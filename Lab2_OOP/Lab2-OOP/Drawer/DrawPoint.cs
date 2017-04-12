using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab2_OOP.Drawer
{
    public class DrawPoint : DrawFigure
    {
        public DrawPoint(Canvas indata) : base(indata)
        {
            this.indata = indata;
        }

        public override void Draw(Color color, int thickness)
        {
            Line obj = new Line();
            Figures.CustomPoint tmp = new Figures.CustomPoint(figure.A);
            obj.X1 = tmp.A.X;
            obj.X2 = tmp.A.X + thickness;
            obj.Y1 = tmp.A.Y;
            obj.Y2 = tmp.A.Y + thickness;
            obj.HorizontalAlignment = HorizontalAlignment.Left;
            obj.VerticalAlignment = VerticalAlignment.Center;
            obj.StrokeThickness = thickness;
            obj.Stroke = new SolidColorBrush(color);
            indata.Children.Add(obj);
        }
    }
}
