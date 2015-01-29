using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Text;

using AiMetrix.BusinessObject.Events;

namespace TextFileLog
{
    public class TextFileLog
    {
        public object Main(Hashtable data)
        {
            NSEvent response = new NSEvent();
            string executingPath = string.Empty;

            try
            {
                executingPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                string output = DateTime.Now.ToLongDateString() +  " This is output from our example Action DLL";

                File.WriteAllText(Path.Combine(executingPath, "action.log"), output);
            }
            catch (Exception)
            {   
            }

            return response;
        }
    }
}