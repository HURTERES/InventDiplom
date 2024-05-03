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

        private void TbxPass_IconLeftClick(object sender, EventArgs e)
        {
            Image visibleIcon = Properties.Resources.visible;
            Image closeEyeIcon = Properties.Resources.close_eye;

            if (IsSameImage(TbxPass.IconLeft, visibleIcon))
            {
                TbxPass.IconLeft = closeEyeIcon;
                TbxPass.UseSystemPasswordChar = true;
            }
            else if (IsSameImage(TbxPass.IconLeft, closeEyeIcon))
            {
                TbxPass.IconLeft = visibleIcon;
                TbxPass.UseSystemPasswordChar = false;
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
            this.Close();
        }
    }
}
