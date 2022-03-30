using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_Library;
using Xunit;

namespace ATM_Library.Tests
{
    public class ATMTests
    {
        [Theory]
        [InlineData("1325", "1325", true)]
        [InlineData("1000", "1325", false)]
        [InlineData("", "1325", false)]
        [InlineData("1325", "", false)]
        [InlineData("", " ", false)]
        public void CheckPincodeShouldWork(string card_Pincode, string compare_Pincode, bool expected)
        {
            // Arrange 
            ATM_Machine atmMachine = new ATM_Machine();

            // Act
            bool actual = atmMachine.CheckCardPincode(card_Pincode, compare_Pincode);

            // Assert
            Assert.Equal(expected, actual);

        }


        [Theory]
        [InlineData(50)]
        [InlineData(-50)]
        [InlineData(0)]
        public void DepositAmountToAccount(double deposit_amount)
        {
            // Arrange
            ATM_Machine atmMachine = new ATM_Machine();
            Card card = new Card("12341 23123", "1234", new Account(100));

            // Act
            double balance_before_deposit = card.Linked_Account.Balance;
            
            atmMachine.DepositToAccount(card, deposit_amount);

            double balance_after_deposit = card.Linked_Account.Balance;
            
            // Assert
            Assert.True(balance_after_deposit >= balance_before_deposit);
        }

        [Theory]
        [InlineData(50)]
        [InlineData(-50)]
        [InlineData(0)]
        public void WithdrawAmountFromAccount(double withdraw_amount)
        {
            // Arrange
            ATM_Machine atmMachine = new ATM_Machine();
            Card card = new Card("12341 23123", "1234", new Account(100));

            // Act
            double balance_before_withdraw = card.Linked_Account.Balance;

            atmMachine.WithdrawFromAccount(card, withdraw_amount);

            double balance_after_withdraw = card.Linked_Account.Balance;

            // Assert
            Assert.True(balance_after_withdraw <= balance_before_withdraw);
        }

    }
}
