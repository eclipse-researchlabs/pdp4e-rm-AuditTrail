using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AuditTrail.Models
{
    public class AuditTrailPayloadModel
    {
        public string Query { get; set; }
        public string Variables { get; set; }

        public string Data { get; set; }
    }
}
