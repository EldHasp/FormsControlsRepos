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
        }

        private void ControlsView_FormClosed(object sender, FormClosedEventArgs e)
            => ControlsViewClose?.Invoke();

        private readonly Dictionary<Control, ControlBaseData> controlsData = new Dictionary<Control, ControlBaseData>();
        IDictionary<int, ControlBaseData> data;
        public void LoadControls(IDictionary<int, ControlBaseData> data)
        {
            this.data = data;
            controlsData.Clear();
            Controls.Clear();
            foreach (var item in data)
            {
                if (item.Key != item.Value.Id)
                    throw new Exception("Идентификаторы не совпадают.");

                Control control = item.Value.GreateUI();

                controlsData.Add(control, item.Value);
                Controls.Add(control);
            }
        }

        public ICollection<ControlBaseData> GetControls()
            => data?.Values;

        
    }

}
