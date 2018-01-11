using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using UserNotifications;
using Firebase.InstanceID;
using Firebase.Core;
using Firebase.CloudMessaging;

namespace pp2.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, 
    IUNUserNotificationCenterDelegate, 
    IMessagingDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            Firebase.Core.App.Configure();

            RegisterForFirebaseNotifications();
           
            InstanceId.Notifications.ObserveTokenRefresh((sender, e) => {
                // Note that this callback will be fired everytime a new token is generated, including the first
                // time. So if you need to retrieve the token as soon as it is available this is where that
                // should be done.
                var refreshedToken = InstanceId.SharedInstance.Token;
                ConnectToFirebase();
                // Do your magic to refresh the token where is needed
            });





            return base.FinishedLaunching(app, options);
        }
        public void DidRefreshRegistrationToken(Messaging messaging, string fcmToken)
        {
           
        }
        public void ConnectToFirebase()
        {
            Firebase.CloudMessaging.Messaging.SharedInstance.Connect(
                error=>{

                }
            );
        }
        public void RegisterForFirebaseNotifications()
        {
            // Register your app for remote notifications.
            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                // iOS 10 or later
                var authOptions = UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound;
                UNUserNotificationCenter.Current.RequestAuthorization(authOptions, (granted, error) => {
                    Console.WriteLine(granted);
                });

                // For iOS 10 display notification (sent via APNS)
                UNUserNotificationCenter.Current.Delegate = this;

                // For iOS 10 data message (sent via FCM)
                Firebase.CloudMessaging.Messaging.SharedInstance.Delegate = this;
            }
            else
            {
                // iOS 9 or before
                var allNotificationTypes = UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound;
                var settings = UIUserNotificationSettings.GetSettingsForTypes(allNotificationTypes, null);
                UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
            }

            UIApplication.SharedApplication.RegisterForRemoteNotifications();

        }
        // To receive notifications in foregroung on iOS 9 and below.
        // To receive notifications in background in any iOS version
        public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
        {
            // If you are receiving a notification message while your app is in the background,
            // this callback will not be fired 'till the user taps on the notification launching the application.

            // Do your magic to handle the notification data
            System.Console.WriteLine(userInfo);
        }

        // To receive notifications in foreground on iOS 10 devices.
        [Export("userNotificationCenter:willPresentNotification:withCompletionHandler:")]
        public void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
        {
            // Do your magic to handle the notification data
            System.Console.WriteLine(notification.Request.Content.UserInfo);
        }

        // Receive data message on iOS 10 devices.
        public void ApplicationReceivedRemoteMessage(RemoteMessage remoteMessage)
        {
            Console.WriteLine(remoteMessage.AppData);
        }
        [Export("userNotificationCenter:didReceiveNotificationResponse:withCompletionHandler:")]
        public void DidReceiveNotificationResponse(UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler)
        {
            // Do your magic to handle the notification data
            //System.Console.WriteLine(userInfo);
        }
    }
}
