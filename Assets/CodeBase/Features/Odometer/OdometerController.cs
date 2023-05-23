using Assets.CodeBase.App;
using Assets.CodeBase.App.Services;


namespace Assets.CodeBase.Odometer
{
    public class OdometerController
    {  
        private readonly OdometerModel _model;
        private OdometerView _view;
        public OdometerController(CoroutineRunner coroutineRunner, IResourcesProvider resourceProvider)
        {
            _model = new OdometerModel(coroutineRunner, resourceProvider);
            _model.ValueChanged += OnValueChanged;
            _model.FinalValueSet += OnFinalValueSet;
        }

        public void SetView(OdometerView view)
        {
            _view = view;            
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
