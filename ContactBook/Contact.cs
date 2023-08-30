namespace ContactBook
{
    public class Contact
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }

        public override string ToString()
        {
            return $"First Name:{firstName},Last Name:{lastName},Address:{address},City:{city},State:{state},Zip:{zip},Phone Number:{phoneNumber},Email:{email}";
        }

    }
}
