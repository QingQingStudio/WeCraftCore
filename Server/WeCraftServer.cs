﻿using System; 
using System.Threading;
using WeCraft.Core;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using WeCraft.Core.Game;
using WeCraft.Core.Network;

namespace WeCraft.Core
{
    internal class WeCraftServer
    {
        public static WeCraftServer Instance { get; private set; }
        public readonly ServiceProvider ServiceProvider;
        public readonly IServer? Server;
        public readonly ILogger? Logger;
        public readonly WeCraft.Core.WeCraftCore? Core;

        public WeCraftServer()
        {
            //初始化基础服务
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<ISetting, Setting>();
            serviceCollection.AddSingleton<IServer,Server>(); 
            serviceCollection.AddSingleton<ILogger>(LogManager.GetLogger("WeCraft"));
            serviceCollection.AddSingleton<WeCraft.Core.WeCraftCore>(new WeCraft.Core.WeCraftCore());
            ServiceProvider = serviceCollection.BuildServiceProvider(); 
            Server = ServiceProvider.GetService<IServer>();
            Logger = ServiceProvider.GetService<ILogger>();
            Core = ServiceProvider.GetService<WeCraft.Core.WeCraftCore>();
            if (this.Server == null)
            {
                throw new System.Exception("错误,找不到合适的服务器实例");
            }

            if (this.Logger == null)
            {
                throw new System.Exception("错误,找不到合适的日志系统");
            } 
        }
        public static void Main(string[] args)
        {
            Instance = new WeCraftServer();
            Instance.Server?.Run();
            Instance.ReadConsole();
        }

        private void ReadConsole()
        {
            while (true)
            {
                Console.WriteLine(Console.ReadLine());
                Thread.Sleep(50);
            }
        }
    }
}