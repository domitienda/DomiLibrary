using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;

namespace DomiLibrary.Utility.Log
{
    /// <summary>
    /// Helper que contiene la lógica de añadir appenders en un logger, además de establecer el nivel
    /// </summary>
    public class AppenderHelper
    {
        /// <summary>
        /// Metodo que establece el nivel en un logger
        /// </summary>
        /// <param name="nombreLogger"></param>
        /// <param name="nivel"></param>
        public static void EstablecerNivel(string nombreLogger, string nivel)
        {
            var log = LogManager.GetLogger(nombreLogger);
            var logger = (Logger) log.Logger;
            logger.Level = logger.Hierarchy.LevelMap[nivel];
        }

        /// <summary>
        /// Añade un IAppender en un logger
        /// </summary>
        /// <param name="nombreLogger"></param>
        /// <param name="appender"></param>
        public static void AnyadirAppender(string nombreLogger, IAppender appender)
        {
            var log = LogManager.GetLogger(nombreLogger);
            var logger = (Logger)log.Logger;
            logger.AddAppender(appender);
        }
    }
}
