using GameZone.Data;
using GameZone.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Repositories
{
    public class CatogeriesService : ICatogeriesService
    {
        ApplicationDbContext Context;
        public CatogeriesService(ApplicationDbContext dbContext)
        {
            Context = dbContext;
        }
        public IEnumerable<SelectListItem> GetSelectList()
        {
            return Context.Categories.Select(x => new
            SelectListItem
            { Value = x.Id.ToString(), Text = x.Name.ToString(), })
            .OrderBy(x => x.Text)
            .AsNoTracking()
            .ToList();
        }
    }
}
