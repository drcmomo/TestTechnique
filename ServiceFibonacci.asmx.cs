using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Xml;
using TestTechniqueFibonacci.Utilities;

namespace TestTechniqueFibonacci
{
    /// <summary>
    /// Description résumée de ServiceFibonacci
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiceFibonacci : IFibonacci
    {

        [WebMethod]
        public int Fibonnacci(int n)
        {
            int value1 = 0;
            int value2 = 1;
            if (n < 0 || n > 100 || n == 0)
                return -1;

            for (int i = 1; i < n; i++)
            {
                int temp = value1;
                value1 = value2;
                value2 = temp + value2;
            }
            return value1;
        }

        [WebMethod]

        public string XmlToJson(string xml)
        {

          
            string removeParenthese = xml.Replace("(", String.Empty);
            string removeParenthese1 = removeParenthese.Replace(")", String.Empty);          
            object yourOjbect = new JavaScriptSerializer().DeserializeObject(removeParenthese1);
            var test = string.Concat("<? xml version = '1.0'>", yourOjbect.ToString());     
            try
            {  
            XmlDocument document = new XmlDocument();
            document.LoadXml(yourOjbect.ToString());
            return ConvertToJson.XmlToJSON(document);
            }
            catch(Exception ex)
            {
                return "Bad Xml format";
            }

        }
       
    }
}
