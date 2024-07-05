using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
//
using System.Data;

namespace WSUniverzitet
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet DajSveLetelice()
        {
            DataSet dsLetelice = new DataSet();
            dsLetelice.ReadXml(Server.MapPath("~/") + "XML/Letelice.XML");

            return dsLetelice;
        }


        [WebMethod]
        public string DajLetelicu(string RegBr)
        {
            string NazivLetelice = "";
            DataSet dsLetelice = new DataSet();
            dsLetelice.ReadXml(Server.MapPath("~/") + "XML/Letelice.XML");
            // filtriranje dataset-a
            DataRow[] result = dsLetelice.Tables[0].Select("RegBr='" + RegBr + "'");
            NazivLetelice = result[0].ItemArray[1].ToString();

            return NazivLetelice;
        }

        [WebMethod]
        public string DajRegBrLetelice(string naziv)
        {
            string RegBrLetelice = "";
            DataSet dsLetelice = new DataSet();
            dsLetelice.ReadXml(Server.MapPath("~/") + "XML/Letelice.XML");
            // filtriranje dataset-a
            DataRow[] result = dsLetelice.Tables[0].Select("Naziv='" + naziv + "'");
            RegBrLetelice = result[0].ItemArray[0].ToString();

            return RegBrLetelice;
        }

    }
}