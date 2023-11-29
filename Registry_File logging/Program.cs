using Microsoft.Win32;

var subKey = "Software_regedit";

var key = Registry.CurrentUser.OpenSubKey(subKey);
if (key is null)
{
    var newKey = Registry.CurrentUser.CreateSubKey(subKey);
    newKey.SetValue("First_Run", DateTime.Now.ToString());
    newKey.Close();
}

var directoryPath = @"c:\test";
var fileName = @"test1.txt";
var fullPath = Path.Combine(directoryPath, fileName);

var existsDir = Directory.Exists(directoryPath);
var existsFile = File.Exists(fullPath);

if (!existsDir) Directory.CreateDirectory(directoryPath);
if (!existsFile) File.Create(fullPath).Close();

using StreamWriter sw = File.AppendText(fullPath);
sw.WriteLine($"Start program: {DateTime.Now}");
Console.WriteLine("The information about the current run was successfully added to the file.");