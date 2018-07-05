namespace ExemploWebPushCore.Controllers
{
  public class PushNotificationSubscription
  {
    public string Endpoint { get; set; }
    public PushNotificationSubscriptionKeys Keys { get; set; }

    // public PushNotificationSubscription()
    // {
    //   Keys = new PushNotificationSubscriptionKeys();
    // }
  }

  public class PushNotificationSubscriptionKeys
  {
    public string P256dh { get; set; }
    public string Auth { get; set; }
  }
}