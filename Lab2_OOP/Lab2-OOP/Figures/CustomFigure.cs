using System.Windows;

namespace Lab2_OOP.Figures
{
    public abstract class CustomFigure
    {
        public Point A { get; protected set; } //автоматические свойства

        public CustomFigure(Point A)
        {
            this.A = A;
        }
    }
}