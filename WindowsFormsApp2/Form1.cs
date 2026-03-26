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
    public partial class Form1 : Form
    {
        private Panel panelButtons;
        private Button btnOpenArticle;
        private Button btnDrawing;
        private Button btnExit;
        private Button btnTheory;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(818, 497);
            StartPosition = FormStartPosition.CenterScreen;

            panelButtons = new Panel();
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Height = 497;
            panelButtons.BackColor = Color.FromArgb(255, 192, 128);
            panelButtons.Padding = new Padding(10);

            btnOpenArticle = new Button();
            btnOpenArticle.Text = "Вступ";
            btnOpenArticle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnOpenArticle.Size = new Size(170, 70);
            btnOpenArticle.BackColor = Color.Blue;
            btnOpenArticle.ForeColor = Color.White;
            btnOpenArticle.FlatStyle = FlatStyle.Flat;
            btnOpenArticle.Click += (s, e) =>
            {
                Form2 f2 = new Form2();
                this.Hide();
                f2.ShowDialog();
                this.Show();
            };

            btnTheory = new Button();
            btnTheory.Text = "Теорія";
            btnTheory.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnTheory.Size = new Size(170, 70);
            btnTheory.BackColor = Color.Blue;
            btnTheory.ForeColor = Color.White;
            btnTheory.FlatStyle = FlatStyle.Flat;
            ContextMenuStrip theoryMenu = new ContextMenuStrip();
            theoryMenu.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            theoryMenu.BackColor = Color.White;

            ToolStripMenuItem item1 = new ToolStripMenuItem("Хроматичні аберації");
            item1.Click += (s, e) =>
            {
                Form4 f4 = new Form4("Х.а..rtf");
                this.Hide();
                f4.ShowDialog();
                this.Show();
            };

            ToolStripMenuItem item2 = new ToolStripMenuItem("Сферичні аберації");
            item2.Click += (s, e) =>
            {
                Form4 f4 = new Form4("С.а..rtf");
                this.Hide();
                f4.ShowDialog();
                this.Show();
            };

            theoryMenu.Items.AddRange(new ToolStripItem[] { item1, item2 });

            btnTheory.Click += (s, e) =>
            {
                theoryMenu.Show(btnTheory, new Point(0, btnTheory.Height));
            };

            btnDrawing = new Button();
            btnDrawing.Text = "Побудова";
            btnDrawing.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnDrawing.Size = new Size(170, 70);
            btnDrawing.BackColor = Color.Blue;
            btnDrawing.ForeColor = Color.White;
            btnDrawing.FlatStyle = FlatStyle.Flat;
            btnDrawing.Click += (s, e) =>
            {
                Form3 f3 = new Form3();
                this.Hide();
                f3.ShowDialog();
                this.Show();
            };

            btnExit = new Button();
            btnExit.Text = "До титульної сторінки";
            btnExit.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnExit.Size = new Size(170, 70);
            btnExit.BackColor = Color.Blue;
            btnExit.ForeColor = Color.White;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Click += (s, e) =>
            {
                Form6 f6 = new Form6();
                this.Hide();
                f6.ShowDialog();
                this.Show();
            };

            panelButtons.Controls.Add(btnOpenArticle);
            panelButtons.Controls.Add(btnTheory);
            panelButtons.Controls.Add(btnDrawing);
            panelButtons.Controls.Add(btnExit);

            panelButtons.Resize += (s, e) =>
            {
                int spacing = 29;
                int totalWidth = btnOpenArticle.Width + btnTheory.Width + btnDrawing.Width + btnExit.Width + (3 * spacing);
                int startX = (panelButtons.Width) / 2;
                int centerY = (panelButtons.Height - btnOpenArticle.Height) / 2;

                btnOpenArticle.Location = new Point(btnOpenArticle.Location.X + spacing / 2, centerY); 
                btnTheory.Location = new Point(btnOpenArticle.Location.X + btnOpenArticle.Width + spacing, centerY); 
                btnDrawing.Location = new Point(btnOpenArticle.Location.X + btnOpenArticle.Width + btnTheory.Width + 2 * spacing, centerY); 
                btnExit.Location = new Point(btnOpenArticle.Location.X + btnOpenArticle.Width + btnTheory.Width + btnDrawing.Width + 3 * spacing, centerY);
            };

            Controls.Add(panelButtons);
        }
    }
}