using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw0704
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> company = new List<object>();

            SQLiteConnection con = new SQLiteConnection($@"Data Source = C:\Users\HackerU\Desktop\0704hw.db; Version = 3");
            con.Open();

            using (SQLiteCommand cmd = new SQLiteCommand($"Select Employee.id, Employee.name as empName, Department.name as deptName from Employee" +
                $" Join Department on Employee.Department_Id = Department.Id", con))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read() == true)
                    {
                        var emp = new
                        {
                            ID = (Int64)reader["ID"],
                            empName = (string)reader["empName"],
                            deptName = (string)reader["deptName"]
                        };
                        company.Add(emp);
                    }
                }
            }
        }
    }
}
