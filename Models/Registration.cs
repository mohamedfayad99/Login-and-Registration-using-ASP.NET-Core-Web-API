namespace LoginRegistration.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string BPhoneNumber { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

  
        public string ConfirmPassword { get; set; }

    }
}
