namespace ForeverGaming.Models
{
    public interface IGameUnitOfWork
    {
        Repository<Game> Games { get; }
        Repository<Genre> Genres { get; }
        Repository<Type> Types { get; }
        Repository<Format> Formats { get; }

        void Save();
    }
}
