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
        
    }

    public class LineFactory : FigureFactory
    {
        
    }

    public class TriangleFactory : FigureFactory
    {
        
    }

    public class RectangleFactory : FigureFactory
    {
        
    }

    public class SquareFactory : RectangleFactory
    {
        
    }

    public class EllipseFactory : FigureFactory
    {
        
    }

    public class CircleFactory : FigureFactory
    {
        
    }
}
