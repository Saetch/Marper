using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marper.Logic;
using Marper.Cntrl;
namespace Marper
{

    //this class is supposed to wrap all the classes and logic needed to get a game running together
    internal static class Game
    {
        internal static void Singleplayer(MainWindow mw)
        {
            Model model = new Model();
            Controller cntrl = new Controller();

            mw.StartGameWithController(cntrl);
        }
    }


}
