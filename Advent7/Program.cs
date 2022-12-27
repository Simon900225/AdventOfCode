var inputReader = new StreamReader("input.txt");

string? line;

Folder currentFolder = new Folder("C", new List<Folder>(), new List<File>(), null);
Folder rootFolder = currentFolder;

while ((line = inputReader.ReadLine()) != null)
{
    if (line.StartsWith("$"))
    {
        if (line.StartsWith("$ cd .."))
        {
            currentFolder = currentFolder.Parent;
        }
        else if (line.StartsWith("$ cd"))
        {
            var newFolder = new Folder(
                line.Remove(0, 4),
                new List<Folder>(),
                new List<File>(),
                currentFolder
            );
            currentFolder.SubFolders.Add(newFolder);
            currentFolder = newFolder;
        }
    }
    else
    {
        if (!line.StartsWith("dir"))
        {
            var values = line.Split(' ');
            currentFolder.Files.Add(new File(values[1], Convert.ToInt32(values[0])));
        }
    }
};

var allFolders = GetAllFolders(rootFolder);
var smallFolders = allFolders.Where(x => x.SubTreeSize() <= 100000).ToList();

var diskLeft = 70000000 - rootFolder.SubTreeSize();

var sizeWeNeed = 30000000 - diskLeft;

var folder = allFolders.Where(x => x.SubTreeSize() >= sizeWeNeed).OrderBy(x => x.SubTreeSize()).First();

Console.WriteLine(rootFolder.SubTreeSize());
Console.WriteLine(smallFolders.Sum(x => x.SubTreeSize()));
Console.WriteLine(folder.SubTreeSize());
static List<Folder> GetAllFolders(Folder folder)
{
    List<Folder> result = folder.SubFolders.ToList();
    foreach(var subfolder in folder.SubFolders)
    {
        result.AddRange(GetAllFolders(subfolder));
    }
    return result;
}

record Folder(string Path, List<Folder> SubFolders, List<File> Files, Folder Parent)
{
    public int FilesInFolderSize()
    {
        return Files.Sum(x => x.Size);
    }

    public int SubTreeSize()
    {
        return Files.Sum(x => x.Size) + SubFolders.Sum(x => x.SubTreeSize());
    }

}
record File(string Path, int Size);