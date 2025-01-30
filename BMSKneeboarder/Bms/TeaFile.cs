using BMSKneeboarder.Bms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms
{
    public class TeaFile
    {
        // Token: 0x06000133 RID: 307 RVA: 0x00025667 File Offset: 0x00023867
        protected TeaFile()
        {
            this._version = 0;
        }

        // Token: 0x06000134 RID: 308 RVA: 0x00025678 File Offset: 0x00023878
        public TeaFile(byte[] bytes, int version)
            : this()
        {
            this._version = version;
            int num = 0;
            this.numTeams = BitConverter.ToInt16(bytes, num);
            checked
            {
                num += 2;
                if (this.numTeams > 8)
                {
                    this.numTeams = 8;
                }
                //Array.Resize<Team>(ref this.teams, (int)this.numTeams);
                Array.Resize<AirTaskingManager>(ref this.airTaskingManagers, (int)this.numTeams);
                Array.Resize<GroundTaskingManager>(ref this.groundTaskingManagers, (int)this.numTeams);
                Array.Resize<NavalTaskingManager>(ref this.navalTaskingManagers, (int)this.numTeams);
                int num2 = (int)(this.numTeams - 1);
                for (int i = 0; i <= num2; i++)
                {
                    Team team = new Team(bytes, ref num, version);
                    Teams.Add(team);
                    this.airTaskingManagers[i] = new AirTaskingManager(bytes, ref num, version);
                    this.groundTaskingManagers[i] = new GroundTaskingManager(bytes, ref num, version);
                    this.navalTaskingManagers[i] = new NavalTaskingManager(bytes, ref num, version);
                }
            }
        }

        // Token: 0x04000126 RID: 294
        public short numTeams;

        // Token: 0x04000127 RID: 295
        public List<Team> Teams { get; set; } = new List<Team>();

        // Token: 0x04000128 RID: 296
        public AirTaskingManager[] airTaskingManagers;

        // Token: 0x04000129 RID: 297
        public GroundTaskingManager[] groundTaskingManagers;

        // Token: 0x0400012A RID: 298
        public NavalTaskingManager[] navalTaskingManagers;

        // Token: 0x0400012B RID: 299
        protected int _version;
    }
}
