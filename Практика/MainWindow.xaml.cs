using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Практика
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            private ArrayAnalyzer arrayAnalyzer;
            public MainWindow()
            {
                InitializeComponent();
                arrayAnalyzer = new ArrayAnalyzer(); 
            }
            private void GenerateButton_Click(object sender, RoutedEventArgs e)
            {
               arrayAnalyzer.FillRandomData();// Заполнение случайными данными для примера
                DrawOriginalArrayGraph();
                DrawEqualValuesGraph();
            }
            private void DrawOriginalArrayGraph()
            {
               OriginalArrayCanvas.Children.Clear(); 
                double canvasWidth = OriginalArrayCanvas.ActualWidth;
                double canvasHeight = OriginalArrayCanvas.ActualHeight;
            Line xAis = new Line //Рисуем ось Х
            {
                X1 = 0,
                Y1 = canvasHeight,
                X2 = canvasWidth,
                Y2 = canvasHeight,
                Stroke=Brushes.Black,
                StrokeThickness =2
            };
             OriginalArrayCanvas.Children.Add(xAis);
            Line yAis = new Line  //Рисуем ось Y
            {
               X1=0,
               Y1=0,
               X2=0,
               Y2=canvasHeight,
               Stroke=Brushes.Black,
               StrokeThickness =2
            };
             OriginalArrayCanvas.Children.Add(yAis);
             for(int i =0; i<=100; i+=10)
             {
                double yPost = canvasHeight - (i * canvasHeight / 100);
                Line m = new Line
                {
                    X1= -5,
                    Y1 = yPost,
                    X2=5,
                    Y2=yPost,
                    Stroke=Brushes.Black,
                    StrokeThickness =1
                };
                OriginalArrayCanvas.Children.Add(m);
                TextBlock label = new TextBlock
                {
                    Text = i.ToString(),
                    Foreground = Brushes.Black,
                    Margin = new Thickness(-30,yPost -10,0,0)
                };
             }
                for (int i = 0; i < arrayAnalyzer.Numbers.Length; i++)
                {
                    double x = (canvasWidth / arrayAnalyzer.Numbers.Length) * (i + 1); // Положение по оси X
                    double y = canvasHeight - (arrayAnalyzer.Numbers[i] * canvasHeight / 100); // Положение по оси Y
                    Ellipse point = new Ellipse// Рисуем точку
                    {
                        Fill = Brushes.Orange,
                        Width = 5,
                        Height = 5,
                        Margin = new Thickness(x - 2.5, y - 2.5, 0,0)
                    };
                    OriginalArrayCanvas.Children.Add(point);
                    if (i > 0)  // Рисуем линии между точками
                    {
                        Line line = new Line
                        {
                            X1 = (canvasWidth / arrayAnalyzer.Numbers.Length) * i,
                            Y1 = canvasHeight - (arrayAnalyzer.Numbers[i - 1] * canvasHeight / 100),
                            X2 = x,
                            Y2 = y,
                            Stroke = Brushes.Black,
                            StrokeThickness = 1
                        };
                        OriginalArrayCanvas.Children.Add(line);
                    }
                }
            }
            private void DrawEqualValuesGraph()
            {
              EqualValuesCanvas.Children.Clear();
             Line xAsis1 = new Line  //Рисуем ось Х
             {
               X1=0,
               Y1= EqualValuesCanvas.ActualHeight,
               X2 = EqualValuesCanvas.ActualWidth,
               Y2 = EqualValuesCanvas.ActualHeight,
               Stroke = Brushes.Black,
               StrokeThickness = 2
             };
               EqualValuesCanvas.Children.Add(xAsis1);
            Line yAsis1 = new Line//Рисуем ось Y
            {
                X1=0,
                Y1= 0,
                X2 = 0,
                Y2 = EqualValuesCanvas.ActualHeight,
                Stroke= Brushes.Black,
                StrokeThickness = 2
            };
             EqualValuesCanvas.Children.Add(yAsis1);
              for (int i = 0;i<=100; i+=10)
              {
                double yPost = EqualValuesCanvas.ActualHeight - (i * EqualValuesCanvas.ActualHeight / 100);
                Line m = new Line
                {
                    X1 = -5,
                    Y1 = yPost,
                    X2 = 5,
                    Y2 = yPost,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1
                };
                EqualValuesCanvas.Children.Add(m);
              }
                var equalValues = arrayAnalyzer.GetEqualToPreviousValues();
                double canvasWidth = EqualValuesCanvas.ActualWidth;
                double canvasHeight = EqualValuesCanvas.ActualHeight;
                for (int i = 0; i < equalValues.Length; i++)
                {
                    double x = (canvasWidth / equalValues.Length) * (i + 1); // Положение по оси X 
                    double y = canvasHeight - ((equalValues[i]) * canvasHeight / 100); // Положение по оси Y 
                    Ellipse point = new Ellipse // Рисуем точку 
                    {
                        Fill = Brushes.Yellow,
                        Width = 5,
                        Height = 5,
                        Margin = new Thickness(x - 2.5, y - 2.5, 0, 0)
                    };
                    EqualValuesCanvas.Children.Add(point);
                    if (i > 0) // Рисуем линии между точками
                    {
                        Line line = new Line
                        {
                            X1 = (canvasWidth / equalValues.Length) * i,
                            Y1 = canvasHeight - ((equalValues[i - 1]) * canvasHeight / 100),
                            X2 = x,
                            Y2 = y,
                            Stroke = Brushes.Black,
                            StrokeThickness = 1
                        };
                        EqualValuesCanvas.Children.Add(line);
                    }
                }
                MessageBox.Show($"Количество чисел равных предыдущему: {arrayAnalyzer.CountEqualToPrevious()}");
            }
    }
}
