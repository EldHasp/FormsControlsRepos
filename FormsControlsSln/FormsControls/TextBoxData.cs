using System.Collections.Generic;

namespace FormsControls
{
    public class TextBoxData : ControlData
    {
        public TextBoxData(int id)
            : base(id, ControlType.TextBox)
        { }
        public TextBoxData()
            : base(ControlType.TextBox)
        { }

        public bool AcceptsReturn { get; set; }
        public override void SetValue(Dictionary<string, string> values)
        {
            base.SetValue(values);
            string value;
            if (values.TryGetValue(nameof(AcceptsReturn), out value))
                AcceptsReturn = bool.Parse(value);
        }
    }
}
