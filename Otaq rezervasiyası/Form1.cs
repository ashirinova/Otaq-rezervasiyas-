using System;
using System.Drawing;
using System.Windows.Forms;

namespace Otaq_rezervasiyası
{
    public partial class Form1 : Form
    {
        private int[] qalanSaniye = new int[6];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 400;
            timer1.Start();
        }

        private void OtaqRezervEt(Button btn, Label lbl, int otaqIndex)
        {
            if (string.IsNullOrWhiteSpace(maskedTextBox2.Text))
            {
                MessageBox.Show("Xahiş olunur müddəti daxil edin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int deqiqe;
            bool ugurludur = int.TryParse(maskedTextBox2.Text.Trim(), out deqiqe);

            if (ugurludur && deqiqe > 0)
            {
                qalanSaniye[otaqIndex] = deqiqe * 60;

                btn.BackColor = Color.Red;
                btn.ForeColor = Color.White;
                btn.Enabled = false;

                if (lbl != null)
                {
                    lbl.Text = $"Qalan vaxt: {qalanSaniye[otaqIndex]} san";
                }

                maskedTextBox1.Clear();
                maskedTextBox2.Clear();
            }
            else
            {
                MessageBox.Show("Zəhmət olmasa düzgün dəqiqə daxil edin!", "Səhv", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e) => OtaqRezervEt(button1, lblOtaq1, 0);
        private void button2_Click(object sender, EventArgs e) => OtaqRezervEt(button2, lblOtaq2, 1);
        private void button3_Click(object sender, EventArgs e) => OtaqRezervEt(button3, lblOtaq3, 2);
        private void button4_Click(object sender, EventArgs e) => OtaqRezervEt(button4, lblOtaq4, 3);
        private void button5_Click(object sender, EventArgs e) => OtaqRezervEt(button5, lblOtaq5, 4);
        private void button6_Click(object sender, EventArgs e) => OtaqRezervEt(button6, lblOtaq6, 5);

        private void timer1_Tick(object sender, EventArgs e)
        {
            Button[] otaglar = { button1, button2, button3, button4, button5, button6 };
            Label[] labeller = { lblOtaq1, lblOtaq2, lblOtaq3, lblOtaq4, lblOtaq5, lblOtaq6 };

            for (int i = 0; i < 6; i++)
            {
                if (qalanSaniye[i] > 0)
                {
                    qalanSaniye[i]--;

                    if (labeller[i] != null)
                    {
                        labeller[i].Text = $"Qalan vaxt: {qalanSaniye[i]} san";
                    }

                    if (qalanSaniye[i] == 0)
                    {
                        otaglar[i].UseVisualStyleBackColor = true;
                        otaglar[i].ForeColor = Color.Black;
                        otaglar[i].Enabled = true;

                        if (labeller[i] != null)
                        {
                            labeller[i].Text = "Boşdur";
                        }

                        MessageBox.Show($"{otaglar[i].Text} otağının vaxtı bitdi!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}