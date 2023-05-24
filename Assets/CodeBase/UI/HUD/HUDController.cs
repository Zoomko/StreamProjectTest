using Assets.CodeBase.App;
using Assets.CodeBase.App.Client;
using Assets.CodeBase.Features.Lamp;
using Assets.CodeBase.UI.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CodeBase.UI.HUD
{
    public class HUDController
    {   
        private HUDView _view;

        public void SetView(HUDView view)
        {
            _view = view; 
        }
        public void SetToggle(bool value)
        {
            if (value)
            {
                _view.TrueToggle.isOn = true;
                _view.FalseToggle.isOn = false;
            }
            else
            {
                _view.FalseToggle.isOn = true;
                _view.TrueToggle.isOn = false;
            }
        }
    }
}
