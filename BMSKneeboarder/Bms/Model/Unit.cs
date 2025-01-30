using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMSKneeboarder.Bms;

namespace BMSKneeboarder.Bms.Model
{
    public class Unit : CampaignBase
    {
        // Token: 0x0600013B RID: 315 RVA: 0x0002676F File Offset: 0x0002496F
        protected Unit()
        {
        }

        // Token: 0x0600013C RID: 316 RVA: 0x00026778 File Offset: 0x00024978
        public Unit(byte[] bytes, ref int offset, int version)
            : base(bytes, ref offset, version)
        {
            last_check = BitConverter.ToUInt32(bytes, offset);
            checked
            {
                offset += 4;
                roster = BitConverter.ToInt32(bytes, offset);
                offset += 4;
                unit_flags = BitConverter.ToInt32(bytes, offset);
                offset += 4;
                dest_x = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                dest_y = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                target_id = default;
                target_id.num = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                target_id.creator = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                if (version > 1)
                {
                    cargo_id = default;
                    cargo_id.num = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    cargo_id.creator = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                }
                else
                {
                    cargo_id = default;
                }
                moved = bytes[offset];
                offset++;
                losses = bytes[offset];
                offset++;
                tactic = bytes[offset];
                offset++;
                if (version < 100 && version >= 83)
                {
                    offset += 4;
                }
                if (version >= 71)
                {
                    current_wp = BitConverter.ToUInt16(bytes, offset);
                    offset += 2;
                }
                else
                {
                    current_wp = bytes[offset];
                    offset++;
                }
                name_id = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                reinforcement = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                DecodeWaypoints(bytes, ref offset, version);
            }
        }

        // Token: 0x0600013D RID: 317 RVA: 0x0002691C File Offset: 0x00024B1C
        protected void DecodeWaypoints(byte[] bytes, ref int offset, int version)
        {
            checked
            {
                if (version >= 71)
                {
                    numWaypoints = BitConverter.ToUInt16(bytes, offset);
                    offset += 2;
                }
                else
                {
                    numWaypoints = bytes[offset];
                    offset++;
                }
                if (numWaypoints > 500)
                {
                    numWaypoints = 0;
                }
                waypoints = new Waypoint[(numWaypoints - 1 + 1)];
                int num = numWaypoints - 1;
                for (int i = 0; i <= num; i++)
                {
                    waypoints[i] = new Waypoint(bytes, ref offset, version);
                }
            }
        }

        // Token: 0x1700000C RID: 12
        // (get) Token: 0x0600013E RID: 318 RVA: 0x000269A2 File Offset: 0x00024BA2
        protected bool Final
        {
            get
            {
                return (unit_flags & 1048576) > 0;
            }
        }

        // Token: 0x04000159 RID: 345
        public uint last_check;

        // Token: 0x0400015A RID: 346
        public int roster;

        // Token: 0x0400015B RID: 347
        public int unit_flags;

        // Token: 0x0400015C RID: 348
        public short dest_x;

        // Token: 0x0400015D RID: 349
        public short dest_y;

        // Token: 0x0400015E RID: 350
        public BmsStructs.BmsId target_id;

        // Token: 0x0400015F RID: 351
        public BmsStructs.BmsId cargo_id;

        // Token: 0x04000160 RID: 352
        public byte moved;

        // Token: 0x04000161 RID: 353
        public byte losses;

        // Token: 0x04000162 RID: 354
        public byte tactic;

        // Token: 0x04000163 RID: 355
        public ushort current_wp;

        // Token: 0x04000164 RID: 356
        public short name_id;

        // Token: 0x04000165 RID: 357
        public short reinforcement;

        // Token: 0x04000166 RID: 358
        public ushort numWaypoints;

        // Token: 0x04000167 RID: 359
        public Waypoint[] waypoints;

        // Token: 0x04000168 RID: 360
        public const int U_FINAL = 1048576;
    }
}
