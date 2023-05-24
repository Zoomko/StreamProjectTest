using Assets.CodeBase.App;
using Assets.CodeBase.App.Services;


namespace Assets.CodeBase.Odometer
{
    public class OdometerController
    {  
        private readonly OdometerModel _model;
        private readonly AudioController _audioController;
        private OdometerView _view;
        public OdometerController(CoroutineRunner coroutineRunner, IResourcesProvider resourceProvider, AudioController audioController)
        {
            _model = new OdometerModel(coroutineRunner, resourceProvider);
            _model.ValueChanged += OnValueChanged;
            _model.FinalValueSet += OnFinalValueSet;
            _audioController = audioController;
        }

        public void SetView(OdometerView view)
        {
            _view = view;
            _view.Constructor(_audioController);
        }

        public void SetValue(float value)
        {
            _model.SetValue(value);
        }

        private void OnValueChanged(float value)
        {
            _view.SetNumber(value);
        }

        private void OnFinalValueSet(float value)
        {
            _view.SetFinalNumber(value);
        }

    }
}
