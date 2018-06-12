using Android.App;
using System.Linq;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System;
using PCLStorage;
using System.Threading.Tasks;
using Android.Content;
using System.IO;

namespace Boodschapp_PO4
{
    public class person 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    [Activity(Label = "boodschapp", MainLauncher = false, Theme = "@style/AppTheme")]
    public class GrocerylistActivity : Activity
    {
        Button              button, buttonDemi, savebutton;
        List<string>        mItems = new List<string>();

        ListView            mListView;
        EditText            editText1;
        ListviewAdapter     adapter;

        string fullPath = Path.Combine(
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments),
             "anushaar.txt");
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GrocerylistLayout);

            button      = FindViewById<Button>(Resource.Id.button1);
            buttonDemi  = FindViewById<Button>(Resource.Id.demi);
            savebutton = FindViewById<Button>(Resource.Id.savebutton);
            mListView   = FindViewById<ListView>(Resource.Id.mylistView);

            adapter             = new ListviewAdapter(this, mItems);
            mListView.Adapter   = adapter;

            button.Click        += Button_Click;
            mListView.ItemClick += MListView_ItemClick;
            buttonDemi.Click    += ButtonDemi_Click;
            savebutton.Click += Savebutton_Click;




            try
            {
                var storedjson1 = File.ReadAllText(fullPath);
                var newinstance1 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(storedjson1);
                if (newinstance1.Any())
                {
                    foreach (var v in newinstance1)
                    {
                        Console.WriteLine(v);
                        mItems.Add(v);
                        adapter.NotifyDataSetChanged();

                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("error: empty list" + e);
            }

        }



        void Button_Click(object sender, System.EventArgs e)
        {
            editText1 = FindViewById<EditText>(Resource.Id.editText1);

            var currentvar1 = editText1.Text;


            if (currentvar1 != "")
            {
                mItems.Add(currentvar1);
                adapter.NotifyDataSetChanged();
                editText1.Text = "";
                string jsonoutput = Newtonsoft.Json.JsonConvert.SerializeObject(mItems, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(fullPath, jsonoutput);
            }


            if (currentvar1 == "")
            {
                
            }


        }

        void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            mItems.Remove(mItems[e.Position]);
            adapter.NotifyDataSetChanged();
            string jsonoutput = Newtonsoft.Json.JsonConvert.SerializeObject(mItems, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(fullPath, jsonoutput);
        }

        void ButtonDemi_Click(object sender, EventArgs e)
        {
            var demiIntent = new Intent(this, typeof(BrowsingScreen1Activity));

            //demiIntent.PutExtra("lijst", mItems.ToArray());

            StartActivity(demiIntent);
        }


        void Savebutton_Click(object sender, EventArgs e)
        {
            var storedjson = File.ReadAllText(fullPath);
            var newinstance = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(storedjson);
            foreach (var v in newinstance)
            {
                mItems.Add(v);
                adapter.NotifyDataSetChanged();

            }
        }

    }
}