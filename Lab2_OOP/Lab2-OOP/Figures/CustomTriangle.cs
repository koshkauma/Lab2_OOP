using System.Windows;
using System.Windows.Media;

namespace Lab2_OOP.Figures
{
    public class CustomTriangle : CustomFigure
    {
        public Point B { get; protected set; }
        public Point C { get; protected set; }

        public CustomTriangle(Point A, Point B, Point C) : base(A)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }
    }
}
