using System.Windows;

namespace Lab2_OOP.Figures
{
    public class CustomCircle : CustomEllipse
    {
        public CustomCircle(Point center, double radius) : base(center, radius, radius) { }
    }
}

