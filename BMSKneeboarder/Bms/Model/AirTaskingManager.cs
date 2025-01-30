using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms.Model
{
    public class AirTaskingManager : CampaignManager
    {
        // Token: 0x06000018 RID: 24 RVA: 0x00002A48 File Offset: 0x00000C48
        protected AirTaskingManager()
        {
        }

        // Token: 0x06000019 RID: 25 RVA: 0x00002A50 File Offset: 0x00000C50
        public AirTaskingManager(byte[] bytes, ref int offset, int version)
            : base(bytes, ref offset, version)
        {
            this.flags = BitConverter.ToInt16(bytes, offset);
            checked
            {
                offset += 2;
                if (version >= 28)
                {
                    if (version >= 63)
                    {
                        this.averageCAStrength = BitConverter.ToInt16(bytes, offset);
                        offset += 2;
                    }
                    this.averageCAMissions = BitConverter.ToInt16(bytes, offset);
                    offset += 2;
                    this.sampleCycles = bytes[offset];
                    offset++;
                }
                if (version < 63)
                {
                    this.averageCAMissions = 500;
                    this.averageCAStrength = 500;
                    this.sampleCycles = 10;
                }
                this.numAirbases = bytes[offset];
                offset++;
                Array.Resize<ATMAirbase>(ref this.airbases, (int)this.numAirbases);
                int num = (int)(this.numAirbases - 1);
                for (int i = 0; i <= num; i++)
                {
                    this.airbases[i] = new ATMAirbase(bytes, ref offset, version);
                }
                this.cycle = bytes[offset];
                offset++;
                this.numMissionRequests = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                Array.Resize<BmsStructs.MissionRequest>(ref this.missionRequests, (int)this.numMissionRequests);
                if (version < 35)
                {
                    int num2 = (int)(this.numMissionRequests - 1);
                    for (int j = 0; j <= num2; j++)
                    {
                        offset += 64;
                    }
                    return;
                }
                int num3 = (int)(this.numMissionRequests - 1);
                for (int k = 0; k <= num3; k++)
                {
                    BmsStructs.MissionRequest missionRequest = default(BmsStructs.MissionRequest);
                    missionRequest.requesterID.num = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    missionRequest.requesterID.creator = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    missionRequest.targetID.num = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    missionRequest.targetID.creator = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    missionRequest.secondaryID.num = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    missionRequest.secondaryID.creator = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    missionRequest.pakID.num = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    missionRequest.pakID.creator = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    missionRequest.who = bytes[offset];
                    offset++;
                    missionRequest.vs = bytes[offset];
                    offset++;
                    offset += 2;
                    missionRequest.tot = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    missionRequest.tx = BitConverter.ToInt16(bytes, offset);
                    offset += 2;
                    missionRequest.ty = BitConverter.ToInt16(bytes, offset);
                    offset += 2;
                    missionRequest.flags = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    missionRequest.caps = BitConverter.ToInt16(bytes, offset);
                    offset += 2;
                    missionRequest.target_num = BitConverter.ToInt16(bytes, offset);
                    offset += 2;
                    missionRequest.speed = BitConverter.ToInt16(bytes, offset);
                    offset += 2;
                    missionRequest.match_strength = BitConverter.ToInt16(bytes, offset);
                    offset += 2;
                    missionRequest.priority = BitConverter.ToInt16(bytes, offset);
                    offset += 2;
                    missionRequest.tot_type = bytes[offset];
                    offset++;
                    missionRequest.action_type = bytes[offset];
                    offset++;
                    missionRequest.mission = bytes[offset];
                    offset++;
                    missionRequest.aircraft = bytes[offset];
                    offset++;
                    missionRequest.context = bytes[offset];
                    offset++;
                    missionRequest.roe_check = bytes[offset];
                    offset++;
                    missionRequest.delayed = bytes[offset];
                    offset++;
                    missionRequest.start_block = bytes[offset];
                    offset++;
                    missionRequest.final_block = bytes[offset];
                    offset++;
                    Array.Resize<byte>(ref missionRequest.slots, 4);
                    int num4 = 0;
                    do
                    {
                        missionRequest.slots[num4] = bytes[offset];
                        offset++;
                        num4++;
                    }
                    while (num4 <= 3);
                    missionRequest.min_to = bytes[offset];
                    offset++;
                    missionRequest.max_to = bytes[offset];
                    offset++;
                    offset += 3;
                    this.missionRequests[k] = missionRequest;
                }
            }
        }

        // Token: 0x04000008 RID: 8
        public short flags;

        // Token: 0x04000009 RID: 9
        public short averageCAStrength;

        // Token: 0x0400000A RID: 10
        public short averageCAMissions;

        // Token: 0x0400000B RID: 11
        public byte sampleCycles;

        // Token: 0x0400000C RID: 12
        public byte numAirbases;

        // Token: 0x0400000D RID: 13
        public ATMAirbase[] airbases;

        // Token: 0x0400000E RID: 14
        public byte cycle;

        // Token: 0x0400000F RID: 15
        public short numMissionRequests;

        // Token: 0x04000010 RID: 16
        public BmsStructs.MissionRequest[] missionRequests;
    }
}
