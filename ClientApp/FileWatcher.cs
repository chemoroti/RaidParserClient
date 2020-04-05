using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DamageParser.ClientApp
{
    public class FileWatcher
    {
        private string FullPath;
        private FileStream FileStream;
        private string FileName;
        private StreamReader Reader;
        public delegate void OnLogFileUpdate(IEnumerable<string> newLines);
        public event OnLogFileUpdate OnLogFileUpdateEvent;
        public FileWatcher(string fullPath, string fileName)
        {
            FullPath = fullPath;
            FileName = fileName;
        }

        public void Start()
        {
            //Open the file as FileStream
            FileStream = new FileStream(FullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            Reader = new StreamReader(FileStream);
            //Set the starting position
            FileStream.Position = FileStream.Length - 1;

            FileSystemWatcher watch = new FileSystemWatcher();
            watch.Path = GetFilePath(FullPath, FileName);
            watch.Filter = FileName;
            watch.NotifyFilter = NotifyFilters.LastWrite;
            watch.Changed += new FileSystemEventHandler(OnChanged);
            watch.EnableRaisingEvents = true;
        }

        private string GetFilePath(string fullPath, string fileName)
        {
            string path = fullPath.Substring(0, fullPath.Length - fileName.Length);
            return path;
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            if (e.FullPath == FullPath)
            {
                IEnumerable<string> newLines = GetAddedLines();
                if (newLines.Count() == 0)
                    return;

                if(OnLogFileUpdateEvent != null)
                    OnLogFileUpdateEvent.Invoke(newLines);
            }
        }

        //Get the current offset. You can save this when the application exits and on next reload
        //set startPosition to value returned by this method to start reading from that location
        public long CurrentOffset
        {
            get { return FileStream.Position; }
        }

        //Returns the lines added after this function was last called
        public IEnumerable<string> GetAddedLines()
        {
            var readToEnd = Reader.ReadToEnd();
            IEnumerable<string> result = readToEnd.Split('\n').Where(l => 
                Regex.IsMatch(l, EnumsAndConstants.MeleeRegex) ||
                Regex.IsMatch(l, EnumsAndConstants.SpellRegex) ||
                (!string.IsNullOrEmpty(EnumsAndConstants.PetAttackRegex) && Regex.IsMatch(l, EnumsAndConstants.PetAttackRegex)) ||
                Regex.IsMatch(l, EnumsAndConstants.MyKillshotRegex) ||
                Regex.IsMatch(l, EnumsAndConstants.OtherKillshotRegex) ||
                Regex.IsMatch(l, EnumsAndConstants.DiedRegex) || 
                Regex.IsMatch(l, EnumsAndConstants.PetLeaderRegex)
            );
            return result;
        }
    }
}
