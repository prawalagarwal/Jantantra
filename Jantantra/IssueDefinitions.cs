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

namespace Jantantra
{
    public class Issue
    {
        public string title;
        public string summary;
        public string comments;
        public int votes;
        
        public string Title
        {
            get { return title; }
        }

        public string Summary
        {
            get { return summary; }
        }

        public string Comments
        {
            get { return comments; }
        }
        public int Votes
        {
            get { return votes; }
        }
    }

    public class IssueCollection
    {
        static Issue[] prePopulatedIssues =
        {
            new Issue{title = "Drainage Issue", summary = "Critical drainage issue faced at Ashok Vihar.", votes = 254, comments = "Comments"},
            new Issue{title = "Potholes on roads", summary = "Citizens struggling to make their way through the several potholes in Gautami Enclave", votes = 116, comments = "Comments"},
            new Issue{title = "No Water!", summary = "Water supply affeted in Kondapur", votes = 75, comments = "Comments"},
            new Issue{title = "VAT issues", summary = "Shopkeepers still chargin service tax on certain items in Gachibowli", votes = 44, comments = "Comments"},
            new Issue{title = "Drainage Issue", summary = "Critical drainage issue faced at Ashok Vihar.", votes = 32, comments = "Comments"},
            new Issue{title = "Potholes on roads", summary = "Citizens struggling to make their way through the several potholes in Gautami Enclave", votes = 11, comments = "Comments"},
        };

        internal Issue[] issues;

        public IssueCollection()
        {
            issues = prePopulatedIssues;
            
        }
    }
}