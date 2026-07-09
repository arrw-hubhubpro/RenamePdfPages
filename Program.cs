using RenamePdfPages;

Console.WriteLine("PDF Page Renamer");
Console.WriteLine("----------------");

Console.Write("Введите путь к папке с PDF файлами: ");

string? folderPath = Console.ReadLine();

if (string.IsNullOrWhiteSpace(folderPath))
{
    Console.WriteLine("Путь не указан.");
    return;
}

if (!Directory.Exists(folderPath))
{
    Console.WriteLine("Папка не существует.");
    return;
}

PdfRenamer renamer = new PdfRenamer();

renamer.RenamePdfFiles(folderPath);

Console.WriteLine();
Console.WriteLine("Готово. Нажмите любую клавишу.");
Console.ReadKey();
