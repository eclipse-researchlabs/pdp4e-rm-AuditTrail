using System;
using System.Collections.Generic;
using System.Text;
using Core.AuditTrail.Models;
using Core.Database.Tables;
using MediatR;

namespace Core.AuditTrail.Implementation.Commands
{
    public class LogActionCommand : IRequest<Database.Tables.AuditTrail>
    {
        public AuditTrailAction Action { get; set; }
        public Guid? ObjectId { get; set; }

        public AuditTrailPayloadModel Payload { get; set; }
    }
}
