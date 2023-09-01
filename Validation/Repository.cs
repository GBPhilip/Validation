namespace Validation
{
    public class Repository : IRepository
    {
        public bool DoesIdExist(int id)
        {
            if (id == 5)
            {
                return true;
            }
            if (id == 7)
            {
                throw new InvalidOperationException();
            }
            return false;
        }


    }
}