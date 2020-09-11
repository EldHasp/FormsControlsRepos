using System.Collections.Generic;
using System.Windows.Forms;

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

        protected TextBoxData(int id, ControlType type)
        : base(id, type)
        { }

        protected TextBoxData(ControlType type)
            : base(type)
        { }

        static TextBoxData()
        {
            AddDerivedClasses(new TextBoxData());
        }


        public bool AcceptsReturn { get; set; }
        public override void SetValues(Dictionary<string, string> values)
        {
            base.SetValues(values);
            string value;
            if (values.TryGetValue(nameof(AcceptsReturn), out value))
                AcceptsReturn = bool.Parse(value);
        }
        public override void SetProperties(Control control)
        {
            if (control is TextBox textBox)
            {
                textBox.AcceptsReturn = AcceptsReturn;
            }
            base.SetProperties(control);
        }

        protected override Control CreateInstanceCoreUI()
            => new TextBox();
        protected override ControlBaseData CreateInstanceCore(int id)
            => new TextBoxData(id);

    }
}
