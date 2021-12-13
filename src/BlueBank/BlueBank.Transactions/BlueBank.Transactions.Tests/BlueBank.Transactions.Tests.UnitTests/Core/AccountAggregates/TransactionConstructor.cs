using BlueBank.Transactions.Core.AccountAggregates;
using System;
using Xunit;

namespace BlueBank.Transactions.Tests.UnitTests.Core.CustomerAggregates
{
    public class TransactionConstructor
    {
        [Fact]
        public void ThrowsExceptionGivenNegativeAmountArgument()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Transaction(-1, TransactionType.Credit));
        }

        [Fact]
        public void ThrowsExceptionGivenZeroAmountArgument()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Transaction(0, TransactionType.Credit));
        }
    }
}
