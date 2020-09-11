using System.Collections.Generic;

namespace FormsControls
{
    public class Presenter
    {
        bool IsControlsView
        {
            get => _isControlsView;
            set
            {
                _isControlsView = value;
                mainView.GetEnabledControlsSave(IsControlsView);
                mainView.GetEnabledControlsViewShow(!IsControlsView);
            }
        }
        Dictionary<int, ControlData> data;

        private Model model = new Model();

        private readonly MainView mainView;
        private void ControlsSave()
        {
            if (IsControlsView)
                model.Save(controlsView.GetControls());
        }

        ControlsView controlsView;
        private bool _isControlsView = false;

        private void ControlsViewShow()
        {
            if (!IsControlsView)
            {
                controlsView = new ControlsView();
                controlsView.ControlsViewClose += ControlsViewClose;
                controlsView.LoadControls(data = model.GetData());
                IsControlsView = true;
            }

            controlsView.Show();
        }

        private void ControlsViewClose() => IsControlsView = false;
        public Presenter(MainView mainView)
        {
            this.mainView = mainView;
            mainView.ControlsViewShow += ControlsViewShow;
            mainView.ControlsSave += ControlsSave;
            IsControlsView = false;
       }
    }
}
