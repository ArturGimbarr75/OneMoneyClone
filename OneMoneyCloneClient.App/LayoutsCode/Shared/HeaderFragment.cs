using Android.Views;

namespace OneMoneyCloneClient.App.LayoutsCode.Shared;
internal class HeaderFragment : Fragment
{
	private ImageButton _leftButton = default!;
	private TextView _titleText = default!;
	private TextView _balanceText = default!;
	private ImageButton _rightButton = default!;

	public string TitleText { get; set; } = "All accounts";
	public string BalanceText { get; set; } = "EUR 216.86";

	public Action? LeftButtonAction { get; set; }
	public Action? RightButtonAction { get; set; }

	public override View OnCreateView(LayoutInflater? inflater, ViewGroup? container, Bundle? savedInstanceState)
	{
		var view = inflater?.Inflate(Resource.Layout.fragment_header, container, false)!;

		_leftButton = view.FindViewById<ImageButton>(Resource.Id.headerLeftButton)!;
		_titleText = view.FindViewById<TextView>(Resource.Id.headerTitleText)!;
		_balanceText = view.FindViewById<TextView>(Resource.Id.headerBalanceText)!;
		_rightButton = view.FindViewById<ImageButton>(Resource.Id.headerRightButton)!;

		_titleText.Text = TitleText;
		_balanceText.Text = BalanceText;

		_leftButton.Click += (sender, args) => LeftButtonAction?.Invoke();
		_rightButton.Click += (sender, args) => RightButtonAction?.Invoke();

		return view;
	}

	public void UpdateCenterText()
	{
		TitleText = "All accounts";
		BalanceText = "EUR 216.86";
		_titleText.Text = TitleText;
		_balanceText.Text = BalanceText = "EUR 216.86";
	}
}
