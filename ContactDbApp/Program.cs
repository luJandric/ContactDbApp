using System;
using ContactDbLib;


namespace ContactDbApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlRepository.DeleteContact(2004);
        }
    }
}
