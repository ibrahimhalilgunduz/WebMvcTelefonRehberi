using WebMvcTelefonRehberi.Domain;

namespace WebMvcTelefonRehberi.BLManager.Abstract
{
    public interface IKisiManager : IManager<Kisi>
    {
        public bool CheckForGsm(string Gsm);
    }
}
