using Microsoft.EntityFrameworkCore;
using mserver.Models;

namespace mserver.Data
{
    public class TipoComidaService : ITipoComidaService
    {
        private readonly NetApiDbContext _context;
        public TipoComidaService(NetApiDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteOneComidum(int i)
        {
            var OneTipoComida = await _context.TipoComida.FindAsync(i);
            if (OneTipoComida != null)
            {
                _context.TipoComida.Remove(OneTipoComida);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<TipoComidum>> GetAllTiposoComidum()
        {
            return await _context.TipoComida.ToListAsync();
        }

        public async Task<TipoComidum?> GetOneComidum(int i)
        {
            var OneTipoComida = await _context.TipoComida.FindAsync(i);
            return OneTipoComida;
        }

        public async Task<bool> InsertOneComidum(TipoComidum TC)
        {
            _context.TipoComida.Add(TC);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> PutOneComidum(TipoComidum TC)
        {
            _context.Entry(TC).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveOneComidum(TipoComidum TC)
        {
            if (TC.TipoComidaId>0)
            {
                return await PutOneComidum(TC);
            }
            else
            {
                return await InsertOneComidum(TC);
            }
        }
    }
}
