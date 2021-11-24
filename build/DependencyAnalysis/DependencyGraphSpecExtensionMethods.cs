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
    }
}