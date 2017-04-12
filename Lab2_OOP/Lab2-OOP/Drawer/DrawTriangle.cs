using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab2_OOP.Drawer
{
    public class DrawTriangle : DrawFigure
    {
        public DrawTriangle(Canvas indata) : base(indata)
        {
            this.indata = indata;
        }

        public override void Draw(Color color, int thickness)
        {
            Polygon polygon = new Polygon();
            Figures.CustomTriangle tmp = (Figures.CustomTriangle)figure;
            polygon.Stroke = new SolidColorBrush(color);
            polygon.StrokeThickness = thickness;
            polygon.Points.Add(tmp.A);
            polygon.Points.Add(tmp.B);
            polygon.Points.Add(tmp.C);
            indata.Children.Add(polygon);
        }
    }
}
