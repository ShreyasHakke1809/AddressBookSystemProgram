﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook
{
    public class AddressBookSystem
    {
        List<Contact> contacts;
        public AddressBookSystem()
        {
            contacts = new List<Contact>();
        }
        public void AddContact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            Contact personDetails = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
            contacts.Add(personDetails);
            DisplayContacts();
        }
        public void AddNewContact()
        {
            Console.WriteLine("-----------------------------------------------\n");
            Console.WriteLine("Create new contact\n");
            Console.Write("Enter your First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter your Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter your Address: ");
            string address = Console.ReadLine();
            Console.Write("Enter your City: ");
            string city = Console.ReadLine();
            Console.Write("Enter your State: ");
            string state = Console.ReadLine();
            Console.Write("Enter your Zipcode: ");
            string zip = Console.ReadLine();
            Console.Write("Enter your Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter your EmailID: ");
            string email = Console.ReadLine();

            AddContact(firstName, lastName, address, city, state, zip, phoneNumber, email);
            Console.WriteLine("\nNew added contact\n");
            DisplayContacts();
        }
        public void DisplayContacts()
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine("First Name: " + contact.firstName);
                Console.WriteLine("Last Name: " + contact.lastName);
                Console.WriteLine("Address: " + contact.address);
                Console.WriteLine("City: " + contact.city);
                Console.WriteLine("State: " + contact.state);
                Console.WriteLine("ZipCode: " + contact.zip);
                Console.WriteLine("Phone Number: " + contact.phoneNumber);
                Console.WriteLine("Email ID: " + contact.email);
            }
        }
    }
}
