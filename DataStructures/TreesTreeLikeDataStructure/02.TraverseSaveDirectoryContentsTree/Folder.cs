namespace _02.TraverseSaveDirectoryContentsTree
{
    using System.Collections.Generic;

    public class Folder
    {
        public string Name { get; set; }

        public IList<File> Files { get; set; }

        public IList<Folder> ChildFolders { get; set; }

        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }
    }
}
