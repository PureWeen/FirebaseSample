

using Android.App;
using Android.Content;
using Firebase.Iid;
using Firebase.Messaging;
using System;

namespace FirebaseFun.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseIIDService : FirebaseInstanceIdService
    {
        private static string _Token = String.Empty;
        public static string GetToken(Context context = null)
        { 
            if (String.IsNullOrWhiteSpace(_Token))
            {
                return _Token;
            }
            //If you just try to retrieve the token without checking GetApps this happens
            //Java.Lang.IllegalStateException: Default FirebaseApp is not initialized in this process com.shane.firebasefun. Make sure to call FirebaseApp.initializeApp(Context) first.
            else if (Firebase.FirebaseApp.GetApps(context ??  Android.App.Application.Context).Count != 0)
            {
                _Token = FirebaseInstanceId.Instance.Token;
            }

            return _Token;
        }
         
        const string TAG = "MyFirebaseIIDService";
        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            _Token = refreshedToken;
        }
    }


    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "MyFirebaseMsgService";
         
        public override void OnMessageReceived(RemoteMessage message)
        {

        }
    }


     
    //public static class PushHandlerService
    //{
    //    static NotificationHub Hub;

    //    static public string RegistrationID
    //    {
    //        get { return MyFirebaseIIDService.Token; }
    //    }

 


    //    public static NotificationHub GetNotificationHub(Context context = null)
    //    {
    //        if (Hub != null)
    //            return Hub;

    //        context = context ??
    //                AndroidDeviceInfoClient.GetMeSomeContext();


    //        if (ClientFactory.IsStaging)
    //        {
    //            Hub = new NotificationHub(
    //                 PingARing.Mobile.Constants.AzureNotificationHub.NotificationHubNameStaging,
    //                 PingARing.Mobile.Constants.AzureNotificationHub.ConnectionStringWeUseStaging,
    //                 context);
    //        }
    //        else
    //        {
    //            Hub = new NotificationHub(
    //                PingARing.Mobile.Constants.AzureNotificationHub.NotificationHubName,
    //                PingARing.Mobile.Constants.AzureNotificationHub.ConnectionStringWeUse,
    //                context);
    //        }

    //        //Hub.Unregister();
             
    //        return Hub;
    //    } 
        
         
    //}

}