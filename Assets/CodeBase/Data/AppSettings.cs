using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.Data
{
    [CreateAssetMenu(fileName = "AppSettings", menuName = "AppSettings")]
    public class AppSettings : ScriptableObject
    {
        [Header("Odometer")]
        public float TimeToSetOdometer;
        [Header("Client")]
        public int TimeToReconnect;
        [Header("Lamp")]
        public float ChangeColorTime;
    }
}
