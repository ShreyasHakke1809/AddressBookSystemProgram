namespace ContactBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book System");
            AddressBookSystem address = new AddressBookSystem();
            /*bool loopAgain = true;
            while (loopAgain)
            {
                Console.WriteLine("n1.Add new contact\n2.Add new address book\n3.Display Address book\n4.Edit contact\n5.Delete Contact");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        address.AddNewContact();
                        address.DisplayContacts();
                        break;
                    case 2:
                        address.AddMultipleAddressBooks();
                        break;
                    case 3:
                        address.AddMultipleAddressBooks();
                        address.DisplayAddressBooks();
                        break;
                    case 4:
                        address.EditContact();
                        break;
                    case 5:
                        address.DeleteContacts();
                        break;
                    case 6:
                        loopAgain = false;
                        break;

                }*/
            //address.AddNewContact();
            //address.DisplayContacts();
            address.AddMultipleAddressBooks();
            address.DisplayAddressBooks();

        }
    }
}