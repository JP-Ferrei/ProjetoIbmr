using Domain.Model;

namespace Data.Interface.Shared
{
    public interface IIbmrProvider
    {
        SessionAppModel SessionApp { get; }
        string GetHost();
    }
}
