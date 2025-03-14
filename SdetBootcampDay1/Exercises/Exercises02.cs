using NUnit.Framework;
using SdetBootcampDay1.TestObjects;

namespace SdetBootcampDay1.Exercises
{
    [TestFixture]
    public class Exercises02
    {
        /**
         * TODO: rewrite these three tests into a single, parameterized test.
         * You decide if you want to use [TestCase] or [TestCaseSource], but
         * I would like to know why you chose the option you chose afterwards.
         */
        [TestCase(100,50,50, TestName = "Deposit 100 Withdraw 50 and balance is 50")]
        [TestCase(1000,1000,0, TestName = "Deposit 1000 Withdraw 1000 and balance is 0")]
        [TestCase(250,1,249, TestName = "Deposit 250 Withdraw 1 and balance is 249")]
        public void CreateNewSavingsAccount_DepositWithdrawBalance(int deposit, int withdraw, int balance)
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(deposit);
            account.Withdraw(withdraw);

            Assert.That(account.Balance, Is.EqualTo(balance));
        }

        // [Test]
        // public void CreateNewSavingsAccount_Deposit1000Withdraw1000_BalanceShouldBe0()
        // {
        //     var account = new Account(AccountType.Savings);

        //     account.Deposit(1000);
        //     account.Withdraw(1000);

        //     Assert.That(account.Balance, Is.EqualTo(0));
        // }

        // [Test]
        // public void CreateNewSavingsAccount_Deposit250Withdraw1_BalanceShouldBe249()
        // {
        //     var account = new Account(AccountType.Savings);

        //     account.Deposit(250);
        //     account.Withdraw(1);

        //     Assert.That(account.Balance, Is.EqualTo(249));
        // }
    }
}
