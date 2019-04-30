#region Namespaces
using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
#endregion

namespace DocDefender {
    public class Block {
        public List<Document> documents;
        public readonly string previous_hash;
        public readonly string hash;
        public int nonce;
        public DateTime timestamp = DateTime.Now;

        public override string ToString() {
            return $"{timestamp}\nPrev hash:\t{previous_hash}\nHash:\t\t{hash}";
        }

        public Block (List<Document> documents, string previous_hash, int nonce = 0) {
            this.documents = documents;
            this.previous_hash = previous_hash;
            this.nonce = nonce;

            this.hash = GenerateHash();
        }

        public string GenerateHash() {
            using (SHA256 sha256Hash = SHA256.Create()) {
                StringBuilder blockData = new StringBuilder();
                short i = 0;
                while(i < this.documents.Count) {
                    blockData.Append(this.documents[i]);
                    i++;
                }
                blockData.Append(this.previous_hash + this.nonce);
                return GetHash(sha256Hash, blockData.ToString());
            }
        }

        private string GetHash (HashAlgorithm hashAlgorithm, string input) {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++) {
                sBuilder.Append (data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}