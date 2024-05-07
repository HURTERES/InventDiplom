using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace InventDipl
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static string TxtCon = @"Data Source=213.155.192.79,3002;Initial Catalog=DBInvent;User ID=u21obolen;Password=s8kd";
        private void Zoom_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else this.WindowState =FormWindowState.Maximized;
        }
        int Count = 0;
        void GeneratePanel(int Count)
        {
            PictureBox Pbx = new PictureBox();
            Pbx.Location = new System.Drawing.Point(8, 8);
            Pbx.Name = "Pbx";
            Pbx.Size = new System.Drawing.Size(97, 84);
            Pbx.TabIndex = 0;
            Pbx.TabStop = false;
            Pbx.Click += ShowLabelInformation;

            System.Windows.Forms.Label LblId = new System.Windows.Forms.Label();
            LblId.AutoSize = true;
            LblId.BackColor = System.Drawing.Color.Transparent;
            LblId.Location = new System.Drawing.Point(112, 8);
            LblId.Name = "LblId";
            LblId.Size = new System.Drawing.Size(16, 13);
            LblId.TabIndex = 1;
            LblId.Text = Id;
            LblId.Click+= ShowLabelInformation;

            System.Windows.Forms.Label LblName = new System.Windows.Forms.Label();
            LblName.BackColor = System.Drawing.Color.Transparent;
            LblName.Font = new System.Drawing.Font("Felix Titling", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LblName.Location = new System.Drawing.Point(120, 8);
            LblName.Name = "LblName";
            LblName.Size = new System.Drawing.Size(154, 94);
            LblName.TabIndex = 3;
            LblName.Text = Names;
            LblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            LblName.Click += ShowLabelInformation;

            System.Windows.Forms.Label LblNum = new System.Windows.Forms.Label();
            LblNum.BackColor = System.Drawing.Color.Transparent;
            LblNum.Font = new System.Drawing.Font("Felix Titling", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LblNum.Location = new System.Drawing.Point(283, 6);
            LblNum.Name = "LblNum";
            LblNum.Size = new System.Drawing.Size(90, 94);
            LblNum.TabIndex = 4;
            LblNum.Text = Num;
            LblNum.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            LblNum.Click += ShowLabelInformation;

            System.Windows.Forms.Label LblUnit = new System.Windows.Forms.Label();
            LblUnit.BackColor = System.Drawing.Color.Transparent;
            LblUnit.Font = new System.Drawing.Font("Felix Titling", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LblUnit.Location = new System.Drawing.Point(387, 3);
            LblUnit.Name = "LblUnit";
            LblUnit.Size = new System.Drawing.Size(185, 34);
            LblUnit.TabIndex = 5;
            LblUnit.Text = Unit;
            LblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            LblUnit.Click += ShowLabelInformation;

            System.Windows.Forms.Label LblPrice= new System.Windows.Forms.Label();
            LblPrice.BackColor = System.Drawing.Color.Transparent;
            LblPrice.Font = new System.Drawing.Font("Felix Titling", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LblPrice.Location = new System.Drawing.Point(589, 6);
            LblPrice.Name = "LblPrice";
            LblPrice.Size = new System.Drawing.Size(149, 34);
            LblPrice.TabIndex = 6;
            LblPrice.Text = Price;
            LblPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            LblPrice.Click += ShowLabelInformation;

            System.Windows.Forms.Label LblCount = new System.Windows.Forms.Label();
            LblCount.BackColor = System.Drawing.Color.Transparent;
            LblCount.Font = new System.Drawing.Font("Felix Titling", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LblCount.Location = new System.Drawing.Point(387, 42);
            LblCount.Name = "LblCount";
            LblCount.Size = new System.Drawing.Size(185, 34);
            LblCount.TabIndex = 7;
            LblCount.Text = Counts;
            LblCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            LblCount.Click += ShowLabelInformation;

            System.Windows.Forms.Label LblTotal = new System.Windows.Forms.Label();
            LblTotal.BackColor = System.Drawing.Color.Transparent;
            LblTotal.Font = new System.Drawing.Font("Felix Titling", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LblTotal.Location = new System.Drawing.Point(589, 42);
            LblTotal.Name = "LblTotal";
            LblTotal.Size = new System.Drawing.Size(149, 58);
            LblTotal.TabIndex = 8;
            LblTotal.Text = Cost;
            LblTotal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            LblTotal.Click+= ShowLabelInformation;

            System.Windows.Forms.Label LblStatus = new System.Windows.Forms.Label();
            LblStatus.BackColor = System.Drawing.Color.Transparent;
            LblStatus.Font = new System.Drawing.Font("Felix Titling", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LblStatus.Location = new System.Drawing.Point(750, 6);
            LblStatus.Name = "LblStatus";
            LblStatus.Size = new System.Drawing.Size(210, 29);
            LblStatus.TabIndex = 15;
            LblStatus.Text = Status;
            LblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            LblStatus.Click += ShowLabelInformation;

            System.Windows.Forms.Label LblPurpose = new System.Windows.Forms.Label();
            LblPurpose.BackColor = System.Drawing.Color.Transparent;
            LblPurpose.Font = new System.Drawing.Font("Felix Titling", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LblPurpose.Location = new System.Drawing.Point(744, 42);
            LblPurpose.Name = "LblPurpose";
            LblPurpose.Size = new System.Drawing.Size(216, 58);
            LblPurpose.TabIndex = 10;
            LblPurpose.Text = Purpose;
            LblPurpose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            LblStatus.Click += ShowLabelInformation;

            System.Windows.Forms.Label LblAccountNum= new System.Windows.Forms.Label();
            LblAccountNum.BackColor = System.Drawing.Color.Transparent;
            LblAccountNum.Font = new System.Drawing.Font("Felix Titling", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LblAccountNum.Location = new System.Drawing.Point(966, 8);
            LblAccountNum.Name = "LblAccountNum";
            LblAccountNum.Size = new System.Drawing.Size(216, 29);
            LblAccountNum.TabIndex = 16;
            LblAccountNum.Text = AccountNum;
            LblAccountNum.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            LblAccountNum.Click += ShowLabelInformation;

            System.Windows.Forms.Label LblBookValue = new System.Windows.Forms.Label();
            LblBookValue.BackColor = System.Drawing.Color.Transparent;
            LblBookValue.Font = new System.Drawing.Font("Felix Titling", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LblBookValue.Location = new System.Drawing.Point(966, 42);
            LblBookValue.Name = "LblBookValue";
            LblBookValue.Size = new System.Drawing.Size(216, 58);
            LblBookValue.TabIndex = 12;
            LblBookValue.Text = BookValue;
            LblBookValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            LblBookValue.Click += ShowLabelInformation;

            System.Windows.Forms.Label LblNote = new System.Windows.Forms.Label();
            LblNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            LblNote.BackColor = System.Drawing.Color.Transparent;
            LblNote.Font = new System.Drawing.Font("Felix Titling", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LblNote.Location = new System.Drawing.Point(1188, 6);
            LblNote.Name = "LblNote";
            LblNote.Size = new System.Drawing.Size(164, 96);
            LblNote.TabIndex = 13;
            LblNote.Text = Note;
            LblNote.Click += ShowLabelInformation;

            // Разделяющие панели
            System.Windows.Forms.Panel Pn1 = new System.Windows.Forms.Panel();
            Pn1.BackColor = System.Drawing.Color.Black;
            Pn1.Location = new System.Drawing.Point(275, 0);
            Pn1.Name = "Pn1";
            Pn1.Size = new System.Drawing.Size(2, 84);
            Pn1.TabIndex = 18;
            System.Windows.Forms.Panel Pn2 = new System.Windows.Forms.Panel();
            Pn2.BackColor = System.Drawing.Color.Black;
            Pn2.Location = new System.Drawing.Point(379, 0);
            Pn2.Name = "Pn2";
            Pn2.Size = new System.Drawing.Size(2, 84);
            Pn2.TabIndex = 19;
            System.Windows.Forms.Panel Pn3 = new System.Windows.Forms.Panel();
            Pn3.BackColor = System.Drawing.Color.Black;
            Pn3.Location = new System.Drawing.Point(578, 0);
            Pn3.Name = "Pn3";
            Pn3.Size = new System.Drawing.Size(2, 84);
            Pn3.TabIndex = 20;
            System.Windows.Forms.Panel Pn4 = new System.Windows.Forms.Panel();
            Pn4.BackColor = System.Drawing.Color.Black;
            Pn4.Location = new System.Drawing.Point(742, 0);
            Pn4.Name = "Pn4";
            Pn4.Size = new System.Drawing.Size(2, 84);
            Pn4.TabIndex = 21;
            System.Windows.Forms.Panel Pn5 = new System.Windows.Forms.Panel();
            Pn5.BackColor = System.Drawing.Color.Black;
            Pn5.Location = new System.Drawing.Point(958, 0);
            Pn5.Name = "Pn5";
            Pn5.Size = new System.Drawing.Size(2, 84);
            Pn5.TabIndex = 21;
            System.Windows.Forms.Panel Pn6 = new System.Windows.Forms.Panel();
            Pn6.BackColor = System.Drawing.Color.Black;
            Pn6.Location = new System.Drawing.Point(1188, 0);
            Pn6.Name = "Pn6";
            Pn6.Size = new System.Drawing.Size(2, 84);
            Pn6.TabIndex = 21;

            Guna2CustomGradientPanel guna2CustomGradientPanel2 = new Guna2CustomGradientPanel();
            guna2CustomGradientPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            guna2CustomGradientPanel2.Controls.Add(Pn6);
            guna2CustomGradientPanel2.Controls.Add(Pn5);
            guna2CustomGradientPanel2.Controls.Add(Pn4);
            guna2CustomGradientPanel2.Controls.Add(Pn3);
            guna2CustomGradientPanel2.Controls.Add(Pn1);
            guna2CustomGradientPanel2.Controls.Add(Pn2);
            guna2CustomGradientPanel2.Controls.Add(LblAccountNum);
            guna2CustomGradientPanel2.Controls.Add(LblStatus);
            guna2CustomGradientPanel2.Controls.Add(LblNote);
            guna2CustomGradientPanel2.Controls.Add(LblTotal);
            guna2CustomGradientPanel2.Controls.Add(LblBookValue);
            guna2CustomGradientPanel2.Controls.Add(LblCount);
            guna2CustomGradientPanel2.Controls.Add(LblPrice);
            guna2CustomGradientPanel2.Controls.Add(LblUnit);
            guna2CustomGradientPanel2.Controls.Add(LblNum);
            guna2CustomGradientPanel2.Controls.Add(LblName);
            guna2CustomGradientPanel2.Controls.Add(LblId);
            guna2CustomGradientPanel2.Controls.Add(Pbx);
            guna2CustomGradientPanel2.Controls.Add(LblPurpose);
            guna2CustomGradientPanel2.FillColor = System.Drawing.Color.DarkOrchid;
            guna2CustomGradientPanel2.FillColor2 = System.Drawing.Color.DarkOrchid;
            guna2CustomGradientPanel2.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(163)))), ((int)(((byte)(249)))));
            guna2CustomGradientPanel2.Location = new System.Drawing.Point(5, 100*Count+15*Count-15);
            guna2CustomGradientPanel2.Name = "guna2CustomGradientPanel2";
            guna2CustomGradientPanel2.Size = new System.Drawing.Size(1359, 102);
            guna2CustomGradientPanel2.TabIndex = 1;
            guna2CustomGradientPanel2.Click += Guna2CustomGradientPanel2_Click;

            Guna2Elipse guna2Elipse= new Guna2Elipse();
            guna2Elipse.BorderRadius = 15;
            guna2Elipse.TargetControl =guna2CustomGradientPanel2;
            PanelData.Controls.Add(guna2CustomGradientPanel2);

        }

        System.Windows.Forms.Control CurrentActiveControl;
        private void ShowLabelInformation(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Control control)
            {
                if (control.Parent is Guna2CustomGradientPanel panel)
                {
                    // Сначала изменяем цвет FillColor только для текущей активной панели
                    panel.FillColor = Color.LimeGreen;
                    panel.FillColor2 = Color.Lime;
                    panel.FillColor4 = Color.White;

                    // Затем проходим по всем панелям в контейнере PanelData и изменяем цвет FillColor на DarkOrchid
                    foreach (System.Windows.Forms.Control ctrl in PanelData.Controls)
                    {
                        if (ctrl is Guna2CustomGradientPanel otherPanel && otherPanel != panel)
                        {
                            otherPanel.FillColor = Color.DarkOrchid;
                            otherPanel.FillColor2 = Color.DarkOrchid;
                            otherPanel.FillColor4 = Color.FromArgb(221, 163, 249);
                        }
                    }

                    // Сохраняем текущий активный элемент как панель Guna2CustomGradientPanel
                    CurrentActiveControl = panel;

                    // Далее идет ваш код обработки меток в панели
                    foreach (System.Windows.Forms.Control ctrl in panel.Controls)
                    {
                        if (ctrl is System.Windows.Forms.Label label)
                        {
                            switch (label.Name)
                            {
                                case "LblId":
                                    Id = label.Text;
                                    break;
                                case "LblName":
                                    Names = label.Text;
                                    break;
                                case "LblNum":
                                    Num = label.Text;
                                    break;
                                case "LblUnit":
                                    Unit = label.Text;
                                    break;
                                case "LblPrice":
                                    Price = label.Text;
                                    break;
                                case "LblCount":
                                    Counts = label.Text;
                                    break;
                                case "LblCost":
                                    Cost = label.Text;
                                    break;
                                case "LblStatus":
                                    Status = label.Text;
                                    break;
                                case "LblPurpose":
                                    Purpose = label.Text;
                                    break;
                                case "LblAccountNum":
                                    AccountNum = label.Text;
                                    break;
                                case "LblBookValue":
                                    BookValue = label.Text;
                                    break;
                                case "LblNote":
                                    Note = label.Text;
                                    break;
                                default:
                                    break;
                            }
                        }
                        else if (ctrl is System.Windows.Forms.PictureBox Pbx)
                        {
                            // Обработка PictureBox, если необходимо
                        }
                    }
                }
            }
        }
        string Id, Names, Num, Unit, Price, Counts, Cost, Status, Purpose, AccountNum, BookValue, Note, Photo;
        private void Guna2CustomGradientPanel2_Click(object sender, EventArgs e)
        {
            if (sender is Guna2CustomGradientPanel panel)
            {
                // Сначала изменяем цвет FillColor только для текущей активной панели
                panel.FillColor = Color.LimeGreen;
                panel.FillColor2 = Color.Lime;
                panel.FillColor4 = Color.White;

                // Затем проходим по всем панелям в контейнере PanelData и изменяем цвет FillColor на DarkOrchid
                foreach (System.Windows.Forms.Control control in PanelData.Controls)
                {
                    if (control is Guna2CustomGradientPanel otherPanel && otherPanel != panel)
                    {
                        otherPanel.FillColor = Color.DarkOrchid;
                        otherPanel.FillColor2 = Color.DarkOrchid;
                        otherPanel.FillColor4 = Color.FromArgb(221, 163, 249);
                    }
                }

                // Сохраняем текущий активный элемент как панель Guna2CustomGradientPanel
                CurrentActiveControl = panel;
            }

            System.Windows.Forms.Control PanelValues = sender as System.Windows.Forms.Control;
            foreach (System.Windows.Forms.Control control in PanelValues.Controls)
                if (control is System.Windows.Forms.Label label)
                {
                    if (label.Name == "LblId")
                        Id = label.Text;

                    if (label.Name == "LblName")
                        Names = label.Text;

                    if (label.Name == "LblNum")
                        Num = label.Text;

                    if (label.Name == "LblUnit")
                        Unit = label.Text;

                    if (label.Name == "LblPrice")
                        Price = label.Text;

                    if (label.Name == "LblCount")
                        Counts = label.Text;

                    if (label.Name == "LblCost")
                        Cost = label.Text;

                    if (label.Name == "LblStatus")
                        Status = label.Text;

                    if (label.Name == "LblPurpose")
                        Purpose = label.Text;

                    if (label.Name == "LblAccountNum")
                        AccountNum = label.Text;

                    if (label.Name == "LblBookValue")
                       BookValue = label.Text;

                    if (label.Name == "LblNote")
                        Note = label.Text;
                }
                else if (control is System.Windows.Forms.PictureBox Pbx)
                {
                    
                }


        }
        private void FormMain_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;

            SqlConnection Con = new SqlConnection(TxtCon);
            SqlCommand Cmd = new SqlCommand("select * from Product", Con);
            Con.Open();
            SqlDataReader Res = Cmd.ExecuteReader();
            if (Res != null)
                while(Res.Read())
                {
                    Count++;
                    Id = Res["IdProduct"].ToString();
                    Names = Res["Name"].ToString();
                    Num = Res["Number"].ToString();
                    Unit= Res["Unit"].ToString();
                    Price= Res["Price"].ToString();
                    Counts= Res["Count"].ToString();
                    Cost= Res["Cost"].ToString();
                    Status= Res["Status"].ToString();
                    Purpose= Res["Purpose"].ToString();
                    AccountNum= Res["AccountNum"].ToString();
                    BookValue= Res["BookValue"].ToString();
                    Note= Res["Note"].ToString();
                    Photo= Application.StartupPath +"\\Photo\\"+Res["Photo"].ToString();
                    GeneratePanel(Count);
                
                }
            Con.Close();

            for (int i = 0; i < 3; i++)
            {
                Count++;
                GeneratePanel(Count);
            }

            PanelData.HorizontalScroll.Enabled = false;
            PanelData.VerticalScroll.Enabled = true;
            PanelData.HorizontalScroll.Maximum = 0;
            PanelData.VerticalScroll.Maximum = 0;
            PanelData.AutoScroll = true;
        }
    }
}
