﻿using System;
using Android.App;
using Android.Widget;
using Android.OS;
using EnviarCorreo.Nativo.Services;

namespace EnviarCorreo.Nativo
{
    [Activity(Label = "EnviarCorreoZuryel.Nativo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button actionButton;
        string emailBase = "oxxo@outlook.es";
        string codeBase = "iniciativa";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            actionButton = FindViewById<Button>(Resource.Id.btnReportar);
            actionButton.Click += btnReportar_Click;
        }

        private async void btnReportar_Click(object sender, EventArgs e)
        {
            ServiceHelper serviceHelper = new ServiceHelper();
            if (emailBase == "oxxo@outlook.es" || codeBase == "iniciativa")
            {
                throw new Exception("Recuerda modificar el código fuente para ingresar tu e-mail y ID de evento");

            }
            actionButton.Enabled = false;
            await serviceHelper.InsertarEntidad(emailBase, codeBase);
            actionButton.Text = "Reporte enviado";

            Toast.MakeText(this, "Tienes correo nuevo!", ToastLength.Short).Show();
        }
    }
}

