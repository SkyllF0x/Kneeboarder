using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace BMSKneeboarder.Bms.Model
{
    public class Objective : CampaignBase
    {
        // Token: 0x060000D8 RID: 216 RVA: 0x0001C11F File Offset: 0x0001A31F
        protected Objective()
        {
            this.RTD = 57.29578f;
            this.DTR = 0.01745329f;
        }

        // Token: 0x060000D9 RID: 217 RVA: 0x0001C140 File Offset: 0x0001A340
        public Objective(byte[] bytes, ref int offset, int version, int SubVer)
            : base(bytes, ref offset, version)
        {
            this.RTD = 57.29578f;
            this.DTR = 0.01745329f;
            this.lastRepair = BitConverter.ToUInt32(bytes, offset);
            checked
            {
                offset += 4;
                if (version > 1)
                {
                    this.obj_flags = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                }
                else
                {
                    this.obj_flags = (uint)BitConverter.ToUInt16(bytes, offset);
                    offset += 2;
                }
                this.supply = bytes[offset];
                offset++;
                this.fuel = bytes[offset];
                offset++;
                this.losses = bytes[offset];
                offset++;
                if (version < 100)
                {
                    if ((version >= 83) & (version < 84))
                    {
                        offset += 8;
                    }
                    else if ((version >= 84) & (version < 86))
                    {
                        offset += 12;
                    }
                    else if (version >= 86)
                    {
                        if (SubVer == 0)
                        {
                            offset += 12;
                        }
                        else if (SubVer == 1)
                        {
                            offset += 8;
                        }
                        else
                        {
                            offset += 8;
                        }
                    }
                }
                this.numStatuses = bytes[offset];
                offset++;
                this.fstatus = new byte[(int)(this.numStatuses + 1)];
                int i;
                for (i = 0; i < (int)this.numStatuses; i++)
                {
                    this.fstatus[i] = bytes[offset];
                    offset++;
                }
                this.priority = bytes[offset];
                offset++;
                this.nameId = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.parent = default(BmsStructs.BmsId);
                this.parent.num = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.parent.creator = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.first_owner = bytes[offset];
                offset++;
                this.links = bytes[offset];
                offset++;
                if (this.links > 0)
                {
                    this.link_data = new BmsStructs.CampObjectiveLinkDataType[(int)(this.links - 1 + 1)];
                }
                else
                {
                    this.link_data = null;
                }
                i = 0;
                while (i < (int)this.links)
                {
                    BmsStructs.CampObjectiveLinkDataType campObjectiveLinkDataType = default(BmsStructs.CampObjectiveLinkDataType);
                    campObjectiveLinkDataType.costs = new byte[9];
                    for (int j = 0; j < 8; j++)
                    {
                        campObjectiveLinkDataType.costs[j] = bytes[offset];
                        offset++;
                    }
                    BmsStructs.BmsId vu_ID = default(BmsStructs.BmsId);
                    vu_ID.num = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    vu_ID.creator = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    campObjectiveLinkDataType.id = vu_ID;
                    this.link_data[i] = campObjectiveLinkDataType;
                    Math.Max(Interlocked.Increment(ref i), i - 1);
                }
                if (version >= 20)
                {
                    this.hasRadarData = bytes[offset];
                    Math.Max(Interlocked.Increment(ref offset), offset - 1);
                    if (this.hasRadarData > 0)
                    {
                        this.detect_ratio = new float[9];
                        for (i = 0; i < 8; i++)
                        {
                            this.detect_ratio[i] = BitConverter.ToSingle(bytes, offset);
                            offset += 4;
                        }
                    }
                    else
                    {
                        this.detect_ratio = null;
                    }
                }
                else
                {
                    this.detect_ratio = null;
                }
                if (version >= 103)
                {
                    this.simPostion.y = BitConverter.ToDouble(bytes, offset);
                    offset += 8;
                    this.simPostion.x = BitConverter.ToDouble(bytes, offset);
                    offset += 8;
                    this.simPostion.z = BitConverter.ToDouble(bytes, offset);
                    offset += 8;
                    this.simHeaing = unchecked(BitConverter.ToSingle(bytes, offset) * this.RTD);
                    offset += 4;
                }
                if (version >= 106)
                {
                    Array.Resize<char>(ref this.CampName, 80);
                    this.CampName = Conversions.ToCharArrayRankOne(Encoding.Default.GetString(bytes, offset, 80));
                    offset += 80;
                }
                if (version < 100 && version >= 86)
                {
                    offset += 24;
                }
            }
        }

        // Token: 0x040000C2 RID: 194
        private float RTD;

        // Token: 0x040000C3 RID: 195
        private float DTR;

        // Token: 0x040000C4 RID: 196
        public uint lastRepair;

        // Token: 0x040000C5 RID: 197
        public uint obj_flags;

        // Token: 0x040000C6 RID: 198
        public byte supply;

        // Token: 0x040000C7 RID: 199
        public byte fuel;

        // Token: 0x040000C8 RID: 200
        public byte losses;

        // Token: 0x040000C9 RID: 201
        public byte numStatuses;

        // Token: 0x040000CA RID: 202
        public byte[] fstatus;

        // Token: 0x040000CB RID: 203
        public byte priority;

        // Token: 0x040000CC RID: 204
        public short nameId;

        // Token: 0x040000CD RID: 205
        public BmsStructs.BmsId parent;

        // Token: 0x040000CE RID: 206
        public byte first_owner;

        // Token: 0x040000CF RID: 207
        public byte links;

        // Token: 0x040000D0 RID: 208
        public BmsStructs.CampObjectiveLinkDataType[] link_data;

        // Token: 0x040000D1 RID: 209
        public byte hasRadarData;

        // Token: 0x040000D2 RID: 210
        public float[] detect_ratio;

        // Token: 0x040000D3 RID: 211
        public BmsStructs.Vector3 simPostion;

        // Token: 0x040000D4 RID: 212
        public float simHeaing;

        // Token: 0x040000D5 RID: 213
        public char[] CampName;
    }
}
