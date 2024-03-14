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
using static Tarea2024_03_05.AcInicio;

namespace Tarea2024_03_05
{
    
    [Activity(Label = "AcEdit")]
    public class AcEdit : Activity
    {
        Button btnedit;
        EditText txtNombre;
        EditText txtTelefono;
        EditText txtEmain;
        EditText txtEdad;
        Spinner spPaises;
        DataSet ds;
        DataSet ds2;
        int id;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            clsDatos datos = new clsDatos();
            id = this.Intent.GetIntExtra("id", 0);
            ds = datos.detalleContacto(id);

            // Create your application here
            SetContentView(Resource.Layout.Contactos);
           btnedit = this.FindViewById<Button>(Resource.Id.btnAdd);
            txtNombre = this.FindViewById<EditText>(Resource.Id.txtAddNombre);
            txtTelefono = this.FindViewById<EditText>(Resource.Id.txtAddTelefono);
            txtEmain = this.FindViewById<EditText>(Resource.Id.txtAddEmail);
            txtEdad = this.FindViewById<EditText>(Resource.Id.txtAddEdad);
            spPaises = this.FindViewById<Spinner>(Resource.Id.spAddPais);


            btnedit.Click += Btnedit_Click;


            txtNombre.Text = ds.Tables[0].Rows[0]["nombre"].ToString();
            txtTelefono.Text = ds.Tables[0].Rows[0]["telefono"].ToString();
            txtEmain.Text = ds.Tables[0].Rows[0]["email"].ToString();
            txtEdad.Text = ds.Tables[0].Rows[0]["edad"].ToString();
            btnedit.Text = "Editar";
            ds2 = datos.paises();
            ArrayAdapter adap = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem);
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                adap.Add(ds2.Tables[0].Rows[i]["pais"].ToString());
            }
            spPaises.Adapter = adap;
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["idpais"]) == Convert.ToInt32(ds2.Tables[0].Rows[i]["idpais"]))
                {
                    spPaises.SetSelection(i);
                }
            }

            //Toast.MakeText(this, this.Intent.GetIntExtra("id", 0).ToString(), ToastLength.Short).Show();
        }
        private void Btnedit_Click(object sender, EventArgs e)
        {
            clsDatos datos = new clsDatos();
            int res = 0;
            int idpais = Convert.ToInt32(ds2.Tables[0].Rows[spPaises.SelectedItemPosition]["idPais"]);
            res = datos.EditarContacto(id, txtNombre.Text, txtTelefono.Text, txtEmain.Text, Convert.ToInt32(txtEdad.Text), idpais);
            if (res != 0)
            {
                Toast.MakeText(this, "Usuarios Modificado", ToastLength.Short).Show();
                Finish();
            }
            else
            {
                AlertDialog a1 = new AlertDialog.Builder(this).Create();
                a1.SetTitle("Alerta de seguridad 🗿");
                a1.SetMessage("No todos los datos del contacto estan llenos\nReviselos");
                a1.SetButton("OK", btnOK);
                a1.Show();
            }
        }

        private void btnOK(object sender, DialogClickEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
 
}