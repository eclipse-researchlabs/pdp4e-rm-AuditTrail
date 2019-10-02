using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.AuditTrail.Implementation.Commands;
using Core.AuditTrail.Models;
using Core.Database.Tables;

namespace Core.AuditTrail.Interfaces.Services
{
    public interface IAuditTrailService
    {
        Task<AuditTrailModel> LogAction(LogActionCommand command);
        AuditTrailModel LogAction(AuditTrailAction action, Guid? objectId, AuditTrailPayloadModel payload = null);
    }
}
