string currentFolder = Directory.GetCurrentDirectory();
int index = currentFolder.IndexOf(@"\AutoGenerateCode");
Console.WriteLine("Enter source project folder(Enter 'this' if debug mode):");
string sourceFolder = Console.ReadLine();
if (sourceFolder == "this")
{
    sourceFolder = currentFolder.Remove(index);
}
Console.WriteLine(sourceFolder);
Console.WriteLine("Enter source domain class:");
string sourceName = Console.ReadLine();
string sourceNameCamel = sourceName.ToArray()[0].ToString().ToLower() + sourceName.Substring(1, sourceName.Length - 1);
Console.WriteLine(sourceNameCamel);
var files = Directory.GetFiles(sourceFolder, sourceName + "*", SearchOption.AllDirectories).ToList();
files.AddRange(Directory.GetFiles(sourceFolder, "I" + sourceName + "*", SearchOption.AllDirectories));
files.RemoveAll(c => c.EndsWith("razor.g.cs"));
foreach (var item in files)
{
    Console.WriteLine(item);
}
if (!files.Any())
{
    Console.WriteLine("Source class not found.");
    Console.ReadKey();
    return;
}
Console.WriteLine("Enter target domain class:");
string targetName = Console.ReadLine();
string targetNameCamel = targetName.ToArray()[0].ToString().ToLower() + targetName.Substring(1, targetName.Length - 1);

foreach (var file in files)
{
    string path = Path.GetDirectoryName(file);
    string nameFile = Path.GetFileName(file);
    //Console.WriteLine(path);
    //Console.WriteLine(nameFile);
    string convertNameFile = nameFile.Replace(sourceName, targetName);
    string newFilePath = Path.Combine(path, convertNameFile);
    if (File.Exists(newFilePath))
    {
        Console.WriteLine(convertNameFile + " already exists");
        continue;
    }
    string contentFile = File.ReadAllText(file);
    contentFile = contentFile.Replace(sourceName, targetName);
    contentFile = contentFile.Replace(sourceNameCamel, targetNameCamel);
    File.WriteAllText(newFilePath, contentFile);
    Console.WriteLine(convertNameFile + " has been created");
}