using System;
using System.Collections.Generic;

namespace DocDefender
{
    public class Blockchain
    {
        private List<Block> chain = new List<Block>();
        public List<Block> Chain
        {
            get { return chain;}
            set { chain = value;}
        }
        
        public Blockchain(){
            GenesisBlock();
        }
        
        // First block in chain
        private void GenesisBlock(){
            Block block = new Block(new List<Document>(), new String('0', 64));
            this.Chain.Add(block);
        }

        public void AddBlock(List<Document> documents){
            Block block = new Block(documents, Chain[Chain.Count - 1].hash);
            this.Chain.Add(block);
        }

        public bool ValidateChain(){
            for (int i = 1; i < this.Chain.Count; i++){
                Block current = this.Chain[i];
                Block previous = this.Chain[i-1];
                if (current.hash != current.GenerateHash()){
                    PrintWithColor($"{current.timestamp} The current hash of the block does not equal the generated hash of the block", ConsoleColor.Red);
                    return false;
                }
                if (previous.hash != previous.GenerateHash()){
                    PrintWithColor("The previous block's hash does not equal the previous hash value stored in the current block", ConsoleColor.Red);
                    return false;
                }
            }
            PrintWithColor($"Hash validation complete! {chain.Count} elements [with started-zero]", ConsoleColor.Green);
            return true;
        }

        private void PrintWithColor(string text, ConsoleColor color){
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}