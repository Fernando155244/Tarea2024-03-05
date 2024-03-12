using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using AlertDialog = Android.App.AlertDialog;

namespace Tarea2024_03_05
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            Button btnlog = this.FindViewById<Button>(Resource.Id.btnLogin);
            btnlog.Click += Btnlog_Click;
        }

        private void Btnlog_Click(object sender, System.EventArgs e)
        {
            EditText txtuser = this.FindViewById<EditText>(Resource.Id.txtUser);
            EditText txtpass = this.FindViewById<EditText>(Resource.Id.txtPassword);
            clsDatos datos = new clsDatos();
            int res = datos.Login(txtuser.Text, txtpass.Text);
            //Toast.MakeText(this,res.ToString(),ToastLength.Long).Show();

            if(res == 0)
            {
                AlertDialog a1 = new AlertDialog.Builder(this).Create();
                a1.SetTitle("Alerta de seguridad 🗿");
                a1.SetMessage("Usuario o contraseña errados!");
                a1.SetButton("OK",btnOK);
                a1.Show();
            }
            else
            {
                Toast.MakeText(this, "Bienvenido", ToastLength.Long).Show();
                StartActivity(typeof(AcInicio));
            }
        }

        private void btnOK(object sender, DialogClickEventArgs e)
        {
            
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}