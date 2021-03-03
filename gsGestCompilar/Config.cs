//-----------------------------------------------------------------------------
// Config - Clase para manejar ficheros de configuración
//
// Basada en la original para Visual Basic                          (15/Nov/05)
// y revisiones posteriores.
//
// (c) Guillermo (elGuille) Som, 2005-2006, 2020-2021
//-----------------------------------------------------------------------------

using System;
using System.Linq;
using System.IO;
using System.Xml;

namespace elGuille.Util
{
    public class Config
    {

        // ----------------------------------------------------------------------
        // Los campos y métodos privados
        // ----------------------------------------------------------------------
        private const string configuration = "configuration/";
        private string ficConfig = "";
        private XmlDocument configXml = new XmlDocument();

        public string GetValue(string seccion, string clave)
        {
            return GetValue(seccion, clave, "");
        }
        public string GetValue(string seccion, string clave, string predeterminado)
        {
            return cfgGetValue(seccion, clave, predeterminado);
        }
        public int GetValue(string seccion, string clave, int predeterminado)
        {
            return System.Convert.ToInt32(cfgGetValue(seccion, clave, predeterminado.ToString()));
        }
        public bool GetValue(string seccion, string clave, bool predeterminado)
        {
            string def = "0";
            if (predeterminado)
                def = "1";
            def = cfgGetValue(seccion, clave, def);
            if (def == "1")
                return true;
            else
                return false;
        }
        public double GetValue(string seccion, string clave, double predeterminado)
        {
            return System.Convert.ToDouble(cfgGetValue(seccion, clave, predeterminado.ToString()));
        }

        public void SetValue(string seccion, string clave, string valor)
        {
            // cfgSetValue("configuration/" & seccion, clave, valor)
            cfgSetValue(seccion, clave, valor);
        }
        public void SetValue(string seccion, string clave, int valor)
        {
            cfgSetValue(seccion, clave, valor.ToString());
        }
        public void SetValue(string seccion, string clave, bool valor)
        {
            if (valor)
                cfgSetValue(seccion, clave, "1");
            else
                cfgSetValue(seccion, clave, "0");
        }
        public void SetValue(string seccion, string clave, double valor)
        {
            cfgSetValue(seccion, clave, valor.ToString());
        }

        public void SetKeyValue(string seccion, string clave, string valor)
        {
            cfgSetKeyValue(seccion, clave, valor);
        }
        public void SetKeyValue(string seccion, string clave, int valor)
        {
            cfgSetKeyValue(seccion, clave, valor.ToString());
        }
        public void SetKeyValue(string seccion, string clave, bool valor)
        {
            if (valor)
                cfgSetKeyValue(seccion, clave, "1");
            else
                cfgSetKeyValue(seccion, clave, "0");
        }
        public void SetKeyValue(string seccion, string clave, double valor)
        {
            cfgSetKeyValue(seccion, clave, valor.ToString());
        }

        // Elimina la sección, en realidad la deja vacía
        public void RemoveSection(string seccion)
        {
            XmlNode n;
            n = configXml.SelectSingleNode(configuration + seccion);
            if (n != null)
                n.RemoveAll();
        }

        // Guardar el fichero de configuración
        // Si no se llama a este método, no se guardará de forma permanente.
        public void Save()
        {
            configXml.Save(ficConfig);
        }

        // Leer el fichero de configuración
        // Si no existe, se crea uno nuevo
        public void Read()
        {
            string fic = ficConfig;
            if (File.Exists(fic))
                configXml.Load(fic);
            else
            {
                const string revDate = "Tue, 02 Mar 2021 19:43:00 GMT";

                // Crear el XML de configuración con la sección General
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                sb.Append("<configuration>");
                // Por si es un fichero appSetting
                sb.Append("<configSections>");
                sb.Append("<section name=\"General\" type=\"System.Configuration.DictionarySectionHandler\" />");
                sb.Append("</configSections>");
                sb.Append("<General>");
                sb.Append("<!-- Los valores irán dentro del elemento indicado por la clave -->");
                sb.Append("<!-- Aunque también se podrán indicar como pares key / value -->");
                sb.AppendFormat("<add key=\"Revisión\" value=\"{0}\" />", revDate);
                sb.Append("<!-- La clase siempre los añade como un elemento -->");
                sb.Append("<Copyright>©Guillermo (elGuille) Som, 2005-2021</Copyright>");
                sb.Append("</General>");

                sb.AppendLine("<configXml_Info>");
                sb.AppendLine("<info>Generado con Config para C#</info>");
                sb.AppendLine("<copyright>©Guillermo 'guille' Som, 2005-2021</copyright>");
                sb.AppendFormat("<revision>{0}</revision>", revDate);
                sb.AppendLine();
                sb.AppendLine("<formatoUTF8>El formato de este fichero debe ser UTF-8</formatoUTF8>");
                sb.AppendLine("</configXml_Info>");

                sb.Append("</configuration>");

                // Asignamos la cadena al objeto
                configXml.LoadXml(sb.ToString());

                // Guardamos el contenido de configXml y creamos el fichero
                configXml.Save(ficConfig);
            }
        }

