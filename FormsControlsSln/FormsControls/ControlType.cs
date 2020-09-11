using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;

namespace FormsControls
{
    [DefaultProperty(nameof(TypeName))]
    public class ControlType : IEquatable<ControlType>, IEqualityComparer<ControlType>
    {
        public string TypeName { get; }

        protected ControlType(string typeName)
            => TypeName = !string.IsNullOrWhiteSpace(typeName)
            ? typeName.Trim()
            : throw new ArgumentNullException(nameof(typeName), "Имя не должно быть пустым.");

        public bool Equals(ControlType other)
            => other != null && TypeName == other.TypeName;
        public override bool Equals(object obj)
            => Equals(obj as ControlType);
        public override int GetHashCode()
            => -448171650 + EqualityComparer<string>.Default.GetHashCode(TypeName);

        public bool Equals(ControlType x, ControlType y)
        {
            if (x == null)
                return y == null;
            return x.TypeName.Equals(y.TypeName);
        }

        public int GetHashCode(ControlType obj)
           => obj?.GetHashCode() ?? 0;

        protected static readonly Dictionary<string, ControlType> types = new Dictionary<string, ControlType>();
        public static ControlType Control { get; } = GetControlType();
        public static ControlType Button { get; } = GetControlType();
        public static ControlType TextBox { get; } = GetControlType();

        public static ControlType GetControlType([CallerMemberName] string typeName = "")
        {
            if (!(types.TryGetValue(typeName, out ControlType type)))
                types.Add(typeName, type = new ControlType(typeName));

            return type;
        }
        public static ReadOnlyDictionary<string, ControlType> Types { get; }
        static ControlType()
        {
            Types = new ReadOnlyDictionary<string, ControlType>(types);
        }

        public override string ToString()
            => $"\"{TypeName}\"";
    }
}
