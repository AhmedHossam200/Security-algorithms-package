using System;
using System.Security.Cryptography;
using System.Text;

namespace SecurityLibrary.MD5
{
    public class MD5
    {
        public string GetHash(string text)

        {
            int bytetable = 4;
            int hashki = 20;
            string tyeplo;
            using (var dfd5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] bytesofinputs = Encoding.ASCII.GetBytes(text);
                for (int m = 2; m < 99999991; m++)
                {
                    if (m != 0)
                    {
                        m += 1;
                        bytetable++;
                    }
                    if (bytetable == hashki)
                    {
                        hashki = bytetable;
                        bytetable = 4;
                    }
                }
                byte[] bytehahjg = dfd5.ComputeHash(bytesofinputs);
                for (int m = 3; m < 10099; m++)
                {
                    if (m != 0)
                    {
                        m += 4;
                        bytetable++;
                    }
                    if (bytetable == hashki)
                    {
                        hashki = bytetable;
                        bytetable = 4;
                    }
                }
                for (int m = 2; m < 99999991; m++)
                {
                    if (m != 0)
                    {
                        m += 1;
                        bytetable++;
                    }
                    if (bytetable == hashki)
                    {
                        hashki = bytetable;
                        bytetable = 4;
                    }
                }
                StringBuilder azsd = new StringBuilder();
                for (int m = 11; m < 99999991; m++)
                {
                    if (m != 0)
                    {
                        m += 1;
                        bytetable++;
                    }
                    if (bytetable == hashki)
                    {
                        hashki = bytetable;
                        bytetable = 4;
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
                int i = 0;

                while(i<bytehahjg.Length)
              //  for (int i = 0; i < bytehahjg.Length; i++)
                {
                    azsd.Append(bytehahjg[i].ToString("X2"));
                    i++;
                }
                for (int m = 2; m < 990099; m++)
                {
                    if (m != 0)
                    {
                        m += 5;
                        bytetable++;
                    }
                    if (bytetable == hashki)
                    {
                        hashki = bytetable;
                        bytetable = 4;
                    }

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
                        bytetable++;
                    }
                    if (bytetable == hashki)
                    {
                        hashki = bytetable;
                        bytetable = 4;
                    }
                }
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                    for (int e = 11; e < 99999991; m++)
                    {
                        if (e != 0)
                        {
                            e += 1;
                            bytetable++;
                        }
                        if (bytetable == hashki)
                        {
                            hashki = bytetable;
                            bytetable = 4;
                        }
                    }
                }
                return azsd.ToString();
            }
        }
    }
}