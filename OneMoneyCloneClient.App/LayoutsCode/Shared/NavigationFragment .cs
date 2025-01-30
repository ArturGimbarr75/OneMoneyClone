using Android.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMoneyCloneClient.App.LayoutsCode.Shared;
internal class NavigationFragment : Fragment
{
	public override View OnCreateView(LayoutInflater? inflater, ViewGroup? container, Bundle? savedInstanceState)
	{
		var view = inflater!.Inflate(Resource.Layout.fragment_navigation, container, false)!;

		var accountsButton = view.FindViewById<ImageButton>(Resource.Id.accountsButton)!;
		var categoriesButton = view.FindViewById<ImageButton>(Resource.Id.categoriesButton)!;
		var transactionsButton = view.FindViewById<ImageButton>(Resource.Id.transactionsButton)!;
		var budgetsButton = view.FindViewById<ImageButton>(Resource.Id.budgetsButton)!;
		var overviewButton = view.FindViewById<ImageButton>(Resource.Id.overviewButton)!;

		accountsButton.Click += (sender, args) =>
		{
			Toast.MakeText(Context, "Accounts clicked", ToastLength.Short)?.Show();
		};

		categoriesButton.Click += (sender, args) =>
		{
			Toast.MakeText(Context, "Categories clicked", ToastLength.Short)?.Show();
		};

		transactionsButton.Click += (sender, args) =>
		{
			Toast.MakeText(Context, "Transactions clicked", ToastLength.Short)?.Show();
		};

		budgetsButton.Click += (sender, args) =>
		{
			Toast.MakeText(Context, "Budgets clicked", ToastLength.Short)?.Show();
		};

		overviewButton.Click += (sender, args) =>
		{
			Toast.MakeText(Context, "Overview clicked", ToastLength.Short).Show();
		};

		return view;
	}
}
