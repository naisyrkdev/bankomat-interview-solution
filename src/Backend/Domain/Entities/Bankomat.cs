namespace Domain.Entities
{
    public class Bankomat
    {
        public int BankomatId { get; set; }

        public List<Banknot> Banknots { get; set; }
    }
}
