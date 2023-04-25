using GeneralDepartmentEmployeeTerminal.DataBase;
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

namespace GeneralDepartmentEmployeeTerminal.Views
{
    

    public partial class ModalWindowForm : Form
    {      
        // всегда подключаем класс БД вместе с библиотекой
        DBConnect dbConnect = new DBConnect();

        int selectedRow;

        public ModalWindowForm()
        {
            InitializeComponent();
        }
        
        private void CreateColums() // метод создание колонок таблицы
        {
            PassesListGridView.Columns.Add("id","№");
            PassesListGridView.Columns.Add("last_name", "Фамилия");
            PassesListGridView.Columns.Add("first_name", "Имя");
            PassesListGridView.Columns.Add("patronymic", "Отчество");
            PassesListGridView.Columns.Add("appointment", "Назначение");
            PassesListGridView.Columns.Add("organization", "Организация");
            PassesListGridView.Columns.Add("status", "Статус");
        }

        // метод в который мы передаем параметры
        private void ReadSingleRows(DataGridView dgw, IDataRecord record) /* IDataRecord предоставляем значение столбцов*/
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3),
            record.GetString(4), record.GetString(5), record.GetString(6));
        }
        
        private void RefreshDataGrid(DataGridView dgw) // метод который выводит данные в таблицу
        {
            dgw.Rows.Clear();

            // команда в которой берем все данные из таблицы
            string queryString = $"SELECT id, last_name, first_name, patronymic, appointment, organization," +
                $"(SELECT status FROM Status WHERE id = User_Private_Visit.id_status) FROM User_Private_Visit"; 

            SqlCommand command = new SqlCommand(queryString, dbConnect.getConnection());

            dbConnect.openConnection();

            SqlDataReader reader = command.ExecuteReader(); //чтение данных по запросу command

            //выводим все данные с бд
            while (reader.Read())
            {
                ReadSingleRows(dgw,reader);
            }
            reader.Close();

            dbConnect.closeConnection();
        }

        // обновление таблицы (выполняется повторное чтение из таблицы)
        private void RefreshTable_Click(object sender, EventArgs e)
        {           
            RefreshDataGrid(PassesListGridView);
        }

        private void ModalWindowForm_Load(object sender, EventArgs e) // метод при загрузке формы
        {
            CreateColums(); // создание колонок
            RefreshDataGrid(PassesListGridView); // обновление таблицы (выполняется повторное чтение из таблицы)
        }

        // метод срабатывающий при нажатии на колонку в DataGrid
        private void PassesListGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex; // Назначаем id строки которую выбрали

            if(e.RowIndex >= 0)
            {
                ViewListApplicationsForm frm = new ViewListApplicationsForm();

                int idP = selectedRow;
                frm.InputDataCalls(idP+1);

                frm.id = idP + 1; // передаем id в класс следующей формы

                this.Hide();
                frm.ShowDialog();
                this.Show();              
            }          
        }
        private void ModalWindowForm_FormClosed(object sender, FormClosedEventArgs e) // закрытие программы
        {
            Application.Exit();
        }
    }

    

}
