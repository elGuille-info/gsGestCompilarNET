// ----------------------------------------------------------------------------
// Definición de My de Visual Basic para C#                         (02/Mar/21)
//
// Aquí está definido:
//  My.Settings, My.Application.Info y
//  My.Computer.FileSystem.SpecialDirectories y RenameFile
//
// En esta URL está el código de ejemplo de My.Application.Info:
// http://www.elguille.info/NET/vs2005/como/my_application_info_csharp.aspx
// 
// (c) Guillermo (elGuille) Som, 2007, 2019, 2021
// ----------------------------------------------------------------------------
using System;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Reflection;

using SpecialFolder = System.Environment.SpecialFolder;

//// Asignar el espacio de nombres del proyecto
//using NamespaceProyecto = Gedico2Sage200c_Net5;

namespace elGuille.Util
{
    /// <summary>
    /// Simula en parte el objeto My de Visual Basic 2005 o superior.
    /// </summary>
    static class My
    {
        //// My.Settings
        //public static NamespaceProyecto.Properties.Settings Settings
        //{
        //    get
        //    {
        //        return NamespaceProyecto.Properties.Settings.Default;
        //    }
        //}

        // My.Application.Info
        public static class Application
        {
            public static class Info
            {
                static System.Diagnostics.FileVersionInfo fvi;
                static System.Reflection.Assembly ensamblado;
                static AssemblyName an;

                static Info()
                {
                    //ensamblado = System.Reflection.Assembly.GetExecutingAssembly();
                    // Usar esto para evitar sobrecargar la memoria
                    ensamblado = typeof(My).Assembly;
                    fvi = FileVersionInfo.GetVersionInfo(ensamblado.Location);
                    an = ensamblado.GetName();
                }

                /// <summary>
                /// El nombre del ensamblado actual.
                /// </summary>
                /// <remarks>Esto no pertenece a My.Application.Info.</remarks>
                public static string NombreEnsamblado { get { return ensamblado.Location; } }

                /// <summary>
                /// La versión del ensamblado
                /// Equivale al atributo AssemblyVersion
                /// </summary>
                public static Version Version
                {
                    get
                    {
                        return an.Version;
                    }
                }

                /// <summary>
                /// La versión del ensamblado (FileVersion)
                /// equivale al atributo: AssemblyFileVersion
                /// </summary>
                public static Version FileVersion
                {
                    get
                    {
                        return new Version(fvi.FileVersion);
                    }
                }

                public static string Title
                {
                    get
                    {
                        return fvi.FileDescription;
                        // antes mostraba esto: fvi.ProductName;
                    }
                }
                public static string Copyright
                {
                    get
                    {
                        return fvi.LegalCopyright;
                    }
                }
                public static string ProductName
                {
                    get
                    {
                        return fvi.ProductName;
                    }
                }
                public static string CompanyName
                {
                    get
                    {
                        return fvi.CompanyName;
                    }
                }
                public static string Trademark
                {
                    get
                    {
                        return fvi.LegalTrademarks;
                    }
                }
                public static string Description
                {
                    get
                    {
                        return fvi.Comments;
                    }
                }
            }
        }

        /// <summary>
        /// My.Computer con FileSystem y SpecialDirectories
        /// </summary>
        public static class Computer
        {
            /// <summary>
            /// 
            /// </summary>
            public static class FileSystem
            {
                /// <summary>
                /// Cambia el nombre de un fichero.
                /// </summary>
                /// <param name="oldFile">Fichero a renombrar. Con el path completo.</param>
                /// <param name="newFile">Nuevo nombre del fichero. Sin path.</param>
                public static void RenameFile(string oldFile, string newFile)
                {
                    // Añadir el path del fichero de origen
                    var ficDest = Path.Combine(Path.GetDirectoryName(oldFile), newFile);
                    File.Copy(oldFile, ficDest, true);
                    // Solo borrar si se ha hecho la copia
                    if (File.Exists(ficDest))
                        File.Delete(oldFile);
                }

                // 
                // Resumen:
                // Proporciona propiedades para tener acceso a normalmente hace referencia a directorios.

