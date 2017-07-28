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
    
    public class IssuesActivity : Activity
    {
        RecyclerView mRecyclerView;

        // Layout manager that lays out each card in the RecyclerView:
        RecyclerView.LayoutManager mLayoutManager;

        // Adapter that accesses the data set (a GivingCampaignActivity)
        GCActivityAdapter mAdapter;

        //ProgressDialog LoadingDialog;

        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);

            IssueCollection issueList = new IssueCollection(); 
            SetContentView(Resource.Layout.issueslist);

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            mAdapter = new GCActivityAdapter(issueList);
            mAdapter.ItemClick += OnItemClick;
            mRecyclerView.SetAdapter(mAdapter);
        }
        void OnItemClick(object sender, int position)
        {
            //var detailActivity = new Intent(this, typeof(EventDetailActivity));
            //detailActivity.PutExtra("Position", position);
            //StartActivityForResult(detailActivity, 1);
        }
    }

    // Adapter to connect the data set (photo album) to the RecyclerView: 
    public class GCActivityAdapter : RecyclerView.Adapter
    {
        // Event handler for item clicks:
        public event EventHandler<int> ItemClick;

        public IssueCollection issueCollection;

        public GCActivityAdapter (IssueCollection collection)
        {
            issueCollection = collection;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the photo:
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.issue_card_layout, parent, false);

            // Create a ViewHolder to find and hold these view references, and 
            // register OnClick with the view holder:
            ActivityViewHolder vh = new ActivityViewHolder(itemView, OnClick);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ActivityViewHolder vh = holder as ActivityViewHolder;

            
            vh.Title.Text = issueCollection.issues[position].Title;
            vh.Summary.Text = issueCollection.issues[position].Summary;
            vh.Votes.Text = issueCollection.issues[position].Votes.ToString() + " Votes";
            //vh.Comments.Text = issueCollection.issues[position].Comments;     
        }

        public override int ItemCount
        {
            get
            {
                return issueCollection.issues.Length;
            }
        }

        // Raise an event when the item-click takes place:
        void OnClick(int position)
        {
            if (ItemClick != null)
                ItemClick(this, position);
        }
    }

    
}