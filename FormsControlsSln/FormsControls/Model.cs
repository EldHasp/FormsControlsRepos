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

        public Dictionary<int, ControlData> GetData()
        {
            Dictionary<int, ControlData> dict = new Dictionary<int, ControlData>();
            HashSet<string> names = new HashSet<string>();
            foreach (var item in data)
            {
                if (names.Contains(item.Value["Name"]))
                    throw new Exception("У элементов одинаковые имена.");
                ControlData control;
                switch (item.Value["Type"])
                {
                    case "Button":
                        control = new ButtonData(item.Key);
                        break;
                    case "TextBox":
                        control = new TextBoxData(item.Key);
                        break;
                    case "Control":
                        control = new ControlData(item.Key);
                        break;
                    default:
                        throw new Exception("Такого типа элементов не существует.");
                }

                control.SetValue(item.Value);

                names.Add(control.Name);
                dict.Add(control.Id, control);
            }

            return dict;
        }

        public void Save(ICollection<ControlData> data)
        {
            // Сохранение data

            MessageBox.Show("Надо сохранить элементы:" + string.Concat(data.Select(dt => Environment.NewLine  + dt.Name)));
        }
    }
}
