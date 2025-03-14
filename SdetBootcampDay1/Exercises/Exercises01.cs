using NUnit.Framework;
using SdetBootcampDay1.TestObjects;

namespace SdetBootcampDay1.Exercises
{
    [TestFixture]
    public class Exercises01
    {
        [Test]
        public void GivenANewCheckingAccount_WhenIDeposit200_ThenBalanceShouldBe200()
        {
            var account = new Account(AccountType.Checking);

            account.Deposit(200);

            Assert.That(account.Balance, Is.EqualTo(200));

            Assert.That(account.Balance, Is.GreaterThan(199));
    
        }

        [Test]
        public void GivenANewSavingsAccount_WhenIDeposit200AndWithdraw100_ThenBalanceShouldBe100()
        {
       
            var account = new Account(AccountType.Savings);

            account.Deposit(200);
            account.Withdraw(100);

            Assert.That(account.Balance, Is.EqualTo(100));
    
        }
        [Test]
        public void GivenANewCheckingAccount_WhenIDeposit100AndWithdraw200_ThenBalanceShouldBeMinus100()
        {
            var account = new Account(AccountType.Checking);

            account.Deposit(100);
            account.Withdraw(200);

             Assert.That(account.Balance, Is.EqualTo(-100));
        }

    }
}
