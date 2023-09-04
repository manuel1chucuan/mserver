using mserver.Models;

namespace mserver.Data
{
    public interface ITipoComidaService
    {
        Task<IEnumerable<TipoComidum>> GetAllTiposoComidum();
        Task<bool> InsertOneComidum(TipoComidum TC);
        Task<TipoComidum?> GetOneComidum(int i);
        Task<bool> PutOneComidum(TipoComidum TC);
        Task<bool> DeleteOneComidum(int i);
        Task<bool> SaveOneComidum(TipoComidum TC);
    }
}
