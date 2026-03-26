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
    public partial class Form5 : Form
    {
        private TextBox textBoxR, textBoxN, textBoxH;
        private Button btnCalc;
        private DataGridView dataGrid;
        private Label lblR, lblN, lblI;
        private Button btnBack;
        public Form5()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(600, 425);
            BackColor = Color.White;
            StartPosition = FormStartPosition.CenterScreen;
            Font commonFont = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold | FontStyle.Italic);

            lblR = new Label
            {
                Text = "R:",
                Location = new Point(20, 20),
                AutoSize = true,
                Font = commonFont,
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblN = new Label
            {
                Text = "n:",
                Location = new Point(20, 60),
                AutoSize = true,
                Font = commonFont,
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblI = new Label
            {
                Text = "H:",
                Location = new Point(20, 100),
                AutoSize = true,
                Font = commonFont,
                TextAlign = ContentAlignment.MiddleCenter
            };

            textBoxR = new TextBox
            {
                Location = new Point(80, 20),
                Width = 80,
                Text = "50",
                Font = commonFont,
                TextAlign = HorizontalAlignment.Center
            };

            textBoxN = new TextBox
            {
                Location = new Point(80, 60),
                Width = 80,
                Text = "1.5",
                Font = commonFont,
                TextAlign = HorizontalAlignment.Center
            };

            textBoxH = new TextBox
            {
                Location = new Point(80, 100),
                Width = 80,
                Text = "10",
                Font = commonFont,
                TextAlign = HorizontalAlignment.Center
            };

            btnCalc = new Button
            {
                Text = "Розрахувати",
                Location = new Point(20, 140),
                Width = 140,
                Height = 30,
                Font = commonFont,
                BackColor = Color.Blue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCalc.Click += BtnCalc_Click;

            dataGrid = new DataGridView
            {
                Location = new Point(200, 20),
                Size = new Size(360, 300),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            dataGrid.Columns.Add("hi", "hi");
            dataGrid.Columns.Add("Fi", "Fi");

            Controls.Add(lblR);
            Controls.Add(lblN);
            Controls.Add(lblI);
            Controls.Add(textBoxR);
            Controls.Add(textBoxN);
            Controls.Add(textBoxH);
            Controls.Add(btnCalc);
            Controls.Add(dataGrid);

            Panel panelButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            btnBack = new Button()
            {
                Text = "До побудови",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Size = new Size(100, 50),
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
        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBoxR.Text, out double R))
            {
                MessageBox.Show("R не може бути текстом");
                return;
            }
            if (!double.TryParse(textBoxN.Text, out double n))
            {
                MessageBox.Show("n не може бути текстом");
                return;
            }
            if (!double.TryParse(textBoxH.Text, out double H))
            {
                MessageBox.Show("H не може бути текстом");
                return;
            }

            if (H < R && n > 0)
            {
                double alpha = Math.Asin(H / R);
                double beta = Math.Asin(H / (n * R));
                double phi = alpha - beta;
                double F = R * (1 + (H / (n * R * Math.Sin(phi))));

                dataGrid.Rows.Add($"h = {H}", $"F = {Math.Round(F, 0)}");
            }

            if (H == R || H > R || n < 0 || n == 0)
            {
                MessageBox.Show("Перевірте введені дані. H строго менше R, а n строго більше 0");
            }
        }
    }
}
