using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace HistoricPhotoStore.Presentation.Helpers
{
    public interface PathHelper
    {
        string RootDirectoryPath { get; }
    }

    public class WebServerPathHelper : PathHelper
    {
        public string RootDirectoryPath
        {
            get { return HostingEnvironment.MapPath("~"); }
        }
    }
}
