using DAL.Abstract;
using WebMvcTelefonRehberi.DAL.EfCore;
using WebMvcTelefonRehberi.Domain;

namespace DAL.EfCore
{
    public class KisilerRepository : BaseeDbRepository<Kisi>, IKisilerRepository
    {
    }
}
