using System.Windows;

namespace Lab2_OOP.Figures
{
    public class CustomSquare : CustomRectangle
    {
        public CustomSquare(Point A, double side) : base(A, side, side) { }
    }
}
