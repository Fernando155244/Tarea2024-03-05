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
    [Activity(Label = "AcDetalles")]
    public class AcDetalles : Activity
    {
        DataSet ds;
        int id;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            id = this.Intent.GetIntExtra("idc", 0); 
            // Create your application here
            SetContentView(Resource.Layout.Detalles);
            clsDatos datos = new clsDatos();
            ds = datos.detalleContacto(id);
            

            TextView txtnombre = this.FindViewById<TextView>(Resource.Id.txtNombre);
            TextView txttelefono = this.FindViewById<TextView>(Resource.Id.txtTelefono);
            TextView txtemail = this.FindViewById<TextView>(Resource.Id.txtEmail);
            TextView txtedad = this.FindViewById<TextView>(Resource.Id.txtEdad);
            TextView txtpais = this.FindViewById<TextView>(Resource.Id.txtPaís);
            Button btnborrar = this.FindViewById<Button>(Resource.Id.btnEliminar);
            Button btneditar = this.FindViewById<Button>(Resource.Id.btnEditar);

            btnborrar.Click += Btnborrar_Click;
            btneditar.Click += Btneditar_Click;

            txtnombre.Text = ds.Tables[0].Rows[0]["nombre"].ToString();
            txttelefono.Text = ds.Tables[0].Rows[0]["telefono"].ToString();
            txtemail.Text = ds.Tables[0].Rows[0]["email"].ToString();
            txtedad.Text = ds.Tables[0].Rows[0]["edad"].ToString();
            txtpais.Text = ds.Tables[0].Rows[0]["pais"].ToString();
        }
        protected override void OnResume()
        {
            base.OnResume();
            clsDatos datos = new clsDatos();
            ds = datos.detalleContacto(id);
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

        private void Btneditar_Click(object sender, EventArgs e)
        {
            Intent i1 = new Intent(this, typeof(AcEdit));
            i1.PutExtra("id", id);
            StartActivity(i1);
        }

        private void Btnborrar_Click(object sender, EventArgs e)
        {
            AlertDialog a1 = new AlertDialog.Builder(this).Create();
            a1.SetTitle("💀¿Desceas borrar este contacto?💀");
            a1.SetMessage("Si borras no podras recuperarlo!");
            a1.SetButton("Borrar", btnSi);
            a1.SetButton2("Cancelar", btnNo);
            a1.Show();
        }

        private void btnNo(object sender, DialogClickEventArgs e)
        {
            Toast.MakeText(this, "Cancelado", ToastLength.Short).Show();
        }

        private void btnSi(object sender, DialogClickEventArgs e)
        {
            clsDatos datos = new clsDatos();
            if (id != 0)
            {
                Toast.MakeText(this, "Usuarios Eliminado", ToastLength.Short).Show();
                Finish();
            }
            else
            {
                Toast.MakeText(this, "Alerta de seguridad 🗿\nEl usuario no ha podido ser borrado!", ToastLength.Long).Show();
            }
        }

        private void btnOK(object sender, DialogClickEventArgs e)
        {
        }
    }
}