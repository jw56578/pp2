using System;
using Xamarin.Forms;

/*
refer to ios project Renderers/NoHelperEntryRenderer.cs
this is to prevent ios fixing what you type in for username and password fields and other inputs that you don't want auto corrected
https://developer.xamarin.com/recipes/cross-platform/xamarin-forms/ios/prevent-keyboard-suggestions/
*/
namespace pp2
{
    public class NoHelperEntry : Entry
    {

    }
}
