using LoadDWBigData.Data.Result;

namespace LoadDWBigData.Data.Interfaces
{
    public interface ILoadDwService
    {
        Task<OperationResult> LoadDWH();
    }
}
