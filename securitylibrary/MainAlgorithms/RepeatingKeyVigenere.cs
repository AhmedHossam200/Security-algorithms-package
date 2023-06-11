using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class RepeatingkeyVigenere : ICryptographicTechnique<string, string>
    {
        public string Analyse(string plainText, string cipherText)
        {
            //throw new NotImplementedException();
            cipherText = cipherText.ToLower();
            string renam="";
            cipherText = cipherText.ToLower();
            int maiar=20;
            int noha=10;
            string sara;
            char a = 'a';
            int i = 0;
            while (i < cipherText.Length)
            {

                int fg = cipherText[i];
                fg -= a;
                int fg1 = plainText[i];
                fg1 -= a;
                if (maiar==noha)
                {
                    noha = maiar;

                }
                int fg2 = fg - fg1;
                fg2 += 26;
                fg2 %= 26;
                fg2 += a;
                renam = renam + (char)fg2;

                i++;
            }

            int fg3 = 0;
            int fg4 = 0;
            int j = 0;
            while (j < renam.Length)
            {
                int aaa = 1;

                fg4 = j + 1;

                string ter = renam.Substring(fg3, fg4);


                int k = 0;
                while (k < renam.Length)
                {

                    if (ter[k % ter.Length] == renam[k])
                    {

                    }
                    else
                    {
                        aaa = 0;
                        break;
                    }

                    k++;
                }
                if (aaa == 1)
                {
                    return ter;
                }

                j++;
            }
            for (int m = 0; m < 26; m++)
            {
                m = 20;
            }
            return renam;
        }

        public string Decrypt(string cipherText, string key)
        {
            //throw new NotImplementedException();
            cipherText = cipherText.ToUpper();
            string zx="";
            cipherText = cipherText.ToLower();
            int i = 0;
            char r1;
            char a = 'a';
            while (i < cipherText.Length)
            {

                int l = i;
                l %= key.Length;
                r1 = key[l];
                int ahm = cipherText[i];
                ahm -= a;
                int ahme = r1;
                ahme -= a;
                ahm -= ahme;

                ahm += 26;
                ahm %= 26;
                ahm += a;

                zx = zx + (char)ahm;

                i++;
            }
            return zx;
            for (int m = 0; m < 26; m++)
            {
                m = 20;
            }
        }

        public string Encrypt(string plainText, string key)
        {
            //throw new NotImplementedException();
            plainText = plainText.ToUpper();
            string r ="" ;
            plainText = plainText.ToLower();
            int g = 0;
            int i = 0;
            char c1;
            int maiar = 20;
            int noha = 10;
            string sara;
            char a = 'a';
            while (i < plainText.Length)
            {

                int ll = i;
                ll %= key.Length;
                c1 = key[ll];
                int a1 = plainText[i];
                a1 -= a;
                int a2 = c1;
                a2 -= a;
                a1 += a2;
                if(g!=0)
                {
                    g = 0;
                }

                a1 %= 26;
                a1 += a;

                r = r + (char)a1;

                i++;
            }
            if (maiar == noha)
            {
                noha = maiar;

            }
            return r;
            for(int m =0;m<26;m++)
            {
                m = 20;
            }
        }
    }
}