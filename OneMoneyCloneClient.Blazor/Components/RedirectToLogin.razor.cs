/*using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace OneMoneyCloneClient.Blazor.Components;

public partial class RedirectToLogin
{
	[Inject] private NavigationManager Navigation { get; set; } = default!;
	[Inject] private AuthenticationStateProvider AuthStateProvider { get; set; } = default!;

	protected override async Task OnInitializedAsync()
	{
		var authState = await AuthStateProvider.GetAuthenticationStateAsync();
		var user = authState.User;

		if (!user.Identity!.IsAuthenticated)
		{
			Navigation.NavigateTo("/login", true);
		}
	}
}
*/