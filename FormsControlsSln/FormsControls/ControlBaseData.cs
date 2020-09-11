using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FormsControls
{
    public abstract class ControlBaseData
    {
        public int Id { get; }
        public ControlType Type { get; }

        protected ControlBaseData(int id, ControlType type)
        {
            Id = id;
            Type = type;
        }

        protected ControlBaseData(ControlType type)
            : this(int.MinValue, type)
        { }
        public abstract void SetValues(Dictionary<string, string> values);

        private static readonly Dictionary<string, ControlBaseData> derivedClasses = new Dictionary<string, ControlBaseData>();
        protected static void AddDerivedClasses(ControlBaseData control)
        {
            if (derivedClasses.TryGetValue(control.Type.TypeName, out ControlBaseData controlBase))
            {
                if (control.GetType() != controlBase.GetType())
                    throw new ArgumentException($"Тип {controlBase.GetType()} с таким ControlType.TypeName={controlBase.Type} уже добавлен, но отличается от переданного.", nameof(control));
            }
            else
            {
                derivedClasses.Add(control.Type.TypeName, control);
            }
        }

        public abstract void SetProperties(Control control);

        protected abstract Control CreateInstanceCoreUI();
        protected abstract ControlBaseData CreateInstanceCore(int id);
        public Control GreateUI()
        {
            Control control = CreateInstanceCoreUI();
            SetProperties(control);
            return control;
        }

        public static ControlBaseData Greate(int id, Dictionary<string, string> values)
        {
            if (!derivedClasses.TryGetValue(values[nameof(Type)], out ControlBaseData factory))
                throw new ArgumentException($"Tипа {values[nameof(Type)]} нет", nameof(values));

            ControlBaseData controlBase = factory.CreateInstanceCore(id);
            controlBase.SetValues(values);
            return controlBase;
        }
    }
}
