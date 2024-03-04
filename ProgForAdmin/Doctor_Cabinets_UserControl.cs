using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using test_DataBase;

namespace ProgForAdmin
{
    public partial class Doctor_Cabinets_UserControl : UserControl
    {
        DataBase DataBase = new DataBase();
        public Doctor_Cabinets_UserControl()
        {
            InitializeComponent();
        }

        private void Doctor_Cabinets_UserControl_Load(object sender, EventArgs e)
        {
            CabinetsComboBox();
            AddTable();
            this.dataGridView1.Columns["ID_Врача"].Visible = false;
            AddTableCabinets();
            this.dataGridView3.Columns["ID_Кабинета"].Visible = false;

        }
        private int cellCabinet()
        {

            int idclient = 0;

            if (dataGridView3.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView3.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView3.Rows[selectedrowindex];
                idclient = Convert.ToInt32(selectedRow.Cells["ID_Кабинета"].Value);
            }
            return idclient;
        }
        private int cell()
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
        private int cell2()
        {

            int idclient = 0;

            if (dataGridView2.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];
                idclient = Convert.ToInt32(selectedRow.Cells["ID_Врача"].Value);
            }
            return idclient;
        }
        private void CabinetsComboBox()
        {
            comboBox1.Items.Clear();
            string querystring2 = $"select * from Кабинет";
            SqlCommand command2 = new SqlCommand(querystring2, DataBase.getConnection());
            DataBase.openConnection();


            List<string> listCab = new List<string>();
            List<int> listCabID = new List<int>();


            using (SqlDataReader reader = command2.ExecuteReader())
            {

                while (reader.Read())
                {

                    var cab = reader.GetString(1);
                    listCab.Add((string)cab);
                    var cabID = reader.GetInt32(0);
                    listCabID.Add((int)cabID);

                }

                reader.Close(); 
            }
            
            
            savedCabID = listCabID;
            foreach (var item in listCab)
            {

                comboBox1.Items.Add(item);

            }

        }
        List<int> savedCabID = new List<int>();
        private bool AddTable()
        {


            SqlConnection con = new SqlConnection("Data Source=exPC; Initial Catalog=EbaTest2; Integrated Security=True");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select ID_Врача, ФИО, Специальность from Врач where ID_Кабинета is NULL", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();


            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            return true;




        }
        private bool AddTableSearch()
        {


            SqlConnection con = new SqlConnection("Data Source=exPC; Initial Catalog=EbaTest2; Integrated Security=True");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select ID_Врача, ФИО, Специальность from Врач where concat (ФИО,Специальность) like '%" + textBox1.Text + "%' and ID_Кабинета is NULL", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();


            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            return true;




        }
        private bool AddTable2Search()
        {
          

            var cabinet = comboBox1.SelectedIndex;
            var cabinetID = savedCabID[cabinet];
            SqlConnection con = new SqlConnection("Data Source=exPC; Initial Catalog=EbaTest2; Integrated Security=True");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter($"Select Врач.ID_Врача,Кабинет.ID_Кабинета,[Номер кабинета],ФИО,Специальность from Кабинет_Врач inner join Врач on Врач.ID_Врача = Кабинет_Врач.ID_Врача inner join Кабинет on Кабинет.ID_Кабинета =  Кабинет_Врач.ID_Кабинета where  Кабинет.ID_Кабинета = '{cabinetID}' and concat (ФИО,Специальность) like '%" + textBox2.Text + "%'", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();


            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            this.dataGridView2.Columns["ID_Кабинета"].Visible = false;
            this.dataGridView2.Columns["ID_Врача"].Visible = false;
            return true;




        }
        private bool AddTable2()
        {


            var cabinet = comboBox1.SelectedIndex;
            try 
            {
                var cabinetID = savedCabID[cabinet];
                SqlConnection con = new SqlConnection("Data Source=exPC; Initial Catalog=EbaTest2; Integrated Security=True");
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter($"Select Врач.ID_Врача,Кабинет.ID_Кабинета,[Номер кабинета],ФИО,Специальность from Кабинет_Врач inner join Врач on Врач.ID_Врача = Кабинет_Врач.ID_Врача inner join Кабинет on Кабинет.ID_Кабинета =  Кабинет_Врач.ID_Кабинета where  Кабинет.ID_Кабинета = '{cabinetID}'", con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();


                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
                this.dataGridView2.Columns["ID_Кабинета"].Visible = false;
                this.dataGridView2.Columns["ID_Врача"].Visible = false;
               
            }
            catch (Exception e)
            {
                
            }




            return true;
        }
        private bool AddTableCabinets()
        {


            SqlConnection con = new SqlConnection("Data Source=exPC; Initial Catalog=EbaTest2; Integrated Security=True");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select ID_Кабинета, [Номер кабинета] from Кабинет", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();


            da.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
            return true;




        }
        private void cabinets()
        {
            if(cabinetsCheck() == false)
            {
                MessageBox.Show("Такой кабинет уже существует!", "Ошибка!");
                return;
            }
            var cabinet = textBox3.Text;
            if (cabinet == "")
            {
                MessageBox.Show("Введите номер кабинета!","Ошибка!");
                return;
            }
            string querystring = $"insert into Кабинет ([Номер кабинета]) values('{cabinet}')";


            SqlCommand command = new SqlCommand(querystring, DataBase.getConnection());

            DataBase.openConnection();
            command.ExecuteNonQuery();


        }
        private bool cabinetsCheck()
        {

            var cabinet = textBox3.Text;
           
            string querystring = $"select * from Кабинет Where [Номер кабинета] = '{cabinet}'";


            SqlCommand command = new SqlCommand(querystring, DataBase.getConnection());

            DataBase.openConnection();
          
            using (SqlDataReader reader = command.ExecuteReader())
            {

                var cabinetExist = reader.Read();

                if (cabinetExist == true)
                {

                    return false;
                }
              
            }
            return true;

        }

        private void cabinetsDelete()
        {

            var cabinet = cellCabinet();
            if(cabinet < 0)
            {
                MessageBox.Show("Выберите кабинет для удаления!", "Ошибка!");
                return;
            }
            
            string querystring1 = $"Delete from Кабинет where ID_Кабинета ='{cabinet}'";
            string querystring2 = $"Delete from Кабинет_Врач where ID_Кабинета ='{cabinet}'";
            string querystring3 = $"Update Врач set ID_Кабинета = NULL where ID_Кабинета ='{cabinet}'";
            SqlCommand command1 = new SqlCommand(querystring1, DataBase.getConnection());
            SqlCommand command2 = new SqlCommand(querystring2, DataBase.getConnection());
            SqlCommand command3 = new SqlCommand(querystring3, DataBase.getConnection());

            DataBase.openConnection();
            command2.ExecuteNonQuery();
            command1.ExecuteNonQuery();
            command3.ExecuteNonQuery();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddTable2();
            label3.Text = "Врачи в кабинете № " + comboBox1.Text.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var cabinet = comboBox1.SelectedIndex;

            if (cabinet < 0)
            {
                MessageBox.Show("Выберите номер кабинета!", "Ошибка!");
                return;

            }
         
            
             var cabinetID = savedCabID[cabinet];

            


            if (cell() > 0)
            {
                string querystring1 = $"update Врач set ID_Кабинета = {cabinetID} where ID_Врача = '{cell()}'";
                SqlCommand command1 = new SqlCommand(querystring1, DataBase.getConnection());

                string querystring3 = $"insert into Кабинет_Врач (ID_Кабинета,ID_Врача) values('{cabinetID}','{cell()}')";
                SqlCommand command3 = new SqlCommand(querystring3, DataBase.getConnection());
                command1.ExecuteNonQuery();

                command3.ExecuteNonQuery();
                DataBase.openConnection();
                AddTable();
                AddTable2();
                dataGridView2.ClearSelection();
            }
            else
            MessageBox.Show("Выберите врача для перемещения", "Ошибка!");
            return;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            var cabinet = comboBox1.SelectedIndex;
           
            if (cabinet < 0)
            {
                MessageBox.Show("Выберите номер кабинета!", "Ошибка!");
                return;

            }
            else
            {
                var cabinetID = savedCabID[cabinet];

            }
            

            if (cell2() > 0) 
            {
                string querystring1 = $"update Врач set ID_Кабинета = NULL where ID_Врача = '{cell2()}'";
                SqlCommand command1 = new SqlCommand(querystring1, DataBase.getConnection());
                string querystring2 = $"Delete Кабинет_Врач where ID_Врача = '{cell2()}'";
                SqlCommand command2 = new SqlCommand(querystring2, DataBase.getConnection());

                command1.ExecuteNonQuery();
                command2.ExecuteNonQuery();

                DataBase.openConnection();
                AddTable();
                AddTable2();
                dataGridView1.ClearSelection();
            }
            else
            MessageBox.Show("Выберите врача для перемещения", "Ошибка!");
            return;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AddTableSearch();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            AddTable2Search();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cabinets();
            AddTableCabinets();
            comboBox1.SelectedItem = null;
            CabinetsComboBox();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cabinetsDelete();
            AddTableCabinets();
            comboBox1.SelectedItem = null;
            comboBox1.Text= "";
            CabinetsComboBox();
            AddTable();
            this.dataGridView2.Rows.Clear();

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
