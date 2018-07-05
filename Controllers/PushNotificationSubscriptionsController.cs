using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebPush;

namespace ExemploWebPushCore.Controllers
{
    public class PushNotificationSubscriptionsController : Controller
    {
        [HttpPost("api/push-notification-subscription")]
        public async Task<IActionResult> Create([FromBody] PushNotificationSubscription subscription)
        {
            var pushSubscription = new PushSubscription(subscription.Endpoint, subscription.Keys.P256dh, subscription.Keys.Auth);
            
            var vapidDetails = new VapidDetails(
                "mailto:example@yourdomain.org",
                "BAvyBimPt4GhPo5qWR-6GhPo6kMlwsmxGgVyRvuRYtEck0Hz4kLOG8lc23p3K_mRH1bgqUU5BdWzxMXb6boVzi4",
                "WgOFGuwBA8tVzVOQn2M-oFqtgZvlmvJtFLC1VHq-Pho");

            var webPushClient = new WebPushClient();
            webPushClient.SetVapidDetails(vapidDetails);
                                   
            //TODO; store pushsubscription for later use

            // send notification 
            var payload = new PushNotificationPayload
            {
                notification = new PushNotification
                {
                    title = "Titulo",
                    body = "Teste de notificacao",
                    icon = "assets/icon-128x128.png"
                }
            };

            var payloadSerialized = JsonConvert.SerializeObject(payload);

            try
            {
                await webPushClient.SendNotificationAsync(pushSubscription, payloadSerialized, vapidDetails);
            }
            catch (WebPushException exception)
            {
                var statusCode = exception.StatusCode;
                return new StatusCodeResult((int)statusCode);
            } 
           
            return new OkResult();
        }
    }
}