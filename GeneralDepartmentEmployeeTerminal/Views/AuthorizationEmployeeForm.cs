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
    public partial class AuthorizationEmployeeForm : Form
    {
        DBConnect database = new DBConnect();
        public AuthorizationEmployeeForm()
        {
            InitializeComponent();
            //чтобы окно вызывалось по центру экрана
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AuthorizationEmployeeForm_Load(object sender, EventArgs e)
        {
            
        }

        private void AuthorizationButton_Click(object sender, EventArgs e)
        {
            // в переменную сохраняем данные из тексбокса
            var employeeCode = textBox1.Text;

            SqlDataAdapter adapter = new SqlDataAdapter(); //адаптер для работы с командами sql
            DataTable table = new DataTable(); // для работы с даннными

            // создание строки запроса
            SqlCommand command = new SqlCommand("SELECT id, department, employee_code FROM Employees WHERE employee_code = @eC AND department = @Val", database.getConnection());
            command.Parameters.Add("@eC", SqlDbType.VarChar).Value = employeeCode;
            command.Parameters.Add("@Val", SqlDbType.VarChar).Value = "Общий отдел";

            adapter.SelectCommand = command; // выполнение команды
            adapter.Fill(table); // в table сохраняется кол-во обновленных строк

            /* проверка: если из таблицы есть наши данные то они обновлятся, т.к. они идентичны то
            кол-во столбцов в ней должны быть обновлены только один */
            if (table.Rows.Count == 1)
            {
                // тогда переключаемся на другую форму
                ModalWindowForm ViewForm = new ModalWindowForm();
                this.Hide();
                ViewForm.ShowDialog();
                this.Show();
            }
            else 
            MessageBox.Show("Неверный код сотрудника!"); // иначе выдаем ошибку

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '*'; //скрываем символом '*' наши данные
            textBox1.MaxLength = 7; // задаем длину 7 символов
        }
    }
}
