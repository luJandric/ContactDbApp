using System;

namespace ContactDbLib
{
    public class Contact
    {
        private int _id;
        private string _ssn;
        private string _firstName;
        private string _lastName;

        public int Id
        {
            get => Id;
            set => _id = Id;
        }

        public string Ssn
        {
            get => Ssn;

            set => _ssn = Ssn;
        }

        public string FirstName
        {
            get => FirstName;

            set => _firstName = FirstName;
        }

        public string LastName
        {
            get => LastName;

            set => _lastName = LastName;
        }
    }
}
