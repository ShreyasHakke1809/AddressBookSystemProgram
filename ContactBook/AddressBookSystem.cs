using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace ContactBook
{
    public class AddressBookSystem
    {
        List<Contact> listofContacts = new List<Contact>();
        Dictionary<string, List<Contact>> multipleAddressBook = new Dictionary<string, List<Contact>>();
        public List<Contact> AddNewContact()
        {
            Console.WriteLine("How many contacts you want to create");
            int n = Convert.ToInt32(Console.ReadLine());
            int i = 0;
            while (i < n)
            {
                Console.WriteLine("-----------------------------------------------\n");
                Console.WriteLine("Create new contact\n");
                Contact contact = new Contact();

                Console.Write("Enter your First Name: ");
                string firstName = Console.ReadLine();
                bool isDuplicate = listofContacts.Any(existingContact => existingContact.firstName.Equals(firstName));
                if (isDuplicate)
                {
                    Console.WriteLine("Contact with the same first name already exists. Please enter a different first name.");
                    continue;
                }
                contact.firstName = firstName;
                Console.Write("Enter your Last Name: ");
                contact.lastName = Console.ReadLine();
                Console.Write("Enter your Address: ");
                contact.address = Console.ReadLine();
                Console.Write("Enter your City: ");
                contact.city = Console.ReadLine();
                Console.Write("Enter your State: ");
                contact.state = Console.ReadLine();
                Console.Write("Enter your Zipcode: ");
                contact.zip = Console.ReadLine();
                Console.Write("Enter your Phone Number: ");
                contact.phoneNumber = Console.ReadLine();
                Console.Write("Enter your EmailID: ");
                contact.email = Console.ReadLine();
                listofContacts.Add(contact);
                i++;
            }
            return listofContacts;
        }
        public void EditContact()
        {
            Console.WriteLine("Enter the address book name in which you want to edit a contact:");
            string addressBookName = Console.ReadLine();

            // Check if the provided address book name exists in the dictionary
            if (multipleAddressBook.ContainsKey(addressBookName))
            {
                List<Contact> contactsInAddressBook = multipleAddressBook[addressBookName];

                Console.WriteLine("Enter the first name of the contact you want to edit:");
                string firstName = Console.ReadLine();

                // Find the contact to edit using the provided first name
                Contact contactToEdit = null;
                foreach (Contact contact in contactsInAddressBook)
                {
                    if (contact.firstName.Equals(firstName))
                    {
                        contactToEdit = contact;
                        break;
                    }
                }
                if (contactToEdit != null)
                {
                    Console.WriteLine("Enter the new first name:");
                    contactToEdit.firstName = Console.ReadLine();
                    Console.WriteLine("Enter the new last name:");
                    contactToEdit.lastName = Console.ReadLine();
                    Console.WriteLine("Enter new address:");
                    contactToEdit.address = Console.ReadLine();
                    Console.WriteLine("Enter new city:");
                    contactToEdit.city = Console.ReadLine();
                    Console.WriteLine("Enter new state:");
                    contactToEdit.state = Console.ReadLine();
                    Console.WriteLine("Enter new zipcode:");
                    contactToEdit.zip = Console.ReadLine();
                    Console.WriteLine("Enter the new phone number:");
                    contactToEdit.phoneNumber = Console.ReadLine();
                    Console.WriteLine("Enter the new email:");
                    contactToEdit.email = Console.ReadLine();

                    Console.WriteLine("\nContact edited successfully.\n");
                    DisplayAddressBooks();
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }
            }
            else
            {
                Console.WriteLine("Address book not found.");
            }
        }
        public void DeleteContacts()
        {
            Console.WriteLine("Enter the address book name from which you want to delete a contact:");
            string addressBookName = Console.ReadLine();

            if (multipleAddressBook.ContainsKey(addressBookName))
            {
                Console.WriteLine("Enter the first name of the contact you want to delete:");
                string firstName = Console.ReadLine();

                List<Contact> contactsInAddressBook = multipleAddressBook[addressBookName];

                Contact contactToDelete = null;
                foreach (Contact contact in contactsInAddressBook)
                {
                    if (contact.firstName.Equals(firstName))
                    {
                        contactToDelete = contact;
                        break;
                    }
                }
                if (contactToDelete != null)
                {
                    contactsInAddressBook.Remove(contactToDelete);
                    Console.WriteLine("Contact removed successfully.");
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }
            }
            else
            {
                Console.WriteLine("Address book not found.");
            }
        }
        public void AddMultipleAddressBooks()
        {
            Console.WriteLine("How many addresss book you create");
            int n = Convert.ToInt32(Console.ReadLine());
            int i = 0;
            while (i < n)
            {
                Console.WriteLine("Please enter address book name");
                string name = Console.ReadLine();
                bool isPresent = false;
                foreach (var keys in multipleAddressBook.Keys)
                {
                    if (keys.Equals(name))
                    {
                        // bookName=name;
                        Console.WriteLine("Address Book is Present");
                        isPresent = true;
                        break;
                    }
                }
                if (!isPresent)
                {
                    List<Contact> contacts = AddNewContact();
                    multipleAddressBook.Add(name, contacts);
                    listofContacts = new List<Contact>();
                    i++;
                }
                else
                {
                    break;
                }
            }
            DisplayContacts();
        }
        public void DisplayAddressBooks()
        {
            foreach (KeyValuePair<string, List<Contact>> addressBook in multipleAddressBook)
            {
                Console.WriteLine("Address Book Name:" + addressBook.Key);
                Console.WriteLine("Displaying contacts in this Address book");
                foreach (Contact contact in addressBook.Value)
                {
                    Console.WriteLine(contact);
                }
            }
        }
        public void SearchByCityOrState()
        {
            Console.WriteLine("Enter the city or state to search for contacts:");
            string searchQuery = Console.ReadLine();

            bool found = false;

            foreach (KeyValuePair<string, List<Contact>> addressBook in multipleAddressBook)
            {
                Console.WriteLine($"Searching in Address Book: {addressBook.Key}");
                List<Contact> matchingContacts = addressBook.Value
                    .Where(contact => contact.city.Equals(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                                       contact.state.Equals(searchQuery, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (matchingContacts.Any())
                {
                    matchingContacts.ForEach(contact => Console.WriteLine(contact));
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine($"No contacts found in any address book for {searchQuery}");
            }
        }
        public void ViewByCityOrState()
        {
            Console.WriteLine("Enter the city or state to search for contacts:");
            string searchQuery = Console.ReadLine();
            bool found = false;

            foreach (KeyValuePair<string, List<Contact>> addressBook in multipleAddressBook)
            {
                Console.WriteLine($"Searching in Address Book: {addressBook.Key}");
                List<Contact> matchingContacts = addressBook.Value
                    .Where(contact =>
                        contact.city.Equals(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                        contact.state.Equals(searchQuery, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (matchingContacts.Any())
                {
                    Console.WriteLine("Matching Contacts:");
                    foreach (Contact matchingContact in matchingContacts)
                    {
                        Console.WriteLine(matchingContact);
                    }
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine($"No contacts found in any address book for {searchQuery}");
            }
        }
        public int GetContactCountByCity()
        {
            string city = Console.ReadLine();
            int count = 0;

            foreach (KeyValuePair<string, List<Contact>> addressBook in multipleAddressBook)
            {
                List<Contact> contactsInAddressBook = addressBook.Value;
                count += contactsInAddressBook.Count(contact =>
                    contact.city.Equals(city, StringComparison.OrdinalIgnoreCase));
            }

            return count;
        }

        public int GetContactCountByState()
        {
            string state = Console.ReadLine();
            int count = 0;

            foreach (KeyValuePair<string, List<Contact>> addressBook in multipleAddressBook)
            {
                List<Contact> contactsInAddressBook = addressBook.Value;
                count += contactsInAddressBook.Count(contact =>
                    contact.state.Equals(state, StringComparison.OrdinalIgnoreCase));
            }

            return count;
        }
        public void SortAddressBookByName()
        {
            Console.WriteLine("Enter the address book name you want to sort by name:");
            string addressBookName = Console.ReadLine();

            if (multipleAddressBook.ContainsKey(addressBookName))
            {
                List<Contact> contactsInAddressBook = multipleAddressBook[addressBookName];

                List<Contact> sortedContacts = contactsInAddressBook.OrderBy(contact => contact.firstName).ToList();

                Console.WriteLine($"Sorted Contacts in Address Book '{addressBookName}' by Name:");
                foreach (Contact contact in sortedContacts)
                {
                    Console.WriteLine(contact);
                }
            }
            else
            {
                Console.WriteLine("Address book not found.");
            }
        }
        public void SortAddressBookByCity()
        {
            string addressBookName = Console.ReadLine();
            if (multipleAddressBook.ContainsKey(addressBookName))
            {
                List<Contact> contactsInAddressBook = multipleAddressBook[addressBookName];

                List<Contact> sortedContacts = contactsInAddressBook.OrderBy(contact => contact.city).ToList();

                Console.WriteLine($"Sorted Contacts in Address Book '{addressBookName}' by City:");
                foreach (Contact contact in sortedContacts)
                {
                    Console.WriteLine(contact);
                }
            }
            else
            {
                Console.WriteLine("Address book not found.");
            }
        }

        public void SortAddressBookByState()
        {
            string addressBookName = Console.ReadLine();

            if (multipleAddressBook.ContainsKey(addressBookName))
            {
                List<Contact> contactsInAddressBook = multipleAddressBook[addressBookName];

                List<Contact> sortedContacts = contactsInAddressBook.OrderBy(contact => contact.state).ToList();

                Console.WriteLine($"Sorted Contacts in Address Book '{addressBookName}' by State:");
                foreach (Contact contact in sortedContacts)
                {
                    Console.WriteLine(contact);
                }
            }
            else
            {
                Console.WriteLine("Address book not found.");
            }
        }

        public void SortAddressBookByZip()
        {
            string addressBookName = Console.ReadLine();

            if (multipleAddressBook.ContainsKey(addressBookName))
            {
                List<Contact> contactsInAddressBook = multipleAddressBook[addressBookName];

                List<Contact> sortedContacts = contactsInAddressBook.OrderBy(contact => contact.zip).ToList();

                Console.WriteLine($"Sorted Contacts in Address Book '{addressBookName}' by Zip:");
                foreach (Contact contact in sortedContacts)
                {
                    Console.WriteLine(contact);
                }
            }
            else
            {
                Console.WriteLine("Address book not found.");
            }
        }
        public void WriteToTextFile()
        {
            string path = @"C:\Users\shrey\source\repos\ContactBook\ContactBook\FileIo.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (var contact in listofContacts)
                    {
                        writer.WriteLine($"First Name: {contact.firstName}");
                        writer.WriteLine($"Last Name: {contact.lastName}");
                        writer.WriteLine($"Address: {contact.address}");
                        writer.WriteLine($"City: {contact.city}");
                        writer.WriteLine($"State: {contact.state}");
                        writer.WriteLine($"Zipcode: {contact.zip}");
                        writer.WriteLine($"Phone Number: {contact.phoneNumber}");
                        writer.WriteLine($"Email: {contact.email}");
                        writer.WriteLine("-----------------------------------------------");
                    }
                }
                Console.WriteLine($"Address book data written to {path}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to the file: {ex.Message}");
            }
        }

        public void ReadFromTextFile()
        {
            string path = @"C:\Users\shrey\source\repos\ContactBook\ContactBook\FileIo.txt";
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
            Console.ReadKey();
        }
        public void WriteToCSVFile()
        {
            string path = @"C:\Users\shrey\source\repos\ContactBook\ContactBook\Files\FileName.csv";

            using (var writer = new StreamWriter(path))
            using (var csvexport = new CsvWriter(writer, CultureInfo.InvariantCulture))

                csvexport.WriteRecords(listofContacts);

        }
        public void ReadFromCSVFile()
        {
            /*string path = @"C:\Users\shrey\source\repos\ContactBook\ContactBook\Files\FileName.csv";

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Contact>().ToList();
                {
                    Console.WriteLine();
                    foreach (Contact contact in records)
                    {
                        Console.WriteLine(contact);
                    }
                }
            }*/
            string filePath = @"C:\Users\shrey\source\repos\ContactBook\ContactBook\Files\FileName.csv";

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                using (CsvReader csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    var records = csv.GetRecords<Contact>(); // Replace MyCsvClass with your data class

                    foreach (var record in records)
                    {
                        // Process the data as needed
                        Console.WriteLine(record.ToString());//$"First Name: {record.firstName}, Last Name: {record.lastName}, Email: {record.Email}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }



        public void DisplayContacts()
        {
            foreach (var contact in listofContacts)
            {
                Console.WriteLine(contact);
            }
        }
    }
}

