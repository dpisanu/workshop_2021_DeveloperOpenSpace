using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace DependencyAnalysis
{
    public class DependencyHashStorage : IDisposable
    {
        private readonly HashSet<string> _hashes = new();
        private readonly string _storageDirectoryPath;
        private readonly object _lock = new object();
        private SHA1CryptoServiceProvider _sha1CryptoServiceProvider = new SHA1CryptoServiceProvider();

        public DependencyHashStorage(string storageDirectoryPath)
        {
            _storageDirectoryPath = storageDirectoryPath;

            _hashes = new HashSet<string>(File.Exists(GetStorageFilePath())
                ? File.ReadAllLines(GetStorageFilePath())
                : Enumerable.Empty<string>());
        }

        private string GetStorageFilePath() => Path.Combine(_storageDirectoryPath, "Hashes.txt");

        public string GenerateHash(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            using var stream = fileInfo.OpenRead();
            byte[] hash;
            lock (_lock)
            {
                hash = _sha1CryptoServiceProvider.ComputeHash(stream);
            }

            var hashString = BitConverter.ToString(hash).Replace("-", "");
            return hashString;
        }

        public void StoreHash(string hash) => _hashes.Add(hash);

        public void StoreFileHash(string filePath)
        {
            var hash = GenerateHash(filePath);
            StoreHash(hash);
        }

        public bool IsHashKnown(string hash) => _hashes.Contains(hash);

        public bool IsHashKnownForFile(string filePath)
        {
            var hash = GenerateHash(filePath);
            return IsHashKnown(hash);
        }

        public void Dispose()
        {
            File.WriteAllLines(GetStorageFilePath(), _hashes);
        }
    }
}