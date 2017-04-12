﻿using System;
using System.IO.Pipelines;
using Leto.Internal;

namespace Leto.Sessions
{
    public interface ISessionProvider
    {
        BigEndianAdvancingSpan ProcessSessionTicket(BigEndianAdvancingSpan sessionTicket);
        void EncryptSessionKey(ref WritableBuffer writer, Span<byte> ticketContent);
        DateTime GetCurrentExpiry();
    }
}
