using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI
{
    class DatabaseManipulationClass
    {
        T10_DBEntities db = new T10_DBEntities();
        private List<Spis> lista = new List<Spis>();
        private List<Kontakt> kontakti = new List<Kontakt>();
        public DatabaseManipulationClass()
        {
            db.Database.Connection.Open();
        }

        public void checkLoginData(string argUserName, string argPassword, Form argForm)
        {
            Odvjetnik korisnik = null;
            try
            {
                korisnik = db.Odvjetnik.SingleOrDefault(e => e.KorisnickoIme == argUserName);

                if (korisnik == null)
                {
                    MessageBox.Show("Netočna lozinka/korisničko ime!");
                }
                else
                {
                    if (korisnik.KorisnickoIme == argUserName && korisnik.Lozinka == argPassword)
                    {
                        argForm.Hide();
                        MainMenuForm mm = new MainMenuForm(korisnik);
                        mm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Netočna lozinka/korisničko ime!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Greška pri spajanju na server!");
            }
        }

        public List<Spis> getSpis()
        {
            lista = db.Spis.ToList();
            return lista;
        }

        public List<Kontakt> getKontakti()
        {
            kontakti = db.Kontakt.ToList();
            return kontakti;
        }
    }
}
