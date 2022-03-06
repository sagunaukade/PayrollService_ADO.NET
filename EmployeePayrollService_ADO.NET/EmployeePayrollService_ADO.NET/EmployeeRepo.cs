using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollService_ADO.NET
{
    public class EmployeeRepo
    {
        //Give path for Database Connection
        public static string connection = @"Data Source=DESKTOP-IAGIDN5;Initial Catalog=Payroll_Service;Integrated Security=True";
        //Represents a connection to Sql Server Database
      //  SqlConnection sqlConnection = new SqlConnection(connection);
        //SqlConnection
        public static SqlConnection sqlConnection = null;

        //Method to check the sql connection is established
        public static void GetAllEmployees()
        {
            try
            {
                using (sqlConnection = new SqlConnection(connection))
                {
                    //Object for employee class
                    EmployeeModel model = new EmployeeModel();
                    //Qurey to retreive data
                    string query = "Select * From Employee_Payroll";
                   //pass query to TSQL
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    //Open Connection
                    sqlConnection.Open();
                    //Returns object of result set
                    SqlDataReader result = command.ExecuteReader();
                    Console.WriteLine("Connection is properly established");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //close connection
                sqlConnection.Close();
            }
        }
    }
}
