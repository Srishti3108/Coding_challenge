using System;
namespace Insurance_Management_System
{
    internal class Payment
    {
        private int paymentId;
        private DateTime paymentDate;
        private double paymentAmount;
        private string client;


        public Payment()
        {
            paymentId = 0;
            paymentDate = DateTime.Now;
            paymentAmount = 0.0;
            client = "default";
        }


        public Payment(int paymentId, DateTime paymentDate, double paymentAmount, string client)
        {
            this.paymentId = paymentId;
            this.paymentDate = paymentDate;
            this.paymentAmount = paymentAmount;
            this.client = client;
        }


        public int PaymentId
        {
            get { return paymentId; }
            set { paymentId = value; }
        }

        public DateTime PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }

        public double PaymentAmount
        {
            get { return paymentAmount; }
            set { paymentAmount = value; }
        }

        public string Client
        {
            get { return client; }
            set { client = value; }
        }
        public override string ToString()
        {
            return $"PaymentId: {paymentId}, PaymentDate: {paymentDate.ToShortDateString()}, PaymentAmount: {paymentAmount}, Client: {client}";
        }
    }
}
