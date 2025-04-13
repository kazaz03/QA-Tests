using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using ProjectName.Stranice;

namespace ProjectName.Testovi
{
    public class KorpaTest : TestnaBaza
    {
        [Test]
        public void DodavanjeProizvodaUKorpu()
        {
            var homeStranica = new HomeStranica(Driver);
            string nazivProizvoda = "Versace Crystal Noir EDT";

            homeStranica.PretraziProizvod(nazivProizvoda);
            homeStranica.OdaberiProizvodIzRezultata(nazivProizvoda);
            var korpaStranica = new KorpaStranica(Driver);
            korpaStranica.DodajUKorpu();

            Assert.That(korpaStranica.ProvjeriProizvodUKorpi(nazivProizvoda), Is.True, "Proizvod nije dodan u korpu.");
        }

        [Test]
        public void PraznaKorpa()
        {
            var korpaStranica = new KorpaStranica(Driver);
            korpaStranica.OtvoriKorpu();
            Assert.That(korpaStranica.ProvjeriDaLiJeKorpaPrazna(), Is.True, "Korpa nije prazna nakon brisanja proizvoda.");
        }
    }
}