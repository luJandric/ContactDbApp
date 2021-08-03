using System;
using ContactDbLib;


namespace ContactDbApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlRepository.ReadContact(3);
        }
    }
}
