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
    public partial class ViewListApplicationsForm : Form
    {
        public int id; // переменная для получения id

        DBConnect dbConnect = new DBConnect();
        SqlDataAdapter adapter = new SqlDataAdapter();
        public ViewListApplicationsForm()
        {
            InitializeComponent();
            ComboBoxAdd();
        }

        // кнопка назад
        private void BackToListButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveChangeButton_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            dbConnect.openConnection();
            int status = 0;
            // обновление статуса заявки
            var statusString = StatusComboBox.Text;

            if (statusString == "Ожидание") status = 1;
            else if (statusString == "Одобрена") status = 2;
            else if (statusString == "Отклонена") status = 3;

            var AddQuary = $"UPDATE User_Private_Visit SET id_status = {status} WHERE id = {id}";
            var AddQuaryBL = $"UPDATE User_Private_Visit SET id_status = {status} WHERE id = {id}; INSERT INTO Black_List (id_user) VALUES ('{id}')";

            // добавление даты прибытия

            var ArrivalTime = TimePicker.Value;
            var ArrivalDate = DatePicker.Value;

            if(status == 2 )
            {
                // добавляю в БД данные времени
                var AddTimeArrival = $"INSERT INTO Arrival_Time (date_arrival, time_arrival) VALUES ('{ArrivalDate}','{ArrivalTime}'); SELECT SCOPE_IDENTITY()";
                

                var insertCommand = new SqlCommand(AddTimeArrival, dbConnect.getConnection());
                var idA = insertCommand.ExecuteScalar();
                // обновляю строку добалвенной связи времени прибытия
                var UpdateQuary = $"UPDATE User_Private_Visit SET id_arrival_time = {idA} WHERE id = {id}";
                var commandTime = new SqlCommand(UpdateQuary, dbConnect.getConnection());
                commandTime.ExecuteNonQuery();

                var command = new SqlCommand(AddQuary, dbConnect.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Данные измененны и сохраненны!");
            }
            else if (status == 3)
            {
                // добавляю в БД данные времени
                var AddTimeArrival = $"INSERT INTO Arrival_Time (date_arrival, time_arrival) VALUES ('{ArrivalDate}','{ArrivalTime}'); SELECT SCOPE_IDENTITY()";


                var insertCommand = new SqlCommand(AddTimeArrival, dbConnect.getConnection());
                var idA = insertCommand.ExecuteScalar();
                // обновляю строку добалвенной связи времени прибытия
                var UpdateQuary = $"UPDATE User_Private_Visit SET id_arrival_time = {idA} WHERE id = {id}";
                var commandTime = new SqlCommand(UpdateQuary, dbConnect.getConnection());
                commandTime.ExecuteNonQuery();

                var command = new SqlCommand(AddQuaryBL, dbConnect.getConnection());
                command.ExecuteNonQuery();

                StatusComboBox.Enabled = false;
                TimePicker.Enabled = false;
                DatePicker.Enabled = false;

                MessageBox.Show("Данные измененны и сохраненны!");
            }
            else
            MessageBox.Show("Данные по времени не могут быть сохранены если заявка не одобрена!");

            

            dbConnect.closeConnection();
        }

        public void InputDataCalls(int id)
        {

            // <summary>
            // Выбираем все данные которые соответсвуют входящему id
            // adapter возвращает нам индефикаторы пользователей, данных паспорта и статус заявки, а так же
            // прочие нужные данные заявителя для заполнения формы
            // <summary/>
            SqlCommand command = new SqlCommand(
                "SELECT (SELECT login_user FROM Users WHERE id = User_Private_Visit.id_user), " +
                "last_name, first_name, patronymic, phone_number, email," +
                "(SELECT status FROM Status WHERE id = User_Private_Visit.id_status), appointment," +
                "(SELECT passport_series FROM Passport_Data WHERE id = User_Private_Visit.id_passport_data)," +
                "(SELECT  passport_number FROM Passport_Data WHERE id = User_Private_Visit.id_passport_data) " +
                "FROM User_Private_Visit WHERE id = @iU", dbConnect.getConnection());
            command.Parameters.Add("@iU", SqlDbType.VarChar).Value = id;

            adapter.SelectCommand = command;

            dbConnect.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            reader.Read();
            // записывание данных в форму
            LoginBox.Text = reader.GetString(0);
            LastNameBox.Text = reader.GetString(1);
            FirstNameBox.Text = reader.GetString(2);
            PatronymicBox.Text = reader.GetString(3);
            PhoneNumberBox.Text = reader.GetString(4);
            EmailBox.Text = reader.GetString(5);
            StatusComboBox.Text = reader.GetString(6);
            AppointmentBox.Text = reader.GetString(7);
            PassportDataSeries.Text = reader.GetString(8);
            PassportDataNumber.Text = reader.GetString(9);

            reader.Close();

            dbConnect.closeConnection();
        }

        private void ComboBoxAdd()
        {
            dbConnect.openConnection();
            // <summary>
            // в command поступают все названия статусов
            // в reader он отправляет все значения, которые по циклу читает
            // и вывод в наш combobox
            // <summary/>
            SqlCommand command = new SqlCommand("SELECT status FROM Status", dbConnect.getConnection());
            adapter.SelectCommand = command;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                StatusComboBox.Items.Add(reader.GetString(0));
            }
            reader.Close();

            dbConnect.closeConnection();
        }

        private void StatusComboBox_Layout(object sender, LayoutEventArgs e)
        {
            dbConnect.openConnection();

            SqlCommand cmd = new SqlCommand("SELECT id_user FROM Black_List", dbConnect.getConnection());
            adapter.SelectCommand = cmd;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (id == reader.GetInt32(0))
                {
                    StatusComboBox.Enabled = false;
                    TimePicker.Enabled = false;
                    DatePicker.Enabled = false;
                }
            }
            reader.Close();
            dbConnect.closeConnection();
        }
    }
}
