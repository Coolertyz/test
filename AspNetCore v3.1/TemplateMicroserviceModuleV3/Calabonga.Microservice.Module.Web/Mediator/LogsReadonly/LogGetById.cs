﻿using System;
using AutoMapper;
using Calabonga.AspNetCore.Controllers.Handlers;
using Calabonga.AspNetCore.Controllers.Queries;
using $ext_projectname$.Entities;
using $safeprojectname$.ViewModels.LogViewModels;
using Calabonga.UnitOfWork;

namespace $safeprojectname$.Mediator.LogsReadonly
{
    /// <summary>
    /// Request for Log by Identifier
    /// </summary>
    public class LogGetByIdRequest : GetByIdQuery<LogViewModel>
    {
        public LogGetByIdRequest(Guid id) : base(id)
        {
        }
    }

    /// <summary>
    /// Response for  Request for Log by Identifier
    /// </summary>
    public class LogGetByIdRequestHandler : GetByIdHandlerBase<LogGetByIdRequest, Log, LogViewModel>
    {
        public LogGetByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
