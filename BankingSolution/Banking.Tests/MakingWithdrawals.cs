
using Banking.Domain;

namespace Banking.Tests;
public class MakingWithdrawals
{
    [Theory]
    [InlineData(123.23)]
    [InlineData(7000)]
    [InlineData(-200)]
    public void MakingWithdrawalsDecreasesBalance(decimal amountToWithdraw)
    {
        var account = new Account();
        var openingBalance = account.GetBalance();

        account.Withdraw(amountToWithdraw);

        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
    }

    [Fact]
    public void OverdraftNotAllowed()
    {
        var account = new Account();
        var openingBalance = account.GetBalance();

        account.Withdraw(openingBalance + 0.01M);

        Assert.Equal(openingBalance, account.GetBalance());
    }

    public void CanTakeFullBalance()
    {
        var account = new Account();

        account.Withdraw(account.GetBalance());

        Assert.Equal(0, account.GetBalance());
    }
}
