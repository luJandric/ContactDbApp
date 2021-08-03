using System;
using Microsoft.Data.SqlClient;


namespace ContactDbLib
{
    public static class SqlRepository
    {
        public static void CreateContact(string ssn, string firstName, string lastName)
        {
            string connectionString =
                @"Server = (localdb)\MSSQLLocalDB; " +
                "Database = ContactDb; " +
                "Integrated Security = true";

            using SqlConnection connection = new(connectionString);
            SqlCommand command = connection.CreateCommand();

            command.CommandText =
                "INSERT INTO Contact; " +
                "VALUES {}(";
        }


         public static string ReadContact(int id)
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

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine($"You're looking for : {id}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return //alt mulig rart;
        }
    }
}
