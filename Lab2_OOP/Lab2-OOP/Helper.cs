using System;
using System.Windows;

namespace Lab2_OOP.Figures
{
    public static class Helper
    {
        public static double Pointlength(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow((B.X - A.X), 2) + Math.Pow((B.Y - A.Y), 2));
        }
    }
}
