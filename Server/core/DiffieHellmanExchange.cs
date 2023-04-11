﻿using CoreLib;
using System.Security.Policy;
using System.Threading.Tasks;
using static Server.core.Server;

namespace Server.core
{
    public class DiffieHellmanExchange
    {
        public static string GenKeyMessForClient(DiffieHellman Alice, LogHandler logHandler)
        {
            var publicKey = Alice.PublicKey;

            var resultString = NetworkCodes.GetMessage(NetworkCodes.MessageCodes.DiffieHellmanExchange,
                                                       publicKey.ToString());

            logHandler(ServerLogMessages.DiffieHellmanExchangeDataSended(publicKey.ToString()));
            return resultString;
        }

    }
}
