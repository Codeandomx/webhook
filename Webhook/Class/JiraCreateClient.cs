using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Webhook.Class
{
    public class JiraCreateClient
    {
        /// <summary>
        /// Creamos el cliente para Jira
        /// </summary>
        /// <param name="query">Url del API Rest</param>
        /// <param name="argument"></param>
        /// <param name="data"></param>
        /// <param name="method">Metodo HTTP</param>
        /// <returns></returns>
        public static string RunQuery(string query, string data = null, string method = "GET")
        {
            try
            {
                string m_BaseUrl = query;
                HttpWebRequest newRequest = WebRequest.Create(m_BaseUrl) as HttpWebRequest;
                newRequest.ContentType = "application/json";
                newRequest.Method = method;

                // Verificamos si existen datos a enviar
                if (data != null)
                {
                    using (StreamWriter writer = new StreamWriter(newRequest.GetRequestStream()))
                    {
                        writer.Write(data);
                    }
                }

                // Codificamos en base 64 las credenciales de acceso
                string base64Credentials = GetEncodedCredentials();
                newRequest.Headers.Add("Authorization", "Basic " + base64Credentials);

                // Enviamos la solicitud
                HttpWebResponse response = newRequest.GetResponse() as HttpWebResponse;

                string result = string.Empty;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }

                newRequest = null;
                response = null;

                return result;
            }
            catch (Exception)
            {
                //MessageBox.Show(@"There is a problem getting data from Jira :" + "\n\n" + query, "Jira Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        /// <summary>
        /// Creamos y codificamos las credenciales de acceso
        /// </summary>
        /// <returns></returns>
        private static string GetEncodedCredentials()
        {
            string m_Username = "paulo.gonzalez.sc@itszapopan.edu.mx";
            string m_Password = "Paulo866";

            string mergedCredentials = string.Format("{0}:{1}", m_Username, m_Password);
            byte[] byteCredentials = UTF8Encoding.UTF8.GetBytes(mergedCredentials);
            return Convert.ToBase64String(byteCredentials);
        }
    }
}