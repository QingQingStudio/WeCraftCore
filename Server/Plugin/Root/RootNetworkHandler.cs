﻿using WeCraft.Core;
using WeCraft.Core.C2S;
using WeCraft.Core.S2C;
using WeCraft.Core.Util;

namespace WeCraft.Core.Plugin
{
    public class RootNetworkHandler
    {
        protected RootPlugin plugin;
        public RootNetworkHandler(RootPlugin rootPlugin)
        {
            this.plugin = rootPlugin;
        }
        public void HandlePing(ushort clientId,byte[] data)
        {
            var ping=PBUtil.Deserialize<C2S_Ping>(data);
            S2C_Pong pong = new S2C_Pong()
            {
                msg = ping.msg + "|pong|"+clientId
            };
            plugin.NetworkManager.Send(new []{clientId},plugin.DefaultChannel.Id,PackId.S2C_Pong,pong);
        }
    }
}