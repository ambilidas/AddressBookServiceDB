using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookServiceDB
{
    public class AddressBook
    {
        public static void CreateDataBase()
        {
            SqlConnection conn = new SqlConnection("data source=LIANO; database=AddressBookService; integrated security=true");
            try
            {
                //sql query
                SqlCommand cmd = new SqlCommand("create database AddressBookServiceDB");
                //opening connection
                conn.Open();
                //executing sql query
                cmd.ExecuteNonQuery();
                Console.WriteLine("Database created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong"+ex);
            }
            //closing connection
            finally
            {
                conn.Close();
            }
        }
    }
}
