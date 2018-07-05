namespace ExemploWebPushCore.Controllers
{
  public class PushNotificationPayload
  {
    public PushNotification notification { get; set; }

    public PushNotificationPayload()
    {
        notification = new PushNotification();
    }
  }

  public class PushNotification
  {
    public string title { get; set; }
    public string body { get; set; }
    public string icon { get; set; }
  }
}