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

namespace WindowsFormsApp2
{
    public partial class Form8 : Form
    {
        private Button btnBack;
        private string _rtfFile;
        private RichTextBox richTextBox1;

        private void LoadRtf()
        {
            string rtfFilePath = Path.Combine(Application.StartupPath, _rtfFile);

            if (File.Exists(rtfFilePath))
            {
                richTextBox1.LoadFile(rtfFilePath, RichTextBoxStreamType.RichText);
            }
        }

        public Form8(string rtfFile)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            _rtfFile = rtfFile;

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
                Padding = new Padding(20, 0, 20, 20),
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

            panel.Controls.Add(richTextBox1);
            Controls.Add(panel);

            LoadRtf();
        }
    }
}
