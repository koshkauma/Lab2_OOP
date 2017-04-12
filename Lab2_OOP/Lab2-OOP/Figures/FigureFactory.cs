using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab2_OOP.Figures
{
    public abstract class FigureFactory
    {
        public abstract CustomFigure Create(List<Point> buffer);
    }

    public class PointFactory : FigureFactory
    {
        public override CustomFigure Create(List<Point> buffer)
        {
            return new CustomPoint(buffer[0]);
        }
    }

    public class LineFactory : FigureFactory
    {
        public override CustomFigure Create(List<Point> buffer)
        {
            const
                int ARGS_COUNT = 2;
            if (buffer.Count == ARGS_COUNT)
                return new CustomLine(buffer[0], buffer[1]);
            else
                return null;
        }
    }

    public class TriangleFactory : FigureFactory
    {
        public override CustomFigure Create(List<Point> buffer)
        {
            const
                int ARGS_COUNT = 3;
            if (buffer.Count == ARGS_COUNT)
                return new CustomTriangle(buffer[0], buffer[1], buffer[2]);
            else
                return null;
        }
    }

    public class RectangleFactory : FigureFactory
    {
        protected CustomRectangle outdata { get; set; }

        public override CustomFigure Create(List<Point> buffer)
        {
            const
                int ARGS_COUNT = 2;
            if (buffer.Count == ARGS_COUNT)
            {
                double firstSide = Helper.Pointlength(buffer[0], new Point(buffer[1].X, buffer[0].Y));
                double secondSide = Helper.Pointlength(buffer[0], new Point(buffer[0].X, buffer[1].Y));
                short x_correction = 1, y_correction = 1;
                if (buffer[0].X > buffer[1].X)
                    x_correction = -1;
                else
                    x_correction = 1;
                if (buffer[0].Y > buffer[1].Y)
                    y_correction = -1;
                else
                    y_correction = 1;
                Point A = new Point(buffer[0].X + x_correction * firstSide / 2, buffer[1].Y - y_correction * secondSide / 2);

                outdata = new CustomRectangle(A, firstSide, secondSide);
                return outdata;

            }
            else
                return null;
        }
    }

    public class SquareFactory : RectangleFactory
    {
        public override CustomFigure Create(List<Point> buffer)
        {
            const
                int ARGS_COUNT = 2;
            if (buffer.Count == ARGS_COUNT)
            {
                base.Create(buffer);
                return new CustomSquare(outdata.A, outdata.firstSide);

            }
            else
                return null;
        }
    }

    public class EllipseFactory : FigureFactory
    {
        public override CustomFigure Create(List<Point> buffer)
        {
            const
                int ARGS_COUNT = 3;
            if (buffer.Count == ARGS_COUNT)
            {
                return new CustomEllipse(buffer[0], Helper.Pointlength(buffer[0], buffer[1]), Helper.Pointlength(buffer[0], buffer[2]));
            }
            else
                return null;
        }
    }

    public class CircleFactory : EllipseFactory
    {
        public override CustomFigure Create(List<Point> buffer)
        {
            const
                int ARGS_COUNT = 2;
            if (buffer.Count == ARGS_COUNT)
                return new CustomCircle(buffer[0], Helper.Pointlength(buffer[0], buffer[1]));
            else
                return null;
        }
    }
}
