using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Boodschapp_PO4
{
    public class BrowsingViewHolder : RecyclerView.ViewHolder
    {
        public TextView Category        { get; private set; }
        public TextView Group           { get; private set; }
        public TextView Name            { get; private set; }
        public ImageView BrowseImage    { get; private set; }

        public BrowsingViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            Category    = itemView.FindViewById<TextView>(Resource.Id.categoryView);
            Group       = itemView.FindViewById<TextView>(Resource.Id.groupView);
            Name        = itemView.FindViewById<TextView>(Resource.Id.productView);
            BrowseImage = itemView.FindViewById<ImageView>(Resource.Id.browsingimageView);

            itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
}