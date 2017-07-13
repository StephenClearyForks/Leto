using System;
using System.IO.Pipelines;
using System.Net;
using System.Text;
using System.Buffers;
using System.Runtime;

namespace SocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Is server GC {GCSettings.IsServerGC}");

            if(args[1] == "s")
            {
                var server = new RawSocketSslStream(args[2]);
                var ignore = server.Run(IPAddress.Parse(args[0]));
                Console.WriteLine("Started");
                Console.ReadLine();
            }
            if(args[1] == "l")
            {
                var server = new RawSocketLeto(args[2]);
                server.Run(IPAddress.Parse(args[0])).Wait();
                Console.WriteLine("Started");
                Console.ReadLine();
            }
            else
            {
                var server = new RawSocketHttpServerSample(args[2]);
                var ignore = server.Run(IPAddress.Parse(args[0]));
                Console.WriteLine("Started");
                Console.ReadLine();
            }

            //var bytes = Encoding.ASCII.GetBytes("pHYs");

            //using (var factory = new PipeFactory())
            //using (var listener = new System.IO.Pipelines.Networking.Sockets.SocketListener())
            //using (var secureListener = new Leto.OpenSsl11.OpenSslSecurePipeListener(Data.Certificates.RSACertificate))
            //{
            //    listener.OnConnection(async (conn) =>
            //    {
            //        var pipe = await secureListener.CreateConnection(conn);
            //        Console.WriteLine("Handshake Done");
            //        var readResult = await pipe.Input.ReadAsync();
            //        var writer = pipe.Output.Alloc();
            //        writer.Append(readResult.Buffer);
            //        await writer.FlushAsync();
            //        pipe.Input.Advance(readResult.Buffer.End);
            //        pipe.Output.Complete();
            //        Console.WriteLine("Connection Done");

            //    });
            //    listener.Start(new IPEndPoint(IPAddress.Any, 443));
            //    Console.ReadLine();
            //}
        }
    }
}
