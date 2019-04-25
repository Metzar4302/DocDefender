namespace DocDefender
{
    public class Transaction
    {
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public float Amount { get; set; }

        public Transaction(string sender, string recipient, float amount){
            this.Sender = sender;
            this.Recipient = recipient;
            this.Amount = amount;
        }

        public override string ToString(){
            return $"{Sender}-{Recipient}:{Amount}";
        }
    }
}