using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using PokeDex.Resources.ResourceFiles;

namespace PokeDex.FrontEnd.Layout;

public partial class NavMenu
{
    [Inject] private IJSRuntime JS { get; set; } = default!;
    [Inject] private NavigationManager Navigation { get; set; } = default!;

    private readonly NavBuilder navBuilder = new();
    private string currentTheme = "system";

    private readonly List<ThemeOption> themes =
    [
        new() { Value = "system", Label = "System" },
        new() { Value = "light", Label = "Light" },
        new() { Value = "dark", Label = "Dark" }
    ];

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            currentTheme = await JS.InvokeAsync<string>("themeManager.get");
            StateHasChanged();
        }
    }

    private async Task OnThemeChanged(ThemeOption selected)
    {
        await JS.InvokeVoidAsync("themeManager.set", selected.Value);
    }
}

public class ThemeOption
{
    public string Value { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
}

public class NavBuilder
{
    public List<NavItem> Items { get; private set; }

    public NavBuilder()
    {
        Items =
        [
            new NavItem { Title = CommonResources.Home, Href = "/" },
            new NavItem { Title = CommonResources.PokeDex, Href = "/PokeDex" },
            new NavItem { Title = CommonResources.Items, Href = "/Items" },
            new NavItem { Title = CommonResources.Map, Href = "/Map" },
            new NavItem { Title = CommonResources.Map, Href = "/Map" },
        ];
    }
}

public class NavItem
{
    public string Title { get; set; } = string.Empty;
    public string Href { get; set; } = string.Empty;
    public NavLinkMatch Match { get; set; } = NavLinkMatch.All;
}