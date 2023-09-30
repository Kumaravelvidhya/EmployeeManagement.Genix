using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmployeeRepository
    {
        public readonly string connectionString;

        public EmployeeRepository()
        {
            connectionString = @"Data source=ANIYAAN-1006;Initial catalog=EmployeeManagement;User Id=Anaiyaan;Password=Anaiyaan@123";
        }
        public List<EmployeeModel> GetAllEmployeeData()
        {
            try
            {
                List<EmployeeModel> constrain = new List<EmployeeModel>();

                var connection = new SqlConnection(connectionString);
                connection.Open();
                constrain = connection.Query<EmployeeModel>($" exec Getallemployees").ToList();
                connection.Close();

                return constrain;
            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EmployeeModel GetEmployeeData(int Id)
        {
            try
            {
                var connection = new SqlConnection(connectionString);
                connection.Open();
                var Employee = connection.QueryFirst<EmployeeModel>($" exec Getemployeesid {Id} ");
                connection.Close();
                return Employee;
            }

            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertEmployeeData(EmployeeModel details)
        {

            try
            {
                SqlConnection con = new SqlConnection(connectionString);

                con.Open();
                con.Execute($" exec CreateEmployeeDetails '{details.Name}', '{details.DateOfBirth}','{details.Experience}','{details.Phonenumber}','{details.EmailAddress}'");

                con.Close();

            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void UpdateEmployeeData(EmployeeModel details)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);

                con.Open();
                con.Execute($" exec UpdateEmployeeDetails '{details.Id}','{details.Name}','{details.DateOfBirth}','{details.Experience}','{details.Phonenumber}','{details.EmailAddress}'");
                con.Close();
            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteEmployeeData(int Id)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);

                con.Open();
                con.Execute($"  exec DeleteEmployeeDetails { Id}");
                con.Close();
            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
