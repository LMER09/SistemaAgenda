using SistemaAgenda.UI;

namespace Sistema_de_AgendayCitas
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Manejador global de excepciones: evita que el programa se cierre de golpe
            // si ocurre un error que nadie capturo con try-catch
            Application.ThreadException += (sender, e) =>
            {
                MessageBox.Show("Ocurrió un error inesperado:\n" + e.Exception.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.Run(new frmPrincipal());
        }
    }
}