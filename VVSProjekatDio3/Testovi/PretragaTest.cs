using NUnit.Framework;
using ProjectName.Stranice;

namespace ProjectName.Testovi
{
    public class PretragaTest : TestnaBaza
    {
        [Test]
        public void UspjesnaPretragaSaPostojecimNazivomProizvoda()
        {
            var pretragaStranica = new PretragaStranica(Driver);
            string nazivProizvoda = "Versace Crystal Noir EDT";

            pretragaStranica.UnesiUpitPretrage(nazivProizvoda);

            Assert.That(pretragaStranica.RezultatPrikazan(nazivProizvoda), Is.True, "Rezultat pretrage nije pronađen.");
        }

        [Test]
        public void UspjesnaPretragaZaDjelimicniNazivProizvoda()
        {
            var pretragaStranica = new PretragaStranica(Driver);
            string djelimicniNaziv = "Crystal Noir";
            string puniNaziv = "Versace Crystal Noir EDT";

            pretragaStranica.UnesiUpitPretrage(djelimicniNaziv);

            Assert.That(pretragaStranica.RezultatPrikazan(puniNaziv), Is.True, "Rezultat pretrage za djelimičan naziv nije pronađen.");
        }

        [Test]
        public void NeuspjesnaPretragaZaNepostojeciNaziv()
        {
            var pretragaStranica = new PretragaStranica(Driver);
            string nepostojeciNaziv = "Amina1";

            pretragaStranica.UnesiUpitPretrage(nepostojeciNaziv);

            Assert.That(pretragaStranica.NemaRezultata(nepostojeciNaziv), Is.True, "Poruka o grešci nije prikazana za neuspješnu pretragu.");
        }

        [Test]
        public void NeuspjesnaPretragaZaNasumicniNizZnakova()
        {
            var pretragaStranica = new PretragaStranica(Driver);
            string nasumicniNiz = "cyz829";

            pretragaStranica.UnesiUpitPretrage(nasumicniNiz);

            Assert.That(pretragaStranica.NemaRezultata(nasumicniNiz), "Poruka o grešci nije prikazana za neuspješnu pretragu.");
        }

        [Test]
        public void NeuspjesnaPretragaZaPrazanString()
        {
            var pretragaStranica = new PretragaStranica(Driver);
            string prazanUnos = "";

            pretragaStranica.UnesiUpitPretrage(prazanUnos);

            Assert.That(pretragaStranica.NemaRezultata(prazanUnos), "Poruka o grešci nije prikazana za prazan unos.");
        }
    }
}