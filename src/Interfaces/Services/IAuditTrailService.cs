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