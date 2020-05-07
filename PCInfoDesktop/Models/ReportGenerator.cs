using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace PCInfoDesktop.Models {
    /// <summary>
    /// Class to create the content of the Agreement Report and convert it to PDF.
    /// </summary>
    public static class ReportGenerator {
        /// <summary>
        /// Gets the path of a report.
        /// </summary>
        /// <param name="id">ID of the current employee.</param>
        /// <returns>Path of the report corresponding to the ID.</returns>
        private static string GetReportPath(int id, string extension = "pdf") {
            return Path.Combine(
                Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName),
                "Reports",
                $"{id}_agreement.{extension}");
        }

        /// <summary>
        /// Creates a file and writes the content of the Agreement Report.
        /// </summary>
        /// <param name="employee">Logged employee who will sign the report.</param>
        public static void WriteReport(Employee employee) {
            string path = Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "Reports");
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }

            using (var writer = new PdfWriter(GetReportPath(employee.ID)))
            using (var pdf = new PdfDocument(writer))
            using (var document = new Document(pdf)) {
                // title
                document.Add(new Paragraph("Responsabilidad del uso del software")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(20));

                // employee's full name
                string fullname = $"{employee.Name} {employee.FirstLastName} {employee.SecondLastName}";
                // introduction
                document.Add(new Paragraph($"Por este medio yo, {fullname}, como empleado responsable me comprometo al buen uso del equipo de cómputo actual, el cual se especifica a continuación, así como las siguientes aplicaciones instaladas, y acepto que tanto la computadora como el software instalado y su contenido son propiedad de la empresa.")
                    .SetFontSize(10)
                    .SetTextAlignment(TextAlignment.JUSTIFIED));

                // initialize system information
                var sysInfo = new SysInfo();

                // table of basic system information
                var table = new Table(3, false)
                    .SetHorizontalAlignment(HorizontalAlignment.CENTER)
                    .SetTextAlignment(TextAlignment.CENTER);
                // add headers
                foreach (var header in new string[]{"Nombre de PC", "Sistema operativo", "Número de serie"}) {
                    table.AddHeaderCell(new Cell()
                        .SetBackgroundColor(ColorConstants.GRAY)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .Add(new Paragraph(header))
                        .SetFontSize(10));
                }
                // add content cells
                foreach (var str in new string[] { sysInfo.PCName, sysInfo.OSName, sysInfo.OSId }) {
                    table.AddCell(new Cell()
                        .SetTextAlignment(TextAlignment.CENTER)
                        .Add(new Paragraph(str))
                        .SetFontSize(10));
                }
                document.Add(table);

                // table of installed applications
                table = new Table(5, false)
                    .SetHorizontalAlignment(HorizontalAlignment.CENTER)
                    .SetTextAlignment(TextAlignment.CENTER);
                table.AddHeaderCell(new Cell(1, 5)
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("Aplicaciones instaladas"))
                    .SetFontSize(10));
                // add headers
                foreach (var header in new string[] { "Nombre", "Editor", "Fecha de instalación", "Tamaño", "Versión"}) {
                    table.AddHeaderCell(new Cell()
                        .SetBackgroundColor(ColorConstants.GRAY)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .Add(new Paragraph(header))
                        .SetFontSize(10));
                }
                // add each app
                foreach (var app in sysInfo.InstalledApplications) {
                    foreach (var str in app.ToArray()) {
                        table.AddCell(new Cell()
                            .SetTextAlignment(TextAlignment.CENTER)
                            .Add(new Paragraph(str))
                            .SetFontSize(10));
                    }
                }
                document.Add(table);

                document.Add(new Paragraph("\n\n\nPor lo anterior, confirmo que estoy enterado:")
                    .SetFontSize(11)
                    .SetTextAlignment(TextAlignment.CENTER));
                document.Add(new Paragraph("\n\n________________________")
                    .SetFontSize(11)
                    .SetTextAlignment(TextAlignment.CENTER));
                document.Add(new Paragraph($"{fullname}")
                    .SetFontSize(11)
                    .SetTextAlignment(TextAlignment.CENTER));
            }
        }
    }
}
