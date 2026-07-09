using UglyToad.PdfPig;

namespace RenamePdfPages;

public class PdfRenamer
{
    public void RenamePdfFiles(string folderPath)
    {
        string[] pdfFiles = Directory.GetFiles(
            folderPath,
            "*.pdf",
            SearchOption.TopDirectoryOnly
        );

        if (pdfFiles.Length == 0)
        {
            Console.WriteLine("PDF файлы не найдены.");
            return;
        }

        foreach (string file in pdfFiles)
        {
            try
            {
                RenameFile(file);
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Ошибка обработки {file}: {ex.Message}"
                );
            }
        }
    }


    private void RenameFile(string filePath)
    {
        int pagesCount;

        using (PdfDocument document = PdfDocument.Open(filePath))
        {
            pagesCount = document.NumberOfPages;
        }


        string directory = Path.GetDirectoryName(filePath)!;
        string filename = Path.GetFileNameWithoutExtension(filePath);
        string extension = Path.GetExtension(filePath);


        string newFileName =
            $"{filename} л. - {pagesCount}{extension}";


        string newPath =
            Path.Combine(directory, newFileName);


        if (filePath == newPath)
        {
            Console.WriteLine(
                $"Пропущен: {filename}"
            );
            return;
        }


        File.Move(
            filePath,
            newPath
        );


        Console.WriteLine(
            $"{filename}{extension} → {newFileName}"
        );
    }
}