        public string FileName
        {
            get
            {
                return ficConfig;
            }
            set
            {
                // Al asignarlo, NO leemos el contenido del fichero
                ficConfig = value;
            }
        }

        // Public Sub New()
        // ' Asignamos automáticamente el nombre del fichero, y lo leemos
        // ' Este constructor no deberíamos usarlo si esta clase está en una DLL
        // ficConfig = System.Reflection.Assembly.GetExecutingAssembly.Location & ".cfg"
        // Read()
        // End Sub
        public Config(string fic)
        {
            ficConfig = fic;
            Read();
        }
        // 
        // ----------------------------------------------------------------------
        // Los métodos privados
        // ----------------------------------------------------------------------
        // 
        // El método interno para guardar los valores
        // Este método siempre guardará en el formato <seccion><clave>valor</clave></seccion>
        private void cfgSetValue(string seccion, string clave, string valor)
        {
            // 
            XmlNode n;
            // 
            // Se comrpueba si es un elemento de la sección:
            // <seccion><clave>valor</clave></seccion>
            n = configXml.SelectSingleNode(configuration + seccion + "/" + clave);
            if (n != null)
                n.InnerText = valor;
            else
            {
                XmlNode root;
                XmlElement elem;
                root = configXml.SelectSingleNode(configuration + seccion);
                if (root == null)
                {
                    // Si no existe el elemento principal,
                    // lo añadimos a <configuration>
                    elem = configXml.CreateElement(seccion);
                    configXml.DocumentElement.AppendChild(elem);
                    root = configXml.SelectSingleNode(configuration + seccion);
                }
                if (root != null)
                {
                    // Crear el elemento
                    elem = configXml.CreateElement(clave);
                    elem.InnerText = valor;
                    // Añadirlo al nodo indicado
                    root.AppendChild(elem);
                }
            }
        }

        // Asigna un atributo a una sección
        // Por ejemplo: <Seccion clave=valor>...</Seccion>
        // También se usará para el formato de appSettings: <add key=clave value=valor />
        // Aunque en este caso, debe existir el elemento a asignar.
        private void cfgSetKeyValue(string seccion, string clave, string valor)
        {
            // 
            XmlNode n;
            // 
            n = configXml.SelectSingleNode(configuration + seccion + "/add[@key=\"" + clave + "\"]");
            if (n != null)
                n.Attributes["value"].InnerText = valor;
            else
            {
                XmlNode root;
                XmlElement elem;
                root = configXml.SelectSingleNode(configuration + seccion);
                if (root == null)
                {
                    // Si no existe el elemento principal,
                    // lo añadimos a <configuration>
                    elem = configXml.CreateElement(seccion);
                    configXml.DocumentElement.AppendChild(elem);
                    root = configXml.SelectSingleNode(configuration + seccion);
                }
                if (root != null)
                {
                    XmlAttribute a = (XmlAttribute)configXml.CreateNode(XmlNodeType.Attribute, clave, null);
                    a.InnerText = valor;
                    root.Attributes.Append(a);
                }
            }
        }

        // Devolver el valor de la clave indicada
        private string cfgGetValue(string seccion, string clave, string valor
                        )
        {
            // 
            XmlNode n;
            // 
            // Primero comprobar si están el formato de appSettings: <add key = clave value = valor />
            n = configXml.SelectSingleNode(configuration + seccion + "/add[@key=\"" + clave + "\"]");
            if (n != null)
                return n.Attributes["value"].InnerText;
            // 
            // Después se comprueba si está en el formato <Seccion clave = valor>
            n = configXml.SelectSingleNode(configuration + seccion);
            if (n != null)
            {
                XmlAttribute a = n.Attributes[clave];
                if (a != null)
                    return a.InnerText;
            }
            // 
            // Por último se comprueba si es un elemento de seccion:
            // <seccion><clave>valor</clave></seccion>
            n = configXml.SelectSingleNode(configuration + seccion + "/" + clave);
            if (n != null)
                return n.InnerText;
            // 
            // Si no existe, se devuelve el valor predeterminado
            return valor;
        }
    }
}
