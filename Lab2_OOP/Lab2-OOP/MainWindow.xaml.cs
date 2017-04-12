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

        public MainWindow()
        {
            InitializeComponent();
        }

        public void InitCanvas()
        {
            
        }

        private void MainWindow_Form_Initialized(object sender, EventArgs e)
        {
            
        }

        private void Pencil_IntstrumentGrid_Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Line_IntstrumentGrid_Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Triangle_IntstrumentGrid_Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Rectangle_IntstrumentGrid_Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Square_IntstrumentGrid_Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Ellipse_IntstrumentGrid_Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Circle_IntstrumentGrid_Button_Click(object sender, RoutedEventArgs e)
        {
            
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
            
        }

        private void MainWindow_Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void MainWindow_Form_KeyDown(object sender, KeyEventArgs e)
        {
            
        }


        private void ClearCanvas_EditMainMenu_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DeleteLast_EditMainMenu_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void MainCanvas_Canvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void ProccessBuffer()
        {
            
        }

        private void MainCanvas_Canvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void MainCanvas_Canvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            
        }

       

        
    }
}
