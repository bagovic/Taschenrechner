using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    static class Maths
    {
        static int teilfaktor = 0, ggt = 0, tfm = 0;
        static bool mfaktor = true;
        public static double Fakultaet(double n)
        {
            if (n >= 1)
                return n * Fakultaet(n - 1);
            else
                return n + 1;
        }
        public static double qs(string n)
        {
            double m = 0;
            for (int i = 0; i < n.Length; i++)
            {
                double x = double.Parse(n[i].ToString());
                m += x;
            }
            return m;
        }
        public static string Basics(double m, double n, string op)
        {
            switch (op)
            {
                case "+":
                    return (m + n).ToString();
                case "-":
                    return (m - n).ToString();
                case "*":
                    return (m * n).ToString();
                case "/":
                    return (m / n).ToString();
                case "%":
                    return (m % n).ToString();
                case "ggT":
                    teilfaktor = 0; ggt = 0; tfm = 0; mfaktor = true;
                    return ggT(m, n).ToString();
            }
            return "Fehler";
        }
        private static int ggT(double m, double n)
        {
            if (tfm < m) teilfaktor++;
            else return ggt;
            if (mfaktor)
            {
                double rest = m % teilfaktor;
                if (rest == 0 && teilfaktor > tfm)
                {
                    tfm = teilfaktor;
                    mfaktor = false;
                }
                else ggT(m, n);
            }
            if (!mfaktor)
            {
                double rest = n % teilfaktor;
                if (rest == 0 && teilfaktor == tfm)
                {
                    mfaktor = true;
                    ggt = teilfaktor;
                    ggT(m, n);
                }
                else
                {
                    mfaktor = true;
                    ggT(m, n);
                }

            }
            return ggt;
        }
    }
}
