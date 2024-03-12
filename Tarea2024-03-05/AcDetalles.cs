using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Tarea2024_03_05
{
    /*Subir a git
     git add .
    git commit -m "Ahora con todos los datos y botones con emojis"
    git push*/
    [Activity(Label = "AcDetalles")]
    public class AcDetalles : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            int id = this.Intent.GetIntExtra("idc",0);
            // Create your application here
            SetContentView(Resource.Layout.Detalles);
            clsDatos datos = new clsDatos();
            DataSet ds = datos.detalleContacto(id);


            TextView txtnombre = this.FindViewById<TextView>(Resource.Id.txtNombre);
            TextView txttelefono = this.FindViewById<TextView>(Resource.Id.txtTelefono);
            TextView txtemail = this.FindViewById<TextView>(Resource.Id.txtEmail);
            TextView txtedad = this.FindViewById<TextView>(Resource.Id.txtEdad);
            TextView txtpais = this.FindViewById<TextView>(Resource.Id.txtPaís);

            txtnombre.Text = ds.Tables[0].Rows[0]["nombre"].ToString();
            txttelefono.Text = ds.Tables[0].Rows[0]["telefono"].ToString();
            txtemail.Text = ds.Tables[0].Rows[0]["email"].ToString();
            txtedad.Text = ds.Tables[0].Rows[0]["edad"].ToString();
            txtpais.Text = ds.Tables[0].Rows[0]["pais"].ToString();

        }
    }
}