using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Library
{
    public class ATM_Machine
    {
        public bool CheckCardPincode(string card_Pincode, string compare_Pincode)
        {
            if (string.IsNullOrWhiteSpace(card_Pincode))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(compare_Pincode))
            {
                return false;
            }
            return card_Pincode.Equals(compare_Pincode);
        }

        public void DepositToAccount(Card card, double amount)
        {
            if (amount > 0)
            {
                card.Linked_Account.Deposit(amount);
            }
        }

        public void WithdrawFromAccount(Card card, double amount)
        {
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
