using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;
using System.Linq;
using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace SistemaAgenda.UI
{
    public partial class frmReportes : Form
    {
        private PagosBLL pagosBLL = new PagosBLL();

        // Guarda solo los pagos del día que se muestran en pantalla,
        // para que exportar use exactamente lo mismo que ves en el grid
        private List<Pagos> _pagosDeHoy = new List<Pagos>();

        public frmReportes()
        {
            InitializeComponent();
            QuestPDF.Settings.License = LicenseType.Community;
        }

        // Trae los pagos y filtra únicamente los de la fecha de hoy —
        // antes se sumaban TODOS los pagos de la historia, sin filtrar por día
        private void CargarPagos()
        {
            DateTime hoy = DateTime.Today;

            _pagosDeHoy = pagosBLL.ObtenerTodos()
                .Where(p => p.FechaPago.Date == hoy)
                .ToList();

            dgvPagos.DataSource = null;
            dgvPagos.DataSource = _pagosDeHoy;

            decimal total = _pagosDeHoy.Sum(p => p.Monto);

            lblTotal.Text = $"RD$ {total:F2}";
            lblFechaReporte.Text = $"Reporte de hoy, {hoy:dd/MM/yyyy}";
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            CargarPagos();
        }

        private void btnCorteDia_Click(object sender, EventArgs e)
        {
            decimal total = _pagosDeHoy.Sum(p => p.Monto);

            CorteDia corte = new CorteDia(total);
            corte.Cerrar();
            MessageBox.Show($"Corte del día generado.\nTotal: RD$ {total:F2}", "Corte del día");
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (_pagosDeHoy.Count == 0)
            {
                MessageBox.Show("No hay pagos registrados hoy para exportar.");
                return;
            }

            using var dialogo = new SaveFileDialog
            {
                Filter = "Excel (*.xlsx)|*.xlsx",
                FileName = $"Reporte_{DateTime.Today:dd-MM-yyyy}.xlsx"
            };

            if (dialogo.ShowDialog() != DialogResult.OK) return;

            try
            {
                using var libro = new XLWorkbook();
                var hoja = libro.Worksheets.Add("Pagos del día");

                hoja.Cell(1, 1).Value = "Reporte de pagos";
                hoja.Cell(2, 1).Value = $"Fecha: {DateTime.Today:dd/MM/yyyy}";
                hoja.Range(1, 1, 1, 4).Merge();
                hoja.Cell(1, 1).Style.Font.Bold = true;
                hoja.Cell(1, 1).Style.Font.FontSize = 14;

                int fila = 4;
                hoja.Cell(fila, 1).Value = "Id Cita";
                hoja.Cell(fila, 2).Value = "Monto";
                hoja.Cell(fila, 3).Value = "Método de pago";
                hoja.Cell(fila, 4).Value = "Fecha del pago";
                hoja.Range(fila, 1, fila, 4).Style.Font.Bold = true;

                foreach (Pagos p in _pagosDeHoy)
                {
                    fila++;
                    hoja.Cell(fila, 1).Value = p.Id_Citas;
                    hoja.Cell(fila, 2).Value = p.Monto;
                    hoja.Cell(fila, 3).Value = p.Metodo_DePago;
                    hoja.Cell(fila, 4).Value = p.FechaPago.ToString("dd/MM/yyyy HH:mm");
                }

                fila++;
                hoja.Cell(fila, 1).Value = "Total";
                hoja.Cell(fila, 2).Value = _pagosDeHoy.Sum(p => p.Monto);
                hoja.Range(fila, 1, fila, 2).Style.Font.Bold = true;

                hoja.Columns().AdjustToContents();
                libro.SaveAs(dialogo.FileName);

                MessageBox.Show("Reporte exportado a Excel correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo exportar el Excel: " + ex.Message);
            }
        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            if (_pagosDeHoy.Count == 0)
            {
                MessageBox.Show("No hay pagos registrados hoy para exportar.");
                return;
            }

            using var dialogo = new SaveFileDialog
            {
                Filter = "PDF (*.pdf)|*.pdf",
                FileName = $"Reporte_{DateTime.Today:dd-MM-yyyy}.pdf"
            };

            if (dialogo.ShowDialog() != DialogResult.OK) return;

            try
            {
                decimal total = _pagosDeHoy.Sum(p => p.Monto);

                Document.Create(documento =>
                {
                    documento.Page(pagina =>
                    {
                        pagina.Margin(30);
                        pagina.Size(PageSizes.A4);
                        pagina.DefaultTextStyle(x => x.FontSize(11));

                        pagina.Header().Column(col =>
                        {
                            col.Item().Text("Reporte de pagos").FontSize(18).Bold();
                            col.Item().Text($"Fecha: {DateTime.Today:dd/MM/yyyy}").FontColor(Colors.Grey.Darken1);
                        });

                        pagina.Content().PaddingTop(15).Table(tabla =>
                        {
                            tabla.ColumnsDefinition(columnas =>
                            {
                                columnas.RelativeColumn();
                                columnas.RelativeColumn();
                                columnas.RelativeColumn();
                                columnas.RelativeColumn();
                            });

                            tabla.Header(encabezado =>
                            {
                                encabezado.Cell().Text("Id Cita").Bold();
                                encabezado.Cell().Text("Monto").Bold();
                                encabezado.Cell().Text("Método de pago").Bold();
                                encabezado.Cell().Text("Fecha del pago").Bold();
                            });

                            foreach (Pagos p in _pagosDeHoy)
                            {
                                tabla.Cell().Text(p.Id_Citas.ToString());
                                tabla.Cell().Text($"RD$ {p.Monto:F2}");
                                tabla.Cell().Text(p.Metodo_DePago);
                                tabla.Cell().Text(p.FechaPago.ToString("dd/MM/yyyy HH:mm"));
                            }
                        });

                        pagina.Footer().AlignRight().Text($"Total del día: RD$ {total:F2}").Bold().FontSize(13);
                    });
                }).GeneratePdf(dialogo.FileName);

                MessageBox.Show("Reporte exportado a PDF correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo exportar el PDF: " + ex.Message);
            }
        }
    }
}