using LicenseCreatorLib;
using LicenseCreatorWeb.Model;
using LicenseCreatorWebLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace LicenseCreatorWeb.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private readonly DatabaseContext m_databaseContext;

        public LicenseController(DatabaseContext databaseContext)
        {
            m_databaseContext = databaseContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LicenseData>> Get(int id)
        {
            var license = await m_databaseContext.Licenses.FindAsync(id);

            if (license == null)
            {
                return NotFound();
            }

            return license;
        }

        [HttpPost]
        public async Task<ActionResult<LicenseData>> Create([FromBody] License license)
        {
            //License? license = JsonConvert.DeserializeObject<License>(json);
            license?.ToFile();

           // await m_databaseContext.SaveChangesAsync();
            return Ok(license);

            //return CreatedAtAction("GetLicense", new { id = license.Id }, license);
        }

    }
}
