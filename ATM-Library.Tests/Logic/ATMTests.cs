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
        [InlineData("1325", true)]
        [InlineData("15123", false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        public void CheckPincodeShouldWork(string compare_Pincode, bool expected)
        {
            // Arrange 
            ATM_Machine atmMachine = new ATM_Machine();
            Card card = new Card("12512 123", "1325", new Account(10));

            // Act
            atmMachine.InsertCard(card);
            bool actual = atmMachine.ValidatePincodeWithCard(compare_Pincode);
            atmMachine.PullOutCard();

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
            
            atmMachine.InsertCard(card);
            atmMachine.DepositToAccount(card, deposit_amount);
            atmMachine.PullOutCard();

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

            atmMachine.InsertCard(card);
            atmMachine.WithdrawFromAccount(card, withdraw_amount);
            atmMachine.PullOutCard();

            double balance_after_withdraw = card.Linked_Account.Balance;

            // Assert
            Assert.True(balance_after_withdraw <= balance_before_withdraw);
        }

    }
}
