using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Text;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.NETCoreMVVMApp1.Models;
using DynamicData;
using ReactiveUI;
using ReactiveUI.Legacy;

namespace Avalonia.NETCoreMVVMApp1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Dot _startDot= new Dot();
        private Dot _firsttDot= new Dot();
        private Dot _secondDot= new Dot();
        private Dot _thirdDot= new Dot();

        public int StartDotX
        {
            get => _startDot.X;
            set => this.RaiseAndSetIfChanged(ref _startDot.X, value);
        }
        public int StartDotY
        {
            get => _startDot.Y;
            set => this.RaiseAndSetIfChanged(ref _startDot.Y, value);
        }
        public int FirstDotX
        {
            get => _firsttDot.X;
            set => this.RaiseAndSetIfChanged(ref _firsttDot.X, value);
        }
        public int FirstDotY
        {
            get => _firsttDot.Y;
            set => this.RaiseAndSetIfChanged(ref _firsttDot.Y, value);
        }
        public int SecondDotX
        {
            get => _secondDot.X;
            set => this.RaiseAndSetIfChanged(ref _secondDot.X, value);
        }
        public int SecondDotY
        {
            get => _secondDot.Y;
            set => this.RaiseAndSetIfChanged(ref _secondDot.Y, value);
        }
        public int ThirdDotX
        {
            get => _thirdDot.X;
            set => this.RaiseAndSetIfChanged(ref _thirdDot.X, value);
        }
        public int ThirdDotY
        {
            get => _thirdDot.Y;
            set => this.RaiseAndSetIfChanged(ref _thirdDot.Y, value);
        }

       // private SourceList<IControl> _controls;

        //public IObservable<IChangeSet<IControl>> Connect() => _controls.Connect();
        //public ReactiveList<IControl> MyCollection =>  new ReactiveList<IControl>{new Line{StartPoint = new Point(1,1),EndPoint = new Point(10,10),Stroke = Brushes.Aqua},new Line{StartPoint = new Point(1,1),EndPoint = new Point(1,10),Stroke = Brushes.Blue},  };
        SourceList<Dot> dots = new SourceList<Dot>();
        private ReadOnlyObservableCollection<Dot> _collection;
        public ReadOnlyObservableCollection<Dot> Collection => _collection;
        public MainWindowViewModel()
        {
            dots.Connect().Bind(out _collection).Subscribe();
        }

        public void SetDots()
        {
            dots.Clear();
            dots.Add(_firsttDot);
            dots.Add(_secondDot);
            dots.Add(_thirdDot);
            dots.Add(_startDot);
            // controls.Add(new Ellipse{RenderTransformOrigin = new RelativePoint(new Point(_firsttDot.X,_firsttDot.Y),RelativeUnit.Absolute ),Height = 5,Width = 5, Fill = Brushes.Red});
            // controls.Add();
            // controls.Add(new Ellipse{RenderTransformOrigin = new RelativePoint(new Point(_thirdDot.X,_thirdDot.Y),RelativeUnit.Absolute ),Height = 5,Width = 5, Fill = Brushes.Red});
            //controls.Add(new Ellipse{RenderTransformOrigin = new RelativePoint(new Point(_startDot.X,_startDot.Y),RelativeUnit.Absolute ),Height = 5,Width = 5, Fill = Brushes.Blue});
        }
    }
}