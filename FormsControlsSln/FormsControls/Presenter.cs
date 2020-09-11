using System;
using System.Collections.Generic;

namespace FormsControls
{
    public class Presenter
    {
        Dictionary<int, ControlBaseData> data;

        private Model model = new Model();

        public MainView MainView { get; }
        private void ControlsSave()
        {
            if (ControlsView != null)
                model.Save(ControlsView.GetControls());
        }

        private ControlsView _controlsView;
        ControlsView ControlsView
        {
            get => _controlsView;
            set
            {
                if (ControlsView != null)
                    ControlsView.ControlsViewClose -= ControlsViewClose;

                _controlsView = value;

                if (ControlsView != null)
                {
                    ControlsView.ControlsViewClose += ControlsViewClose;
                ControlsView.LoadControls(data = model.GetData());
                }

                MainView.GetEnabledControlsSave(ControlsView != null);
                MainView.GetEnabledControlsViewShow(ControlsView == null);

            }
        }

        private void ControlsViewShow()
        {
            if (ControlsView == null)
                ControlsView = new ControlsView();

            ControlsView.Show();
        }

        private void ControlsViewClose()
        {
            ControlsView = null;
        }

        public Presenter(MainView mainView)
        {
            MainView = mainView ?? throw new ArgumentNullException(nameof(mainView));
            mainView.ControlsViewShow += ControlsViewShow;
            mainView.ControlsSave += ControlsSave;
        }
    }
}
