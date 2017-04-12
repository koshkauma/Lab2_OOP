using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab2_OOP.Drawer
{
    public class DrawRectangle : DrawFigure
    {
        public DrawRectangle(Canvas indata) : base(indata)
        {
            this.indata = indata;
        }

        public override void Draw(Color color, int thickness)
        {
            Figures.CustomRectangle tmp = (Figures.CustomRectangle)figure;
            Polygon rect = new Polygon();
            rect.Stroke = new SolidColorBrush(color);
            rect.Points.Add(new Point(tmp.A.X - tmp.firstSide/2, tmp.A.Y - tmp.secondSide / 2));
            rect.Points.Add(new Point(tmp.A.X + tmp.firstSide / 2, tmp.A.Y - tmp.secondSide / 2));
            rect.Points.Add(new Point(tmp.A.X + tmp.firstSide / 2, tmp.A.Y + tmp.secondSide / 2));
            rect.Points.Add(new Point(tmp.A.X - tmp.firstSide / 2, tmp.A.Y + tmp.secondSide / 2));
            rect.StrokeThickness = thickness;
            indata.Children.Add(rect);
        }
    }
}
