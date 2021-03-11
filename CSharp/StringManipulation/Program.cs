using System;

namespace StringManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstString = "Accenture SPA";
            string secondString = "Accenture Società per Azioni";
            string output;


            //Normalize Strings
            firstString = stringNormalizer(firstString);
            secondString = stringNormalizer(secondString);


            /* 
            Longest Common Subsequence
            */
            
            output = lcs(firstString, secondString);

            Console.WriteLine($"The LCS of ({firstString}, {secondString}) is: {output}");
     

            /* 
            FuzzySharp - The Levenshtein Distance 
            */

            //Weighted Comparison
            int weighted;

            weighted = FuzzySharp.Fuzz.WeightedRatio(firstString, secondString);
            Console.WriteLine($"Weighted Comparison: {weighted}");

            //Ratio Comparison
            int Ratio;

            Ratio = FuzzySharp.Fuzz.Ratio(firstString, secondString);
            Console.WriteLine($"Ratio Comparison: {Ratio}");


            //TokenAbbreviationRatio Comparison
            int TokenAbbreviationRatio;

            TokenAbbreviationRatio = FuzzySharp.Fuzz.TokenAbbreviationRatio(firstString, secondString);
            Console.WriteLine($"TokenAbbreviationRatio Comparison: {TokenAbbreviationRatio}");



            //TokenAbbreviationRatio Comparison
            int PartialRatio;

            PartialRatio = FuzzySharp.Fuzz.PartialRatio(firstString, secondString);
            Console.WriteLine($"PartialRatio Comparison: {PartialRatio}");

        }

         public static string lcs(string a, string b)
        {
            a = stringNormalizer(a);
            b = stringNormalizer(b);
            var lengths = new int[a.Length, b.Length];
            int greatestLength = 0;
            string output = "";
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    {
                        lengths[i, j] = i == 0 || j == 0 ? 1 : lengths[i - 1, j - 1] + 1;
                        if (lengths[i, j] > greatestLength)
                        {
                            greatestLength = lengths[i, j];
                            output = a.Substring(i - greatestLength + 1, greatestLength);
                        }
                    }
                    else
                    {
                        lengths[i, j] = 0;
                    }
                }
            }
            return output;
        }
         public static string stringNormalizer(string a)
         {
             a = a.ToUpper();
             //a = a.Trim();
             //a = a.Replace(" ", "");
             //a = a.Replace(".", "");
             //a = a.Replace(",", "");
             //a = a.Replace("'", "");

             return a;
         }
    }
}
