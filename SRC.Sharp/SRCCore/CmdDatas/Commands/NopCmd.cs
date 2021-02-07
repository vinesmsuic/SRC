﻿using SRCCore.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRCCore.CmdDatas.Commands
{
    public class NopCmd : CmdData
    {
        public NopCmd(SRC src, EventDataLine eventData) : base(src, CmdType.NopCmd, eventData)
        {
        }

        protected override int ExecInternal()
        {
            return EventData.ID + 1;
        }
    }
}
