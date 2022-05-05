namespace Student.Microservice.Application.ViewModel
{
    public class CreatedAccountEventViewModel
    {
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public bool IsThirdParty { get; set; }
        public string ThirdPartyProvider { get; set; }
    }
}
