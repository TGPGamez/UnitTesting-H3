using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Library
{
    public class ATM_Machine
    {
        private Card inserted_Card;

        public void InsertCard(Card card)
        {
            inserted_Card = card;
        }

        public void PullOutCard()
        {
            inserted_Card = null;
        }


        /// <summary>
        /// Check if the card pincode is the entered code
        /// </summary>
        /// <param name="card_Pincode"></param>
        /// <param name="compare_Pincode"></param>
        /// <returns></returns>
        public bool ValidatePincodeWithCard(string compare_Pincode)
        {
            if (!HasCardInserted())
            {
                return false;
            }
            //Check if card pincode or compare pincode is null or whitespace only
            if (string.IsNullOrWhiteSpace(inserted_Card.PinCode)
                || string.IsNullOrWhiteSpace(compare_Pincode))
            {
                return false;
            }
            // Compare the two strings
            return inserted_Card.PinCode.Equals(compare_Pincode);
        }

        /// <summary>
        /// Deposit money to an card account
        /// </summary>
        /// <param name="card"></param>
        /// <param name="amount"></param>
        public void DepositToAccount(Card card, double amount)
        {
            if (HasCardInserted())
            {
                //Check if amount is not under 0
                if (amount > 0)
                {
                    card.Linked_Account.Deposit(amount);
                }
            }
        }

        /// <summary>
        /// Withdraw money from an card account
        /// </summary>
        /// <param name="card"></param>
        /// <param name="amount"></param>
        public void WithdrawFromAccount(Card card, double amount)
        {
            if (HasCardInserted())
            {
                //Check if amount is not under 0
                if (amount > 0)
                {
                    if (card.Linked_Account.Balance >= amount)
                    {
                        card.Linked_Account.Withdraw(amount);
                    }
                }
            }
        }

        private bool HasCardInserted()
        {
            return inserted_Card != null && inserted_Card.Linked_Account != null;
        }
    }
}
