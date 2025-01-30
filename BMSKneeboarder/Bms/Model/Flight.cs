using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMSKneeboarder.Bms;

namespace BMSKneeboarder.Bms.Model
{
    public class Flight : AirUnit, ICloneable
    {
        // Token: 0x060000C2 RID: 194 RVA: 0x0001AB65 File Offset: 0x00018D65
        protected Flight()
        {
        }

        // Token: 0x060000C3 RID: 195 RVA: 0x0001AB70 File Offset: 0x00018D70
        public object Clone()
        {
            return new Flight
            {
                baseFlags = baseFlags,
                callsign_id = callsign_id,
                callsign_num = callsign_num,
                campId = campId,
                cargo_id = cargo_id,
                current_wp = current_wp,
                dest_x = dest_x,
                dest_y = dest_y,
                dummy = dummy,
                entityType = entityType,
                eval_flags = eval_flags,
                fuel_burnt = fuel_burnt,
                fuel_initial = fuel_initial,
                id = id,
                last_check = last_check,
                last_combat = last_combat,
                last_direction = last_direction,
                last_move = last_move,
                last_player_slot = last_player_slot,
                loadout = loadout,
                loadouts = loadouts,
                losses = losses,
                mission = mission,
                mission_context = mission_context,
                mission_id = mission_id,
                mission_over_time = mission_over_time,
                mission_target = mission_target,
                moved = moved,
                name_id = name_id,
                numWaypoints = numWaypoints,
                old_mission = old_mission,
                owner = owner,
                package = package,
                pilots = pilots,
                plane_stats = plane_stats,
                player_slots = player_slots,
                priority = priority,
                reinforcement = reinforcement,
                requester = requester,
                roster = roster,
                slots = slots,
                spotted = spotted,
                spotTime = spotTime,
                squadron = squadron,
                tactic = tactic,
                target_id = target_id,
                time_on_target = time_on_target,
                unit_flags = unit_flags,
                use_loadout = use_loadout,
                x = x,
                y = y,
                z = z,
                texSet = texSet,
                TacanChannel = TacanChannel,
                TacanBand = TacanBand,
                STN = STN,
                F2F_ch = F2F_ch,
                MSN_ch = MSN_ch,
                EW_ch = EW_ch
            };
        }

