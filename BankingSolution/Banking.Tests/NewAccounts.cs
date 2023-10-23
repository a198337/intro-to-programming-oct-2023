
using Banking.Domain;

namespace Banking.Tests;
public class NewAccounts
{
    [Fact]
    public void NewAccountsHaveCorrectOpeningBalance()
    {
        //Given - I have a new account
        Account account = new Account();

        //When I ask it for it's balance
        decimal openingBalance = account.GetBalance();

        //then it is 5k bucks (decimal)
        Assert.Equal(5000M, openingBalance);
    }
}
