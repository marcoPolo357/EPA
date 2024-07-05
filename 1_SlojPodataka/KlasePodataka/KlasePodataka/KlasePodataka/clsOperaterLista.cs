using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class clsOperaterLista
    {

        // atributi
        private List<clsOperater> pListaOperatera; 

        // property
        public List<clsOperater> ListaOperatera
        {
            get
            {
                return pListaOperatera;
            }
            set
            {
                if (this.pListaOperatera != value)
                    this.pListaOperatera = value;
            }
        }

        // konstruktor
        public clsOperaterLista()
        {
            pListaOperatera = new List<clsOperater>(); 

        }

        // privatne metode

        // javne metode
        public void DodajElementListe(clsOperater objNoviOperater)
        {
            pListaOperatera.Add(objNoviOperater);
        }

        public void ObrisiElementListe(clsOperater objOperaterZaBrisanje)
        {
            pListaOperatera.Remove(objOperaterZaBrisanje);  
        }

        public void ObrisiElementNaPoziciji(int pozicija)
        {
            pListaOperatera.RemoveAt(pozicija);
        }

        public void IzmeniElementListe(clsOperater objStariOperater, clsOperater objNoviOperater)
        {
            int indexStarogOperatera = 0;
            indexStarogOperatera = pListaOperatera.IndexOf(objNoviOperater);
            pListaOperatera.RemoveAt(indexStarogOperatera);
            pListaOperatera.Insert(indexStarogOperatera, objNoviOperater);   
        }

           
    }
}
