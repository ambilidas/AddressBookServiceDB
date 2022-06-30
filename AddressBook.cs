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
                SqlCommand cmd = new SqlCommand("create database AddressBookService");
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
        public int InsertIntoTable(AddressBookTable obj)
        {
            SqlConnection conn = new SqlConnection("data source=LIANO; database=AddressBookService; integrated security=true");
            int result = 0;
            
                using (conn)
                {
                    SqlCommand sqlCommand = new SqlCommand("InsertIntoTable_SP",conn);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@FirstName",obj.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", obj.LastName);
                    sqlCommand.Parameters.AddWithValue("@Address", obj.Address);
                    sqlCommand.Parameters.AddWithValue("@City", obj.City);
                    sqlCommand.Parameters.AddWithValue("@State", obj.State);
                    sqlCommand.Parameters.AddWithValue("@Zip", obj.Zip);
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Email", obj.Email);
                    sqlCommand.Parameters.AddWithValue("@name", obj.name);
                    sqlCommand.Parameters.AddWithValue("@Type", obj.Type);
                    conn.Open();

                    //Executing sql query
                    result = sqlCommand.ExecuteNonQuery();
                    if(result != 0)
                    {
                        Console.WriteLine("Updated");
                    }
                    else
                    {
                        Console.WriteLine("Not updated");
                    }
                    conn.Close();
                }
                return result;
            
        }
        public static void RetrieveData()
        {
            SqlConnection conn = new SqlConnection("data source=LIANO; database=AddressBookService; integrated security=true");
            try
            {
                //sql query
                SqlCommand cmd = new SqlCommand("select * from AddressBook");
                //opening connection
                conn.Open();
                //executing sql query
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data retrieved successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong" + ex);
            }
            //closing connection
            finally
            {
                conn.Close();
            }
        }

        public static void DeleteData()
        {
            SqlConnection conn = new SqlConnection("data source=LIANO; database=AddressBookService; integrated security=true");
            try
            {
                //sql query
                SqlCommand cmd = new SqlCommand("delete from AddressBook where Firstname=Athul");
                //opening connection
                conn.Open();
                //executing sql query
                int result=cmd.ExecuteNonQuery();
                if( result != 0)
                {
                    Console.WriteLine("Updated contact");
                }
                else
                {
                    Console.WriteLine("Not updated");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong" + ex);
            }
            //closing connection
            finally
            {
                conn.Close();
            }
        }



    }
}
