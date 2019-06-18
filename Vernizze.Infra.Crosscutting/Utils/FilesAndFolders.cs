using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Vernizze.Infra.CrossCutting.Utils
{
    public static class FilesAndFolders
    {
        public static string AppPath()
        {
            return Directory.GetCurrentDirectory();
        }

        public static string SetCurrentFileName(string fileName)
        {
            var currentDir = Directory.GetCurrentDirectory();

            var isRootDir = currentDir.EndsWith(@":\");

            if (isRootDir)
            {
                currentDir = currentDir.Replace(@":\", string.Empty);
            }

            return string.Concat(currentDir, @"\", fileName);
        }

        public static string SetCurrentFileName(string path, string fileName)
        {
            var currentDir = path;

            var isRootDir = currentDir.EndsWith(@":\");

            if (isRootDir)
            {
                currentDir = currentDir.Replace(@":\", string.Empty);
            }

            return string.Concat(currentDir, @"\", fileName);
        }

        public static void ThrowFileNotFoundException(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"Arquivo ''{fileName}'' não existe!");
            }
        }

        public static string GetFileContent(string file_name, Dictionary<string, string> pairs)
        {
            var result = string.Empty;

            if (File.Exists(file_name))
            {
                var file = File.ReadAllText(file_name);

                if (file.Length > 0)
                {
                    pairs.ToList().ForEach(i =>
                    {
                        file = file.Replace(i.Key, i.Value);
                    });

                    result = file;
                }
            }

            return result;
        }

        public static string GetFileContent(string file_name)
        {
            var result = string.Empty;

            if (File.Exists(file_name))
            {
                var file = File.ReadAllText(file_name);

                if (file.Length > 0)
                    result = file;
            }

            return result;
        }

        public static bool WriteFile(string file_path, string file_name, string content)
        {
            var append = false;
            var result = false;

            if (!Directory.Exists(file_path))
                Directory.CreateDirectory(file_path);

            append = File.Exists($@"{file_path}\{file_name}");

            using (StreamWriter file = new StreamWriter($@"{file_path}\{file_name}", append, Encoding.UTF8))
            {
                file.Write(content);
            }

            result = File.Exists($@"{file_path}\{file_name}");

            return result;
        }
    }
}
