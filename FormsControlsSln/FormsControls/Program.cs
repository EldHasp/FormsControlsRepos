using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsControls
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            presenter = new Presenter(new MainView());
            Application.Run(presenter.MainView);
        }

        /// <summary>Используемые типы</summary>
        static ControlBaseData[] usingControlBaseData =
        {
            new ButtonData(),
            new TextBoxData()
        };
        static Presenter presenter;
    }
}
