using System.Collections.Concurrent;
using System.Numerics;
using FloatingPointBank.Pages;

namespace FloatingPointBank.Services;

public delegate void TransferEventHandler<TBalance>(BankAccount<TBalance> dstAccount, TBalance amount) where TBalance: INumber<TBalance>;

public delegate void BalanceChangedHandler();

public class AccountUpdateService<TBalance> where TBalance: INumber<TBalance>
{
    public event TransferEventHandler<TBalance> TransferEvent;
    public event BalanceChangedHandler BalanceChangedEvent;
    public readonly ConcurrentBag<BankAccount<TBalance>> Accounts = new();

    public void Transfer(BankAccount<TBalance> dstAccount, TBalance amount)
    {
        TransferEvent?.Invoke(dstAccount, amount); //TODO isn't there a better way to do this 
    }

    public void Transfer(BankAccount<TBalance> srcAccount, BankAccount<TBalance> dstAccount, TBalance amount)
    {
        Transfer(srcAccount, -amount);
        Transfer(dstAccount, amount);
    }

    public void BalanceChanged()
    {
        BalanceChangedEvent?.Invoke(); //todo race condition?
    }
}