using System;

namespace RabinKarp
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = Console.ReadLine();
            var text = Console.ReadLine();
            
            if (pattern.Length > text.Length||text.Length == 0)
            {
                Console.WriteLine("");
                return;
            }
            var sames = KarpRabin.FindSample(text, pattern);
            if (sames.Length != 0)
                foreach (var value in sames)
                    Console.Write("{0} ", value);
            //else Console.WriteLine("Empty");
            Console.ReadKey();
        }        
    }
    public static class KarpRabin
    {
        static int p = 65537;
        static int x = 257;

        public static int[] FindSample(string stringText, string stringPattern)//
        {
            int[] sames = new int[5];
            int k = 0;
            int prehash = -1;
            int hashText = -1;
            char[] text = stringText.ToCharArray();
            char[] pattern = stringPattern.ToCharArray();
            int patlen = pattern.Length;
            int[] xi = GetXi(patlen);
            int hashPattern = GetHash(pattern, xi);
            for (int i = text.Length - patlen; i >= 0; i--)
            {
                if (prehash == -1)
                {
                    var firstHash = new char[patlen];
                    Array.ConstrainedCopy(text, text.Length - patlen, firstHash, 0, patlen);
                    hashText = GetHash(firstHash, xi);
                    prehash = hashText;
                }
                else
                {
                    hashText = ReHash(text, prehash, i, xi);
                    prehash = hashText;
                }
                if (hashPattern == hashText && IsSame(text, pattern, i))
                {
                    if (sames.Length < k)
                        Array.Resize<int>(ref sames, (int)(sames.Length * 1.6));
                    sames[k] = i;
                    k++;
                }
            }
            var result = new int[k];
            for (int m = 0; m < result.Length; m++)
                result[result.Length - m-1] = sames[m];
            return result;
        }

        private static int[] GetXi(int patlen)//
        {
            var result = new int[patlen];
            result[0] = 1;
            for (int i = 1; i < patlen; i++)
                result[i] = result[i - 1] * x % p;
            return result;
        }

        private static bool IsSame(char[] text, char[] pattern, int i )//
        {
            for (int j = 0; j < pattern.Length; j++)            
                if (pattern[j]!=text[i+j])
                    return false;
            return true;
        }

        private static int ReHash(char[] text, int prehash, int i, int[] xi)
        {
            var hash = ((prehash + p - (xi[xi.Length - 1] * text[i + xi.Length]) % p) *x + text[i]) %p;
            return hash;
        }

        private static int GetHash(char[] sample, int[] xi)//
        {
            int hash = 0;
            for (int i = 0; i < sample.Length; i++)
                hash = (hash + sample[i]*xi[i]) % p;
            return hash;
        }
    }
}
