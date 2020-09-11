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
    public partial class MainView : Form
    {
        public event Action ControlsViewShow;
        public event Action ControlsSave;

        private Presenter presenter;

        public MainView()
        {
            InitializeComponent();

            presenter = new Presenter(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ControlsViewShow?.Invoke();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ControlsSave?.Invoke();
        }

        public void GetEnabledControlsViewShow(bool value)
            => button1.Enabled = value;

        public void GetEnabledControlsSave(bool value)
            => button2.Enabled = value;
    }
}
