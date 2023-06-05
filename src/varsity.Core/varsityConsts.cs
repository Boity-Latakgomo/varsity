using varsity.Debugging;

namespace varsity
{
    public class varsityConsts
    {
        public const string LocalizationSourceName = "varsity";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "efb05b7cc3164f23943a135fabd35674";
    }
}
