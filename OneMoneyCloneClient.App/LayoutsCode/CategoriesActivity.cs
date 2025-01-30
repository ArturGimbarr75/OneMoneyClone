using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMoneyCloneClient.App.LayoutsCode;

[Activity (Label = "Categories")]
internal class CategoriesActivity : Activity
{
	protected override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		SetContentView(Resource.Layout.activity_categories);
	}
}
