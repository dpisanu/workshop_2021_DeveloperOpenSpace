using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using NuGet.ProjectModel;

namespace DependencyAnalysis
{
    public static class DependencyGraphSpecExtensionMethods
    {
        public static IEnumerable<(string name, string version)> GetPackageReferences(this PackageSpec packageSpec)
        {
            var xml = File.ReadAllText(packageSpec.FilePath);

            var doc = XDocument.Parse(xml);
            return doc.XPathSelectElements("//PackageReference")
                .Select(pr => (pr.Attribute("Include").Value, pr.Attribute("Version").Value));
        }

        public static IEnumerable<string> GetProjectReferences(this PackageSpec packageSpec)
        {
            var directoryPath = Path.GetDirectoryName(packageSpec.FilePath);
            var xml = File.ReadAllText(packageSpec.FilePath);

            var doc = XDocument.Parse(xml);
            return doc.XPathSelectElements("//ProjectReference")
                .Select(pr => Path.GetFullPath(Path.Combine(directoryPath, pr.Attribute("Include").Value)));
        }

        public static string GetBinPath(this PackageSpec packageSpec)
        {
            var directoryPath = Path.GetDirectoryName(packageSpec.FilePath);
            var xml = File.ReadAllText(packageSpec.FilePath);

            var doc = XDocument.Parse(xml);

            string assemblyName;
            var assemblyNameNode = doc.XPathSelectElement("//AssemblyName");
            string extension = Path.GetFileNameWithoutExtension(packageSpec.FilePath) == "SampleWpfApp" ? "exe" : "dll";
            if (assemblyNameNode == null)
            {
                assemblyName = Path.GetFileNameWithoutExtension(packageSpec.FilePath) + "." + extension;
            }
            else
            {
                assemblyName = assemblyNameNode.Value + extension;
            }

            return Path.GetFullPath(Path.Combine(directoryPath, doc.XPathSelectElements("//OutputPath")
                .First().Value, assemblyName));
        }

        public static IEnumerable<string> GetAllProjectReferences(this PackageSpec packageSpec,
            DependencyGraphSpec dependencyGraphSpec)
        {
            var hashSet = new HashSet<string>(packageSpec.GetAllProjectReferencesInt(dependencyGraphSpec));
            return hashSet;
        }

        private static IEnumerable<string> GetAllProjectReferencesInt(this PackageSpec packageSpec,
            DependencyGraphSpec dependencyGraphSpec)
        {
            var result = new HashSet<string>();

            var projectReferences = packageSpec.GetProjectReferences();

            foreach (var projectReference in projectReferences)
            {
                var spec = dependencyGraphSpec.Projects.Single(p => p.FilePath == projectReference);

                foreach (var subReference in GetAllProjectReferencesInt(spec, dependencyGraphSpec))
                {
                    yield return subReference;
                }
            }

            foreach (var projectReference in projectReferences)
            {
                yield return projectReference;
            }
        }
    }
}