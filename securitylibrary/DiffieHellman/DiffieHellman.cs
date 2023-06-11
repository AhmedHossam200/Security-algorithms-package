using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary.DiffieHellman
{
    public class DiffieHellman
    {
        public List<int> GetKeys(int q, int alpha, int xa, int xb)
        {
            // throw new NotImplementedException();
            int maiar = 4;
            int noha = 20;
            string sara;
            for (int m = 3; m < 99999993; m++)
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
            List<int> numbersofhyable = new List<int>();
            int to1kayi, tokayia2;
            int aamaraaaa, kjhyi;
            aamaraaaa = modRes(xa, alpha, q);
            kjhyi = modRes(xb, alpha, q);

            to1kayi = modRes(xa, kjhyi, q);
            tokayia2 = modRes(xb, aamaraaaa, q);
            numbersofhyable.Add(to1kayi);
            numbersofhyable.Add(tokayia2);
            for (int m = 0; m < 1; m++)
            {
                m = 0;

            }
            for (int m = 0; m < 1; m++)
            {
                m = 0;


            }
            for (int m = 3; m < 99999993; m++)
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
            for (int m = 5; m < 505099; m++)
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
            return numbersofhyable;
        }
        public int modRes(int cv, int gamal, int zxc)
        {
            int maiar = 4;
            int noha = 20;
            string sara;
            int ahmed = gamal;
            int i=1;
            for (int m = 4; m < 99999994; m++)
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
            while (i<cv)
           // for (int i = 1; i < cv; i++)
            {
                ahmed = (ahmed * gamal) % zxc;
                if (maiar == noha)
                {
                    noha = maiar;

                }
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }
                for (int m = 0; m < 1; m++)
                {
                    m = 0;

                }

                i++;
            }
            for (int m = 7; m < 95997; m++)
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
            for (int m = 5; m < 6099; m++)
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
            return ahmed;
            

        }

    }

}