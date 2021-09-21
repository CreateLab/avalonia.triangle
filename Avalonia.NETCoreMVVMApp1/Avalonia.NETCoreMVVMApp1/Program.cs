using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.NETCoreMVVMApp1.ViewModels;
using Avalonia.NETCoreMVVMApp1.Views;
using Avalonia.ReactiveUI;

namespace Avalonia.NETCoreMVVMApp1
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args) => BuildAvaloniaApp().Start(AppMain, args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .With(new Win32PlatformOptions
                {
                    UseDeferredRendering = false,
                    EnableMultitouch = true
                })
                .With(
                    new X11PlatformOptions
                    {
                        UseDeferredRendering = false
                    }).With(
                    new AvaloniaNativePlatformOptions
                    {
                        UseDeferredRendering = false
                    })
                .UseSkia()
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI();

        // Your application's entry point. Here you can initialize your MVVM framework, DI
        // container, etc.
        private static void AppMain(Application app, string[] args)
        {
            var window = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };

            app.Run(window);
        }
    }
}