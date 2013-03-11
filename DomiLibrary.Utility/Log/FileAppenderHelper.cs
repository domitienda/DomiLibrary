using log4net.Appender;
using log4net.Layout;

namespace DomiLibrary.Utility.Log
{
    /// <summary>
    /// Helper que contiene la logica para crear appenders de tipo FICHERO en Log4Net
    /// </summary>
    public class FileAppenderHelper
    {
        /// <summary>
        /// Contiene la logica para crear un appender FICHERO
        /// </summary>
        /// <param name="nombreAppender">Nombre del appender</param>
        /// <param name="nombreFichero">Nombre del fichero</param>
        /// <param name="patronConversion"> Si se deja a null el valor por defecto es %d [%t] %-5p %c [%x] - %m%n </param>
        /// <returns>Retorna el appender creado</returns>
        public static IAppender CrearAppenderFichero(string nombreAppender, string nombreFichero, string patronConversion)
        {
            var appender = new FileAppender
            {
                Name = nombreAppender,
                File = nombreFichero,
                AppendToFile = true
            };

            var patronConversionAux = "%d [%t] %-5p %c [%x] - %m%n";
            if(patronConversion != null && !patronConversion.Equals(string.Empty))
            {
                patronConversionAux = patronConversion;
            }

            var layout = new PatternLayout
            {
                ConversionPattern = patronConversionAux
            };
            layout.ActivateOptions();

            appender.Layout = layout;
            appender.ActivateOptions();

            return appender;
        }
    }
}
