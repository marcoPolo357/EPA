using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using System.Data.SqlClient;
//OVO SE KORISTI KOD WEB APP using System.Configuration; 

namespace KlasePodataka
{
    public class clsLetelicaDB
    {
        // atributi
        private string pStringKonekcije;

        // property
        // 1. nacin
        public string StringKonekcije
        {
            get
            {
                return pStringKonekcije;
            }
        }
        // konstruktor
        // 2. nacin prijema vrednosti stringa konekcije spolja i dodele atributu
        public clsLetelicaDB(string NoviStringKonekcije)
        // OVO JE DOBRO JER OBAVEZUJE DA SE PRILIKOM INSTANCIRANJA OVE KLASE
        // MORA OBEZBEDITI STRING KONEKCIJE
        {
            pStringKonekcije = NoviStringKonekcije; 
        }

        // privatne metode

        // javne metode
        public DataSet DajSveLetelice()
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajSveLetelice", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();
            
            return dsPodaci;
        }

        public string DajNazivPremaRegBr(string RegBrLetelice)
        {
            string NazivLetelice = "";

            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajLetelicuPoRegBr", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@RegBr", SqlDbType.Char).Value = RegBrLetelice;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            NazivLetelice = dsPodaci.Tables[0].Rows[0].ItemArray[1].ToString();

            return NazivLetelice;
        }

        public string DajRegBrPoNazivu(string NazivLetelice)
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajLetelicuPoNazivu", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@NazivLetelice", SqlDbType.NVarChar).Value = NazivLetelice;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci.Tables[0].Rows[0].ItemArray[0].ToString();
        }



        public DataSet DajLetelicuPoNazivu(string NazivLetelice)
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajLetelicuPoNazivu", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@NazivLetelice", SqlDbType.NVarChar).Value = NazivLetelice;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }

        // overloading metoda - isto se zove, ima drugaciji parametar
        public DataSet DajLetelicuPoNazivu(clsLetelica objLetelicaZaFilter)
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajLetelicuPoNazivu", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@NazivLetelice", SqlDbType.NVarChar).Value = objLetelicaZaFilter.Naziv;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }

        public bool SnimiNovuLetelicu(clsLetelica objNovaLetelica)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("DodajNovuLetelicu", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@RegBr", SqlDbType.Char).Value = objNovaLetelica.RegBr;
            Komanda.Parameters.Add("@Naziv", SqlDbType.NVarChar).Value = objNovaLetelica.Naziv;
           
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();
          
            return (brojSlogova > 0);
            
        }

        public bool ObrisiLetelicu(clsLetelica objLetelicaZaBrisanje)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("ObrisiLetelicu", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@RegBr", SqlDbType.Char).Value = objLetelicaZaBrisanje.RegBr;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

         }

        // method overloading - ista procedura sa razlicitim parametrom
        public bool ObrisiLetelicu(string RegBrLeteliceZaBrisanje)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("ObrisiLetelicu", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@RegBr", SqlDbType.Char).Value = RegBrLeteliceZaBrisanje;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }

        public bool IzmeniLetelicu(clsLetelica objStaraLetelica, clsLetelica objNovaLetelica)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("IzmeniLetelicu", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@StariRegBr", SqlDbType.Char).Value = objStaraLetelica.RegBr;
            Komanda.Parameters.Add("@RegBr", SqlDbType.Char).Value = objNovaLetelica.RegBr;
            Komanda.Parameters.Add("@Naziv", SqlDbType.NVarChar).Value = objNovaLetelica.Naziv;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }

        // method overloading - ista metoda, samo drugaciji parametri
        public bool IzmeniLetelicu(string RegBrStareLetelice, clsLetelica objNovaLetelica)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("IzmeniLetelicu", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@StariRegBr", SqlDbType.Char).Value = RegBrStareLetelice;
            Komanda.Parameters.Add("@RegBr", SqlDbType.Char).Value = objNovaLetelica.RegBr;
            Komanda.Parameters.Add("@Naziv", SqlDbType.NVarChar).Value = objNovaLetelica.Naziv;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }


    }
}
