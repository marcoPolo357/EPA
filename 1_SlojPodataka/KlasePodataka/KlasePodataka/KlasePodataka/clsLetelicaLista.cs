using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class clsLetelicaLista
    {
        // atributi
        private List<clsLetelica> pListaLetelica; 

        // property
        public List<clsLetelica> ListaLetelica
        {
            get
            {
                return pListaLetelica;
            }
            set
            {
                if (this.pListaLetelica != value)
                    this.pListaLetelica = value;
            }
        }

        // konstruktor
        public clsLetelicaLista()
        {
            pListaLetelica = new List<clsLetelica>(); 

        }

        // privatne metode

        // javne metode
        public void DodajElementListe(clsLetelica objNovaLetelica)
        {
            pListaLetelica.Add(objNovaLetelica);
        }

        public void ObrisiElementListe(clsLetelica objLetelicaZaBrisanje)
        {
            pListaLetelica.Remove(objLetelicaZaBrisanje);  
        }

        public void ObrisiElementNaPoziciji(int pozicija)
        {
            pListaLetelica.RemoveAt(pozicija);
        }

        public void IzmeniElementListe(clsLetelica objStaraLetelica, clsLetelica objNovaLetelica)
        {
            int indexStareLetelice = 0;
            indexStareLetelice = pListaLetelica.IndexOf(objStaraLetelica);  
            pListaLetelica.RemoveAt(indexStareLetelice); 
            pListaLetelica.Insert(indexStareLetelice, objNovaLetelica);   
        }

           

     




    }
}
