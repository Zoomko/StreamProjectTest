using Assets.CodeBase.Data.DTO.Requests;
using Newtonsoft.Json;

namespace Assets.CodeBase.App.Client
{
    public class MessageSender
    {
        private const string CurrentOdometerOperation = "currentOdometer";
        private const string RandomOdometerOperation = "getRandomStatus";
        private readonly WebSocketClient _webSocketClient;

        public MessageSender(WebSocketClient webSocketClient)
        {
            _webSocketClient = webSocketClient;
        }

        public void SendCurrentValueMessage()
        {
            SendMessage(CurrentOdometerOperation);
        }

        public void SendRandomStatusValueMessage()
        {
            SendMessage(RandomOdometerOperation);
        }

        private void SendMessage(string messageId)
        {
            var requestDTO = new RequestDTO();
            requestDTO.Operation = messageId;
            var requestString = JsonConvert.SerializeObject(requestDTO);
            _webSocketClient.Send(requestString);
        }
    }
}
