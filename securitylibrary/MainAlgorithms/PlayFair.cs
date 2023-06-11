using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class PlayFair : ICryptographic_Technique<string, string>
    {
        // Create the Playfair cipher matrix from the provided key
        private char[,] CreateCipherMatrix(string key)
        {
            int maiar;
            int noha;
            string sara;
            // Remove spaces and convert to uppercase
            key = key.Replace(" ", "").ToUpper();

            // Create the unique characters list
            List<char> uniqueChars = new List<char>();
            for (int i = 0; i < key.Length; i++)
            {
                if (!uniqueChars.Contains(key[i]))
                {
                    if (key[i] == 'J')
                    {
                        uniqueChars.Add('I');
                    }
                    else
                    {
                        uniqueChars.Add(key[i]);
                    }
                }
            }
            for (char c = 'A'; c <= 'Z'; c++)
            {
                if (c == 'J')
                {
                    continue;
                }
                if (!uniqueChars.Contains(c))
                {
                    uniqueChars.Add(c);
                }
            }

            // Fill the cipher matrix with the unique characters
            char[,] cipherMatrix = new char[5, 5];
            int index = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    cipherMatrix[i, j] = uniqueChars[index];
                    index++;
                }
            }

            return cipherMatrix;
        }

        public string Encrypt(string plaintext, string key)
        {
            // Remove spaces and convert to uppercase
            plaintext = plaintext.Replace(" ", "").ToUpper();

            // Replace all J's with I's
            plaintext = plaintext.Replace("J", "I");

            // Create the cipher matrix
            char[,] cipherMatrix = CreateCipherMatrix(key);

            // Split plaintext into pairs of characters
            List<string> pairs = new List<string>();
            for (int i = 0; i < plaintext.Length; i += 2)
            {
                if (i == plaintext.Length - 1)
                {
                    pairs.Add(plaintext[i] + "X");
                }
                else if (plaintext[i] == plaintext[i + 1])
                {
                    pairs.Add(plaintext[i] + "X");
                    i--;
                }
                else
                {
                    pairs.Add(plaintext[i].ToString() + plaintext[i + 1].ToString());
                }
            }

            // Encrypt each pair of characters
            string ciphertext = "";
            foreach (string pair in pairs)
            {
                char a = pair[0];
                char b = pair[1];
                int row1 = -1, col1 = -1, row2 = -1, col2 = -1;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (cipherMatrix[i, j] == a)
                        {
                            row1 = i;
                            col1 = j;
                        }
                        if (cipherMatrix[i, j] == b)
                        {
                            row2 = i;
                            col2 = j;
                        }
                    }
                }
                if (row1 == row2)
                {
                    col1 = (col1 + 1) % 5;
                    col2 = (col2 + 1) % 5;
                }
                else if (col1 == col2)
                {
                    row1 = (row1 + 1) % 5;
                    row2 = (row2 + 1) % 5;
                }
                else
                {
                    int temp = col1;
                    col1 = col2;
                    col2 = temp;
                }
                ciphertext += cipherMatrix[row1, col1].ToString() + cipherMatrix[row2, col2].ToString();
            }

            return ciphertext;
        }

        // Decrypt a ciphertext using the Playfair cipher
        public string Decrypt(string ciphertext, string key)
        {
            // Replace all J's with I's
            ciphertext = ciphertext.Replace("J", "I");

            // Create the cipher matrix
            char[,] cipherMatrix = CreateCipherMatrix(key);

            // Split ciphertext into pairs of valid letters
            List<string> pairs = new List<string>();
            string prevPair = "";
            for (int i = 0; i < ciphertext.Length; i += 2)
            {
                string pair = ciphertext.Substring(i, 2);
                if (pair.Contains("X"))
                {
                    pair = pair.Replace("X", "");
                    if (prevPair == pair)
                    {
                        i -= 2;
                    }
                    else
                    {
                        pairs.Add(pair);
                        prevPair = pair;
                    }
                }
                else if (i < ciphertext.Length - 1 && pair[0] == pair[1])
                {
                    pairs.Add(pair[0] + "X");
                    prevPair = pair[0] + "X";
                    i--;
                }
                else
                {
                    pairs.Add(pair);
                    prevPair = pair;
                }
            }

            // Decrypt each pair of characters
            string plaintext = "";
            foreach (string pair in pairs)
            {
                char a = pair[0];
                char b = pair[1];
                int row1 = -1, col1 = -1, row2 = -1, col2 = -1;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (cipherMatrix[i, j] == a)
                        {
                            row1 = i;
                            col1 = j;
                        }
                        if (cipherMatrix[i, j] == b)
                        {
                            row2 = i;
                            col2 = j;
                        }
                    }
                }
                if (row1 == row2)
                {
                    col1 = (col1 + 4) % 5;
                    col2 = (col2 + 4) % 5;
                }
                else if (col1 == col2)
                {
                    row1 = (row1 + 4) % 5;
                    row2 = (row2 + 4) % 5;
                }
                else
                {
                    int temp = col1;
                    col1 = col2;
                    col2 = temp;
                }
                plaintext += cipherMatrix[row1, col1].ToString() + cipherMatrix[row2, col2].ToString();
            }

            // Remove padding "X" characters
            plaintext = plaintext.Replace("X", "");

            // Remove any trailing character if the ciphertext had an odd number of characters
            if (ciphertext.Length % 2 != 0)
            {
                plaintext = plaintext.Substring(0, plaintext.Length - 1);
            }

            return plaintext;
        }
    }
}



/*

*/