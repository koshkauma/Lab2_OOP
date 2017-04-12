using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Controls.Primitives;

namespace Lab2_OOP
{
    public partial class MainWindow : Window
    {
        protected Figures.FigureFactory concreteFactory { get; set; }
        protected Drawer.DrawFigure chosenDrawer { get; set; }
        protected List<Point> buffer { get; set; }
        protected bool isSaved { get; set; }
        protected bool isLeftMouseButtonDown { get; set; }
        protected bool isMouseMove { get; set; }
        protected List<int> counterOfFigures { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void InitCanvas()
        {
            MainCanvas_Canvas.Children.Clear();
            MainCanvas_Canvas.Background = Brushes.White;
        }

        private void MainWindow_Form_Initialized(object sender, EventArgs e)
        {
            concreteFactory = new Figures.PointFactory();
            chosenDrawer = new Drawer.DrawPoint(MainCanvas_Canvas);
            InitCanvas();
            buffer = new List<Point>();
            counterOfFigures = new List<int>();
            isSaved = true;
            isLeftMouseButtonDown = false;
            isMouseMove = false;
        }

        private void Pencil_IntstrumentGrid_Button_Click(object sender, RoutedEventArgs e)
        {
            concreteFactory = new Figures.PointFactory();
            chosenDrawer = new Drawer.DrawPoint(MainCanvas_Canvas);
        }

        private void Line_IntstrumentGrid_Button_Click(object sender, RoutedEventArgs e)
        {
            concreteFactory = new Figures.LineFactory();
            chosenDrawer = new Drawer.DrawLine(MainCanvas_Canvas);
        }

        private void Triangle_IntstrumentGrid_Button_Click(object sender, RoutedEventArgs e)
        {
            concreteFactory = new Figures.TriangleFactory();
            chosenDrawer = new Drawer.DrawTriangle(MainCanvas_Canvas);
        }

        private void Rectangle_IntstrumentGrid_Button_Click(object sender, RoutedEventArgs e)
        {
            concreteFactory = new Figures.RectangleFactory();
            chosenDrawer = new Drawer.DrawRectangle(MainCanvas_Canvas);
        }

        private void Square_IntstrumentGrid_Button_Click(object sender, RoutedEventArgs e)
        {
            concreteFactory = new Figures.SquareFactory();
            chosenDrawer = new Drawer.DrawRectangle(MainCanvas_Canvas);
        }

        private void Ellipse_IntstrumentGrid_Button_Click(object sender, RoutedEventArgs e)
        {
            concreteFactory = new Figures.EllipseFactory();
            chosenDrawer = new Drawer.DrawEllipse(MainCanvas_Canvas);
        }

        private void Circle_IntstrumentGrid_Button_Click(object sender, RoutedEventArgs e)
        {
            concreteFactory = new Figures.CircleFactory();
            chosenDrawer = new Drawer.DrawEllipse(MainCanvas_Canvas);
        }


        private void Author_HelpMainMenu_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Автор - Чемрукова Арина гр. 551006", "Автор", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Instruction_HelpMainMenu_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("После загрузки программы по умолчанию выбирается инструмент \"Карандаш\" и размер пера \"1\". \r\nВ панеле инструментов существует возможность изменить инструмент и размер пера.\r\nПолученный рисунок можно сохранить в меню либо с помощью комбинации клавиш \"Ctrl + S\". ", "Руководство пользователя", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Task_HelpMainMenu_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(@"Расширить пример с графическими фигурами так, чтобы фигуры можно было создавать на уровне пользовательского интерфейса. Существуют несколько способов: ввод координат с помощью мыши, диалоговый ввод значений, ввод на скриптовом языке. Студент может выбрать любой способ ввода. Создание объекта должно выполняться так, чтобы добавление нового класса в систему не требовало изменения существующего кода (выбор типа с помощью оператора case/switch и множественного if делать нельзя). Получившаяся программа должна представлять собой примитивный графический редактор.
Классы фигур не должны содержать метод рисования.", "Задание", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_FileMainMenu_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SaveInFile_FileMainMenu_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog
            {
                DefaultExt = ".png",
                Filter = "Portable Network Graphics|*.png|Joint Photographic Experts Group|*.jpg|Bitmap Picture|*.bmp"
            };
            Thickness tmp = MainCanvas_Canvas.Margin;
            MainCanvas_Canvas.Margin = new Thickness(0, 0, 0, 0);
            dlg.ShowDialog();
            if (dlg.FileName == "")
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                DrawingVisual drawingVisual = new DrawingVisual();
                RenderTargetBitmap rtb = new RenderTargetBitmap((int)MainCanvas_Canvas.ActualWidth, (int)MainCanvas_Canvas.ActualHeight, 100, 100, PixelFormats.Pbgra32);
                rtb.Render(MainCanvas_Canvas);
                BitmapEncoder encoder = null;
                if (dlg.FileName.Contains(".png"))
                    encoder = new PngBitmapEncoder();
                if (dlg.FileName.Contains(".jpg"))
                    encoder = new JpegBitmapEncoder();
                if (dlg.FileName.Contains(".bmp"))
                    encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(rtb));
                using (var fs = File.OpenWrite(dlg.FileName))
                {
                    encoder.Save(fs);
                }
                isSaved = true;
            }
            MainCanvas_Canvas.Margin = tmp;
        }

