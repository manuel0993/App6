﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;

namespace App6
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            btnGetLocation.Clicked += BtnGetLocation_Clicked;
		}
        private async void BtnGetLocation_Clicked(object sender,EventArgs e)
        {
            await RetreiveLocation();

        }
        private async Task RetreiveLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;

            var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

            txtLat.Text = "Latitud: " + position.Latitude.ToString();
            txtLong.Text = "Longitud: " + position.Longitude.ToString();

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude)
            , Distance.FromMiles(1)));
                
        }

    }
}
