using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SampleforMetroFramwork
{
    class DatabaseFunctions
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        public int curr_actID;
        public string dep_book;
        public string arr_book;
        public string curr_ticketnumber;

        //Constructor
        public DatabaseFunctions()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "menstranspo";
            uid = "jc";
            password = "secret";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert personal
        public void InsertPersonal(string _tmp_fName, int _tmp_age,
                                   string _tmp_gender, string _tmp_cnumber,
                                   string _tmp_address
                                  )
        {
            int _tmp_cnt = Count() + 10000;
            string query = "INSERT INTO `menstranspo`.`personaldetail`" +
            "(`act_id`," +
            "`name`," +
            "`age`," +
            "`gender`," +
            "`contactnumber`," +
            "`address`)" +
            "VALUES" +
            "(\"" + _tmp_cnt + "\"" +
            ",\"" + _tmp_fName + "\"" +
            "," + _tmp_age + "" +
            ",\"" + _tmp_gender + "\"" +
            ",\"" + _tmp_cnumber + "\"" +
            ",\"" + _tmp_address + "\"" + ");"
            ;

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
                curr_actID = _tmp_cnt;
            }
        }

        //Insert vehicle
        public void InsertVehicle(string _tmp_color,
                                   int _tmp_cap, String _tmp_model,
                                   string _tmp_plate, string _tmp_ctype
                                  )
        {

            string query = "INSERT INTO `menstranspo`.`vehicledtl`" +
            "(`act_id`," +
            "`color`," +
            "`capacity`," +
            "`model`," +
            "`plate`," +
            "`volunteer_id`," +
            "`c_type`)" +
            "VALUES" +
            "(\"" + curr_actID + "\"" +
            ",\"" + _tmp_color + "\"" +
            "," + _tmp_cap + " " +
            ",\"" + _tmp_model + "\"" +
            ",\"" + _tmp_plate + "\"" +
            ",\"" + curr_actID + "\"" +
            ",\"" + _tmp_ctype + "\"" + ");"
            ;

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }


        //Insert Church Details
        public void InsertChurchDetails(string _tmp_arrDtl,
                                   string _tmp_depDtl, string _tmp_region,
                                   string _tmp_church, string _tmp_ticketNumber

                                   )
        {

            string query = "INSERT INTO `menstranspo`.`attendeedtl`" +
            "(`attendee_act_id`," +
            "`arrival_dtl_id`," +
            "`dep_dtl_id`," +
            "`region`," +
            "`church`," +
            "`ticker_number`)" +
            "VALUES" +
            "(\"" + curr_actID + "\"" +
            ",\"" + _tmp_arrDtl + "\"" +
            ",\"" + _tmp_depDtl + "\"" +
            ",\"" + _tmp_region + "\"" +
            ",\"" + _tmp_church + "\"" +
            ",\"" + _tmp_ticketNumber + "\"" + ");"
            ;



            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();
                dep_book = _tmp_depDtl;
                arr_book = _tmp_arrDtl;
                curr_ticketnumber = _tmp_ticketNumber;

                //close connection
                this.CloseConnection();
            }
        }

        //Insert Flight Arrivals
        public void InsertFlightArrivals(string _tmp_fNum,
                                   string _tmp_terminal, String _tmp_airline,
                                   string _tmp_routeFr, string _tmp_routeTo,
                                   string _tmp_depTime, string _tmp_arrDate,
                                 string _tmp_arrTime, string _tmp_depDate,
                                 string _tmp_dPoint, string _tmp_dAddress
                                   )
        {

            string query = "INSERT INTO `menstranspo`.`arrivaldtl`" +
            "(`arr_ticket_number`," +
            "`booking_num`," +
            "`flight_num`," +
            "`terminal`," +
            "`airline`," +
            "`route_from`," +
            "`route_to`," +
            "`dep_time`," +
            "`arr_date`," +
            "`arr_time`," +
            "`dep_date`," +
            "`drop_point`," +
            "`drop_address`)" +
            "VALUES" +
            "(\"" + curr_ticketnumber + "\"" +
            ",\"" + arr_book + "\"" +
            ",\"" + _tmp_fNum + "\"" +
            ",\"" + _tmp_terminal + "\"" +
            ",\"" + _tmp_airline + "\"" +
            ",\"" + _tmp_routeFr + "\"" +
            ",\"" + _tmp_routeTo + "\"" +
            ",\"" + _tmp_depTime + "\"" +
            ",\"" + _tmp_arrDate + "\"" +
            ",\"" + _tmp_arrTime + "\"" +
            ",\"" + _tmp_depDate + "\"" +
            ",\"" + _tmp_dPoint + "\"" +
            ",\"" + _tmp_dAddress + "\"" + ");"
            ;

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Insert Flight Departure
        public void InsertFlightDeparture(string _tmp_fNum,
                                   string _tmp_terminal, String _tmp_airline,
                                   string _tmp_routeFr, string _tmp_routeTo,
                                   string _tmp_depTime, string _tmp_arrDate,
                                 string _tmp_arrTime, string _tmp_depDate,
                                string _tmp_puTime, String _tmp_puPointAddress


                                   )
        {

            string query = "INSERT INTO `menstranspo`.`departuredtl`" +

           "(`dep_ticket_number`," +
           "`booking_num`," +
           "`flight_num`," +
           "`terminal`," +
           "`airline`," +
           "`route_from`," +
           "`route_to`," +
           "`dep_time`," +
           "`arr_date`," +
           "`arr_time`," +
           "`dep_date`," +
           "`pickup_time`," +
           "`pickup_point`)" +
           "VALUES" +
           "(\"" + curr_ticketnumber + "\"" +
           ",\"" + dep_book + "\"" +
           ",\"" + _tmp_fNum + "\"" +
           ",\"" + _tmp_terminal + "\"" +
           ",\"" + _tmp_airline + "\"" +
           ",\"" + _tmp_routeFr + "\"" +
           ",\"" + _tmp_routeTo + "\"" +
           ",\"" + _tmp_depTime + "\"" +
           ",\"" + _tmp_arrDate + "\"" +
           ",\"" + _tmp_arrTime + "\"" +
           ",\"" + _tmp_depDate + "\"" +
           ",\"" + _tmp_puTime + "\"" +
           ",\"" + _tmp_puPointAddress + "\"" + ");"
           ;

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }




        //Update statement
        public void Update()
        {
            string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }


        }

        //Delete statement
        public void Delete()
        {
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }

        }







        //Select statement
        public List<string>[] Select(string act_id)
        {

            string query = "SELECT * FROM  `menstranspo`.`personaldetail` where ";
            //Create a list to store the result
            List<string>[] list = new List<string>[6];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();
            list[5] = new List<string>();
            list[6] = new List<string>();
            list[7] = new List<string>();
            list[8] = new List<string>();
            list[9] = new List<string>();
            list[10] = new List<string>();
            list[11] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();






                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["name"] + "");
                    list[2].Add(dataReader["age"] + "");
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["name"] + "");
                    list[2].Add(dataReader["age"] + "");
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["name"] + "");
                    list[2].Add(dataReader["age"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }

        }

        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM personaldetail";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        //Backup
        public void Backup()
        {
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;

                //Save file to C:\ with the current date as a filename
                string path;
                path = "C:\\MySqlBackup" + year + "-" + month + "-" + day +
            "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                StreamWriter file = new StreamWriter(path);


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to backup!");
            }

        }

        //Restore
        public void Restore()
        {
            try
            {
                //Read file from C:\
                string path;
                path = "C:\\MySqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    uid, password, server, database);
                psi.UseShellExecute = false;


                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to Restore!");
            }

        }
    }
}
