using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first.Models
{
    internal class AllProfs
    {
        public ObservableCollection<CharProf> Profs { get; set; } = new ObservableCollection<CharProf>();

        public AllProfs() =>
            LoadProfs();

        public void LoadProfs()
        {
            Profs.Clear();

            //Get folder where the notes are stored
            string appDataPath = FileSystem.AppDataDirectory;
            
            //Use Linq extension to load the *.notes.txt files
            IEnumerable<CharProf> profs = Directory

                //select the file names from directory
                .EnumerateFiles(appDataPath, "*.prof.txt")

                .Select(fileName => new CharProf()
                {
                    Filename = fileName,
                    Name = File.ReadLines(fileName).Take(1).First(),
                    Species = File.ReadLines(fileName).Skip(1).Take(1).First(),
                    Class = File.ReadLines(fileName).Skip(2).Take(1).First(),
                    Date = File.GetCreationTime(fileName)
                    
                })
                .OrderBy(prof => prof.Date);

            foreach (CharProf prof in profs)
            {
                Profs.Add(prof);
            }

        }

    }
}
