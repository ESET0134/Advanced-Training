using Microsoft.AspNetCore.Components;
namespace First_Blazor.Components.Pages
{
    public class IndexBase : ComponentBase
    {
        public string Text { get; set; } = "Click Me!";
        protected void ChangeText()
        {
            if (Text == "Click Me!")
            {
                Text = "You clicked the button!";
            }
        }
    }
}
