using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseCreatorLib
{
    public class License(string name, string email, string hardwareKey, string passPhrase, DateTime expiry, string privateKey, string outputPath, LicenseType licenseType, LicenseSecurityType licenseSecurityType)
    {
        const string DATE_TIME_FORMAT = "dd/MM/yyyy HH:mm";
        public string Name { get; set; } = name;
        public string Email { get; set; } = email;
        public string HardwareKey { get; set; } = hardwareKey;
        public string PassPhrase { get; set; } = passPhrase;
        public DateTime Expiry { get; set; } = expiry;
        public string PrivateKey { get; set; } = privateKey;
        public string OutputPath { get; set; } = outputPath;
        public LicenseType LicenseType { get; set; } = licenseType;
        public LicenseSecurityType LicenseSecurityType { get; set; } = licenseSecurityType;

        public bool ToFile()
        {
            PrivateKey = File.ReadAllText(PrivateKey);

            Expiry = DateTime.ParseExact(Expiry.ToString(), DATE_TIME_FORMAT, null).ToLocalTime();

            Portable.Licensing.License license = Portable.Licensing.License.New()
                  .WithUniqueIdentifier(Guid.NewGuid())
                  .WithAdditionalAttributes(new Dictionary<string, string>()
                  {
                        { "HardwareId", HardwareKey },
                        { "SecurityType", LicenseSecurityType.ToString() },
                        { "Type", LicenseType.ToString() },
                  })
                  .ExpiresAt(LicenseType == LicenseType.Standard || LicenseType == LicenseType.Perpetual ? DateTime.MaxValue : Expiry)
                  .LicensedTo(Name, Email)
                  .CreateAndSignWithPrivateKey(PrivateKey, Email);

            if (OutputPath != null)
            {
                try
                {
                    File.WriteAllText(OutputPath, license.ToString(), Encoding.UTF8);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
    }
}
