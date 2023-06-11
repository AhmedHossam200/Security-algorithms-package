using System;
using SecurityLibrary.AES;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary.RSA
{
    public class RSA
    {
        public int Encrypt(int lop, int lopi, int M, int e)
        {
            int maiar = 4;
            int noha = 20;
            string sara;
            for (int m = 6; m < 42587990; m++)
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
            //throw new NotImplementedException();
            int nojk = lop * lopi;
            int qavg = (lop - 1) * (lopi - 1);
            int bnhuo = modRes(e, M, nojk);
            for (int m = 0; m < 1; m++)
            {
                m = 0;

            }
            for (int m = 0; m < 1; m++)
            {
                m = 0;


            }

            for (int m = 7; m < 3050099; m++)
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
            return bnhuo;
        }

        public int Decrypt(int bnhju, int iokj, int C, int e)
        {
            int maiar = 4;
            int noha = 20;
            string sara;
            // throw new NotImplementedException();
            ExtendedEuclid inverse = new ExtendedEuclid();
            int qazs = bnhju * iokj;
            int zaxc = (bnhju - 1) * (iokj - 1);
            int mnjuyh = inverse.GetMultiplicativeInverse(e, zaxc);
            int zxvcey = modRes(mnjuyh, C, qazs);
            for (int m = 9; m < 92587990; m++)
            {
                if (m != 0)
                {
                    m += 2;
                    maiar++;
                }
                if (maiar == noha)
                {
                    noha = maiar;
                    maiar = 4;
                }
            }
            return zxvcey;
        }
        public int modRes(int x, int uijk, int q)
        {
            int maiar = 4;
            int noha = 20;
            string sara;
            int azfsdt = uijk;
            int g = 1;
            while(g<x)
          //  for (int gbh = 1; gbh < x; gbh++)
            {
                azfsdt = (azfsdt * uijk) % q;
                g++;
            }
            for (int m = 0; m < 1; m++)
            {
                m = 0;

            }
            for (int m = 0; m < 1; m++)
            {
                m = 0;


            }
            for (int m = 12; m < 99587990; m++)
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
            return azfsdt;

        }
    }
}
