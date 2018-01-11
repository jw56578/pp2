## firebase push notifications
* https://developer.xamarin.com/guides/android/data-and-cloud-services/google-messaging/remote-notifications-with-fcm/
* tried following these instructions but when I tried to install the packages they would not install for some reason, I just installed one version back and it worked
* it says set the google-services.json build action to GoogleServices.json but that is not a choice untill I restart VS
* The service that retrieves the token was not being called until I cleaned and rebuilt the android project, but then the token keeps disappearing, i have to clean/rebuild every time
https://developer.xamarin.com/guides/android/data-and-cloud-services/google-messaging/remote-notifications-with-fcm/#Troubleshooting

* this is working but all it does is send a motification to the status bar. 
* how is the code told that the push happened so you can do something with it


* google-services.json is not included in source control, remember to add it back into root directory of Droid and set build action 


* https://developer.xamarin.com/guides/android/data-and-cloud-services/google-messaging/remote-notifications-with-fcm/#Add_the_Instance_ID_Receiver


# recieve push notifications when app is not running?
* https://forums.xamarin.com/discussion/27205/receive-push-notifications-when-app-is-not-running
