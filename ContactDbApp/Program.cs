using System;
using ContactDbLib;


namespace ContactDbApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SqlRepository.ReadContact(1011));
            SqlRepository.UpdateContact(1011, "12114300000", "Kim", "Christ");
            Console.WriteLine(SqlRepository.ReadContact(1011));
        }
    }
}
