namespace PolyDeploy.DeployClient
{
    using System.Collections.Generic;
    using System.IO.Abstractions;
    using System.IO;

    public class PackageFileSource : IPackageFileSource
    {
        private readonly IFileSystem fileSystem;

        public PackageFileSource(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        public IReadOnlyCollection<string> GetPackageFiles(string path)
        {
            return this.fileSystem.Directory.GetFiles(path, "*.zip", new EnumerationOptions()
            {
                RecurseSubdirectories = true
            });
        }

        public Stream GetFileStream(string fileName)
        {
            return this.fileSystem.File.Open(fileName, FileMode.Open, FileAccess.Read);
        }
    }
}
