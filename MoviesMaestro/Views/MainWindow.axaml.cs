using Avalonia.Controls;
using FluentAvalonia.UI.Windowing;

namespace MoviesMaestro.Views;

public partial class MainWindow : AppWindow
{
    public MainWindow()
    {
        InitializeComponent();

        TitleBar.TitleBarHitTestType = TitleBarHitTestType.Complex;
        TitleBar.ExtendsContentIntoTitleBar = true;
    }

}
