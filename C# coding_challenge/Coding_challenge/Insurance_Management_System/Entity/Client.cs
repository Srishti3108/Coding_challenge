using System;
namespace Insurance_Management_System.Entity
{
    internal class Client
    {

        private int clientId;
        private string clientName;
        private string contactInfo;
        private string policy;


        public Client()
        {
            clientId = 0;
            clientName = "default";
            contactInfo = "default";
            policy = "default";
        }


        public Client(int clientId, string clientName, string contactInfo, string policy)
        {
            this.clientId = clientId;
            this.clientName = clientName;
            this.contactInfo = contactInfo;
            this.policy = policy;
        }


        public int ClientId
        {
            get { return clientId; }
            set { clientId = value; }
        }

        public string ClientName
        {
            get { return clientName; }
            set { clientName = value; }
        }

        public string ContactInfo
        {
            get { return contactInfo; }
            set { contactInfo = value; }
        }

        public string Policy
        {
            get { return policy; }
            set { policy = value; }
        }


        public override string ToString()
        {
            return $"ClientId: {clientId}, ClientName: {clientName}, ContactInfo: {contactInfo}, Policy: {policy}";
        }
    }

}