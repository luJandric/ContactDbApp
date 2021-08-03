using System;

namespace ContactDbLib
{
    public class Contact
    {
        private int _id;
        private string _ssn;
        private string _firstName;
        private string _lastName;

        public int id
        {
            get => id;
            set => _id = id;
        }

        public string ssn
        {
            get => ssn;

            set => _ssn = ssn;
        }

        public string firstName
        {
            get => firstName;

            set => _firstName = firstName;
        }

        public string lastName
        {
            get => lastName;

            set => _lastName = lastName;
        }
    }
}
