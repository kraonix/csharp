using NUnit.Framework;
using BankAccountApp;
using System;

namespace BankAccountApp.Tests
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void Test_Deposit_ValidAmount()
        {
            Program acc = new Program(1000);
            acc.Deposit(500);

            Assert.That(acc.Balance, Is.EqualTo(1500));
        }

        [Test]
        public void Test_Deposit_NegativeAmount()
        {
            Program acc = new Program(1000);

            var ex = Assert.Throws<Exception>(() => acc.Deposit(-100));
            Assert.That(ex.Message, Is.EqualTo("Deposit amount cannot be negative"));
        }

        [Test]
        public void Test_Withdraw_ValidAmount()
        {
            Program acc = new Program(1000);
            acc.Withdraw(400);

            Assert.That(acc.Balance, Is.EqualTo(600));
        }

        [Test]
        public void Test_Withdraw_InsufficientFunds()
        {
            Program acc = new Program(500);

            var ex = Assert.Throws<Exception>(() => acc.Withdraw(800));
            Assert.That(ex.Message, Is.EqualTo("Insufficient funds."));
        }
    }
}
