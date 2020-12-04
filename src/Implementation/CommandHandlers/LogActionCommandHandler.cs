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
        private IDatabaseContext _databaseContext;
        private IMapper _mapper;

        public LogActionCommandHandler(IDatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public Task<Database.Tables.AuditTrail> Handle(LogActionCommand request, CancellationToken cancellationToken)
        {
            var entry = _mapper.Map<Database.Tables.AuditTrail>(request);

            _databaseContext.AuditTrial.Add(entry);
            _databaseContext.SaveChanges();

            return Task.FromResult(entry);
        }
    }
}
