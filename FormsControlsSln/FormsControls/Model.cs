using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FormsControls
{
    public class Model
    {
        // Имитация внешнего набора данных
        private Dictionary<int, Dictionary<string, string>> data = new Dictionary<int, Dictionary<string, string>>()
        {
            {1, new Dictionary<string, string>() { { "Name", "Button1" }, { "Type", "Button" }, { "Text","Кнопка"}, {"Left", "10" } , {"Top", "10" }, { "AutoEllipsis", "true" } } },
            {2, new Dictionary<string, string>() { { "Name", "TextBox1" }, { "Type", "TextBox" }, {"Text","Текст"}, {"Left", "150" } , {"Top", "100" }, { "AcceptsReturn", "true" } } }
        };

        public Dictionary<int, ControlBaseData> GetData()
        {
            Dictionary<int, ControlBaseData> dict = new Dictionary<int, ControlBaseData>();
            HashSet<string> names = new HashSet<string>();
            foreach (var item in data)
            {
                string name = item.Value[nameof(ControlData.Name)];
                if (names.Contains(name))
                    throw new Exception("У элементов одинаковые имена.");
                names.Add(name);

                ControlBaseData control = ControlBaseData.Greate(item.Key, item.Value);
                dict.Add(control.Id, control);
            }

            return dict;
        }

        public void Save(ICollection<ControlBaseData> data)
        {
            // Сохранение data

            MessageBox.Show("Надо сохранить элементы:" + string.Concat(data.Select(dt => Environment.NewLine + ((ControlData)dt).Name)));
        }
    }
}
