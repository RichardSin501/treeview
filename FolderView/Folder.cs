using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace FolderView
{
    internal class Folder : INotifyPropertyChanged
    {
        private ObservableCollection<Folder> _subFolders;

        public string Name { get; set; }
        public string Path { get; set; }

        public ObservableCollection<Folder> SubFolders
        {
            get { return _subFolders; }
            set
            {
                _subFolders = value;
                OnPropertyRaised("SubFolders");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Folder(string path)
        {
            Path = path;
            try
            {
                Name = new DirectoryInfo(path).Name;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Name = "";
            }
            SubFolders = new ObservableCollection<Folder>();
        }

        public void LoadSubFolders()
        {
            SubFolders = new ObservableCollection<Folder>();

            try
            {
                try
                {
                    foreach (var dir in Directory.GetDirectories(Path, "*.*", SearchOption.TopDirectoryOnly))
                    {
                        SubFolders.Add(new Folder(dir));
                    }
                }
                catch { }

                foreach (var folder in SubFolders)
                {
                    folder.SubFolders = new ObservableCollection<Folder>();

                    try
                    {
                        foreach (var dir in Directory.GetDirectories(folder.Path, "*.*", SearchOption.TopDirectoryOnly))
                        {
                            folder.SubFolders.Add(new Folder(dir));
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }

        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}