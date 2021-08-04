using System;

namespace ContactDbLib
{
    public class Contact
    {
        public Contact(int id, string ssn, string firstName, string lastName)
        {
            Id = id;
            Ssn = ssn;
            FirstName = firstName;
            LastName = lastName;
        }

        public Contact()
        {
            // Empty on purpose
        }

        public int Id { get; set; }

        public string Ssn { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return String.Format("ID: {0}\nSSN: {1}\nFirstName: {2}\nLastName: {3}", Id, Ssn, FirstName, LastName);
        }
    }
}
