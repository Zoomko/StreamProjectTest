using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.UI.Menu
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField]
        private GameObject _rootPanel;
        
        [SerializeField]
        private TMP_InputField _serverIP;
        [SerializeField]
        private TMP_InputField _serverPort;
        [SerializeField]
        private TMP_InputField _broadcastAddress;

        [SerializeField]
        private Slider _soundsVolume;
        [SerializeField]
        private Slider _musicVolume;

        [SerializeField]
        private Toggle _muteSounds;
        [SerializeField]
        private Toggle _muteMusic;

        [SerializeField]
        private Button _closeButton;
        [SerializeField]
        private Button _saveButton;

        public TMP_InputField ServerIP => _serverIP;
        public TMP_InputField ServerPort => _serverPort;
        public TMP_InputField BroadcastAddress => _broadcastAddress;
        public Slider SoundsVolume => _soundsVolume;
        public Slider MusicVolume => _musicVolume;
        public Toggle MuteSounds => _muteSounds;
        public Toggle MuteMusic => _muteMusic;
        public Button CloseButton => _closeButton;
        public Button SaveButton => _saveButton;


        private void Start()
        {
            _rootPanel.transform.localScale = Vector3.zero;
            LeanTween.scale(_rootPanel, Vector3.one, 0.5f);
        }

        public void Close()
        {
            LeanTween.scale(_rootPanel, Vector3.zero, 0.5f).setOnComplete(()=>Destroy(gameObject));
        }
    }
}
