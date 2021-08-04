using System;
using System.Collections.Generic;
using ContactDbLib;


namespace ContactDbApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlRepository.PrintAllContacts();
        }
    }
}
