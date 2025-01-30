using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model
{
    public class Team
    {
        // Token: 0x06000135 RID: 309 RVA: 0x00025756 File Offset: 0x00023956
        protected Team()
        {
            this.MAX_BONUSES = 20;
            this.MAX_TGTTYPE = 36;
            this.MAX_UNITTYPE = 20;
        }

        // Token: 0x06000136 RID: 310 RVA: 0x00025778 File Offset: 0x00023978
        public Team(byte[] bytes, ref int offset, int version)
        {
            this.MAX_BONUSES = 20;
            this.MAX_TGTTYPE = 36;
            this.MAX_UNITTYPE = 20;
            this.id.num = BitConverter.ToUInt32(bytes, offset);
            checked
            {
                offset += 4;
                this.id.creator = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.entityType = BitConverter.ToUInt16(bytes, offset);
                offset += 2;
                this.who = bytes[offset];
                offset++;
                this.cteam = bytes[offset];
                offset++;
                this.flags = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                if (version > 2)
                {
                    Array.Resize<byte>(ref this.member, 8);
                    int num = this.member.Length - 1;
                    for (int i = 0; i <= num; i++)
                    {
                        this.member[i] = bytes[offset];
                        offset++;
                    }
                    Array.Resize<short>(ref this.stance, 8);
                    int num2 = this.member.Length - 1;
                    for (int j = 0; j <= num2; j++)
                    {
                        this.stance[j] = BitConverter.ToInt16(bytes, offset);
                        offset += 2;
                    }
                }
                else
                {
                    Array.Resize<byte>(ref this.member, 8);
                    int num3 = 0;
                    do
                    {
                        this.member[num3] = bytes[offset];
                        offset++;
                        num3++;
                    }
                    while (num3 <= 7);
                    Array.Resize<short>(ref this.stance, 8);
                    int num4 = 0;
                    do
                    {
                        this.stance[num4] = BitConverter.ToInt16(bytes, offset);
                        offset += 2;
                        num4++;
                    }
                    while (num4 <= 7);
                }
                this.firstColonel = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.firstCommander = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.firstWingman = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.lastWingman = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.playerRating = 0f;
                this.lastPlayerMission = 0U;
                if (version > 11)
                {
                    this.airExperience = bytes[offset];
                    offset++;
                    this.airDefenseExperience = bytes[offset];
                    offset++;
                    this.groundExperience = bytes[offset];
                    offset++;
                    this.navalExperience = bytes[offset];
                    offset++;
                }
                else
                {
                    offset += 4;
                    this.airExperience = 80;
                    this.airDefenseExperience = 80;
                    this.groundExperience = 80;
                    this.navalExperience = 80;
                }
                this.initiative = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.supplyAvail = BitConverter.ToUInt16(bytes, offset);
                offset += 2;
                this.fuelAvail = BitConverter.ToUInt16(bytes, offset);
                offset += 2;
                if (version > 53)
                {
                    this.replacementsAvail = BitConverter.ToUInt16(bytes, offset);
                    offset += 2;
                    this.playerRating = BitConverter.ToSingle(bytes, offset);
                    offset += 4;
                    this.lastPlayerMission = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                }
                else
                {
                    this.replacementsAvail = 0;
                    this.playerRating = 0f;
                    this.lastPlayerMission = 0U;
                }
                if (version < 40)
                {
                    offset += 4;
                }
                this.currentStats = default(BmsStructs.TeamStatus);
                this.currentStats.airDefenseVehs = BitConverter.ToUInt16(bytes, offset);
                offset += 2;
                this.currentStats.aircraft = BitConverter.ToUInt16(bytes, offset);
                offset += 2;
                this.currentStats.groundVehs = BitConverter.ToUInt16(bytes, offset);
                offset += 2;
                this.currentStats.ships = BitConverter.ToUInt16(bytes, offset);
                offset += 2;
                this.currentStats.supply = BitConverter.ToUInt16(bytes, offset);
                offset += 2;
                this.currentStats.fuel = BitConverter.ToUInt16(bytes, offset);
                offset += 2;
                this.currentStats.airbases = BitConverter.ToUInt16(bytes, offset);
                offset += 2;
                this.currentStats.supplyLevel = bytes[offset];
                offset++;
                this.currentStats.fuelLevel = bytes[offset];
                offset++;
                this.startStats = default(BmsStructs.TeamStatus);
                this.startStats.airDefenseVehs = BitConverter.ToUInt16(bytes, offset);
                offset += 2;
                this.startStats.aircraft = BitConverter.ToUInt16(bytes, offset);
                offset += 2;
                this.startStats.groundVehs = BitConverter.ToUInt16(bytes, offset);
                offset += 2;
                this.startStats.ships = BitConverter.ToUInt16(bytes, offset);
                offset += 2;
                this.startStats.supply = BitConverter.ToUInt16(bytes, offset);
                offset += 2;
                this.startStats.fuel = BitConverter.ToUInt16(bytes, offset);
                offset += 2;
                this.startStats.airbases = BitConverter.ToUInt16(bytes, offset);
                offset += 2;
                this.startStats.supplyLevel = bytes[offset];
                offset++;
                this.startStats.fuelLevel = bytes[offset];
                offset++;
                if (version < 100 && version >= 83)
                {
                    offset++;
                }
                this.reinforcement = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                Array.Resize<BmsStructs.BmsId>(ref this.bonusObjs, (int)this.MAX_BONUSES);
                int num5 = this.bonusObjs.Length - 1;
                for (int k = 0; k <= num5; k++)
                {
                    this.bonusObjs[k].num = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.bonusObjs[k].creator = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                }
                Array.Resize<uint>(ref this.bonusTime, (int)this.MAX_BONUSES);
                int num6 = this.bonusTime.Length - 1;
                for (int l = 0; l <= num6; l++)
                {
                    this.bonusTime[l] = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                }
                Array.Resize<byte>(ref this.objtype_priority, (int)this.MAX_TGTTYPE);
                int num7 = this.objtype_priority.Length - 1;
                for (int m = 0; m <= num7; m++)
                {
                    this.objtype_priority[m] = bytes[offset];
                    offset++;
                }
                Array.Resize<byte>(ref this.unittype_priority, (int)this.MAX_UNITTYPE);
                int num8 = this.unittype_priority.Length - 1;
                for (int n = 0; n <= num8; n++)
                {
                    this.unittype_priority[n] = bytes[offset];
                    offset++;
                }
                if (version < 30)
                {
                    Array.Resize<byte>(ref this.mission_priority, 40);
                    int num9 = this.mission_priority.Length - 1;
                    for (int num10 = 0; num10 <= num9; num10++)
                    {
                        this.mission_priority[num10] = bytes[offset];
                        offset++;
                    }
                }
                else if ((version >= 30) & (version < 102))
                {
                    Array.Resize<byte>(ref this.mission_priority, 41);
                    int num11 = this.mission_priority.Length - 1;
                    for (int num12 = 0; num12 <= num11; num12++)
                    {
                        this.mission_priority[num12] = bytes[offset];
                        offset++;
                    }
                }
                else
                {
                    Array.Resize<byte>(ref this.mission_priority, 50);
                    int num13 = this.mission_priority.Length - 1;
                    for (int num14 = 0; num14 <= num13; num14++)
                    {
                        this.mission_priority[num14] = bytes[offset];
                        offset++;
                    }
                }
                if (version < 34)
                {
                    this.attackTime = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.offensiveLoss = bytes[offset];
                    offset++;
                }
                Array.Resize<byte>(ref this.max_vehicle, 4);
                int num15 = this.max_vehicle.Length - 1;
                for (int num16 = 0; num16 <= num15; num16++)
                {
                    this.max_vehicle[num16] = bytes[offset];
                    offset++;
                }
                if (version > 4)
                {
                    this.teamFlag = bytes[offset];
                    offset++;
                    if (version > 32)
                    {
                        this.teamColor = bytes[offset];
                        offset++;
                    }
                    else
                    {
                        this.teamColor = 0;
                    }
                    this.equipment = bytes[offset];
                    offset++;
                    this.name = Encoding.Default.GetString(bytes, offset, 20);
                    offset += 20;
                    int num17 = this.name.IndexOf('\0');
                    if (num17 > 0)
                    {
                        this.name = this.name.Substring(0, num17);
                    }
                    else
                    {
                        this.name = string.Empty;
                    }
                }
                if (version > 32)
                {
                    this.teamMotto = Encoding.Default.GetString(bytes, offset, 200);
                    offset += 200;
                    int num17 = this.teamMotto.IndexOf('\0');
                    if (num17 > 0)
                    {
                        this.teamMotto = this.teamMotto.Substring(0, num17);
                    }
                    else
                    {
                        this.teamMotto = string.Empty;
                    }
                }
                else
                {
                    this.teamMotto = string.Empty;
                }
                if (version > 33)
                {
                    if (version > 50)
                    {
                        this.groundAction.actionTime = BitConverter.ToUInt32(bytes, offset);
                        offset += 4;
                        this.groundAction.actionTimeout = BitConverter.ToUInt32(bytes, offset);
                        offset += 4;
                        this.groundAction.actionObjective.num = BitConverter.ToUInt32(bytes, offset);
                        offset += 4;
                        this.groundAction.actionObjective.creator = BitConverter.ToUInt32(bytes, offset);
                        offset += 4;
                        this.groundAction.actionType = bytes[offset];
                        offset++;
                        this.groundAction.actionTempo = bytes[offset];
                        offset++;
                        this.groundAction.actionPoints = bytes[offset];
                        offset++;
                    }
                    else if (version > 41)
                    {
                        offset += 27;
                    }
                    else
                    {
                        offset += 23;
                    }
                    this.defensiveAirAction.actionStartTime = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.defensiveAirAction.actionStopTime = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.defensiveAirAction.actionObjective.num = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.defensiveAirAction.actionObjective.creator = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.defensiveAirAction.lastActionObjective.num = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.defensiveAirAction.lastActionObjective.creator = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.defensiveAirAction.actionType = bytes[offset];
                    offset++;
                    offset += 3;
                    this.offensiveAirAction.actionStartTime = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.offensiveAirAction.actionStopTime = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.offensiveAirAction.actionObjective.num = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.offensiveAirAction.actionObjective.creator = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.offensiveAirAction.lastActionObjective.num = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.offensiveAirAction.lastActionObjective.creator = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.offensiveAirAction.actionType = bytes[offset];
                    offset++;
                    offset += 3;
                }
                if (version < 43)
                {
                    this.groundAction.actionType = 2;
                    //this.supplyAvail = (unchecked((((this.fuelAvail == 1000) != false) ? true : false)) ? true : false);
                }
                if (version < 51)
                {
                    if (this.who == 4)
                    {
                        this.firstColonel = 500;
                        this.firstCommander = 505;
                        this.firstWingman = 538;
                        this.lastWingman = 583;
                    }
                    else if (this.who == 5)
                    {
                        this.firstColonel = 600;
                        this.firstCommander = 605;
                        this.firstWingman = 639;
                        this.lastWingman = 686;
                    }
                    else if (this.who == 1)
                    {
                        this.firstColonel = 0;
                        this.firstCommander = 20;
                        this.firstWingman = 149;
                        this.lastWingman = 373;
                    }
                }
                if (version < 100 && version >= 83)
                {
                    offset += 4;
                }
            }
        }

        // Token: 0x0400012C RID: 300
        public byte MAX_BONUSES;

        // Token: 0x0400012D RID: 301
        public byte MAX_TGTTYPE;

        // Token: 0x0400012E RID: 302
        public byte MAX_UNITTYPE;

        // Token: 0x0400012F RID: 303
        public BmsStructs.BmsId id;

        // Token: 0x04000130 RID: 304
        public ushort entityType;

        // Token: 0x04000131 RID: 305
        public byte who;

        // Token: 0x04000132 RID: 306
        public byte cteam;

        // Token: 0x04000133 RID: 307
        public short flags;

        // Token: 0x04000134 RID: 308
        public byte[] member;

        // Token: 0x04000135 RID: 309
        public short[] stance;

        // Token: 0x04000136 RID: 310
        public short firstColonel;

        // Token: 0x04000137 RID: 311
        public short firstCommander;

        // Token: 0x04000138 RID: 312
        public short firstWingman;

        // Token: 0x04000139 RID: 313
        public short lastWingman;

        // Token: 0x0400013A RID: 314
        public byte airExperience;

        // Token: 0x0400013B RID: 315
        public byte airDefenseExperience;

        // Token: 0x0400013C RID: 316
        public byte groundExperience;

        // Token: 0x0400013D RID: 317
        public byte navalExperience;

        // Token: 0x0400013E RID: 318
        public short initiative;

        // Token: 0x0400013F RID: 319
        public ushort supplyAvail;

        // Token: 0x04000140 RID: 320
        public ushort fuelAvail;

        // Token: 0x04000141 RID: 321
        public ushort replacementsAvail;

        // Token: 0x04000142 RID: 322
        public float playerRating;

        // Token: 0x04000143 RID: 323
        public uint lastPlayerMission;

        // Token: 0x04000144 RID: 324
        public BmsStructs.TeamStatus currentStats;

        // Token: 0x04000145 RID: 325
        public BmsStructs.TeamStatus startStats;

        // Token: 0x04000146 RID: 326
        public short reinforcement;

        // Token: 0x04000147 RID: 327
        public BmsStructs.BmsId[] bonusObjs;

        // Token: 0x04000148 RID: 328
        public uint[] bonusTime;

        // Token: 0x04000149 RID: 329
        public byte[] objtype_priority;

        // Token: 0x0400014A RID: 330
        public byte[] unittype_priority;

        // Token: 0x0400014B RID: 331
        public byte[] mission_priority;

        // Token: 0x0400014C RID: 332
        public uint attackTime;

        // Token: 0x0400014D RID: 333
        public byte offensiveLoss;

        // Token: 0x0400014E RID: 334
        public byte[] max_vehicle;

        // Token: 0x0400014F RID: 335
        public byte teamFlag;

        // Token: 0x04000150 RID: 336
        public byte teamColor;

        // Token: 0x04000151 RID: 337
        public byte equipment;

        // Token: 0x04000152 RID: 338
        public string name;

        // Token: 0x04000153 RID: 339
        public string teamMotto;

        // Token: 0x04000154 RID: 340
        public BmsStructs.TeamGndActionType groundAction;

        // Token: 0x04000155 RID: 341
        public BmsStructs.TeamAirActionType defensiveAirAction;

        // Token: 0x04000156 RID: 342
        public BmsStructs.TeamAirActionType offensiveAirAction;
    }
}
