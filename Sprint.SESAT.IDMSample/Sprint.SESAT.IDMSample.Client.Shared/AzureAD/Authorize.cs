using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint.SESAT.IDMSample.Client.Shared.AzureAD
{
    [AttributeUsage(AttributeTargets.Method)]
    public class Authorize : Attribute
    {
        public Authorize()
        {

        }
    }
}
