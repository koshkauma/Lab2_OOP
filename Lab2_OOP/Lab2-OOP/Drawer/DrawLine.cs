using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab2_OOP.Drawer
{
    public class DrawLine : DrawFigure
    {
        public DrawLine(Canvas indata) : base(indata)
        {
            this.indata = indata;
        }

        public override void Draw(Color color, int thickness)
        {
            Line myLine = new Line();
            Figures.CustomLine tmp = (Figures.CustomLine)figure;
            myLine.Stroke = new SolidColorBrush(color);
            myLine.X1 = tmp.A.X;
            myLine.X2 = tmp.B.X;
            myLine.Y1 = tmp.A.Y;
            myLine.Y2 = tmp.B.Y;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = thickness;
            indata.Children.Add(myLine);
        }
    }
}
