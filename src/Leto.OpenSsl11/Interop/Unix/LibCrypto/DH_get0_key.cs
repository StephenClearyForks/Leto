﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Leto.OpenSsl11.Interop
{
    internal partial class LibCrypto
    {
        [DllImport(Libraries.LibCrypto, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DH_get0_key(DH dh, out BIGNUM pub_key, out BIGNUM priv_key);
    }
}
