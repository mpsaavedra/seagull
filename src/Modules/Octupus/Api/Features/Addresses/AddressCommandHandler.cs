using System;
using Octupus.Contracts.Comands;
using Seagull.Messaging;

namespace Octupus.Api.Features.Addresses;

public class AddressCommandHandler
{
    public void Handle(CreateAddressCommand command, IMessageBus bus, CancellationToken cancellationToken = default)
    {
        
    }
}
