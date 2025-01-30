using Android.Content;
using Android.Content.PM;
using OneMoneyCloneClient.App.LayoutsCode;

namespace OneMoneyCloneClient.App;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : BaseActivity
{
	protected override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		RequestedOrientation = ScreenOrientation.Portrait;
		int defaultLayoutId = GetDefaultLayoutId();
		SetContentView(defaultLayoutId);
		ActionBar?.Hide();
	}

	private int GetDefaultLayoutId()
	{
		// TODO: Implement this method, make oportunity to select default layout
		return Resource.Layout.activity_accounts;
	}
}
