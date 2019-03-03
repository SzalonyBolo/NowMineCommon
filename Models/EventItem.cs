using NowMineCommon.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NowMineCommon.Models
{
    public struct EventItem
    {
        public CommandType commandType;
        public object Data;
        public uint EventID;

        public EventItem(CommandType commandType, object Data, uint EventID)
        {
            this.commandType = commandType;
            this.Data = Data;
            this.EventID = EventID;
        }
    }
}
