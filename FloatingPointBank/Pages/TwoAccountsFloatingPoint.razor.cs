using Microsoft.AspNetCore.Components;

namespace FloatingPointBank.Pages;

public partial class TwoAccountsFloatingPoint: ComponentBase
{
    
    [Parameter]
    public EventCallback OnClick { get; set; }

    [Parameter]
    public Func<float> GetTransferAmount { get; set; }
    
    protected void HandleClick()
    {
        Transfer(GetTransferAmount());
        if (OnClick.HasDelegate)
        {
            OnClick.InvokeAsync();
        }
    }
    private const float _originalSavingsBalance = 1000000f;
    public float OriginalSavingsBalance => _originalSavingsBalance;
    
    [Parameter]
    public float SavingsBalance { get; set; } = _originalSavingsBalance;
    
    [Parameter]
    public float CheckingBalance { get; set; } = 0f;

    public double TotalBalance
    {
        get => (double)SavingsBalance + CheckingBalance;
    }

    public float VanishingTransferAmount() => float.BitIncrement((SavingsBalance - float.BitDecrement(SavingsBalance))/2);
    

    public float GrowingTransferAmount() => float.BitDecrement((SavingsBalance - float.BitDecrement(SavingsBalance)) / 2);

    public double BurnedMoney
    {
        get => (double)OriginalSavingsBalance - TotalBalance;
    }

    public string color => TotalBalance == OriginalSavingsBalance ? "black": "red";

    public void Transfer(float amount)
    {
        SavingsBalance -= amount;
        CheckingBalance += amount;
    }
}