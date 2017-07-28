using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace Jantantra
{   

    public class ActivityViewHolder : RecyclerView.ViewHolder
    { 
        public TextView Title { get; private set; }
        public TextView Summary { get; private set; }
        public TextView Comments { get; private set; }
        public TextView Votes { get; private set; }


        public ActivityViewHolder(View itemView, Action<int> listener)
            : base(itemView)
        {
            Title = itemView.FindViewById<TextView>(Resource.Id.issueTitle);
            Summary = itemView.FindViewById<TextView>(Resource.Id.issueSummary);
            Comments = itemView.FindViewById<TextView>(Resource.Id.issueComments);
            Votes = itemView.FindViewById<TextView>(Resource.Id.issueVotes);

            // Detect user clicks on the item view and report which item
            // was clicked (by position) to the listener:
            if (listener != null)
            {
                itemView.Click += (sender, e) => listener(base.Position);
            }
        }
    }
}