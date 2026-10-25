using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShexsiyyetVesiqesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Cins ComboBox-una seçimləri əlavə edirik:
            comboBox1.Items.Add("Kişi");
            comboBox1.Items.Add("Qadın");
        }

        // 1. Şəkil yüklə düyməsi
        private void buttonYukle_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Şəkil faylları (*.jpg; *.png; *.jpeg)|*.jpg; *.png; *.jpeg";

            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        // 2. Yadda saxla düyməsi
        private void buttonYaddaSaxla_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSeriya.Text) ||
                string.IsNullOrEmpty(textBoxFin.Text) ||
                string.IsNullOrEmpty(textBoxSoyad.Text) ||
                string.IsNullOrEmpty(textBoxAd.Text) ||
                comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Zəhmət olmasa əsas məlumatları və cinsinizi seçin!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // FİN kod dəqiq 7 simvol olmalıdır
                if (textBoxFin.Text.Length != 7)
                {
                    MessageBox.Show("FİN kod dəqiq 7 simvoldan ibarət olmalıdır!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Tarixləri və cinsi oxuyuruq
                    string dogumTarixi = dateTimePicker1.Value.ToShortDateString();
                    string cins = comboBox1.SelectedItem.ToString();

                    MessageBox.Show($"Məlumatlar uğurla yadda saxlanıldı!\nCins: {cins}\nDoğum tarixi: {dogumTarixi}", "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // 3. Təmizlə düyməsi
        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            textBoxSeriya.Clear();
            textBoxFin.Clear();
            textBoxSoyad.Clear();
            textBoxAd.Clear();
            textBoxAtaAdi.Clear();
            textBoxDogumYeri.Clear();
            textBoxAileVeziyyeti.Clear();
            textBoxVerenOrqan.Clear();

            // ComboBox və Tarixləri sıfırlayırıq
            comboBox1.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;

            pictureBox1.Image = null;
        }

        // Designer xətalarının qarşısını almaq üçün metodlar:
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void textBoxSeriya_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }

        private void buttonTemizle_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonYaddaSaxla_Click_1(object sender, EventArgs e)
        {

        }
    }
}