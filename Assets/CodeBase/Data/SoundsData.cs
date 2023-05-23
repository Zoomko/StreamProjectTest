using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.CodeBase.Data
{
    [CreateAssetMenu(menuName ="SoundsCollection", fileName = "SoundsCollection")]
    public class SoundsData:ScriptableObject
    {        
        [SerializeField]
        private List<SoundData> _soundData;

        private Dictionary<string, AudioClip> _soundsCollection;  
        
        public Dictionary<string, AudioClip> SoundsCollection => _soundsCollection;   
        
        private void OnEnable()
        {
            _soundsCollection = new Dictionary<string, AudioClip>();         
            foreach(var sound in _soundData)
            {
                _soundsCollection.Add(sound.Name, sound.AudioClip);
            }          
            
        }
    }
}
