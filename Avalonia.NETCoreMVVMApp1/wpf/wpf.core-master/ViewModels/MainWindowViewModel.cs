using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using DynamicData;
using ReactiveUI;
using wpf.triangle.Models;

namespace wpf.triangle.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly Dot _startDot = new Dot();

        private readonly Dot _firstDot = new Dot();

        private readonly Dot _secondDot = new Dot();

        private readonly Dot _thirdDot = new Dot();

        private bool _stat;

        public ReactiveCommand<Unit, Unit> StartCommand { get; }

        public ReactiveCommand<Unit, Unit> StopCommand { get; }

        public ReactiveCommand<Unit, Unit> ClearCommand { get; }

        public ReactiveCommand<Unit, Unit> SetDotsCommand { get; }

    #region Dots

        public int StartDotX
        {
            get => (int) _startDot.X;
            set => this.RaiseAndSetIfChanged(ref _startDot.X, value);
        }

        public int StartDotY
        {
            get => (int) _startDot.Y;
            set => this.RaiseAndSetIfChanged(ref _startDot.Y, value);
        }

        public int FirstDotX
        {
            get => (int) _firstDot.X;
            set => this.RaiseAndSetIfChanged(ref _firstDot.X, value);
        }

        public int FirstDotY
        {
            get => (int) _firstDot.Y;
            set => this.RaiseAndSetIfChanged(ref _firstDot.Y, value);
        }

        public int SecondDotX
        {
            get => (int) _secondDot.X;
            set => this.RaiseAndSetIfChanged(ref _secondDot.X, value);
        }

        public int SecondDotY
        {
            get => (int) _secondDot.Y;
            set => this.RaiseAndSetIfChanged(ref _secondDot.Y, value);
        }

        public int ThirdDotX
        {
            get => (int) _thirdDot.X;
            set => this.RaiseAndSetIfChanged(ref _thirdDot.X, value);
        }

        public int ThirdDotY
        {
            get => (int) _thirdDot.Y;
            set => this.RaiseAndSetIfChanged(ref _thirdDot.Y, value);
        }

    #endregion

        private readonly SourceList<DotObject> _dots = new SourceList<DotObject>();

        private readonly ReadOnlyObservableCollection<DotObject> _collection;

        public ReadOnlyObservableCollection<DotObject> Collection => _collection;

        public MainWindowViewModel()
        {
            StartCommand = ReactiveCommand.CreateFromTask(Start);
            StopCommand = ReactiveCommand.Create(() => { _stat = false; });
            ClearCommand = ReactiveCommand.Create((() => { _dots.Clear(); }));
            SetDotsCommand = ReactiveCommand.Create((() =>
            {
                _stat = false;
                _dots.Clear();
                _dots.Add(new DotObject(_firstDot));
                _dots.Add(new DotObject(_secondDot));
                _dots.Add(new DotObject(_thirdDot));
                _dots.Add(new DotObject(_startDot));
            }));

            _firstDot = new Dot
            {
                X = 250,
                Y = 50
            };
            _secondDot = new Dot
            {
                X = 50,
                Y = 500
            };
            _thirdDot = new Dot
            {
                X = 500,
                Y = 500
            };

            _dots.Connect().Bind(out _collection).Subscribe();
        }

        private async Task Start()
        {
            _stat = true;
            var commonDot = _startDot;
            var rnd = new Random();

            while (_stat)
            {
                var number = rnd.Next(1, 4);
                switch (number)
                {
                    case 1:
                    {
                        commonDot.X = (_firstDot.X + commonDot.X) / 2;
                        commonDot.Y = (_firstDot.Y + commonDot.Y) / 2;
                        break;
                    }
                    case 2:
                    {
                        commonDot.X = (_secondDot.X + commonDot.X) / 2;
                        commonDot.Y = (_secondDot.Y + commonDot.Y) / 2;
                        break;
                    }
                    case 3:
                    {
                        commonDot.X = (_thirdDot.X + commonDot.X) / 2;
                        commonDot.Y = (_thirdDot.Y + commonDot.Y) / 2;
                        break;
                    }
                }

                _dots.Add(new DotObject(commonDot));
                await Task.Delay(10);
            }
        }
    }
}