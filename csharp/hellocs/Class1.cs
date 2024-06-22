using Itjp.Ijcad.ApplicationServices;
using Itjp.Ijcad.DatabaseServices;
using Itjp.Ijcad.EditorInput;
using Itjp.Ijcad.Runtime;

namespace hellocs
{
    public class Class1
    {
        [CommandMethod("CSHELLO")]
        public void cmdCsHello()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            ed.WriteMessage("\nHello, World.");
        }

        [CommandMethod("CSHELLOMSG")]
        public void cmdCsHelloMsg()
        {
            Application.ShowAlertDialog("Hello, World");
        }
    }
}
