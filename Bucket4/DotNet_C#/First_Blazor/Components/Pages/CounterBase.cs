using Microsoft.AspNetCore.Components;
namespace First_Blazor.Components.Pages
{
    public class CounterBase : ComponentBase
    {
        protected int currentCount = 0;
        protected void IncrementCount()
        {
            currentCount++;
        }
    }
}
