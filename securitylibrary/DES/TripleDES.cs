using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary.DES
{
    /// <summary>
    /// If the string starts with 0x.... then it's Hexadecimal not string
    /// </summary>
    public class TripleDES : ICryptographicTechnique<string, List<string>>
    {
       
        public string Decrypt(string cipherText, List<string> key)
        {
            //  throw new NotImplementedException();
            DES des = new DES();
            string res, res1, res2;
            res = des.Decrypt(cipherText, key[1]);
            res1 = des.Encrypt(res, key[0]);
            res2 = des.Decrypt(res1, key[1]);
            return res2;
        }

        public string Encrypt(string plainText, List<string> key)
        {
            //throw new NotImplementedException();
            DES des2 = new DES();
            string res, res1, res2;
            res = des2.Encrypt(plainText, key[0]);
            res1 = des2.Decrypt(res, key[1]);
            res2 = des2.Encrypt(res1, key[0]);
            return res2;
        }

        public List<string> Analyse(string plainText, string cipherText)
        {
            throw new NotSupportedException();
        }

    }
}