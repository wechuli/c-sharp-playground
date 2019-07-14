using System;
namespace access_static_non_static
{
    class SystemInfo
    {
        private static double version = 0.1;
        private static string vendor = "Microsoft";

        //The "version" static property
        public static double version
        {
            get { return version; }
            set { version = value; }
        }
        //The 'vendor' static property
        public static string Vendor
        {
            get { return vendor; }
            set { vendor = value; }
        }
    }
}