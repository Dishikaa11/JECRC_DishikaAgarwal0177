using System;

namespace DelegateNotificationDemo
{
    // 🔹 Step 1: Create Delegate
    public delegate void NotificationSender(string message);

    // 🔹 Step 2: Create Notifiers Class
    class Notifiers
    {
        public static void SendEmail(string message)
        {
            Console.WriteLine("Email Sent: " + message);
        }

        public static void SendSMS(string message)
        {
            Console.WriteLine("SMS Sent: " + message);
        }

        public static void SendPushNotification(string message)
        {
            Console.WriteLine("Push Notification Sent: " + message);
        }
    }

    // 🔹 Step 3: Notification Manager Class
    class NotificationManager
    {
        public void NotifyUser(string message, NotificationSender sender)
        {
            sender(message);   // Delegate Invocation
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NotificationManager manager = new NotificationManager();

            // 🔹 Send Email
            manager.NotifyUser("Welcome to our app!", Notifiers.SendEmail);

            // 🔹 Send SMS
            manager.NotifyUser("Your OTP is 1234", Notifiers.SendSMS);

            // 🔹 Send Push Notification
            manager.NotifyUser("You have a new message", Notifiers.SendPushNotification);

            Console.ReadLine();
        }
    }
}
