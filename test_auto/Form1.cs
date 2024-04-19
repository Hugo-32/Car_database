using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Configuration;
using System.Data.SqlClient;

namespace test_auto
{
    public partial class Form1 : Form
    {
        List<int> matchingRowsIndices = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }
        int cpt = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Add(10);

            guna2DataGridView1.Rows[0].Cells[0].Value = Image.FromFile("D:\\Лабы\\test_auto\\images\\1.png");
            guna2DataGridView1.Rows[1].Cells[0].Value = Image.FromFile("D:\\Лабы\\test_auto\\images\\2.png");
            guna2DataGridView1.Rows[2].Cells[0].Value = Image.FromFile("D:\\Лабы\\test_auto\\images\\3.png");
            guna2DataGridView1.Rows[3].Cells[0].Value = Image.FromFile("D:\\Лабы\\test_auto\\images\\4.png");
            guna2DataGridView1.Rows[4].Cells[0].Value = Image.FromFile("D:\\Лабы\\test_auto\\images\\5.png");
            guna2DataGridView1.Rows[5].Cells[0].Value = Image.FromFile("D:\\Лабы\\test_auto\\images\\6.png");
            guna2DataGridView1.Rows[6].Cells[0].Value = Image.FromFile("D:\\Лабы\\test_auto\\images\\7.png");
            guna2DataGridView1.Rows[7].Cells[0].Value = Image.FromFile("D:\\Лабы\\test_auto\\images\\8.png");
            guna2DataGridView1.Rows[8].Cells[0].Value = Image.FromFile("D:\\Лабы\\test_auto\\images\\9.png");
            guna2DataGridView1.Rows[9].Cells[0].Value = Image.FromFile("D:\\Лабы\\test_auto\\images\\10.png");
           
            guna2DataGridView1.Rows[0].Cells[1].Value = "Audi RS7";
            guna2DataGridView1.Rows[1].Cells[1].Value = "Audi RS5";
            guna2DataGridView1.Rows[2].Cells[1].Value = "Audi R8";
            guna2DataGridView1.Rows[3].Cells[1].Value = "Mercedes-Benz W214";
            guna2DataGridView1.Rows[4].Cells[1].Value = "Audi A4";
            guna2DataGridView1.Rows[5].Cells[1].Value = "Audi A5";
            guna2DataGridView1.Rows[6].Cells[1].Value = "Audi Q3";
            guna2DataGridView1.Rows[7].Cells[1].Value = "BMW 3";
            guna2DataGridView1.Rows[8].Cells[1].Value = "BMW i5 G60";
            guna2DataGridView1.Rows[9].Cells[1].Value = "BMW X6M";

            guna2DataGridView1.Rows[0].Cells[2].Value = "Audi";
            guna2DataGridView1.Rows[1].Cells[2].Value = "Audi";
            guna2DataGridView1.Rows[2].Cells[2].Value = "Audi";
            guna2DataGridView1.Rows[3].Cells[2].Value = "Mercedes";
            guna2DataGridView1.Rows[4].Cells[2].Value = "Audi";
            guna2DataGridView1.Rows[5].Cells[2].Value = "Audi";
            guna2DataGridView1.Rows[6].Cells[2].Value = "Audi";
            guna2DataGridView1.Rows[7].Cells[2].Value = "BMW";
            guna2DataGridView1.Rows[8].Cells[2].Value = "BMW";
            guna2DataGridView1.Rows[9].Cells[2].Value = "BMW";

            guna2DataGridView1.Rows[0].Cells[3].Value = "Седан";
            guna2DataGridView1.Rows[1].Cells[3].Value = "Седан";
            guna2DataGridView1.Rows[2].Cells[3].Value = "Купе";
            guna2DataGridView1.Rows[3].Cells[3].Value = "Универсал";
            guna2DataGridView1.Rows[4].Cells[3].Value = "Универсал";
            guna2DataGridView1.Rows[5].Cells[3].Value = "Купе";
            guna2DataGridView1.Rows[6].Cells[3].Value = "Кроссовер";
            guna2DataGridView1.Rows[7].Cells[3].Value = "Седан";
            guna2DataGridView1.Rows[8].Cells[3].Value = "Седан";
            guna2DataGridView1.Rows[9].Cells[3].Value = "Кроссовер";

