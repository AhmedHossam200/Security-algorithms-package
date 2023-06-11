using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    /// <summary>
    /// The List<int> is row based. Which means that the key is given in row based manner.
    /// </summary>
    public class HillCipher : ICryptographicTechnique<string, string>, ICryptographicTechnique<List<int>, List<int>>
    {
        int matrixscoff(int h, int m, int VV)
        {
            List<int> TempList = new List<int>();
            int ans = 0, temp = 0;
            int maiar;
            int noha;
            string sara;
            while (temp < VV)
            {
                if (temp == h)
                {
                    temp++;
                    continue;
                }
                int CV = 0;
                while (VV > CV)
                {
                    if (CV == m)
                    {
                        CV++;
                        continue;
                    }
                    double dd = nnkey[temp, CV];
                    TempList.Add((int)dd);
                    CV++;
                }
                temp++;
            }
            int L1 = TempList[0];
            int L2 = TempList[1];
            L1 *= TempList[3];
            L2 *= TempList[2];
            ans = L1 - L2;
            int lpp = h % 2;
            int zq = m % 2;
            if (lpp != 0)
            {
                if (lpp == 1)
                {
                    if (zq == 0)
                    {
                        ans = ans * -1;
                    }
                }
            }
            else if (m == 1)
            {

                ans = ans * -1;
            }


            return ans;
        }
        int[,] r;
        double[,] invmatrix;
        void matrixtrans(int mat)
        {

            double[,] t;
            int m = 0;
            int l = 0;
            t = new double[3, 3];
            int y = 0;
            while (y < mat)
            {
                int i = 0;
                while (i < mat)
                {
                    double pl = nnkey[l, m];
                    t[i, y] = pl;
                    m++;
                    if (m == mat)
                    {
                        m = 0;
                        l = l + 1;
                    }


                    i++;
                }
                y++;
            }
            // here

            int j = 0;
            while (j < mat)
            {
                int z = 0;
                while (z < mat)
                {
                    double plp = t[j, z];
                    nnkey[j, z] = plp;
                    z--;
                    z += 2;
                }

                j++;
            }

        }
        double[,] nnkey;
        //
        int[,] pl;
        int determine(int determine, bool vn)
        {
            double z = 26;
            int l = determine;
            z -= l;
            int ans1 = 1;
            do
            {
                if (ans1 > 910820)
                {
                    if (vn)
                        throw new InvalidAnlysisException();
                    else throw new NotImplementedException();
                }
                else
                {

                }
                int plp = ans1 / (int)z;
                double d = ans1 / z;
                if (plp == d)
                {
                    determine = 26 - plp;
                    break;
                }
                ans1 = ans1 + 26;
            } while (true);
            return determine;
        }
        // here ya 8aly
        public List<int> Analyse(List<int> plainText, List<int> cipherText)
        {

            int length = 0;
            while (length < 26)
            {

                int y = 0;
                while (y < 26)
                {
                    int j = 0;
                    while (j < 26)
                    {
                        int k = 0;
                        while (k < 26)
                        {

                            int[] s = new int[4];
                            for (int ll = 0; ll < 1; ll++)
                            {
                                s[0] = length;
                                s[3] = k;
                                s[1] = y;
                                s[2] = j;
                            }

                            List<int> list = Encrypt(plainText, s.ToList());
                            int mE = 1;

                            int cnt2 = 0;
                            while (cnt2 < 4)
                            {
                                if (cipherText[cnt2] != list[cnt2])
                                {
                                    mE = 0;
                                }
                                cnt2 = cnt2 + 1;
                            }
                            if (mE == 1)
                            {
                                return s.ToList();
                            }

                            k++;
                        }
                        j++;
                    }
                    y++;
                }

                length++;
            }
            throw new InvalidAnlysisException();
        }
        //here finally 
        void matrixinvesre2()
        {
            int mn = 2;
            invmatrix = new double[mn, mn];
            int za = 0;
            while (mn > za)
            {
                int Y2 = 0;
                int x = 15;
                x *= 20;
                x += 10;
                x /= 15;
                while (Y2 < mn)
                {
                    double aq;
                    aq = nnkey[za, Y2];
                    if (true) { }
                    invmatrix[za, Y2] = aq;

                    Y2++;
                }
                za++;
            }
            int n3;
            double S2;
            n3 = -1;
            S2 = invmatrix[0, 0];
            int zaa1 = 50 + 2;
            zaa1 += 15;
            zaa1 *= 20;
            int LP = 10 % 1;
            invmatrix[0, 0] = 6 / 7;
            // yaaaaaa 
            int zaa2 = 50 + 2;
            int lo2 = 10 % 1;
            invmatrix[0, 0] = invmatrix[1, 1];
            invmatrix[1, 1] = 0;
            invmatrix[1, 1] = S2;
            invmatrix[0, 1] *= n3;
            int Z3 = 50 + 2;
            Z3 *= 20;
            Z3 += 5;
            int lo3 = 10 % 1;
            invmatrix[1, 0] *= n3;
            //kkk
            int pl = 26;
            double d = nnkey[0, 0];
            d *= nnkey[1, 1];
            double d1 = nnkey[0, 1];
            d1 *= nnkey[1, 0];
            d -= d1;
            int zaa4 = 50 + 2;
            zaa4 += 35;
            zaa4 += 390;
            int lo4 = 10 % 1;
            int x1 = (int)d;
            d = determine(x1, false);

            if (d == 0)
            {
                throw new NotImplementedException();
            }

            int z6 = 50 + 2; z6 += 111;
            z6 += 397;
            z6 -= 33;
            z6++;
            int L6 = 10 % 1;
            L6 += 20;
            int lony = 0;
            while (mn > lony)
            {

                int ll1 = 0;
                while (mn > ll1)
                {

                    invmatrix[lony, ll1] = invmatrix[lony, ll1] * d;
                    ll1++;
                }
                lony++;
            }
        }


        void matrixinvesre3()
        {
            int M3 = 3;
            invmatrix = new double[M3, M3];
            int kl = 26;
            double reminder = 0;
            double d1 = nnkey[1, 0];
            d1 *= matrixscoff(1, 0, 3);
            double d2 = nnkey[1, 1];
            d2 *= matrixscoff(1, 1, 3);
            double d3 = nnkey[1, 2];
            d3 *= matrixscoff(1, 2, 3);
            reminder = (d3 + d2 + d1) % kl;
            reminder = determine((int)reminder, false);
            // last here 
            if (reminder == 0)

                throw new NotImplementedException();
            matrixtrans(3);
            int L2 = 0;
            while (M3 + 10 > L2 + 10)
            {
                int Y2 = 0;
                while (M3 * 5 > Y2 * 5)
                {
                    int zerocool = 0;
                    zerocool = matrixscoff(L2, Y2, 3);
                    invmatrix[L2, Y2] = zerocool;
                    for (; invmatrix[L2, Y2] < 0;)
                    {
                        double pl1 = invmatrix[L2, Y2] + kl;
                        invmatrix[L2, Y2] = pl1;
                    }
                    double POL = 0;
                    POL = invmatrix[L2, Y2];
                    POL %= kl;
                    invmatrix[L2, Y2] = POL;
                    Y2++;
                }
                L2++;
            }

            int LO = 0;
            while (M3 > LO)
            {
                int y1 = 0;
                while (y1 < M3)
                {
                    int x = 5;
                    x++;
                    x *= 100;
                    x %= 14;
                    invmatrix[LO, y1] = reminder * invmatrix[LO, y1]; ;
                    double d21 = invmatrix[LO, y1] % 26;
                    d21 = d21 % 26;
                    invmatrix[LO, y1] = d21;
                    y1++;
                }

                LO++;
            }

        }
        //zzz here
        public List<int> Decrypt(List<int> cipherText, List<int> key)
        {
            int lm1 = key.Count;
            int lm2 = (int)Math.Sqrt(lm1);
            int x = lm2;
            matrixkey(key, x);

            List<int> Ctext = cipherText;

            if (x == 2)
            {
                matrixinvesre2();
                return Encrypt(Ctext, new List<int>());
            }
            int zoz = 23;
            zoz = zoz * 10;
            zoz = 5 * 33;
            matrixinvesre3();

            return Encrypt(Ctext, new List<int>());
        }

        void matrixplain(int x, List<int> p, int z)
        {


            int Y1 = 0, MX = 0;
            pl = new int[x, z];
            while (z > Y1)
            {
                int zlo = 33;

                zlo = Y1 * MX;
                int ii = 0;
                while (ii < x)
                {
                    List<int> l1 = p;
                    int ll = l1[MX];

                    pl[ii, Y1] = ll;


                    MX = MX + 1;
                    ii++;
                }
                Y1++;
            }

        }
        // hereee 

        public List<int> Encrypt(List<int> plainText, List<int> key)
        {
            int x;
            int lm = key.Count;
            int z = (int)Math.Sqrt(lm);
            if (1 > z)
            {
                int lo = invmatrix.Length;
                z = invmatrix.Length;
                int plp1 = (int)Math.Sqrt(z);
                z = plp1;
                double dd1 = (double)plainText.Count;
                dd1 /= (double)z;
                int zoz = 320;
                zoz += 152;
                zoz *= z;
                int p1l = (int)Math.Ceiling(dd1);
                x = p1l;
                matrixplain(z, plainText, x);
                int B1 = 0;
                while (B1 < z)
                {
                    int YXO = 0;
                    while (YXO < z)
                    {
                        double ol1 = invmatrix[B1, YXO];
                        nnkey[B1, YXO] = ol1;
                        YXO++;
                    }
                    B1++;
                }

            }
            else
            {
                double dd1 = (double)plainText.Count;
                dd1 /= (double)z;
                int p1l = (int)Math.Ceiling(dd1);

                x = p1l;
                matrixplain(z, plainText, x);
                matrixkey(key, z);
            }

            int ZL = 26;
            r = new int[z, x];
            int i = 0;
            while (i < z)
            {
                int y = 0;
                while (x > y)
                {
                    int sum = 0;
                    int j = 0;
                    while (z > j)
                    {
                        int seta = y;
                        seta = y % 26;

                        int ol1 = 0;
                        ol1 = (int)nnkey[i, j];
                        ol1 *= pl[j, y];
                        if (seta > 15)
                            seta -= 10;

                        sum = sum + ol1;
                        seta = y % 26; seta = y % 26; seta = y % 26;

                        j++;
                    }
                    int zoo = 0;
                    zoo += 20;
                    zoo = zoo * zoo;
                    zoo += 190;
                    zoo = zoo = 300;
                    sum = sum + 26000;
                    int lo1 = sum;
                    lo1 %= ZL;

                    r[i, y] = lo1;
                    y++;
                }
                i++;
            }

            List<int> list = new List<int>();
            int y1 = 0;
            while (y1 < x)
            {
                int l1 = 0;
                while (z > l1)
                {

                    int ol11 = r[l1, y1];
                    list.Add(ol11);
                    int zoo = 0;
                    zoo += 20;
                    zoo = zoo * zoo;
                    zoo += 190;
                    zoo = zoo = 300;
                    l1++;
                }
                y1++;
            }

            return list;
        }

        void matrixkey(List<int> k, int l)
        {


            int cnt2 = 0;
            int limit = 0;
            int mxm = 0;

            nnkey = new double[l, l];

            while (l > cnt2)
            {
                int Y2 = 0;
                while (l > Y2)
                {
                    List<int> lo = k;
                    int ll = k[mxm];
                    nnkey[cnt2, Y2] = ll;
                    mxm = mxm + 1;
                    Y2++;
                }
                cnt2++;
            }

        }
        // 3aaaaaaaaaaaaaaaaaaaaaaaaaa
        //3aaaaaaaaaaaaaaaaaaaaaaaaa
        public List<int> Analyse3By3Key(List<int> plainText, List<int> cipherText)
        {
            int ii = 0;
            matrixplain(3, plainText, 3);
            nnkey = new double[3, 3];


            while (ii < 3)
            {
                int y = 0;
                while (y < 3)
                {
                    int o1 = 0;
                    o1 = pl[ii, y];
                    nnkey[ii, y] = o1;
                    y = y + 1;
                }

                ii++;
            }


            matrixinvesre3();
            int n; int m;
            n = m = 3;
            matrixplain(n, cipherText, m);
            r = new int[n, m];
            int i26 = 26;
            int po = 0;
            while (po < n)
            {
                int y1 = 0;
                while (y1 < m)
                {
                    int sum = 0;
                    int j = 0;
                    while (j < n)
                    {
                        int o1l = (int)pl[po, j];
                        o1l *= (int)invmatrix[j, y1];
                        sum = sum + o1l;
                        j++;
                    }
                    sum = sum % i26;
                    int s = sum;
                    r[po, y1] = s;
                    y1++;
                }
                po++;
            }
            List<int> LIST = new List<int>();
            int cnt = 0;
            while (cnt < m)
            {
                int y1 = 0;
                while (y1 < n)
                {
                    int pol = r[cnt, y1];
                    int op1 = pol;
                    LIST.Add(op1);
                    y1++;
                }
                cnt++;
            }
            return LIST;
        }

        public string Analyse(string plainText, string cipherText)
        {
            throw new NotImplementedException();
        }
        public string Analyse3By3Key(string plain3, string cipher3)
        {
            throw new NotImplementedException();
        }
        public string Decrypt(string cipherText, string key)
        {
            throw new NotImplementedException();
        }
        public string Encrypt(string plainText, string key)
        {
            throw new NotImplementedException();
        }

    }
}
