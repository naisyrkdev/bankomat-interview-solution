namespace Domain.Entities
{
    public class Banknot
    {
        public int BanknotId { get; set; }

        public int BankomatId { get; set; }

        public Bankomat Bankomat { get; set; }

        public int BanknotValue { get; set; }

        public int Amount { get; set; }
    }
}