            guna2DataGridView1.Rows[0].Cells[4].Value = "600 л/с";
            guna2DataGridView1.Rows[1].Cells[4].Value = "444 л/с";
            guna2DataGridView1.Rows[2].Cells[4].Value = "562 л/с";
            guna2DataGridView1.Rows[3].Cells[4].Value = "200 л/с";
            guna2DataGridView1.Rows[4].Cells[4].Value = "250 л/с";
            guna2DataGridView1.Rows[5].Cells[4].Value = "250 л/с";
            guna2DataGridView1.Rows[6].Cells[4].Value = "184 л/с";
            guna2DataGridView1.Rows[7].Cells[4].Value = "300 л/с";
            guna2DataGridView1.Rows[8].Cells[4].Value = "270 л/с";
            guna2DataGridView1.Rows[9].Cells[4].Value = "320 л/с";

            guna2DataGridView1.Rows[0].Cells[5].Value = "4.0L";
            guna2DataGridView1.Rows[1].Cells[5].Value = "2.9L";
            guna2DataGridView1.Rows[2].Cells[5].Value = "5.2L";
            guna2DataGridView1.Rows[3].Cells[5].Value = "2.0L";
            guna2DataGridView1.Rows[4].Cells[5].Value = "2.0L";
            guna2DataGridView1.Rows[5].Cells[5].Value = "2.0L";
            guna2DataGridView1.Rows[6].Cells[5].Value = "2.0L";
            guna2DataGridView1.Rows[7].Cells[5].Value = "2.3L";
            guna2DataGridView1.Rows[8].Cells[5].Value = "2.1L";
            guna2DataGridView1.Rows[9].Cells[5].Value = "2.4L";


