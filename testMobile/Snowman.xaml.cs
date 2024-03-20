﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Snowman : ContentPage
    {
        Slider blue1;
        Stepper stp;
        BoxView ring3;
        BoxView ring;
        BoxView ring1;
        BoxView ring2;
        Button btn;
        Button btn1;
        Button btn2;
        Button btn3;
        Button btn4;
        int r;
        int g;
        int b;
        public Snowman()
        {
            BackgroundColor = Color.Black;

            ring3 = new BoxView()
            {
                CornerRadius = 1,
                WidthRequest = 70,
                HeightRequest = 50,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Gray,
            };

            ring = new BoxView()
            {
                CornerRadius = 400,
                WidthRequest = 100,
                HeightRequest = 100,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.White,
            };

            ring1 = new BoxView()
            {
                CornerRadius = 400,
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.White,
            };

            ring2 = new BoxView()
            {
                CornerRadius = 400,
                WidthRequest = 200,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.White,
            };

            btn = new Button()
            {
                WidthRequest = 70,
                HeightRequest = 30,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Firebrick,
                TextColor = Color.White,
                Text = "Peida",
                FontSize = 8
            };

            btn1 = new Button()
            {
                WidthRequest = 70,
                HeightRequest = 30,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Firebrick,
                TextColor = Color.White,
                Text = "Näita",
                FontSize = 8
            };

            btn2 = new Button()
            {
                WidthRequest = 70,
                HeightRequest = 30,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Firebrick,
                TextColor = Color.White,
                Text = "Muuda värv",
                FontSize = 8
            };

            btn3 = new Button()
            {
                WidthRequest = 70,
                HeightRequest = 30,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Firebrick,
                TextColor = Color.White,
                Text = "Sulama",
                FontSize = 8
            };

            btn.Clicked += hide;
            btn1.Clicked += show;
            btn2.Clicked += color;
            btn3.Clicked += f4; ;

            AbsoluteLayout st = new AbsoluteLayout
            {
                Children = { ring, ring1, ring2, btn, btn1, btn2, btn3, ring3 }
            };

            AbsoluteLayout.SetLayoutBounds(ring, new Rectangle(0.4, 0.37, 300, 200));
            AbsoluteLayout.SetLayoutFlags(ring, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(ring1, new Rectangle(0.4, 0.59, 300, 200));
            AbsoluteLayout.SetLayoutFlags(ring1, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(ring2, new Rectangle(0.4, 0.90, 300, 200));
            AbsoluteLayout.SetLayoutFlags(ring2, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(ring3, new Rectangle(0.4, 0.24, 300, 200));
            AbsoluteLayout.SetLayoutFlags(ring3, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(btn2, new Rectangle(-1.20, 0.01, 300, 100));
            AbsoluteLayout.SetLayoutFlags(btn2, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(btn1, new Rectangle(1.0, 0.01, 300, 100));
            AbsoluteLayout.SetLayoutFlags(btn1, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(btn, new Rectangle(0.07, 0.01, 300, 100));
            AbsoluteLayout.SetLayoutFlags(btn, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(btn3, new Rectangle(2.20, 0.01, 300, 100));
            AbsoluteLayout.SetLayoutFlags(btn3, AbsoluteLayoutFlags.PositionProportional);

            Content = st;

        }

        private async void f4(object sender, EventArgs e)
        {
            await ring.FadeTo(0, 2000);
            await ring1.FadeTo(0, 2000);
            await ring2.FadeTo(0, 2000);

            for (double i = 0.24; i <= 0.99; i += 0.1)
            {
                AbsoluteLayout.SetLayoutBounds(ring3, new Rectangle(0.4, i, 300, 200));
                AbsoluteLayout.SetLayoutFlags(ring3, AbsoluteLayoutFlags.PositionProportional);
                await Task.Delay(50);
            }
        }

        private void hide(object sender, EventArgs e)
        {
            ring3.IsVisible = false;
            ring2.IsVisible = false;
            ring1.IsVisible = false;
            ring.IsVisible = false;
        }

        private void show(object sender, EventArgs e)
        {
            ring3.IsVisible = true;
            ring2.IsVisible = true;
            ring1.IsVisible = true;
            ring.IsVisible = true;
            ring.Opacity = 1;
            ring1.Opacity = 1;
            ring2.Opacity = 1;
            AbsoluteLayout.SetLayoutBounds(ring3, new Rectangle(0.4, 0.24, 300, 200));
            AbsoluteLayout.SetLayoutFlags(ring3, AbsoluteLayoutFlags.PositionProportional);
        }

        private void color(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int r = rnd.Next(0, 255);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);
            ring.BackgroundColor = Color.FromRgb(r, g, b);
            ring1.BackgroundColor = Color.FromRgb(r, g, b);
            ring2.BackgroundColor = Color.FromRgb(r, g, b);
        }
    }
}