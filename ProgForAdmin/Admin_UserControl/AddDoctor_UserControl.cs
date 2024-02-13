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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace ProgForAdmin
{
    public partial class AddDoctor_UserControl : UserControl
    {
        DataBase DataBase = new DataBase();
        public AddDoctor_UserControl()
        {

            InitializeComponent();
            
        }

        private void AddDoctor_UserControl_Load(object sender, EventArgs e)
        {
            logintextBox2.MaxLength = 20;
            PasswordtextBox1.MaxLength = 20;
            AddTable();
            this.dataGridView1.Columns["ID_Врача"].Visible = false;
            CabinetsComboBox();

            Cost_TextBox2.MaxLength = 4;
            doctorComboBox();
        }

        private void reg_button_Click(object sender, EventArgs e)
        {
            var Login_user = logintextBox2.Text;
            if (string.IsNullOrEmpty(Login_user))
            {
                MessageBox.Show("Введите логин!", "Ошибка!");
                return;


            }
            if (checkData() == true)
            {

                MessageBox.Show("Аккаунт с таким логином уже существует!", "Ошибка!");
                return;
            }    
           
            var Password_user = PasswordtextBox1.Text;
            if (string.IsNullOrEmpty(Password_user))
            {
                MessageBox.Show("Введите пароль!", "Ошибка!");
                return;


            }
            var name = name_TextBox.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Введите ФИО!", "Ошибка!");
                return;


            }


            var speciality = comboBox1.Text;
            if (string.IsNullOrEmpty(speciality))
            {
                MessageBox.Show("Введите специальность!", "Ошибка!");
                return;


            }

            var Cost = Cost_TextBox2.Text;
            if (string.IsNullOrEmpty(Cost))
            {
                MessageBox.Show("Введите стоимость посещения!", "Ошибка!");
                return;

            }
            var cabinet = comboBox2.SelectedIndex;
            var cabinetID = savedCabID[cabinet];

            var date = DateTime.Now;
            string querystring = $"insert into Врач (Login_user,Password_user, ФИО, Специальность, Дата_Найма, [Стоимость посещения],ID_Кабинета) values('{Login_user}','{Password_user}','{name}','{speciality}','{date}','{Cost}','{cabinetID}') ";
           

            SqlCommand command = new SqlCommand(querystring, DataBase.getConnection());
            var IDDoctor = Doctor();
            var Idcab = Cab();

            string querystring2 = $"insert into Кабинет_Врач (ID_Врача,ID_Кабинета) values('{IDDoctor}','{Idcab}') ";
            SqlCommand command2 = new SqlCommand(querystring2, DataBase.getConnection());
            
            DataBase.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                command2.ExecuteReader();
                MessageBox.Show("Врач успешно Добавлен!", "Успех!");

                AddTable();


            }
            else
            {

                MessageBox.Show("Врач не добавлен!");




            }
            DataBase.closeConnection();











        }
        private int Doctor()
        {
           
           
            String querystring2 = $"SELECT IDENT_CURRENT('Врач')";

            var connection = DataBase.getConnection();
            

            SqlCommand command2 = new SqlCommand(querystring2, connection);

            var reader = command2.ExecuteReader();
            reader.Read();

            var id = (int)(reader.GetDecimal(0));
           
            

            reader.Close();


            connection.Close();
            return id;

        }
        private int Cab()
        {
            

            String querystring2 = $"SELECT TOP 1 ID_Кабинета FROM Врач ORDER BY ID_Врача DESC";

            var connection = DataBase.getConnection();


            SqlCommand command2 = new SqlCommand(querystring2, connection);

            connection.Open();
            var reader = command2.ExecuteReader();
            reader.Read();
            

            var idCab = reader.GetInt32(0);

           
            reader.Close();
            connection.Close();

            connection.Close();
            return idCab;

        }


        private bool AddTable()
        {


            SqlConnection con = new SqlConnection("Data Source=exPC; Initial Catalog=EbaTest2; Integrated Security=True");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select ФИО, Специальность, ID_Врача,Дата_Найма as 'Дата найма', [Стоимость посещения],Login_user as 'Логин', password_user as 'Пароль' from Врач ", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();


            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            return true;




        }

        private bool checkData()
        {

            var login = logintextBox2.Text;
            var password = PasswordtextBox1.Text;
            string querystring2 = $"select Login_user, password_user from Врач where Login_user = '{login}'";
            SqlCommand command2 = new SqlCommand(querystring2, DataBase.getConnection());
            DataBase.openConnection();
            int count = 0;
            using (SqlDataReader reader = command2.ExecuteReader())
            {
               

                while (reader.Read())
                {
                    count++;
                    

                }

                
            }


            if (count > 0)
            {
                return true;
            }
            return false;
        }

        private void doctorComboBox()
        {

            string querystring2 = $"select distinct Специальность from Врач";
            SqlCommand command2 = new SqlCommand(querystring2, DataBase.getConnection());
            DataBase.openConnection();


            List<string> listSpec = new List<string>();



            using (SqlDataReader reader = command2.ExecuteReader())
            {

                while (reader.Read())
                {

                    var doctorSpec1 = reader.GetString(0);
                    listSpec.Add((string)doctorSpec1);

                }


            }

            foreach (var item in listSpec)
            {

                comboBox1.Items.Add(item);

            }

        }
        private void CabinetsComboBox()
        {

            string querystring2 = $"select * from Кабинет";
            SqlCommand command2 = new SqlCommand(querystring2, DataBase.getConnection());
            DataBase.openConnection();


            List<string> listCab = new List<string>();
            List<int> listCabID = new List<int>();


            using (SqlDataReader reader = command2.ExecuteReader())
            {

                while (reader.Read())
                {

                    var cab= reader.GetString(1);
                    listCab.Add((string)cab);
                    var cabID = reader.GetInt32(0);
                    listCabID.Add((int)cabID);

                }


            }
            savedCabID = listCabID;
            foreach (var item in listCab)
            {

                comboBox2.Items.Add(item);

            }

        }
        List<int> savedCabID = new List<int>();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private int CellId()
        {
            int idclient = 0;

            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                idclient = Convert.ToInt32(selectedRow.Cells["ID_Врача"].Value);
            }
            return idclient;




        }
        private void button1_Click(object sender, EventArgs e)
        {
            var ID = CellId();
            string querystring2 = $"delete from Кабинет_Врач where ID_Врача = '{ID}'";
            string querystring3 = $"delete from Врач where ID_Врача = '{ID}'";
            SqlCommand command2 = new SqlCommand(querystring2, DataBase.getConnection());
            SqlCommand command3 = new SqlCommand(querystring3, DataBase.getConnection());
            DataBase.openConnection();
            command2.ExecuteNonQuery();
            command3.ExecuteNonQuery(); 
            MessageBox.Show("Вы успешно удалили запрись о враче","Успех!");

            AddTable();
        }
    }
}
