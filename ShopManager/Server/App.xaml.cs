using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Server
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // this catches unhandled errors and makes sure they are logged, then it gracefully closes the program.
        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var trace = new StackTrace(e.Exception, true).GetFrame(0).GetMethod();
            ManagerLogger.ServerErrorLogger.GetInstance().WriteError(ManagerLogger.ERR_TYPES_SERVER.SERVER_STOP, ManagerLogger.LOGGING_LEVEL.FATAL_ERROR, e.Exception.Message, "Fatal Error Catch", "A fatal error occured and was not handled, Source = " + trace.Name);
            
            e.Handled = true;
            Current.Shutdown();
        }
    }
    
}
