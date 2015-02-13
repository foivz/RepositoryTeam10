using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PIProjektFinal
{
    public class DataClass
    {
        T10_DBEntities db = new T10_DBEntities();
        Korisnik trenutni = new Korisnik();
        

        public void checkLoginData(string userName, string Password, Form login)
        {
            Korisnik user = new Korisnik();
            user = null;
            try
            {
                user = db.Korisnik.SingleOrDefault(e => e.KorisnickoIme == userName);
                if (user == null)
                {
                    System.Windows.Forms.MessageBox.Show("Pogrešno korisničko ime i/ili lozinka!", "Pogreška pri prijavi u sustav");
                    //ukoliko se ne poklapa username i password, javlja pogresku
                }
                else
                {
                    if (user.KorisnickoIme == userName && user.Lozinka == Password)
                    {
                        login.Hide();
                        MainMenuForm nova = new MainMenuForm(user);
                        nova.Show();
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Pogrešno korisničko ime i/ili lozinka!", "Pogreška pri prijavi u sustav");
                    }
                    

                    //ako je username i password tocan, skriva login formu i prikazuje glavnu formu
                }
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Greška");
                //ukoliko ne postoji internetska veza, nije moguće provjeriti podatke pa javlja grešku i nije moguće koristiti aplikaciju
            }
        }


        public List<Spis> GetSpisByUserID(int userID)
        {
            List<Spis> lista = new List<Spis>();
            lista = (from a in db.Spis where a.KreiraoOdvjetnik == userID select a).ToList();
            return lista;
            //vraca listu spisa za koje korisnik ima ovlasti da briše (preko id korisnika)
        }

        public List<Spis> GetAllSpis()
        {
            List<Spis> lista = new List<Spis>();
            lista = db.Spis.ToList();
            return lista;
            //vraca listu sa svim spisima
        }

        public List<UlogaKontakta> GetUlogaKontaktaList()
        {
            List<UlogaKontakta> lista = new List<UlogaKontakta>();
            lista = db.UlogaKontakta.ToList();
            return lista;
            // puni listu sa svim ulogama kontakta tipa svjedok, bilježnik, sudac itd.
        }
        public List<UlogaKorisnika> GetUlogaKorisnikaList()
        {
            List<UlogaKorisnika> lista = new List<UlogaKorisnika>();
            lista = db.UlogaKorisnika.ToList();
            return lista;
            //puni listu sa svim ulogama korisnika tipa admin, korisnik
        }

        public Spis GetSpisByID(int ID)
        {
            Spis novi = new Spis();
            novi = db.Spis.SingleOrDefault(e => e.ID == ID);
            return novi;
            //vraca spise po id-u
        }

        public List<TipPostupka> GetTipPostupkaList()
        {
            List<TipPostupka> lista = new List<TipPostupka>();
            lista = db.TipPostupka.ToList();
            return lista;
            //vraca listu sa svim tipovima postupaka
        }

        public List<Osoba> GetOsobaList()
        {
            List<Osoba> lista = new List<Osoba>();
            lista = db.Osoba.ToList();
            return lista;
            // vraca listu sa svim osobama (strankama i protustrankama)
        }

        public List<Osoba> GetOsobaList(int statusOsobe)
        {
            List<Osoba> lista = new List<Osoba>();
            lista = (from a in db.Osoba where a.StatusOsobe == statusOsobe select a).ToList();
            return lista;
            // vraca listu s osobama ovisno o statusu osobe tj. je li osoba pravna ili fizička osoba
        }

        public List<Osoba> GetOsobaList(int statusOsobe, int tipOsobe)
        {
            List<Osoba> listaOsoba1 = new List<Osoba>();
            List<Osoba> lista = new List<Osoba>();
            listaOsoba1 = (from a in db.Osoba where a.StatusOsobe == statusOsobe select a).ToList();
            lista = (from a in listaOsoba1 where a.TipOsobe == tipOsobe select a).ToList();
            return lista;
            // vraca listu s osoba ovisno o statusu osobe te o tipu osobe (je li osoba stranka ili protustranka)
        }

        public bool ProvjeriOvlasti(Korisnik korisnik)
        {
            if (korisnik.Uloga == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            // provjera ovlasti za brisanje kontakata i dogadaja + za dodavanje novog korisnika --> ako je admin onda može brisati i dodavati što želi ali ako je obični korisnik onda ne može ništa!
        }

        public bool provjeraOvlastiNaSpisu(Korisnik korisnik, Spis spis)
        {
            if (korisnik.ID == spis.KreiraoOdvjetnik || ProvjeriOvlasti(korisnik) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
            // provjera ovlasti za brisanje spisa --> ako je korisnik kreirao spis ili ako je korisnik admin ima pravo brisati spis
        }

        public TipPostupka GetTipPostupkaByID(int ID)
        {
            TipPostupka tip = db.TipPostupka.SingleOrDefault(e => e.ID == ID);
            return tip;
        }

        public List<TipInstitucije> GetTipInstitucijeList()
        {
            List<TipInstitucije> lista = new List<TipInstitucije>();
            lista = db.TipInstitucije.ToList();
            return lista;
            // varća listu sa svim tipovima institucija (županijski, općinski itd sud)
        }

        public List<Institucija> GetInstitucijaListByID(int ID)
        {
            List<Institucija> lista = (from a in db.Institucija where a.TipInstitucije == ID select a).ToList();
            return lista;
            // vraća listu institucija na temelju tipa institucije (županijski sud u zagrebu, u osijeku itd.)
        }

        public List<Kontakt> GetKontaktiByID(int ID, int uloga)
        {
            List<Kontakt> listaKonacna;
            List<Kontakt> lista = db.Institucija.Where(e => e.ID == ID).SelectMany(c => c.Kontakt).ToList();
            listaKonacna = (from a in lista where a.Uloga == uloga select a).ToList();
            return listaKonacna;
            // vraća listu kontakata s obzirom na njihovu ulogu i instituciju
        }

        public void DodajSpis(Spis spis)
        {
            db.Spis.Add(spis);
            db.SaveChanges();
            // dodavanje novog spisa
        }

        public List<StatusOsobe> GetStatusiOsobe()
        {
            List<StatusOsobe> lista = db.StatusOsobe.ToList();
            return lista;
            // vraća status osobe (fizička pravna)
        }

        public List<TipOsobe> GetTipOsobe()
        {
            List<TipOsobe> lista = db.TipOsobe.ToList();
            return lista;
            // vraća tip osobe (stranka protustranka)
        }

        public bool DodajOsobu(Osoba osoba)
        {
            try
            {
                db.Osoba.Add(osoba);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Korisnik> GetKorisnici()
        {
            List<Korisnik> lista = db.Korisnik.ToList();
            return lista;
        }

        public Korisnik GetKorisnikByID(int ID)
        {
            Korisnik korisnik = db.Korisnik.SingleOrDefault(e => e.ID == ID);
            return korisnik;
        }

        public void UpdateKorisnik(int ID, string Ime, string Prezime, string Adresa, string KorIme,string Lozinka, string tel, string email, int uloga)
        {
            try
            {
                Korisnik korisnik = db.Korisnik.SingleOrDefault(e => e.ID == ID);
                korisnik.Ime = Ime;
                korisnik.Prezime = Prezime;
                korisnik.Adresa = Adresa;
                korisnik.KorisnickoIme = KorIme;
                korisnik.Lozinka = Lozinka;
                korisnik.TelefonGlavni = tel;
                korisnik.email = email;
                korisnik.Uloga = uloga;
                db.SaveChanges();
                MessageBox.Show("Uspješno ste ažurirali korisnika " + korisnik.Ime + " " + korisnik.Prezime);
            }
            catch (Exception)
            {
                MessageBox.Show("Neuspjeh");
            }
            
        }
        
        public void  DeleteKorisnik(int ID)
        {
            try
            {
                Korisnik korisnik = db.Korisnik.SingleOrDefault(e => e.ID == ID);
                db.Korisnik.Remove(korisnik);
                db.SaveChanges();
                MessageBox.Show("Uspješno ste izbrisali korisnika");
            }
            catch (Exception)
            {
                MessageBox.Show("Korisnik i dalje ima dodanih spisa, prvo ih obrišite i onda obrišite korisnika");
            }
        }

        public void DodajKorisnika(Korisnik korisnik)
        {
            try
            {
                db.Korisnik.Add(korisnik);
                db.SaveChanges();
                MessageBox.Show("Uspješno ste dodali korisnika " + korisnik.Ime + " " + korisnik.Prezime);
            }
            catch (Exception)
            {
                MessageBox.Show("Neuspjeh");
            }
        }

        public void DeleteSpis(int IDSpis, Korisnik trenutni)
        {
            Spis spis = db.Spis.SingleOrDefault(e => e.ID == IDSpis);

            if (trenutni.Uloga == 1 || spis.KreiraoOdvjetnik == trenutni.ID)
            {
                try
                {
                    db.Spis.Remove(spis);
                    db.SaveChanges();
                    MessageBox.Show("Uspješno ste izbrisali spis");
                }
                catch (Exception)
                {
                    MessageBox.Show("Neuspjeh u brisanju spisa");
                }
            }
            else
            {
                MessageBox.Show("Nemate ovlasti za brisanje spisa!");
            }
            
        }

        public Dictionary<int,string> GetListaOdvjetnika()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>(); 
            foreach (var item in GetKorisnici())
            {
                dict.Add(item.ID, item.Ime + " " + item.Prezime);
            }
            return dict;
        }

        public Dictionary<string, string> GetListaStranaka(int status)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            List<Osoba> lista = (from a in db.Osoba where a.Spis.Count > 0 && a.StatusOsobe == status select a).ToList();// dohvaća listu osoba koje su stranke(bile one fizičke ili pravne) i koje imaju otvorene predmete
            if (status == 2)// ako je osoba fizicka radi sljedeće
            {
                foreach (var item in lista)
                {
                    dict.Add(item.OIB, item.Ime + " " + item.Prezime);
                }
                return dict;
            }
            else// ako je osoba pravna radi sljedeće
            {
                foreach (var item in lista)
                {
                    dict.Add(item.OIB, item.Naziv);
                }
                return dict;
            }
            
        }

        public List<TipDogadaja> GetTipDogadajaList()
        {
            List<TipDogadaja> lista = db.TipDogadaja.ToList();
            return lista;
        }

        public void DodajDogadaj(Dogadaj dogadaj)
        {
            db.Dogadaj.Add(dogadaj);
            db.SaveChanges();
        }

        public void DodajDogadaj(Dogadaj dogadaj, int spisID)
        {
            var nesto = GetSpisByID(spisID);
            db.Dogadaj.Add(dogadaj);
            nesto.Dogadaj.Add(dogadaj);
        }

        public void DodajDogadaj(Dogadaj dogadaj, int spisID, int OdvjetnikID)
        {
            var nesto = GetSpisByID(spisID);
            db.Dogadaj.Add(dogadaj);
            dogadaj.Korisnik.Add(GetKorisnikByID(OdvjetnikID));
            nesto.Dogadaj.Add(dogadaj);
        }

        public void DodajOdvStrDog(OdvjetnikStrankaImajuDogadaj dogadaj)
        {
            db.OdvjetnikStrankaImajuDogadaj.Add(dogadaj);
            db.SaveChanges();
        }

        public List<Dogadaj> GetDogadaji()
        {
            List<Dogadaj> lista = db.Dogadaj.ToList();
            return lista;
        }

        public void DeleteDogadaj(int dogadajID)
        {
            db.Dogadaj.Remove(db.Dogadaj.SingleOrDefault(e => e.ID == dogadajID));
            db.SaveChanges();
        }

        public List<Spis> GetSpisByOIB(string OIB)
        {
            List<Spis> lista = (from a in db.Spis where a.Stranka == OIB select a).ToList();
            return lista;
        }

        public List<Institucija> GetInstitucijaList()
        {
            List<Institucija> lista = db.Institucija.ToList();
            return lista;
        }

        public List<Osoba> GetOsobaByUloga(int uloga)
        {
            List<Osoba> lista = (from a in db.Osoba where a.StatusOsobe == uloga select a).ToList();
            return lista;
        }
    }
}
