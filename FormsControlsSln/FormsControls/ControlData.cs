using System.Collections.Generic;
using System.Windows.Forms;

namespace FormsControls
{
    public class ControlData : ControlBaseData
    {


        public ControlData(int id)
            : base(id, ControlType.Control)
        { }

        public ControlData()
            : base(ControlType.Control)
        { }

        protected ControlData(int id, ControlType type)
            :base(id, type)
        { }

        protected ControlData(ControlType type)
            : base( type)
        { }

        protected override Control CreateInstanceCoreUI()
            => new Control();

        protected override ControlBaseData CreateInstanceCore(int id)
            => new ControlData(id);

        static ControlData()
        {
            AddDerivedClasses(new ControlData());
        }

        public string Name { get; set; }
        public string Text { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public override void SetValues(Dictionary<string, string> values)
        {
            string value;
            if (values.TryGetValue(nameof(Name), out value))
                Name = value;
            if (values.TryGetValue(nameof(Text), out value))
                Text = value;
            if (values.TryGetValue(nameof(Left), out value))
                Left = int.Parse(value);
            if (values.TryGetValue(nameof(Top), out value))
                Top = int.Parse(value);
        }

        public override void SetProperties(Control control)
        {
            control.Text = Text;
            control.Name = Name;
            control.Top = Top;
            control.Left = Left;
        }

    }
}
