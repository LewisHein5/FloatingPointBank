using System.Numerics;
using Microsoft.AspNetCore.Components;

namespace FloatingPointBank.Pages;

public partial class BankAccount<TBalance>(TBalance balance) : ComponentBase
    where TBalance : INumber<TBalance>
{
    //[Parameter] public AccountUpdateService<TBalance> UpdateService { get; set; }
    [Parameter]
    public TBalance Balance { get; set; } = balance;

    public BankAccount() : this(TBalance.Zero)
    {
        //if (UpdateService != null)
          //  UpdateService.TransferEvent += Transfer;
    }


    //public float GrowingTransferAmount() => float.BitDecrement((Balance - float.BitDecrement(Balance)) / 2);*/

    private void Transfer(TBalance amount)
    {
        Balance += amount;
        InvokeAsync(StateHasChanged);
    }

    public void Transfer(TBalance amount, BankAccount<TBalance> other)
    {
        Transfer(-amount);
        other.Transfer(amount);
    }
}