using Newtonsoft.Json;

namespace LicenseCreatorWebLib
{
    public class LicenseHttpData(string name, string email, string hardwareKey, string passPhrase, DateTime expiry, string privateKey, string outputPath, LicenseType licenseType, LicenseSecurityType licenseSecurityType)
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

        public string ToJson(LicenseHttpData licenseHttpData)
        {
            return JsonConvert.SerializeObject(licenseHttpData, Formatting.Indented);
        }
    }
}
