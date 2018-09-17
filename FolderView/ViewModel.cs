using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace FolderView
{
    internal class ViewModel
    {
        public ObservableCollection<Folder> DirList { get; set; }

        public ViewModel()
        {
            DirList = new ObservableCollection<Folder>();

            foreach (var drive in DriveInfo.GetDrives())
            {
                DirList.Add(new Folder(drive.RootDirectory.FullName));
                Debug.WriteLine(drive.RootDirectory.FullName);
            }

            foreach (var folder in DirList)
            {
                folder.LoadSubFolders();
            }
        }
    }
}