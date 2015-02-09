using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public class DataManipClass
    {
        T10_DBEntities db = new T10_DBEntities();
        private List<Spis> lista = new List<Spis>();

        public void checkLoginData(string userName, string Password, Form login)
        {
            Odvjetnik user = new Odvjetnik();
            user = null;
            try
            {
                user = db.Odvjetnik.SingleOrDefault(e => e.KorisnickoIme == userName);
                if (user == null)
                {
                    System.Windows.Forms.MessageBox.Show("Pogrešno korisničko ime i/ili lozinka!", "Pogreška pri prijavi u sustav");
                }
                else
                {
                    login.Hide();
                    Form1 nova = new Form1(user);
                    nova.Show();
                }
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Greška pri spajanju na server, provjerite vezu s internetom!");
            }
        }

        public List<Spis> GetSpisByUserID(int userID)
        {
            lista = (from a in db.Spis where a.KreiraoOdvjetnik == userID select a).ToList();
            return lista;
        }

        public List<Spis> GetAllSpis()
        {
            List<Spis> lista = new List<Spis>();
            lista = db.Spis.ToList();
            return lista;
        }
        
        public List<Uloga> GetUlogaList()
        {
            List<Uloga> lista = new List<Uloga>();
            lista = db.Uloga.ToList();
            return lista;
        }
        public List<UlogaKontakta> GetUlogaKontaktaList()
        {
            List<UlogaKontakta> lista = new List<UlogaKontakta>();
            lista = db.UlogaKontakta.ToList();
            return lista;
        }
        public List<UlogaKorisnika> GetUlogaKorisnikaList()
        {
            List<UlogaKorisnika> lista = new List<UlogaKorisnika>();
            lista = db.UlogaKorisnika.ToList();
            return lista;
        }

        public Spis GetSpisByID(int ID)
        {
            Spis novi = new Spis();
            novi = db.Spis.SingleOrDefault(e => e.ID == ID);
            return novi;
        }

        public List<TipSpisa> GetTipSpisaList()
        {
            List<TipSpisa> lista = new List<TipSpisa>();
            lista = db.TipSpisa.ToList();
            return lista;
        }
    }
}
