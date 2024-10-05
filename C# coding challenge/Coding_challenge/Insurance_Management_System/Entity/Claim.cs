using System;
namespace Insurance_Management_System.Entity
{
    internal class Claim
    {
   
        private int claimId;
        private string claimNumber;
        private DateTime dateFiled;
        private double claimAmount;
        private string status;
        private string policy;
        private string client;

    
        public Claim()
        {
            claimId = 0;
            claimNumber = "default";
            dateFiled = DateTime.Now;
            claimAmount = 0.0;
            status = "Pending";
            policy = "default";
            client = "default";
        }

   
        public Claim(int claimId, string claimNumber, DateTime dateFiled, double claimAmount, string status, string policy, string client)
        {
            this.claimId = claimId;
            this.claimNumber = claimNumber;
            this.dateFiled = dateFiled;
            this.claimAmount = claimAmount;
            this.status = status;
            this.policy = policy;
            this.client = client;
        }

  
        public int ClaimId
        {
            get { return claimId; }
            set { claimId = value; }
        }

        public string ClaimNumber
        {
            get { return claimNumber; }
            set { claimNumber = value; }
        }

        public DateTime DateFiled
        {
            get { return dateFiled; }
            set { dateFiled = value; }
        }

        public double ClaimAmount
        {
            get { return claimAmount; }
            set { claimAmount = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Policy
        {
            get { return policy; }
            set { policy = value; }
        }

        public string Client
        {
            get { return client; }
            set { client = value; }
        }

   
        public override string ToString()
        {
            return $"ClaimId: {claimId}, ClaimNumber: {claimNumber}, DateFiled: {dateFiled.ToShortDateString()}, " +
                   $"ClaimAmount: {claimAmount}, Status: {status}, Policy: {policy}, Client: {client}";
        }
    }
}