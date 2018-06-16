using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Support.V7.App;
using System.Linq;
using System.Threading.Tasks;


namespace Boodschapp_PO4
{
    [Activity(Label = "boodschapp", MainLauncher = false, Theme = "@style/AppTheme")]
    public class explainScreen : Activity
    {
        TextView Uitleg;
        Switch Switch1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.explainScreen);
            Uitleg = FindViewById<TextView>(Resource.Id.uitleg);

            //Uitleg.Text = "dit is een stuk voorbeeld text, ik neuk jullie allemaal de moeder";

            Switch1.CheckedChange += Switch1_CheckedChange;
        }

        void Switch1_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            int cnt = 0;
            if (e.IsChecked)
            {
                cnt = cnt++;
                    Uitleg.Text = $"anus{cnt}";
            }
        }

    }
}
