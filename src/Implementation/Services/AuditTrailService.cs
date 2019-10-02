using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.AuditTrail.Implementation.Commands;
using Core.AuditTrail.Interfaces.Services;
using Core.AuditTrail.Models;
using Core.Database;
using Core.Database.Tables;
using MediatR;

namespace Core.AuditTrail.Implementation.Services
{
    public class AuditTrailService : IAuditTrailService
    {
        private IMediator _mediator;
        private IMapper _mapper;
        private IBeawreContext _beawreContext;

        public AuditTrailService(IMediator mediator, IMapper mapper, IBeawreContext beawreContext)
        {
            _mediator = mediator;
            _mapper = mapper;
            _beawreContext = beawreContext;
        }

        public async Task<AuditTrailModel> LogAction(LogActionCommand command) => _mapper.Map<AuditTrailModel>(await _mediator.Send(command));

        public AuditTrailModel LogAction(AuditTrailAction action, Guid? objectId, AuditTrailPayloadModel payload = null) => _mapper.Map<AuditTrailModel>(_mediator.Send(new LogActionCommand() { Action = action, ObjectId = objectId, Payload = payload }).Result);

    }
}
