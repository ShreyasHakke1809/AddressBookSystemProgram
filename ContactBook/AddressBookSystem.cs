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
        public void DisplayContacts()
        {
            foreach (var contact in listofContacts)
            {
                Console.WriteLine(contact);
            }
        }
    }
}
