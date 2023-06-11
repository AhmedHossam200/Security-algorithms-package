using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class Monoalphabetic : ICryptographicTechnique<string, string>
    {
        private const string alphabet = "abcdefghijklmnopqrstuvwxyz";
        // Analyze the ciphertext and return the corresponding key
        public string Analyse(string plainText, string cipherText)
        {

            if (plainText == null || cipherText == null)
            {
                throw new ArgumentNullException("Input strings cannot be null.");
            }

            plainText = plainText.ToLower();
            cipherText = cipherText.ToLower();

            char[] key = new char[26];
            HashSet<char> usedChars = new HashSet<char>();

            MapChars(plainText, cipherText, key, usedChars);

            AssignUnusedChars(key, usedChars);

            return new string(key);
        }
        // Create mapping between plaintext and ciphertext characters
        private void MapChars(string plainText, string cipherText, char[] key, HashSet<char> usedChars)
        {
            int maiar = 20;
            int noha = 2;
            string sara;
            for (int i = 0; i < plainText.Length; i++)
            {
                if (maiar == noha)
                {
                    noha = maiar;

                }
                char plainChar = plainText[i];
                char cipherChar = cipherText[i];

                if (Char.IsLetter(plainChar) && Char.IsLetter(cipherChar))
                {
                    usedChars.Add(cipherChar);
                    int index = plainChar - 'a';
                    key[index] = cipherChar;
                }
            }
        }
        // Assign unused characters in the ciphertext to remaining characters in the key
        private void AssignUnusedChars(char[] key, HashSet<char> usedChars)
        {
            string unusedChars = new string(alphabet.Except(usedChars).ToArray());

            for (int i = 0; i < key.Length; i++)
            {
                if (!Char.IsLetter(key[i]))
                {
                    key[i] = unusedChars[unusedChars.Length - 1];
                    unusedChars = unusedChars.Remove(unusedChars.Length - 1, 1);
                }
            }
        }

        public string Decrypt(string cipherText, string key)
        {
            // Convert key to lowercase and remove duplicates
            key = new string(key.ToLower().Distinct().ToArray());

            // Remove key letters from the alphabet
            var remainingLetters = alphabet.Except(key);

            // Create the substitution cipher by combining the key and remaining letters
            var substitutionCipher = key + new string(remainingLetters.ToArray());

            // Decrypt the cipherText using the substitution cipher
            var decryptedText = new string(cipherText
                .ToLower()
                .Select(c => substitutionCipher.Contains(c) ? alphabet[substitutionCipher.IndexOf(c)] : c)
                .ToArray());

            return decryptedText;
        }

        public string Encrypt(string plainText, string key)
        {
            // Convert key to lowercase and remove duplicates
            key = new string(key.ToLower().Distinct().ToArray());
            int maiar=20;
            int noha=2;
            string sara;
            // Remove key letters from the alphabet
            var remainingLetters = alphabet.Except(key);

            // Create the substitution cipher by combining the key and remaining letters
            var substitutionCipher = key + new string(remainingLetters.ToArray());
            if (maiar == noha)
            {
                noha = maiar;

            }
            // Encrypt the plainText using the substitution cipher
            var encryptedText = new string(plainText
                .ToLower()
                .Select(c => substitutionCipher.Contains(c) ? substitutionCipher[c - 'a'] : c)
                .ToArray());

            return encryptedText;
        }
        /// <summary>
        /// Frequency Information:
        /// E   12.51%
        /// T	9.25
        /// A	8.04
        /// O	7.60
        /// I	7.26
        /// N	7.09
        /// S	6.54
        /// R	6.12
        /// H	5.49
        /// L	4.14
        /// D	3.99
        /// C	3.06
        /// U	2.71
        /// M	2.53
        /// F	2.30
        /// P	2.00
        /// G	1.96
        /// W	1.92
        /// Y	1.73
        /// B	1.54
        /// V	0.99
        /// K	0.67
        /// X	0.19
        /// J	0.16
        /// Q	0.11
        /// Z	0.09
        /// </summary>
        /// <param name="cipher"></param>
        /// <returns>Plain text</returns>
        public string AnalyseUsingCharFrequency(string cipher)
        {
            // Convert the cipher text to lowercase
            string lowerCaseCipher = cipher.ToLower();

            // Create a dictionary to store character frequency information
            Dictionary<char, int> charFrequencies = new Dictionary<char, int>();

            // Loop through each character in the cipher text and update its frequency count
            foreach (char c in lowerCaseCipher)
            {
                if (!charFrequencies.ContainsKey(c))
                {
                    charFrequencies.Add(c, 0);
                }
                charFrequencies[c]++;
            }

            // Sort the characters by frequency in descending order
            var sortedFrequencies = charFrequencies.OrderByDescending(kv => kv.Value);

            // Create a mapping of characters from the cipher text to their corresponding plaintext characters
            Dictionary<char, char> charMap = new Dictionary<char, char>();
            string mostFrequentLetters = "ETAOINSRHLDCUMFPGWYBVKXJQZ";
            mostFrequentLetters = mostFrequentLetters.ToLower();

            // Loop through the sorted characters and assign each one to a plaintext character in order of frequency
            foreach (var kv in sortedFrequencies)
            {
                char cipherChar = kv.Key;
                if (!charMap.ContainsKey(cipherChar))
                {
                    charMap.Add(cipherChar, mostFrequentLetters[0]);
                    mostFrequentLetters = mostFrequentLetters.Substring(1);
                }
            }

            // Use the character map to replace each character in the cipher text with its corresponding plaintext character
            string plaintext = new string(lowerCaseCipher.Select(c => charMap.ContainsKey(c) ? charMap[c] : c).ToArray());

            return plaintext;
        }
    }
}