using Newtonsoft.Json;

namespace UnicodeNamer;

class Program
{
    static void Main(string[] args)
    {
        var files = Directory.GetFiles(args[0]);
        var records = JsonConvert.DeserializeObject<List<EmojiRecord>>(File.ReadAllText("./emojis.json"));
        
        if (records == null)
        {
            return;
        }
        
        foreach (var file in files)
        {
            var info = new FileInfo(file);
            var extension = info.Extension;
            var emojis = Path.GetFileNameWithoutExtension(file).Split(['-', '_']);
            var name = string.Join('_', emojis.Select(e => records.FirstOrDefault(r => r.Unicode.Equals(e.TrimStart('u'), StringComparison.InvariantCultureIgnoreCase))?.Name.Replace(" ", string.Empty ) ?? e));
            
            if (info.DirectoryName == null)
            {
                continue;
            }
            
            var newName = Path.Combine(info.DirectoryName, name + extension);
            File.Move(file, newName);
        }
    }
}
