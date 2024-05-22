namespace TestFluentValidation.Models
{
    public class Library
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Book> Books { get; set; }
    }
}
