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
        private Dot _firstDot= new Dot();
        private Dot _secondDot= new Dot();
        private Dot _thirdDot= new Dot();

        public int StartDotX
        {
            get =>(int) _startDot.X;
            set => this.RaiseAndSetIfChanged(ref _startDot.X, value);
        }
        public int StartDotY
        {
            get =>(int) _startDot.Y;
            set => this.RaiseAndSetIfChanged(ref _startDot.Y, value);
        }
        public int FirstDotX
        {
            get => (int)_firstDot.X;
            set => this.RaiseAndSetIfChanged(ref _firstDot.X, value);
        }
        public int FirstDotY
        {
            get => (int)_firstDot.Y;
            set => this.RaiseAndSetIfChanged(ref _firstDot.Y, value);
        }
        public int SecondDotX
        {
            get => (int)_secondDot.X;
            set => this.RaiseAndSetIfChanged(ref _secondDot.X, value);
        }
        public int SecondDotY
        {
            get => (int)_secondDot.Y;
            set => this.RaiseAndSetIfChanged(ref _secondDot.Y, value);
        }
        public int ThirdDotX
        {
            get =>(int) _thirdDot.X;
            set => this.RaiseAndSetIfChanged(ref _thirdDot.X, value);
        }
        public int ThirdDotY
        {
            get => (int)_thirdDot.Y;
            set => this.RaiseAndSetIfChanged(ref _thirdDot.Y, value);
        }

       // private SourceList<IControl> _controls;

        //public IObservable<IChangeSet<IControl>> Connect() => _controls.Connect();
        //public ReactiveList<IControl> MyCollection =>  new ReactiveList<IControl>{new Line{StartPoint = new Point(1,1),EndPoint = new Point(10,10),Stroke = Brushes.Aqua},new Line{StartPoint = new Point(1,1),EndPoint = new Point(1,10),Stroke = Brushes.Blue},  };
        SourceList<DotObject> dots = new SourceList<DotObject>();
        private ReadOnlyObservableCollection<DotObject> _collection;
        public ReadOnlyObservableCollection<DotObject> Collection => _collection;
        public MainWindowViewModel()
        {
            dots.Connect().Bind(out _collection).Subscribe();
        }

        public void SetDots()
        {
            dots.Clear();
            dots.Add(new DotObject(_firstDot));
            dots.Add(new DotObject( _secondDot));
            dots.Add(new DotObject( _thirdDot));
            dots.Add(new DotObject( _startDot));
            // controls.Add(new Ellipse{RenderTransformOrigin = new RelativePoint(new Point(_firsttDot.X,_firsttDot.Y),RelativeUnit.Absolute ),Height = 5,Width = 5, Fill = Brushes.Red});
            // controls.Add();
            // controls.Add(new Ellipse{RenderTransformOrigin = new RelativePoint(new Point(_thirdDot.X,_thirdDot.Y),RelativeUnit.Absolute ),Height = 5,Width = 5, Fill = Brushes.Red});
            //controls.Add(new Ellipse{RenderTransformOrigin = new RelativePoint(new Point(_startDot.X,_startDot.Y),RelativeUnit.Absolute ),Height = 5,Width = 5, Fill = Brushes.Blue});
        }
    }
}