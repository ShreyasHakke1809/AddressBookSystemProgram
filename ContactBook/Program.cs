namespace ContactBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book System");
            AddressBookSystem address = new AddressBookSystem();
            bool loopAgain = true;
            while (loopAgain)
            {
                Console.WriteLine("n1.Add new contact\n2.Add new address book\n3.Display Address book\n4.Edit contact\n5.Delete Contact\n" +
                    "6.Search contact by city or state\n7.View person by city or state\n8.Get city or state count\n9.Sort the entries in the address book alphabetically by Person’s name" +
                    "\n10.Sort the entries in the address book by City,State or Zip\n11.Write or read to .txt File");
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
                        address.SearchByCityOrState();
                        break;
                    case 7:
                        address.ViewByCityOrState();
                        break;
                    case 8:
                        int citycount = address.GetContactCountByCity();
                        int statecount = address.GetContactCountByState();
                        break;
                    case 9:
                        address.SortAddressBookByName();
                        break;
                    case 10:
                        address.SortAddressBookByCity();
                        address.SortAddressBookByState();
                        address.SortAddressBookByZip();
                        break;
                    case 11:
                        address.WriteToTextFile();
                        address.ReadFromTextFile();
                        break;
                    case 12:
                        loopAgain = false;
                        break;

                }
            }
        }
    }
}
