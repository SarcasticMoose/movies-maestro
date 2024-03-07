using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Material.Icons;

namespace MoviesMaestro.Controls
{
    public class MenuItem : ToggleButton
    {
        public MaterialIconKind? Kind
        {
            get => (MaterialIconKind)GetValue(KindProperty)!;
            set => SetValue(KindProperty, value);
        }

        public static readonly AvaloniaProperty KindProperty = AvaloniaProperty.Register<MenuItem, MaterialIconKind>(nameof(Kind));

        public MenuItem()
        {
            Kind = MaterialIconKind.ApacheKafka;
        }
    }
}
