namespace MoviesMaestro.Interfaces
{
    public interface IProvider<T>
    {
        public T Get();
    }
}
