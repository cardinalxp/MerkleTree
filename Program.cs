using MerkleTree;
using Newtonsoft.Json;

var transactions = new string[] {
   "aaa","bbb","ccc","ddd","eee"  
};
var result = MT.buidMerkle(transactions);
Console.WriteLine("Transactions:\n" + JsonConvert.SerializeObject(transactions));
Console.WriteLine("\nMerkle Root:\n" + result);
Console.WriteLine("\nPress enter to close...");
Console.Read();
