using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.AuditTrail.Implementation.Commands;
using Core.Database;
using MediatR;

namespace Core.AuditTrail.Implementation.CommandHandlers
{
    public class LogActionCommandHandler : IRequestHandler<LogActionCommand, Database.Tables.AuditTrail>
    {
        private IBeawreContext _beawreContext;
        private IMapper _mapper;

        public LogActionCommandHandler(IBeawreContext beawreContext, IMapper mapper)
        {
            _beawreContext = beawreContext;
            _mapper = mapper;
        }

        public Task<Database.Tables.AuditTrail> Handle(LogActionCommand request, CancellationToken cancellationToken)
        {
            var entry = _mapper.Map<Database.Tables.AuditTrail>(request);

            _beawreContext.AuditTrial.Add(entry);
            _beawreContext.SaveChanges();

            return Task.FromResult(entry);
        }
    }
}
