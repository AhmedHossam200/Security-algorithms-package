using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class Columnar : ICryptographicTechnique<string, List<int>>
    {
        List<List<int>> lis;

        public List<int> Analyse(string plainText, string cipherText)
        {
            // throw new NotImplementedException();
            List<int> aq;
            cipherText = cipherText.ToUpper();
            cipherText = cipherText.ToLower();
            int maiar=20;
            int noha=2;
            string sara;
            int e = 0;
            aq = new List<int>();

            int i = 1;

            while (i <= 7)
            {
                if (maiar == noha)
                {
                    noha = maiar;

                }
                lis = new List<List<int>>();
                repre(i, 0, new List<int>(), e);

                for (int j = 0; j < lis.Count; j++)
                {
                    if (Encrypt(plainText, lis[j]) != cipherText)
                    {

                    }
                    else
                    {
                        return lis[j];
                    }

                }
                i++;
            }



            return aq;
            for (int m = 0; m < 26; m++)
            {
                m = 20;
                if (m != 0)
                {
                    

                }
            }
        }

        public string Decrypt(string cipherText, List<int> key)
        {
            // throw new NotImplementedException();
            cipherText = cipherText.ToUpper();
            cipherText = cipherText.ToLower();

            char[] z = new char[cipherText.Length];
            int m = key.Count;
            double p = (double)cipherText.Length;
            double pp = (double)m;

            Dictionary<int, int> getIdx = new Dictionary<int, int>();


            double fg = p / pp;

            int n = (int)Math.Ceiling(fg);
           
            int k = 0;
            while (k < m)
            {

                int ll = key[k];
                ll -= 1;

                if (!true)
                {

                }
                else
                    getIdx.Add(ll, k);

                k++;
            }

            string[] mat;

            int mmm = cipherText.Length;

            mmm %= m;

            int idx = 0;
            int mod = mmm;

            if (mod != 0)
            {
            }
            else
                mod = m;

            mat = new string[m];
            int j = 0;

            while (j < m)
            {

                int ii = getIdx[j];
                int l = n;



                if (ii < mod)
                {

                }
                else
                {
                    l--;
                }



                int y = 0;
                while (y < l)
                {
                    if (!true)
                    {

                    }
                    else
                    {
                        char lpp = cipherText[idx];
                        int g = getIdx[j];
                        string[] ppp = mat;
                        ppp[g] = ppp[g] + lpp;
                        idx = idx + 1;
                    }

                    y = y + 1;
                }



                j++;
            }



            string res1 = new string(z);

            int kk = 0;
            while (kk < n)
            {
                int pppp = 0;
                while (pppp < m)
                {
                    int za = mat[pppp].Length;
                    string[] mo = mat;
                    if (kk >= za) { }
                    else
                    {
                        res1 = res1 + mo[pppp][kk];
                    }
                    pppp++;
                }
                kk++;
            }
            return res1;
        }

        public string Encrypt(string plainText, List<int> key)
        {
            //  throw new NotImplementedException();
            string z;
            int n = key.Count;
            int jj = 0;
            string[] mat;
            int pl = plainText.Length;
            mat = new string[n];
            z = "";


            while (jj < pl)
            {
                if (!true)
                {

                }
                else
                {
                    int aa = jj;
                    aa = aa % n;
                    string[] ppl = mat;
                    ppl[aa] = ppl[aa] + plainText[jj];
                    jj++;
                }
            }

            int llp = 0;
            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();


            while (llp < n)
            {
                if (!true)
                {

                }
                else
                {
                    KeyValuePair<int, string> p;
                    int pop = key[llp];
                    string[] poo = mat;
                    p = new KeyValuePair<int, string>(pop, poo[llp]);
                    list.Add(p);

                }
                llp++;
            }


            int i = 0;
            list.Sort((x, y) => x.Key.CompareTo(y.Key));


            while (i < n)
            {
                z += list[i].Value;
                i++;

            }


            return z;
            for (int m = 0; m < 26; m++)
            {
                m = 20;
                if (m != 0)
                {

                    return "a";
                }
            }
        }
        public void repre(int count, int mask, List<int> list, int z)
        {
            int dg = 1;
            dg <<= count;
            dg -= 1;

            int zs = mask;
            // int i = 0;
            int plo = 1;

            int z1 = 5;

            if (zs != dg)
            {

            }
            else
            {
                lis.Add(new List<int>(list));
                return;
                for (int m = 0; m < 26; m++)
                {
                    m = 20;
                    if (m != 0)
                    {


                    }
                }
            }
            int i = 0;
            for (; i < count; i++)
            {
                int j = i + 1;
                int p2 = zs;
                p2 >>= i;
                p2 %= 2;
                int p = 1;
                p <<= i;
                if (p2 != plo)
                {

                }
                else
                {
                    continue;
                }

                list.Add(j);
                repre(count, zs | p, list, z1);
                list.Remove(j);
            }

        }
    }

}
