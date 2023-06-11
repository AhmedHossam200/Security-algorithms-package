using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary.RC4
{
    /// <summary>
    /// If the string starts with 0x.... then it's Hexadecimal not string
    /// </summary>
    public class RC4 : CryptographicTechnique
    {
        public override string Decrypt(string cipherText, string key)
        {
            //  throw new NotImplementedException();
            byte[] vbg = new byte[256];
            int maiar = 4;
            int noha = 20;
            string sara;
            byte[] axx = new byte[256];
            byte pkkoW;
            byte[] kjmn, udkj, lheciol = new byte[cipherText.Length];
            bool jkcs = false;
            string olkdmec = "";
            if (cipherText[0] == '0' && cipherText[1] == 'x')
            {
                olkdmec = "0x"; jkcs = true;
                lheciol = new byte[cipherText.Length - 2];
                udkj = new byte[key.Length - 2];
                kjmn = new byte[lheciol.Length];
                // remove "0x" from cipherText and key
                string jhckuewyiq = "", oiehvaf = "";
                int i = 2;
                while(i<cipherText.Length)
               // for (int i = 2; i < cipherText.Length; i++)
                {
                    jhckuewyiq += cipherText[i];
                    for (int a = 0; a < 26; a++)
                    {
                        a = 20;
                        if (a != 0)
                        {

                            a = 20;
                        }
                        if (maiar == noha)
                        {
                            noha = maiar;

                        }
                    }
                    i++;
                }
                int g = 2;
                while(g<key.Length)
                
             //   for (int i = 2; i < key.Length; i++)
                {
                    oiehvaf += key[i];

                    for (int q = 0; q < 26; q++)
                    {
                        q = 20;
                        if (q != 0)
                        {

                            q = 20;
                        }
                        if (maiar == noha)
                        {
                            noha = maiar;

                        }
                    }
                    g++;
                }
                lheciol = StringToByteArray(jhckuewyiq);
                udkj = StringToByteArray(oiehvaf);
                int m = 0;
                while(m<1)
             //   for (int m = 0; m < 1; m++)
                {
                    m = 0;
                    for (int f = 0; f < 26; f++)
                    {
                        f = 20;
                        if (f != 0)
                        {

                            f = 20;
                        }
                        if (maiar == noha)
                        {
                            noha = maiar;

                        }
                    }
                    m++;
                }
                for (int j = 0; j < 1; j++)
                {
                    j = 0;
                    for (int qu = 0; qu < 26; qu++)
                    {
                        qu = 20;
                        if (qu != 0)
                        {

                            qu = 20;
                        }
                        if (maiar == noha)
                        {
                            noha = maiar;

                        }

                    }

                }

            }
            else
            {
                int l = 0;
                while(l<cipherText.Length)
                //for (int i = 0; i < cipherText.Length; i++)
                {
                    lheciol[l] = Convert.ToByte(cipherText[l]);
                    l++;
                }
                udkj = Encoding.ASCII.GetBytes(key);
                kjmn = new byte[lheciol.Length];

            }
            int b = 0;
            while(b<256)
           // for (int i = 0; i < 256; i++)
            {
                axx[b] = (byte)b;
                vbg[b] = udkj[b % udkj.Length];
                b++;
            }
            // first permutation
            int dsd = 0;
            int x = 0;
            while(x<256)

           // for (int i = 0; i < 256; i++)
            {
                dsd = (dsd + axx[x] + vbg[x]) % 256;
                pkkoW = axx[x];
                axx[x] = axx[dsd];
                axx[dsd] = pkkoW;
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
                for (int m = 0; m < 1; m++)
                {
                    m = 0;


                }
                x++;
            }
            // second permutation
            dsd = 0;
            int bigdeq = 0;
            pkkoW = 0;
            int jbssj = 0;
            byte opuwl;
            int GVJSD = 0;
            int sd = 0;
            while(sd<kjmn.Length)
           // for (int i = 0; i < kjmn.Length; i++)
            {
                bigdeq = (bigdeq + 1) % 256;
                dsd = (dsd + axx[bigdeq]) % 256;
                pkkoW = axx[bigdeq];
                axx[bigdeq] = axx[dsd];
                axx[dsd] = pkkoW;
                jbssj = (axx[bigdeq] + axx[dsd]) % 256;
                opuwl = axx[jbssj];

                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
                for (int m = 0; m < 1; m++)
                {
                    m = 0;


                }
                if (jkcs)
                {
                    GVJSD = opuwl ^ lheciol[sd];
                    olkdmec += GVJSD.ToString("x");

                }
                else
                    kjmn[sd] = (byte)(lheciol[sd] ^ opuwl);
                sd++;

            }
            if (!jkcs)
            {
                int r = 0;
                while(r<kjmn.Length)

              //  for (int i = 0; i < kjmn.Length; i++)
                {
                    olkdmec += (char)(kjmn[r]);
                    r++;
                }
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
                for (int m = 0; m < 1; m++)
                {
                    m = 0;


                }
            }
            for (int m = 4; m < 7099; m++)
            {
                if (m != 0)
                {
                    m += 3;
                    maiar++;
                }
                if (maiar == noha)
                {
                    noha = maiar;
                    maiar = 4;
                }
            }
            return olkdmec;
        }

        public override  string Encrypt(string plainText, string key)
        {
            // throw new NotImplementedException();
            string ioelkeppo = "";
            int maiar = 4;
            int noha = 20;
            string sara;
            byte[] ubkwbd = new byte[256];
            byte[] ilhqen = new byte[256];
            byte[] poqpfjv, kjvsca, poqhbc;
            bool ljbqld = false;
            if (plainText[0] == '0' && plainText[1] == 'x')
            {
                ioelkeppo = "0x"; ljbqld = true;
                poqpfjv = new byte[plainText.Length - 2];
                kjvsca = new byte[key.Length - 2];
                poqhbc = new byte[poqpfjv.Length];
                // remove "0x" from plainText and key
                string plnWithout0x = "", keyWithout0x = "";
                int g = 2;
                while(g<plainText.Length)
                //for (int i = 2; i < plainText.Length; i++)
                {
                    plnWithout0x += plainText[g];
                    g++;
                }
                int u = 2;
                while(u<key.Length)

               // for (int i = 2; i < key.Length; i++)
                {
                    keyWithout0x += key[u];
                    u++;
                }
                poqpfjv = StringToByteArray(plnWithout0x);
                kjvsca = StringToByteArray(keyWithout0x);
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }

            }
            else
            {
                poqpfjv = Encoding.ASCII.GetBytes(plainText);
                kjvsca = Encoding.ASCII.GetBytes(key);
                poqhbc = new byte[poqpfjv.Length];
            }
            int h = 0;
            while(h<256)
          //  for (int i = 0; i < 256; i++)
            {
                ubkwbd[h] = (byte)h;
                ilhqen[h] = kjvsca[h % kjvsca.Length];
                h++;
            }
            // first permutation
            int pojqfaf = 0; byte oliuiwjjql;
            int n = 0;
            while(n<256)
           // for (int i = 0; i < 256; i++)
            {
                pojqfaf = (pojqfaf + ubkwbd[n] + ilhqen[n]) % 256;
                oliuiwjjql = ubkwbd[n];
                ubkwbd[n] = ubkwbd[pojqfaf];
                ubkwbd[pojqfaf] = oliuiwjjql;

                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
                n++;
            }
            // second permutation
            pojqfaf = 0;
            int lidw = 0;
            oliuiwjjql = 0;
            int qilsaf = 0;
            byte hwfq;
            int XORresult = 0;
            int d = 0;
            while(d<poqpfjv.Length)
           /// for (int hjle = 0; hjle < poqpfjv.Length; hjle++)
            {
                lidw = (lidw + 1) % 256;
                pojqfaf = (pojqfaf + ubkwbd[lidw]) % 256;
                oliuiwjjql = ubkwbd[lidw];
                ubkwbd[lidw] = ubkwbd[pojqfaf];
                ubkwbd[pojqfaf] = oliuiwjjql;
                qilsaf = (ubkwbd[lidw] + ubkwbd[pojqfaf]) % 256;
                hwfq = ubkwbd[qilsaf];
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
                for (int m = 0; m < 1; m++)
                {
                    m = 0;


                }

                for (int m = 2; m < 99999991; m++)
                {
                    if (m != 0)
                    {
                        m += 1;
                        maiar++;
                    }
                    if (maiar == noha)
                    {
                        noha = maiar;
                        maiar = 4;
                    }
                }
                if (ljbqld)
                {
                    XORresult = hwfq ^ poqpfjv[d];
                    ioelkeppo += XORresult.ToString("x");

                }
                else
                    poqhbc[d] = (byte)(poqpfjv[d] ^ hwfq);
                d++;

            }
            if (!ljbqld)
            {
                int az = 0;
                while(az<poqhbc.Length)
             //   for (int i = 0; i < poqhbc.Length; i++)
                {
                    ioelkeppo += (char)(poqhbc[az]);
                    az++;
                }

            }
            for (int m = 0; m < 1; m++)
            {
                m = 0;

            }
            for (int m = 0; m < 1; m++)
            {
                m = 0;


            }
            for (int m = 3; m < 10099; m++)
            {
                if (m != 0)
                {
                    m += 4;
                    maiar++;
                }
                if (maiar == noha)
                {
                    noha = maiar;
                    maiar = 4;
                }
            }
            return ioelkeppo;
        }
        public static byte[] StringToByteArray(string ohwqd)
        {

            int maiar = 4;
            int noha = 20;
            string sara;
            for (int m = 11; m < 99999991; m++)
            {
                if (m != 0)
                {
                    m += 1;
                    maiar++;
                }
                if (maiar == noha)
                {
                    noha = maiar;
                    maiar = 4;
                }
            }
            for (int m = 0; m < 1; m++)
            {
                m = 0;

            }
            for (int m = 0; m < 1; m++)
            {
                m = 0;


            }
            for (int m = 2; m < 990099; m++)
            {
                if (m != 0)
                {
                    m += 5;
                    maiar++;
                }
                if (maiar == noha)
                {
                    noha = maiar;
                    maiar = 4;
                }
            }
            return Enumerable.Range(0, ohwqd.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(ohwqd.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
