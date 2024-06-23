using System.Numerics;
using FloatingPointBank.Pages;

namespace FloatingPointBank.Services;

public delegate void TransferEventHandler();

public class AccountUpdateService<TBalance> where TBalance: INumber<TBalance>
{
    public event TransferEventHandler TransferEvent;
    public TBalance TransferAmount = TBalance.Zero;

    public void Transfer(TBalance amount)
    {
        TransferAmount = amount;
        TransferEvent?.Invoke();
    }
}