﻿using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;
using Leto.Tls13.BulkCipher;
using Leto.Tls13.State;
using static Interop.LibCrypto;

namespace Leto.Tls13.Sessions
{
    public class ResumptionKey
    {
        private long _randomId;
        private long _randomServiceId;
        private byte[] _key;
        private byte[] _nounceBase;
        private long _sequence;
        private long _nounceStart;

        public ResumptionKey(long serviceId, long id, byte[] key, byte[] nounceBase)
        {
            _randomServiceId = serviceId;
            _randomId = id;
            _key = key;
            _nounceStart = BitConverter.ToInt64(nounceBase, 0);
            _nounceBase = nounceBase;
        }

        public byte[] DecryptSession(ReadableBuffer buffer)
        {
            throw new NotImplementedException();
        }

        internal void WriteSessionKey(ref WritableBuffer writer, ConnectionState state)
        {
            writer.WriteBigEndian(_randomServiceId);
            writer.WriteBigEndian(_randomId);
            var sequence = System.Threading.Interlocked.Increment(ref _sequence);
            writer.WriteBigEndian(_nounceStart ^ sequence);
            writer.Write(new Span<byte>(_nounceBase,8));

            //Now we have to encrypt the data
            writer.WriteBigEndian(state.CipherSuite.CipherCode);
            writer.WriteBigEndian(state.Version);
            writer.Write(state.KeySchedule.ResumptionSecret);
        }
    }
}
