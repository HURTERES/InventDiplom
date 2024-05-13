using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventDipl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            TbxPass.UseSystemPasswordChar = true;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.SavedLogin))
            {
                TbxLogin.Text = Properties.Settings.Default.SavedLogin;
                TbxPass.Text = Properties.Settings.Default.SavedPassword;
            }
        }

        private bool IsSameImage(Image img1, Image img2)
        {
            using (MemoryStream ms1 = new MemoryStream(), ms2 = new MemoryStream())
            {
                img1.Save(ms1, img1.RawFormat);
                img2.Save(ms2, img2.RawFormat);
                return ms1.ToArray().SequenceEqual(ms2.ToArray());
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SavedLogin = "";
            Properties.Settings.Default.SavedPassword = "";
            Properties.Settings.Default.Save();

            this.Close();
        }

        private void TbxPass_IconRightClick(object sender, EventArgs e)
        {
            Image visibleIcon = Properties.Resources.visible;
            Image closeEyeIcon = Properties.Resources.close_eye;

            if (IsSameImage(TbxPass.IconRight, visibleIcon))
            {
                TbxPass.IconRight = closeEyeIcon;
                TbxPass.UseSystemPasswordChar = true;
            }
            else if (IsSameImage(TbxPass.IconRight, closeEyeIcon))
            {
                TbxPass.IconRight = visibleIcon;
                TbxPass.UseSystemPasswordChar = false;
            }
        }

        private void ButtonSignIn_Click(object sender, EventArgs e)
        {
            int Count = 0;
            SqlConnection Con = new SqlConnection(FormMain.TxtCon);
            Con.Open();
            SqlCommand Cmd = new SqlCommand($"select * from Users", Con);
            SqlDataReader Res = Cmd.ExecuteReader();
            if (Res != null)
            while (Res.Read())
            {
                    if (TbxLogin.Text == Res["Login"].ToString() && TbxPass.Text == Res["Password"].ToString())
                    {
                        Count++;
                        FormMain Frm = new FormMain();
                        try { Frm.PbxPhotoUser.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\\Photo\\" + Res["Image"].ToString()); }
                        catch { Frm.PbxPhotoUser.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\\Photo\\person.png"); }

                        if (CbxRemember.Checked == true)
                        {
                            Properties.Settings.Default.SavedLogin = TbxLogin.Text;
                            Properties.Settings.Default.SavedPassword = TbxPass.Text;
                            Properties.Settings.Default.Save();
                        }

                        this.Hide();
                        Frm.ShowDialog();
                        this.Show();
                        TbxLogin.Clear();
                        TbxPass.Clear();
                    }
            }
            if (Count == 0)
                MessageBox.Show("Неверный логин или пароль");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
