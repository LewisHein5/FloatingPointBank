using Microsoft.AspNetCore.Components;

namespace FloatingPointBank.Pages;

public partial class IntegerBankBalance: ComponentBase
{
    
    [Parameter]
    public EventCallback OnClick { get; set; }

    protected void HandleClick()
    {
        AddDollar();
        if (OnClick.HasDelegate)
        {
            OnClick.InvokeAsync();
        }
    }
    
    public short CurrentBalance { get; set; } = short.MaxValue;

    public string Message => CurrentBalance > 0
        ? "Wow you have so many dollars. Let's add one more:"
        : "Oh no. That's not how banks work \ud83d\ude29";

    public string color => CurrentBalance > 0
        ? "black"
        : "red";

    public void AddDollar()
    {
        CurrentBalance++;
    }
}