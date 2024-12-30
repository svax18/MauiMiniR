using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiMiniR
{
    public static class Calculate
    {
        public static double Beräkna(double val1, double val2, string operatorMath)
        {
            double result = 0;

            switch (operatorMath)
            {
                case "/":
                    result = val1/val2;
                    break;
                case "-":
                    result = val1-val2;
                    break;
                case "*":
                    result = val1*val2;
                    break;
                case "+":
                    result = val1+val2;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
