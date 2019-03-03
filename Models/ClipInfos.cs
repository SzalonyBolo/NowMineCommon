using System;
using System.Collections.Generic;
using System.Text;

namespace NowMineCommon.Models
{
    public class ClipInfo
    {
        public ClipInfo() { }
        public string ID { get; set; }
        public string Title { get; set; }
        public string ChannelName { get; set; }
        public Uri Thumbnail { get; set; }
    }

    public class ClipQueued : ClipInfo
    {
        public int UserID { get; set; }
        public int QPos { get; set; }
        public uint QueueID { get; set; }

        //for JSON deserializer
        public ClipQueued() 
        { }

        public ClipQueued(ClipInfo yi, int qPos, int userId, uint queueID)
        {
            this.ID = yi.ID;
            this.Title = yi.Title;
            this.ChannelName = yi.ChannelName;
            this.Thumbnail = yi.Thumbnail;
            this.QPos = qPos;
            this.UserID = userId;
            this.QueueID = queueID;
        }

        public ClipQueued(ClipInfo yi, int qPos) //for PlayedNow from QueuePanel to send on udp played video from queue
        {
            this.ID = yi.ID;
            this.Title = yi.Title;
            this.ChannelName = yi.ChannelName;
            this.Thumbnail = yi.Thumbnail;
            this.QPos = qPos;
            this.UserID = 0;
        }
    }
}
