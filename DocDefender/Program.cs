﻿#region Namespaces
using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json;
#endregion

namespace DocDefender
{
    class Program
    {
        static Blockchain blockChain1 = new Blockchain();
        static void Main(string[] args)
        {
            #region Test
            Document doc1 = new Document("Doc information", new List<string>(){"DinaryDocData_1", "DinaryDocData_2", "DinaryDocData_3"});
            Document doc2 = new Document("Doc_2 information", new List<string>(){"11", "22", "33"});
            Document doc3 = new Document("Doc_3 information", new List<string>(){"111", "222", "333"});
            Document doc4 = new Document("Doc_4 information", new List<string>(){"1111", "2222", "3333"});

            string serialized = JsonConvert.SerializeObject(doc1);

            string brokenSerialized = "{\"DocInfo\":777,\"DocsFiles\":\"Just text\"}";

            Tools.WriteLineColorized($"{ReadData(brokenSerialized)}", ConsoleColor.Red);
            Tools.WriteLineColorized($"{ReadData(serialized)}", ConsoleColor.Blue);
            
            Tools.ChainView(blockChain1);

            #endregion
        }
        
        public static string ReadData(string inputSerialize){
            try {
                Document doc = JsonConvert.DeserializeObject<Document>(inputSerialize);
                
                AddToBlockChain(doc);
            }
            catch (System.Exception ex) {
                return $"{ex.Message}";
            }
            return "DONE!";
        }

        private static string AddToBlockChain(Document doc){
            try {
                blockChain1.AddBlock(new List<Document>(){doc});
            }
            catch (System.Exception ex) {
                return $"{ex.Message}";
            }
            return "DONE!";
        }
    }
}
