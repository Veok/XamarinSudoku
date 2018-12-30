using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Widget;
using SudokuMobileApp;
using SudokuMobileApp.Droid;

[assembly: ExportRenderer(typeof(XEntry), typeof(XEntryRenderer))]
namespace SudokuMobileApp.Droid
{
    public class XEntryRenderer : EntryRenderer
    {
        public XEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // do whatever you want to the UITextField here!
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);

            }
        }
    }
}