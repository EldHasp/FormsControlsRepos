using System.Collections.Generic;

namespace FormsControls
{

    public class ControlData
    {
        public int Id { get; }
        public ControlType Type { get; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }

        protected ControlData(int id, ControlType type)
        {
            Id = id;
            Type = type;
        }

        public ControlData(int id)
            : this(id, ControlType.Control)
        { }

        public ControlData()
            : this(ControlType.Control)
        { }


        protected ControlData(ControlType type)
            : this(int.MinValue, type)
        { }
        public virtual void SetValue(Dictionary<string, string> values)
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
    }
}
