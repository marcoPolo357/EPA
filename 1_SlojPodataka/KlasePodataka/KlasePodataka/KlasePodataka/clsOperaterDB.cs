using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using System.Data.SqlClient;

namespace KlasePodataka
{
    public class clsOperaterDB
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
        public clsOperaterDB(string NoviStringKonekcije)
        // OVO JE DOBRO JER OBAVEZUJE DA SE PRILIKOM INSTANCIRANJA OVE KLASE
        // MORA OBEZBEDITI STRING KONEKCIJE
        {
            pStringKonekcije = NoviStringKonekcije; 
        }

        // privatne metode

        // javne metode
        public DataSet DajSveOperatere()
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajSveOperatereSaJoin", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();
            
            return dsPodaci;
        }

        public DataSet DajOperateraPoPrezimenu(string Prezime)
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajOperateraPoPrezimenu", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@OperaterPrezime", SqlDbType.NVarChar).Value = Prezime;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }


        public DataSet DajOperateraPoJMBG(string JMBG)
        {
            // MOGU biti jos neke procedure, mogu SE VRATITI VREDNOSTI I U LISTU, DATA TABLE...
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajOperateraPoJMBG", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@OperaterJMBG", SqlDbType.Char).Value = JMBG;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }

        public int DajUkupnoOperateraZaLetelicu(string IDLetelice)
        {
            int ukupnoOperatera=0;
            DataSet dsPodaci = new DataSet();
            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajBrojOperateraZaLetelicu", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@IDLetelice", SqlDbType.Char).Value = IDLetelice;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();
            ukupnoOperatera = int.Parse(dsPodaci.Tables[0].Rows[0].ItemArray[0].ToString());  
            return ukupnoOperatera;
        } 


        private clsOperaterLista DajListuSvihOperatera()
        {
            // PRIPREMA PROMENLJIVIH
            clsOperaterLista objOperaterLista = new clsOperaterLista();
            DataSet dsPodaciOperatera = new DataSet();
            clsOperater objOperater;
            clsLetelica objLetelica;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajSveOperatereSaJoinRegBrLetelice", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaciOperatera);
            Veza.Close();
            Veza.Dispose();

            // FORMIRANJE OBJEKATA I UBACIVANJE U LISTU
            for (int brojac = 0; brojac < dsPodaciOperatera.Tables[0].Rows.Count; brojac++)
            {
                objLetelica = new clsLetelica();
                objLetelica.RegBr = dsPodaciOperatera.Tables[0].Rows[brojac].ItemArray[4].ToString();
                objLetelica.Naziv = dsPodaciOperatera.Tables[0].Rows[brojac].ItemArray[3].ToString();

                objOperater = new clsOperater();
                objOperater.JMBG = dsPodaciOperatera.Tables[0].Rows[brojac].ItemArray [0].ToString(); 
                objOperater.Prezime = dsPodaciOperatera.Tables[0].Rows[brojac].ItemArray [1].ToString (); 
                objOperater.Ime = dsPodaciOperatera.Tables[0].Rows[brojac].ItemArray [2].ToString ();
                objOperater.Letelica =  objLetelica;
                objOperaterLista.DodajElementListe (objOperater);
            }

            return objOperaterLista;
        }
        

        public bool SnimiNovogOperatera(clsOperater objNoviOperater)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova =0;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("DodajNovogOperatera", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@JMBG", SqlDbType.Char).Value = objNoviOperater.JMBG ;
            Komanda.Parameters.Add("@Prezime", SqlDbType.NVarChar ).Value = objNoviOperater.Prezime;
            Komanda.Parameters.Add("@Ime", SqlDbType.NVarChar).Value = objNoviOperater.Ime;
            Komanda.Parameters.Add("@IDLetelice", SqlDbType.Char).Value = objNoviOperater.Letelica.RegBr;
            
           
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();
     
            return (brojSlogova > 0);

        }

        public bool ObirsiOperatera(string JMBGOperateraZaBrisanje)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("ObirsiOperatera", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@JMBG", SqlDbType.Char).Value = JMBGOperateraZaBrisanje;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }

        public bool IzmeniOperatera(clsOperater objStariOperater, clsOperater objNoviOperater)
        {
            // LOKALNE PROMENLJIVE UVEK NA VRHU
            int brojSlogova = 0;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("IzmeniOperatera", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@StariJMBG", SqlDbType.Char).Value = objStariOperater.JMBG ;
            Komanda.Parameters.Add("@JMBG", SqlDbType.Char).Value = objNoviOperater.JMBG;
            Komanda.Parameters.Add("@Prezime", SqlDbType.NVarChar).Value = objNoviOperater.Prezime;
            Komanda.Parameters.Add("@Ime", SqlDbType.NVarChar).Value = objNoviOperater.Ime;
            Komanda.Parameters.Add("@IDLetelice", SqlDbType.Char).Value = objNoviOperater.Letelica.RegBr;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }

        


    }
}
