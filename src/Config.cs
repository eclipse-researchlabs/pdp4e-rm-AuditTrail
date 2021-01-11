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
using AutoMapper;
using Core.AuditTrail.Implementation.Commands;
using Core.AuditTrail.Implementation.Services;
using Core.AuditTrail.Interfaces.Services;
using Core.AuditTrail.Models;
using Core.Database.Tables;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Core.AuditTrail
{
    public class Config
    {
        public static void InitializeServices(ref IServiceCollection services)
        {
            // Services
            services.AddScoped<IAuditTrailService, AuditTrailService>();

            // Queries
        }
    }

    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<LogActionCommand, Database.Tables.AuditTrail>()
                .ForMember(dst => dst.Payload, act => act.MapFrom(src => JsonConvert.SerializeObject(src.Payload)));

            CreateMap<Database.Tables.AuditTrail, AuditTrailModel>()
                .ForMember(dst => dst.PayloadData, act => act.MapFrom(src => string.IsNullOrEmpty(src.Payload) ? new AuditTrailPayloadModel() : JsonConvert.DeserializeObject<AuditTrailPayloadModel>(src.Payload)));
        }
    }
}