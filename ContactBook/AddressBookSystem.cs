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
        public void EditContact()
        {
            Console.WriteLine("-------------------------------------------------\n");
            Console.WriteLine("Enter the first Name to edit the details");
            string firstName = Console.ReadLine();
            foreach (var ele in contacts)
            {
                if (ele.firstName.Equals(firstName))
                {
                    Console.WriteLine("\nContact Found\n");
                    Console.WriteLine("Enter the new first name to Edit");
                    ele.firstName = Console.ReadLine();
                    Console.WriteLine("Enter the new last name to Edit");
                    ele.lastName = Console.ReadLine();
                    Console.WriteLine("Enter new address to Edit");
                    ele.address = Console.ReadLine();
                    Console.WriteLine("Enter new city to Edit");
                    ele.city = Console.ReadLine();
                    Console.WriteLine("Enter new state to Edit");
                    ele.state = Console.ReadLine();
                    Console.WriteLine("Enter new zipcode to Edit");
                    ele.zip = Console.ReadLine();
                    Console.WriteLine("Enter the new phonenumber to Edit");
                    ele.phoneNumber = Console.ReadLine();
                    Console.WriteLine("Enter the new email to Edit");
                    ele.email = Console.ReadLine();
                    Console.WriteLine("\nNew edited contact is\n");
                    DisplayContacts();
                }
            }
        }
        public void DeleteContacts()
        {
            Console.WriteLine("-------------------------------------------------\n");
            Console.WriteLine("\nYou want to delete contact\n");
            Console.WriteLine("Enter the first Name");
            string FirstName = Console.ReadLine();
            Console.WriteLine("Enter the last Name");
            string LastName = Console.ReadLine();
            // Person person = new Person();
            foreach (var contact in contacts.ToList())
            {
                if (contact.firstName.Equals(FirstName) && contact.lastName.Equals(LastName))
                {
                    Console.WriteLine("RemoveContact" + contact);
                    contacts.Remove(contact);
                    Console.WriteLine("Contact removed successfully");
                }
            }
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
