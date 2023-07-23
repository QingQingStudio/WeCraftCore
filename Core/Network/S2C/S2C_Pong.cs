﻿using System;
using ProtoBuf;

namespace WeCraft.Core.S2C
{
    [Serializable]
    [ProtoContract]
    public class S2C_Pong
    {
        [ProtoMember(1)]
        public string msg = "pong";
    }
}