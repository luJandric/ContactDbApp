using System;
using System.Collections.Generic;
using System.Threading.Channels;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;


namespace ContactDbLib
{
    public static class SqlRepository
    {
        const string ConnectionString =
            @"Server = (localdb)\MSSQLLocalDB; " +
            "Database = ContactDb; " +
            "Integrated Security = true";

        public static int CreateContact(string ssn, string firstName, string lastName)
        {
            int indentityId = 0;

            using SqlConnection connection = new(ConnectionString);
            SqlCommand command = connection.CreateCommand();

            command.CommandText =
                "INSERT INTO Contact " +
                $"VALUES (@ssn, @firstName, @lastName)" +
                $"SELECT SCOPE_IDENTITY() as IdentityId;";
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

            using SqlConnection connection = new(ConnectionString);
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
                reader.Close(); //Must we close connection? (connection.Close() ??)
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return contact;
        }


        public static bool UpdateContact(int id, string ssn, string firstName, string lastName)
        {

            using SqlConnection connection = new(ConnectionString);
            SqlCommand command = connection.CreateCommand();

            command.CommandText = "UPDATE Contact " +
                                  "SET SSN = @ssn, FirstName = @firstName, LastName = @lastName " +
                                  "WHERE ID = @id;";
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@ssn", ssn);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);

            try
            {
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }


        public static bool DeleteContact(int id)
        {

            using SqlConnection connection = new(ConnectionString);
            SqlCommand command = connection.CreateCommand();

            command.CommandText =
                "DELETE FROM Contact " +
                "WHERE ID = @id ;";
            command.Parameters.AddWithValue("@id", id);

            try
            {
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static List<Contact> ReadAllContacts()
        {
            List<Contact> list = new List<Contact>();

            using SqlConnection connection = new(ConnectionString);
            SqlCommand command = connection.CreateCommand();


            command.CommandText =
                "SELECT * " +
                "FROM Contact; ";

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Contact contact = new Contact();
                    contact.Id = (int)reader["ID"];
                    contact.Ssn = reader["SSN"].ToString();
                    contact.FirstName = reader["FirstName"].ToString();
                    contact.LastName = reader["LastName"].ToString();
                    list.Add(contact);
                }
                reader.Close(); 
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return list;

        }

        public static void PrintAllContacts()
        {
            foreach (var i in SqlRepository.ReadAllContacts())
            {
                Console.WriteLine(i.ToString());
                Console.WriteLine("------------------------------------\n");
            }

        }
    }
}
