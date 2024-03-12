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
using System.Data;

namespace Tarea2024_03_05
{
    internal class clsDatos
    {
        public int Login (string usuario, string contrasenia)
        {
            WebReference.Service1 ws = new WebReference.Service1 ();
            int res = 0;
            res = ws.Agenda_Login(usuario, contrasenia);
            return res;
        }
        public DataSet cargarContactos()
        {
            WebReference.Service1 ws = new WebReference.Service1();
            DataSet ds = new DataSet();
            ds = ws.Agenda_CargaContactos();
            return ds;
        }
        public DataSet detalleContacto(int id)
        {
            WebReference.Service1 ws = new WebReference.Service1();
            DataSet ds = new DataSet();
            ds = ws.Agenda_DetalleContacto(id);
            return ds;
        }

    }
}