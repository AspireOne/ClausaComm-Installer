using System.Threading;

namespace ClausaComm_Installer.Utils
{
    public static class ThreadUtils
    {
        public static Thread GetThread(ThreadStart action, bool sta)
        {
            var t = new Thread(action)
            {
                IsBackground = true,
                Name = "ClausaComm child thread"
            };

            if (sta)
                t.SetApartmentState(ApartmentState.STA);

            return t;
        }

        public static void RunThread(ThreadStart action, bool sta)
        {
            GetThread(action, sta).Start();
        }
    }
}