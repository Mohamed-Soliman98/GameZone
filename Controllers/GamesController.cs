

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;
        private readonly IGameService _gameService;

        public GamesController(ICategoriesService categoriesService, IDevicesService devicesService, IGameService gameService)
        {
            _categoriesService = categoriesService;
            _devicesService = devicesService;
            _gameService = gameService;
        }

        public IActionResult Index()
        {
            var games = _gameService.GetAll();
            return View(games);
        }
        public IActionResult Details(int id)
        {
            var game =_gameService.GetById(id);
            if (game == null)
                return NotFound();

            return View(nameof(Details),game);
        }
        [HttpGet]
        public IActionResult CreateGame()
        {
            CreateGameVM createGameVM = new()
            {
                Categories = _categoriesService.GetSelectList(),
                Devices = _devicesService.GetSelectList()
            };
            return View("CreateGame", createGameVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveGame(CreateGameVM model)
        {
            if (!ModelState.IsValid)
            {
               model.Categories =_categoriesService.GetSelectList();
               model.Devices = _devicesService.GetSelectList();
                
                return View("CreateGame",model);
            }
            else
            {
                await _gameService.Add(model);
                return RedirectToAction(nameof(CreateGame));
                
            }
        }
       

        public IActionResult Edit(int id)
        {
            var game = _gameService.GetById(id);
            if (game == null)
                return NotFound();

            EditGameFormVM editGameFormVM = new()
            {
                Id = id,
                Name = game.Name,
                Description = game.Description,
                CategoryId = game.CategorieId,
                SelectedDevices = game.Devices.Select(d => d.DeviceId).ToList(),
                Categories =_categoriesService.GetSelectList(),
                Devices = _devicesService.GetSelectList(),
                CurrentCover = game.Cover,
            };

            return View(editGameFormVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveEdit(EditGameFormVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetSelectList();
                model.Devices = _devicesService.GetSelectList();

                return View(model);
            }
            var game = await _gameService.Edit(model);
            if (game == null)
                return BadRequest();
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var _IsDeleted =_gameService.Delete(id);
            return _IsDeleted ? Ok() : BadRequest();
        }
    }
}
