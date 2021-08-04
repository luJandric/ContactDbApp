using System;
using ContactDbLib;


namespace ContactDbApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SqlRepository.ReadContact(2));
            SqlRepository.UpdateContact(2, "34225167225", "Jimmyy", "Jånes");
            Console.WriteLine(SqlRepository.ReadContact(2));
        }
    }
}
