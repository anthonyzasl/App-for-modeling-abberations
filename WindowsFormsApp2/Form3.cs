using System;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        private int R1;
        private int R2;
        private float h1;
        private float h2;
        private float n1;
        private float n2;
        private float n3;
        private float n;
        private float tg1;
        private float tg2;
        private float tg3;
        private int i;
        private float FS1 = 0;
        private float FS2 = 0;
        private float F1 = 0;
        private float F2 = 0;
        private float F3 = 0;
        private Button btnBack;
        private Bitmap drawingBitmap;
        private Graphics drawingGraphics;
        private bool? overlayLines = null;
        Pen mirror2Pen = new Pen(Color.Blue, 2);
        Pen mirrorPen = new Pen(Color.Blue, 2) { DashPattern = new float[] { 5, 5 } };
        Pen dashedPen = new Pen(Color.Orange, 2) { DashPattern = new float[] { 5, 5 } };
        Pen blackDashedPen = new Pen(Color.Black, 2) { DashPattern = new float[] { 5, 5 } };
        Pen rayPen = new Pen(Color.Gray, 4);
        Pen redPen = new Pen(Color.Red, 2);
        Pen yellowPen = new Pen(Color.Yellow, 2);
        Pen bluePen = new Pen(Color.Blue, 2);
        Pen violetPen = new Pen(Color.Violet, 2);
        Pen greenPen = new Pen(Color.Green, 2);
        Pen boldPen = new Pen(Color.Black, 2);
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private ToolTip toolTip3;   
        private ToolTip toolTip4;  
        private ToolTip toolTip5;
        private ToolTip toolTip6;
        private ToolTip toolTip8;
        private ToolTip toolTip10;
        private ToolTip toolTip12;

        public Form3()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            drawingBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            drawingGraphics = Graphics.FromImage(drawingBitmap);
            drawingGraphics.Clear(Color.White);

            pictureBox1.Image = drawingBitmap;

            pictureBox1.Paint += pictureBox1_Paint;

            Panel panelButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 80,
                BackColor = Color.FromArgb(255, 192, 128),
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

            button6.Text = "?";
            button6.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            button6.Size = new Size(100, 40);
            button6.BackColor = Color.Blue;
            button6.ForeColor = Color.White;
            button6.FlatStyle = FlatStyle.Flat;

            button6.Click += (s, e) =>
            {
                Form8 f8 = new Form8("пояснення.rtf");
                this.Hide();
                f8.ShowDialog();
                this.Show();
            };

            panelButtons.Controls.Add(btnBack);

            panelButtons.Resize += (s, e) =>
            {
                btnBack.Location = new Point((panelButtons.Width - btnBack.Width) / 2, (panelButtons.Height - btnBack.Height) / 2);
            };

            Controls.Add(panelButtons);

            button2.Click += (s, e) =>
            {
                if (float.TryParse(textBox1.Text, out float R1) && float.TryParse(textBox2.Text, out float R2) && float.TryParse(textBox4.Text, out float n))
                {
                    Form7 f7 = new Form7(R1, R2, n);
                    this.Hide();
                    f7.ShowDialog();
                    this.Show();
                }
            };
            button4.Click += (s, e) =>
            {
                Form5 f5 = new Form5();
                this.Hide();
                f5.ShowDialog();
                this.Show();
            };

            button5.Click += (s, e) =>
            {
                ClearDrawingAndReset(false);
            };

            void ClearDrawingAndReset(bool clearTextBoxes)
            {
                if (drawingBitmap != null)
                {
                    drawingBitmap.Dispose();
                }
                if (drawingGraphics != null)
                {
                    drawingGraphics.Dispose();
                }

                drawingBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                drawingGraphics = Graphics.FromImage(drawingBitmap);
                drawingGraphics.Clear(Color.White);
                pictureBox1.Image = drawingBitmap;
                pictureBox1.Refresh();
                FS1 = 0;
                FS2 = 0;
                F1 = 0;
                F2 = 0;
                F3 = 0;
                overlayLines = false;

                R1 = 0;
                R2 = 0;
                h1 = h2 = n1 = n2 = n3 = n = tg1 = tg2 = tg3 = 0;
                i = 0;
            }

            toolTip1 = new ToolTip();
            toolTip1.SetToolTip(label4, "Перший радіус");
            toolTip3 = new ToolTip();
            toolTip3.SetToolTip(label6, "Другий радіус");
            toolTip5 = new ToolTip();
            toolTip5.SetToolTip(label8, "Індекс");
            toolTip4 = new ToolTip();
            toolTip4.SetToolTip(label5, "Другий радіус");
            toolTip2 = new ToolTip();
            toolTip2.SetToolTip(label3, "Перший радіус");
            toolTip6 = new ToolTip();
            toolTip6.SetToolTip(label7, "Індекс");
            toolTip8 = new ToolTip();
            toolTip8.SetToolTip(label9, "Показник заломлення");
            toolTip10 = new ToolTip();
            toolTip10.SetToolTip(label11, "Перша висота");
            toolTip12 = new ToolTip();
            toolTip12.SetToolTip(label13, "Друга висота");
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label1.Show();
                label4.Show();
                label6.Show();
                label8.Show();

                label2.Hide();
                label3.Hide();
                label5.Hide();
                label7.Hide();
                label9.Hide();
                label11.Hide();
                label13.Hide();

                int centerX = pictureBox1.Width / 2;
                int centerY = pictureBox1.Height / 2;

                if (overlayLines == null)
                {
                    DialogResult result = MessageBox.Show(
                        "Чи хочете ви зберігати старі побудови?",
                        "Режим малювання",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    overlayLines = (result == DialogResult.Yes);
                }

                e.Graphics.DrawImage(drawingBitmap, Point.Empty);

                Graphics tempGraphics = overlayLines == true ? drawingGraphics : e.Graphics;

                void DrawArrow(Graphics gfx, Pen pen, int x1, int y1, int x2, int y2)
                {
                    gfx.DrawLine(pen, x1, y1, x2, y2);
                    double angle = Math.Atan2(y2 - y1, x2 - x1);
                    PointF arrowP1 = new PointF(x2 - (float)(10 * Math.Cos(angle - Math.PI / 6)), y2 - (float)(10 * Math.Sin(angle - Math.PI / 6)));
                    PointF arrowP2 = new PointF(x2 - (float)(10 * Math.Cos(angle + Math.PI / 6)), y2 - (float)(10 * Math.Sin(angle + Math.PI / 6)));
                    gfx.DrawLine(pen, x2, y2, (int)arrowP1.X, (int)arrowP1.Y);
                    gfx.DrawLine(pen, x2, y2, (int)arrowP2.X, (int)arrowP2.Y);
                }

                DrawArrow(tempGraphics, mirrorPen, centerX, centerY + 100, centerX, centerY - 100);
                DrawArrow(tempGraphics, mirrorPen, centerX, centerY - 100, centerX, centerY + 100);

                tempGraphics.DrawLine(dashedPen, 0, centerY, pictureBox1.Width, centerY);

                if (i == 1 && R1 > 9 && R1 < 36 && R2 > 9 && R2 < 36)
                {
                    tempGraphics.DrawLine(rayPen, centerX - 150, centerY - 50, pictureBox1.Width / 2, pictureBox1.Height / 2 - 50);

                    tempGraphics.DrawLine(rayPen, centerX - 150, centerY + 50, pictureBox1.Width / 2, pictureBox1.Height / 2 + 50);

                    tempGraphics.DrawLine(redPen, pictureBox1.Width / 2, pictureBox1.Height / 2 - 50, (float)centerX + F1, centerY);
                    tempGraphics.DrawLine(redPen, (float)centerX + F1, centerY, (float)((float)centerX + F1 + ((float)centerX + F1 - pictureBox1.Width / 2)), (float)(centerY + (centerY - (pictureBox1.Height / 2 - 50))));
                    tempGraphics.DrawLine(redPen, pictureBox1.Width / 2, pictureBox1.Height / 2 + 50, (float)centerX + F1, centerY);
                    tempGraphics.DrawLine(redPen, (float)centerX + F1, centerY, (float)(2 * ((float)centerX + F1) - pictureBox1.Width / 2), (float)(2 * centerY - (pictureBox1.Height / 2 + 50)));

                    tempGraphics.DrawLine(blackDashedPen, (float)centerX + F1, centerY, (float)centerX + F1, centerY + 75);
                    tempGraphics.DrawLine(blackDashedPen, (float)centerX + F1, centerY, (float)centerX + F1, centerY - 75);

                    float radius1 = 5 / 2f;
                    float radius2 = (F1 - F3) * tg3 / 2 / 2f;
                    float radius3 = (F3 - F2) * tg1 / 2 / 2f;

                    float centerXTotal = centerX + F1;
                    float centerYTotal = centerY + 150;

                    tempGraphics.DrawEllipse(redPen, centerXTotal - radius1, centerYTotal - radius1, radius1 * 2, radius1 * 2);
                    tempGraphics.DrawEllipse(greenPen, centerXTotal - radius2, centerYTotal - radius2, radius2 * 2, radius2 * 2);
                    tempGraphics.DrawEllipse(violetPen, centerXTotal - radius3, centerYTotal - radius3, radius3 * 2, radius3 * 2);
                }

                if (i == 2 && R1 > 9 && R1 < 36 && R2 > 9 && R2 < 36)
                {
                    tempGraphics.DrawLine(rayPen, centerX - 150, centerY - 50, pictureBox1.Width / 2, pictureBox1.Height / 2 - 50);

                    tempGraphics.DrawLine(rayPen, centerX - 150, centerY + 50, pictureBox1.Width / 2, pictureBox1.Height / 2 + 50);

                    tempGraphics.DrawLine(greenPen, pictureBox1.Width / 2, pictureBox1.Height / 2 - 50, (float)centerX + F3, centerY);
                    tempGraphics.DrawLine(greenPen, (float)centerX + F3, centerY, (float)((float)centerX + F3 + ((float)centerX + F3 - pictureBox1.Width / 2)), (float)(centerY + (centerY - (pictureBox1.Height / 2 - 50))));
                    tempGraphics.DrawLine(greenPen, pictureBox1.Width / 2, pictureBox1.Height / 2 + 50, (float)centerX + F3, centerY);
                    tempGraphics.DrawLine(greenPen, (float)centerX + F3, centerY, (float)(2 * ((float)centerX + F3) - pictureBox1.Width / 2), (float)(2 * centerY - (pictureBox1.Height / 2 + 50)));

                    tempGraphics.DrawLine(blackDashedPen, (float)centerX + F3, centerY, (float)centerX + F3, centerY + 75);
                    tempGraphics.DrawLine(blackDashedPen, (float)centerX + F3, centerY, (float)centerX + F3, centerY - 75);

                    float radius1 = 5 / 2f;
                    float radius2 = (F1 - F3) * tg2 / 2 / 2f;
                    float radius3 = (F3 - F2) * tg1 / 2 / 2f;

                    float centerXTotal = centerX + F3;
                    float centerYTotal = centerY + 150;

                    tempGraphics.DrawEllipse(greenPen, centerXTotal - radius1, centerYTotal - radius1, radius1 * 2, radius1 * 2);
                    tempGraphics.DrawEllipse(redPen, centerXTotal - radius2, centerYTotal - radius2, radius2 * 2, radius2 * 2);
                    tempGraphics.DrawEllipse(violetPen, centerXTotal - radius3, centerYTotal - radius3, radius3 * 2, radius3 * 2);
                }

                if (i == 3 && R1 > 9 && R1 < 36 && R2 > 9 && R2 < 36)
                {
                    tempGraphics.DrawLine(rayPen, centerX - 150, centerY - 50, pictureBox1.Width / 2, pictureBox1.Height / 2 - 50);

                    tempGraphics.DrawLine(rayPen, centerX - 150, centerY + 50, pictureBox1.Width / 2, pictureBox1.Height / 2 + 50);

                    tempGraphics.DrawLine(violetPen, pictureBox1.Width / 2, pictureBox1.Height / 2 - 50, (float)centerX + F2, centerY);
                    tempGraphics.DrawLine(violetPen, (float)centerX + F2, centerY, (float)centerX + F2 + 2 * ((float)centerX + F2 - pictureBox1.Width / 2), centerY + 2 * (centerY - (pictureBox1.Height / 2 - 50)));
                    tempGraphics.DrawLine(violetPen, pictureBox1.Width / 2, pictureBox1.Height / 2 + 50, (float)centerX + F2, centerY);
                    tempGraphics.DrawLine(violetPen, (float)centerX + F2, centerY, (float)centerX + F2 + 2 * ((float)centerX + F2 - pictureBox1.Width / 2), centerY + 2 * (centerY - (pictureBox1.Height / 2 + 50)));

                    if (overlayLines == true && boldPen != null)
                    {
                        tempGraphics.DrawLine(boldPen, centerX + F1, centerY, centerX + F2, centerY);
                    }

                    tempGraphics.DrawLine(blackDashedPen, (float)centerX + F2, centerY, (float)centerX + F2, centerY + 75);
                    tempGraphics.DrawLine(blackDashedPen, (float)centerX + F2, centerY, (float)centerX + F2, centerY - 75);

                    float radius1 = 5 / 2f;
                    float radius2 = (F3 - F2) * tg3 / 2 / 2f;
                    float radius3 = (F1 - F2) * tg2 / 2 / 2f;

                    float centerXTotal = centerX + F2;
                    float centerYTotal = centerY + 150;

                    tempGraphics.DrawEllipse(violetPen, centerXTotal - radius1, centerYTotal - radius1, radius1 * 2, radius1 * 2);
                    tempGraphics.DrawEllipse(greenPen, centerXTotal - radius2, centerYTotal - radius2, radius2 * 2, radius2 * 2);
                    tempGraphics.DrawEllipse(redPen, centerXTotal - radius3, centerYTotal - radius3, radius3 * 2, radius3 * 2);
                }

                pictureBox1.Invalidate();
            }

            if (radioButton2.Checked == true)
            {
                label2.Show();
                label3.Show();
                label5.Show();
                label7.Show();
                label9.Show();
                label11.Show();
                label13.Show();

                label1.Hide();
                label4.Hide();
                label6.Hide();
                label8.Hide();

                int centerX = pictureBox1.Width / 2;
                int centerY = pictureBox1.Height / 2;

                if (overlayLines == null)
                {
                    DialogResult result = MessageBox.Show(
                        "Чи хочете ви зберігати старі побудови?",
                        "Режим малювання",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    overlayLines = (result == DialogResult.Yes);
                }

                e.Graphics.DrawImage(drawingBitmap, Point.Empty);

                Graphics tempGraphics = overlayLines == true ? drawingGraphics : e.Graphics;

                void DrawArrow(Graphics gfx, Pen pen, int x1, int y1, int x2, int y2)
                {
                    gfx.DrawLine(pen, x1, y1, x2, y2);
                    double angle = Math.Atan2(y2 - y1, x2 - x1);
                    PointF arrowP1 = new PointF(x2 - (float)(10 * Math.Cos(angle - Math.PI / 6)), y2 - (float)(10 * Math.Sin(angle - Math.PI / 6)));
                    PointF arrowP2 = new PointF(x2 - (float)(10 * Math.Cos(angle + Math.PI / 6)), y2 - (float)(10 * Math.Sin(angle + Math.PI / 6)));
                    gfx.DrawLine(pen, x2, y2, (int)arrowP1.X, (int)arrowP1.Y);
                    gfx.DrawLine(pen, x2, y2, (int)arrowP2.X, (int)arrowP2.Y);
                }

                DrawArrow(tempGraphics, mirrorPen, centerX, centerY + 100, centerX, centerY - 100);
                DrawArrow(tempGraphics, mirrorPen, centerX, centerY - 100, centerX, centerY + 100);

                tempGraphics.DrawLine(dashedPen, 0, centerY, pictureBox1.Width, centerY);

                if (i == 1 && h1 < R1 && h2 < R2 && n > 1.3 && n < 1.7 && R1 > 40 && R1 < 76)
                {
                    FS1 = 2 * (n * R1 * R2) / ((n - 1) * n * (R1 + R2) - (n - 1) * 20);
                    tempGraphics.DrawLine(rayPen, centerX - 150, centerY - h1, pictureBox1.Width / 2, pictureBox1.Height / 2 - h1);
                    tempGraphics.DrawLine(rayPen, centerX - 150, centerY + h1, pictureBox1.Width / 2, pictureBox1.Height / 2 + h1);
                    tempGraphics.DrawLine(greenPen, pictureBox1.Width / 2, pictureBox1.Height / 2 - h1, pictureBox1.Width / 2 + FS1, pictureBox1.Height / 2);
                    tempGraphics.DrawLine(greenPen, pictureBox1.Width / 2, pictureBox1.Height / 2 + h1, pictureBox1.Width / 2 + FS1, pictureBox1.Height / 2);
                }
                if (i == 2 && h1 < R1 && h2 < R2 && n > 1.3 && n < 1.7 && R2 > 40 && R2 < 76)
                {
                    FS2 = (n * R1 * R2) / ((n - 1) * n * (R1 + R2) - (n - 1) * 0);
                    tempGraphics.DrawLine(rayPen, centerX - 150, centerY - h2, pictureBox1.Width / 2, pictureBox1.Height / 2 - h2);
                    tempGraphics.DrawLine(rayPen, centerX - 150, centerY + h2, pictureBox1.Width / 2, pictureBox1.Height / 2 + h2);
                    tempGraphics.DrawLine(greenPen, pictureBox1.Width / 2, pictureBox1.Height / 2 - h2, pictureBox1.Width / 2 + FS2, pictureBox1.Height / 2);
                    tempGraphics.DrawLine(greenPen, pictureBox1.Width / 2, pictureBox1.Height / 2 + h2, pictureBox1.Width / 2 + FS2, pictureBox1.Height / 2);

                    if (overlayLines == true && boldPen != null)
                    {
                        tempGraphics.DrawLine(boldPen, pictureBox1.Width / 2 + FS1, pictureBox1.Height / 2, centerX + FS2, centerY);
                    }
                }

                pictureBox1.Invalidate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (!int.TryParse(textBox1.Text, out R1))
                    R1 = 0;
                if (!int.TryParse(textBox2.Text, out R2))
                    R2 = 0;
                if (!int.TryParse(textBox3.Text, out i))
                    i = 0;
                if (!float.TryParse(textBox4.Text, out n1))
                    n1 = 0;
                if (!float.TryParse(textBox6.Text, out n2))
                    n2 = 0;
                if (!float.TryParse(textBox7.Text, out n3))
                    n3 = 0;

                if (R1 <= 9 || R1 >= 36 || R2 <= 9 || R2 >= 36)
                {
                    MessageBox.Show("Перевірте введені дані. R строго від 9 до 36 невключно");
                    textBox1.Clear();
                    textBox2.Clear();
                }

                F1 = (2 * (R1 * R2)) / ((n1 - 1) * (R1 + R2));

                F2 = (2 * (R1 * R2)) / ((n2 - 1) * (R1 + R2));

                F3 = (2 * (R1 * R2)) / ((n3 - 1) * (R1 + R2));

                tg1 = 50 / F2;
                tg2 = 50 / F1;
                tg3 = 50 / F3;

                pictureBox1.Refresh();
                label21.Text = "";
                label22.Text = "";
                label23.Text = "";
                label24.Text = "";
                label25.Text = "";
                label26.Text = "";
            }

            if (radioButton2.Checked == true)
            {

                if (!int.TryParse(textBox1.Text, out R1))
                    R1 = 0;
                if (!int.TryParse(textBox2.Text, out R2))
                    R2 = 0;
                if (!int.TryParse(textBox3.Text, out i))
                    i = 0;
                if (!float.TryParse(textBox4.Text, out n))
                    n = 0;
                if (!float.TryParse(textBox6.Text, out h1))
                    h1 = 0;
                if (!float.TryParse(textBox7.Text, out h2))
                    h2 = 0;

                if (R1 <= 40 || R1 >= 76 || R2 <= 40 || R2 >= 76 || h1 >= R1 || h2 >= R2 || n <= 1.3 || n >= 1.7)
                {
                    MessageBox.Show("Перевірте введені дані. R строго від 9 до 36 невключно, n строго від 1.3 до 1.7 невключно, а h не повинні перевищувати відповідні їм R");
                    textBox1.Clear();
                    textBox2.Clear();
                }

                pictureBox1.Refresh();
                label21.Text = "";
                label22.Text = "";
                label23.Text = "";
                label24.Text = "";
                label25.Text = "";
                label26.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics gr = pictureBox1.CreateGraphics();
    
            radioButton1.Checked = false;
            radioButton2.Checked = false;

            if (!double.TryParse(textBox12.Text, out double nu1))
                nu1 = 0;
            if (!double.TryParse(textBox11.Text, out double nu2))
                nu2 = 0;

            double nd1 = double.Parse(textBox8.Text);
            double nd2 = double.Parse(textBox5.Text);
            double nc1 = double.Parse(textBox10.Text);
            double nc2 = double.Parse(textBox9.Text);
            double nf1 = double.Parse(textBox14.Text);
            double nf2 = double.Parse(textBox13.Text);
            if (!double.TryParse(textBox15.Text, out double phitarget))
                phitarget = 0;

            if (phitarget < 0.01 || phitarget > 1 || nu1 < 36 || n1 > 37 || nu2 < 64 || nu2 > 65)
            {
                MessageBox.Show("Перевірте введені дані. Фі  від 0.01 до 1 включно, а Ню1 та Ню2 від 64 до 65 невключно та від 36 до 37 невключно, відповідно");
                textBox1.Clear();
                textBox2.Clear();
            }

            if (phitarget >= 0.01 && phitarget <= 1 && nu1 > 36 && n1 < 37 && nu2 > 64 && nu2 < 65)
            {

                double phi1 = (nu1 * phitarget) / (nu1 - nu2);
                double phi2 = (nu2 * phitarget) / (nu2 - nu1);

                double r2 = (nd2 - 1)/phi2;
                double r3 = r2;
                double k = (phi1 / (nd1 - 1)) + (1 / r2);
                double r1 = 1 / k;

                label21.Text = "R1: " + Math.Round(r1, 2);
                label23.Text = "R2: " + Math.Round(r2, 2);
                label22.Text = "R3: " + Math.Round(r3, 2);
                label24.Text = "R4: ∞";

                double phif1 = ((nf1 - 1) * phi1) / (nd1 - 1);
                double phic1 = ((nc1 - 1) * phi1) / (nd1 - 1);
                double phif2 = (nf2 - 1) / r3;
                double phif = phif1 + phif2;
                double phic = phif;
                double ff1 = 1 / phif1;
                double fc1 = 1 / phic1;
                double ff = 1 / phif;
                double fc = ff;
                double fd = 1 / phitarget;
                double delta0 = fc1 - ff1;
                double delta = ff - fd;

                label25.Text = "Δ0: " + Math.Round(delta0, 4);
                label26.Text = "Δ: " + Math.Round(delta, 4);

                gr.DrawLine(dashedPen, 150, pictureBox1.Height / 4, 650, pictureBox1.Height / 4);
                gr.DrawArc(mirror2Pen, 200, pictureBox1.Height / 4 - 60, 30, 120, 180, 180);
                gr.DrawArc(mirror2Pen, 200, pictureBox1.Height / 4 - 60, 30, 120, 0, 180);
                gr.DrawLine(mirrorPen, 400, pictureBox1.Height / 4 - 65, 400, pictureBox1.Height / 4 + 65);
                gr.DrawLine(redPen, 400, pictureBox1.Height / 4 - 45, 550, pictureBox1.Height / 4);
                gr.DrawLine(redPen, 400, pictureBox1.Height / 4 + 45, 550, pictureBox1.Height / 4);
                gr.DrawLine(bluePen,  400, pictureBox1.Height / 4 - 30, 500, pictureBox1.Height / 4);
                gr.DrawLine(bluePen, 400, pictureBox1.Height / 4 + 30, 500, pictureBox1.Height / 4);
                gr.DrawLine(yellowPen, 400, pictureBox1.Height / 4 - 37, 525, pictureBox1.Height / 4);
                gr.DrawLine(yellowPen, 400, pictureBox1.Height / 4 + 37, 525, pictureBox1.Height / 4);
                gr.DrawLine(boldPen, 550, pictureBox1.Height / 4, 500, pictureBox1.Height / 4);

                gr.DrawLine(dashedPen, 150, pictureBox1.Height * 2 / 3, 650, pictureBox1.Height * 2 / 3);
                gr.DrawArc(mirror2Pen, 200, pictureBox1.Height * 2 / 3 - 60, 30, 120, 180, 180);
                gr.DrawArc(mirror2Pen, 200, pictureBox1.Height * 2 / 3 - 60, 30, 120, 0, 180);
                gr.DrawLine(mirror2Pen, 215, pictureBox1.Height * 2 / 3 + 60, 215 + 40, pictureBox1.Height * 2 / 3 + 60);
                gr.DrawLine(mirror2Pen, 215, pictureBox1.Height * 2 / 3 - 60, 215 + 40, pictureBox1.Height * 2 / 3 - 60);
                gr.DrawLine(mirror2Pen, 215 + 40, pictureBox1.Height * 2 / 3 - 60, 215 + 40, pictureBox1.Height * 2 / 3 + 60);
                gr.DrawLine(mirrorPen, 400, pictureBox1.Height * 2 / 3 - 65, 400, pictureBox1.Height * 2 / 3 + 65);
                gr.DrawLine(redPen, 400, pictureBox1.Height * 2 / 3 - 45, 550, pictureBox1.Height * 2 / 3);
                gr.DrawLine(redPen, 400, pictureBox1.Height * 2 / 3 + 45, 550, pictureBox1.Height * 2 / 3);
                gr.DrawLine(bluePen, 400, pictureBox1.Height * 2 / 3 - 40, 543, pictureBox1.Height * 2 / 3);
                gr.DrawLine(bluePen, 400, pictureBox1.Height * 2 / 3 + 40, 543, pictureBox1.Height * 2 / 3);
                gr.DrawLine(yellowPen, 400, pictureBox1.Height * 2 / 3 - 37, 515, pictureBox1.Height * 2 / 3);
                gr.DrawLine(yellowPen, 400, pictureBox1.Height * 2 / 3 + 37, 515, pictureBox1.Height * 2 / 3);
                gr.DrawLine(boldPen, 543, pictureBox1.Height * 2 / 3, 518, pictureBox1.Height * 2 / 3);

            }
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!radioButton1.Checked) return;

            textBox4.Text = "1.1";
            textBox6.Text = "1.25";
            textBox7.Text = "1.15";

            textBox4.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!radioButton2.Checked) return;

            textBox4.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;
        }
    }
}