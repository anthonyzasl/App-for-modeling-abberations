using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp2
{
    public partial class Form7 : Form
    {
        private Chart chart1;
        private Button btnBack;
        public Form7 (float R1,float R2, float n)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            chart1 = new Chart()
            {
                Left = 0,
                Top = 50,
                Dock = DockStyle.Bottom,
                Height = ClientSize.Height
            };
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            ChartArea area = new ChartArea("Main");
            area.AxisX.Title = "d";
            area.AxisY.Title = "F";
            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas.Add(area);

            Series series = new Series("F")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                Color = Color.Blue
            };
            chart1.Series.Add(series);

            Controls.Add(chart1);

            DrawFunction(R1, R2, n);

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

        private void DrawFunction(float R1, float R2, float n)
        {
            double k = (n * R1 * R2) / Math.Pow((n - 1), 2);
            double c = (n * (R1 + R2)) / (n - 1);

            double dMin = 1;
            double dMax = R1;

            var series = chart1.Series["F"];
            series.Points.Clear();

            for (double d = dMin; d <= dMax; d += 1)
            {
                double denom = c - d;
                double F = k / denom;
                series.Points.AddXY(d, F);
            }

            chart1.ChartAreas[0].RecalculateAxesScale();
        }
    }
}
