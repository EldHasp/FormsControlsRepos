using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsControls
{
    public partial class ControlsView : Form
    {
        public event Action ControlsViewClose;
        public ControlsView()
        {
            InitializeComponent();

            FormClosed += ControlsView_FormClosed;
        }

        private void ControlsView_FormClosed(object sender, FormClosedEventArgs e)
            => ControlsViewClose?.Invoke();

        private readonly Dictionary<Control, ControlData> controlsData = new Dictionary<Control, ControlData>();
        IDictionary<int, ControlData> data;
        public void LoadControls(IDictionary<int, ControlData> data)
        {
            this.data = data;
            controlsData.Clear();
            Controls.Clear();
            foreach (var item in data)
            {
                if (item.Key != item.Value.Id)
                    throw new Exception("Идентификаторы не совпадают.");

                Control control = Create(item.Value);

                controlsData.Add(control, item.Value);
                Controls.Add(control);
            }
        }

        public ICollection<ControlData> GetControls()
            => data?.Values;

        
        public static Control Create(ControlData data)
        {
            Control control = null;
            if (data is ButtonData bData)
            {
                if (control == null)
                    control = new Button();
                Button button = (Button)control;
                button.AutoEllipsis = bData.AutoEllipsis;
            }
            if (data is TextBoxData tbData)
            {
                if (control == null)
                    control = new TextBox();
                TextBox tBox = (TextBox)control;
                tBox.AcceptsReturn = tbData.AcceptsReturn;
            }
            if (data is ControlData cntrData)
            {
                if (control == null)
                    control = new Control();
                control.Name = cntrData.Name;
                control.Text = cntrData.Text;
                control.Left = cntrData.Left;
                control.Top = cntrData.Top;
            }

            if (control == null)
                throw new Exception("Такой тип не обрабатывается.");

            return control;
        }
    }

}
