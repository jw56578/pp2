using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using CoreGraphics;
using pp2;
using pp2.iOS;

//wth - vs is not recognizing the type NoHelperEntry unless i fully qualify it with namespace, its not recognizing anything beyond pp2
[assembly: ExportRenderer(typeof(pp2.NoHelperEntry), typeof(NoHelperEntryRenderer))]
namespace pp2.iOS
{
    public class NoHelperEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SpellCheckingType = UITextSpellCheckingType.No;             // No Spellchecking
                Control.AutocorrectionType = UITextAutocorrectionType.No;           // No Autocorrection
                Control.AutocapitalizationType = UITextAutocapitalizationType.None; // No Autocapitalization
            }
        }
    }
}