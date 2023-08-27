using System;
using System.Linq;
using WebMvcTelefonRehberi.BLManager.Abstract;
using WebMvcTelefonRehberi.Domain;

namespace WebMvcTelefonRehberi.BLManager.Concrete
{
    public class KisiManager : ManagerBase<Kisi>, IKisiManager
    {
        public bool CheckForGsm(string Gsm)
        {
            var ogrenci = base.db.GetAll(x => x.Gsm == Gsm).FirstOrDefault();

            if (ogrenci != null)
                throw new Exception($"{Gsm} Numarasi Daha Onceden Kaydedilmistir");

            return false;
        }
    }
}
