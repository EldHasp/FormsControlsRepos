using System.Collections.Generic;

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

        public bool AutoEllipsis { get; set; }

        public override void SetValue(Dictionary<string, string> values)
        {
            base.SetValue(values);
            string value;
            if (values.TryGetValue(nameof(AutoEllipsis), out value))
                AutoEllipsis = bool.Parse(value);

        }
    }
}
