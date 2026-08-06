using SistemaAgenda.Negocios;
using SistemaAgenda.Datos;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using ClosedXML.Excel;
using System.IO;

namespace SistemaAgenda.UI
{
    public partial class frmReportes : Form
    {
        private readonly PagosBLL pagosBLL = new PagosBLL();
        private readonly BaseColor Rosa = new BaseColor(233, 30, 99);
        private readonly BaseColor Gris = new BaseColor(240, 240, 240);

        public frmReportes()
        {
            InitializeComponent();
        }

        private async Task CargarPagosAsync()
        {
            var reporte = await pagosBLL.ObtenerReporteAsync(
                dtpDesde.Value.Date,
                dtpHasta.Value.Date);

            dgvPagos.DataSource = null;
            dgvPagos.DataSource = reporte;

            lblCantidadCitas.Text = reporte.Count.ToString();

            decimal total = pagosBLL.ObtenerTotalReporte(reporte);

            lblTotal.Text = $"RD$ {total:N2}";
        }

        private async void FrmReportes_Load(object sender, EventArgs e)
        {
            dtpDesde.MaxDate = DateTime.Today;
            dtpHasta.MaxDate = DateTime.Today;

            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;

            await CargarPagosAsync();
        }

        // No toca base de datos: exporta lo que ya esta en el grid
        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();

            guardar.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
            guardar.FileName = "Reporte_Ingresos.xlsx";

            if (guardar.ShowDialog() != DialogResult.OK)
                return;

            using (XLWorkbook libro = new XLWorkbook())
            {
                var hoja = libro.Worksheets.Add("Reporte");

                hoja.Cell(1, 1).Value = "REPORTE DE INGRESOS";
                hoja.Range(1, 1, 1, dgvPagos.Columns.Count).Merge();
                hoja.Cell(1, 1).Style.Font.Bold = true;
                hoja.Cell(1, 1).Style.Font.FontSize = 16;
                hoja.Cell(1, 1).Style.Alignment.Horizontal =
                    XLAlignmentHorizontalValues.Center;

                hoja.Cell(3, 1).Value = "Desde:";
                hoja.Cell(3, 2).Value = dtpDesde.Value.ToShortDateString();

                hoja.Cell(4, 1).Value = "Hasta:";
                hoja.Cell(4, 2).Value = dtpHasta.Value.ToShortDateString();

                hoja.Cell(5, 1).Value = "Total:";
                hoja.Cell(5, 2).Value = lblTotal.Text;

                hoja.Cell(6, 1).Value = "Cantidad de citas:";
                hoja.Cell(6, 2).Value = lblCantidadCitas.Text;

                int filaInicio = 8;

                for (int i = 0; i < dgvPagos.Columns.Count; i++)
                {
                    hoja.Cell(filaInicio, i + 1).Value =
                        dgvPagos.Columns[i].HeaderText;

                    hoja.Cell(filaInicio, i + 1).Style.Font.Bold = true;
                    hoja.Cell(filaInicio, i + 1).Style.Fill.BackgroundColor =
                        XLColor.LightPink;

                    hoja.Cell(filaInicio, i + 1).Style.Alignment.Horizontal =
                        XLAlignmentHorizontalValues.Center;
                }

                int fila = filaInicio + 1;

                foreach (DataGridViewRow row in dgvPagos.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    for (int i = 0; i < dgvPagos.Columns.Count; i++)
                    {
                        hoja.Cell(fila, i + 1).Value =
                            row.Cells[i].Value?.ToString();
                    }

                    fila++;
                }

                var rango = hoja.Range(
                    filaInicio,
                    1,
                    fila - 1,
                    dgvPagos.Columns.Count);

                rango.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                rango.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                hoja.Columns().AdjustToContents();

                libro.SaveAs(guardar.FileName);
            }

            MessageBox.Show(
                "Reporte exportado correctamente a Excel.",
                "Sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private async void btnCorteDia_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show(
                    "La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.",
                    "Fechas inválidas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var reporte = await pagosBLL.ObtenerReporteAsync(
                dtpDesde.Value.Date,
                dtpHasta.Value.Date);

            dgvPagos.DataSource = null;
            dgvPagos.DataSource = reporte;

            lblCantidadCitas.Text = reporte.Count.ToString();

            decimal total = pagosBLL.ObtenerTotalReporte(reporte);

            lblTotal.Text = "RD$ " + total.ToString("N2");
        }

        private void lblTotal_Click(object sender, EventArgs e) { }
        private void lblDesde_Click(object sender, EventArgs e) { }
        private void lblHasta_Click(object sender, EventArgs e) { }
        private void dtpFechaReporte_ValueChanged(object sender, EventArgs e) { }

