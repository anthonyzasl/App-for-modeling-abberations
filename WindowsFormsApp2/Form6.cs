using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Титульна сторінка";
            this.BackColor = Color.FromArgb(255, 192, 128);
            this.Size = new Size(900, 750);

            Label lblTop = new Label();
            lblTop.Text = "Дніпровський науковий ліцей інформаційних технологій\nДніпровської міської ради";
            lblTop.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTop.AutoSize = false;
            lblTop.TextAlign = ContentAlignment.MiddleCenter;
            lblTop.Dock = DockStyle.Top;
            lblTop.Height = 120;
            this.Controls.Add(lblTop);

            Label lblTopic = new Label();
            lblTopic.Text = "Випускна робота на тему:\n" + "Хроматичні та сферичні\n" + "аберації оптичних систем";
            lblTopic.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTopic.TextAlign = ContentAlignment.MiddleCenter;
            lblTopic.AutoSize = false;
            lblTopic.Location = new Point(0, 150);
            lblTopic.Size = new Size(this.Width, 150);
            lblTopic.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(lblTopic);

            Label lblAuthor = new Label();
            lblAuthor.Text = "Виконав:\nліцеїст 11–A–1 клас\nЗаславський Антон";
            lblAuthor.Font = new Font("Segoe UI", 14, FontStyle.Regular);
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(this.Width - lblAuthor.Width - 120, 330);
            this.Controls.Add(lblAuthor);

            Label lblTeachers = new Label();
            lblTeachers.Text = "Керівники:\nМогилевська Н.В.\nБоровик Л.І.";
            lblTeachers.Font = new Font("Segoe UI", 14, FontStyle.Regular);
            lblTeachers.AutoSize = true;
            lblTeachers.Location = new Point(this.Width - lblTeachers.Width - 120, 430);
            this.Controls.Add(lblTeachers);

            Label lblBottom = new Label();
            lblBottom.Text = "м. Дніпро\n2025";
            lblBottom.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblBottom.TextAlign = ContentAlignment.MiddleCenter;
            lblBottom.AutoSize = false;
            lblBottom.Size = new Size(this.Width, 80);
            lblBottom.Location = new Point(0, this.Height - 180);
            lblBottom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(lblBottom);

            Button btnExit = new Button();
            btnExit.Text = "Далі";
            btnExit.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnExit.Size = new Size(170, 50);
            btnExit.BackColor = Color.Blue;
            btnExit.ForeColor = Color.White;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Location = new Point((this.Width - btnExit.Width) / 2, this.Height - 90);
            btnExit.Anchor = AnchorStyles.Bottom;
            btnExit.Click += (s, e) =>
            {
                Form1 f1 = new Form1();
                this.Hide();
                f1.ShowDialog();
                this.Show();
            };
            this.Controls.Add(btnExit);

        }
    }
}
