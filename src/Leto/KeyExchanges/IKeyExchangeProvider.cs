﻿using Leto.Certificates;
using System;

namespace Leto.KeyExchanges
{
    public interface IKeyExchangeProvider : IDisposable
    {
        IKeyExchange GetKeyExchange(NamedGroup namedGroup);
        IKeyExchange GetKeyExchange(KeyExchangeType keyExchange, Span<byte> supportedGroups);
        IKeyExchange GetKeyExchange(Span<byte> keyshare);
        IKeyExchange GetKeyExchangeFromSupportedGroups(Span<byte> buffer);
    }
}
