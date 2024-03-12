using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarea2024_03_05
{
    [Activity(Label = "AcDetalles")]
    public class AcDetalles : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            int id = this.Intent.GetIntExtra("idc",0);
            // Create your application here
            SetContentView(Resource.Layout.Detalles);
            TextView txtnombre = this.FindViewById<TextView>(Resource.Id.txtNombre);
            txtnombre.Text = id.ToString();
        }
    }
}