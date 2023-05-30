using Assets.CodeBase.Data.DTO.Responses;
using Assets.CodeBase.Odometer;
using Assets.CodeBase.UI.HUD;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Assets.CodeBase.App.Client
{
    public class MessageDispatcher
    {
        private readonly OdometerController _odometerController;
        private readonly HUDController _hudController;
        private Dictionary<string, Action<string>> _messageActions;

        public MessageDispatcher(OdometerController odometerController, HUDController hudController)
        {
            _messageActions = new Dictionary<string, Action<string>>
            {
                { "odometer_val", OnOdometerValue },
                { "currentOdometer", OnCurrentOdometerValue },
                { "randomStatus", OnRandomStatusValue }
            };
            _odometerController = odometerController;
            _hudController = hudController;
        }

        public void OnMessageComes(byte[] data)
        {
            var message = System.Text.Encoding.UTF8.GetString(data);
            Debug.Log(message);
            var requestOperation = JsonConvert.DeserializeObject<ResponseOperationDTO>(message);
            _messageActions[requestOperation.Operation].Invoke(message);
        }

        private void OnOdometerValue(string message)
        {
            var requestObject = JsonConvert.DeserializeObject<ResponseOdometerValueDTO>(message);
            if (requestObject.Value != null)
                _odometerController.SetValue(float.Parse(requestObject.Value, CultureInfo.InvariantCulture));
        }

        private void OnCurrentOdometerValue(string message)
        {
            var requestObject = JsonConvert.DeserializeObject<ResponseCurrentOdometerValueDTO>(message);
            if (requestObject.Value != null)
                _odometerController.SetValue(float.Parse(requestObject.Value, CultureInfo.InvariantCulture));
        }

        private void OnRandomStatusValue(string message)
        {
            var requestObject = JsonConvert.DeserializeObject<ResponseRandomValueDTO>(message);            
            _hudController.SetToggle(requestObject.Status);
        }
    }
}
