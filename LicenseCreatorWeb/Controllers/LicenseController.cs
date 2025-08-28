using LicenseCreatorLib;
using LicenseCreatorWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<LicenseData>> GetLicense(int id)
        {
            var license = await m_databaseContext.Licenses.FindAsync(id);

            if (license == null)
            {
                return NotFound();
            }

            return license;
        }

        [HttpPost]
        public async Task<ActionResult<LicenseData>> CreateLicense(LicenseData license)
        {
            license.Id = 0;
            license.CreatedAt = DateTime.UtcNow;
            m_databaseContext.Licenses.Add(license);
            await m_databaseContext.SaveChangesAsync();

            return CreatedAtAction("GetLicense", new { id = license.Id }, license);
        }

    }
}
