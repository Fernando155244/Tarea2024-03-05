using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Tarea2024_03_05
{
    [Activity(Label = "AcInicio")]
    public class AcInicio : Activity
    {
        DataSet ds;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Inicio);

            ListView ls = this.FindViewById<ListView>(Resource.Id.lsContactos);
            Button btnadd = this.FindViewById<Button>(Resource.Id.btnAgregar);

            clsDatos datos = new clsDatos();
            ds = datos.cargarContactos();
            btnadd.Click += Btnadd_Click;
            ls.ItemClick += Ls_ItemClick;



            ls.Adapter = new miAdap(this, ds);
        }
        protected override void OnResume()
        {
            base.OnResume();
            ListView l1 = this.FindViewById<ListView>(Resource.Id.lsContactos);
            clsDatos datos = new clsDatos();
            ds = datos.cargarContactos();
            l1.Adapter = new miAdap(this, ds);
        }

        private void Ls_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int id = Convert.ToInt32(ds.Tables[0].Rows[e.Position]["idContacto"]);
            //Toast.MakeText(this,id,ToastLength.Long).Show();
            Intent i1 = new Intent(this, typeof(AcDetalles));
            i1.PutExtra("idc", id);
            StartActivity(i1);
        }

        private void Btnadd_Click(object sender, EventArgs e)
        {

            StartActivity(typeof(AcContactos));
        }

        internal class miAdap : BaseAdapter
        {
            private AcInicio acInicio;
            private DataSet ds;

            public miAdap(AcInicio acInicio, DataSet ds)
            {
                this.acInicio = acInicio;
                this.ds = ds;
            }

            public override int Count
            {
                get
                {
                    return ds.Tables[0].Rows.Count;
                }
            }

            public override Java.Lang.Object GetItem(int position)
            {
                return "";
            }

            public override long GetItemId(int position)
            {
                return position;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                View celda = convertView;
                if (celda == null)
                {
                    celda = acInicio.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);
                }
                TextView txtnom = celda.FindViewById<TextView>(Android.Resource.Id.Text1);
                TextView txttel = celda.FindViewById<TextView>(Android.Resource.Id.Text2);

                txtnom.Text = ds.Tables[0].Rows[position]["nombre"].ToString();
                txttel.Text = ds.Tables[0].Rows[position]["telefono"].ToString();
                return celda;
            }
        }
    }
}