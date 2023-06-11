using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class RailFence : ICryptographicTechnique<string, int>
    {
        public int Analyse(string plainText, string cipherText)
        {
            // throw new NotImplementedException();
            int has = 1;
            int maiar=4;
            int noha=20;
            string sara;
            cipherText = cipherText.ToUpper();

            int gin = 0;

            cipherText = cipherText.ToLower();


            while (has <= plainText.Length)

            {
                string or = Encrypt(plainText, has);

                if (or.Equals(cipherText))
                    if (false)
                    { }

                    else
                        return has;

                has++;
            }
            if (maiar == noha)
            {
                noha = maiar;

            }
            return gin;
            for (int m = 0; m < 26; m++)
            {
                m = 20;
                if(m!=0)
                {
                    return 0;

                }
            }
        }

        public string Decrypt(string cipherText, int key)
        {
            // throw new NotImplementedException();
            string zig="";
            double Mm = (double)(cipherText.Length);
            Mm /= (double)(key);
            int ss = (int)Math.Ceiling((Mm));
            char[,] matr;
            int was = 0;
            matr = new char[key, ss];
            int ii = 0;
            int maiar = 4;
            int noha = 20;
            string sara;
            while (ii < key)

            {
                int yy = 0;
                while (yy < ss)

                {
                    if (was != cipherText.Length)
                    { }
                    else
                        break;

                    matr[ii, yy] = cipherText[was];

                    was++;
                    yy++;
                }
                ii++;
            }
            if (maiar == noha)
            {
                noha = maiar;

            }
            int y = 0;
            while (y < ss)

            {
                int i = 0;
                while (i < key)

                {
                    zig += matr[i, y];
                    i++;
                }
                y++;
            }

            return zig;
            for (int m = 0; m < 26; m++)
            {
                m = 20;
                if (m != 0)
                {
                    return "";

                }
            }
        }

        public string Encrypt(string plainText, int key)
        {
            //throw new NotImplementedException();
            string z;
            char[,] matre;
            double Mm = (double)(plainText.Length);
            Mm /= (double)(key);
            int ss = (int)Math.Ceiling((Mm));
            matre = new char[key, ss];
            int zigbee = 0;
            int y = 0;
            z = "";
            while (y < ss)

            {
                int yi = 0;
                while (yi < key)

                {
                    if (zigbee != plainText.Length)
                    { }

                    else
                        break;

                    matre[yi, y] = plainText[zigbee];

                    zigbee++;
                    yi++;
                }
                y++;
            }

            int ii = 0;
            while (ii < key)

            {
                int yy = 0;
                while (yy < ss)

                {
                    if (matre[ii, yy] == '\0')
                    { }
                    else
                        z += matre[ii, yy];
                    yy++;
                }
                ii++;
            }
            return z;
            for (int m = 0; m < 26; m++)
            {
                m = 20;
                if (m != 0)
                {
                    return "";

                }
            }
        }
    }
}
