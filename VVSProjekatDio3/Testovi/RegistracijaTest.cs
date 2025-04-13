using NUnit.Framework;
using ProjectName.Stranice;

namespace ProjectName.Testovi
{
    public class RegistracijaTest : TestnaBaza
    {
        [Test]
        public void UspjesnaRegistracijaSaValidnimPodacima()
        {
            var registracijaStranica = new RegistracijaStranica(Driver);

            registracijaStranica.OtvoriMojRacunStranicu();
            registracijaStranica.OtvoriRegistracijaStranicu();
            registracijaStranica.RegistracijaKorisnika("validanemail5@example.com", "JakaLozinka123!");

            Assert.That(
                registracijaStranica.RegistracijaUspjesna(),
                Is.True,
                "Registracija nije uspjela sa validnim podacima."
            );
        }

        [Test]
        public void NeuspjesnaRegistracijaSaSlabomLozinkom()
        {
            var registracijaStranica = new RegistracijaStranica(Driver);

            registracijaStranica.OtvoriMojRacunStranicu();
            registracijaStranica.OtvoriRegistracijaStranicu();
            registracijaStranica.RegistracijaKorisnika("validanemail@example.com", "123");

            Assert.That(
                registracijaStranica.RegistracijaUspjesna(),
                Is.False,
                "Registracija je uspjela sa slabom lozinkom, što je pogrešno."
            );
        }
    }
}