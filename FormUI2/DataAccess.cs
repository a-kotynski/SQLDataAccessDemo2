using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace FormUI2
{
    public class DataAccess
    {
        public List<Person> GetPeople(string lastName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Test_Sample"))) //using means calling code with a connection - afterwhich the connection is destroyed
            {
                var output = connection.Query<Person>($"select * from dbo.Person where LastName = '{ lastName }'").ToList();
                return output;
                //https://youtu.be/Et2khGnrIqc?t=3132
                //TODO restore BAK file to see the stored procedures and replicate them in my database
                //C:\Users\Andrzej\Downloads\SQLDataAccessDemos
            }
        }
    }
}
