using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services
{
    public interface ICatogeriesService
    {
        IEnumerable<SelectListItem> GetSelectList();
    }
}
