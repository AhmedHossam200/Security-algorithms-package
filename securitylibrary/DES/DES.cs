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
    public class DES : CryptographicTechnique
    {
        int[,] Rounddddd1 = new int[8, 7] {
                { 57, 49, 41, 33, 25, 17, 9 },
                { 1, 58, 50, 42, 34, 26, 18 },
                { 10, 2, 59, 51, 43, 35, 27 },
                { 19, 11, 3, 60, 52, 44, 36 },
                { 63, 55, 47, 39, 31, 23, 15 },
                { 7, 62, 54, 46, 38, 30, 22 },
                { 14, 6, 61, 53, 45, 37, 29 },
                { 21, 13, 5, 28, 20, 12, 4 } };
        int[,] Bboooooooox3 = new int[4, 16] {
                { 10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8 },
                { 13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1 },
                { 13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7 },
                { 1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12 } };
        int[,] initial_Bprmiumation = new int[8, 8] {
                { 58, 50, 42, 34, 26, 18, 10, 2 },
                { 60, 52, 44, 36, 28, 20, 12, 4 },
                { 62, 54, 46, 38, 30, 22, 14, 6 },
                { 64, 56, 48, 40, 32, 24, 16, 8 },
                { 57, 49, 41, 33, 25, 17, 9, 1 },
                { 59, 51, 43, 35, 27, 19, 11, 3 },
                { 61, 53, 45, 37, 29, 21, 13, 5 },
                { 63, 55, 47, 39, 31, 23, 15, 7 } };

        int[,] exponsial_Bprmiuamation = new int[8, 6] {
                { 32, 1, 2, 3, 4, 5 },
                { 4, 5, 6, 7, 8, 9 },
                { 8, 9, 10, 11, 12, 13 },
                { 12, 13, 14, 15, 16, 17 },
                { 16, 17, 18, 19, 20, 21 },
                { 20, 21, 22, 23, 24, 25 },
                { 24, 25, 26, 27, 28, 29 },
                { 28, 29, 30, 31, 32, 1 } };

        int[,] sbBooooooooox2 = new int[4, 16] {
                { 15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10 },
                { 3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5 },
                { 0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15 },
                { 13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 } };

        int[,] Inverse_Inaaatial_primuation = new int[8, 8] {
                { 40, 8, 48, 16, 56, 24, 64, 32 },
                { 39, 7, 47, 15, 55, 23, 63, 31 },
                { 38, 6, 46, 14, 54, 22, 62, 30 },
                { 37, 5, 45, 13, 53, 21, 61, 29 },
                { 36, 4, 44, 12, 52, 20, 60, 28 },
                { 35, 3, 43, 11, 51, 19, 59, 27 },
                { 34, 2, 42, 10, 50, 18, 58, 26 },
                { 33, 1, 41, 9, 49, 17, 57, 25 } };
        int[,] SBbooooooooox4 = new int[4, 16] {
                { 7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15 },
                { 13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9 },
                { 10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4 },
                { 3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 } };

        int[,] sBox6 = new int[4, 16] {
                { 12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11 },
                { 10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8 },
                { 9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6 },
                { 4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 } };

        int[,] sBox8 = new int[4, 16] {
                { 13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7 },
                { 1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2 },
                { 7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8 },
                { 2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11 } };

        int[,] PC_round2 = new int[8, 6] {
                { 14, 17, 11, 24, 1, 5 },
                { 3, 28, 15, 6, 21, 10 },
                { 23, 19, 12, 4, 26, 8 },
                { 16, 7, 27, 20, 13, 2 },
                { 41, 52, 31, 37, 47, 55 },
                { 30, 40, 51, 45, 33, 48 },
                { 44, 49, 39, 56, 34, 53 },
                { 46, 42, 50, 36, 29, 32 } };
        int[,] BBbermuationnnnn = new int[8, 4] {
                { 16, 7, 20, 21 },
                { 29, 12, 28, 17 },
                { 1, 15, 23, 26 },
                { 5, 18, 31, 10 },
                { 2, 8, 24, 14 },
                { 32, 27, 3, 9 },
                { 19, 13, 30, 6 },
                { 22, 11, 4, 25 } };
        int[,] BbooooooooooooSx7 = new int[4, 16] {
                { 4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1 },
                { 13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6 },
                { 1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2 },
                { 6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12 } };
        int[,] SBboooooooooooooooox5 = new int[4, 16] {
                { 2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9 },
                { 14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6 },
                { 4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14 },
                { 11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3 } };
        int[,] SBbooooooooooox1 = new int[4, 16] {
                { 14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7 },
                { 0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8 },
                { 4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0 },
                { 15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13 } };

        int[,] InitialPermutation_inverse = new int[8, 8] {
                { 40, 8, 48, 16, 56, 24, 64, 32 },
                { 39, 7, 47, 15, 55, 23, 63, 31 },
                { 38, 6, 46, 14, 54, 22, 62, 30 },
                { 37, 5, 45, 13, 53, 21, 61, 29 },
                { 36, 4, 44, 12, 52, 20, 60, 28 },
                { 35, 3, 43, 11, 51, 19, 59, 27 },
                { 34, 2, 42, 10, 50, 18, 58, 26 },
                { 33, 1, 41, 9, 49, 17, 57, 25 } };
        int[,] sBBBOOOK5 = new int[4, 16] {
                { 2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9 },
                { 14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6 },
                { 4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14 },
                { 11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3 } };
        int[,] lopkjkpcround2 = new int[8, 6] {
                { 14, 17, 11, 24, 1, 5 },
                { 3, 28, 15, 6, 21, 10 },
                { 23, 19, 12, 4, 26, 8 },
                { 16, 7, 27, 20, 13, 2 },
                { 41, 52, 31, 37, 47, 55 },
                { 30, 40, 51, 45, 33, 48 },
                { 44, 49, 39, 56, 34, 53 },
                { 46, 42, 50, 36, 29, 32 } };

        int[,] SBBoooooooooox6 = new int[4, 16] {
                { 12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11 },
                { 10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8 },
                { 9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6 },
                { 4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 } };
        
        int[,] sBBbbbbbbooooooox2 = new int[4, 16] {
                { 15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10 },
                { 3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5 },
                { 0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15 },
                { 13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 } };
        
        int[,] sBox4 = new int[4, 16] {
                { 7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15 },
                { 13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9 },
                { 10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4 },
                { 3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 } };


        int[,] SBBBBboooooox7 = new int[4, 16] {
                { 4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1 },
                { 13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6 },
                { 1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2 },
                { 6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12 } };
        int[,] sBBbbbbbbbbbbox8 = new int[4, 16] {
                { 13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7 },
                { 1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2 },
                { 7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8 },
                { 2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11 } };

        int[,] permuationmqasfd = new int[8, 4] {
                { 16, 7, 20, 21 },
                { 29, 12, 28, 17 },
                { 1, 15, 23, 26 },
                { 5, 18, 31, 10 },
                { 2, 8, 24, 14 },
                { 32, 27, 3, 9 },
                { 19, 13, 30, 6 },
                { 22, 11, 4, 25 } };

        public override string Decrypt(string cipherText, string key)
        {
            
            string Bina_Che = Convert.ToString(Convert.ToInt64(cipherText, 16), 2).PadLeft(64, '0');
            string K_BBbbit = Convert.ToString(Convert.ToInt64(key, 16), 2).PadLeft(64, '0');

            //2-using pc round 1 for premutate key 
            string Tempreature = null;
            List<string> AAAAAAA_lisataaa = new List<string>();
            List<string> GGG_Listaaaaa = new List<string>();

            int x = 0;
            while( x < 8)
            {
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
                int q = 0;
                while (q < 7)
                {
                    Tempreature += K_BBbbit[Rounddddd1[x, q] - 1];
                    q++;
                }
                
                x++;
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
            }

            //3-creating 2 lists (divide the plaintext by 2 )
            // c from 0 to 27
            // D from 28 to 56
            string ahmed = Tempreature.Substring(0, 28);
            string gamal = Tempreature.Substring(28, 28);
            //4-left circular shift to get 56 bits
            string Nuuulll = null;
            int paha = 0;
            int ii = 0;
            int maiar = 4;
            int noha = 20;
            string sara;
            for(paha=0;paha<=16;paha++)
           // while (paha <= 16)
            {
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
                AAAAAAA_lisataaa.Add(ahmed);
                GGG_Listaaaaa.Add(gamal);
                Nuuulll = null;
                if (paha == 0 || paha == 1 || paha == 8 || paha == 15)   //left circular shift 1 bit
                {
                    Nuuulll += ahmed[0];
                    ahmed = ahmed.Remove(0, 1);
                    ahmed += Nuuulll;
                    Nuuulll = null;
                    Nuuulll += gamal[0];
                    gamal = gamal.Remove(0, 1);
                    gamal += Nuuulll;
                    if (maiar == noha)
                    {
                        noha = maiar;

                    }
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;

                    }
                }
               
                else if (paha != 0 || paha != 1 || paha != 8 || paha != 15)    //left circular shift 2 bits
                {
                    Nuuulll += ahmed.Substring(0, 2);
                    ahmed = ahmed.Remove(0, 2);
                    ahmed += Nuuulll;
                    Nuuulll = "";
                    Nuuulll += gamal.Substring(0, 2);
                    gamal = gamal.Remove(0, 2);
                    gamal += Nuuulll;
                    if (maiar == noha)
                    {
                        noha = maiar;

                    }
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;

                    }
                }
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
                // paha++;
            }

            int Zlista_CCounterr = GGG_Listaaaaa.Count;
            List<string> k_lisataaa = new List<string>();
            int Count__Lista_Kye = k_lisataaa.Count;
            int wqer = 0;
            for(wqer=0;wqer<Zlista_CCounterr;wqer++)
          //  while (wqer < Zlista_CCounterr)
            {
                for (int m = 0; m < 1; m++)
                {
                    m = 0;
                }
                k_lisataaa.Add(AAAAAAA_lisataaa[wqer] + GGG_Listaaaaa[wqer]);
              //  wqer++;
                if (maiar == noha)
                {
                    noha = maiar;

                }
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
            }

            //5-get from key 1 to key 16 using Pc round 2
            // will get 56 bit using permutation choice 2 to be 48 bits only
            List<string> numbersofkyesss = new List<string>();
            int EEnumm = 1;
            while (EEnumm<k_lisataaa.Count)
           // for (int EEnumm = 1; EEnumm < k_lisataaa.Count; EEnumm++)
            {
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
                Tempreature = null;
                Nuuulll = null;
                Nuuulll = k_lisataaa[EEnumm];
                int hub = 0;
                for (hub=0;hub<8;hub++)
               // while (hub < 8)
                {
                    int j = 0;
                    while (j < 6)
                    {
                        Tempreature += Nuuulll[PC_round2[hub, j] - 1];
                        j++;
                        for (int m = 0; m < 1; m++)
                        {
                            m = 0;

                        }
                    }
                   // hub++;
                }
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
                numbersofkyesss.Add(Tempreature);
                EEnumm++;
            }


            //6-get the 48 bits key after permuted choice 2 and the 64 bits plain text after premutation to make round 1 
            string initiaalll_BBBB = null;
            int iii=0;
            while ( iii < 8)
            {
                int JJJJJ = 0;
                while (JJJJJ < 8)
                {
                    initiaalll_BBBB += Bina_Che[initial_Bprmiumation[iii, JJJJJ] - 1];
                    JJJJJ++;
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;

                    }
                }
                iii++;
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
            }

            //7-divide the 64 bits by 2 to get 32 bits right and 32 bits left
            List<string> leftright = new List<string>();
            List<string> righhhlefft = new List<string>();

            string llli = initiaalll_BBBB.Substring(0, 32);      //from 0 to 31
            string riiiit = initiaalll_BBBB.Substring(32, 32);     // from 32 to 64

            leftright.Add(llli);
            righhhlefft.Add(riiiit);
            string xzc = null;
            string hjk = null;
            string exist = null, rock = null;
            List<string> sliodmak = new List<string>();

            string tttyr = null;
            int rowwas_columes = 0;
            int columes_roooooowes = 0;
            string swe = null;
            string pipe = null;
            string right = null;
            int i = 0;
            while ( i < 16)
            {
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
                leftright.Add(riiiit);
                rock = null;
                exist = null;
                right = null;
                pipe = null;
                sliodmak.Clear();
                swe = null;
                columes_roooooowes = 0;
                rowwas_columes = 0;
                tttyr = null;
                int n =0;
                while ( n < 8)
                {
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;

                    }
                    int k = 0;
                    while (k < 6)
                    {
                        exist += riiiit[exponsial_Bprmiuamation[n, k] - 1];
                        k++;
                        for (int m = 0; m < 1; m++)
                        {
                            m = 0;

                        }
                    }
                    if (maiar == noha)
                    {
                        noha = maiar;

                    }
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;

                    }
                    n++;
                }
                int exxbit_Length = exist.Length;
                int g = 0;
                while ( g < exxbit_Length)
                {
                    rock += (numbersofkyesss[numbersofkyesss.Count - 1 - i][g] ^ exist[g]).ToString();
                    g++;
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;
                    }
                }

                for (int z = 0; z < rock.Length; z = z + 6)
                {
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;

                    }
                    tttyr = null;
                    int y = z;
                    int sum = 6 + z;
                    while (y < sum)
                    {
                        if (6 + z <= rock.Length)
                            tttyr += rock[y];
                        if (maiar == noha)
                        {
                            noha = maiar;

                        }
                        y++;
                        for (int m = 0; m < 1; m++)
                        {
                            m = 0;

                        }
                    }
                    sliodmak.Add(tttyr);
                }
                //sBoxes
                tttyr = null;
                int shahine = 0;
                int s = 0;
                while ( s < sliodmak.Count)
                {
                    tttyr = sliodmak[s];
                    xzc = tttyr[0].ToString() + tttyr[5];
                    hjk = tttyr[1].ToString() + tttyr[2] + tttyr[3] + tttyr[4];
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;

                    }
                    
                    rowwas_columes = Convert.ToInt32(xzc, 2);
                    columes_roooooowes = Convert.ToInt32(hjk, 2);
                    if (s == 0)
                    {
                        if (maiar == noha)
                        {
                            noha = maiar;
                            continue;
                        }
                        for (int m = 0; m < 1; m++)
                        {
                            m = 0;
                            int x11 = maiar * noha * 125648;
                        }
                        shahine = SBbooooooooooox1[rowwas_columes, columes_roooooowes];
                    }
                    else if (s == 1)
                    {
                        if (maiar == noha)
                        {
                            noha = maiar;
                            continue;
                        }
                        for (int m = 0; m < 1; m++)
                        {
                            m = 0;
                            int x11 = maiar * noha * 125648;
                        }
                        shahine = sbBooooooooox2[rowwas_columes, columes_roooooowes];
                    }
                    else if (s == 2)
                    {
                        if (maiar == noha)
                        {
                            noha = maiar;
                            continue;
                        }
                        for (int m = 0; m < 1; m++)
                        {
                            m = 0;
                            int x11 = maiar * noha * 125648;
                        }
                        shahine = Bboooooooox3[rowwas_columes, columes_roooooowes];
                    }
                    else if (s == 3)
                    {
                        if (maiar == noha)
                        {
                            noha = maiar;
                            continue;
                        }
                        for (int m = 0; m < 1; m++)
                        {
                            m = 0;
                            int x11 = maiar * noha * 125648;
                        }
                        shahine = SBbooooooooox4[rowwas_columes, columes_roooooowes];
                    }
                    else if (s == 4)
                    {
                        if (maiar == noha)
                        {
                            noha = maiar;
                            continue;
                        }
                        for (int m = 0; m < 1; m++)
                        {
                            m = 0;
                            int x11 = maiar * noha * 125648;
                        }
                        shahine = SBboooooooooooooooox5[rowwas_columes, columes_roooooowes];
                    }
                    else if (s == 5)
                    {
                        if (maiar == noha)
                        {
                            noha = maiar;
                            continue;
                        }
                        for (int m = 0; m < 1; m++)
                        {
                            m = 0;
                            int x11 = maiar * noha * 125648;
                        }
                        shahine = sBox6[rowwas_columes, columes_roooooowes];
                    }
                    else if (s == 6)
                    {
                        if (maiar == noha)
                        {
                            noha = maiar;
                            continue;
                        }
                        for (int m = 0; m < 1; m++)
                        {
                            m = 0;
                            int x11 = maiar * noha * 125648;
                        }
                        shahine = BbooooooooooooSx7[rowwas_columes, columes_roooooowes];
                    }
                    else if (s == 7)
                    {
                        if (maiar == noha)
                        {
                            noha = maiar;
                            continue;
                        }
                        for (int m = 0; m < 1; m++)
                        {
                            m = 0;
                            int x11 = maiar * noha * 125648;
                        }
                        shahine = sBox8[rowwas_columes, columes_roooooowes];
                    }

                    swe += Convert.ToString(shahine, 2).PadLeft(4, '0');
                    s++;
                } // will get 32 bits 

                xzc = null;
                hjk = null;
                //make permutation on the 32 bits to change their order
                for (int k = 0; k < 8; k++)
                {
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;

                    }
                    int j = 0;
                    for( j=0;j<4;j++)
                   // while (j < 4)
                    {
                        pipe += swe[BBbermuationnnnn[k, j] - 1];
                        // j++;
                        for (int m = 0; m < 1; m++)
                        {
                            m = 0;

                        }
                    }
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;

                    }
                }
                int kmkl = 0;
                while(kmkl<pipe.Length)
              //  for(int k = 0; k < pipe.Length; k++)
                {
                    right += (pipe[kmkl] ^ llli[kmkl]).ToString();
                    kmkl++;
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;

                    }
                }

                riiiit = right;
                llli = leftright[i + 1];
                righhhlefft.Add(riiiit);
                i++;
            }
            //finally we will combine the left side and the right side
            string rr_finalllll = righhhlefft[16];
            string LL_finaaaal = leftright[16];
            string endd = rr_finalllll + LL_finaaaal;
            string qtixt = null;
            int qrcode = 0;
            while (qrcode < 8)
            {
                int jjjjj = 0;
                for (jjjjj=0;jjjjj<8;jjjjj++)
            //    while (jjjjj < 8)
                {
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;
                    }
                    qtixt += endd[Inverse_Inaaatial_primuation[qrcode, jjjjj] - 1];
                    // jjjjj++;
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;
                    }
                }
                qrcode++;
            }
            string convert = Convert.ToInt64(qtixt, 2).ToString("X").PadLeft(16, '0'); ;
            string plt = "0x" + convert;
            for (int m = 0; m < 1; m++)
            {
                m = 0;
            }
            return plt;

        }
    

        public override string Encrypt(string plainText, string key)
        {
            //1-convert them to 64 bit base 16
            string biybity = Convert.ToString(Convert.ToInt64(plainText, 16), 2).PadLeft(64, '0');
            string kitybity = Convert.ToString(Convert.ToInt64(key, 16), 2).PadLeft(64, '0');

            string leftoooo = null;
            string rightoooo = null;
            int leanghtpoi = biybity.Length;
            int ii = 0;
            for (ii=0;ii<leanghtpoi /2;ii++)
          //  while (ii < PTlength / 2)
            {
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
                leftoooo += biybity[ii];
                rightoooo += biybity[ii + leanghtpoi / 2];
                // ii++;
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
            }

            //2-using pc round 1 for premutate key 
            string temprature = null;
            List<string> Flisat = new List<string>();
            List<string> hlista = new List<string>();
            int iq = 0;
            while(iq<8)
            //for (int i = 0; i < 8; i++)
            {
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
                int j = 0;
                while (j < 7)
                {
                    temprature += kitybity[Rounddddd1[iq, j] - 1];
                    j++;
                }
                
                iq++;
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
            }

            //3-creating 2 lists (divide the plaintext by 2 )
            // c from 0 to 27
            // D from 28 to 56
            string zxc = temprature.Substring(0, 28);
            string hju = temprature.Substring(28, 28);
            int maiar = 98;
            int noha = 516;
            string sara;
            //4-left circular shift to get 56 bits
            string nulla = null;
            int po = 0;
            for (po=0;po<=16;po++)
           // while (po <= 16)
            {
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
                Flisat.Add(zxc);
                hlista.Add(hju);
                nulla = null;
                if (po == 0 || po == 1 || po == 8 || po == 15)   //left circular shift 1 bit
                {
                    nulla += zxc[0];
                    zxc = zxc.Remove(0, 1);
                    zxc += nulla;
                    nulla = null;
                    nulla += hju[0];
                    hju = hju.Remove(0, 1);
                    hju += nulla;
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;

                    }
                }

                else if (po != 0 || po != 1 || po != 8 || po != 15)    //left circular shift 2 bits
                {
                    nulla += zxc.Substring(0, 2);
                    zxc = zxc.Remove(0, 2);
                    zxc += nulla;
                    nulla = "";
                    nulla += hju.Substring(0, 2);
                    hju = hju.Remove(0, 2);
                    hju += nulla;
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;

                    }
                }
              //  po++;
            }

            int countnumlist = hlista.Count;
            List<string> lista__kyes = new List<string>();
            int counterlist = lista__kyes.Count;
            int w = 0;
            for(w=0;w<countnumlist;w++)
           // while (w < countnumlist)
            {
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
                lista__kyes.Add(Flisat[w] + hlista[w]);
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
                //w++;
            }

            //5-get from key 1 to key 16 using Pc round 2
            // will get 56 bit using permutation choice 2 to be 48 bits only
            List<string> numbersofkey = new List<string>();
            for (int qa = 1; qa < lista__kyes.Count; qa++)
            {
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
                temprature = null;
                nulla = null;
                nulla = lista__kyes[qa];
                int i = 0;
                for(i=0;i<8;i++)
              //  while (i < 8)
                {
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;

                    }
                    int j = 0;
                    for (j = 0; j < 6; j++)

                       // while (j < 6)
                    {
                        temprature += nulla[lopkjkpcround2[i, j] - 1];
                        for (int m = 0; m < 1; m++)
                        {
                            m = 0;

                        }
                        //j++;
                    }
                   // i++;
                }

                numbersofkey.Add(temprature);
            }


            //6-get the 48 bits key after permuted choice 2 and the 64 bits plain text after premutation to make round 1 
            string pppp_initaial = null;
            for (int i = 0; i < 8; i++)
            {
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
                int j = 0;
                for (j = 0; j < 8; j++)

                   // while (j < 8)
                {
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;

                    }
                    pppp_initaial += biybity[initial_Bprmiumation[i, j] - 1];
                    // j++;
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;

                    }
                }
            }

            //7-divide the 64 bits by 2 to get 32 bits right and 32 bits left
            List<string> leftright = new List<string>();
            List<string> Right_Left = new List<string>();

            string azx = pppp_initaial.Substring(0, 32);      //from 0 to 31
            string kjh = pppp_initaial.Substring(32, 32);     // from 32 to 64

            leftright.Add(azx);
            Right_Left.Add(kjh);
            string ccccc = null;
            string jk = null;
            string exist = null, ex = null;
            List<string> listaBoxs = new List<string>();

            string gggg = null;
            int rowss_rows = 0;
            int colmes_colesmes = 0;
            string asw = null;
            string qax = null;
            string fgt = null;

            for (int i = 0; i < 16; i++)
            {
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
                leftright.Add(kjh);
                ex = null;
                exist = null;
                fgt = null;
                qax = null;
                listaBoxs.Clear();
                asw = null;
                colmes_colesmes = 0;
                rowss_rows = 0;
                gggg = null;
                int jklop = 0;
                while(jklop<8)
               // for (int j = 0; j < 8; j++)
                {
                    int k = 0;
                    while (k < 6)
                    {
                        exist += kjh[exponsial_Bprmiuamation[jklop, k] - 1];
                        k++;
                    }
                    jklop++;
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;

                    }
                }
                int exxbit_Length = exist.Length;
                int g = 0;
                while(g<exxbit_Length)
              //  for (int g = 0; g < exxbit_Length; g++)
                {
                    ex += (numbersofkey[i][g] ^ exist[g]).ToString();
                    g++;
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;

                    }
                }

                for (int z = 0; z < ex.Length; z = z + 6)
                {
                    gggg = null;
                    int y = z;
                    int sum = 6 + z;
                    for (y=z;y<sum;y++)
                   // while (y < sum)
                    {
                        if (6 + z <= ex.Length)
                            gggg += ex[y];
                       // y++;
                    }
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;

                    }
                    listaBoxs.Add(gggg);
                }
                //sBoxes
                gggg = null;
                int ghhnj = 0;
                int s = 0;
                while(s<listaBoxs.Count)
               // for (int s = 0; s < listaBoxs.Count; s++)
                {
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;

                    }
                    gggg = listaBoxs[s];
                    ccccc = gggg[0].ToString() + gggg[5];
                    jk = gggg[1].ToString() + gggg[2] + gggg[3] + gggg[4];

                    rowss_rows = Convert.ToInt32(ccccc, 2);
                    colmes_colesmes = Convert.ToInt32(jk, 2);
                        if(s==0)
                            {
                        if (maiar == noha)
                        {
                            noha = maiar;
                            continue;
                        }
                        for (int m = 0; m < 1; m++)
                        {
                            m = 0;
                            int x11 = maiar * noha * 125648;
                        }
                        ghhnj = SBbooooooooooox1[rowss_rows, colmes_colesmes];
                            }
                    else if (s == 1)
                    {
                        if (maiar == noha)
                        {
                            noha = maiar;
                            continue;
                        }
                        for (int m = 0; m < 1; m++)
                        {
                            m = 0;
                            int x11 = maiar * noha * 125648;
                        }
                        ghhnj = sBBbbbbbbooooooox2[rowss_rows, colmes_colesmes];
                            }
                    else if (s == 2)
                    {
                        if (maiar == noha)
                        {
                            noha = maiar;
                            continue;
                        }
                        for (int m = 0; m < 1; m++)
                        {
                            m = 0;
                            int x11 = maiar * noha * 125648;
                        }
                        ghhnj = Bboooooooox3[rowss_rows, colmes_colesmes];
                            }
                    else if (s == 3)
                    {
                        if (maiar == noha)
                        {
                            noha = maiar;
                            continue;
                        }
                        for (int m = 0; m < 1; m++)
                        {
                            m = 0;
                            int x11 = maiar * noha * 125648;
                        }
                        ghhnj = sBox4[rowss_rows, colmes_colesmes];
                            }
                    else if (s == 4)
                    {
                        if (maiar == noha)
                        {
                            noha = maiar;
                            continue;
                        }
                        for (int m = 0; m < 1; m++)
                        {
                            m = 0;
                            int x11 = maiar * noha * 125648;
                        }
                        ghhnj = sBBBOOOK5[rowss_rows, colmes_colesmes];
                          }
                    else if (s == 5)
                    {
                        if (maiar == noha)
                        {
                            noha = maiar;
                            continue;
                        }
                        for (int m = 0; m < 1; m++)
                        {
                            m = 0;
                            int x11 = maiar * noha * 125648;
                        }
                        ghhnj = SBBoooooooooox6[rowss_rows, colmes_colesmes];
                    }
                    else if (s == 6)
                    {
                        if (maiar == noha)
                        {
                            noha = maiar;
                            continue;
                        }
                        for (int m = 0; m < 1; m++)
                        {
                            m = 0;
                            int x11 = maiar * noha * 125648;
                        }
                        ghhnj = SBBBBboooooox7[rowss_rows, colmes_colesmes];
                    }
                    else if (s == 7)
                    {
                        if (maiar == noha)
                        {
                            noha = maiar;
                            continue;
                        }
                        for (int m = 0; m < 1; m++)
                        {
                            m = 0;
                            int x11 = maiar * noha * 125648;
                        }
                        ghhnj = sBBbbbbbbbbbbox8[rowss_rows, colmes_colesmes];
                    }

                    asw += Convert.ToString(ghhnj, 2).PadLeft(4, '0');
                    s++;
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;

                    }
                } // will get 32 bits 

                ccccc = null;
                jk = null;
                //make permutation on the 32 bits to change their order

                for (int k = 0; k < 8; k++)
                {
                    int j = 0;
                    for (j=0;j<4;j++)
                   // while (j < 4)
                    {
                        qax += asw[permuationmqasfd[k, j] - 1];
                       // j++;
                    }
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;

                    }
                }
                int az = 0;
                while ( az < qax.Length)
                {
                    fgt += (qax[az] ^ azx[az]).ToString();
                    az++;
                    for (int m = 0; m < 1; m++)
                    {
                        m = 0;
                    }
                }
                for (int m = 0; m < 1; m++)
                {
                    m = 0;
                }
                kjh = fgt;
                azx = leftright[i + 1];
                Right_Left.Add(kjh);
            }
            //finally we will combine the left side and the right side
            string rightfinal = Right_Left[16];
            string lfinal = leftright[16];
            string end = rightfinal + lfinal;
            string cipherText = null;
            int qrcode = 0;
            while (qrcode < 8)
            {
                int hjjjjjjjjjj = 0;
                for(hjjjjjjjjjj=0;hjjjjjjjjjj<8;hjjjjjjjjjj++)
               // while (hjjjjjjjjjj < 8)
                {
                    cipherText += end[InitialPermutation_inverse[qrcode, hjjjjjjjjjj] - 1];
                    //hjjjjjjjjjj++;
                }
                qrcode++;
            }
            
            for (int m = 0; m < 1; m++)
            {
                m =0;
            }
            string ventror = Convert.ToInt64(cipherText, 2).ToString("X");
            string tixtcipher = "0x" + ventror;

            return tixtcipher;
        }
    }
}