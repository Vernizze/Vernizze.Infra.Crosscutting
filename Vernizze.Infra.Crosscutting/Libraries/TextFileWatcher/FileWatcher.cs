using System.IO;

using Vernizze.Infra.CrossCutting.Extensions;

namespace Vernizze.Infra.CrossCutting.Libraries.TextFileWatcher
{
    public delegate void FileWatcher_OnChanged(object source, FileSystemEventArgs e);
    public delegate void FileWatcher_OnCreated(object source, FileSystemEventArgs e);
    public delegate void FileWatcher_OnDeleted(object source, FileSystemEventArgs e);
    public delegate void FileWatcher_OnRenamed(object source, RenamedEventArgs e);

    public static class FileWatcher
    {
        public static void Watch(string watched_path, FileWatcher_OnChanged OnChanged, FileWatcher_OnRenamed OnRenamed, FileWatcher_OnCreated OnCreated = null, FileWatcher_OnDeleted OnDeleted = null)
        {
            if (Directory.Exists(watched_path))
            {
                // Create a new FileSystemWatcher and set its properties.
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = watched_path;
                /* Watch for changes in LastAccess and LastWrite times, and
                   the renaming of files or directories. */
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                   | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                // Only watch text files.
                watcher.Filter = "*.txt";

                // Add event handlers.
                watcher.Changed += new FileSystemEventHandler(OnChanged);

                if (OnCreated.IsNull())
                    watcher.Created += new FileSystemEventHandler(OnChanged);
                else
                    watcher.Created += new FileSystemEventHandler(OnCreated);

                if (OnDeleted.IsNull())
                    watcher.Deleted += new FileSystemEventHandler(OnChanged);
                else
                    watcher.Deleted += new FileSystemEventHandler(OnChanged);

                watcher.Renamed += new RenamedEventHandler(OnRenamed);

                // Begin watching.
                watcher.EnableRaisingEvents = true;
            }
        }
    }
}
