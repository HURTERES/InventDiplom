using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            FormMain Frm = new FormMain();
            Frm.ShowDialog();
        }
    }
}
