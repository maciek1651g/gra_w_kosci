using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra_w_kosci
{
    class LiczeniePunktow
    {
        public static int PunktyZaKonkretneKostki(int[] kosci, int wartoscKostki)
        {
            int wynik = 0;

            for (int i = 0; i < kosci.Length; i++)
            {
                if(kosci[i]== wartoscKostki)
                {
                    wynik++;
                }
            }

            return wynik * wartoscKostki;
        }

        public static int TrojkaKosci(int[] kosci)
        {
            for (int i = 0; i < kosci.Length/2; i++)
            {
                int trojka = kosci[i];
                int licznik = 1;

                for (int j = i+1; j < kosci.Length; j++)
                {
                    if(kosci[j]==trojka)
                    {
                        licznik++;
                    }
                }

                if(licznik>=3)
                {
                    return SumaOczek(kosci);
                }
            }

            return 0;
        }

        public static int CzworkaKosci(int[] kosci)
        {
            for (int i = 0; i < kosci.Length/2; i++)
            {
                int czworka = kosci[i];
                int licznik = 1;

                for (int j = i + 1; j < kosci.Length; j++)
                {
                    if (kosci[j] == czworka)
                    {
                        licznik++;
                    }
                }

                if (licznik >= 4)
                {
                    return SumaOczek(kosci);
                }
            }

            return 0;
        }

        public static int Full(int[] kosci)
        {
            Sortuj(kosci);

            if((kosci[0]==kosci[1] && kosci[2]==kosci[3] && kosci[3]==kosci[4]) || (kosci[0] == kosci[1] && kosci[1] == kosci[2] && kosci[3] == kosci[4]))
            {
                return 25;
            }

            return 0;
        }

        public static int MalyStrit(int[] kosci)
        {
            Sortuj(kosci);

            int licznik = 1;

            for (int i = 1; i < kosci.Length; i++)
            {
                if(kosci[i-1]<kosci[i])
                {
                    licznik++;
                }
            }

            if(licznik>=4)
            {
                return 30;
            }

            return 0;
        }

        public static int DuzyStrit(int[] kosci)
        {
            Sortuj(kosci);

            if ((kosci[0] < kosci[1] && kosci[1] < kosci[2] && kosci[2] < kosci[3] && kosci[3] < kosci[4]))
            {
                return 40;
            }

            return 0;
        }

        public static int Poker(int[] kosci)
        {
            if ((kosci[0] == kosci[1] && kosci[1] == kosci[2] && kosci[2] == kosci[3] && kosci[3] == kosci[4]))
            {
                return 50;
            }

            return 0;
        }

        public static int Szansa(int[] kosci)
        {
            return SumaOczek(kosci);
        }

        private static int SumaOczek(int[]kosci)
        {
            int wynik = 0;
            for (int i = 0; i < kosci.Length; i++)
            {
                wynik += kosci[i];
            }
            return wynik;
        }
        private static void Sortuj(int[] kosci)
        {
            for (int i = 0; i < kosci.Length; i++)
            {
                for (int j = 0; j < kosci.Length; j++)
                {
                    if(kosci[i]<kosci[j])
                    {
                        int tmp = kosci[i];
                        kosci[i] = kosci[j];
                        kosci[j] = tmp;
                    }
                }
            }
        }
    }
}
