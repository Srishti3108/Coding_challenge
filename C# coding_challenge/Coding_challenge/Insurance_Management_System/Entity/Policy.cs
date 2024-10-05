using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Management_System.Entity
{
    internal class Policy
    {
        private int policyId;
        private string policyName;
        private string policyDetails;
        private double premiumAmount;
        private int clientId;

        // Default constructor
        public Policy()
        {
            policyId = 0;
            policyName = "default";
            policyDetails = "default";
            premiumAmount = 0.0;
            clientId = 0;
        }

        // Parameterized constructor
        public Policy(int policyId, string policyName, string policyDetails, double premiumAmount, int clientId)
        {
            this.policyId = policyId;
            this.policyName = policyName;
            this.policyDetails = policyDetails;
            this.premiumAmount = premiumAmount;
            this.clientId = clientId;
        }

        // Getters and Setters
        public int PolicyId
        {
            get { return policyId; }
            set { policyId = value; }
        }

        public string PolicyName
        {
            get { return policyName; }
            set { policyName = value; }
        }

        public string PolicyDetails
        {
            get { return policyDetails; }
            set { policyDetails = value; }
        }

        public double PremiumAmount
        {
            get { return premiumAmount; }
            set { premiumAmount = value; }
        }

        public int ClientId
        {
            get { return clientId; }
            set { clientId = value; }
        }

        // ToString method to display object information
        public override string ToString()
        {
            return $"PolicyId: {policyId}, PolicyName: {policyName}, PolicyDetails: {policyDetails}, " +
                   $"PremiumAmount: {premiumAmount}, ClientId: {clientId}";
        }
    }
}

