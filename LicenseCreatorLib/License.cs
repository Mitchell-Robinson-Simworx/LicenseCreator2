using LicenseCreatorLib;
using System.Text;

namespace LicenseCreatorLib
{
    public class License
    {
        const string DATE_TIME_FORMAT = "dd/MM/yyyy HH:mm";

        public string Name { get; set; }
        public string Email { get; set; }
        public string HardwareKey { get; set; }
        public string PassPhrase { get; set; }
        public DateTime Expiry { get; set; }
        public string PrivateKey { get; set; }
        public string OutputPath { get; set; }
        public LicenseType LicenseType { get; set; }
        public LicenseSecurityType LicenseSecurityType { get; set; }

        public bool ToFile()
        {
            PrivateKey = File.ReadAllText(PrivateKey);

            Expiry = DateTime.ParseExact(Expiry.ToString(), DATE_TIME_FORMAT, null).ToLocalTime();

            var license = Portable.Licensing.License.New()
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