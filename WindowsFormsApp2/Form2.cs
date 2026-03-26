using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        private Button btnBack;
        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            Size = new Size(1117, 718);
            StartPosition = FormStartPosition.CenterScreen;

            richTextBox1 = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = false,
                BorderStyle = BorderStyle.None,
                BackColor = Color.White
            };
            Controls.Add(richTextBox1);

            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20, 0, 0, 0),
                BackColor = Color.White
            };

            Panel panelButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 45,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            btnBack = new Button()
            {
                Text = "До меню",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Size = new Size(100, 40),
                BackColor = Color.Blue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnBack.Click += (s, e) => Close();

            panelButtons.Controls.Add(btnBack);

            panelButtons.Resize += (s, e) =>
            {
                btnBack.Location = new Point((panelButtons.Width - btnBack.Width) / 2, (panelButtons.Height - btnBack.Height) / 2);
            };

            Controls.Add(panelButtons);

            string rtfFilePath = Path.Combine(Application.StartupPath, "вступ.rtf");
            if (File.Exists(rtfFilePath))
            {
                richTextBox1.LoadFile(rtfFilePath, RichTextBoxStreamType.RichText);
            }

            panel.Controls.Add(richTextBox1);
            Controls.Add(panel);
        }
    }
}