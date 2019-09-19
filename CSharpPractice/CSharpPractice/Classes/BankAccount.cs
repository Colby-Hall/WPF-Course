using CSharpPractice.Interfaces;

namespace CSharpPractice.Classes
{
    public class BankAccount : IInformation
    {
        private double balance;
        public double Balance
        {
            get
            {
                if (balance < 1000000)
                    return balance;
                return 1000000;
            }
            // protected = accessible from current or inherited classes
            protected set
            {
                if (value > 0)
                    balance = value;
                else
                    balance = 0;
            }
        }
        /* propfull snippet shortcut
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }
        */

        public BankAccount()
        {
            Balance = 100;
        }

        // constructor overload
        public BankAccount(double initialBalance)
        {
            Balance = initialBalance;
        }




        // method overriding , virtual = overrideable
        public virtual double AddToBalance(double balanceToBeAdded)
        {
            Balance += balanceToBeAdded;
            return Balance;
        }

        public string GetInformation()
            //:c is a fast way to format as currency
        {
            return $"Your current balance is: {Balance:c}";
        }
    }

    //inheritance
    public class ChildBankAccount : BankAccount
    {
        public ChildBankAccount()
        {
            Balance = 10;
        }

        // override snippet
        public override double AddToBalance(double balanceToBeAdded)
        {
            // base refers to BankAccount class, originator class of function
            // use base method unless certain conditions met, for example
            if (balanceToBeAdded > 1000)
                balanceToBeAdded = 1000;
            if (balanceToBeAdded < -1000)
                balanceToBeAdded = -1000;
            return base.AddToBalance(balanceToBeAdded);
        }
    }
}