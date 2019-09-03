using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAspCore.Services
{
    public class EmailSettings // Classse com mesmo nome em (appsettings.json)
    {
        // Mesmas Propriedades que foram configuradas no Arquivo: (appsettings.json)
        public String PrimaryDomain { get; set; }
        public int PrimaryPort { get; set; }
        public String UsernameEmail { get; set; }
        public String UsernamePassword { get; set; }
        public String FromEmail { get; set; }
        public String ToEmail { get; set; }
        public String CcEmail { get; set; }
    }
}
