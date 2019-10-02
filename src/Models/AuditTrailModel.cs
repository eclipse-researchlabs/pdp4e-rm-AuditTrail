using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AuditTrail.Models
{
    public class AuditTrailModel : Database.Tables.AuditTrail
    {
        public AuditTrailPayloadModel PayloadData { get; set; }
    }
}
