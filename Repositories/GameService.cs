

using GameZone.Settings;

namespace GameZone.Repositories
{
    public class GameService : IGameService
    {
        ApplicationDbContext Context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _ImagePath;
        public GameService(ApplicationDbContext application ,IWebHostEnvironment webHostEnvironment)
        {
             Context = application;
            _webHostEnvironment = webHostEnvironment;
            _ImagePath = $"{_webHostEnvironment.WebRootPath}{Filesettings.ImagesPath}";
        }
        public IEnumerable<Game> GetAll()
        {
            return Context.Games
                .Include(g => g.Categorie)
                .Include(g => g.Devices)
                .ThenInclude(d => d.Device)
                .AsNoTracking()
                .ToList();   
        }
        
        public Game? GetById(int id)
        {
            return Context.Games
                .Include(g => g.Categorie)
                .Include(g => g.Devices)
                .ThenInclude(d => d.Device)
                .AsNoTracking()
                .SingleOrDefault(x => x.Id == id);


        }
        public async Task Add(CreateGameVM model)
        {
            var CoveName =await SaveCover(model.Cover);

            Game game = new()
            {
                Name = model.Name,
                Description = model.Description,
                CategorieId = model.CategoryId,
                Cover = CoveName,
                Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList()

            };
            Context.Add(game);
            await Context.SaveChangesAsync();
        }

        public async Task<Game?> Edit(EditGameFormVM model)
        {
            var game = Context.Games
                .Include(x => x.Devices)
                .SingleOrDefault(c => c.Id == model.Id);

            if (game is null)
                return null;

            var hasnewcover = model.Cover is not null;

            var OldCover = game.Cover;
               
            game.Name = model.Name;
            game.Description = model.Description;
            game.CategorieId = model.CategoryId;
            game.Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList();
            if (hasnewcover)
            {
                game.Cover = await SaveCover(model.Cover!);
            }

            var x = await Context.SaveChangesAsync();
            if (x > 0)
            {
                if (hasnewcover)
                {
                    var cover = Path.Combine(_ImagePath, OldCover);
                    File.Delete(cover);
                }
                return game;
            }
            else
            {
                var Cover = Path.Combine(_ImagePath, game.Cover);
                File.Delete(Cover);
                return null;
            }
        }
        private async Task<string> SaveCover(IFormFile cover)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
            var path = Path.Combine(_ImagePath, coverName);
            using var stream = File.Create(path);
            await cover.CopyToAsync(stream);
            return coverName;
        }

        public bool Delete(int id)
        {
            var IsDeleted = false;
            var game = Context.Games.Find(id);
            if (game is null)
                return IsDeleted;

            Context.Remove(game);
            var save = Context.SaveChanges();
            if (save > 0)
            {
                IsDeleted = true;
                var cover = Path.Combine(_ImagePath, game.Cover);
                File.Delete(cover);
            }
            return IsDeleted;
        }
    }
}
