using System.Collections.Concurrent;
using System.Numerics;
using FloatingPointBank.Pages;

namespace FloatingPointBank.Services;

public delegate void TransferEventHandler();

public class AccountUpdateService<TBalance> where TBalance: INumber<TBalance>
{
    public event TransferEventHandler TransferEvent;
    public readonly ConcurrentDictionary<BankAccount<TBalance>, TBalance> TransferAmounts = new();

    public void Transfer(BankAccount<TBalance> dstAccount, TBalance amount)
    {
        TransferAmounts.AddOrUpdate(dstAccount, _ => amount, (_, _) => amount);
        TransferEvent?.Invoke();
    }

    public void Transfer(BankAccount<TBalance> srcAccount, BankAccount<TBalance> dstAccount, TBalance amount)
    {
        Transfer(srcAccount, -amount);
        Transfer(dstAccount, amount);
    }
}