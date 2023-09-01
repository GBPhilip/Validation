namespace Validation
{
    public interface IRepository
    {
        bool DoesIdExist(int Id);
        Task<bool> DoesIdExistAsync(int Id);
    }
}