﻿using System.Threading.Channels;

namespace WeCraft.Core.Game
{
    public class GameLogic: IGameLogic
    {
        public Channel<string> CommandChannel;

        private IServer _server;
        public GameLogic(IServer server)
        {
            this._server = server;
        }

        public void Tick()
        {
        }
    }
}