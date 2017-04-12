using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab2_OOP.Drawer
{
    public class DrawEllipse : DrawFigure
    {
        public DrawEllipse(Canvas indata) : base(indata)
        {
            this.indata = indata;
        }

        public override void Draw(Color color, int thickness)
        {
            Figures.CustomEllipse tmp = (Figures.CustomEllipse)figure;
            var g = new StreamGeometry();

            using (var gc = g.Open())
            {
                gc.BeginFigure(
                    startPoint: new Point(tmp.A.X - tmp.width, tmp.A.Y + 1),
                    isFilled: false,
                    isClosed: true);

                gc.ArcTo(
                    point: new Point(tmp.A.X - tmp.width, tmp.A.Y),
                    size: new Size(tmp.width, tmp.height),
                    rotationAngle: 0d,
                    isLargeArc: true,
                    sweepDirection: SweepDirection.Counterclockwise,
                    isStroked: true,
                    isSmoothJoin: false);
            }

            var path = new Path
            {
                Stroke = new SolidColorBrush(color),
                StrokeThickness = thickness,
                Data = g
            };

            indata.Children.Add(path);
        }
    }
}
