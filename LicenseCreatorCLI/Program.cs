using LicenseCreatorWebLib;
using LicenseCreatorWeb;
using LicenseCreatorLib;
using System.Diagnostics;
using System.Net.Http;

namespace LicenseCreatorCLI
{
    public class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            //Spoofing getting the data.
            LicenseHttpData license = new LicenseHttpData("Mitch", "Mitch", "1826-D588-1A0C-3EC2-3651-58F8-E11B-E699", "s!mw0rx", DateTime.Now, @"Y:\MotionMaster\Licensing\Keys\MotionMaster-Private.key", @"C:\Users\mitchellrobinson\Desktop", LicenseCreatorWebLib.LicenseType.Standard, LicenseCreatorWebLib.LicenseSecurityType.Unlocked);

            //Converting to json.
            var licensejson = license.ToJson(license);
            Debug.WriteLine(licensejson);
            var content = new StringContent(licensejson);

            var res = client.PostAsync(@$"http://localhost:5152/API/License/", content);
        }
    }
}
    







