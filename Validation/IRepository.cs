namespace Validation
{
    public interface IRepository
    {
        bool DoesIdExist(int Id);
    }
}