        private void MainWindow_Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!isSaved)
            {
                if (MessageBox.Show("Файл не сохранён. Вы уверены, что хотите завершить работу?", "Вы уверены?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
            else
                e.Cancel = false;
        }

        private void MainWindow_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
                Instruction_HelpMainMenu_MenuItem_Click(Instruction_HelpMainMenu_MenuItem, new RoutedEventArgs());
            if (e.Key == Key.C & Keyboard.Modifiers == ModifierKeys.Control)
                ClearCanvas_EditMainMenu_MenuItem_Click(ClearCanvas_EditMainMenu_MenuItem, new RoutedEventArgs());
            if (e.Key == Key.F4 & Keyboard.Modifiers == ModifierKeys.Alt)
                Application.Current.Shutdown();
            if (e.Key == Key.S & Keyboard.Modifiers == ModifierKeys.Control)
                SaveInFile_FileMainMenu_MenuItem_Click(SaveInFile_FileMainMenu_MenuItem, new RoutedEventArgs());
        }


        private void ClearCanvas_EditMainMenu_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Это действие необратимо! Вы уверены, что хотите очистить полотно?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                MainCanvas_Canvas.Background = Brushes.White;
                InitCanvas();
            }
        }

        private void DeleteLast_EditMainMenu_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (MainCanvas_Canvas.Children.Count != 0)
            {
                int amountOfElementsToDelete = counterOfFigures.ElementAt(counterOfFigures.Count - 1);
                MainCanvas_Canvas.Children.RemoveRange(MainCanvas_Canvas.Children.Count - amountOfElementsToDelete, amountOfElementsToDelete + 1);
                counterOfFigures.RemoveAt(counterOfFigures.Count - 1);
            }
        }

        private void MainCanvas_Canvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isMouseMove = false;
            isLeftMouseButtonDown = false;
        }

        private void ProccessBuffer()
        {
            Drawer.DrawFigure dp = chosenDrawer;
            dp.figure = concreteFactory.Create(buffer);
            if (dp.figure != null)
            {
                isSaved = false;
                dp.Draw(Color_ColorPicker.SelectedColor.GetValueOrDefault(), SizeControl_IntegerUpDown.Value.GetValueOrDefault());
                buffer.Clear();
                if (!isMouseMove)
                    counterOfFigures.Add(1);
                else
                {
                    int prev = counterOfFigures.ElementAt(counterOfFigures.Count - 1);
                    counterOfFigures[counterOfFigures.Count - 1] = prev + 1;
                }
            }

        }

        private void MainCanvas_Canvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            const
                int X_FAULT = 115, Y_FAULT = 30;
            Point tmp = e.GetPosition(sender as Control);
            buffer.Add(new Point((tmp.X - X_FAULT), (tmp.Y - Y_FAULT)));
            ProccessBuffer();
            isLeftMouseButtonDown = true;
        }

        private void MainCanvas_Canvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            const
                int X_FAULT = 115, Y_FAULT = 30;
            if (isLeftMouseButtonDown)
                if (chosenDrawer.GetType() == typeof(Drawer.DrawPoint))
                {
                    isMouseMove = true;
                    Point tmp = e.GetPosition(sender as Control);
                    buffer.Add(new Point((tmp.X - X_FAULT), (tmp.Y - Y_FAULT)));
                    ProccessBuffer();
                }

        }
    }
}
