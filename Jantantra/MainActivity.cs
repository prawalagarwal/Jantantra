using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Webkit;
using Android.Content;
using Xamarin.Forms;
using Android.Gms.Maps;
using System;
using Android.Gms.Maps.Model;
using Android.Locations;
using System.Collections.Generic;

namespace Jantantra
{
    [Activity(Label = "Jantantra", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IOnMapReadyCallback
    {
        private GoogleMap mMap;

        public void OnMapReady(GoogleMap googleMap)
        {
            mMap = googleMap;
            mMap.MapType = GoogleMap.MapTypeNormal;
            LatLng location = new LatLng(17.3850, 78.4867);  //Lat Long of Hyderabad
            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(location);
            builder.Zoom(12);
            builder.Bearing(155);
            //builder.Tilt(65);
            CameraPosition cameraPosition = builder.Build();
            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
            mMap.MoveCamera(cameraUpdate);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //Jantantra.Init(typeof(Jantantra).Assembly);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Enroll);
            //SetUpMap();
            Spinner spinnerCountry = (Spinner)FindViewById(Resource.Id.editText4);
            //spinner.ItemSelected += new System.EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapterCountry = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.states_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapterCountry.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerCountry.Adapter = adapterCountry;

            Spinner spinnerState = (Spinner)FindViewById(Resource.Id.editText5);
            //spinner.ItemSelected += new System.EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapterState = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.cities_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapterState.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerState.Adapter = adapterState;

            Spinner spinnerCity = (Spinner)FindViewById(Resource.Id.editText6);
            //spinner.ItemSelected += new System.EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapterCity = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.constituency_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapterCity.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerCity.Adapter = adapterCity;

            //var geoUri = Android.Net.Uri.Parse("geo:42.374260,-71.120824");
            //var mapIntent = new Intent(Intent.ActionView, geoUri);
            //StartActivity(mapIntent);
        }

        private void SetUpMap()
        {
            if (mMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }            
        }

        //public void GetLocationFromAddress(string strAddress)
        //{
        //    Geocoder coder = new Geocoder(this);
        //    //List<Address> address;
            
        //    try
        //    {
        //        var address = coder.GetFromLocationName(strAddress, 5);
        //        if (address == null)
        //        {
        //            return null;
        //        }
        //        Address location = address[0];                
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}

        //private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        //{
        //    Spinner spinner = (Spinner)sender;

        //    string toast = string.Format("The country is {0}", spinner.GetItemAtPosition(e.Position));
        //    Toast.MakeText(this, toast, ToastLength.Long).Show();
        //}
    }    
}

