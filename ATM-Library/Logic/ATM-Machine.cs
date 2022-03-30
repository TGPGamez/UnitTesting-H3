using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Library
{
    public class ATM_Machine
    {
        /// <summary>
        /// Check if the card pincode is the entered code
        /// </summary>
        /// <param name="card_Pincode"></param>
        /// <param name="compare_Pincode"></param>
        /// <returns></returns>
        public bool CheckCardPincode(string card_Pincode, string compare_Pincode)
        {
            //Check if card pincode is null or whitespace only
            if (string.IsNullOrWhiteSpace(card_Pincode))
            {
                return false;
            }
            // Check if entered pincode is null or whitespace only
            if (string.IsNullOrWhiteSpace(compare_Pincode))
            {
                return false;
            }
            // Compare the two strings
            return card_Pincode.Equals(compare_Pincode);
        }

        /// <summary>
        /// Deposit money to an card account
        /// </summary>
        /// <param name="card"></param>
        /// <param name="amount"></param>
        public void DepositToAccount(Card card, double amount)
        {
            //Check if amount is not under 0
            if (amount > 0)
            {
                card.Linked_Account.Deposit(amount);
            }
        }

        /// <summary>
        /// Withdraw money from an card account
        /// </summary>
        /// <param name="card"></param>
        /// <param name="amount"></param>
        public void WithdrawFromAccount(Card card, double amount)
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
}
