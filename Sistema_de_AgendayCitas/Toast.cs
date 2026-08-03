using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaAgenda.UI
{
    // Notificación tipo "toast": aparece en la esquina inferior derecha
    // de la pantalla y se cierra sola después de unos segundos, sin
    // interrumpir lo que el usuario está haciendo (a diferencia de un
    // MessageBox, que bloquea el resto de la aplicación).
    public class Toast : Form
    {
        private const int ANCHO = 320;
        private const int ALTO = 80;
        private const int MARGEN = 16;
        private const int DURACION_MS = 4000;

        // Guarda los toasts abiertos actualmente para poder apilarlos
        // uno encima del otro sin que se tapen entre sí.
        private static readonly List<Toast> _toastsAbiertos = new List<Toast>();

        private readonly System.Windows.Forms.Timer _timerCierre;

        private Toast(string mensaje, string titulo)
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            ShowInTaskbar = false;
            TopMost = true;
            BackColor = Color.MediumVioletRed;
            Size = new Size(ANCHO, ALTO);

            var lblTitulo = new Label
            {
                Text = "🔔 " + titulo,
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                AutoSize = false,
                Dock = DockStyle.Top,
                Height = 24,
                Padding = new Padding(12, 8, 8, 0)
            };

            var lblMensaje = new Label
            {
                Text = mensaje,
                ForeColor = Color.LavenderBlush,
                Font = new Font("Segoe UI", 9F),
                AutoSize = false,
                Dock = DockStyle.Fill,
                Padding = new Padding(12, 0, 8, 8)
            };

            var btnCerrar = new Label
            {
                Text = "✕",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Dock = DockStyle.Right,
                Width = 28,
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };
            btnCerrar.Click += (s, e) => CerrarYReacomodar();

            Controls.Add(lblMensaje);
            Controls.Add(btnCerrar);
            Controls.Add(lblTitulo);

            _timerCierre = new System.Windows.Forms.Timer { Interval = DURACION_MS };
            _timerCierre.Tick += (s, e) => CerrarYReacomodar();
            _timerCierre.Start();
        }

        // Punto de entrada público: crea y muestra el toast en la esquina de la pantalla
        public static void Mostrar(string mensaje, string titulo = "Recordatorio")
        {
            var toast = new Toast(mensaje, titulo);
            toast.Show();
            _toastsAbiertos.Add(toast);
            ReacomodarToasts();
        }

        // Cierra este toast y desliza los demás para llenar el espacio que dejó
        private void CerrarYReacomodar()
        {
            _timerCierre.Stop();
            _toastsAbiertos.Remove(this);
            Close();
            ReacomodarToasts();
        }

        // Coloca todos los toasts abiertos apilados en la esquina inferior derecha
        private static void ReacomodarToasts()
        {
            var area = Screen.PrimaryScreen!.WorkingArea;
            int y = area.Bottom - MARGEN;

            for (int i = _toastsAbiertos.Count - 1; i >= 0; i--)
            {
                y -= ALTO + 10;
                _toastsAbiertos[i].Location = new Point(area.Right - ANCHO - MARGEN, y);
            }
        }
    }
}