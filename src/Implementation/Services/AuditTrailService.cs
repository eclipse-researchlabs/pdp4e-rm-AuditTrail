// /********************************************************************************
//  * Copyright (c) 2020,2021 Beawre Digital SL
//  *
//  * This program and the accompanying materials are made available under the
//  * terms of the Eclipse Public License 2.0 which is available at
//  * http://www.eclipse.org/legal/epl-2.0.
//  *
//  * SPDX-License-Identifier: EPL-2.0 3
//  *
//  ********************************************************************************/

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
        private IDatabaseContext _databaseContext;
        private IMapper _mapper;
        private IMediator _mediator;

        public AuditTrailService(IMediator mediator, IMapper mapper, IDatabaseContext databaseContext)
        {
            _mediator = mediator;
            _mapper = mapper;
            _databaseContext = databaseContext;
        }

        public async Task<AuditTrailModel> LogAction(LogActionCommand command) => _mapper.Map<AuditTrailModel>(await _mediator.Send(command));

        public AuditTrailModel LogAction(AuditTrailAction action, Guid? objectId, AuditTrailPayloadModel payload = null) =>
            _mapper.Map<AuditTrailModel>(_mediator.Send(new LogActionCommand() {Action = action, ObjectId = objectId, Payload = payload}).Result);
    }
}