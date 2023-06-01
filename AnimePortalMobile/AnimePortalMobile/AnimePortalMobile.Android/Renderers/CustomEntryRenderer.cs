using Android.Graphics;
using AnimePortalMobile.CustomElements;
using AnimePortalMobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Xamarin.Forms.Color;

[assembly: ExportRenderer(typeof(RoundedEntry), typeof(CustomEntryRenderer))]

namespace AnimePortalMobile.Droid.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        private RoundedEntry Entry => Element as RoundedEntry;

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                //Control.Background = null;

                GradientStrokeDrawable drawable = new GradientStrokeDrawable();

                drawable.SetCornerRadius(Entry.CornerRadius);
                drawable.SetColor(Entry.BackgroundColor.ToAndroid());
                drawable.SetPadding((int)Entry.Padding.Left, (int)Entry.Padding.Top, (int)Entry.Padding.Right, (int)Entry.Padding.Bottom);
                //drawable.SetPadding(new Android.Graphics.Rect(Entry.Padding, Entry.Padding, Entry.Padding, Entry.Padding));

                Entry.BackgroundColor = Color.Transparent;

                Control.SetBackground(drawable);

                Control.SetTextCursorDrawable(Resource.Drawable.cursor);
            }
        }
    }
}