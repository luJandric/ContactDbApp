using System;

namespace ContactDbLib
{
    public class Contact
    {
        private int _ID;
        private string _SSN;
        private string _FirstName;
        private string _LastName;

        public int ID
        {
            get => ID;
            set => _ID = ID;
        }

        public string SSN
        {
            get => SSN;

            set => _SSN = SSN;
        }

        public string FirstName
        {
            get => FirstName;

            set => _FirstName = FirstName;
        }

        public string LastName
        {
            get => LastName;

            set => _LastName = LastName;
        }
    }
}
