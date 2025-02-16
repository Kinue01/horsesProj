using horsesProj.ModelV2;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace horsesProj.Util
{
    internal static class ReportUtils
    {
        private static readonly Font font = FontFactory.GetFont("Arial", 20);

        public static bool genPDFReport(List<TbRideCompetitor> result, string path)
        {
            using FileStream fileStream = new(path, FileMode.Create);
            using Document document = new();

            PdfWriter.GetInstance(document, fileStream);
            document.Open();

            document.Add(new Paragraph("Отчёт", font));

            result.ForEach(r =>
            {
                document.Add(new Paragraph(r.Ride.ToString() + " " + r.Competitor.ToString() + " " + r.RideResult + " " + r.HorseRunFail, font));
            });

            return true;
        }
    }
}
