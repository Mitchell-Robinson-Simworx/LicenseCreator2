
using LicenseCreatorLib;
using System.ComponentModel.DataAnnotations;


namespace LicenseCreatorWeb.Model
{
    public class LicenseData
    {
        [Key]
        public uint id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string HardwareKey { get; set; }
        public DateTime Expiry { get; set; }
        public LicenseType LicenseType { get; set; }
        public LicenseSecurityType LicenseSecurityType { get; set; }
        public DateTime CreatedAt { get; set; }
        

        

        public LicenseData From(License license)
        {
            return new LicenseData
            {
                Name = license.Name,
                Email = license.Email,
                HardwareKey = license.HardwareKey,
                Expiry = license.Expiry,
                LicenseType = license.LicenseType,
                LicenseSecurityType = license.LicenseSecurityType,
                CreatedAt = DateTime.UtcNow,
            };
        }
    }
}
