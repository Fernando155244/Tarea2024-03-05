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
    [Activity(Label = "AcContactos")]
    public class AcContactos : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Contactos);

            Button add = this.FindViewById<Button>(Resource.Id.btnAdd);

            add.Click += Add_Click;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            clsDatos datos = new clsDatos();
            
        }
    }
}