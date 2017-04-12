using System.Windows;

namespace Lab2_OOP.Figures
{
    public class CustomEllipse : CustomFigure
    {
        public double width { get; protected set; }
        public double height { get; protected set; }

        public CustomEllipse(Point center, double width, double height) : base(center)
        {
            

        }
    }
}
