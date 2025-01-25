using Android.Content.PM;

namespace OneMoneyCloneClient.App;

public class BaseActivity : Activity
{
	protected override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		RequestedOrientation = ScreenOrientation.Portrait;
	}
}