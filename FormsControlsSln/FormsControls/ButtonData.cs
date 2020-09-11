using System.Collections.Generic;
using System.Windows.Forms;

namespace FormsControls
{
    public class ButtonData : ControlData
    {
        public ButtonData(int id)
            : base(id, ControlType.Button)
        { }
        public ButtonData()
            : base(ControlType.Button)
        { }

        protected ButtonData(int id, ControlType type)
        : base(id, type)
        { }

        protected ButtonData(ControlType type)
            : base(type)
        { }

        static ButtonData()
        {
            AddDerivedClasses(new ButtonData());
        }


        public bool AutoEllipsis { get; set; }

        public override void SetValues(Dictionary<string, string> values)
        {
            base.SetValues(values);
            string value;
            if (values.TryGetValue(nameof(AutoEllipsis), out value))
                AutoEllipsis = bool.Parse(value);

        }

        public override void SetProperties(Control control)
        {
            if (control is Button button)
            {
                button.AutoEllipsis = AutoEllipsis;
            }    
            base.SetProperties(control);
        }

        protected override Control CreateInstanceCoreUI()
            => new Button();

        protected override ControlBaseData CreateInstanceCore(int id)
            => new ButtonData(id);

    }
}
