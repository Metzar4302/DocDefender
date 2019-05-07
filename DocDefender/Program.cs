#region Namespaces
using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json;
using System.Diagnostics;
#endregion

namespace DocDefender
{
    class Program
    {
        private static Blockchain blockChain1 = new Blockchain();
        static void Main(string[] args) {
            Document doc1 = new Document("Doc information", new List<string>(){"BinaryDocData_1", "BinaryDocData_2", "BinaryDocData_3"});
            Document doc2 = new Document("Doc_2 information", new List<string>(){"11", "22", "33"});
            Document doc3 = new Document("Doc_3 information", new List<string>(){"111", "222", "333"});
            Document doc4 = new Document("Doc_4 information", new List<string>(){"1111", "2222", "3333"});
            // Test
            string serialized = JsonConvert.SerializeObject(doc1);
            // Test error 
            string brokenSerialized = "{\"DocInfo\":777,\"DocsFiles\":\"Just text\"}";

            string[] serializedArray = new string[]{
                serialized,
                brokenSerialized
            };

            // ReadData(brokenSerialized);
            // ReadData(serialized);
            ReadDataArray(serializedArray);
            
            // Tools.ChainView(blockChain1);
        }
        public static void ReadDataArray(string[] inputSerializes){
            for (int i = 0; i < inputSerializes.Length; i++) {
                System.Console.WriteLine($"{i+1} / {inputSerializes.Length}");
                ReadData(inputSerializes[i]);
            }
        }

        // Reading json data, convert this and add block to chain
        public static void ReadData(string inputSerialize){
            try {
                Tools.WriteLineColorized($"Processing...", ConsoleColor.DarkBlue);
                // Deserializing document from input string
                Document doc = JsonConvert.DeserializeObject<Document>(inputSerialize);
                // Adding document to chain
                AddToBlockChain(doc);
                Tools.WriteLineColorized($"DONE!", ConsoleColor.Blue);
            }
            catch (JsonSerializationException){
                Tools.WriteLineColorized($"ERROR: Cannot convert value to target type", ConsoleColor.Red);
                // Tools.WriteLineColorized($ {Encoding.Convert()}"Невозможно привести полученное значение к заданому типу", ConsoleColor.Red);
            }
            catch (Exception ex) {
                Tools.WriteLineColorized($"{ex.Message}", ConsoleColor.Red);
            }
        }

        private static void AddToBlockChain(Document doc){
            try {
                blockChain1.AddBlock(new List<Document>(){doc});
            }
            catch (Exception ex) {
                Tools.WriteLineColorized($"{ex.Message}", ConsoleColor.Red);
            }
        }
    }
}
