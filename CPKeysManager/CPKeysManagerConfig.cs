using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPKeysManager
{
    class CPKMConfig
    {
        public const string baseCPKey = @"SOFTWARE\WOW6432Node\Crypto Pro\Settings\Users";
        public const string baseCPKKey = @"Keys";

        public const string baseUKey = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList";
        public const string piKey = @"ProfileImagePath";

        public const string keyFilter = @"S-1-5-21";

        public const string baseUDNKey = @"Volatile Environment";
        public const string unKey = @"USERNAME";
        public const string dnKey = @"USERDOMAIN";

        public const string pathCsptest = @"C:\Program Files\Crypto Pro\CSP\csptest.exe";
        public const string pathCertmgr = @"C:\Program Files\Crypto Pro\CSP\certmgr.exe";
        public const string pathReg = @"reg.exe";
        public const string pathSchtasks = @"schtasks.exe";

    }
}
