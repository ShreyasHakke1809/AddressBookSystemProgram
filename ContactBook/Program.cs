namespace ContactBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book System");
            AddressBookSystem address = new AddressBookSystem();
            address.AddContact("Shreyas", "Hakke", "Kavalapur", "Miraj", "Maharashtra", "416306", "9673215173", "shreyashakke1809@gmail.com");
            Console.WriteLine("-----------");
            address.DisplayContacts();
        }


    }
}