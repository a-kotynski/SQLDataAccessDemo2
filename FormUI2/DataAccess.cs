using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace FormUI2
{
    public class DataAccess
    {
        public List<Person> GetPeople(string lastName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Test_Sample"))) //using means calling code with a connection - afterwhich the connection is destroyed
            {
                var output = connection.Query<Person>("People_GetByLastName @LastName", new { LastName = lastName }).ToList(); //string contains stored procedure and attribute name
                return output;
            }
        }

        internal void InsertPerson(string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Test_Sample")))
            {
                List<Person> people = new List<Person>();
                people.Add(new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, PhoneNumber=phoneNumber });
                connection.Execute("dbo.People_Insert @FirstName, @LastName, @EmailAddress, @PhoneNumber", people);
            }
        }
    }
}
