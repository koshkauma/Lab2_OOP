using System.Windows;

namespace Lab2_OOP.Figures
{
    public class CustomRectangle : CustomFigure
    {
        public double firstSide { get; protected set; }
        public double secondSide { get; protected set; }

        public CustomRectangle(Point A, double firstSide, double secondSide) : base(A)
        {
            this.firstSide = firstSide;
            this.secondSide = secondSide;
        }
    }
}
