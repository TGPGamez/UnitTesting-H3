using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Library
{
    public class Account
    {
        private double balanace;

        public double Balance
        {
            get { return balanace; }
            private set { balanace = value; }
        }

        public Account()
        {

        }

        public Account(double balance)
        {
            this.balanace = balance;
        }

        public void Deposit(double amount)
        {
            this.balanace += amount;
        }

        public void Withdraw(double amount)
        {
            this.balanace -= amount;
        }
    }
}
