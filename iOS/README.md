## how do you implement firebase in ios
* https://components.xamarin.com/gettingstarted/firebaseioscloudmessaging
* Wow, these instructions are terrible
* install package Xamarin.Firebase.iOS.Core
* install package Xamarin.Firebase.iOS.CloudMessaging
* call Firebase.Core.App.Configure();
* implement interfaces on the AppDelegate
* make sure bundle id and name are correct regardless of what the project is named
* remember to add the GoogleService-Info.plist file that isn't in source control'
* this isn't working, the token is never being refreshed'