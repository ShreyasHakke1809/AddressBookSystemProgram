namespace ContactBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book System");
            AddressBookSystem address = new AddressBookSystem();
            Console.WriteLine("\n1.Create contact\n2.Add new contact");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    address.AddContact("Shreyas", "Hakke", "Kavalapur", "Miraj", "Maharashtra", "416306", "9673215173", "shreyashakke1809@gmail.com");
                    Console.WriteLine("-----------");
                    address.DisplayContacts();
                    break;
                case 2:
                    address.AddNewContact();
                    break;
            }
          
        }
    }
}