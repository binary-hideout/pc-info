using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Signatures;

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.X509;

using System.IO;

namespace PCInfoDesktop.Models {
    /// <summary>
    /// Class to manage electronic signatures on PDFs.
    /// </summary>
    public static class ElectronicSignature {
        /// <summary>
        /// Electronically signs the PDF of agreement report.
        /// </summary>
        /// <param name="id">Employee's ID.</param>
        /// <param name="pfxPath">Path of PFX file.</param>
        /// <param name="password">Password to open PFX.</param>
        public static void SignPDF(int id, string pfxPath, char[] password) {
            ICipherParameters privateKey;
            X509Certificate[] chain;
            using (var fileStream = new FileStream(pfxPath, FileMode.Open, FileAccess.Read)) {
                var pk12 = new Pkcs12Store(fileStream, password);
                string alias = null;
                foreach (object a in pk12.Aliases) {
                    alias = a as string;
                    if (pk12.IsKeyEntry(alias)) {
                        break;
                    }
                }
                privateKey = pk12.GetKey(alias).Key;

                var certificate = pk12.GetCertificateChain(alias);
                chain = new X509Certificate[certificate.Length];
                for (int k = 0; k < certificate.Length; ++k) {
                    chain[k] = certificate[k].Certificate;
                }
            }

            using (var reader = new PdfReader(ReportGenerator.GetReportPath(id)))
            using (var fileStream = new FileStream(ReportGenerator.GetReportPath(id, "_SIGNED"), FileMode.Create)) {
                var signer = new PdfSigner(reader, fileStream, new StampingProperties());
                int lastPage;
                using (var r = new PdfReader(ReportGenerator.GetReportPath(id)))
                using (var document = new PdfDocument(r)) {
                    lastPage = document.GetNumberOfPages();
                }
                var appearance = signer.GetSignatureAppearance()
                    .SetReason("Me comprometo al uso responsable del software especificado en este documento.")
                    .SetPageRect(new Rectangle(100, 1000, 200, 100))
                    .SetPageNumber(lastPage);
                signer.SetFieldName("MyFieldName");

                var pks = new PrivateKeySignature(privateKey, DigestAlgorithms.SHA256);
                signer.SignDetached(pks, chain, null, null, null, 0, PdfSigner.CryptoStandard.CMS);
            }
        }
    }
}
