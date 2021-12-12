namespace BlueBank.Accounts.Api.ApiModels
{
    public class CreateAccountDTO
    {
        public int CustomerId { get; set; }
        public decimal InitialCredit { get; set; }
    }
}
