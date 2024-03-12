using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Service.Autofill;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Tarea2024_03_05
{
    [Activity(Label = "AcContactos")]
    public class AcContactos : Activity
    {
        DataSet ds;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Contactos);


            clsDatos datos = new clsDatos();
            ds = datos.paises();

            Spinner spPaises = this.FindViewById<Spinner>(Resource.Id.spAddPais);

            ArrayAdapter adap = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem);
            for (int i=0; i<ds.Tables[0].Rows.Count; i++)
            {
                adap.Add(ds.Tables[0].Rows[i]["pais"].ToString());
            }
            spPaises.Adapter = adap;
            Button add = this.FindViewById<Button>(Resource.Id.btnAdd);

            add.Click += Add_Click;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            EditText txtNombre = this.FindViewById<EditText>(Resource.Id.txtAddNombre);
            EditText txtTelefono = this.FindViewById<EditText>(Resource.Id.txtAddTelefono);
            EditText txtEmain = this.FindViewById<EditText>(Resource.Id.txtAddEmail);
            EditText txtEdad = this.FindViewById<EditText>(Resource.Id.txtAddEdad);
            Spinner spPaises = this.FindViewById<Spinner>(Resource.Id.spAddPais);

            clsDatos datos = new clsDatos();
            int res = 0;
            int idpais = Convert.ToInt32(ds.Tables[0].Rows[spPaises.SelectedItemPosition]["idPais"]);
            res = datos.AgregarContactos(txtNombre.Text, txtTelefono.Text, txtEmain.Text, Convert.ToInt32(txtEdad.Text), idpais);
            if (res != 0)
            {
                Toast.MakeText(this,"Usuarios Ingresado",ToastLength.Short).Show();
                Finish();
            }
        }
    }
}