            guna2DataGridView1.Rows[0].Cells[6].Value = "800Nm";
            guna2DataGridView1.Rows[1].Cells[6].Value = "600Nm";
            guna2DataGridView1.Rows[2].Cells[6].Value = "540Nm";
            guna2DataGridView1.Rows[3].Cells[6].Value = "320Nm";
            guna2DataGridView1.Rows[4].Cells[6].Value = "350Nm";
            guna2DataGridView1.Rows[5].Cells[6].Value = "370Nm";
            guna2DataGridView1.Rows[6].Cells[6].Value = "340Nm";
            guna2DataGridView1.Rows[7].Cells[6].Value = "400Nm";
            guna2DataGridView1.Rows[8].Cells[6].Value = "380Nm";
            guna2DataGridView1.Rows[9].Cells[6].Value = "420Nm";
            FillComboBox();
        }

        private void FillComboBox()
        {
            HashSet<string> uniqueValuesColumn3 = new HashSet<string>();
            HashSet<string> uniqueValuesColumn4 = new HashSet<string>();

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (!row.IsNewRow) 
                {
                    string valueColumn3 = row.Cells[2].Value.ToString();
                    string valueColumn4 = row.Cells[3].Value.ToString();
                    uniqueValuesColumn3.Add(valueColumn3);
                    uniqueValuesColumn4.Add(valueColumn4);
                }
            }

            foreach (string value in uniqueValuesColumn3)
            {
                guna2ComboBox1.Items.Add(value);
            }

            foreach (string value in uniqueValuesColumn4)
            {
                guna2ComboBox2.Items.Add(value);
            }
        }


        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            ShowNextMatchingCar();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            ShowPreviousMatchingCar();
        }

        private void ShowNextMatchingCar()
        {
            if (guna2ComboBox1.SelectedItem == null || guna2ComboBox2.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите марку и тип кузова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedBrand = guna2ComboBox1.SelectedItem.ToString();
            string selectedBodyType = guna2ComboBox2.SelectedItem.ToString();

            for (int i = cpt + 1; i < guna2DataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[i];
                if (!row.IsNewRow)
                {
                    string brand = row.Cells[2].Value.ToString();
                    string bodyType = row.Cells[3].Value.ToString();

                    if (brand == selectedBrand && bodyType == selectedBodyType)
                    {
                        cpt = i; // Обновляем счетчик на индекс текущей строки
                        DisplayCar(row);
                        return;
                    }
                }
            }

            // Если не найдено подходящей машины, переходим к первой строке
            for (int i = 0; i <= cpt; i++)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[i];
                if (!row.IsNewRow)
                {
                    string brand = row.Cells[2].Value.ToString();
                    string bodyType = row.Cells[3].Value.ToString();

                    if (brand == selectedBrand && bodyType == selectedBodyType)
                    {
                        cpt = i; // Обновляем счетчик на индекс текущей строки
                        DisplayCar(row);
                        return;
                    }
                }
            }
        }

        private void ShowPreviousMatchingCar()
        {
            if (guna2ComboBox1.SelectedItem == null || guna2ComboBox2.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите марку и тип кузова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedBrand = guna2ComboBox1.SelectedItem.ToString();
            string selectedBodyType = guna2ComboBox2.SelectedItem.ToString();

            for (int i = cpt - 1; i >= 0; i--)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[i];
                if (!row.IsNewRow)
                {
                    string brand = row.Cells[2].Value.ToString();
                    string bodyType = row.Cells[3].Value.ToString();

                    if (brand == selectedBrand && bodyType == selectedBodyType)
                    {
                        cpt = i; // Обновляем счетчик на индекс текущей строки
                        DisplayCar(row);
                        return;
                    }
                }
            }

            // Если не найдено подходящей машины, переходим к последней строке
            for (int i = guna2DataGridView1.Rows.Count - 1; i >= cpt; i--)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[i];
                if (!row.IsNewRow)
                {
                    string brand = row.Cells[2].Value.ToString();
                    string bodyType = row.Cells[3].Value.ToString();

                    if (brand == selectedBrand && bodyType == selectedBodyType)
                    {
                        cpt = i; // Обновляем счетчик на индекс текущей строки
                        DisplayCar(row);
                        return;
                    }
                }
            }
        }

        private void DisplayCar(DataGridViewRow row)
        {
            guna2PictureBox_car.Image = (Image)row.Cells[0].Value;
            label1.Text = row.Cells[1].Value.ToString();
            label4.Text = row.Cells[4].Value.ToString();
            label5.Text = row.Cells[5].Value.ToString();
            label6.Text = row.Cells[6].Value.ToString();
            label11.Text = label4.Text.Substring(0, label4.Text.Length - 3);
            guna2PictureBox_car2.Load("D:\\Лабы\\test_auto\\images\\" + (cpt + 1).ToString() + (cpt + 1).ToString() + ".png");
            guna2PictureBox_car3.Load("D:\\Лабы\\test_auto\\images\\" + (cpt + 1).ToString() + (cpt + 1).ToString() + (cpt + 1).ToString() + ".png");
            guna2PictureBox_car1.Image = guna2PictureBox_car.Image;
        }



        private void guna2PictureBox_car1_Click(object sender, EventArgs e)
        {
            guna2PictureBox_car.Image = guna2PictureBox_car1.Image;

        }

        private void guna2PictureBox_car2_Click(object sender, EventArgs e)
        {
            guna2PictureBox_car.Image = guna2PictureBox_car2.Image;

        }

        private void guna2PictureBox_car3_Click(object sender, EventArgs e)
        {
            guna2PictureBox_car.Image = guna2PictureBox_car3.Image;

        }
    }
}
