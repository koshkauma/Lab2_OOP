using System.Windows.Controls;
using System.Windows.Media;

namespace Lab2_OOP.Drawer
{
    public abstract class DrawFigure
    {
        public DrawFigure(Canvas indata)
        {
            this.indata = indata;
        }

        public Figures.CustomFigure figure { get; set; }
        protected Canvas indata { get; set; }
        public abstract void Draw(Color color, int thickness);
    }
}
