using System;
using System.Threading.Channels;
using Microsoft.Data.SqlClient;


namespace ContactDbLib
{
    public static class SqlRepository
    {
        public static int CreateContact(string ssn, string firstName, string lastName)
        {
            int indentityId = 0;
            string connectionString =
                @"Server = (localdb)\MSSQLLocalDB; " +
                "Database = ContactDb; " +
                "Integrated Security = true";

            using SqlConnection connection = new(connectionString);
            SqlCommand command = connection.CreateCommand();

            command.CommandText =
                "INSERT INTO Contact " +
                $"VALUES (@ssn, @firstName, @lastName)" +
                $"SELECT SCOPE_IDENTITY() as IdentityId; ";
            command.Parameters.AddWithValue("@ssn", ssn);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);

            try
            {
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    indentityId = (int) (decimal) reader["IdentityID"];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            connection.Close();
            return indentityId;
        }


        public static Contact ReadContact(int id)
        {
            string connectionString =
                @"Server = (localdb)\MSSQLLocalDB; " +
                "Database = ContactDb; " +
                "Integrated Security = true";

            using SqlConnection connection = new(connectionString);
            SqlCommand command = connection.CreateCommand();

            command.CommandText =
                "SELECT * " +
                "FROM Contact " +
                "WHERE Contact.ID = @ID;";
            command.Parameters.AddWithValue("@ID", id);

            Contact contact = new Contact();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    contact.Id = (int) reader["ID"];
                    contact.Ssn = reader["SSN"].ToString();
                    contact.FirstName = reader["FirstName"].ToString();
                    contact.LastName = reader["LastName"].ToString();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return contact;
        }
    }
}
