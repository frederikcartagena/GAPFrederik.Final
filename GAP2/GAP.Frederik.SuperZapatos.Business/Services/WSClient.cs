using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace GAP.Frederik.SuperZapatos.Business.Services
{
    public static class WSClient
    {
        private static readonly string NameWordGet = "Get";
        public static string WebServiceUrl
        {
            get
            {
                if (string.IsNullOrEmpty(WebKeys.System.DependientesWebApi.Url))
                {
                    throw (new Exception("Error:La llave 'WebServiceUrl' no ha sido programada"));
                }
                return WebKeys.System.DependientesWebApi.Url;

            }


        }

        public static string GetRequest(string methodUrl, Dictionary<string, string> parametersDictionary, ISystemFail error)
        {
            string response = null;
            string parameters = string.Empty;
            if (parametersDictionary.Count > 0)
            {
                parameters = "?";
                int counter = 0;
                foreach (var item in parametersDictionary)
                {

                    if (counter == (parametersDictionary.Count - 1))
                        parameters += string.Format("{0}={1}", item.Key, item.Value);
                    else
                        parameters += string.Format("{0}={1}&", item.Key, item.Value);

                    counter++;


                }
            }
            string completeURL = string.Format("{0}{1}/{2}{3}", WebServiceUrl, methodUrl, NameWordGet, parameters);//string.Concat(WebServiceUrl, methodUrl, parameters);
            try
            {
                using (var client = new System.Net.WebClient())
                {

                    Stream stream = client.OpenRead(completeURL);
                    StreamReader reader = new StreamReader(stream);
                    response = reader.ReadToEnd();
                }
            }
            catch (WebException webEx)
            {
                error.Error = true;
                error.Excepcion = webEx;

                if (webEx.Response is HttpWebResponse)
                {
                    switch (((HttpWebResponse)webEx.Response).StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            response = null;
                            error.Mensaje = "URL not found";
                            break;
                        case HttpStatusCode.Forbidden:
                            response = null;
                            error.Mensaje = "Access to the URL not allowed";
                            break;
                        default:
                            response = null;
                            error.Mensaje = "Exception ocurred while executing the Get request";
                            break;

                    }
                }                
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.Excepcion = ex;
                error.Mensaje = string.Concat("Error al realizar la petición POST:", completeURL);                
                response = null;
            }


            return response;
        }



        public static string GetRequest(string controllerName, string methodUrl, Dictionary<string, string> parametersDictionary, ISystemFail error)
        {
            string response = null;
            string parameters = string.Empty;
            if (parametersDictionary.Count > 0)
            {
                parameters = "?";
                int counter = 0;
                foreach (var item in parametersDictionary)
                {

                    if (counter == (parametersDictionary.Count - 1))
                        parameters += string.Format("{0}={1}", item.Key, item.Value);
                    else
                        parameters += string.Format("{0}={1}&", item.Key, item.Value);

                    counter++;


                }
            }            
            string completeURL = string.Format("{0}{1}{2}", WebServiceUrl, controllerName, parameters);
            try
            {
                using (var client = new System.Net.WebClient())
                {

                    Stream stream = client.OpenRead(completeURL);
                    StreamReader reader = new StreamReader(stream);
                    response = reader.ReadToEnd();
                }
            }
            catch (WebException webEx)
            {
                error.Error = true;
                error.Excepcion = webEx;

                if (webEx.Response is HttpWebResponse)
                {
                    switch (((HttpWebResponse)webEx.Response).StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            response = null;
                            error.Mensaje = "URL not found";
                            break;
                        case HttpStatusCode.Forbidden:
                            response = null;
                            error.Mensaje = "Access to the URL not allowed";
                            break;
                        default:
                            response = null;
                            error.Mensaje = "Exception ocurred while executing the Get request";
                            break;

                    }
                }                
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.Excepcion = ex;
                error.Mensaje = string.Concat("Error al realizar la petición POST:", completeURL);                
                response = null;
            }


            return response;
        }


        public static string PostRequest(string controllerName, string actionName, object requestBody, ISystemFail error, Dictionary<string, string> parametersDictionary = null)
        {
            string response = null;
            string parameters = string.Empty;
            if (parametersDictionary.Count > 0)
            {
                parameters = "?";
                int counter = 0;
                foreach (var item in parametersDictionary)
                {
                    if (counter == (parametersDictionary.Count - 1))
                        parameters += string.Format("{0}={1}", item.Key, item.Value);
                    else
                        parameters += string.Format("{0}={1}&", item.Key, item.Value);
                    counter++;
                }
            }


            string completeURL = string.Concat(WebServiceUrl, controllerName, "/", actionName, parameters);
            Uri completeUri = new Uri(completeURL);
            try
            {
                using (var client = new System.Net.WebClient())
                {
                    client.Headers["Content-Type"] = "application/json";

                    ASCIIEncoding encoding = new ASCIIEncoding();
                    //byte[] requestBodyBites = encoding.GetBytes(JsonConvert.SerializeObject(requestBody));
                    byte[] requestBodyBites = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(requestBody));
                    byte[] byteArrayResponse = client.UploadData(completeUri, "POST", requestBodyBites);
                    response = System.Text.Encoding.UTF8.GetString(byteArrayResponse);
                }
            }
            catch (WebException webEx)
            {
                error.Error = true;
                error.Excepcion = webEx;

                if (webEx.Response is HttpWebResponse)
                {
                    switch (((HttpWebResponse)webEx.Response).StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            response = null;
                            error.Mensaje = "URL not found";
                            break;
                        case HttpStatusCode.Forbidden:
                            response = null;
                            error.Mensaje = "Access to the URL not allowed";
                            break;
                        default:
                            response = null;
                            error.Mensaje = "Exception ocurred while executing the Post request to the service";
                            break;

                    }
                }                
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.Excepcion = ex;
                error.Mensaje = string.Concat("Error al realizar la peticion POST:", completeURL);                
                response = null;
            }

            return response;

        }

        public static string PutRequest(string controllerName, string actionName, object requestBody, ISystemFail error, Dictionary<string, string> parametersDictionary = null)
        {
            string response = null;
            string parameters = string.Empty;
            if (parametersDictionary.Count > 0)
            {
                parameters = "?";
                int counter = 0;
                foreach (var item in parametersDictionary)
                {
                    if (counter == (parametersDictionary.Count - 1))
                        parameters += string.Format("{0}={1}", item.Key, item.Value);
                    else
                        parameters += string.Format("{0}={1}&", item.Key, item.Value);
                    counter++;
                }
            }


            string completeURL = string.Concat(WebServiceUrl, controllerName, "/", actionName, parameters);
            Uri completeUri = new Uri(completeURL);
            try
            {
                using (var client = new System.Net.WebClient())
                {
                    client.Headers["Content-Type"] = "application/json";
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    byte[] requestBodyBites = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(requestBody));
                    //byte[] requestBodyBites = encoding.GetBytes(JsonConvert.SerializeObject(requestBody));
                    byte[] byteArrayResponse = client.UploadData(completeUri, "PUT", requestBodyBites);
                    response = System.Text.Encoding.UTF8.GetString(byteArrayResponse);
                }
            }
            catch (WebException webEx)
            {
                error.Error = true;
                error.Excepcion = webEx;

                if (webEx.Response is HttpWebResponse)
                {
                    switch (((HttpWebResponse)webEx.Response).StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            response = null;
                            error.Mensaje = "URL not found";
                            break;
                        case HttpStatusCode.Forbidden:
                            response = null;
                            error.Mensaje = "Access to the URL not allowed";
                            break;
                        default:
                            response = null;
                            error.Mensaje = "Exception ocurred while executing the PUT request to the service";
                            break;

                    }
                }                
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.Excepcion = ex;
                error.Mensaje = string.Concat("Error al realizar la peticion PUT:", completeURL);                
                response = null;
            }

            return response;

        }

        public static byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}