﻿using ManualHelp.Common.Handlers.Abstract;
using ManualHelp.Common.RabbitMq.Abstract;
using ManualHelp.Service.Identity.Messages.Command.JwtIdentity;
using ManualHelp.Service.Identity.Messages.Event.JwtIdentity;
using ManualHelp.Service.Identity.Repository.Abstract.JwtIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualHelp.Service.Identity.Handler.JwtIdentity
{
    public class SignUpUserHandler : ICommandHandler<SignUpUser>
    {
        private readonly IIdentityService _identityService;
        private readonly IBusPublisher _busPublisher;

        public SignUpUserHandler()
        {
        }

        public SignUpUserHandler
            (
            IIdentityService identityService,
            IBusPublisher busPublisher
            )
        {
            _identityService = identityService;
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(SignUpUser command, ICorrelationContext context)
        {
           var user = await _identityService.SignUpAsync(command.Email, command.Password);

           await _busPublisher
                .PublishEventAsync(
                     new UserRegistered
                     {
                        Id = user.Id,
                        Email = command.Email
                     }, context);
        }
    }
}
