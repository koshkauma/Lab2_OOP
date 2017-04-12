using System.Windows;

namespace Lab2_OOP.Figures
{
    public class CustomLine : CustomFigure
    {
        public Point B { get; protected set; }

        public CustomLine(Point A, Point B) : base(A)
        {
            this.A = A;
            this.B = B;
        }
    }
}
