namespace ClausaComm_Installer.ClausaCommManipulation
{
    public abstract class ClausaCommManipulation
    {
        public const string ClausaCommSubkeyName = Program.ClausaCommName;
        public const string ClausaCommSubkeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\" + ClausaCommSubkeyName;
    }
}