        // Token: 0x060000C4 RID: 196 RVA: 0x0001AE18 File Offset: 0x00019018
        public Flight(byte[] bytes, ref int offset, int version)
            : base(bytes, ref offset, version)
        {
            z = BitConverter.ToSingle(bytes, offset);
            checked
            {
                offset += 4;
                fuel_burnt = BitConverter.ToInt32(bytes, offset);
                offset += 4;
                if (version < 65)
                {
                    fuel_burnt = 0;
                }
                if (version == 74 | version >= 100)
                {
                    fuel_initial = new int[4];
                    int num = 0;
                    do
                    {
                        fuel_initial[num] = BitConverter.ToInt32(bytes, offset);
                        offset += 4;
                        num++;
                    }
                    while (num <= 3);
                    laserCode = new int[4];
                    int num2 = 0;
                    do
                    {
                        laserCode[num2] = BitConverter.ToInt16(bytes, offset);
                        offset += 2;
                        num2++;
                    }
                    while (num2 <= 3);
                }
                last_move = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                last_combat = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                time_on_target = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                mission_over_time = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                mission_target = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                if (version < 100 && version >= 83)
                {
                    offset += 6;
                }
                loadouts = 0;
                if (version < 24)
                {
                    use_loadout = 0;
                    weapons = new byte[16];
                    loadouts = 1;
                    loadout = new BmsStructs.LoadoutStruct[(loadouts - 1 + 1)];
                    if (version >= 8)
                    {
                        use_loadout = bytes[offset];
                        offset++;
                        if (use_loadout != 0)
                        {
                            BmsStructs.LoadoutArray loadoutArray = default;
                            loadoutArray.Stores = new BmsStructs.LoadoutStruct[5];
                            int num3 = 0;
                            do
                            {
                                BmsStructs.LoadoutStruct loadoutStruct = loadoutArray.Stores[num3];
                                loadoutStruct.WeaponID = new ushort[16];
                                int num4 = 0;
                                do
                                {
                                    loadoutStruct.WeaponID[num4] = bytes[offset];
                                    offset++;
                                    num4++;
                                }
                                while (num4 <= 15);
                                loadoutStruct.WeaponCount = new byte[16];
                                int num5 = 0;
                                do
                                {
                                    loadoutStruct.WeaponCount[num5] = bytes[offset];
                                    offset++;
                                    num5++;
                                }
                                while (num5 <= 15);
                                num3++;
                            }
                            while (num3 <= 4);
                            loadout[0] = loadoutArray.Stores[0];
                        }
                    }
                    weapon = new short[16];
                    if (version < 18)
                    {
                        int num6 = 0;
                        do
                        {
                            weapon[num6] = BitConverter.ToInt16(bytes, offset);
                            offset += 2;
                            num6++;
                        }
                        while (num6 <= 15);
                        if (use_loadout == 0)
                        {
                            int num7 = 0;
                            do
                            {
                                loadout[0].WeaponID[num7] = (byte)weapon[num7];
                                num7++;
                            }
                            while (num7 <= 15);
                        }
                    }
                    else
                    {
                        int num8 = 0;
                        do
                        {
                            weapon[num8] = bytes[offset];
                            offset++;
                            num8++;
                        }
                        while (num8 <= 15);
                        if (use_loadout == 0)
                        {
                            int num9 = 0;
                            do
                            {
                                loadout[0].WeaponID[num9] = (byte)weapon[num9];
                                num9++;
                            }
                            while (num9 <= 15);
                        }
                    }
                    int num10 = 0;
                    do
                    {
                        weapons[num10] = bytes[offset];
                        offset++;
                        num10++;
                    }
                    while (num10 <= 15);
                    if (use_loadout == 0)
                    {
                        int num11 = 0;
                        do
                        {
                            loadout[0].WeaponCount[num11] = weapons[num11];
                            num11++;
                        }
                        while (num11 <= 15);
                    }
                }
                else
                {
                    loadouts = bytes[offset];
                    offset++;
                    loadout = new BmsStructs.LoadoutStruct[(loadouts - 1 + 1)];
                    int num12 = loadouts - 1;
                    for (int i = 0; i <= num12; i++)
                    {
                        BmsStructs.LoadoutStruct loadoutStruct2 = default;
                        loadoutStruct2.WeaponID = new ushort[16];
                        int num13 = 0;
                        do
                        {
                            if (version >= 73)
                            {
                                loadoutStruct2.WeaponID[num13] = BitConverter.ToUInt16(bytes, offset);
                                offset += 2;
                            }
                            else
                            {
                                loadoutStruct2.WeaponID[num13] = bytes[offset];
                                offset++;
                            }
                            num13++;
                        }
                        while (num13 <= 15);
                        loadoutStruct2.WeaponCount = new byte[16];
                        int num14 = 0;
                        do
                        {
                            loadoutStruct2.WeaponCount[num14] = bytes[offset];
                            offset++;
                            num14++;
                        }
                        while (num14 <= 15);
                        loadout[i] = loadoutStruct2;
                    }
                }
                mission = bytes[offset];
                offset++;
                if (version > 65)
                {
                    old_mission = bytes[offset];
                    offset++;
                }
                else
                {
                    old_mission = mission;
                }
                last_direction = bytes[offset];
                offset++;
                priority = bytes[offset];
                offset++;
                mission_id = bytes[offset];
                offset++;
                if (version < 14)
                {
                    dummy = bytes[offset];
                    offset++;
                }
                eval_flags = bytes[offset];
                offset++;
                if (version > 65)
                {
                    mission_context = bytes[offset];
                    offset++;
                }
                else
                {
                    mission_context = 0;
                }
                package = default;
                package.num = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                package.creator = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                squadron = default;
                squadron.num = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                squadron.creator = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                if (version > 65)
                {
                    requester = default;
                    requester.num = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    requester.creator = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                }
                else
                {
                    requester = default;
                }
                slots = new byte[4];
                int num15 = 0;
                do
                {
                    slots[num15] = bytes[offset];
                    offset++;
                    num15++;
                }
                while (num15 <= 3);
                pilots = new byte[4];
                int num16 = 0;
                do
                {
                    pilots[num16] = bytes[offset];
                    offset++;
                    num16++;
                }
                while (num16 <= 3);
                plane_stats = new byte[4];
                int num17 = 0;
                do
                {
                    plane_stats[num17] = bytes[offset];
                    offset++;
                    num17++;
                }
                while (num17 <= 3);
                player_slots = new byte[4];
                int num18 = 0;
                do
                {
                    player_slots[num18] = bytes[offset];
                    offset++;
                    num18++;
                }
                while (num18 <= 3);
                last_player_slot = bytes[offset];
                offset++;
                callsign_id = bytes[offset];
                offset++;
                callsign_num = bytes[offset];
                offset++;
                refuelQuantity = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                if (version >= 105)
                {
                    texSet = new long[4];
                    int num19 = 0;
                    do
                    {
                        texSet[num19] = unchecked(BitConverter.ToInt32(bytes, offset));
                        offset += 4;
                        num19++;
                    }
                    while (num19 <= 3);
                }
                if (version >= 108)
                {
                    TacanChannel = new byte[4];
                    int num20 = 0;
                    do
                    {
                        TacanChannel[num20] = bytes[offset];
                        offset++;
                        num20++;
                    }
                    while (num20 <= 3);
                    TacanBand = new byte[4];
                    int num21 = 0;
                    do
                    {
                        TacanBand[num21] = bytes[offset];
                        offset++;
                        num21++;
                    }
                    while (num21 <= 3);
                }
                if (version >= 109)
                {
                    Loaded_CFT = new bool[4];
                    int num22 = 0;
                    do
                    {
                        if (bytes[offset] > 0)
                        {
                            Loaded_CFT[num22] = true;
                        }
                        else
                        {
                            Loaded_CFT[num22] = false;
                        }
                        offset++;
                        num22++;
                    }
                    while (num22 <= 3);
                }
                if (version < 100 && version >= 83)
                {
                    offset += 244;
                }
            }
        }

