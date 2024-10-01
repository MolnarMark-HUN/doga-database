using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace doga_database
{
    public class databasehandler
    {
        Form f;
        MySqlConnection connection;
        string tablename = "pekaruk";
        public databasehandler()
        {
            f = new Form();   
            string username = "root";
            string password = "";
            string host = "localhost";
            string dbname = "pekseg";
            string connectionstring = $"username={username};password={password};host={host};database={dbname}";
            connection = new MySqlConnection(connectionstring);

        }
        public void readall()
        {
            connection.Open();
            string query = "SELECT * FROM pekaruk";
            MySqlCommand command = new MySqlCommand(query,connection);
            MySqlDataReader read = command.ExecuteReader();
            try
            {
                while (read.Read())
                {
                    int id = read.GetInt32(read.GetOrdinal("id"));
                    int ammount = read.GetInt32(read.GetOrdinal("ammount"));
                    string name = read.GetString(read.GetOrdinal("name"));
                    int price = read.GetInt32(read.GetOrdinal("price"));
                    pekaruk pekstuff = new pekaruk();
                    pekstuff.id = id;
                    pekstuff.ammount = ammount;
                    pekstuff.name = name;
                    pekstuff.price = price;
                    pekaruk.peks.Add(pekstuff);



                }
                command.Dispose();
                read.Close();
                connection.Close();
                MessageBox.Show("Bombaaaaa");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"Error");
            }
            
        }
        public void write(pekaruk peke)
        {
            connection.Open();

            try
            {
                string query = $"INSERT INTO {tablename} (name,ammount,price) values('{peke.name}',{peke.ammount},{peke.price}) ";
                MySqlCommand command = new MySqlCommand(query, connection);
                pekaruk.peks.Add(peke);
                command.ExecuteNonQuery();
                command.Dispose();
                MessageBox.Show("Sikerult");
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error");
            }
            connection.Close();

        }
        public void deleteone(pekaruk pes)
        {
            
            try
            {
                connection.Open();
                string query = $"DELETE FROM {tablename} WHERE id ={pes.id}";
                MySqlCommand command = new MySqlCommand(query, connection);
                pekaruk.peks.Remove(pes);
                command.ExecuteNonQuery();
                command.Dispose();
                MessageBox.Show("Siker geci");
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error");
            }
            connection.Close();
        }

    }
}
