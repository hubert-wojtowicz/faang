namespace BoxDb.Contract
{
    public interface IBoxDb : IBoxDbInputHandler, IBoxDbOperation, IBoxDbTrasaction
    {
    }

    public interface IBoxDbInputHandler
    {
        string Handle(string input);
    }

    public interface IBoxDbOperation
    {
        void Set(string key, string value);
        string Get(string key);
        void Delete(string key);
        int Count(string value);
    }

    public interface IBoxDbTrasaction
    {
        void Begin();
        void Commit();
        void Rollback();
    }

    public interface IOperation
    {
    }

    public class SetOperation : IOperation
    {
    }
    public class GetOperation : IOperation
    {
    }
    public class DeleteOperation : IOperation
    {
    }
    public class RollbackOperation : IOperation
    {
    }
}