        public int PlanesNum
        {
            get
            {
                int sz = 0;
                if (plane_stats[1] == 0)
                    sz = 1;
                else if (plane_stats[2] == 0)
                    sz = 2;
                else if (plane_stats[3] == 0)
                    sz = 3;
                else
                    sz = 4;
                return sz;
            }
        }

        // Token: 0x04000095 RID: 149
        public int fuel_burnt;

        // Token: 0x04000096 RID: 150
        public uint last_move;

        // Token: 0x04000097 RID: 151
        public uint last_combat;

        // Token: 0x04000098 RID: 152
        public uint time_on_target;

        // Token: 0x04000099 RID: 153
        public uint mission_over_time;

        // Token: 0x0400009A RID: 154
        public short mission_target;

        // Token: 0x0400009B RID: 155
        public byte use_loadout;

        // Token: 0x0400009C RID: 156
        public byte[] weapons;

        // Token: 0x0400009D RID: 157
        public byte loadouts;

        // Token: 0x0400009E RID: 158
        public BmsStructs.LoadoutStruct[] loadout;

        // Token: 0x0400009F RID: 159
        public short[] weapon;

        // Token: 0x040000A0 RID: 160
        public byte mission;

        // Token: 0x040000A1 RID: 161
        public byte old_mission;

        // Token: 0x040000A2 RID: 162
        public byte last_direction;

        // Token: 0x040000A3 RID: 163
        public byte priority;

        // Token: 0x040000A4 RID: 164
        public byte mission_id;

        // Token: 0x040000A5 RID: 165
        public byte dummy;

        // Token: 0x040000A6 RID: 166
        public byte eval_flags;

        // Token: 0x040000A7 RID: 167
        public byte mission_context;

        // Token: 0x040000A8 RID: 168
        public BmsStructs.BmsId package;

        // Token: 0x040000A9 RID: 169
        public BmsStructs.BmsId squadron;

        // Token: 0x040000AA RID: 170
        public BmsStructs.BmsId requester;

        // Token: 0x040000AB RID: 171
        public int[] fuel_initial;

        // Token: 0x040000AC RID: 172
        public int[] laserCode;

        // Token: 0x040000AD RID: 173
        public byte[] slots;

        // Token: 0x040000AE RID: 174
        public byte[] pilots;

        // Token: 0x040000AF RID: 175
        public byte[] plane_stats;

        // Token: 0x040000B0 RID: 176
        public byte[] player_slots;

        // Token: 0x040000B1 RID: 177
        public byte last_player_slot;

        // Token: 0x040000B2 RID: 178
        public byte callsign_id;

        // Token: 0x040000B3 RID: 179
        public byte callsign_num;

        // Token: 0x040000B4 RID: 180
        public uint refuelQuantity;

        // Token: 0x040000B5 RID: 181
        public long[] texSet;

        // Token: 0x040000B6 RID: 182
        public byte[] TacanChannel;

        // Token: 0x040000B7 RID: 183
        public byte[] TacanBand;

        // Token: 0x040000B8 RID: 184
        public bool[] Loaded_CFT;

        // Token: 0x040000B9 RID: 185
        private const int WEAPON_IDS_WIDENED_VERSION = 73;

        // Token: 0x040000BA RID: 186
        private const int NEW_ENDING_FIELD_ADDED_VERSION = 73;

        public string STN = string.Empty;
        public string F2F_ch = string.Empty;
        public string MSN_ch = string.Empty;
        public string EW_ch = string.Empty;
    }
}
