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

        SqlConnection con;
        SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(@"data source=ARTEM;initial catalog=car_db;integrated security=true;TrustServerCertificate=True");
            getCars();
        }
        int cpt = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Add(10);

            for (int i = 0; i < 10; i++)
            {
                guna2DataGridView1.Rows[i].Cells[0].Value = Image.FromFile("D:\\Лабы\\test_auto\\test_auto\\images\\" + (i+1).ToString() + ".png");
                guna2DataGridView1.Rows[i].Cells[1].Value = cars[i].name;
                guna2DataGridView1.Rows[i].Cells[2].Value = cars[i].brand;
                guna2DataGridView1.Rows[i].Cells[3].Value = cars[i].carcase;
                guna2DataGridView1.Rows[i].Cells[4].Value = cars[i].hp;
                guna2DataGridView1.Rows[i].Cells[5].Value = cars[i].capacity;
                guna2DataGridView1.Rows[i].Cells[6].Value = cars[i].nm;
            }

            
            FillComboBox();
        }

        public void getCars()
        {
            con.Open();
            string selectquery = "select * from car_table";
            SqlCommand cmd = new SqlCommand(selectquery, con);
            SqlDataReader reader1;
            reader1 = cmd.ExecuteReader();
            string carname;
            string carcase;
            string carbrand;
            string description;
            string hp;
            string capacity;
            string nm;
            int id;

            while (reader1.Read())
            {
                carname = reader1.GetValue(1).ToString();
                carcase = reader1.GetValue(3).ToString();
                carbrand = reader1.GetValue(2).ToString();
                description = reader1.GetValue(4).ToString();
                hp = reader1.GetValue(5).ToString();
                capacity = reader1.GetValue(6).ToString();
                nm = reader1.GetValue(7).ToString();
                id = (int)Convert.ToInt64(Convert.ToDouble(reader1.GetValue(0)));

                Car car = new Car(carname, carbrand, carcase, description, id, hp, capacity, nm);
                Console.WriteLine(carname + " " + carcase + " " + carbrand + " " + description + " " + id.ToString());
                cars.Add(car);

            }

            con.Close();
        }

        public class Car
        {
            public string name;
            public string brand;
            public string carcase;
            public string description;
            public string hp;
            public string capacity;
            public string nm;
            public int id;
            Car()
            {
                name = "";
                brand = "";
                carcase = "";
                description = "";
                id = 0;
                hp = "";
                capacity = "";
                nm = "";
            }
            public Car(string name, string brand, string carcase, string description, int id, string hp, string capacity, string nm)
            {
                this.name = name;
                this.brand = brand;
                this.carcase = carcase;
                this.description = description;
                this.id = id;
                this.hp = hp;
                this.capacity = capacity;
                this.nm = nm;
            }
        }

        List<Car> cars = new List<Car>();

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
                        cpt = i; 
                        DisplayCar(row);
                        return;
                    }
                }
            }

            
            for (int i = 0; i <= cpt; i++)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[i];
                if (!row.IsNewRow)
                {
                    string brand = row.Cells[2].Value.ToString();
                    string bodyType = row.Cells[3].Value.ToString();

                    if (brand == selectedBrand && bodyType == selectedBodyType)
                    {
                        cpt = i; 
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
                        cpt = i; 
                        DisplayCar(row);
                        return;
                    }
                }
            }

            for (int i = guna2DataGridView1.Rows.Count - 1; i >= cpt; i--)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[i];
                if (!row.IsNewRow)
                {
                    string brand = row.Cells[2].Value.ToString();
                    string bodyType = row.Cells[3].Value.ToString();

                    if (brand == selectedBrand && bodyType == selectedBodyType)
                    {
                        cpt = i;
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
            guna2PictureBox_car2.Load("D:\\Лабы\\test_auto\\test_auto\\images\\" + (cpt + 1).ToString() + (cpt + 1).ToString() + ".png");
            guna2PictureBox_car3.Load("D:\\Лабы\\test_auto\\test_auto\\images\\" + (cpt + 1).ToString() + (cpt + 1).ToString() + (cpt + 1).ToString() + ".png");
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
