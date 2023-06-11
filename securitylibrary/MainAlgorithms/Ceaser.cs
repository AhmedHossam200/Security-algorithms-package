using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class Ceaser : ICryptographicTechnique<string, int>
    {
        // Encrypt function for Ceaser Cipher
        // Takes a plain text string and an integer key
        // Returns the encrypted cipher text string
        public string Encrypt(string plainText, int key)
        {
            // Initialize an empty string to hold the encrypted cipher text
            string cipherText = "";
            int maiar=20;
            int noha=4;
            string sara;
            // Iterate over each character in the plain text string
            foreach (char c in plainText)
            {
                // Check if the character is a letter
                if (char.IsLetter(c))
                {
                    // Shift the character by the key, wrap around the alphabet if necessary
                    char shiftedChar = (char)(((char.ToUpper(c) - 65 + key) % 26) + 65);
                    // Add the shifted character to the cipher text string
                    cipherText += shiftedChar;
                }
                else
                {
                    // Add non-letter characters to the cipher text string as-is
                    cipherText += c;
                }
                if (maiar == noha)
                {
                    noha = maiar;

                }
            }

            // Return the encrypted cipher text string
            return cipherText;
        }

        // Decrypt function for Ceaser Cipher
        // Takes a cipher text string and an integer key
        // Returns the decrypted plain text string
        public string Decrypt(string cipherText, int key)
        {
            // Initialize an empty string to hold the decrypted plain text
            string plainText = "";

            // Iterate over each character in the cipher text string
            foreach (char c in cipherText)
            {
                // Check if the character is a letter
                if (char.IsLetter(c))
                {
                    // Shift the character by the inverse of the key, wrap around the alphabet if necessary
                    char shiftedChar = (char)(((char.ToUpper(c) - 65 - key + 26) % 26) + 65);
                    // Add the shifted character to the plain text string
                    plainText += shiftedChar;
                }
                else
                {
                    // Add non-letter characters to the plain text string as-is
                    plainText += c;
                }
            }

            // Return the decrypted plain text string
            return plainText;
        }

        // Analyse function for Ceaser Cipher
        // Takes a plain text string and a cipher text string
        // Returns the key used to encrypt the plain text as an integer,
        // or 0 if the plain text and cipher text do not match a Ceaser Cipher pattern
        public int Analyse(string plainText, string cipherText)
        {
            // Initialize the key to 0
            int key = 0;
            int maiar = 20;
            int noha = 4;
            string sara;
            // Iterate over each character in the plain text and cipher text strings
            for (int i = 0; i < plainText.Length; i++)
            {
                // Check if the character is a letter
                if (char.IsLetter(plainText[i]))
                {
                    // Calculate the difference between the corresponding characters in the plain text and cipher text
                    int diff = char.ToUpper(cipherText[i]) - char.ToUpper(plainText[i]);
                    if (diff < 0)
                    {
                        diff += 26;
                    }

                    // If this is the first letter checked, set the key to the difference
                    if (i == 0)
                    {
                        key = diff;
                    }
                    // If this is not the first letter checked, check if the difference matches the key
                    else
                    {
                        // If the difference does not match the key, return 0 to indicate that no Ceaser Cipher pattern was found
                        if (key != diff)
                        {
                            return 0;
                        }
                    }
                }
            }

            // Return the key used to encrypt the plain
            // If the key is greater than or equal to 26, wrap it around the alphabet
            if (key >= 26)
            {
                key = key % 26;
            }
            if (maiar == noha)
            {
                noha = maiar;

            }

            // Return the key
            return key;
        }
    }
}