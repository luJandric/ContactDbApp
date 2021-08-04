using System;
using ContactDbLib;


namespace ContactDbApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Contact contact = new Contact(55,"23445123456","Eric","Christ");
            Console.WriteLine(contact.ToString());
        }
    }
}
