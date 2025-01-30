using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BMSKneeboarder.Bms.Model
{
    public class Package : AirUnit, ICloneable
    {
        // Token: 0x060000E9 RID: 233 RVA: 0x0001AB65 File Offset: 0x00018D65
        protected Package()
        {
        }

        // Token: 0x060000EA RID: 234 RVA: 0x0001D800 File Offset: 0x0001BA00
        public Package(byte[] bytes, ref int offset, int version)
            : base(bytes, ref offset, version)
        {
            this.elements = bytes[offset];
            checked
            {
                offset++;
                this.element = new BmsStructs.BmsId[(int)(this.elements - 1 + 1)];
                int num = (int)(this.elements - 1);
                for (int i = 0; i <= num; i++)
                {
                    BmsStructs.BmsId vu_ID = default(BmsStructs.BmsId);
                    vu_ID.num = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    vu_ID.creator = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.element[i] = vu_ID;
                }
                this.interceptor = default(BmsStructs.BmsId);
                this.interceptor.num = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.interceptor.creator = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                if (version >= 7)
                {
                    this.awacs = default(BmsStructs.BmsId);
                    this.awacs.num = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.awacs.creator = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.jstar = default(BmsStructs.BmsId);
                    this.jstar.num = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.jstar.creator = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.ecm = default(BmsStructs.BmsId);
                    this.ecm.num = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.ecm.creator = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.tanker = default(BmsStructs.BmsId);
                    this.tanker.num = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.tanker.creator = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                }
                this.wait_cycles = bytes[offset];
                offset++;
                this.mis_request = default(BmsStructs.MissionRequest);
                if (base.Final & (this.wait_cycles == 0))
                {
                    this.requests = BitConverter.ToInt16(bytes, offset);
                    offset += 2;
                    if (version < 35)
                    {
                        this.threat_stats = BitConverter.ToInt16(bytes, offset);
                        offset += 2;
                    }
                    this.responses = BitConverter.ToInt16(bytes, offset);
                    offset += 2;
                    this.mis_request.mission = bytes[offset];
                    offset++;
                    this.mis_request.aircraft = bytes[offset];
                    offset++;
                    this.mis_request.context = bytes[offset];
                    offset++;
                    this.mis_request.roe_check = bytes[offset];
                    offset++;
                    this.mis_request.requesterID = default(BmsStructs.BmsId);
                    this.mis_request.requesterID.num = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.mis_request.requesterID.creator = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.mis_request.targetID = default(BmsStructs.BmsId);
                    this.mis_request.targetID.num = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    this.mis_request.targetID.creator = BitConverter.ToUInt32(bytes, offset);
                    offset += 4;
                    if (version >= 26)
                    {
                        this.mis_request.tot = BitConverter.ToUInt32(bytes, offset);
                        offset += 4;
                    }
                    else if (version >= 16)
                    {
                        this.mis_request.tot = BitConverter.ToUInt32(bytes, offset);
                        offset += 4;
                    }
                    if (version >= 35)
                    {
                        this.mis_request.action_type = bytes[offset];
                        offset++;
                    }
                    else
                    {
                        this.mis_request.action_type = 0;
                    }
                    if (version >= 41)
                    {
                        this.mis_request.priority = BitConverter.ToInt16(bytes, offset);
                        offset += 2;
                    }
                    else
                    {
                        this.mis_request.priority = 1;
                    }
                    this.package_flags = 0U;
                    return;
                }
                this.flights = bytes[offset];
                offset++;
                this.wait_for = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.iax = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.iay = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.eax = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.eay = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.bpx = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.bpy = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.tpx = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.tpy = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.takeoff = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.tp_time = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.package_flags = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.caps = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.requests = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                if (version < 35)
                {
                    this.threat_stats = BitConverter.ToInt16(bytes, offset);
                    offset += 2;
                }
                this.responses = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.num_ingress_waypoints = bytes[offset];
                offset++;
                this.ingress_waypoints = new Waypoint[(int)(this.num_ingress_waypoints - 1 + 1)];
                int num2 = (int)(this.num_ingress_waypoints - 1);
                for (int j = 0; j <= num2; j++)
                {
                    this.ingress_waypoints[j] = new Waypoint(bytes, ref offset, version);
                }
                this.num_egress_waypoints = bytes[offset];
                offset++;
                this.egress_waypoints = new Waypoint[(int)(this.num_egress_waypoints - 1 + 1)];
                int num3 = (int)(this.num_egress_waypoints - 1);
                for (int k = 0; k <= num3; k++)
                {
                    this.egress_waypoints[k] = new Waypoint(bytes, ref offset, version);
                }
                this.mis_request.requesterID = default(BmsStructs.BmsId);
                this.mis_request.requesterID.num = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.mis_request.requesterID.creator = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.mis_request.targetID = default(BmsStructs.BmsId);
                this.mis_request.targetID.num = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.mis_request.targetID.creator = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.mis_request.secondaryID = default(BmsStructs.BmsId);
                this.mis_request.secondaryID.num = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.mis_request.secondaryID.creator = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.mis_request.pakID = default(BmsStructs.BmsId);
                this.mis_request.pakID.num = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.mis_request.pakID.creator = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.mis_request.who = bytes[offset];
                offset++;
                this.mis_request.vs = bytes[offset];
                offset++;
                offset += 2;
                this.mis_request.tot = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.mis_request.tx = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.mis_request.ty = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.mis_request.flags = BitConverter.ToUInt32(bytes, offset);
                offset += 4;
                this.mis_request.caps = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.mis_request.target_num = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.mis_request.speed = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.mis_request.match_strength = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.mis_request.priority = BitConverter.ToInt16(bytes, offset);
                offset += 2;
                this.mis_request.tot_type = bytes[offset];
                offset++;
                this.mis_request.action_type = bytes[offset];
                offset++;
                this.mis_request.mission = bytes[offset];
                offset++;
                this.mis_request.aircraft = bytes[offset];
                offset++;
                this.mis_request.context = bytes[offset];
                offset++;
                this.mis_request.roe_check = bytes[offset];
                offset++;
                if (version >= 35)
                {
                    this.mis_request.delayed = bytes[offset];
                    offset++;
                    this.mis_request.start_block = bytes[offset];
                    offset++;
                    this.mis_request.final_block = bytes[offset];
                    offset++;
                    this.mis_request.slots = new byte[4];
                    int num4 = 0;
                    do
                    {
                        this.mis_request.slots[num4] = bytes[offset];
                        offset++;
                        num4++;
                    }
                    while (num4 <= 3);
                    this.mis_request.min_to = bytes[offset];
                    offset++;
                    this.mis_request.max_to = bytes[offset];
                    offset++;
                    offset += 3;
                }
            }
        }

        // Token: 0x060000EB RID: 235 RVA: 0x0001E12C File Offset: 0x0001C32C
        public object Clone()
        {
            Package package = new Package();
            package.awacs = this.awacs;
            package.baseFlags = this.baseFlags;
            package.bpx = this.bpx;
            package.bpy = this.bpy;
            package.campId = this.campId;
            package.caps = this.caps;
            package.cargo_id = this.cargo_id;
            package.current_wp = this.current_wp;
            package.dest_x = this.dest_x;
            package.dest_y = this.dest_y;
            package.eax = this.eax;
            package.eay = this.eay;
            package.ecm = this.ecm;
            package.egress_waypoints = this.egress_waypoints;
            package.element = this.element;
            package.elements = this.elements;
            package.entityType = this.entityType;
            package.flights = this.flights;
            package.iax = this.iax;
            package.iay = this.iay;
            package.id = this.id;
            package.ingress_waypoints = this.ingress_waypoints;
            package.interceptor = this.interceptor;
            package.jstar = this.jstar;
            package.last_check = this.last_check;
            package.losses = this.losses;
            package.mis_request = this.mis_request;
            package.moved = this.moved;
            package.name_id = this.name_id;
            package.num_egress_waypoints = this.num_egress_waypoints;
            package.num_ingress_waypoints = this.num_ingress_waypoints;
            package.numWaypoints = this.numWaypoints;
            package.owner = this.owner;
            package.package_flags = this.package_flags;
            package.reinforcement = this.reinforcement;
            package.requests = this.requests;
            package.responses = this.responses;
            package.roster = this.roster;
            package.spotted = this.spotted;
            package.spotTime = this.spotTime;
            package.tactic = this.tactic;
            package.takeoff = this.takeoff;
            package.tanker = this.tanker;
            package.target_id = this.target_id;
            package.threat_stats = this.threat_stats;
            package.tp_time = this.tp_time;
            package.tpx = this.tpx;
            package.tpy = this.tpy;
            package.unit_flags = this.unit_flags;
            package.wait_cycles = this.wait_cycles;
            package.wait_for = this.wait_for;
            package.waypoints = this.waypoints;
            package.x = this.x;
            package.y = this.y;
            package.z = this.z;
            return package;
        }

        // Token: 0x040000E2 RID: 226
        public byte elements;

        // Token: 0x040000E3 RID: 227
        public BmsStructs.BmsId[] element;

        // Token: 0x040000E4 RID: 228
        public BmsStructs.BmsId interceptor;

        // Token: 0x040000E5 RID: 229
        public BmsStructs.BmsId awacs;

        // Token: 0x040000E6 RID: 230
        public BmsStructs.BmsId jstar;

        // Token: 0x040000E7 RID: 231
        public BmsStructs.BmsId ecm;

        // Token: 0x040000E8 RID: 232
        public BmsStructs.BmsId tanker;

        // Token: 0x040000E9 RID: 233
        public byte wait_cycles;

        // Token: 0x040000EA RID: 234
        public byte flights;

        // Token: 0x040000EB RID: 235
        public short wait_for;

        // Token: 0x040000EC RID: 236
        public short iax;

        // Token: 0x040000ED RID: 237
        public short iay;

        // Token: 0x040000EE RID: 238
        public short eax;

        // Token: 0x040000EF RID: 239
        public short eay;

        // Token: 0x040000F0 RID: 240
        public short bpx;

        // Token: 0x040000F1 RID: 241
        public short bpy;

        // Token: 0x040000F2 RID: 242
        public short tpx;

        // Token: 0x040000F3 RID: 243
        public short tpy;

        // Token: 0x040000F4 RID: 244
        public uint takeoff;

        // Token: 0x040000F5 RID: 245
        public uint tp_time;

        // Token: 0x040000F6 RID: 246
        public uint package_flags;

        // Token: 0x040000F7 RID: 247
        public short caps;

        // Token: 0x040000F8 RID: 248
        public short requests;

        // Token: 0x040000F9 RID: 249
        public short threat_stats;

        // Token: 0x040000FA RID: 250
        public short responses;

        // Token: 0x040000FB RID: 251
        public byte num_ingress_waypoints;

        // Token: 0x040000FC RID: 252
        public Waypoint[] ingress_waypoints;

        // Token: 0x040000FD RID: 253
        public byte num_egress_waypoints;

        // Token: 0x040000FE RID: 254
        public Waypoint[] egress_waypoints;

        // Token: 0x040000FF RID: 255
        public BmsStructs.MissionRequest mis_request;
    }
}
