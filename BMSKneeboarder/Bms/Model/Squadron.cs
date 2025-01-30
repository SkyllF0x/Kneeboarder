using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMSKneeboarder.Bms;

namespace BMSKneeboarder.Bms.Model
{
    public class Squadron : AirUnit
    {
        // Token: 0x06000120 RID: 288 RVA: 0x0002386C File Offset: 0x00021A6C
        protected Squadron()
        {
        }

        // Token: 0x06000121 RID: 289 RVA: 0x0002387F File Offset: 0x00021A7F
        public Squadron Clone()
        {
            return (Squadron)MemberwiseClone();
        }

        // Token: 0x06000122 RID: 290 RVA: 0x0002388C File Offset: 0x00021A8C
        public Squadron(byte[] bytes, ref int offset, int version, bool Export)
            : base(bytes, ref offset, version)
        {
            fuel = BitConverter.ToInt32(bytes, offset);
            checked
            {
                offset += 4;
                specialty = bytes[offset];
                offset++;
                if (version >= 101)
                {
                    campSpecificRating = new byte[16];
                    int num = 0;
                    do
                    {
                        campSpecificRating[num] = bytes[offset];
                        offset++;
                        num++;
                    }
                    while (num <= 15);
                }
                if (version < 69)
                {
                    stores = new byte[200];
                    int num2 = 0;
                    do
                    {
                        stores[num2] = bytes[offset];
                        offset++;
                        num2++;
                    }
                    while (num2 <= 199);
                }
                else if (version == 73)
                {
                    stores = new byte[600];
                    int num3 = 0;
                    do
                    {
                        stores[num3] = bytes[offset];
                        offset++;
                        num3++;
                    }
                    while (num3 <= 599);
                }
                else if (version == 74 | version >= 100)
                {
                    stores = new byte[1000];
                    int num4 = 0;
                    do
                    {
                        stores[num4] = bytes[offset];
                        offset++;
                        num4++;
                    }
                    while (num4 <= 999);
                }
                else if (version < 100)
                {
                    if (version >= 83)
                    {
                        stores = new byte[600];
                        int num5 = 0;
                        do
                        {
                            stores[num5] = bytes[offset];
                            offset++;
                            num5++;
                        }
                        while (num5 <= 599);
                    }
                }
                else
                {
                    stores = new byte[220];
                    int num6 = 0;
                    do
                    {
                        stores[num6] = bytes[offset];
                        offset++;
                        num6++;
                    }
                    while (num6 <= 219);
                }
                if (version < 47)
                {
                    if (version >= 29)
                    {
                        pilots = new Pilot[48];
                        int num7 = pilots.Length - 1;
                        for (int i = 0; i <= num7; i++)
                        {
                            Pilot pilot = new Pilot();
                            pilot.pilot_id = BitConverter.ToInt16(bytes, offset);
                            offset += 2;
                            pilot.pilot_skill_and_rating = bytes[offset];
                            offset++;
                            pilot.pilot_status = bytes[offset];
                            offset++;
                            pilot.aa_kills = bytes[offset];
                            offset++;
                            pilot.ag_kills = bytes[offset];
                            offset++;
                            pilot.as_kills = bytes[offset];
                            offset++;
                            pilot.an_kills = bytes[offset];
                            offset++;
                            pilots[i] = pilot;
                        }
                    }
                    else
                    {
                        pilots = new Pilot[36];
                        int num8 = pilots.Length - 1;
                        for (int j = 0; j <= num8; j++)
                        {
                            Pilot pilot2 = new Pilot();
                            pilot2.pilot_id = BitConverter.ToInt16(bytes, offset);
                            offset += 2;
                            pilot2.pilot_skill_and_rating = bytes[offset];
                            offset++;
                            pilot2.pilot_status = bytes[offset];
                            offset++;
                            pilot2.aa_kills = bytes[offset];
                            offset++;
                            pilot2.ag_kills = bytes[offset];
                            offset++;
                            pilot2.as_kills = bytes[offset];
                            offset++;
                            pilot2.an_kills = bytes[offset];
                            offset++;
                            pilots[j] = pilot2;
                        }
                    }
                }
                else
                {
                    pilots = new Pilot[48];
                    int num9 = pilots.Length - 1;
                    for (int k = 0; k <= num9; k++)
                    {
                        Pilot pilot3 = new Pilot();
                        pilot3.pilot_id = BitConverter.ToInt16(bytes, offset);
                        offset += 2;
                        pilot3.pilot_skill_and_rating = bytes[offset];
                        offset++;
                        pilot3.pilot_status = bytes[offset];
                        offset++;
                        pilot3.aa_kills = bytes[offset];
                        offset++;
                        pilot3.ag_kills = bytes[offset];
                        offset++;
                        pilot3.as_kills = bytes[offset];
                        offset++;
                        pilot3.an_kills = bytes[offset];
                        offset++;
                        pilot3.missions_flown = BitConverter.ToInt16(bytes, offset);
                        offset += 2;
                        pilots[k] = pilot3;
                    }
                }
                schedule = new int[16];
                int num10 = schedule.Length - 1;
                for (int l = 0; l <= num10; l++)
                {
                    schedule[l] = BitConverter.ToInt32(bytes, offset);
                    offset += 4;
                }
                airbase_id = default;
                airbase_id.num = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                airbase_id.creator = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                hot_spot = default;
                hot_spot.num = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                hot_spot.creator = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                if (version >= 6 && version < 16)
                {
                    junk = default;
                    junk.num = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    junk.creator = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                }
                rating = new byte[16];
                int num11 = rating.Length - 1;
                for (int m = 0; m <= num11; m++)
                {
                    rating[m] = bytes[offset];
                    offset++;
                }
                aa_kills = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                ag_kills = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                as_kills = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                an_kills = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                missions_flown = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                mission_score = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                total_losses = bytes[offset];
                offset++;
                if (version >= 9)
                {
                    pilot_losses = bytes[offset];
                    offset++;
                }
                else
                {
                    pilot_losses = 0;
                }
                if (version >= 100)
                {
                    squadron_patch = BitConverter.ToUInt16(bytes, offset);
                    offset += 2;
                }
                else if (version >= 45)
                {
                    squadron_patch = bytes[offset];
                    offset++;
                }
                if (version >= 101 && Export)
                {
                    squadronName = BmsUtils.FixName(Encoding.Default.GetString(bytes, offset, 80));
                    offset += 80;
                }
                if (version < 100 && version >= 83)
                {
                    offset += 3;
                }
                if (version >= 102)
                {
                    squadronRetaskAt = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    veh_relocate = bytes[offset];
                    offset++;
                }
                if (version >= 105)
                {
                    texSet = unchecked(BitConverter.ToInt32(bytes, offset));
                    offset += 4;
                }
            }
        }


