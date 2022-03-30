using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Library
{
    public class Card
    {
        private string cardName;

        public string CardName
        {
            get { return cardName; }
        }

        private string pinCode;

        public string PinCode
        {
            get { return pinCode; }
        }

        private Account account;

        public Account Linked_Account
        {
            get { return account; }
        }



        public Card()
        {

        }

        public Card(string cardName, string pinCode, Account linked_account)
        {
            this.cardName = cardName;
            this.pinCode = pinCode;
            this.account = linked_account;
        }
    }
}
