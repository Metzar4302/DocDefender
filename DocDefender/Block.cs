using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DocDefender {
    public class Block {
        public List<Transaction> transactions;
        public string previous_hash;
        public string hash;
        public int nonce;
        public DateTime timestamp = DateTime.Now;

        public override string ToString() {
            return $"{timestamp}\nPrev hash:\t{previous_hash}\nHash:\t\t{hash}";
        }

        public Block (List<Transaction> transactions, string previous_hash, int nonce = 0) {
            this.transactions = transactions;
            this.previous_hash = previous_hash;
            this.nonce = nonce;

            this.hash = GenerateHash();
        }

        public string GenerateHash() {
            using (SHA256 sha256Hash = SHA256.Create()) {
                StringBuilder blockData = new StringBuilder();
                foreach (var item in this.transactions){
                    blockData.Append(item);
                }
                blockData.Append(this.previous_hash + this.nonce);
                string hash = GetHash (sha256Hash, blockData.ToString());
                return hash;
            }
        }

        private string GetHash (HashAlgorithm hashAlgorithm, string input) {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++) {
                sBuilder.Append (data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}