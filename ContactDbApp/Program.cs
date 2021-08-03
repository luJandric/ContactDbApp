using System;
using ContactDbLib;


namespace ContactDbApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlRepository.CreateContact("14957730719", "Reginald", "Christ");
        }
    }
}
