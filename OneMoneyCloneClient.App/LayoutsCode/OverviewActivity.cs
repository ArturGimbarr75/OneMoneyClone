using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMoneyCloneClient.App.LayoutsCode;

[Activity(Label = "Overview")]
internal class OverviewActivity : Activity
{
	protected override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		SetContentView(Resource.Layout.activity_overview);
	}
}