                /// <summary>
                /// Proporciona propiedades para tener acceso a directorios.
                /// 
                /// El código (sin implementación) está sacado de
                /// lo que se muestra en Visual Studio cuando pulsas
                /// en la opción "Ver la definición".
                /// 
                /// He dejado los comentarios que había en esa definición.
                /// </summary>
                public static class SpecialDirectories
                {
                    // 
                    // Resumen:
                    // Obtiene un nombre de ruta de acceso que señala al directorio Mis documentos.
                    // 
                    // Devuelve:
                    // La ruta de acceso al directorio Mis documentos.
                    // 
                    // Excepciones:
                    // T:System.IO.DirectoryNotFoundException:
                    // La ruta de acceso está vacía, habitualmente porque el sistema operativo no admite
                    // el directorio.
                    public static string MyDocuments
                    {
                        get
                        {
                            return Environment.GetFolderPath(SpecialFolder.MyDocuments);
                        }
                    }
                    // 
                    // Resumen:
                    // Obtiene un nombre de ruta de acceso que señala al directorio Mi música.
                    // 
                    // Devuelve:
                    // La ruta de acceso al directorio Mi música.
                    // 
                    // Excepciones:
                    // T:System.IO.DirectoryNotFoundException:
                    // La ruta de acceso está vacía, habitualmente porque el sistema operativo no admite
                    // el directorio.
                    public static string MyMusic
                    {
                        get
                        {
                            return Environment.GetFolderPath(SpecialFolder.MyMusic);
                        }
                    }
                    // 
                    // Resumen:
                    // Obtiene un nombre de ruta de acceso que señala al directorio Mis imágenes.
                    // 
                    // Devuelve:
                    // La ruta de acceso al directorio Mis imágenes.
                    // 
                    // Excepciones:
                    // T:System.IO.DirectoryNotFoundException:
                    // La ruta de acceso está vacía, habitualmente porque el sistema operativo no admite
                    // el directorio.
                    public static string MyPictures
                    {
                        get
                        {
                            return Environment.GetFolderPath(SpecialFolder.MyPictures);
                        }
                    }
                    // 
                    // Resumen:
                    // Obtiene un nombre de ruta de acceso que señala al directorio escritorio.
                    // 
                    // Devuelve:
                    // La ruta de acceso al directorio escritorio.
                    // 
                    // Excepciones:
                    // T:System.IO.DirectoryNotFoundException:
                    // La ruta de acceso está vacía, habitualmente porque el sistema operativo no admite
                    // el directorio.
                    public static string Desktop
                    {
                        get
                        {
                            return Environment.GetFolderPath(SpecialFolder.Desktop);
                        }
                    }
                    // 
                    // Resumen:
                    // Obtiene un nombre de ruta de acceso que señala al directorio programas.
                    // 
                    // Devuelve:
                    // La ruta de acceso al directorio programas.
                    // 
                    // Excepciones:
                    // T:System.IO.DirectoryNotFoundException:
                    // La ruta de acceso está vacía, habitualmente porque el sistema operativo no admite
                    // el directorio.
                    public static string Programs
                    {
                        get
                        {
                            return Environment.GetFolderPath(SpecialFolder.Programs);
                        }
                    }
                    // 
                    // Resumen:
                    // Obtiene una ruta de acceso que señala a la archivos de programa directory.
                    // 
                    // Devuelve:
                    // La ruta de acceso a la archivos de programa directory.
                    // 
                    // Excepciones:
                    // T:System.IO.DirectoryNotFoundException:
                    // La ruta de acceso está vacía, habitualmente porque el sistema operativo no admite
                    // el directorio.
                    public static string ProgramFiles
                    {
                        get
                        {
                            return Environment.GetFolderPath(SpecialFolder.ProgramFiles);
                        }
                    }
                    // 
                    // Resumen:
                    // Obtiene un nombre de ruta de acceso que señala al directorio Temp.
                    // 
                    // Devuelve:
                    // La ruta de acceso al directorio Temp.
                    // 
                    // Excepciones:
                    // T:System.IO.DirectoryNotFoundException:
                    // La ruta de acceso está vacía, habitualmente porque el sistema operativo no admite
                    // el directorio.
                    public static string Temp
                    {
                        get
                        {
                            return Environment.GetEnvironmentVariable("TEMP");
                        }
                    }
                    // 
                    // Resumen:
                    // Obtiene un nombre de ruta de acceso que señala al directorio de datos de la aplicación
                    // para el usuario actual.
                    // 
                    // Devuelve:
                    // La ruta de acceso al directorio de datos de aplicación para el usuario actual.
                    // 
                    // Excepciones:
                    // T:System.IO.DirectoryNotFoundException:
                    // La ruta de acceso está vacía, habitualmente porque el sistema operativo no admite
                    // el directorio.
                    public static string CurrentUserApplicationData
                    {
                        get
                        {
                            return Environment.GetFolderPath(SpecialFolder.LocalApplicationData);
                        }
                    }
                    //
                    // Resumen:
                    // Obtiene un nombre de ruta de acceso que señala al directorio de datos de la aplicación
                    // para todos los usuarios.
                    // 
                    // Devuelve:
                    // La ruta de acceso al directorio de datos de aplicación para todos los usuarios.
                    // 
                    // Excepciones:
                    // T:System.IO.DirectoryNotFoundException:
                    // La ruta de acceso está vacía, habitualmente porque el sistema operativo no admite
                    // el directorio.
                    public static string AllUsersApplicationData
                    {
                        get
                        {
                            return Environment.GetFolderPath(SpecialFolder.CommonApplicationData);
                        }
                    }
                }
            }
        }
    }
}
