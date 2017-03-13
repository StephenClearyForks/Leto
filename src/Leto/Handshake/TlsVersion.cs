﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Leto.Handshake
{
    public enum TlsVersion : ushort
    {
        Tls1 = 0x0301,
        Tls11 = 0x0302,
        Tls12 = 0x0303,
        Tls13Draft18 = 0x7f12
    }
}
