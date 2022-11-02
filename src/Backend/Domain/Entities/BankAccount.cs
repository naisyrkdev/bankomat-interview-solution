namespace Domain.Entities
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int Balance { get; set; }
    }
}
