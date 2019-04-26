#region Namespaces
using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Threading;
#endregion

namespace DocDefender
{
    class Program
    {
        static void Main(string[] args)
        {
            Document doc1 = new Document("Doc1 information", new List<string>(){"1", "2", "3"});
            Document doc2 = new Document("Doc2 information", new List<string>(){"11", "22", "33"});
            Document doc3 = new Document("Doc3 information", new List<string>(){"111", "222", "333"});
            Document doc4 = new Document("Doc4 information", new List<string>(){"1111", "2222", "3333"});

            Blockchain blockChain1 = new Blockchain();
            blockChain1.AddBlock(new List<Document>(){doc1, doc2});
            Thread.Sleep(1000);
            blockChain1.AddBlock(new List<Document>(){doc3});
            Thread.Sleep(1000);
            blockChain1.AddBlock(new List<Document>(){doc4});
            ChainView(blockChain1);
            
            
        }
        static void ChainView(Blockchain blockChain){
            foreach (Block item in blockChain.Chain) {
                Console.WriteLine($"{item}");
            }
        }
    }
}
