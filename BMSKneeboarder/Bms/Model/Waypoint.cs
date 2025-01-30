using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model
{
    public class Waypoint : ICloneable
    {
        // Token: 0x06000166 RID: 358 RVA: 0x0002F20C File Offset: 0x0002D40C
        protected Waypoint()
        {
            this.DesignatedTargetID = new BmsStructs.BmsId[4];
            this.DesignatedTargetBuilding = new byte[4];
        }

        public bool IsTgtWaypoint
        {
            get
            {
                return (Action >= 9 && Action <= 26) || Action == 30;
            }
        }

        // Token: 0x06000167 RID: 359 RVA: 0x0002F22C File Offset: 0x0002D42C
        public Waypoint(byte[] bytes, ref int offset, int version)
            : this()
        {
            this.haves = bytes[offset];
            checked
            {
                offset++;
                this.GridX = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.GridY = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.GridZ = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.Arrive = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.Action = bytes[offset];
                offset++;
                this.RouteAction = bytes[offset];
                offset++;
                this.Formation = bytes[offset];
                offset++;
                if (version < 73)
                {
                    this.Flags = (uint)BitConverter.ToUInt16(bytes, offset);
                    offset += 2;
                }
                else
                {
                    this.Flags = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                }
                if ((this.haves & 2) != 0)
                {
                    this.TargetID = default(BmsStructs.BmsId);
                    this.TargetID.num = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.TargetID.creator = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.TargetBuilding = bytes[offset];
                    offset++;
                    if (version > 103)
                    {
                        int num = 0;
                        do
                        {
                            this.DesignatedTargetID[num].num = BitConverter.ToUInt32(bytes, offset);
                            offset += 4;
                            this.DesignatedTargetID[num].creator = BitConverter.ToUInt32(bytes, offset);
                            offset += 4;
                            this.DesignatedTargetBuilding[num] = bytes[offset];
                            offset++;
                            num++;
                        }
                        while (num <= 3);
                    }
                }
                else
                {
                    this.TargetID = default(BmsStructs.BmsId);
                    this.TargetBuilding = byte.MaxValue;
                    int num2 = 0;
                    do
                    {
                        this.DesignatedTargetID[num2].num = 0U;
                        this.DesignatedTargetID[num2].creator = 0U;
                        this.DesignatedTargetBuilding[num2] = 0;
                        num2++;
                    }
                    while (num2 <= 3);
                }
                if ((this.haves & 1) != 0)
                {
                    this.Depart = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                }
                else
                {
                    this.Depart = this.Arrive;
                }
                if (version < 100 && version >= 86)
                {
                    offset += 4;
                }
            }
        }

        // Token: 0x06000168 RID: 360 RVA: 0x0002F44C File Offset: 0x0002D64C
        public object Clone()
        {
            return new Waypoint
            {
                Action = this.Action,
                Arrive = this.Arrive,
                Depart = this.Depart,
                Flags = this.Flags,
                Formation = this.Formation,
                GridX = this.GridX,
                GridY = this.GridY,
                GridZ = this.GridZ,
                haves = this.haves,
                RouteAction = this.RouteAction,
                Speed = this.Speed,
                TargetBuilding = this.TargetBuilding,
                TargetID = this.TargetID
            };
        }

        // Token: 0x0400016B RID: 363
        public byte haves;

        // Token: 0x0400016C RID: 364
        public short GridX;

        // Token: 0x0400016D RID: 365
        public short GridY;

        // Token: 0x0400016E RID: 366
        public short GridZ;

        // Token: 0x0400016F RID: 367
        public uint Arrive;

        // Token: 0x04000170 RID: 368
        public byte Action;

        // Token: 0x04000171 RID: 369
        public byte RouteAction;

        // Token: 0x04000172 RID: 370
        public byte Formation;

        // Token: 0x04000173 RID: 371
        public uint Flags;

        // Token: 0x04000174 RID: 372
        public uint Speed;

        // Token: 0x04000175 RID: 373
        public BmsStructs.BmsId TargetID;

        // Token: 0x04000176 RID: 374
        public BmsStructs.BmsId[] DesignatedTargetID;

        // Token: 0x04000177 RID: 375
        public byte TargetBuilding;

        // Token: 0x04000178 RID: 376
        public byte[] DesignatedTargetBuilding;

        // Token: 0x04000179 RID: 377
        public uint Depart;

        // Token: 0x0400017A RID: 378
        public const byte WP_HAVE_DEPTIME = 1;

        // Token: 0x0400017B RID: 379
        public const byte WP_HAVE_TARGET = 2;

        // Token: 0x0400017C RID: 380
        private const int FLAGS_WIDENED_AT_VERSION = 73;
    }
}
