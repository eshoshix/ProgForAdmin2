using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test_DataBase;

namespace ProgForAdmin
{
    public partial class Application1 : MetroFramework.Forms.MetroForm
    {
        DataBase DataBase = new DataBase();
        int CurrentAdminID;
        public Application1(int ID)
        {
           CurrentAdminID = ID;
            InitializeComponent();
        }

        private void Application_Load(object sender, EventArgs e)
        {

            SQL_UserControl sql = new SQL_UserControl();
            addUserControl(sql);
            label2.Text = "SQL консоль";
            name();
        


        }


        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void name()
        {

            string querystring = $"select name from AdminData where [ID] = '{CurrentAdminID}'";
            SqlCommand command = new SqlCommand(querystring, DataBase.getConnection());
            DataBase.openConnection();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                reader.Read();

                string column1Data = reader["name"].ToString();
              

                label1.Text = $"{column1Data}";

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddDiagnoz_UserControl add = new AddDiagnoz_UserControl();  
            addUserControl(add);
            label2.Text = "Добавить диагноз";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddDoctor_UserControl adD = new AddDoctor_UserControl();    
            addUserControl(adD);
            label2.Text = "Зарегистрировать врача";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add_Description_About_Clinic_UserControl us = new Add_Description_About_Clinic_UserControl();
            addUserControl(us);
            label2.Text = "Редактировать информацию о поликлинике";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SQL_UserControl sql = new SQL_UserControl();
            addUserControl(sql);
            label2.Text = "SQL консоль";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Doctor_Cabinets_UserControl DC = new Doctor_Cabinets_UserControl();
            addUserControl(DC);
            label2.Text = "Управление кабинетами";
        }
    }
}
