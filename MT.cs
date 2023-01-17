using Newtonsoft.Json;
using System.Dynamic;
using System.Security.Cryptography;

namespace MerkleTree
{
    internal class MT
    {
        public static string buidMerkle(string[] transactions)
        {
            while (true)
            {
                if (transactions.Length == 1) return transactions[0];
                List<string> list = new List<string>();
                int length = (transactions.Length % 2 != 0) ? transactions.Length - 1 : transactions.Length;
                for (int i = 0; i < length; i += 2) list.Add(createHash(transactions[i], transactions[i + 1]));
                if (length < transactions.Length) list.Add(createHash(transactions[transactions.Length - 1], transactions[transactions.Length - 1]));
                transactions = list.ToArray();
            }
        }


        static string createHash(string first, string second)
        {
            byte[] array1 = Enumerable.Range(0, first.Length / 2).Select(x => Convert.ToByte(first.Substring(x * 2, 2), 16)).ToArray();
            Array.Reverse(array1);
            byte[] array2 = Enumerable.Range(0, second.Length / 2).Select(x => Convert.ToByte(second.Substring(x * 2, 2), 16)).ToArray();
            Array.Reverse(array2);
            var concat = array1.Concat(array2).ToArray();
            SHA256 sha256 = SHA256.Create();
            byte[] hash1 = sha256.ComputeHash(concat);
            byte[] hash2 = sha256.ComputeHash(hash1);
            Array.Reverse(hash2);
            return BitConverter.ToString(hash2).Replace("-", "").ToLower();
        }
    }
}