        // No toca base de datos: exporta lo que ya esta en el grid
        private void btnPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "PDF (*.pdf)|*.pdf";
            guardar.FileName = "ReporteIngresos.pdf";

            if (guardar.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                iTextSharp.text.Document documento =
                    new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 30, 30, 30, 30);

                iTextSharp.text.pdf.PdfWriter.GetInstance(
                    documento,
                    new FileStream(guardar.FileName, FileMode.Create));

                documento.Open();

                var fuenteTitulo = iTextSharp.text.FontFactory.GetFont(
                    iTextSharp.text.FontFactory.HELVETICA_BOLD, 20);

                fuenteTitulo.Color = new iTextSharp.text.BaseColor(233, 30, 99);

                var fuenteSubTitulo = iTextSharp.text.FontFactory.GetFont(
                    iTextSharp.text.FontFactory.HELVETICA_OBLIQUE, 11);

                fuenteSubTitulo.Color = iTextSharp.text.BaseColor.GRAY;

                var fuenteNormal = iTextSharp.text.FontFactory.GetFont(
                    iTextSharp.text.FontFactory.HELVETICA, 10);

                var fuenteNegrita = iTextSharp.text.FontFactory.GetFont(
                    iTextSharp.text.FontFactory.HELVETICA_BOLD, 10);

                var fuenteCabecera = iTextSharp.text.FontFactory.GetFont(
                    iTextSharp.text.FontFactory.HELVETICA_BOLD, 10);

                fuenteCabecera.Color = iTextSharp.text.BaseColor.WHITE;

                iTextSharp.text.Paragraph titulo =
                    new iTextSharp.text.Paragraph("SALÓN BELLEZA", fuenteTitulo);

                titulo.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                documento.Add(titulo);

                iTextSharp.text.Paragraph lema =
                    new iTextSharp.text.Paragraph("Tu belleza, nuestro compromiso", fuenteSubTitulo);

                lema.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                lema.SpacingAfter = 15;
                documento.Add(lema);

                iTextSharp.text.Paragraph reporte =
                    new iTextSharp.text.Paragraph("REPORTE DE INGRESOS", fuenteNegrita);

                reporte.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                reporte.SpacingAfter = 20;
                documento.Add(reporte);

                documento.Add(new iTextSharp.text.Paragraph(
                    $"Desde: {dtpDesde.Value:dd/MM/yyyy}", fuenteNormal));

                documento.Add(new iTextSharp.text.Paragraph(
                    $"Hasta: {dtpHasta.Value:dd/MM/yyyy}", fuenteNormal));

                documento.Add(new iTextSharp.text.Paragraph(
                    $"Fecha de emisión: {DateTime.Now:dd/MM/yyyy HH:mm}", fuenteNormal));

                documento.Add(new iTextSharp.text.Paragraph(" "));

                documento.Add(new iTextSharp.text.Paragraph(
                    $"Total generado: {lblTotal.Text}", fuenteNegrita));

                documento.Add(new iTextSharp.text.Paragraph(
                    $"Cantidad de citas: {lblCantidadCitas.Text}", fuenteNegrita));

                documento.Add(new iTextSharp.text.Paragraph(" "));

                iTextSharp.text.pdf.PdfPTable tabla =
                    new iTextSharp.text.pdf.PdfPTable(dgvPagos.Columns.Count);

                tabla.WidthPercentage = 100;

                foreach (DataGridViewColumn columna in dgvPagos.Columns)
                {
                    iTextSharp.text.pdf.PdfPCell celda =
                        new iTextSharp.text.pdf.PdfPCell(
                            new iTextSharp.text.Phrase(columna.HeaderText, fuenteCabecera));

                    celda.BackgroundColor = new iTextSharp.text.BaseColor(233, 30, 99);
                    celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    celda.Padding = 6;

                    tabla.AddCell(celda);
                }

                foreach (DataGridViewRow fila in dgvPagos.Rows)
                {
                    if (fila.IsNewRow)
                        continue;

                    foreach (DataGridViewCell celda in fila.Cells)
                    {
                        tabla.AddCell(celda.Value?.ToString() ?? "");
                    }
                }

                documento.Add(tabla);

                documento.Add(new iTextSharp.text.Paragraph(" "));

                iTextSharp.text.Paragraph pie =
                    new iTextSharp.text.Paragraph(
                        "Reporte generado automáticamente por Sistema Agenda y Citas",
                        fuenteSubTitulo);

                pie.Alignment = iTextSharp.text.Element.ALIGN_CENTER;

                documento.Add(pie);

                documento.Close();

                MessageBox.Show(
                    "PDF exportado correctamente.",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al generar PDF",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}