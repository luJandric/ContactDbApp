using System;
using Microsoft.Data.SqlClient;


namespace ContactDbLib
{
    public static class SqlRepository 
    {
        static void CreateContact(string ssn, string firstName, string lastName)
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
    }
}
