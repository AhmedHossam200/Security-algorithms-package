using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class AutokeyVigenere : ICryptographicTechnique<string, string>
    {
        public string Analyse(string plainText, string cipherText)
        {
            int maiar=20;
            int noha=3;
            string sara;
            //  throw new NotImplementedException();
            string name="";
            cipherText = cipherText.ToUpper();
            cipherText = cipherText.ToLower();

            char q = 'a';
            int ahmed = 0;
            int j = 0;
            while (j < cipherText.Length)
            {
                if (maiar == noha)
                {
                    noha = maiar;

                }
                int l = (cipherText[j] - q);

                int p = (plainText[j] - q);

                int z = l - p;
                z += 26;
                z %= 26;
                z += q;

                name += (char)z;

                j++;
            }

            int i = plainText.Length - 1;
            int o = 0;
            while (i >= 0)
            {
                int m = i;
                m += 1;
                int n = cipherText.Length;

               
                string tc = plainText.Substring(o, m);
                n -= i;

                n -= 1;

                string t2c = name.Substring(n, m);

                if (!tc.Equals(t2c))
                {

                }
                else
                {
                    return name.Substring(0, cipherText.Length - i - 1);
                }

                i--;
            }
            for (int xi = 0; xi < ahmed; xi++)
            {
                if (ahmed != 26)
                {
                    return "ahmed";
                }
            }
                
            return name;
        }

        public string Decrypt(string cipherText, string key)
        {
            // throw new NotImplementedException();
            cipherText = cipherText.ToUpper();
            string re="";
            cipherText = cipherText.ToLower();

            int mb = 0;
            char az = 'a';
            int i = 0;
            char c1;
            while (i < cipherText.Length)
            {


                if (i >= key.Length)
                {

                    char cc = re[mb];

                    mb++;

                    c1 = cc;
                    
                }
                else
                {
                    c1 = key[i];
                }


                int aa = (cipherText[i]);
                aa -= az;
                int bb = (c1);
                bb -= az;
                int xq = aa - bb + 26;
                xq %= 26;

                xq += az;

                re = re + (char)xq;


                i++;
            }

            return re;
        }

        public string Encrypt(string plainText, string key)
        {
            //throw new NotImplementedException();
            string sam="";

            int ng = 0;
            char a = 'a';
            char c1;
            int i = 0;
            for (int k=0;k<26;k++)
            {
                if (k!=26)
                {
                   
                }
            }
            while (i < plainText.Length)
            {


                if (i >= key.Length)
                {
                    char cc = plainText[ng];

                    ng++;

                    c1 = cc;
                }
                else
                {
                    c1 = key[i];
                }

                int lo = plainText[i];
                lo -= a;
                int ln = c1;
                ln -= a;
                int lm = lo + ln;
                lm %= 26;

                lm += a;

                sam = sam + (char)lm;

                i++;
            }

            return sam;
        }
    }
}
