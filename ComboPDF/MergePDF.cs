using System.IO;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace ComboPDF
{
    class MergePDF
    {
        public static bool MergePDFFiles(string input1, string input2, string outputPath, string pdfName)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            if (!File.Exists(input1))
            {
                Console.Error.WriteLine($"Error: File not found: {input1}");
            }

            if (!File.Exists(input2))
            {
                Console.Error.WriteLine($"Error: File not found: {input2}");
            }

            // ── Merge ────────────────────────────────────────────────────────────────────
            try
            {
                MergePdfs(input1, input2, outputPath, pdfName);
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to merge PDFs: {ex.Message}");
                return false;
            }
            static void MergePdfs(string path1, string path2, string outputPath, string outputName)
            {
                // Create the output directory if it doesn't already exist.
                string? dir = Path.GetDirectoryName(Path.GetFullPath(outputPath));
                if (!string.IsNullOrEmpty(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                // Checks if pdf is in the output file name
                bool isPdf = outputName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase);
                if (isPdf)
                {
                    DocumentOperation
                    .LoadFile(path1)
                    .MergeFile(path2)
                    .Save($"{outputPath}\\{outputName}");
                }
                if (!isPdf)
                {
                    outputName += ".pdf";
                    DocumentOperation
                    .LoadFile(path1)
                    .MergeFile(path2)
                    .Save($"{outputPath}\\{outputName}");
                }
            }
        }
    }
}
