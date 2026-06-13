using GameZone.Data;
using GameZone.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Repositories
{
    public class DevicesService : IDevicesService
    {
        ApplicationDbContext Context;
        public DevicesService(ApplicationDbContext dbContext)
        {
            Context = dbContext;
        }
        public IEnumerable<SelectListItem> GetSelectList()
        {
            return Context.Devices.Select(x => new
            SelectListItem { Value = x.Id.ToString(), Text = x.Name.ToString(), })
            .OrderBy(x => x.Text)
            .AsNoTracking()
           .ToList();
        }
    }
}
 