using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

namespace Cinehub.Services
{
    public class ImageInsertionService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ImageInsertionService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        /// <summary>
        /// Create a simple PDF document
        /// </summary>
        /// <returns>Return the created PDF document as stream</returns>
        public MemoryStream ImageInsertionPDF()
        {
            //Create a new PDF document
            PdfDocument document = new PdfDocument();
            // Add a new page to the newly created document.
            PdfPage page = document.Pages.Add();
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold);
            PdfGraphics g = page.Graphics;
            g.DrawString("JPEG Image", font, PdfBrushes.Blue, new Syncfusion.Drawing.PointF(0, 40));
            //Load JPEG image to stream.
            FileStream jpgImageStream = new FileStream(@"d:\C#\BlazorApp1\BlazorApp1\wwwroot\Images\hereditary.jpg", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            //Load the JPEG image
            PdfImage jpgImage = new PdfBitmap(jpgImageStream);
            //Draw the JPEG image
            g.DrawImage(jpgImage, new Syncfusion.Drawing.RectangleF(0, 70, 515, 215));
            MemoryStream stream = new MemoryStream();
            //Save the PDF document
            document.Save(stream);
            stream.Position = 0;
            //Close the PDF document
            document.Close(true);
            return stream;
        }
        #region HelperMethod
        private string ResolveApplicationPath(string fileName)
        {
            return _hostingEnvironment.WebRootPath + "//data//pdf//" + fileName;
        }
        private string ResolveApplicationImagePath(string fileName)
        {
            return _hostingEnvironment.WebRootPath + "//images//pdf//" + fileName;
        }
        #endregion
    }
}
