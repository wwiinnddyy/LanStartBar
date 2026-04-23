using Jalium.UI;
using Jalium.UI.Controls;
using Jalium.UI.Media;
using Jalium.UI.Interop;

namespace LanStartBar;

public enum BackdropStyle
{
    Normal,
    FrostedGlass,
    Mica,
    Acrylic,
    LiquidGlass
}

public class GlassBorder : Border
{
    public static readonly DependencyProperty BackdropStyleProperty =
        DependencyProperty.Register(
            nameof(BackdropStyle),
            typeof(BackdropStyle),
            typeof(GlassBorder),
            new PropertyMetadata(BackdropStyle.Normal, OnBackdropStyleChanged));

    public BackdropStyle BackdropStyle
    {
        get => (BackdropStyle)(GetValue(BackdropStyleProperty) ?? BackdropStyle.Normal);
        set => SetValue(BackdropStyleProperty, value);
    }

    private static void OnBackdropStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((GlassBorder)d).InvalidateVisual();
    }

    protected override void OnRender(object drawingContext)
    {
        if (drawingContext is not DrawingContext dc)
            return;

        var rect = new Rect(0, 0, ActualWidth, ActualHeight);
        var cr = CornerRadius;

        switch (BackdropStyle)
        {
            case BackdropStyle.FrostedGlass:
                dc.DrawBackdropEffect(
                    rect,
                    new FrostedGlassEffect(
                        blurRadius: 30f,
                        noiseIntensity: 0.04f,
                        tintColor: Color.FromArgb(220, 245, 245, 250),
                        tintOpacity: 0.5f),
                    cr);
                break;

            case BackdropStyle.LiquidGlass:
                if (drawingContext is RenderTargetDrawingContext rtdc)
                {
                    rtdc.DrawLiquidGlass(
                        rect,
                        cornerRadius: (float)cr.TopLeft,
                        blurRadius: 12f,
                        refractionAmount: 55f);
                }
                else
                {
                    dc.DrawBackdropEffect(
                        rect,
                        new FrostedGlassEffect(20f),
                        cr);
                }
                break;

            default:
                base.OnRender(drawingContext);
                break;
        }
    }
}
