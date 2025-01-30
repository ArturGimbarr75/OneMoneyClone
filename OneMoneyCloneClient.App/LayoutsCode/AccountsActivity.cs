using OneMoneyCloneClient.App.LayoutsCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMoneyCloneClient.App.LayoutsCode;

[Activity(Label = "Accounts")]
internal class AccountsActivity : Activity
{
	protected override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		SetContentView(Resource.Layout.activity_accounts);

		var navigationFragment = new NavigationFragment();
		SupportFragmentManager.BeginTransaction()
			.Replace(Resource.Id.navigationFragmentContainer, navigationFragment)
			.Commit();
	}
}
