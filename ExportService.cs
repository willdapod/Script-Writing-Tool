using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

public class ExportService
{
    public void ExportToPDF(Scene scene, string filePath)
    {
        Document doc = new Document();
        PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
        doc.Open();

        // Explicitly use iTextSharp.text.Paragraph
        doc.Add(new iTextSharp.text.Paragraph(scene.Title));
        foreach (var line in scene.ScriptLines)
        {
            doc.Add(new iTextSharp.text.Paragraph($"{line.Speaker.Name}: {line.Dialogue}"));
        }

        doc.Close();
    }
}