        // Token: 0x0400010A RID: 266
        public int fuel;

        // Token: 0x0400010B RID: 267
        public byte specialty;

        // Token: 0x0400010C RID: 268
        public byte[] campSpecificRating;

        // Token: 0x0400010D RID: 269
        public byte[] stores;

        // Token: 0x0400010E RID: 270
        public Pilot[] pilots;

        // Token: 0x0400010F RID: 271
        public int[] schedule;

        // Token: 0x04000110 RID: 272
        public BmsStructs.BmsId airbase_id;

        // Token: 0x04000111 RID: 273
        public BmsStructs.BmsId hot_spot;

        // Token: 0x04000112 RID: 274
        public BmsStructs.BmsId junk;

        // Token: 0x04000113 RID: 275
        public byte[] rating;

        // Token: 0x04000114 RID: 276
        public short aa_kills;

        // Token: 0x04000115 RID: 277
        public short ag_kills;

        // Token: 0x04000116 RID: 278
        public short as_kills;

        // Token: 0x04000117 RID: 279
        public short an_kills;

        // Token: 0x04000118 RID: 280
        public short missions_flown;

        // Token: 0x04000119 RID: 281
        public short mission_score;

        // Token: 0x0400011A RID: 282
        public byte total_losses;

        // Token: 0x0400011B RID: 283
        public byte pilot_losses;

        // Token: 0x0400011C RID: 284
        public ushort squadron_patch;

        // Token: 0x0400011D RID: 285
        public uint squadronRetaskAt;

        // Token: 0x0400011E RID: 286
        public byte veh_relocate;

        // Token: 0x0400011F RID: 287
        public long texSet;

        // Token: 0x04000120 RID: 288
        public string squadronName;
    }
}
