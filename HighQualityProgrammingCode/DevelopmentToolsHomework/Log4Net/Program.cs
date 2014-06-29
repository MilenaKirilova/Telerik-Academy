namespace Log4Net
{
    using System;
    using System.IO;
    using log4net;
    using log4net.Appender;
    using log4net.Config;
    using log4net.Core;
    using log4net.Layout;
    public class Log4NetDemo
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Log4NetDemo));
        static void Main()
        {
            var fileAppender = new FileAppender();
            fileAppender.File = "log.txt";
            fileAppender.AppendToFile = true;
            fileAppender.Layout = new SimpleLayout();
            fileAppender.Threshold = Level.Warn;
            fileAppender.ActivateOptions();

            BasicConfigurator.Configure(fileAppender);

            try
            {
                File.ReadAllLines("./unexistingFile.txt");
            }
            catch (FileNotFoundException ex)
            {
                log.Error(ex.Message);
            }
        }
    }
}
