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
                $"VALUES (@ssn, @firstName, @lastName);";
            command.Parameters.AddWithValue("@ssn", ssn);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);

            // Debug-info: to see generated SQL. 
            Console.WriteLine($"\nAdded: {command.CommandText}");
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

            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                contact.ssn = reader.GetName(0);
                contact.firstName = reader.GetName(1);
                contact.lastName = reader.GetName(2);

                //Console.WriteLine($"{reader.GetName(0)} {reader.GetName(1)} {reader.GetName(2)}");
                //Console.WriteLine($"You're looking for : {id}");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return contact;
        }
    }
}
