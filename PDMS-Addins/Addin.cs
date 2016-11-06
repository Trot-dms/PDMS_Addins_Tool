using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDMS_Addins
{
    class Addin
    {
        public string AddinFolder { get; set; }
        public string AddinName { get; set; }
        public Module AddinModule { get; set; }
        public bool AddinState { get; set; }

    }
}
