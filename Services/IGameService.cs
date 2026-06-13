using GameZone.ViewModel;

namespace GameZone.Services
{
    public interface IGameService
    {
        public IEnumerable<Game> GetAll();
        public Game? GetById(int id);
        public Task<Game?> Edit(EditGameFormVM editGame);
        public bool Delete (int id);
        public Task Add(CreateGameVM createGame);
    }
}
