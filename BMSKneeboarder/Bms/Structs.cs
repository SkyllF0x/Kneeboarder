using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSKneeboarder.Bms
{
    public static class BmsStructs
    {
        public struct Vector3
        {
            public double x;

            public double y;

            public double z;
        }
        public struct PilotInfoClass
        {
            // Token: 0x040001B3 RID: 435
            public short usage;

            // Token: 0x040001B4 RID: 436
            public byte voice_id;

            // Token: 0x040001B5 RID: 437
            public byte photo_id;
        }

        // Token: 0x02000056 RID: 86
        public struct MissionRequest
        {
            // Token: 0x040001B6 RID: 438
            public BmsId requesterID;

            // Token: 0x040001B7 RID: 439
            public BmsId targetID;

            // Token: 0x040001B8 RID: 440
            public BmsId secondaryID;

            // Token: 0x040001B9 RID: 441
            public BmsId pakID;

            // Token: 0x040001BA RID: 442
            public byte who;

            // Token: 0x040001BB RID: 443
            public byte vs;

            // Token: 0x040001BC RID: 444
            public uint tot;

            // Token: 0x040001BD RID: 445
            public short tx;

            // Token: 0x040001BE RID: 446
            public short ty;

            // Token: 0x040001BF RID: 447
            public uint flags;

            // Token: 0x040001C0 RID: 448
            public short caps;

            // Token: 0x040001C1 RID: 449
            public short target_num;

            // Token: 0x040001C2 RID: 450
            public short speed;

            // Token: 0x040001C3 RID: 451
            public short match_strength;

            // Token: 0x040001C4 RID: 452
            public short priority;

            // Token: 0x040001C5 RID: 453
            public byte tot_type;

            // Token: 0x040001C6 RID: 454
            public byte action_type;

            // Token: 0x040001C7 RID: 455
            public byte mission;

            // Token: 0x040001C8 RID: 456
            public byte aircraft;

            // Token: 0x040001C9 RID: 457
            public byte context;

            // Token: 0x040001CA RID: 458
            public byte roe_check;

            // Token: 0x040001CB RID: 459
            public byte delayed;

            // Token: 0x040001CC RID: 460
            public byte start_block;

            // Token: 0x040001CD RID: 461
            public byte final_block;

            // Token: 0x040001CE RID: 462
            public byte[] slots;

            // Token: 0x040001CF RID: 463
            public byte min_to;

            // Token: 0x040001D0 RID: 464
            public byte max_to;
        }

        public struct BmsId
        {
            public uint num;

            public uint creator;

            public static bool operator ==(BmsId c1, BmsId c2)
            {
                return c1.num == c2.num && c1.creator == c2.creator;
            }

            public static bool operator !=(BmsId c1, BmsId c2)
            {
                return c1.num != c2.num || c1.creator != c2.creator;
            }
        }

        // Token: 0x02000058 RID: 88
        public struct vector
        {
            // Token: 0x040001D3 RID: 467
            public float x;

            // Token: 0x040001D4 RID: 468
            public float y;

            // Token: 0x040001D5 RID: 469
            public float z;
        }

        // Token: 0x02000059 RID: 89
        public struct CampObjectiveLinkDataType
        {
            // Token: 0x040001D6 RID: 470
            public byte[] costs;

            // Token: 0x040001D7 RID: 471
            public BmsId id;
        }

        // Token: 0x0200005A RID: 90
        public struct LoadoutStruct
        {
            // Token: 0x040001D8 RID: 472
            public ushort[] WeaponID;

            // Token: 0x040001D9 RID: 473
            public byte[] WeaponCount;
        }

        // Token: 0x0200005B RID: 91
        public struct LoadoutArray
        {
            // Token: 0x040001DA RID: 474
            public LoadoutStruct[] Stores;
        }

        // Token: 0x0200005C RID: 92


        // Token: 0x0200005D RID: 93
        public struct BmsRackGroup
        {
            // Token: 0x040001DD RID: 477
            public string groupname;

            // Token: 0x040001DE RID: 478
            public BmsPylon[] pylonList;
        }

        // Token: 0x0200005E RID: 94


        // Token: 0x0200005F RID: 95


        // Token: 0x02000060 RID: 96
        public struct BmsPylon
        {
            // Token: 0x040001EB RID: 491
            public string[] rackNameList;

            // Token: 0x040001EC RID: 492
            public int pylonCT;

            // Token: 0x040001ED RID: 493
            public string mnemonic;

            // Token: 0x040001EE RID: 494
            public string pylonjettmodes;
        }

        // Token: 0x02000061 RID: 97
        public struct VuEntityType
        {
            // Token: 0x040001EF RID: 495
            public ushort id_;

            // Token: 0x040001F0 RID: 496
            public ushort collisionType_;

            // Token: 0x040001F1 RID: 497
            public float collisionRadius_;

            // Token: 0x040001F2 RID: 498
            public byte[] classInfo_;

            // Token: 0x040001F3 RID: 499
            public byte FType_;

            // Token: 0x040001F4 RID: 500
            public byte Unknown_;

            // Token: 0x040001F5 RID: 501
            public ulong UpdateRate_;

            // Token: 0x040001F6 RID: 502
            public ulong UpdateTolerance_;

            // Token: 0x040001F7 RID: 503
            public float FineUpdateRange_;

            // Token: 0x040001F8 RID: 504
            public float FineUpdateForceRange_;

            // Token: 0x040001F9 RID: 505
            public float FineUpdateMultiplier_;

            // Token: 0x040001FA RID: 506
            public float DamageSeed_;

            // Token: 0x040001FB RID: 507
            public int Hitpoints_;

            // Token: 0x040001FC RID: 508
            public ushort majorRevisionNumber_;

            // Token: 0x040001FD RID: 509
            public ushort minorRevisionNumber_;

            // Token: 0x040001FE RID: 510
            public ushort CreatePriority_;

            // Token: 0x040001FF RID: 511
            public byte managementDomain_;

            // Token: 0x04000200 RID: 512
            public bool transferable_;

            // Token: 0x04000201 RID: 513
            public bool private_;

            // Token: 0x04000202 RID: 514
            public bool tangible_;

            // Token: 0x04000203 RID: 515
            public bool collidable_;

            // Token: 0x04000204 RID: 516
            public bool global_;

            // Token: 0x04000205 RID: 517
            public bool persistent_;

            // Token: 0x04000206 RID: 518
            public short GrphNormal_;

            // Token: 0x04000207 RID: 519
            public short GrphRepaired_;

            // Token: 0x04000208 RID: 520
            public short GrphDamaged_;

            // Token: 0x04000209 RID: 521
            public short GrphDestroyed_;

            // Token: 0x0400020A RID: 522
            public short GrphLeftDestroyed_;

            // Token: 0x0400020B RID: 523
            public short GrphRightDestroyed_;

            // Token: 0x0400020C RID: 524
            public short GrphBothDestroyed_;
        }

        // Token: 0x02000062 RID: 98
        public struct PrimaryObjective
        {
            // Token: 0x0400020D RID: 525
            public BmsId id;

            // Token: 0x0400020E RID: 526
            public short[] priority;

            // Token: 0x0400020F RID: 527
            public byte[] Flags;

            // Token: 0x04000210 RID: 528
            public short[] extra;
        }

        // Token: 0x02000063 RID: 99
        public struct CampEvent
        {
            // Token: 0x04000211 RID: 529
            public short id;

            // Token: 0x04000212 RID: 530
            public short flags;
        }

        // Token: 0x02000064 RID: 100
        public struct EntityClassType
        {
            // Token: 0x04000213 RID: 531
            public VuEntityType vuClassData;

            // Token: 0x04000214 RID: 532
            public short[] visType;

            // Token: 0x04000215 RID: 533
            public short vehicleDataIndex;

            // Token: 0x04000216 RID: 534
            public short dataType;

            // Token: 0x04000217 RID: 535
            public short dataPtr;
        }

        // Token: 0x02000065 RID: 101
        public struct SimACDefType
        {
            // Token: 0x04000218 RID: 536
            public int combatClass;

            // Token: 0x04000219 RID: 537
            public int airframeIdx;

            // Token: 0x0400021A RID: 538
            public int signatureIdx;

            // Token: 0x0400021B RID: 539
            public int[] sensorType;

            // Token: 0x0400021C RID: 540
            public int[] sensorIdx;
        }

        // Token: 0x02000066 RID: 102
        public struct DirtyDataClassType
        {
            // Token: 0x0400021D RID: 541
            public long Priority;
        }

        // Token: 0x02000067 RID: 103
        public struct FeatureClassDataType
        {
            // Token: 0x0400021E RID: 542
            public short Index;

            // Token: 0x0400021F RID: 543
            public short RepairTime;

            // Token: 0x04000220 RID: 544
            public byte Priority;

            // Token: 0x04000221 RID: 545
            public ushort Flags;

            // Token: 0x04000222 RID: 546
            public char[] Name;

            // Token: 0x04000223 RID: 547
            public short HitPoints;

            // Token: 0x04000224 RID: 548
            public short Height;

            // Token: 0x04000225 RID: 549
            public float Angle;

            // Token: 0x04000226 RID: 550
            public short RadarType;

            // Token: 0x04000227 RID: 551
            public byte[] Detection;

            // Token: 0x04000228 RID: 552
            public byte[] DamageMod;
        }

        // Token: 0x02000068 RID: 104
        public struct FeatureEntry
        {
            // Token: 0x04000229 RID: 553
            public short Index;

            // Token: 0x0400022A RID: 554
            public ushort Flags;

            // Token: 0x0400022B RID: 555
            public byte[] eClass;

            // Token: 0x0400022C RID: 556
            public byte Value;

            // Token: 0x0400022D RID: 557
            public byte Value2;

            // Token: 0x0400022E RID: 558
            public vector Offset;

            // Token: 0x0400022F RID: 559
            public float Facing;

            // Token: 0x04000230 RID: 560
            public short unk1;

            // Token: 0x04000231 RID: 561
            public short unk2;
        }

        // Token: 0x02000069 RID: 105
        public struct ItemCountVec
        {
            // Token: 0x04000232 RID: 562
            public int First;

            // Token: 0x04000233 RID: 563
            public int Count;
        }

        // Token: 0x0200006A RID: 106
        public struct WeaponListDataType
        {
            // Token: 0x04000234 RID: 564
            public char[] Name;

            // Token: 0x04000235 RID: 565
            public short[] WeaponID;

            // Token: 0x04000236 RID: 566
            public byte[] Quantity;
        }

        // Token: 0x0200006B RID: 107
        public struct IRDataType
        {
            // Token: 0x04000237 RID: 567
            public string Name;

            // Token: 0x04000238 RID: 568
            public float NominalRange;

            // Token: 0x04000239 RID: 569
            public float FOVHalfAngle;

            // Token: 0x0400023A RID: 570
            public float GimbalLimitHalfAngle;

            // Token: 0x0400023B RID: 571
            public float GroundFactor;

            // Token: 0x0400023C RID: 572
            public float FlareChance;
        }

        // Token: 0x0200006C RID: 108
        public class PtHeaderDataType
        {
            // Token: 0x0400023D RID: 573
            public short objID;

            // Token: 0x0400023E RID: 574
            public byte type;

            // Token: 0x0400023F RID: 575
            public byte count;

            // Token: 0x04000240 RID: 576
            public byte[] features;

            // Token: 0x04000241 RID: 577
            public float data;

            // Token: 0x04000242 RID: 578
            public float sinHeading;

            // Token: 0x04000243 RID: 579
            public float cosHeading;

            // Token: 0x04000244 RID: 580
            public int first;

            // Token: 0x04000245 RID: 581
            public short texIdx;

            // Token: 0x04000246 RID: 582
            public byte runwayNum;

            // Token: 0x04000247 RID: 583
            public sbyte ltrt;

            // Token: 0x04000248 RID: 584
            public short nextHeader;
        }

        // Token: 0x0200006D RID: 109
        public struct PtDataTypeExtended
        {
            // Token: 0x04000249 RID: 585
            public float xOffset;

            // Token: 0x0400024A RID: 586
            public float yOffset;

            // Token: 0x0400024B RID: 587
            public float zOffset;

            // Token: 0x0400024C RID: 588
            public float maxheight;

            // Token: 0x0400024D RID: 589
            public float maxwidth;

            // Token: 0x0400024E RID: 590
            public float maxlength;

            // Token: 0x0400024F RID: 591
            public byte type;

            // Token: 0x04000250 RID: 592
            public byte flags;

            // Token: 0x04000251 RID: 593
            public byte rootIdx;

            // Token: 0x04000252 RID: 594
            public byte branchIdx;

            // Token: 0x04000253 RID: 595
            public float heading;

            // Token: 0x04000254 RID: 596
            public int branchNbr;

            // Token: 0x04000255 RID: 597
            public int taxiwayLetter;

            // Token: 0x04000256 RID: 598
            public int runwayNumber;

            // Token: 0x04000257 RID: 599
            public int runwaySide;

            // Token: 0x04000258 RID: 600
            public int parkingPointGroup;

            // Token: 0x04000259 RID: 601
            public bool isCrossingPoint;
        }

        // Token: 0x0200006E RID: 110
        public struct PtDataType
        {
            // Token: 0x0400025A RID: 602
            public float xOffset;

            // Token: 0x0400025B RID: 603
            public float yOffset;

            // Token: 0x0400025C RID: 604
            public byte type;

            // Token: 0x0400025D RID: 605
            public byte flags;
        }

        // Token: 0x0200006F RID: 111
        public class ObjClassDataType
        {
            // Token: 0x0400025E RID: 606
            public short Index;

            // Token: 0x0400025F RID: 607
            public char[] Name;

            // Token: 0x04000260 RID: 608
            public short DataRate;

            // Token: 0x04000261 RID: 609
            public short DeagDistance;

            // Token: 0x04000262 RID: 610
            public short PtDataIndex;

            // Token: 0x04000263 RID: 611
            public byte[] Detection;

            // Token: 0x04000264 RID: 612
            public byte[] DamageMod;

            // Token: 0x04000265 RID: 613
            public short IconIndex;

            // Token: 0x04000266 RID: 614
            public byte Features;

            // Token: 0x04000267 RID: 615
            public byte RadarFeature;

            // Token: 0x04000268 RID: 616
            public int FirstFeature;
        }

        // Token: 0x02000070 RID: 112
        public struct CampObjData
        {
            // Token: 0x04000269 RID: 617
            public int CampId;

            // Token: 0x0400026A RID: 618
            public string CampName;

            // Token: 0x0400026B RID: 619
            public int OcdIndex;

            // Token: 0x0400026C RID: 620
            public float Heading;

            // Token: 0x0400026D RID: 621
            public double PositionX;

            // Token: 0x0400026E RID: 622
            public double PositionY;

            // Token: 0x0400026F RID: 623
            public float PositionZ;
        }

        // Token: 0x02000071 RID: 113
        public struct RadarDataType
        {
            // Token: 0x04000270 RID: 624
            public string Name;

            // Token: 0x04000271 RID: 625
            public int RWRsound;

            // Token: 0x04000272 RID: 626
            public short RWRsymbol;

            // Token: 0x04000273 RID: 627
            public short RDRDataInd;

            // Token: 0x04000274 RID: 628
            public float[] Lethality;

            // Token: 0x04000275 RID: 629
            public float NominalRange;

            // Token: 0x04000276 RID: 630
            public float BeamHalfAngle;

            // Token: 0x04000277 RID: 631
            public float ScanHalfAngle;

            // Token: 0x04000278 RID: 632
            public float SweepRate;

            // Token: 0x04000279 RID: 633
            public uint CoastTime;

            // Token: 0x0400027A RID: 634
            public float LookDownPenalty;

            // Token: 0x0400027B RID: 635
            public float JammingPenalty;

            // Token: 0x0400027C RID: 636
            public float NotchPenalty;

            // Token: 0x0400027D RID: 637
            public float NotchSpeed;

            // Token: 0x0400027E RID: 638
            public float ChaffChance;

            // Token: 0x0400027F RID: 639
            public short flag;
        }

        // Token: 0x02000072 RID: 114
        public struct RocketClassDataType
        {
            // Token: 0x04000280 RID: 640
            public short weaponId;

            // Token: 0x04000281 RID: 641
            public short nweaponId;

            // Token: 0x04000282 RID: 642
            public short weaponCount;
        }

        // Token: 0x02000073 RID: 115
        public struct RwrDataType
        {
            // Token: 0x04000283 RID: 643
            public string Name;

            // Token: 0x04000284 RID: 644
            public float nominalRange;

            // Token: 0x04000285 RID: 645
            public float top;

            // Token: 0x04000286 RID: 646
            public float bottom;

            // Token: 0x04000287 RID: 647
            public float left;

            // Token: 0x04000288 RID: 648
            public float right;

            // Token: 0x04000289 RID: 649
            public short flag;
        }

        // Token: 0x02000074 RID: 116
        public struct SimWeaponDataType
        {
            // Token: 0x0400028A RID: 650
            public int flags;

            // Token: 0x0400028B RID: 651
            public float cd;

            // Token: 0x0400028C RID: 652
            public float weight;

            // Token: 0x0400028D RID: 653
            public float area;

            // Token: 0x0400028E RID: 654
            public float xEjection;

            // Token: 0x0400028F RID: 655
            public float yEjection;

            // Token: 0x04000290 RID: 656
            public float zEjection;

            // Token: 0x04000291 RID: 657
            public char[] mnemonic;

            // Token: 0x04000292 RID: 658
            public int weaponClass;

            // Token: 0x04000293 RID: 659
            public int domain;

            // Token: 0x04000294 RID: 660
            public int weaponType;

            // Token: 0x04000295 RID: 661
            public int dataIdx;
        }

        // Token: 0x02000075 RID: 117
        public struct SquadronStoresDataType
        {
            // Token: 0x04000296 RID: 662
            public byte[] Stores;

            // Token: 0x04000297 RID: 663
            public byte[] flags;

            // Token: 0x04000298 RID: 664
            public byte infiniteAG;

            // Token: 0x04000299 RID: 665
            public byte infiniteAA;

            // Token: 0x0400029A RID: 666
            public byte infiniteGun;

            // Token: 0x0400029B RID: 667
            public ushort[] InServiceStart;

            // Token: 0x0400029C RID: 668
            public ushort[] InServiceEnd;
        }

        // Token: 0x02000076 RID: 118
        public struct VehicleClassDataType
        {
            // Token: 0x0400029D RID: 669
            public short Index;

            // Token: 0x0400029E RID: 670
            public short HitPoints;

            // Token: 0x0400029F RID: 671
            public uint Flags;

            // Token: 0x040002A0 RID: 672
            public char[] Name;

            // Token: 0x040002A1 RID: 673
            public char[] NCTR;

            // Token: 0x040002A2 RID: 674
            public float RCSfactor;

            // Token: 0x040002A3 RID: 675
            public long MaxWt;

            // Token: 0x040002A4 RID: 676
            public long EmptyWt;

            // Token: 0x040002A5 RID: 677
            public long FuelWt;

            // Token: 0x040002A6 RID: 678
            public short FuelEcon;

            // Token: 0x040002A7 RID: 679
            public short EngineSound;

            // Token: 0x040002A8 RID: 680
            public short HighAlt;

            // Token: 0x040002A9 RID: 681
            public short LowAlt;

            // Token: 0x040002AA RID: 682
            public short CruiseAlt;

            // Token: 0x040002AB RID: 683
            public short MaxSpeed;

            // Token: 0x040002AC RID: 684
            public short RadarType;

            // Token: 0x040002AD RID: 685
            public short NumberOfPilots;

            // Token: 0x040002AE RID: 686
            public ushort RackFlags;

            // Token: 0x040002AF RID: 687
            public ushort VisibleFlags;

            // Token: 0x040002B0 RID: 688
            public byte CallsignIndex;

            // Token: 0x040002B1 RID: 689
            public byte CallsignSlots;

            // Token: 0x040002B2 RID: 690
            public byte[] HitChance;

            // Token: 0x040002B3 RID: 691
            public byte[] Strength;

            // Token: 0x040002B4 RID: 692
            public byte[] Range;

            // Token: 0x040002B5 RID: 693
            public byte[] Detection;

            // Token: 0x040002B6 RID: 694
            public short[] Weapon;

            // Token: 0x040002B7 RID: 695
            public byte[] Weapons;

            // Token: 0x040002B8 RID: 696
            public byte[] DamageMod;

            // Token: 0x040002B9 RID: 697
            public byte ptType;

            // Token: 0x040002BA RID: 698
            public string Description;

            // Token: 0x040002BB RID: 699
            public ushort InServiceStart;

            // Token: 0x040002BC RID: 700
            public ushort InServiceEnd;
        }

        // Token: 0x02000077 RID: 119
        public struct UnitClassDataType
        {
            // Token: 0x040002BD RID: 701
            public short Index;

            // Token: 0x040002BE RID: 702
            public int[] NumElements;

            // Token: 0x040002BF RID: 703
            public short[] VehicleType;

            // Token: 0x040002C0 RID: 704
            public byte[,] VehicleClass;

            // Token: 0x040002C1 RID: 705
            public short[] ElementFlags;

            // Token: 0x040002C2 RID: 706
            public string[] ElementName;

            // Token: 0x040002C3 RID: 707
            public short[] ElementTexSetIdx;

            // Token: 0x040002C4 RID: 708
            public string Description;

            // Token: 0x040002C5 RID: 709
            public ushort Flags;

            // Token: 0x040002C6 RID: 710
            public char[] Name;

            // Token: 0x040002C7 RID: 711
            public short MoveType;

            // Token: 0x040002C8 RID: 712
            public short MovementSpeed;

            // Token: 0x040002C9 RID: 713
            public short MaxRange;

            // Token: 0x040002CA RID: 714
            public long Fuel;

            // Token: 0x040002CB RID: 715
            public short FuelRate;

            // Token: 0x040002CC RID: 716
            public short PtDataIndex;

            // Token: 0x040002CD RID: 717
            public byte[] Scores;

            // Token: 0x040002CE RID: 718
            public byte Role;

            // Token: 0x040002CF RID: 719
            public byte[] HitChance;

            // Token: 0x040002D0 RID: 720
            public byte[] Strength;

            // Token: 0x040002D1 RID: 721
            public byte[] Range;

            // Token: 0x040002D2 RID: 722
            public float[] Detection;

            // Token: 0x040002D3 RID: 723
            public byte[] DamageMod;

            // Token: 0x040002D4 RID: 724
            public byte RadarVehicle;

            // Token: 0x040002D5 RID: 725
            public short SpecialIndex;

            // Token: 0x040002D6 RID: 726
            public short IconIndex;

            // Token: 0x040002D7 RID: 727
            public ushort InServiceStart;

            // Token: 0x040002D8 RID: 728
            public ushort InServiceEnd;
        }

        // Token: 0x02000078 RID: 120
        public struct VisualDataType
        {
            // Token: 0x040002D9 RID: 729
            public string Name;

            // Token: 0x040002DA RID: 730
            public float nominalRange;

            // Token: 0x040002DB RID: 731
            public float top;

            // Token: 0x040002DC RID: 732
            public float bottom;

            // Token: 0x040002DD RID: 733
            public float left;

            // Token: 0x040002DE RID: 734
            public float right;
        }

        // Token: 0x02000079 RID: 121
        public struct WeaponClassDataType
        {
            // Token: 0x040002DF RID: 735
            public short Index;

            // Token: 0x040002E0 RID: 736
            public ushort Strength;

            // Token: 0x040002E1 RID: 737
            public ushort FuelCapacity;

            // Token: 0x040002E2 RID: 738
            public ushort NumChaffs;

            // Token: 0x040002E3 RID: 739
            public ushort EcmStrength;

            // Token: 0x040002E4 RID: 740
            public ushort DamageType;

            // Token: 0x040002E5 RID: 741
            public float Range;

            // Token: 0x040002E6 RID: 742
            public ushort Flags;

            // Token: 0x040002E7 RID: 743
            public char[] Name;

            // Token: 0x040002E8 RID: 744
            public byte MinAlt;

            // Token: 0x040002E9 RID: 745
            public byte BulletDispersion;

            // Token: 0x040002EA RID: 746
            public byte[] HitChance;

            // Token: 0x040002EB RID: 747
            public byte FireRate;

            // Token: 0x040002EC RID: 748
            public byte Rariety;

            // Token: 0x040002ED RID: 749
            public ushort GuidanceFlags;

            // Token: 0x040002EE RID: 750
            public byte Collective;

            // Token: 0x040002EF RID: 751
            public byte BulletBits;

            // Token: 0x040002F0 RID: 752
            public byte BulletTTL;

            // Token: 0x040002F1 RID: 753
            public short BulletVelocity;

            // Token: 0x040002F2 RID: 754
            public short Rackgroup;

            // Token: 0x040002F3 RID: 755
            public ushort Weight;

            // Token: 0x040002F4 RID: 756
            public short DragIndex;

            // Token: 0x040002F5 RID: 757
            public ushort BlastRadius;

            // Token: 0x040002F6 RID: 758
            public ushort numFlares;

            // Token: 0x040002F7 RID: 759
            public short RadarType;

            // Token: 0x040002F8 RID: 760
            public short SimDataIdx;

            // Token: 0x040002F9 RID: 761
            public byte MaxAlt;

            // Token: 0x040002FA RID: 762
            public byte BulletRoundsPerSec;

            // Token: 0x040002FB RID: 763
            public short BombHeadCtIdx;

            // Token: 0x040002FC RID: 764
            public string Description;

            // Token: 0x040002FD RID: 765
            public ushort InServiceStart;

            // Token: 0x040002FE RID: 766
            public ushort InServiceEnd;
        }

        // Token: 0x0200007A RID: 122
        public struct Political
        {
            // Token: 0x040002FF RID: 767
            public short ID;
        }

        // Token: 0x0200007B RID: 123
        public struct Pilots
        {
            // Token: 0x04000300 RID: 768
            public short No;

            // Token: 0x04000301 RID: 769
            public string Name;

            // Token: 0x04000302 RID: 770
            public ushort Usage;

            // Token: 0x04000303 RID: 771
            public byte Photo;

            // Token: 0x04000304 RID: 772
            public byte Voice;
        }

        // Token: 0x0200007C RID: 124
        public struct Callsigns
        {
            // Token: 0x04000305 RID: 773
            public short No;

            // Token: 0x04000306 RID: 774
            public string Name;
        }

        // Token: 0x0200007D RID: 125
        public struct CampaignClassDataType
        {
            // Token: 0x04000307 RID: 775
            public uint CurrentTime;

            // Token: 0x04000308 RID: 776
            public uint StartTime;

            // Token: 0x04000309 RID: 777
            public uint TimeLimit;

            // Token: 0x0400030A RID: 778
            public int TE_VictoryPoints;

            // Token: 0x0400030B RID: 779
            public int TE_Type;

            // Token: 0x0400030C RID: 780
            public int TE_number_teams;

            // Token: 0x0400030D RID: 781
            public int[] TE_number_aircraft;

            // Token: 0x0400030E RID: 782
            public int[] TE_number_f16s;

            // Token: 0x0400030F RID: 783
            public int TE_team;

            // Token: 0x04000310 RID: 784
            public int[] TE_team_pts;

            // Token: 0x04000311 RID: 785
            public int TE_flags;

            // Token: 0x04000312 RID: 786
            public byte[] TeamInfo;

            // Token: 0x04000313 RID: 787
            public uint LastMajorEvent;

            // Token: 0x04000314 RID: 788
            public uint LastResupply;

            // Token: 0x04000315 RID: 789
            public uint LastRepair;

            // Token: 0x04000316 RID: 790
            public uint LastReinforcement;

            // Token: 0x04000317 RID: 791
            public short TimeStamp;

            // Token: 0x04000318 RID: 792
            public short Group;

            // Token: 0x04000319 RID: 793
            public short GroundRatio;

            // Token: 0x0400031A RID: 794
            public short AirRatio;

            // Token: 0x0400031B RID: 795
            public short AirDefenseRatio;

            // Token: 0x0400031C RID: 796
            public short NavalRatio;

            // Token: 0x0400031D RID: 797
            public short Brief;

            // Token: 0x0400031E RID: 798
            public short TheaterSizeX;

            // Token: 0x0400031F RID: 799
            public short TheaterSizeY;

            // Token: 0x04000320 RID: 800
            public byte CurrentDay;

            // Token: 0x04000321 RID: 801
            public byte ActiveTeam;

            // Token: 0x04000322 RID: 802
            public byte DayZero;

            // Token: 0x04000323 RID: 803
            public byte EndgameResult;

            // Token: 0x04000324 RID: 804
            public byte Situation;

            // Token: 0x04000325 RID: 805
            public byte EnemyAirExp;

            // Token: 0x04000326 RID: 806
            public byte EnemyADExp;

            // Token: 0x04000327 RID: 807
            public byte BullseyeName;

            // Token: 0x04000328 RID: 808
            public short BullseyeX;

            // Token: 0x04000329 RID: 809
            public short BullseyeY;

            // Token: 0x0400032A RID: 810
            public string TheaterName;

            // Token: 0x0400032B RID: 811
            public string Scenario;

            // Token: 0x0400032C RID: 812
            public string SaveFile;

            // Token: 0x0400032D RID: 813
            public string UIName;

            // Token: 0x0400032E RID: 814
            public BmsId PlayerSquadronID;

            // Token: 0x0400032F RID: 815
            public short NumRecentEventEntries;

            // Token: 0x04000330 RID: 816
            public EventNode[] RecentEventEntries;

            // Token: 0x04000331 RID: 817
            public short NumPriorityEventEntries;

            // Token: 0x04000332 RID: 818
            public EventNode[] PriorityEventEntries;

            // Token: 0x04000333 RID: 819
            public ushort CampMapSize;

            // Token: 0x04000334 RID: 820
            public byte[] CampMap;

            // Token: 0x04000335 RID: 821
            public short LastIndexNum;

            // Token: 0x04000336 RID: 822
            public short NumAvailableSquadrons;

            // Token: 0x04000337 RID: 823
            public SquadInfo[] SquadInfo;

            // Token: 0x04000338 RID: 824
            public byte Tempo;

            // Token: 0x04000339 RID: 825
            public uint CreatorIP;

            // Token: 0x0400033A RID: 826
            public uint CreationTime;

            // Token: 0x0400033B RID: 827
            public uint CreationRand;
        }

        // Token: 0x0200007E RID: 126
        public struct TeamStatus
        {
            // Token: 0x0400033C RID: 828
            public ushort airDefenseVehs;

            // Token: 0x0400033D RID: 829
            public ushort aircraft;

            // Token: 0x0400033E RID: 830
            public ushort groundVehs;

            // Token: 0x0400033F RID: 831
            public ushort ships;

            // Token: 0x04000340 RID: 832
            public ushort supply;

            // Token: 0x04000341 RID: 833
            public ushort fuel;

            // Token: 0x04000342 RID: 834
            public ushort airbases;

            // Token: 0x04000343 RID: 835
            public byte supplyLevel;

            // Token: 0x04000344 RID: 836
            public byte fuelLevel;
        }

        // Token: 0x0200007F RID: 127
        public struct TeamGndActionType
        {
            // Token: 0x04000345 RID: 837
            public uint actionTime;

            // Token: 0x04000346 RID: 838
            public uint actionTimeout;

            // Token: 0x04000347 RID: 839
            public BmsId actionObjective;

            // Token: 0x04000348 RID: 840
            public byte actionType;

            // Token: 0x04000349 RID: 841
            public byte actionTempo;

            // Token: 0x0400034A RID: 842
            public byte actionPoints;
        }

        // Token: 0x02000080 RID: 128
        public struct TeamAirActionType
        {
            // Token: 0x0400034B RID: 843
            public uint actionStartTime;

            // Token: 0x0400034C RID: 844
            public uint actionStopTime;

            // Token: 0x0400034D RID: 845
            public BmsId actionObjective;

            // Token: 0x0400034E RID: 846
            public BmsId lastActionObjective;

            // Token: 0x0400034F RID: 847
            public byte actionType;
        }

        // Token: 0x02000081 RID: 129
        public struct TeamBasicInfo
        {
            // Token: 0x04000350 RID: 848
            public byte teamFlag;

            // Token: 0x04000351 RID: 849
            public byte teamColor;

            // Token: 0x04000352 RID: 850
            public string teamName;

            // Token: 0x04000353 RID: 851
            public string teamMotto;
        }

        // Token: 0x02000082 RID: 130
        public struct SquadInfo
        {
            // Token: 0x04000354 RID: 852
            public float X;

            // Token: 0x04000355 RID: 853
            public float Y;

            // Token: 0x04000356 RID: 854
            public BmsId id;

            // Token: 0x04000357 RID: 855
            public short descriptionIndex;

            // Token: 0x04000358 RID: 856
            public short nameId;

            // Token: 0x04000359 RID: 857
            public short airbaseIcon;

            // Token: 0x0400035A RID: 858
            public short squadronPath;

            // Token: 0x0400035B RID: 859
            public byte specialty;

            // Token: 0x0400035C RID: 860
            public byte currentStrength;

            // Token: 0x0400035D RID: 861
            public byte country;

            // Token: 0x0400035E RID: 862
            public char[] airbaseName;

            // Token: 0x0400035F RID: 863
            public int flags;

            // Token: 0x04000360 RID: 864
            public short campId;

            // Token: 0x04000361 RID: 865
            public short texSet;

            // Token: 0x04000362 RID: 866
            public char[] squadronName;

            // Token: 0x04000363 RID: 867
            public byte padding;
        }

        // Token: 0x02000083 RID: 131
        public class EmbeddedFileInfo
        {
            // Token: 0x04000364 RID: 868
            public string fileName;

            // Token: 0x04000365 RID: 869
            public string Ext;

            // Token: 0x04000366 RID: 870
            public uint FileOffset;

            // Token: 0x04000367 RID: 871
            public uint FileSizeBytes;
        }

        // Token: 0x02000084 RID: 132
        public struct Package
        {
            // Token: 0x04000368 RID: 872
            public int FltNr;

            // Token: 0x04000369 RID: 873
            public uint Flt_Id_Num;

            // Token: 0x0400036A RID: 874
            public uint Flt_Id_Creator;

            // Token: 0x0400036B RID: 875
            public string Callsign;

            // Token: 0x0400036C RID: 876
            public string Task;

            // Token: 0x0400036D RID: 877
            public int AC_Nr;

            // Token: 0x0400036E RID: 878
            public string AC_Type;

            // Token: 0x0400036F RID: 879
            public string VHF;

            // Token: 0x04000370 RID: 880
            public string UHF;

            // Token: 0x04000371 RID: 881
            public string IDM;

            // Token: 0x04000372 RID: 882
            public string TCN;

            // Token: 0x04000373 RID: 883
            public string Note;

            // Token: 0x04000374 RID: 884
            public bool F16;

            // Token: 0x04000375 RID: 885
            public uint TakeOffTime;

            // Token: 0x04000376 RID: 886
            public byte PushStpt;

            // Token: 0x04000377 RID: 887
            public uint PushTime;

            // Token: 0x04000378 RID: 888
            public int PushAlt;

            // Token: 0x04000379 RID: 889
            public byte TargetStpt;

            // Token: 0x0400037A RID: 890
            public uint TargetTime;

            // Token: 0x0400037B RID: 891
            public byte RefuelStpt;
        }

        // Token: 0x02000085 RID: 133
        public struct Flightplan
        {
            // Token: 0x0400037C RID: 892
            public uint Arrive;

            // Token: 0x0400037D RID: 893
            public short Action;

            // Token: 0x0400037E RID: 894
            public uint Depart;

            // Token: 0x0400037F RID: 895
            public float Heading;

            // Token: 0x04000380 RID: 896
            public float Distance;

            // Token: 0x04000381 RID: 897
            public long Alt;

            // Token: 0x04000382 RID: 898
            public short Speed;

            // Token: 0x04000383 RID: 899
            public int Fuel;

            // Token: 0x04000384 RID: 900
            public short Formation;

            // Token: 0x04000385 RID: 901
            public string Latitude;

            // Token: 0x04000386 RID: 902
            public string Longtitude;
        }

        // Token: 0x02000086 RID: 134
        public struct EventNode
        {
            // Token: 0x04000387 RID: 903
            public short x;

            // Token: 0x04000388 RID: 904
            public short y;

            // Token: 0x04000389 RID: 905
            public uint time;

            // Token: 0x0400038A RID: 906
            public byte flags;

            // Token: 0x0400038B RID: 907
            public byte Team;

            // Token: 0x0400038C RID: 908
            public byte padding;

            // Token: 0x0400038D RID: 909
            public int EventTextSkip;

            // Token: 0x0400038E RID: 910
            public int UiEventNode;

            // Token: 0x0400038F RID: 911
            public ushort eventTextSize;

            // Token: 0x04000390 RID: 912
            public string eventText;
        }

        // Token: 0x02000087 RID: 135
        public struct Weather
        {
            // Token: 0x04000391 RID: 913
            public float WindHeading;

            // Token: 0x04000392 RID: 914
            public float WindSpeed;

            // Token: 0x04000393 RID: 915
            public ulong LastCheck;

            // Token: 0x04000394 RID: 916
            public float Temp;

            // Token: 0x04000395 RID: 917
            public byte TodaysTemp;

            // Token: 0x04000396 RID: 918
            public byte TodaysWind;

            // Token: 0x04000397 RID: 919
            public byte TodaysBase;

            // Token: 0x04000398 RID: 920
            public byte TodaysConLow;

            // Token: 0x04000399 RID: 921
            public byte TodaysConHigh;

            // Token: 0x0400039A RID: 922
            public float XOffset;

            // Token: 0x0400039B RID: 923
            public float YOffset;

            // Token: 0x0400039C RID: 924
            public ulong nw;

            // Token: 0x0400039D RID: 925
            public ulong nh;
        }

        // Token: 0x02000088 RID: 136
        public struct CellState
        {
            // Token: 0x0400039E RID: 926
            public byte BaseAltitude;

            // Token: 0x0400039F RID: 927
            public byte Type;
        }

        // Token: 0x02000089 RID: 137
        public struct ValidPlane
        {
            // Token: 0x040003A0 RID: 928
            public string Name;

            // Token: 0x040003A1 RID: 929
            public int Domain;

            // Token: 0x040003A2 RID: 930
            public int eClass;

            // Token: 0x040003A3 RID: 931
            public int Type;

            // Token: 0x040003A4 RID: 932
            public int SubType;

            // Token: 0x040003A5 RID: 933
            public int Specific;

            // Token: 0x040003A6 RID: 934
            public int Extra_1;

            // Token: 0x040003A7 RID: 935
            public int Extra_2;

            // Token: 0x040003A8 RID: 936
            public int Extra_3;

            // Token: 0x040003A9 RID: 937
            public int DataType;
        }

        // Token: 0x0200008A RID: 138
        public struct InValidPlane
        {
            // Token: 0x040003AA RID: 938
            public string SqType;

            // Token: 0x040003AB RID: 939
            public int Ct;
        }

        // Token: 0x0200008B RID: 139
        public struct TePlanes
        {
            // Token: 0x040003AC RID: 940
            public string Name;

            // Token: 0x040003AD RID: 941
            public int Type;

            // Token: 0x040003AE RID: 942
            public int SubType;

            // Token: 0x040003AF RID: 943
            public int Specific;

            // Token: 0x040003B0 RID: 944
            public int UnitSubType;

            // Token: 0x040003B1 RID: 945
            public int ID;

            // Token: 0x040003B2 RID: 946
            public int textId;

            // Token: 0x040003B3 RID: 947
            public int UnitIcon;
        }

        // Token: 0x0200008C RID: 140
        public struct TeUnits
        {
            // Token: 0x040003B4 RID: 948
            public string Name;

            // Token: 0x040003B5 RID: 949
            public int Side;

            // Token: 0x040003B6 RID: 950
            public int SubType;

            // Token: 0x040003B7 RID: 951
            public int Specific;
        }

        // Token: 0x0200008D RID: 141
        public struct TeNavalUnits
        {
            // Token: 0x040003B8 RID: 952
            public string Name;

            // Token: 0x040003B9 RID: 953
            public int Side;

            // Token: 0x040003BA RID: 954
            public int SubType;

            // Token: 0x040003BB RID: 955
            public int Specific;
        }

        // Token: 0x0200008E RID: 142
        public struct PersistantObject
        {
            // Token: 0x040003BC RID: 956
            public short flags;

            // Token: 0x040003BD RID: 957
            public PackedVUID unionData;

            // Token: 0x040003BE RID: 958
            public short visType;

            // Token: 0x040003BF RID: 959
            public float x;

            // Token: 0x040003C0 RID: 960
            public float y;
        }

        // Token: 0x0200008F RID: 143
        public struct PackedVUID
        {
            // Token: 0x040003C1 RID: 961
            public uint creator_;

            // Token: 0x040003C2 RID: 962
            public byte index_;

            // Token: 0x040003C3 RID: 963
            public uint num_;
        }

        // Token: 0x02000090 RID: 144
        public struct HDR
        {
            // Token: 0x040003C4 RID: 964
            public uint Version;

            // Token: 0x040003C5 RID: 965
            public int nColors;

            // Token: 0x040003C6 RID: 966
            public int NoDarkColors;

            // Token: 0x040003C7 RID: 967
            public HdrColor[] Colors;

            // Token: 0x040003C8 RID: 968
            public HdrParent[] Parents;

            // Token: 0x040003C9 RID: 969
            public HdrLod[] Lods;

            // Token: 0x040003CA RID: 970
            public HdrTexture[] Textures;
        }

        // Token: 0x02000091 RID: 145
        public struct HdrColor
        {
            // Token: 0x040003CB RID: 971
            public float Red;

            // Token: 0x040003CC RID: 972
            public float Green;

            // Token: 0x040003CD RID: 973
            public float Blue;

            // Token: 0x040003CE RID: 974
            public float Alpha;
        }

        // Token: 0x02000092 RID: 146
        public struct HdrParent
        {
            // Token: 0x040003CF RID: 975
            public float radius;

            // Token: 0x040003D0 RID: 976
            public float minX;

            // Token: 0x040003D1 RID: 977
            public float maxX;

            // Token: 0x040003D2 RID: 978
            public float minY;

            // Token: 0x040003D3 RID: 979
            public float maxY;

            // Token: 0x040003D4 RID: 980
            public float minZ;

            // Token: 0x040003D5 RID: 981
            public float maxZ;

            // Token: 0x040003D6 RID: 982
            public float RadarSign;

            // Token: 0x040003D7 RID: 983
            public float IRSign;

            // Token: 0x040003D8 RID: 984
            public short nTextureSets;

            // Token: 0x040003D9 RID: 985
            public short nDynamicCoords;

            // Token: 0x040003DA RID: 986
            public byte nLODs;

            // Token: 0x040003DB RID: 987
            public byte nSwitches;

            // Token: 0x040003DC RID: 988
            public byte nDOFs;

            // Token: 0x040003DD RID: 989
            public byte nSlots;

            // Token: 0x040003DE RID: 990
            public long Unused;

            // Token: 0x040003DF RID: 991
            public DynamiceData[] Dymanic;

            // Token: 0x040003E0 RID: 992
            public SlotData[] Slot;

            // Token: 0x040003E1 RID: 993
            public LodRecord[] Lods;
        }

        // Token: 0x02000093 RID: 147
        public struct LodRecord
        {
            // Token: 0x040003E2 RID: 994
            public int Nr;

            // Token: 0x040003E3 RID: 995
            public float MaxRange;
        }

        // Token: 0x02000094 RID: 148
        public struct HdrLod
        {
            // Token: 0x040003E4 RID: 996
            public int root;

            // Token: 0x040003E5 RID: 997
            public uint fileoffset;

            // Token: 0x040003E6 RID: 998
            public uint filesize;
        }

        // Token: 0x02000095 RID: 149
        public struct HdrTexture
        {
            // Token: 0x040003E7 RID: 999
            public float fileOffset;

            // Token: 0x040003E8 RID: 1000
            public float fileSize;

            // Token: 0x040003E9 RID: 1001
            public short palID;

            // Token: 0x040003EA RID: 1002
            public short refCount;
        }

        // Token: 0x02000096 RID: 150
        public struct DynamiceData
        {
            // Token: 0x040003EB RID: 1003
            public float X;

            // Token: 0x040003EC RID: 1004
            public float Y;

            // Token: 0x040003ED RID: 1005
            public float Z;
        }

        // Token: 0x02000097 RID: 151
        public struct SlotData
        {
            // Token: 0x040003EE RID: 1006
            public float X;

            // Token: 0x040003EF RID: 1007
            public float Y;

            // Token: 0x040003F0 RID: 1008
            public float Z;
        }

        // Token: 0x02000098 RID: 152
        public struct Runway
        {
            // Token: 0x040003F1 RID: 1009
            public int Prio;

            // Token: 0x040003F2 RID: 1010
            public float Heading;

            // Token: 0x040003F3 RID: 1011
            public float MagHdg;

            // Token: 0x040003F4 RID: 1012
            public float Var;

            // Token: 0x040003F5 RID: 1013
            public sbyte LtRt;

            // Token: 0x040003F6 RID: 1014
            public int texIdx;

            // Token: 0x040003F7 RID: 1015
            public ParkingSpots[] Spots;

            // Token: 0x040003F8 RID: 1016
            public TaxiPoint[] TaxiPt;

            // Token: 0x040003F9 RID: 1017
            public RwyPoint[] RwyPt;

            // Token: 0x040003FA RID: 1018
            public SupportPoint[] SupportPt;

            // Token: 0x040003FB RID: 1019
            public HeliSpots[] HeliPt;

            // Token: 0x040003FC RID: 1020
            public ParkingSpots TakeoffPt;

            // Token: 0x040003FD RID: 1021
            public ParkingSpots RunwayPt;
        }

        // Token: 0x02000099 RID: 153
        public struct ParkingSpots
        {
            // Token: 0x040003FE RID: 1022
            public short Nr;

            // Token: 0x040003FF RID: 1023
            public short Type;

            // Token: 0x04000400 RID: 1024
            public float xOffset;

            // Token: 0x04000401 RID: 1025
            public float yOffset;

            // Token: 0x04000402 RID: 1026
            public float FeetX;

            // Token: 0x04000403 RID: 1027
            public float FeetY;

            // Token: 0x04000404 RID: 1028
            public string North;

            // Token: 0x04000405 RID: 1029
            public string East;

            // Token: 0x04000406 RID: 1030
            public int Group;
        }

        // Token: 0x0200009A RID: 154
        public struct HeliSpots
        {
            // Token: 0x04000407 RID: 1031
            public short Nr;

            // Token: 0x04000408 RID: 1032
            public float xOffset;

            // Token: 0x04000409 RID: 1033
            public float yOffset;

            // Token: 0x0400040A RID: 1034
            public float FeetX;

            // Token: 0x0400040B RID: 1035
            public float FeetY;

            // Token: 0x0400040C RID: 1036
            public string North;

            // Token: 0x0400040D RID: 1037
            public string East;
        }

        // Token: 0x0200009B RID: 155
        public struct TaxiPoint
        {
            // Token: 0x0400040E RID: 1038
            public short Nr;

            // Token: 0x0400040F RID: 1039
            public short Idx;

            // Token: 0x04000410 RID: 1040
            public short Type;

            // Token: 0x04000411 RID: 1041
            public short taxiwayLetter;

            // Token: 0x04000412 RID: 1042
            public float xOffset;

            // Token: 0x04000413 RID: 1043
            public float yOffset;

            // Token: 0x04000414 RID: 1044
            public float FeetX;

            // Token: 0x04000415 RID: 1045
            public float FeetY;
        }

        // Token: 0x0200009C RID: 156
        public struct RwyPoint
        {
            // Token: 0x04000416 RID: 1046
            public float xOffset;

            // Token: 0x04000417 RID: 1047
            public float yOffset;

            // Token: 0x04000418 RID: 1048
            public float FeetX;

            // Token: 0x04000419 RID: 1049
            public float FeetY;
        }

        // Token: 0x0200009D RID: 157
        public struct SupportPoint
        {
            // Token: 0x0400041A RID: 1050
            public float xOffset;

            // Token: 0x0400041B RID: 1051
            public float yOffset;

            // Token: 0x0400041C RID: 1052
            public float FeetX;

            // Token: 0x0400041D RID: 1053
            public float FeetY;
        }

        // Token: 0x0200009E RID: 158
        public struct DisplayThemeColors
        {
            // Token: 0x0400041E RID: 1054
            public MFD_Color MFD_DEFAULT;

            // Token: 0x0400041F RID: 1055
            public MFD_Color MFD_SOI_BOX;

            // Token: 0x04000420 RID: 1056
            public MFD_Color MFD_AIRCRAFT_REF;

            // Token: 0x04000421 RID: 1057
            public MFD_Color MFD_BULLSEYE;

            // Token: 0x04000422 RID: 1058
            public MFD_Color MFD_BULLSEYE_DATA;

            // Token: 0x04000423 RID: 1059
            public MFD_Color MFD_STEERPOINT_CURSOR_DATA;

            // Token: 0x04000424 RID: 1060
            public MFD_Color MFD_REFERENCE_SYMBOL;

            // Token: 0x04000425 RID: 1061
            public MFD_Color MFD_NOT_SOI;

            // Token: 0x04000426 RID: 1062
            public MFD_Color MFD_TGT_CLOSURE_RATE;

            // Token: 0x04000427 RID: 1063
            public MFD_Color MFD_ANTENNA_AZEL_SCALE;

            // Token: 0x04000428 RID: 1064
            public MFD_Color MFD_ANTENNA_AZEL;

            // Token: 0x04000429 RID: 1065
            public MFD_Color MFD_FCR_REAQ_IND;

            // Token: 0x0400042A RID: 1066
            public MFD_Color MFD_FCR_RANGE_TICKS;

            // Token: 0x0400042B RID: 1067
            public MFD_Color MFD_CURSOR;

            // Token: 0x0400042C RID: 1068
            public MFD_Color MFD_CURSOR_SCAN_LIMIT_NEGATIVE;

            // Token: 0x0400042D RID: 1069
            public MFD_Color MFD_MINMAX_ALT;

            // Token: 0x0400042E RID: 1070
            public MFD_Color MFD_FCR_AZIMUTH_SCAN_LIM;

            // Token: 0x0400042F RID: 1071
            public MFD_Color MFD_ATTACK_STEERING_CUE;

            // Token: 0x04000430 RID: 1072
            public MFD_Color MFD_LINES;

            // Token: 0x04000431 RID: 1073
            public MFD_Color MFD_CUSTOM_LINES;

            // Token: 0x04000432 RID: 1074
            public MFD_Color MFD_CUR_STPT;

            // Token: 0x04000433 RID: 1075
            public MFD_Color MFD_DLZ;

            // Token: 0x04000434 RID: 1076
            public MFD_Color MFD_STEER_ERROR_CUE;

            // Token: 0x04000435 RID: 1077
            public MFD_Color MFD_UNKNOWN;

            // Token: 0x04000436 RID: 1078
            public MFD_Color MFD_EXPAND_BOX;

            // Token: 0x04000437 RID: 1079
            public MFD_Color MFD_FCR_BUG;

            // Token: 0x04000438 RID: 1080
            public MFD_Color MFD_FCR_BUGGED_FLASH_TAIL;

            // Token: 0x04000439 RID: 1081
            public MFD_Color MFD_FCR_BUGGED_TAIL;

            // Token: 0x0400043A RID: 1082
            public MFD_Color MFD_FCR_BUGGED;

            // Token: 0x0400043B RID: 1083
            public MFD_Color MFD_KILL_X;

            // Token: 0x0400043C RID: 1084
            public MFD_Color MFD_FCR_UNK_TRACK_FLASH;

            // Token: 0x0400043D RID: 1085
            public MFD_Color MFD_FCR_UNK_TRACK;

            // Token: 0x0400043E RID: 1086
            public MFD_Color MFD_DL_TEAM14;

            // Token: 0x0400043F RID: 1087
            public MFD_Color MFD_DL_TEAM58;

            // Token: 0x04000440 RID: 1088
            public MFD_Color MFD_LSDL_LINE;

            // Token: 0x04000441 RID: 1089
            public MFD_Color MFD_AIRSPEED_BOX;

            // Token: 0x04000442 RID: 1090
            public MFD_Color MFD_AIRCRAFT_HDG_BOX;

            // Token: 0x04000443 RID: 1091
            public MFD_Color MFD_RADAR_ALT_BOX;

            // Token: 0x04000444 RID: 1092
            public MFD_Color MFD_OWNSHIP;

            // Token: 0x04000445 RID: 1093
            public MFD_Color MFD_ROUTES;

            // Token: 0x04000446 RID: 1094
            public MFD_Color MFD_DATALINK;

            // Token: 0x04000447 RID: 1095
            public MFD_Color MFD_MARKPOINT;

            // Token: 0x04000448 RID: 1096
            public MFD_Color MFD_SWEEP;

            // Token: 0x04000449 RID: 1097
            public MFD_Color MFD_DLP_SCAN;

            // Token: 0x0400044A RID: 1098
            public MFD_Color MFD_DLP_MISSILE;

            // Token: 0x0400044B RID: 1099
            public MFD_Color MFD_DLP_AZ_LINE;

            // Token: 0x0400044C RID: 1100
            public MFD_Color MFD_PREPLAN_INRANGE;

            // Token: 0x0400044D RID: 1101
            public MFD_Color MFD_PREPLAN;

            // Token: 0x0400044E RID: 1102
            public MFD_Color MFD_HARPOON_PATH;

            // Token: 0x0400044F RID: 1103
            public MFD_Color MFD_HARPOON_TEXT;

            // Token: 0x04000450 RID: 1104
            public MFD_Color MFD_HARM_ALIC_BOX;

            // Token: 0x04000451 RID: 1105
            public MFD_Color MFD_HARM_ALIC_BOX_RANGE_LINES;

            // Token: 0x04000452 RID: 1106
            public MFD_Color MFD_HARM_DTSB_BOX;

            // Token: 0x04000453 RID: 1107
            public MFD_Color MFD_HARM_DTSB_SYMBOL;

            // Token: 0x04000454 RID: 1108
            public MFD_Color MFD_HARM_HAD_CURSOR;

            // Token: 0x04000455 RID: 1109
            public MFD_Color MFD_HARM_HAD_WEZ;

            // Token: 0x04000456 RID: 1110
            public MFD_Color MFD_HARM_HAD_ROUTES;

            // Token: 0x04000457 RID: 1111
            public MFD_Color MFD_HARM_HAD_LOCK;

            // Token: 0x04000458 RID: 1112
            public MFD_Color MFD_HARM_HAD_EMMITER_BEHIND9;

            // Token: 0x04000459 RID: 1113
            public MFD_Color MFD_HARM_HAD_EMMITER_BEHIND9_TRACK;

            // Token: 0x0400045A RID: 1114
            public MFD_Color MFD_HARM_HAD_EMMITER;

            // Token: 0x0400045B RID: 1115
            public MFD_Color MFD_HARM_HAD_EMMITER_LAUNCH;

            // Token: 0x0400045C RID: 1116
            public MFD_Color MFD_HARM_HAD_EMMITER_TRACK;

            // Token: 0x0400045D RID: 1117
            public MFD_Color MFD_HARM_HAD_EMMITER_RADIATE;

            // Token: 0x0400045E RID: 1118
            public MFD_Color MFD_HARM_HAS_EMMITER;

            // Token: 0x0400045F RID: 1119
            public MFD_Color MFD_HARM_HANDOFF_EMMITER;

            // Token: 0x04000460 RID: 1120
            public MFD_Color MFD_HARM_HANDOFF;

            // Token: 0x04000461 RID: 1121
            public MFD_Color MFD_PULLUP_CROSS;

            // Token: 0x04000462 RID: 1122
            public MFD_Color MFD_CHECKATTITUDE;

            // Token: 0x04000463 RID: 1123
            public MFD_Color MFD_CHECKATTITUDE_TEXT;

            // Token: 0x04000464 RID: 1124
            public MFD_Color MFD_TFRLIMITS;

            // Token: 0x04000465 RID: 1125
            public MFD_Color MFD_TFRLIMITS_TEXT;

            // Token: 0x04000466 RID: 1126
            public MFD_Color MFD_SENSORS_VIDEO;

            // Token: 0x04000467 RID: 1127
            public MFD_Color MFD_CUSTOM_LINE1;

            // Token: 0x04000468 RID: 1128
            public MFD_Color MFD_CUSTOM_LINE2;

            // Token: 0x04000469 RID: 1129
            public MFD_Color MFD_CUSTOM_LINE3;

            // Token: 0x0400046A RID: 1130
            public MFD_Color MFD_CUSTOM_LINE4;

            // Token: 0x0400046B RID: 1131
            public MFD_Color MFD_ROUTES_STPT;
        }

        // Token: 0x0200009F RID: 159
        public struct OffMapAb
        {
            // Token: 0x0400046C RID: 1132
            public string Name;

            // Token: 0x0400046D RID: 1133
            public int X;

            // Token: 0x0400046E RID: 1134
            public int Y;

            // Token: 0x0400046F RID: 1135
            public float North;

            // Token: 0x04000470 RID: 1136
            public float East;

            // Token: 0x04000471 RID: 1137
            public int Side;
        }

        // Token: 0x020000A0 RID: 160
        public struct MissionDataType
        {
            // Token: 0x04000472 RID: 1138
            public byte misIndex;

            // Token: 0x04000473 RID: 1139
            public byte misType;

            // Token: 0x04000474 RID: 1140
            public byte tgtType;

            // Token: 0x04000475 RID: 1141
            public byte misRole;

            // Token: 0x04000476 RID: 1142
            public byte misProfile;

            // Token: 0x04000477 RID: 1143
            public byte tgtProfile;

            // Token: 0x04000478 RID: 1144
            public byte tgtDescription;

            // Token: 0x04000479 RID: 1145
            public byte routeWpAction;

            // Token: 0x0400047A RID: 1146
            public byte tgtWpAction;

            // Token: 0x0400047B RID: 1147
            public short tgtMinAlt;

            // Token: 0x0400047C RID: 1148
            public short tgtMaxAlt;

            // Token: 0x0400047D RID: 1149
            public short misAltHighProfile;

            // Token: 0x0400047E RID: 1150
            public short misAltLowProfile;

            // Token: 0x0400047F RID: 1151
            public short separation;

            // Token: 0x04000480 RID: 1152
            public short loiterTime;

            // Token: 0x04000481 RID: 1153
            public short loiterTimeMinimum;

            // Token: 0x04000482 RID: 1154
            public short loiterDistance;

            // Token: 0x04000483 RID: 1155
            public short loiterDirection;

            // Token: 0x04000484 RID: 1156
            public short loiterOffset;

            // Token: 0x04000485 RID: 1157
            public short loiterTrackDist;

            // Token: 0x04000486 RID: 1158
            public short loiterTimeEscortFlight;

            // Token: 0x04000487 RID: 1159
            public byte strength;

            // Token: 0x04000488 RID: 1160
            public byte minPlanTime;

            // Token: 0x04000489 RID: 1161
            public byte maxPlanTime;

            // Token: 0x0400048A RID: 1162
            public short holdingTime;

            // Token: 0x0400048B RID: 1163
            public short holdingDist;

            // Token: 0x0400048C RID: 1164
            public short maxAirThreat;

            // Token: 0x0400048D RID: 1165
            public short maxGndThreat;

            // Token: 0x0400048E RID: 1166
            public byte escortType;

            // Token: 0x0400048F RID: 1167
            public short minDistSimilar;

            // Token: 0x04000490 RID: 1168
            public short minTimeSimilar;

            // Token: 0x04000491 RID: 1169
            public short minDistToFlot;

            // Token: 0x04000492 RID: 1170
            public short maxDistToFlot;

            // Token: 0x04000493 RID: 1171
            public byte formationTypePrePush;

            // Token: 0x04000494 RID: 1172
            public short formationSpacingPrePush;

            // Token: 0x04000495 RID: 1173
            public byte formationTypePreTgt;

            // Token: 0x04000496 RID: 1174
            public short formationSpacingPreTgt;

            // Token: 0x04000497 RID: 1175
            public byte formationTypePostTgt;

            // Token: 0x04000498 RID: 1176
            public short formationSpacingPostTgt;

            // Token: 0x04000499 RID: 1177
            public byte formationTypePostSplit;

            // Token: 0x0400049A RID: 1178
            public short formationSpacingPostSplit;

            // Token: 0x0400049B RID: 1179
            public byte specialCapabilities;

            // Token: 0x0400049C RID: 1180
            public string flags;

            // Token: 0x0400049D RID: 1181
            public string Note;
        }

        // Token: 0x020000A1 RID: 161
        public struct SqTexSet
        {
            // Token: 0x0400049E RID: 1182
            public int team;

            // Token: 0x0400049F RID: 1183
            public int sq;

            // Token: 0x040004A0 RID: 1184
            public int tex;

            // Token: 0x040004A1 RID: 1185
            public int type;

            // Token: 0x040004A2 RID: 1186
            public int SubType;

            // Token: 0x040004A3 RID: 1187
            public int Specific;
        }

        // Token: 0x020000A2 RID: 162
        public struct TransverseMercatorMeta
        {
            // Token: 0x040004A4 RID: 1188
            public string theaterName;

            // Token: 0x040004A5 RID: 1189
            public double Meridian;

            // Token: 0x040004A6 RID: 1190
            public double offsetX;

            // Token: 0x040004A7 RID: 1191
            public double offsetY;

            // Token: 0x040004A8 RID: 1192
            public double centerLat;

            // Token: 0x040004A9 RID: 1193
            public double centerLon;

            // Token: 0x040004AA RID: 1194
            public uint theaterSizeInMeters;

            // Token: 0x040004AB RID: 1195
            public float HEIGHTMAP_SIZE;

            // Token: 0x040004AC RID: 1196
            public float METER_RES;

            // Token: 0x040004AD RID: 1197
            public float FT_TO_GRID;

            // Token: 0x040004AE RID: 1198
            public float GRID_TO_FT;

            // Token: 0x040004AF RID: 1199
            public float GRID_OFFSET;
        }

        // Token: 0x020000A3 RID: 163
        public enum VuClassHierarchy
        {
            // Token: 0x040004B1 RID: 1201
            VU_DOMAIN,
            // Token: 0x040004B2 RID: 1202
            VU_CLASS,
            // Token: 0x040004B3 RID: 1203
            VU_TYPE,
            // Token: 0x040004B4 RID: 1204
            VU_STYPE,
            // Token: 0x040004B5 RID: 1205
            VU_SPTYPE,
            // Token: 0x040004B6 RID: 1206
            VU_OWNER
        }

        // Token: 0x020000A4 RID: 164
        public enum VuConsts
        {
            // Token: 0x040004B8 RID: 1208
            DOMAIN_ANY = 255,
            // Token: 0x040004B9 RID: 1209
            CLASS_ANY = 255,
            // Token: 0x040004BA RID: 1210
            TYPE_ANY = 255,
            // Token: 0x040004BB RID: 1211
            STYPE_ANY = 255,
            // Token: 0x040004BC RID: 1212
            SPTYPE_ANY = 255,
            // Token: 0x040004BD RID: 1213
            RFU1_ANY = 255,
            // Token: 0x040004BE RID: 1214
            RFU2_ANY = 255,
            // Token: 0x040004BF RID: 1215
            RFU3_ANY = 255,
            // Token: 0x040004C0 RID: 1216
            VU_ANY = 255
        }

        // Token: 0x020000A5 RID: 165
        public enum VuVisTypes
        {
            // Token: 0x040004C2 RID: 1218
            VIS_NORMAL,
            // Token: 0x040004C3 RID: 1219
            VIS_REPAIRED,
            // Token: 0x040004C4 RID: 1220
            VIS_DAMAGED,
            // Token: 0x040004C5 RID: 1221
            VIS_DESTROYED,
            // Token: 0x040004C6 RID: 1222
            VIS_LEFT_DEST,
            // Token: 0x040004C7 RID: 1223
            VIS_RIGHT_DEST,
            // Token: 0x040004C8 RID: 1224
            VIS_BOTH_DEST
        }

        // Token: 0x020000A6 RID: 166
        public enum Classtable_Domains
        {
            // Token: 0x040004CA RID: 1226
            DOMAIN_ABSTRACT = 1,
            // Token: 0x040004CB RID: 1227
            DOMAIN_AIR,
            // Token: 0x040004CC RID: 1228
            DOMAIN_LAND,
            // Token: 0x040004CD RID: 1229
            DOMAIN_SEA,
            // Token: 0x040004CE RID: 1230
            DOMAIN_SPACE,
            // Token: 0x040004CF RID: 1231
            DOMAIN_UNDERGROUND,
            // Token: 0x040004D0 RID: 1232
            DOMAIN_UNDERSEA
        }

        // Token: 0x020000A7 RID: 167
        public enum Classtable_Classes
        {
            // Token: 0x040004D2 RID: 1234
            CLASS_ANIMAL = 1,
            // Token: 0x040004D3 RID: 1235
            CLASS_FEATURE,
            // Token: 0x040004D4 RID: 1236
            CLASS_MANAGER,
            // Token: 0x040004D5 RID: 1237
            CLASS_OBJECTIVE,
            // Token: 0x040004D6 RID: 1238
            CLASS_SFX,
            // Token: 0x040004D7 RID: 1239
            CLASS_UNIT,
            // Token: 0x040004D8 RID: 1240
            CLASS_VEHICLE,
            // Token: 0x040004D9 RID: 1241
            CLASS_WEAPON,
            // Token: 0x040004DA RID: 1242
            CLASS_WEATHER,
            // Token: 0x040004DB RID: 1243
            CLASS_SESSION,
            // Token: 0x040004DC RID: 1244
            CLASS_ABSTRACT = 0,
            // Token: 0x040004DD RID: 1245
            CLASS_GAME = 11,
            // Token: 0x040004DE RID: 1246
            CLASS_GROUP,
            // Token: 0x040004DF RID: 1247
            CLASS_DIALOG
        }

        // Token: 0x020000A8 RID: 168
        public enum Classtable_Types
        {
            // Token: 0x040004E1 RID: 1249
            TYPE_NOTHING = 1,
            // Token: 0x040004E2 RID: 1250
            TYPE_MINESWEEP,
            // Token: 0x040004E3 RID: 1251
            TYPE_GUN,
            // Token: 0x040004E4 RID: 1252
            TYPE_RACK,
            // Token: 0x040004E5 RID: 1253
            TYPE_LAUNCHER,
            // Token: 0x040004E6 RID: 1254
            TYPE_ABSTRACT_WEAPONS,
            // Token: 0x040004E7 RID: 1255
            TYPE_ATM = 1,
            // Token: 0x040004E8 RID: 1256
            TYPE_FLIGHT = 1,
            // Token: 0x040004E9 RID: 1257
            TYPE_PACKAGE,
            // Token: 0x040004EA RID: 1258
            TYPE_SQUADRON,
            // Token: 0x040004EB RID: 1259
            TYPE_AIR_UNITS,
            // Token: 0x040004EC RID: 1260
            TYPE_AIRPLANE = 1,
            // Token: 0x040004ED RID: 1261
            TYPE_BOMB,
            // Token: 0x040004EE RID: 1262
            TYPE_POD,
            // Token: 0x040004EF RID: 1263
            TYPE_FUEL_TANK,
            // Token: 0x040004F0 RID: 1264
            TYPE_HELICOPTER,
            // Token: 0x040004F1 RID: 1265
            TYPE_MISSILE,
            // Token: 0x040004F2 RID: 1266
            TYPE_RECON,
            // Token: 0x040004F3 RID: 1267
            TYPE_ROCKET,
            // Token: 0x040004F4 RID: 1268
            TYPE_AIR_VEHICLES,
            // Token: 0x040004F5 RID: 1269
            TYPE_AIRBASE = 1,
            // Token: 0x040004F6 RID: 1270
            TYPE_AIRSTRIP,
            // Token: 0x040004F7 RID: 1271
            TYPE_ARMYBASE,
            // Token: 0x040004F8 RID: 1272
            TYPE_BEACH,
            // Token: 0x040004F9 RID: 1273
            TYPE_BORDER,
            // Token: 0x040004FA RID: 1274
            TYPE_BRIDGE,
            // Token: 0x040004FB RID: 1275
            TYPE_CHEMICAL,
            // Token: 0x040004FC RID: 1276
            TYPE_CITY,
            // Token: 0x040004FD RID: 1277
            TYPE_COM_CONTROL,
            // Token: 0x040004FE RID: 1278
            TYPE_DEPOT,
            // Token: 0x040004FF RID: 1279
            TYPE_FACTORY,
            // Token: 0x04000500 RID: 1280
            TYPE_FORD,
            // Token: 0x04000501 RID: 1281
            TYPE_FORTIFICATION,
            // Token: 0x04000502 RID: 1282
            TYPE_HILL_TOP,
            // Token: 0x04000503 RID: 1283
            TYPE_INTERSECT,
            // Token: 0x04000504 RID: 1284
            TYPE_NAV_BEACON,
            // Token: 0x04000505 RID: 1285
            TYPE_NUCLEAR,
            // Token: 0x04000506 RID: 1286
            TYPE_PASS,
            // Token: 0x04000507 RID: 1287
            TYPE_PORT,
            // Token: 0x04000508 RID: 1288
            TYPE_POWERPLANT,
            // Token: 0x04000509 RID: 1289
            TYPE_RADAR,
            // Token: 0x0400050A RID: 1290
            TYPE_RADIO_TOWER,
            // Token: 0x0400050B RID: 1291
            TYPE_RAIL_TERMINAL,
            // Token: 0x0400050C RID: 1292
            TYPE_RAILROAD,
            // Token: 0x0400050D RID: 1293
            TYPE_REFINERY,
            // Token: 0x0400050E RID: 1294
            TYPE_ROAD,
            // Token: 0x0400050F RID: 1295
            TYPE_SEA,
            // Token: 0x04000510 RID: 1296
            TYPE_TOWN,
            // Token: 0x04000511 RID: 1297
            TYPE_VILLAGE,
            // Token: 0x04000512 RID: 1298
            TYPE_HARTS,
            // Token: 0x04000513 RID: 1299
            TYPE_SAM_SITE,
            // Token: 0x04000514 RID: 1300
            TYPE_LAND_OBJECTIVES,
            // Token: 0x04000515 RID: 1301
            TYPE_CRATER = 1,
            // Token: 0x04000516 RID: 1302
            TYPE_CTRL_TOWER,
            // Token: 0x04000517 RID: 1303
            TYPE_BARN,
            // Token: 0x04000518 RID: 1304
            TYPE_BUNKER,
            // Token: 0x04000519 RID: 1305
            TYPE_BUSH,
            // Token: 0x0400051A RID: 1306
            TYPE_FACTORYS,
            // Token: 0x0400051B RID: 1307
            TYPE_CHURCH,
            // Token: 0x0400051C RID: 1308
            TYPE_CITY_HALL,
            // Token: 0x0400051D RID: 1309
            TYPE_DOCK,
            // Token: 0x0400051E RID: 1310
            TYPE_RUNWAY = 11,
            // Token: 0x0400051F RID: 1311
            TYPE_WAREHOUSE,
            // Token: 0x04000520 RID: 1312
            TYPE_HELIPAD,
            // Token: 0x04000521 RID: 1313
            TYPE_FUEL_TANKS,
            // Token: 0x04000522 RID: 1314
            TYPE_NUKE_PLANT,
            // Token: 0x04000523 RID: 1315
            TYPE_BRIDGES,
            // Token: 0x04000524 RID: 1316
            TYPE_PIER,
            // Token: 0x04000525 RID: 1317
            TYPE_PPOLE,
            // Token: 0x04000526 RID: 1318
            TYPE_SHOP,
            // Token: 0x04000527 RID: 1319
            TYPE_PTOWER,
            // Token: 0x04000528 RID: 1320
            TYPE_APARTMENT,
            // Token: 0x04000529 RID: 1321
            TYPE_HOUSE,
            // Token: 0x0400052A RID: 1322
            TYPE_PPLANT,
            // Token: 0x0400052B RID: 1323
            TYPE_TAXI_SIGN,
            // Token: 0x0400052C RID: 1324
            TYPE_NAV_BEAC,
            // Token: 0x0400052D RID: 1325
            TYPE_RADAR_SITE,
            // Token: 0x0400052E RID: 1326
            TYPE_CRATERS,
            // Token: 0x0400052F RID: 1327
            TYPE_RADARS,
            // Token: 0x04000530 RID: 1328
            TYPE_RTOWER,
            // Token: 0x04000531 RID: 1329
            TYPE_TAXIWAY,
            // Token: 0x04000532 RID: 1330
            TYPE_RAIL_TERMINALS,
            // Token: 0x04000533 RID: 1331
            TYPE_REFINERYS,
            // Token: 0x04000534 RID: 1332
            TYPE_SAM,
            // Token: 0x04000535 RID: 1333
            TYPE_SHED,
            // Token: 0x04000536 RID: 1334
            TYPE_BARRACKS,
            // Token: 0x04000537 RID: 1335
            TYPE_TREE,
            // Token: 0x04000538 RID: 1336
            TYPE_WTOWER,
            // Token: 0x04000539 RID: 1337
            TYPE_TWNHALL,
            // Token: 0x0400053A RID: 1338
            TYPE_AIR_TERMINAL,
            // Token: 0x0400053B RID: 1339
            TYPE_SHRINE,
            // Token: 0x0400053C RID: 1340
            TYPE_PARK,
            // Token: 0x0400053D RID: 1341
            TYPE_OFF_BLOCK,
            // Token: 0x0400053E RID: 1342
            TYPE_TVSTN,
            // Token: 0x0400053F RID: 1343
            TYPE_HOTEL,
            // Token: 0x04000540 RID: 1344
            TYPE_HANGAR,
            // Token: 0x04000541 RID: 1345
            TYPE_LIGHTS,
            // Token: 0x04000542 RID: 1346
            TYPE_VASI,
            // Token: 0x04000543 RID: 1347
            TYPE_TANK,
            // Token: 0x04000544 RID: 1348
            TYPE_FENCE,
            // Token: 0x04000545 RID: 1349
            TYPE_PARKINGLOT,
            // Token: 0x04000546 RID: 1350
            TYPE_SMOKESTACK,
            // Token: 0x04000547 RID: 1351
            TYPE_BUILDING,
            // Token: 0x04000548 RID: 1352
            TYPE_COOL_TWR,
            // Token: 0x04000549 RID: 1353
            TYPE_CONT_DOME,
            // Token: 0x0400054A RID: 1354
            TYPE_GUARDHOUSE,
            // Token: 0x0400054B RID: 1355
            TYPE_TRANSFORMER,
            // Token: 0x0400054C RID: 1356
            TYPE_AMMO_DUMP,
            // Token: 0x0400054D RID: 1357
            TYPE_ART_SITE,
            // Token: 0x0400054E RID: 1358
            TYPE_OFFICE,
            // Token: 0x0400054F RID: 1359
            TYPE_CHEM_PLANT,
            // Token: 0x04000550 RID: 1360
            TYPE_TOWER,
            // Token: 0x04000551 RID: 1361
            TYPE_HOSPITAL,
            // Token: 0x04000552 RID: 1362
            TYPE_SHOPBLK,
            // Token: 0x04000553 RID: 1363
            TYPE_STATIC,
            // Token: 0x04000554 RID: 1364
            TYPE_RUNWAY_MARKER,
            // Token: 0x04000555 RID: 1365
            TYPE_STADIUM,
            // Token: 0x04000556 RID: 1366
            TYPE_MONUMENT,
            // Token: 0x04000557 RID: 1367
            TYPE_ARRESTOR_CABLE,
            // Token: 0x04000558 RID: 1368
            TYPE_LAND_FEATURES,
            // Token: 0x04000559 RID: 1369
            TYPE_GTM = 1,
            // Token: 0x0400055A RID: 1370
            TYPE_BATTALION = 1,
            // Token: 0x0400055B RID: 1371
            TYPE_BRIGADE,
            // Token: 0x0400055C RID: 1372
            TYPE_LAND_UNITS,
            // Token: 0x0400055D RID: 1373
            TYPE_FOOT = 1,
            // Token: 0x0400055E RID: 1374
            TYPE_TOWED,
            // Token: 0x0400055F RID: 1375
            TYPE_TRACKED,
            // Token: 0x04000560 RID: 1376
            TYPE_WHEELED,
            // Token: 0x04000561 RID: 1377
            TYPE_LAND_VEHICLES,
            // Token: 0x04000562 RID: 1378
            TYPE_NTM = 1,
            // Token: 0x04000563 RID: 1379
            TYPE_TASKFORCE = 1,
            // Token: 0x04000564 RID: 1380
            TYPE_SEA_UNITS,
            // Token: 0x04000565 RID: 1381
            TYPE_ASSAULT = 1,
            // Token: 0x04000566 RID: 1382
            TYPE_BOAT,
            // Token: 0x04000567 RID: 1383
            TYPE_BUOY,
            // Token: 0x04000568 RID: 1384
            TYPE_CAPITAL_SHIP,
            // Token: 0x04000569 RID: 1385
            TYPE_CARGO,
            // Token: 0x0400056A RID: 1386
            TYPE_CRUISER,
            // Token: 0x0400056B RID: 1387
            TYPE_DEPTHCHARGE,
            // Token: 0x0400056C RID: 1388
            TYPE_DESTROYER,
            // Token: 0x0400056D RID: 1389
            TYPE_FRIGATE,
            // Token: 0x0400056E RID: 1390
            TYPE_PATROL,
            // Token: 0x0400056F RID: 1391
            TYPE_RAFT,
            // Token: 0x04000570 RID: 1392
            TYPE_SHIP,
            // Token: 0x04000571 RID: 1393
            TYPE_TANKER,
            // Token: 0x04000572 RID: 1394
            TYPE_TORPEDO,
            // Token: 0x04000573 RID: 1395
            TYPE_SEA_VEHICLES,
            // Token: 0x04000574 RID: 1396
            TYPE_WOLFPACK = 1,
            // Token: 0x04000575 RID: 1397
            TYPE_UNSERSEA_UNITS,
            // Token: 0x04000576 RID: 1398
            TYPE_SUBMARINE = 1,
            // Token: 0x04000577 RID: 1399
            TYPE_UNSERSEA_VEHICLES,
            // Token: 0x04000578 RID: 1400
            TYPE_TEAM = 1,
            // Token: 0x04000579 RID: 1401
            TYPE_CHAFF = 5,
            // Token: 0x0400057A RID: 1402
            TYPE_FLARE,
            // Token: 0x0400057B RID: 1403
            TYPE_EJECT = 9,
            // Token: 0x0400057C RID: 1404
            TYPE_FLYING_EYE = 1,
            // Token: 0x0400057D RID: 1405
            TYPE_ARMADA = 1,
            // Token: 0x0400057E RID: 1406
            TYPE_END_MISSION = 1,
            // Token: 0x0400057F RID: 1407
            TYPE_TEST = 15,
            // Token: 0x04000580 RID: 1408
            TYPE_COCKPIT = 3,
            // Token: 0x04000581 RID: 1409
            TYPE_DEBRIS = 1,
            // Token: 0x04000582 RID: 1410
            TYPE_AEXPLOSION = 1,
            // Token: 0x04000583 RID: 1411
            TYPE_CANOPY = 7,
            // Token: 0x04000584 RID: 1412
            TYPE_EXPLOSION = 1,
            // Token: 0x04000585 RID: 1413
            TYPE_FIRE,
            // Token: 0x04000586 RID: 1414
            TYPE_DUST,
            // Token: 0x04000587 RID: 1415
            TYPE_SMOKE,
            // Token: 0x04000588 RID: 1416
            TYPE_CLOUD = 1,
            // Token: 0x04000589 RID: 1417
            TYPE_HULK
        }

        // Token: 0x020000A9 RID: 169
        public enum Sub_Types
        {
            // Token: 0x0400058B RID: 1419
            STYPE_NOTHING = 1,
            // Token: 0x0400058C RID: 1420
            STYPE_GENERIC = 3,
            // Token: 0x0400058D RID: 1421
            STYPE_,
            // Token: 0x0400058E RID: 1422
            STYPE_UNIT_AIR_TRANSPORT = 1,
            // Token: 0x0400058F RID: 1423
            STYPE_UNIT_ASW,
            // Token: 0x04000590 RID: 1424
            STYPE_UNIT_ATTACK,
            // Token: 0x04000591 RID: 1425
            STYPE_UNIT_ATTACK_HELO,
            // Token: 0x04000592 RID: 1426
            STYPE_UNIT_AWACS,
            // Token: 0x04000593 RID: 1427
            STYPE_UNIT_BOMBER,
            // Token: 0x04000594 RID: 1428
            STYPE_UNIT_ECM,
            // Token: 0x04000595 RID: 1429
            STYPE_UNIT_FIGHTER,
            // Token: 0x04000596 RID: 1430
            STYPE_UNIT_FIGHTER_BOMBER,
            // Token: 0x04000597 RID: 1431
            STYPE_UNIT_JSTAR,
            // Token: 0x04000598 RID: 1432
            STYPE_UNIT_RECON,
            // Token: 0x04000599 RID: 1433
            STYPE_UNIT_RECON_HELO,
            // Token: 0x0400059A RID: 1434
            STYPE_UNIT_TANKER,
            // Token: 0x0400059B RID: 1435
            STYPE_UNIT_TRANSPORT_HELO,
            // Token: 0x0400059C RID: 1436
            STYPE_UNIT_ELINT,
            // Token: 0x0400059D RID: 1437
            STYPE_UNIT_ABCCC,
            // Token: 0x0400059E RID: 1438
            STYPE_UNIT_AIR_DEFENSE = 1,
            // Token: 0x0400059F RID: 1439
            STYPE_UNIT_AIRMOBILE,
            // Token: 0x040005A0 RID: 1440
            STYPE_UNIT_AIRBORNE = 2,
            // Token: 0x040005A1 RID: 1441
            STYPE_UNIT_ARMOR,
            // Token: 0x040005A2 RID: 1442
            STYPE_UNIT_ARMORED_CAV,
            // Token: 0x040005A3 RID: 1443
            STYPE_UNIT_ENGINEER,
            // Token: 0x040005A4 RID: 1444
            STYPE_UNIT_HQ,
            // Token: 0x040005A5 RID: 1445
            STYPE_UNIT_INFANTRY,
            // Token: 0x040005A6 RID: 1446
            STYPE_UNIT_MARINE,
            // Token: 0x040005A7 RID: 1447
            STYPE_UNIT_MECHANIZED,
            // Token: 0x040005A8 RID: 1448
            STYPE_UNIT_ROCKET,
            // Token: 0x040005A9 RID: 1449
            STYPE_UNIT_SP_ARTILLERY,
            // Token: 0x040005AA RID: 1450
            STYPE_UNIT_SS_MISSILE,
            // Token: 0x040005AB RID: 1451
            STYPE_UNIT_SUPPLY,
            // Token: 0x040005AC RID: 1452
            STYPE_UNIT_TOWED_ARTILLERY,
            // Token: 0x040005AD RID: 1453
            STYPE_UNIT_RESERVE,
            // Token: 0x040005AE RID: 1454
            STYPE_UNIT_AMPHIBIOUS = 1,
            // Token: 0x040005AF RID: 1455
            STYPE_UNIT_BATTLESHIP,
            // Token: 0x040005B0 RID: 1456
            STYPE_UNIT_CARRIER,
            // Token: 0x040005B1 RID: 1457
            STYPE_UNIT_CRUISER,
            // Token: 0x040005B2 RID: 1458
            STYPE_UNIT_DESTROYER,
            // Token: 0x040005B3 RID: 1459
            STYPE_UNIT_FRIGATE,
            // Token: 0x040005B4 RID: 1460
            STYPE_UNIT_PATROL,
            // Token: 0x040005B5 RID: 1461
            STYPE_UNIT_SEA_SUPPLY,
            // Token: 0x040005B6 RID: 1462
            STYPE_UNIT_SEA_TANKER,
            // Token: 0x040005B7 RID: 1463
            STYPE_UNIT_SEA_TRANSPORT,
            // Token: 0x040005B8 RID: 1464
            STYPE_UNIT_SSGN,
            // Token: 0x040005B9 RID: 1465
            STYPE_UNIT_SSN,
            // Token: 0x040005BA RID: 1466
            STYPE_UNIT_SSBN,
            // Token: 0x040005BB RID: 1467
            STYPE_AIR_ASW = 1,
            // Token: 0x040005BC RID: 1468
            STYPE_AIR_ATTACK,
            // Token: 0x040005BD RID: 1469
            STYPE_AIR_AWACS,
            // Token: 0x040005BE RID: 1470
            STYPE_AIR_BOMBER,
            // Token: 0x040005BF RID: 1471
            STYPE_AIR_ECM,
            // Token: 0x040005C0 RID: 1472
            STYPE_AIR_FIGHTER,
            // Token: 0x040005C1 RID: 1473
            STYPE_AIR_FIGHTER_BOMBER,
            // Token: 0x040005C2 RID: 1474
            STYPE_AIR_JSTAR,
            // Token: 0x040005C3 RID: 1475
            STYPE_AIR_RECON,
            // Token: 0x040005C4 RID: 1476
            STYPE_AIR_TANKER,
            // Token: 0x040005C5 RID: 1477
            STYPE_AIR_TRANSPORT,
            // Token: 0x040005C6 RID: 1478
            STYPE_AIR_ELINT,
            // Token: 0x040005C7 RID: 1479
            STYPE_AIR_ABCCC,
            // Token: 0x040005C8 RID: 1480
            STYPE_AIR_UAV,
            // Token: 0x040005C9 RID: 1481
            STYPE_AIR_ATTACK_HELO = 1,
            // Token: 0x040005CA RID: 1482
            STYPE_AIR_RECON_HELO,
            // Token: 0x040005CB RID: 1483
            STYPE_AIR_TRANSPORT_HELO,
            // Token: 0x040005CC RID: 1484
            STYPE_TOWED_AAA = 1,
            // Token: 0x040005CD RID: 1485
            STYPE_TOWED_ARTILLERY,
            // Token: 0x040005CE RID: 1486
            STYPE_TRACKED_AAA = 1,
            // Token: 0x040005CF RID: 1487
            STYPE_TRACKED_AIR_DEFENSE,
            // Token: 0x040005D0 RID: 1488
            STYPE_TRACKED_ARMOR,
            // Token: 0x040005D1 RID: 1489
            STYPE_TRACKED_ARTILLERY,
            // Token: 0x040005D2 RID: 1490
            STYPE_TRACKED_ENGINEER,
            // Token: 0x040005D3 RID: 1491
            STYPE_TRACKED_HQ,
            // Token: 0x040005D4 RID: 1492
            STYPE_TRACKED_IFV,
            // Token: 0x040005D5 RID: 1493
            STYPE_TRACKED_MORTAR,
            // Token: 0x040005D6 RID: 1494
            STYPE_TRACKED_TRANSPORT,
            // Token: 0x040005D7 RID: 1495
            STYPE_WHEELED_AAA = 1,
            // Token: 0x040005D8 RID: 1496
            STYPE_WHEELED_AIR_DEFENSE,
            // Token: 0x040005D9 RID: 1497
            STYPE_WHEELED_ARTILLERY,
            // Token: 0x040005DA RID: 1498
            STYPE_WHEELED_ENGINEER,
            // Token: 0x040005DB RID: 1499
            STYPE_WHEELED_FIRETRUCK,
            // Token: 0x040005DC RID: 1500
            STYPE_WHEELED_HQ,
            // Token: 0x040005DD RID: 1501
            STYPE_WHEELED_IFV,
            // Token: 0x040005DE RID: 1502
            STYPE_WHEELED_TRANSPORT,
            // Token: 0x040005DF RID: 1503
            STYPE_AMPHIBIOUS = 1,
            // Token: 0x040005E0 RID: 1504
            STYPE_WASP,
            // Token: 0x040005E1 RID: 1505
            STYPE_NEWPORT = 4,
            // Token: 0x040005E2 RID: 1506
            STYPE_MISSILE_BOAT = 1,
            // Token: 0x040005E3 RID: 1507
            STYPE_BATTLESHIP = 1,
            // Token: 0x040005E4 RID: 1508
            STYPE_CARRIER,
            // Token: 0x040005E5 RID: 1509
            STYPE_AMMOSHIP = 1,
            // Token: 0x040005E6 RID: 1510
            STYPE_CSHIP1,
            // Token: 0x040005E7 RID: 1511
            STYPE_CSHIP2 = 5,
            // Token: 0x040005E8 RID: 1512
            STYPE_CSHIP3,
            // Token: 0x040005E9 RID: 1513
            STYPE_CSHIP4,
            // Token: 0x040005EA RID: 1514
            STYPE_CRUISER = 1,
            // Token: 0x040005EB RID: 1515
            STYPE_SPRUANCE,
            // Token: 0x040005EC RID: 1516
            STYPE_FRIGATE = 1,
            // Token: 0x040005ED RID: 1517
            STYPE_PATROL_BOAT = 1,
            // Token: 0x040005EE RID: 1518
            STYPE_LIFE_RAFT = 1,
            // Token: 0x040005EF RID: 1519
            STYPE_TANKER = 1,
            // Token: 0x040005F0 RID: 1520
            STYPE_SEA_SUPPLY = 1,
            // Token: 0x040005F1 RID: 1521
            STYPE_SEA_TRANSPORT,
            // Token: 0x040005F2 RID: 1522
            STYPE_SSBN = 1,
            // Token: 0x040005F3 RID: 1523
            STYPE_SSGN,
            // Token: 0x040005F4 RID: 1524
            STYPE_SSN,
            // Token: 0x040005F5 RID: 1525
            STYPE_TORPEDO = 1,
            // Token: 0x040005F6 RID: 1526
            STYPE_DEPTHCHARGE = 1,
            // Token: 0x040005F7 RID: 1527
            STYPE_FACTORY1_SHIP = 10,
            // Token: 0x040005F8 RID: 1528
            STYPE_BOMB = 1,
            // Token: 0x040005F9 RID: 1529
            STYPE_BOMB_GUIDED,
            // Token: 0x040005FA RID: 1530
            STYPE_BOMB_IRON,
            // Token: 0x040005FB RID: 1531
            STYPE_BOMB_GPS,
            // Token: 0x040005FC RID: 1532
            STYPE_BOMB_WCMD,
            // Token: 0x040005FD RID: 1533
            STYPE_MISSILE_AIR_AIR = 1,
            // Token: 0x040005FE RID: 1534
            STYPE_MISSILE_AIR_GROUND,
            // Token: 0x040005FF RID: 1535
            STYPE_MISSILE_ANTI_SHIP,
            // Token: 0x04000600 RID: 1536
            STYPE_MISSILE_SURF_AIR = 5,
            // Token: 0x04000601 RID: 1537
            STYPE_MISSILE_SURF_SURF,
            // Token: 0x04000602 RID: 1538
            STYPE_POD_ECM = 1,
            // Token: 0x04000603 RID: 1539
            STYPE_POD_CM_BOTH,
            // Token: 0x04000604 RID: 1540
            STYPE_POD_CM_FLARE,
            // Token: 0x04000605 RID: 1541
            STYPE_POD_CM_CHAFF,
            // Token: 0x04000606 RID: 1542
            STYPE_POD_TGT,
            // Token: 0x04000607 RID: 1543
            STYPE_POD_LD,
            // Token: 0x04000608 RID: 1544
            STYPE_POD_FLIR,
            // Token: 0x04000609 RID: 1545
            STYPE_POD_NAV,
            // Token: 0x0400060A RID: 1546
            STYPE_POD_ACMI,
            // Token: 0x0400060B RID: 1547
            STYPE_POD_DATALINK,
            // Token: 0x0400060C RID: 1548
            STYPE_POD_ELS,
            // Token: 0x0400060D RID: 1549
            STYPE_POD_ELINT,
            // Token: 0x0400060E RID: 1550
            STYPE_POD_SMOKE,
            // Token: 0x0400060F RID: 1551
            STYPE_RACK = 1,
            // Token: 0x04000610 RID: 1552
            STYPE_CAMERA = 1,
            // Token: 0x04000611 RID: 1553
            STYPE_CHAFF = 1,
            // Token: 0x04000612 RID: 1554
            STYPE_FUEL_TANK = 1,
            // Token: 0x04000613 RID: 1555
            STYPE_ROCKET,
            // Token: 0x04000614 RID: 1556
            STYPE_AAA_GUN = 1,
            // Token: 0x04000615 RID: 1557
            STYPE_SMALLARMS,
            // Token: 0x04000616 RID: 1558
            STYPE_ARTILLERY,
            // Token: 0x04000617 RID: 1559
            STYPE_GUN,
            // Token: 0x04000618 RID: 1560
            STYPE_MORTAR,
            // Token: 0x04000619 RID: 1561
            STYPE_TAIL_GUN,
            // Token: 0x0400061A RID: 1562
            STYPE_CG = 1,
            // Token: 0x0400061B RID: 1563
            STYPE_COCKPIT = 1,
            // Token: 0x0400061C RID: 1564
            STYPE_F16PIT,
            // Token: 0x0400061D RID: 1565
            STYPE_F16PIT_MP,
            // Token: 0x0400061E RID: 1566
            STYPE_CANOPY1 = 1,
            // Token: 0x0400061F RID: 1567
            STYPE_EJECT1 = 1,
            // Token: 0x04000620 RID: 1568
            STYPE_EJECT2,
            // Token: 0x04000621 RID: 1569
            STYPE_EJECT3,
            // Token: 0x04000622 RID: 1570
            STYPE_EJECT4 = 3,
            // Token: 0x04000623 RID: 1571
            STYPE_DEBRIS = 1,
            // Token: 0x04000624 RID: 1572
            STYPE_DECK = 1,
            // Token: 0x04000625 RID: 1573
            STYPE_DUST1 = 1,
            // Token: 0x04000626 RID: 1574
            STYPE_ENG_FIRE,
            // Token: 0x04000627 RID: 1575
            STYPE_FIRE1,
            // Token: 0x04000628 RID: 1576
            STYPE_FIREBALL = 3,
            // Token: 0x04000629 RID: 1577
            STYPE_FLARE1 = 1,
            // Token: 0x0400062A RID: 1578
            STYPE_MAYDAY = 1,
            // Token: 0x0400062B RID: 1579
            STYPE_MFLAME_L = 1,
            // Token: 0x0400062C RID: 1580
            STYPE_MFLAME_S,
            // Token: 0x0400062D RID: 1581
            STYPE_WEXPLOSION1 = 1,
            // Token: 0x0400062E RID: 1582
            STYPE_LEXPLOSION1 = 3,
            // Token: 0x0400062F RID: 1583
            STYPE_AEXPLOSION2 = 1,
            // Token: 0x04000630 RID: 1584
            STYPE_AEXPLOSION1,
            // Token: 0x04000631 RID: 1585
            STYPE_MISS_FLAME = 1,
            // Token: 0x04000632 RID: 1586
            STYPE_MISS_LAUN = 1,
            // Token: 0x04000633 RID: 1587
            STYPE_PUFFY,
            // Token: 0x04000634 RID: 1588
            STYPE_SAM_LAUN = 2,
            // Token: 0x04000635 RID: 1589
            STYPE_SECONDARY1 = 1,
            // Token: 0x04000636 RID: 1590
            STYPE_SECONDARY2,
            // Token: 0x04000637 RID: 1591
            STYPE_SMOKESTACK1 = 1,
            // Token: 0x04000638 RID: 1592
            STYPE_TANK_HULK,
            // Token: 0x04000639 RID: 1593
            STYPE_GEARING = 1,
            // Token: 0x0400063A RID: 1594
            STYPE_FOOT_SQUAD = 1,
            // Token: 0x0400063B RID: 1595
            STYPE_FACTORY1L = 8,
            // Token: 0x0400063C RID: 1596
            STYPE_FACTORY1R,
            // Token: 0x0400063D RID: 1597
            STYPE_POPMENU = 1,
            // Token: 0x0400063E RID: 1598
            STYPE_MINESWPBLADE = 1,
            // Token: 0x0400063F RID: 1599
            STYPE_PLOT_F01_04 = 3,
            // Token: 0x04000640 RID: 1600
            STYPE_PLOT_F01_05,
            // Token: 0x04000641 RID: 1601
            STYPE_REL_VALVE1 = 3,
            // Token: 0x04000642 RID: 1602
            STYPE_PROC_TANK1 = 5,
            // Token: 0x04000643 RID: 1603
            STYPE_TEST = 1,
            // Token: 0x04000644 RID: 1604
            STYPE_CNC_TILE1 = 1,
            // Token: 0x04000645 RID: 1605
            STYPE_CNC1 = 3,
            // Token: 0x04000646 RID: 1606
            STYPE_HANG_TILE1 = 2,
            // Token: 0x04000647 RID: 1607
            STYPE_ADMIN1 = 1,
            // Token: 0x04000648 RID: 1608
            STYPE_ADMIN02,
            // Token: 0x04000649 RID: 1609
            STYPE_AIRBASE1 = 1,
            // Token: 0x0400064A RID: 1610
            STYPE_AIRBASE2,
            // Token: 0x0400064B RID: 1611
            STYPE_AIRBASE_501,
            // Token: 0x0400064C RID: 1612
            STYPE_AIRBASE_510,
            // Token: 0x0400064D RID: 1613
            STYPE_AIRBASE_560,
            // Token: 0x0400064E RID: 1614
            STYPE_AIRBASE_505 = 5,
            // Token: 0x0400064F RID: 1615
            STYPE_20_02ABASE2 = 1,
            // Token: 0x04000650 RID: 1616
            STYPE_AIRSTRIPH,
            // Token: 0x04000651 RID: 1617
            STYPE_02_20ABASE2 = 2,
            // Token: 0x04000652 RID: 1618
            STYPE_34_16ABASE2,
            // Token: 0x04000653 RID: 1619
            STYPE_01_19ABASE,
            // Token: 0x04000654 RID: 1620
            STYPE_NSEOUL = 4,
            // Token: 0x04000655 RID: 1621
            STYPE_DTSEOUL,
            // Token: 0x04000656 RID: 1622
            STYPE_SUNAN,
            // Token: 0x04000657 RID: 1623
            STYPE_SEOULAFB,
            // Token: 0x04000658 RID: 1624
            STYPE_GEN_AFB,
            // Token: 0x04000659 RID: 1625
            STYPE_KIMPO,
            // Token: 0x0400065A RID: 1626
            STYPE_05_23ABASE2,
            // Token: 0x0400065B RID: 1627
            STYPE_20_02ABASE = 10,
            // Token: 0x0400065C RID: 1628
            STYPE_02_20ABASE,
            // Token: 0x0400065D RID: 1629
            STYPE_08_26ABASE,
            // Token: 0x0400065E RID: 1630
            STYPE_11_29ABASE,
            // Token: 0x0400065F RID: 1631
            STYPE_12_30ABASE,
            // Token: 0x04000660 RID: 1632
            STYPE_20_02ABASE1,
            // Token: 0x04000661 RID: 1633
            STYPE_21_03ABASE,
            // Token: 0x04000662 RID: 1634
            STYPE_23_05ABASE,
            // Token: 0x04000663 RID: 1635
            STYPE_26_08ABASE,
            // Token: 0x04000664 RID: 1636
            STYPE_30_12ABASE,
            // Token: 0x04000665 RID: 1637
            STYPE_32_14ABASE,
            // Token: 0x04000666 RID: 1638
            STYPE_34_16ABASE,
            // Token: 0x04000667 RID: 1639
            STYPE_36_18ABASE,
            // Token: 0x04000668 RID: 1640
            STYPE_SUWON,
            // Token: 0x04000669 RID: 1641
            STYPE_OSAN,
            // Token: 0x0400066A RID: 1642
            STYPE_MIRIM,
            // Token: 0x0400066B RID: 1643
            STYPE_OSANLIT = 9,
            // Token: 0x0400066C RID: 1644
            STYPE_1RWYLIT,
            // Token: 0x0400066D RID: 1645
            STYPE_2RWYLIT,
            // Token: 0x0400066E RID: 1646
            STYPE_KIMPOLIT,
            // Token: 0x0400066F RID: 1647
            STYPE_SEOULLIT,
            // Token: 0x04000670 RID: 1648
            STYPE_SUNANLIT,
            // Token: 0x04000671 RID: 1649
            STYPE_SUNANLIT2,
            // Token: 0x04000672 RID: 1650
            STYPE_WONSANLIT,
            // Token: 0x04000673 RID: 1651
            STYPE_RWYDIST4 = 3,
            // Token: 0x04000674 RID: 1652
            STYPE_RWYDIST3,
            // Token: 0x04000675 RID: 1653
            STYPE_RWYDIST2,
            // Token: 0x04000676 RID: 1654
            STYPE_RWYDIST1,
            // Token: 0x04000677 RID: 1655
            STYPE_RUNWAY_NUM = 41,
            // Token: 0x04000678 RID: 1656
            STYPE_THR160,
            // Token: 0x04000679 RID: 1657
            STYPE_HWYTAX1 = 1,
            // Token: 0x0400067A RID: 1658
            STYPE_TAXIOSAN,
            // Token: 0x0400067B RID: 1659
            STYPE_TAXI_01,
            // Token: 0x0400067C RID: 1660
            STYPE_TAXIS02,
            // Token: 0x0400067D RID: 1661
            STYPE_TAXIS03L,
            // Token: 0x0400067E RID: 1662
            STYPE_TAXIS03U,
            // Token: 0x0400067F RID: 1663
            STYPE_TAXIS04,
            // Token: 0x04000680 RID: 1664
            STYPE_TAXIS05,
            // Token: 0x04000681 RID: 1665
            STYPE_TAXIS06,
            // Token: 0x04000682 RID: 1666
            STYPE_AIRSTRIPV = 1,
            // Token: 0x04000683 RID: 1667
            STYPE_AMMO_DUMP1 = 1,
            // Token: 0x04000684 RID: 1668
            STYPE_APARTMENT1 = 1,
            // Token: 0x04000685 RID: 1669
            STYPE_APARTMENT2,
            // Token: 0x04000686 RID: 1670
            STYPE_APARTMENT4,
            // Token: 0x04000687 RID: 1671
            STYPE_APARTMENT5,
            // Token: 0x04000688 RID: 1672
            STYPE_APARTMENT6,
            // Token: 0x04000689 RID: 1673
            STYPE_APARTMENT3,
            // Token: 0x0400068A RID: 1674
            STYPE_APARTMENT7,
            // Token: 0x0400068B RID: 1675
            STYPE_ARMYBASE1 = 1,
            // Token: 0x0400068C RID: 1676
            STYPE_A52ARMB,
            // Token: 0x0400068D RID: 1677
            STYPE_252ARMB,
            // Token: 0x0400068E RID: 1678
            STYPE_251ARMB,
            // Token: 0x0400068F RID: 1679
            STYPE_A51ARMB,
            // Token: 0x04000690 RID: 1680
            STYPE_D52ARMB,
            // Token: 0x04000691 RID: 1681
            STYPE_D51ARMB,
            // Token: 0x04000692 RID: 1682
            STYPE_D35ARMB,
            // Token: 0x04000693 RID: 1683
            STYPE_D3AARMB,
            // Token: 0x04000694 RID: 1684
            STYPE_C0FARMB,
            // Token: 0x04000695 RID: 1685
            STYPE_141ARMB,
            // Token: 0x04000696 RID: 1686
            STYPE_D39ARMB,
            // Token: 0x04000697 RID: 1687
            STYPE_142ARMB,
            // Token: 0x04000698 RID: 1688
            STYPE_A0FARMB,
            // Token: 0x04000699 RID: 1689
            STYPE_A35ARMB,
            // Token: 0x0400069A RID: 1690
            STYPE_ART_SITE1 = 1,
            // Token: 0x0400069B RID: 1691
            STYPE_BARN1 = 1,
            // Token: 0x0400069C RID: 1692
            STYPE_BARN2,
            // Token: 0x0400069D RID: 1693
            STYPE_BARRACKS1 = 1,
            // Token: 0x0400069E RID: 1694
            STYPE_BARRACKS2,
            // Token: 0x0400069F RID: 1695
            STYPE_BEACH = 1,
            // Token: 0x040006A0 RID: 1696
            STYPE_BORDER = 1,
            // Token: 0x040006A1 RID: 1697
            STYPE_BRIDGE1 = 1,
            // Token: 0x040006A2 RID: 1698
            STYPE_BRIDGE2,
            // Token: 0x040006A3 RID: 1699
            STYPE_BRIDGE3,
            // Token: 0x040006A4 RID: 1700
            STYPE_BRIDGE4,
            // Token: 0x040006A5 RID: 1701
            STYPE_BRIDGE1_2,
            // Token: 0x040006A6 RID: 1702
            STYPE_BRIDGE1_4,
            // Token: 0x040006A7 RID: 1703
            STYPE_BRIDGE1_1,
            // Token: 0x040006A8 RID: 1704
            STYPE_BRIDGE2_3,
            // Token: 0x040006A9 RID: 1705
            STYPE_BRIDGE2_1,
            // Token: 0x040006AA RID: 1706
            STYPE_BRIDGE4_1 = 11,
            // Token: 0x040006AB RID: 1707
            STYPE_BRIDGE5_1,
            // Token: 0x040006AC RID: 1708
            STYPE_BRIDGE6_1,
            // Token: 0x040006AD RID: 1709
            STYPE_BRIDGE7_1,
            // Token: 0x040006AE RID: 1710
            STYPE_BRIDGE6_2,
            // Token: 0x040006AF RID: 1711
            STYPE_BRIDGE2_2,
            // Token: 0x040006B0 RID: 1712
            STYPE_BRIDGE6_3,
            // Token: 0x040006B1 RID: 1713
            STYPE_BRIDGE3_1,
            // Token: 0x040006B2 RID: 1714
            STYPE_BRIDGE1_1A,
            // Token: 0x040006B3 RID: 1715
            STYPE_BRIDGE1_2A,
            // Token: 0x040006B4 RID: 1716
            STYPE_BRIDGE1_X2,
            // Token: 0x040006B5 RID: 1717
            STYPE_BRIDGE1_X2A,
            // Token: 0x040006B6 RID: 1718
            STYPE_BRIDGE1_X3,
            // Token: 0x040006B7 RID: 1719
            STYPE_BRIDGE1_X3A,
            // Token: 0x040006B8 RID: 1720
            STYPE_BRIDGE2_1A,
            // Token: 0x040006B9 RID: 1721
            STYPE_BRIDGE2_2A,
            // Token: 0x040006BA RID: 1722
            STYPE_BRIDGE2_3A,
            // Token: 0x040006BB RID: 1723
            STYPE_BRIDGE3_1A,
            // Token: 0x040006BC RID: 1724
            STYPE_BRIDGE4_1A,
            // Token: 0x040006BD RID: 1725
            STYPE_BRIDGE4_X2,
            // Token: 0x040006BE RID: 1726
            STYPE_BRIDGE4_X2A,
            // Token: 0x040006BF RID: 1727
            STYPE_BRIDGE5_1A,
            // Token: 0x040006C0 RID: 1728
            STYPE_BRIDGE6_1A,
            // Token: 0x040006C1 RID: 1729
            STYPE_BRIDGE6_X2,
            // Token: 0x040006C2 RID: 1730
            STYPE_BRIDGE6_X2A,
            // Token: 0x040006C3 RID: 1731
            STYPE_BRIDGE7_1A,
            // Token: 0x040006C4 RID: 1732
            STYPE_SM_BRIDGE3 = 10,
            // Token: 0x040006C5 RID: 1733
            STYPE_BRIDGE_044_4 = 1,
            // Token: 0x040006C6 RID: 1734
            STYPE_BRIDGE_044_6,
            // Token: 0x040006C7 RID: 1735
            STYPE_BRIDGE_044_7,
            // Token: 0x040006C8 RID: 1736
            STYPE_BRIDGE_044_5,
            // Token: 0x040006C9 RID: 1737
            STYPE_BRIDGE_241_3,
            // Token: 0x040006CA RID: 1738
            STYPE_BRIDGE_242_3,
            // Token: 0x040006CB RID: 1739
            STYPE_BRIDGE_D41_3,
            // Token: 0x040006CC RID: 1740
            STYPE_BRIDGE_D42_3,
            // Token: 0x040006CD RID: 1741
            STYPE_BRIDGE_046_2,
            // Token: 0x040006CE RID: 1742
            STYPE_BRIDGE_046_3,
            // Token: 0x040006CF RID: 1743
            STYPE_BRIDGE_046_4,
            // Token: 0x040006D0 RID: 1744
            STYPE_BRIDGE_046_5,
            // Token: 0x040006D1 RID: 1745
            STYPE_BRIDGE_A41_3,
            // Token: 0x040006D2 RID: 1746
            STYPE_BRIDGE_A42_3,
            // Token: 0x040006D3 RID: 1747
            STYPE_BRIDGE_654_1,
            // Token: 0x040006D4 RID: 1748
            STYPE_BRIDGE_656_1,
            // Token: 0x040006D5 RID: 1749
            STYPE_BRIDGE_6E6_1,
            // Token: 0x040006D6 RID: 1750
            STYPE_BRIDGE_6E4_1,
            // Token: 0x040006D7 RID: 1751
            STYPE_BRIDGE_684_1,
            // Token: 0x040006D8 RID: 1752
            STYPE_BRIDGE_686_1,
            // Token: 0x040006D9 RID: 1753
            STYPE_BRIDGE_68B_1,
            // Token: 0x040006DA RID: 1754
            STYPE_BRIDGE_68D_1,
            // Token: 0x040006DB RID: 1755
            STYPE_BRIDGE_65B_1,
            // Token: 0x040006DC RID: 1756
            STYPE_BRIDGE_65D_1,
            // Token: 0x040006DD RID: 1757
            STYPE_BRIDGE_6EB_1,
            // Token: 0x040006DE RID: 1758
            STYPE_BRIDGE_6ED_1,
            // Token: 0x040006DF RID: 1759
            STYPE_BRIDGE_754_1,
            // Token: 0x040006E0 RID: 1760
            STYPE_BRIDGE_044_1,
            // Token: 0x040006E1 RID: 1761
            STYPE_BRIDGE_046_1,
            // Token: 0x040006E2 RID: 1762
            STYPE_BRIDGE_04B_1,
            // Token: 0x040006E3 RID: 1763
            STYPE_BRIDGE_04D_1,
            // Token: 0x040006E4 RID: 1764
            STYPE_BRIDGE_75D_1,
            // Token: 0x040006E5 RID: 1765
            STYPE_BRIDGE_624_1,
            // Token: 0x040006E6 RID: 1766
            STYPE_BRIDGE_626_1,
            // Token: 0x040006E7 RID: 1767
            STYPE_BRIDGE_62B_1,
            // Token: 0x040006E8 RID: 1768
            STYPE_BRIDGE_62D_1,
            // Token: 0x040006E9 RID: 1769
            STYPE_BRIDGE_044_2,
            // Token: 0x040006EA RID: 1770
            STYPE_BRIDGE_044_3,
            // Token: 0x040006EB RID: 1771
            STYPE_BRIDGE_046_6,
            // Token: 0x040006EC RID: 1772
            STYPE_BRIDGE_046_7,
            // Token: 0x040006ED RID: 1773
            STYPE_BRIDGE_04B_2,
            // Token: 0x040006EE RID: 1774
            STYPE_BRIDGE_04B_3,
            // Token: 0x040006EF RID: 1775
            STYPE_BRIDGE_04B_4,
            // Token: 0x040006F0 RID: 1776
            STYPE_BRIDGE_04B_5,
            // Token: 0x040006F1 RID: 1777
            STYPE_BRIDGE_04B_6,
            // Token: 0x040006F2 RID: 1778
            STYPE_BRIDGE_04B_7,
            // Token: 0x040006F3 RID: 1779
            STYPE_BRIDGE_04D_2,
            // Token: 0x040006F4 RID: 1780
            STYPE_BRIDGE_04D_3,
            // Token: 0x040006F5 RID: 1781
            STYPE_BRIDGE_04D_4,
            // Token: 0x040006F6 RID: 1782
            STYPE_BRIDGE_04D_6,
            // Token: 0x040006F7 RID: 1783
            STYPE_BRIDGE_04D_7,
            // Token: 0x040006F8 RID: 1784
            STYPE_BRIDGE_624_2,
            // Token: 0x040006F9 RID: 1785
            STYPE_BRIDGE_624_3,
            // Token: 0x040006FA RID: 1786
            STYPE_BRIDGE_624_4,
            // Token: 0x040006FB RID: 1787
            STYPE_BRIDGE_624_5,
            // Token: 0x040006FC RID: 1788
            STYPE_BRIDGE_624_6,
            // Token: 0x040006FD RID: 1789
            STYPE_BRIDGE_624_7,
            // Token: 0x040006FE RID: 1790
            STYPE_BRIDGE_62D_2,
            // Token: 0x040006FF RID: 1791
            STYPE_BRIDGE_62D_3,
            // Token: 0x04000700 RID: 1792
            STYPE_BRIDGE_62D_4,
            // Token: 0x04000701 RID: 1793
            STYPE_BRIDGE_62D_5,
            // Token: 0x04000702 RID: 1794
            STYPE_BRIDGE_62D_6,
            // Token: 0x04000703 RID: 1795
            STYPE_BRIDGE_62D_7,
            // Token: 0x04000704 RID: 1796
            STYPE_BRIDGE_626_2,
            // Token: 0x04000705 RID: 1797
            STYPE_BRIDGE_626_3,
            // Token: 0x04000706 RID: 1798
            STYPE_BRIDGE_626_4,
            // Token: 0x04000707 RID: 1799
            STYPE_BRIDGE_626_5,
            // Token: 0x04000708 RID: 1800
            STYPE_BRIDGE_626_6,
            // Token: 0x04000709 RID: 1801
            STYPE_BRIDGE_626_7,
            // Token: 0x0400070A RID: 1802
            STYPE_BRIDGE_62B_2,
            // Token: 0x0400070B RID: 1803
            STYPE_BRIDGE_62B_4,
            // Token: 0x0400070C RID: 1804
            STYPE_BRIDGE_62B_3,
            // Token: 0x0400070D RID: 1805
            STYPE_BRIDGE_62B_5,
            // Token: 0x0400070E RID: 1806
            STYPE_BRIDGE_62B_6,
            // Token: 0x0400070F RID: 1807
            STYPE_BRIDGE_62B_7,
            // Token: 0x04000710 RID: 1808
            STYPE_BRIDGE_654_2,
            // Token: 0x04000711 RID: 1809
            STYPE_BRIDGE_654_3,
            // Token: 0x04000712 RID: 1810
            STYPE_BRIDGE_654_4,
            // Token: 0x04000713 RID: 1811
            STYPE_BRIDGE_654_5,
            // Token: 0x04000714 RID: 1812
            STYPE_BRIDGE_654_6,
            // Token: 0x04000715 RID: 1813
            STYPE_BRIDGE_654_7,
            // Token: 0x04000716 RID: 1814
            STYPE_BRIDGE_656_2,
            // Token: 0x04000717 RID: 1815
            STYPE_BRIDGE_656_3,
            // Token: 0x04000718 RID: 1816
            STYPE_BRIDGE_656_4,
            // Token: 0x04000719 RID: 1817
            STYPE_BRIDGE_656_5,
            // Token: 0x0400071A RID: 1818
            STYPE_BRIDGE_656_6,
            // Token: 0x0400071B RID: 1819
            STYPE_BRIDGE_656_7,
            // Token: 0x0400071C RID: 1820
            STYPE_BRIDGE_65B_2,
            // Token: 0x0400071D RID: 1821
            STYPE_BRIDGE_65B_3,
            // Token: 0x0400071E RID: 1822
            STYPE_BRIDGE_65B_4,
            // Token: 0x0400071F RID: 1823
            STYPE_BRIDGE_65B_5,
            // Token: 0x04000720 RID: 1824
            STYPE_BRIDGE_65B_6,
            // Token: 0x04000721 RID: 1825
            STYPE_BRIDGE_65B_7,
            // Token: 0x04000722 RID: 1826
            STYPE_BRIDGE_65D_2,
            // Token: 0x04000723 RID: 1827
            STYPE_BRIDGE_65D_3,
            // Token: 0x04000724 RID: 1828
            STYPE_BRIDGE_65D_4,
            // Token: 0x04000725 RID: 1829
            STYPE_BRIDGE_65D_5,
            // Token: 0x04000726 RID: 1830
            STYPE_BRIDGE_65D_6,
            // Token: 0x04000727 RID: 1831
            STYPE_BRIDGE_65D_7,
            // Token: 0x04000728 RID: 1832
            STYPE_BRIDGE_684_2,
            // Token: 0x04000729 RID: 1833
            STYPE_BRIDGE_684_3,
            // Token: 0x0400072A RID: 1834
            STYPE_BRIDGE_684_4 = 103,
            // Token: 0x0400072B RID: 1835
            STYPE_BRIDGE_684_6,
            // Token: 0x0400072C RID: 1836
            STYPE_BRIDGE_686_2 = 102,
            // Token: 0x0400072D RID: 1837
            STYPE_BRIDGE_686_3 = 105,
            // Token: 0x0400072E RID: 1838
            STYPE_BRIDGE_686_4,
            // Token: 0x0400072F RID: 1839
            STYPE_BRIDGE_686_5,
            // Token: 0x04000730 RID: 1840
            STYPE_BRIDGE_686_6,
            // Token: 0x04000731 RID: 1841
            STYPE_BRIDGE_68B_2 = 110,
            // Token: 0x04000732 RID: 1842
            STYPE_BRIDGE_68B_3 = 109,
            // Token: 0x04000733 RID: 1843
            STYPE_BRIDGE_68B_4 = 111,
            // Token: 0x04000734 RID: 1844
            STYPE_BRIDGE_68B_5,
            // Token: 0x04000735 RID: 1845
            STYPE_BRIDGE_68B_6,
            // Token: 0x04000736 RID: 1846
            STYPE_BRIDGE_68D_2 = 115,
            // Token: 0x04000737 RID: 1847
            STYPE_BRIDGE_68D_3 = 114,
            // Token: 0x04000738 RID: 1848
            STYPE_BRIDGE_68D_4 = 116,
            // Token: 0x04000739 RID: 1849
            STYPE_BRIDGE_68D_6 = 118,
            // Token: 0x0400073A RID: 1850
            STYPE_BRIDGE_6E4_2 = 117,
            // Token: 0x0400073B RID: 1851
            STYPE_BRIDGE_6E4_3 = 119,
            // Token: 0x0400073C RID: 1852
            STYPE_BRIDGE_6E4_4,
            // Token: 0x0400073D RID: 1853
            STYPE_BRIDGE_6E4_5 = 122,
            // Token: 0x0400073E RID: 1854
            STYPE_BRIDGE_6E4_6 = 121,
            // Token: 0x0400073F RID: 1855
            STYPE_BRIDGE_6E4_7 = 123,
            // Token: 0x04000740 RID: 1856
            STYPE_BRIDGE_6E6_2,
            // Token: 0x04000741 RID: 1857
            STYPE_BRIDGE_6E6_3,
            // Token: 0x04000742 RID: 1858
            STYPE_BRIDGE_6E6_4,
            // Token: 0x04000743 RID: 1859
            STYPE_BRIDGE_6E6_6,
            // Token: 0x04000744 RID: 1860
            STYPE_BRIDGE_6E6_5,
            // Token: 0x04000745 RID: 1861
            STYPE_BRIDGE_6E6_7,
            // Token: 0x04000746 RID: 1862
            STYPE_BRIDGE_6EB_2,
            // Token: 0x04000747 RID: 1863
            STYPE_BRIDGE_6EB_3,
            // Token: 0x04000748 RID: 1864
            STYPE_BRIDGE_6EB_4,
            // Token: 0x04000749 RID: 1865
            STYPE_BRIDGE_6EB_5,
            // Token: 0x0400074A RID: 1866
            STYPE_BRIDGE_6EB_6,
            // Token: 0x0400074B RID: 1867
            STYPE_BRIDGE_6EB_7,
            // Token: 0x0400074C RID: 1868
            STYPE_BRIDGE_6ED_2,
            // Token: 0x0400074D RID: 1869
            STYPE_BRIDGE_6ED_3,
            // Token: 0x0400074E RID: 1870
            STYPE_BRIDGE_6ED_4,
            // Token: 0x0400074F RID: 1871
            STYPE_BRIDGE_6ED_5,
            // Token: 0x04000750 RID: 1872
            STYPE_BRIDGE_6ED_6,
            // Token: 0x04000751 RID: 1873
            STYPE_BRIDGE_6ED_7,
            // Token: 0x04000752 RID: 1874
            STYPE_BRIDGE_754_2,
            // Token: 0x04000753 RID: 1875
            STYPE_BRIDGE_754_3,
            // Token: 0x04000754 RID: 1876
            STYPE_BRIDGE_754_4,
            // Token: 0x04000755 RID: 1877
            STYPE_BRIDGE_754_5,
            // Token: 0x04000756 RID: 1878
            STYPE_BRIDGE_754_6,
            // Token: 0x04000757 RID: 1879
            STYPE_BRIDGE_754_7,
            // Token: 0x04000758 RID: 1880
            STYPE_BRIDGE_75D_2,
            // Token: 0x04000759 RID: 1881
            STYPE_BRIDGE_75D_3,
            // Token: 0x0400075A RID: 1882
            STYPE_BRIDGE_75D_4,
            // Token: 0x0400075B RID: 1883
            STYPE_BRIDGE_75D_5,
            // Token: 0x0400075C RID: 1884
            STYPE_BRIDGE_75D_6,
            // Token: 0x0400075D RID: 1885
            STYPE_BRIDGE_75D_7,
            // Token: 0x0400075E RID: 1886
            STYPE_B_131_1,
            // Token: 0x0400075F RID: 1887
            STYPE_B132_1,
            // Token: 0x04000760 RID: 1888
            STYPE_B_784_1,
            // Token: 0x04000761 RID: 1889
            STYPE_B_78B_1,
            // Token: 0x04000762 RID: 1890
            STYPE_BRIDGE_131_2,
            // Token: 0x04000763 RID: 1891
            STYPE_BRIDGE_131_3,
            // Token: 0x04000764 RID: 1892
            STYPE_BRIDGE_131_4,
            // Token: 0x04000765 RID: 1893
            STYPE_BRIDGE_132_2,
            // Token: 0x04000766 RID: 1894
            STYPE_BRIDGE_132_3,
            // Token: 0x04000767 RID: 1895
            STYPE_BRIDGE_132_4,
            // Token: 0x04000768 RID: 1896
            STYPE_BRIDGE_242_1,
            // Token: 0x04000769 RID: 1897
            STYPE_BRIDGE_241_1 = 6,
            // Token: 0x0400076A RID: 1898
            STYPE_BRIDGE_241_2 = 5,
            // Token: 0x0400076B RID: 1899
            STYPE_BRIDGE_241__3 = 165,
            // Token: 0x0400076C RID: 1900
            STYPE_BRIDGE_241_4,
            // Token: 0x0400076D RID: 1901
            STYPE_BRIDGE_242_2,
            // Token: 0x0400076E RID: 1902
            STYPE_BRIDGE_242__3,
            // Token: 0x0400076F RID: 1903
            STYPE_BRIDGE_242_4,
            // Token: 0x04000770 RID: 1904
            STYPE_BRIDGE_A42_1,
            // Token: 0x04000771 RID: 1905
            STYPE_BRIDGE_A41_1 = 14,
            // Token: 0x04000772 RID: 1906
            STYPE_BRIDGE_a41_2 = 13,
            // Token: 0x04000773 RID: 1907
            STYPE_BRIDGE_a41__3 = 171,
            // Token: 0x04000774 RID: 1908
            STYPE_BRIDGE_a41_4,
            // Token: 0x04000775 RID: 1909
            STYPE_BRIDGE_a42_2,
            // Token: 0x04000776 RID: 1910
            STYPE_BRIDGE_A42__3,
            // Token: 0x04000777 RID: 1911
            STYPE_BRIDGE_A42_4,
            // Token: 0x04000778 RID: 1912
            STYPE_BRIDGE_D41_1,
            // Token: 0x04000779 RID: 1913
            STYPE_BRIDGE_D41_2,
            // Token: 0x0400077A RID: 1914
            STYPE_BRIDGE_D41__3,
            // Token: 0x0400077B RID: 1915
            STYPE_BRIDGE_D41_4,
            // Token: 0x0400077C RID: 1916
            STYPE_BRIDGE_D42_1 = 178,
            // Token: 0x0400077D RID: 1917
            STYPE_BRIDGE_D42_2 = 180,
            // Token: 0x0400077E RID: 1918
            STYPE_BRIDGE_D42_4,
            // Token: 0x0400077F RID: 1919
            STYPE_B2AC_1,
            // Token: 0x04000780 RID: 1920
            STYPE_B2A3_1,
            // Token: 0x04000781 RID: 1921
            STYPE_BD2A_1,
            // Token: 0x04000782 RID: 1922
            STYPE_BUNKER1 = 1,
            // Token: 0x04000783 RID: 1923
            STYPE_BUNKER2,
            // Token: 0x04000784 RID: 1924
            STYPE_BUSH1 = 1,
            // Token: 0x04000785 RID: 1925
            STYPE_30FBURB1 = 1,
            // Token: 0x04000786 RID: 1926
            STYPE_307BURB1,
            // Token: 0x04000787 RID: 1927
            STYPE_30BBURB1,
            // Token: 0x04000788 RID: 1928
            STYPE_40FBURB1 = 6,
            // Token: 0x04000789 RID: 1929
            STYPE_835BURB1,
            // Token: 0x0400078A RID: 1930
            STYPE_80FBURB1 = 11,
            // Token: 0x0400078B RID: 1931
            STYPE_23ABURB1,
            // Token: 0x0400078C RID: 1932
            STYPE_ECFBURB1,
            // Token: 0x0400078D RID: 1933
            STYPE_237BURB1,
            // Token: 0x0400078E RID: 1934
            STYPE_83ABURB1,
            // Token: 0x0400078F RID: 1935
            STYPE_C2FBURB1 = 15,
            // Token: 0x04000790 RID: 1936
            STYPE_435BURB1,
            // Token: 0x04000791 RID: 1937
            STYPE_43BBURB1,
            // Token: 0x04000792 RID: 1938
            STYPE_437BURB1 = 19,
            // Token: 0x04000793 RID: 1939
            STYPE_30DBURB1 = 19,
            // Token: 0x04000794 RID: 1940
            STYPE_30EBURB1,
            // Token: 0x04000795 RID: 1941
            STYPE_E8BBURB1,
            // Token: 0x04000796 RID: 1942
            STYPE_E8EBURB1,
            // Token: 0x04000797 RID: 1943
            STYPE_EE7BURB1 = 25,
            // Token: 0x04000798 RID: 1944
            STYPE_EE4BURB1,
            // Token: 0x04000799 RID: 1945
            STYPE_303BURB1,
            // Token: 0x0400079A RID: 1946
            STYPE_B27BURB1,
            // Token: 0x0400079B RID: 1947
            STYPE_B2BBURB1,
            // Token: 0x0400079C RID: 1948
            STYPE_B2FBURB1,
            // Token: 0x0400079D RID: 1949
            STYPE_C27BURB1,
            // Token: 0x0400079E RID: 1950
            STYPE_C2ABURB1,
            // Token: 0x0400079F RID: 1951
            STYPE_C2BBURB1,
            // Token: 0x040007A0 RID: 1952
            STYPE_E8FBURB1,
            // Token: 0x040007A1 RID: 1953
            STYPE_EC2BURB1,
            // Token: 0x040007A2 RID: 1954
            STYPE_EC5BURB1,
            // Token: 0x040007A3 RID: 1955
            STYPE_ECABURB1,
            // Token: 0x040007A4 RID: 1956
            STYPE_ECDBURB1,
            // Token: 0x040007A5 RID: 1957
            STYPE_ECEBURB1,
            // Token: 0x040007A6 RID: 1958
            STYPE_EEDBURB1,
            // Token: 0x040007A7 RID: 1959
            STYPE_EEFBURB1,
            // Token: 0x040007A8 RID: 1960
            STYPE_D3FBURB1,
            // Token: 0x040007A9 RID: 1961
            STYPE_BUNKER3 = 3,
            // Token: 0x040007AA RID: 1962
            STYPE_40CCHEM = 1,
            // Token: 0x040007AB RID: 1963
            STYPE_304CHEM = 4,
            // Token: 0x040007AC RID: 1964
            STYPE_80ACHEM,
            // Token: 0x040007AD RID: 1965
            STYPE_817CHEM,
            // Token: 0x040007AE RID: 1966
            STYPE_84DCHEM,
            // Token: 0x040007AF RID: 1967
            STYPE_C28CHEM,
            // Token: 0x040007B0 RID: 1968
            STYPE_EC1CHEM,
            // Token: 0x040007B1 RID: 1969
            STYPE_EC2CHEM,
            // Token: 0x040007B2 RID: 1970
            STYPE_EC4CHEM,
            // Token: 0x040007B3 RID: 1971
            STYPE_D5ACHEM,
            // Token: 0x040007B4 RID: 1972
            STYPE_CHURCH1 = 1,
            // Token: 0x040007B5 RID: 1973
            STYPE_CHURCH2 = 3,
            // Token: 0x040007B6 RID: 1974
            STYPE_CITY_835 = 24,
            // Token: 0x040007B7 RID: 1975
            STYPE_C2F_CITY = 43,
            // Token: 0x040007B8 RID: 1976
            STYPE_307_CITY,
            // Token: 0x040007B9 RID: 1977
            STYPE_81E_CITY,
            // Token: 0x040007BA RID: 1978
            STYPE_41E_CITY,
            // Token: 0x040007BB RID: 1979
            STYPE_817_CITY,
            // Token: 0x040007BC RID: 1980
            STYPE_CITY_HALL1 = 1,
            // Token: 0x040007BD RID: 1981
            STYPE_CITY_HALL2,
            // Token: 0x040007BE RID: 1982
            STYPE_COM_CONTROL1 = 1,
            // Token: 0x040007BF RID: 1983
            STYPE_CONT_DOME1 = 1,
            // Token: 0x040007C0 RID: 1984
            STYPE_CTRL_TOWER1 = 1,
            // Token: 0x040007C1 RID: 1985
            STYPE_CTRL_TOWER2,
            // Token: 0x040007C2 RID: 1986
            STYPE_COOL_TWR1 = 1,
            // Token: 0x040007C3 RID: 1987
            STYPE_COOLT2 = 8,
            // Token: 0x040007C4 RID: 1988
            STYPE_CRANE1 = 4,
            // Token: 0x040007C5 RID: 1989
            STYPE_CRATER1 = 1,
            // Token: 0x040007C6 RID: 1990
            STYPE_CRATER,
            // Token: 0x040007C7 RID: 1991
            STYPE_CRACKER1 = 1,
            // Token: 0x040007C8 RID: 1992
            STYPE_CRACKER2,
            // Token: 0x040007C9 RID: 1993
            STYPE_DEPOT1 = 1,
            // Token: 0x040007CA RID: 1994
            STYPE_DEPOT2,
            // Token: 0x040007CB RID: 1995
            STYPE_DEPOT1_F,
            // Token: 0x040007CC RID: 1996
            STYPE_DEPOT2_F,
            // Token: 0x040007CD RID: 1997
            STYPE_D35DEPOT = 3,
            // Token: 0x040007CE RID: 1998
            STYPE_322DEPOT,
            // Token: 0x040007CF RID: 1999
            STYPE_D3BDEPOT,
            // Token: 0x040007D0 RID: 2000
            STYPE_402DEPOT = 5,
            // Token: 0x040007D1 RID: 2001
            STYPE_40CDEPOT,
            // Token: 0x040007D2 RID: 2002
            STYPE_84BDEPOT,
            // Token: 0x040007D3 RID: 2003
            STYPE_ECADEPOT,
            // Token: 0x040007D4 RID: 2004
            STYPE_D31DEPOT,
            // Token: 0x040007D5 RID: 2005
            STYPE_D3ADEPOT,
            // Token: 0x040007D6 RID: 2006
            STYPE_D36DEPOT,
            // Token: 0x040007D7 RID: 2007
            STYPE_D3CDEPOT,
            // Token: 0x040007D8 RID: 2008
            STYPE_D79DEPOT,
            // Token: 0x040007D9 RID: 2009
            STYPE_125DEPOT,
            // Token: 0x040007DA RID: 2010
            STYPE_126DEPOT,
            // Token: 0x040007DB RID: 2011
            STYPE_12DDEPOT,
            // Token: 0x040007DC RID: 2012
            STYPE_A35DEPOT,
            // Token: 0x040007DD RID: 2013
            STYPE_A3BDEPOT,
            // Token: 0x040007DE RID: 2014
            STYPE_2A6DMZ = 3,
            // Token: 0x040007DF RID: 2015
            STYPE_2A4DMZ,
            // Token: 0x040007E0 RID: 2016
            STYPE_2ADDMZ = 2,
            // Token: 0x040007E1 RID: 2017
            STYPE_2ABDMZ = 5,
            // Token: 0x040007E2 RID: 2018
            STYPE_DOCK01 = 1,
            // Token: 0x040007E3 RID: 2019
            STYPE_DOCK02,
            // Token: 0x040007E4 RID: 2020
            STYPE_DOCK06,
            // Token: 0x040007E5 RID: 2021
            STYPE_DOCK07 = 6,
            // Token: 0x040007E6 RID: 2022
            STYPE_DOCK04,
            // Token: 0x040007E7 RID: 2023
            STYPE_DOCK05,
            // Token: 0x040007E8 RID: 2024
            STYPE_238FACT = 1,
            // Token: 0x040007E9 RID: 2025
            STYPE_232FACT,
            // Token: 0x040007EA RID: 2026
            STYPE_305FACT,
            // Token: 0x040007EB RID: 2027
            STYPE_DUGNDFACT,
            // Token: 0x040007EC RID: 2028
            STYPE_FAC_UNDER_1 = 4,
            // Token: 0x040007ED RID: 2029
            STYPE_41EFACT,
            // Token: 0x040007EE RID: 2030
            STYPE_444FACT,
            // Token: 0x040007EF RID: 2031
            STYPE_446FACT,
            // Token: 0x040007F0 RID: 2032
            STYPE_44BFACT,
            // Token: 0x040007F1 RID: 2033
            STYPE_322FACT,
            // Token: 0x040007F2 RID: 2034
            STYPE_324FACT,
            // Token: 0x040007F3 RID: 2035
            STYPE_328FACT,
            // Token: 0x040007F4 RID: 2036
            STYPE_403FACT,
            // Token: 0x040007F5 RID: 2037
            STYPE_405FACT,
            // Token: 0x040007F6 RID: 2038
            STYPE_40AFACT,
            // Token: 0x040007F7 RID: 2039
            STYPE_40CFACT,
            // Token: 0x040007F8 RID: 2040
            STYPE_417FACT,
            // Token: 0x040007F9 RID: 2041
            STYPE_418FACT,
            // Token: 0x040007FA RID: 2042
            STYPE_231FACT = 20,
            // Token: 0x040007FB RID: 2043
            STYPE_44DFACT,
            // Token: 0x040007FC RID: 2044
            STYPE_79CFACT,
            // Token: 0x040007FD RID: 2045
            STYPE_7A0FACT,
            // Token: 0x040007FE RID: 2046
            STYPE_801FACT,
            // Token: 0x040007FF RID: 2047
            STYPE_802FACT,
            // Token: 0x04000800 RID: 2048
            STYPE_803FACT,
            // Token: 0x04000801 RID: 2049
            STYPE_805FACT,
            // Token: 0x04000802 RID: 2050
            STYPE_UGNDFACT = 27,
            // Token: 0x04000803 RID: 2051
            STYPE_807FACT,
            // Token: 0x04000804 RID: 2052
            STYPE_80AFACT,
            // Token: 0x04000805 RID: 2053
            STYPE_80BFACT,
            // Token: 0x04000806 RID: 2054
            STYPE_817FACT,
            // Token: 0x04000807 RID: 2055
            STYPE_81EFACT,
            // Token: 0x04000808 RID: 2056
            STYPE_844FACT,
            // Token: 0x04000809 RID: 2057
            STYPE_846FACT,
            // Token: 0x0400080A RID: 2058
            STYPE_84BFACT,
            // Token: 0x0400080B RID: 2059
            STYPE_84DFACT,
            // Token: 0x0400080C RID: 2060
            STYPE_B28FACT,
            // Token: 0x0400080D RID: 2061
            STYPE_B2CFACT,
            // Token: 0x0400080E RID: 2062
            STYPE_C21FACT,
            // Token: 0x0400080F RID: 2063
            STYPE_C22FACT,
            // Token: 0x04000810 RID: 2064
            STYPE_C23FACT,
            // Token: 0x04000811 RID: 2065
            STYPE_C24FACT,
            // Token: 0x04000812 RID: 2066
            STYPE_C25FACT,
            // Token: 0x04000813 RID: 2067
            STYPE_C28FACT,
            // Token: 0x04000814 RID: 2068
            STYPE_C2BFACT,
            // Token: 0x04000815 RID: 2069
            STYPE_C2CFACT,
            // Token: 0x04000816 RID: 2070
            STYPE_D35FACT,
            // Token: 0x04000817 RID: 2071
            STYPE_D3AFACT,
            // Token: 0x04000818 RID: 2072
            STYPE_DA8FACT,
            // Token: 0x04000819 RID: 2073
            STYPE_E81FACT,
            // Token: 0x0400081A RID: 2074
            STYPE_E83FACT,
            // Token: 0x0400081B RID: 2075
            STYPE_E8AFACT,
            // Token: 0x0400081C RID: 2076
            STYPE_E8CFACT,
            // Token: 0x0400081D RID: 2077
            STYPE_EC1FACT,
            // Token: 0x0400081E RID: 2078
            STYPE_EC4FACT,
            // Token: 0x0400081F RID: 2079
            STYPE_EC5FACT,
            // Token: 0x04000820 RID: 2080
            STYPE_ECCFACT,
            // Token: 0x04000821 RID: 2081
            STYPE_EE1FACT,
            // Token: 0x04000822 RID: 2082
            STYPE_EE2FACT = 60,
            // Token: 0x04000823 RID: 2083
            STYPE_EE5FACT = 59,
            // Token: 0x04000824 RID: 2084
            STYPE_EE8FACT = 61,
            // Token: 0x04000825 RID: 2085
            STYPE_21DUGFACT,
            // Token: 0x04000826 RID: 2086
            STYPE_204UGNDFACT,
            // Token: 0x04000827 RID: 2087
            STYPE_23CUGNDFACT,
            // Token: 0x04000828 RID: 2088
            STYPE_202UGNDFACT,
            // Token: 0x04000829 RID: 2089
            STYPE_20FUGNDFACT,
            // Token: 0x0400082A RID: 2090
            STYPE_21CUGNDFACT,
            // Token: 0x0400082B RID: 2091
            STYPE_FENCE_NUKE2 = 1,
            // Token: 0x0400082C RID: 2092
            STYPE_FENCE1 = 3,
            // Token: 0x0400082D RID: 2093
            STYPE_FENCE2,
            // Token: 0x0400082E RID: 2094
            STYPE_FENCE3,
            // Token: 0x0400082F RID: 2095
            STYPE_FENCE4,
            // Token: 0x04000830 RID: 2096
            STYPE_FORD = 1,
            // Token: 0x04000831 RID: 2097
            STYPE_FORTIFICATION1 = 1,
            // Token: 0x04000832 RID: 2098
            STYPE_FUEL_TANK2 = 1,
            // Token: 0x04000833 RID: 2099
            STYPE_FUEL_TANK1,
            // Token: 0x04000834 RID: 2100
            STYPE_GUARDHOUSE1 = 1,
            // Token: 0x04000835 RID: 2101
            STYPE_HANGAR2 = 1,
            // Token: 0x04000836 RID: 2102
            STYPE_HANGAR3,
            // Token: 0x04000837 RID: 2103
            STYPE_HANGAR6,
            // Token: 0x04000838 RID: 2104
            STYPE_HANGAR8,
            // Token: 0x04000839 RID: 2105
            STYPE_HANGAR1,
            // Token: 0x0400083A RID: 2106
            STYPE_HANGAR7,
            // Token: 0x0400083B RID: 2107
            STYPE_HANGAR9,
            // Token: 0x0400083C RID: 2108
            STYPE_HANGAR10,
            // Token: 0x0400083D RID: 2109
            STYPE_HANGAR11,
            // Token: 0x0400083E RID: 2110
            STYPE_HANGAR12,
            // Token: 0x0400083F RID: 2111
            STYPE_HARTS1 = 1,
            // Token: 0x04000840 RID: 2112
            STYPE_HELIPAD1 = 1,
            // Token: 0x04000841 RID: 2113
            STYPE_HILL_TOP = 1,
            // Token: 0x04000842 RID: 2114
            STYPE_HOSPITAL01 = 1,
            // Token: 0x04000843 RID: 2115
            STYPE_HOSPITAL02,
            // Token: 0x04000844 RID: 2116
            STYPE_HOSPITAL03,
            // Token: 0x04000845 RID: 2117
            STYPE_HOTEL1 = 1,
            // Token: 0x04000846 RID: 2118
            STYPE_HOTEL02,
            // Token: 0x04000847 RID: 2119
            STYPE_HOUSE3 = 1,
            // Token: 0x04000848 RID: 2120
            STYPE_HOUSE4,
            // Token: 0x04000849 RID: 2121
            STYPE_HOUSE5,
            // Token: 0x0400084A RID: 2122
            STYPE_HOUSE2,
            // Token: 0x0400084B RID: 2123
            STYPE_HOUSE6,
            // Token: 0x0400084C RID: 2124
            STYPE_HOUSE7,
            // Token: 0x0400084D RID: 2125
            STYPE_HOUSE8,
            // Token: 0x0400084E RID: 2126
            STYPE_HOUSE9,
            // Token: 0x0400084F RID: 2127
            STYPE_HOUSE10,
            // Token: 0x04000850 RID: 2128
            STYPE_HOUSE11,
            // Token: 0x04000851 RID: 2129
            STYPE_HOUSE12,
            // Token: 0x04000852 RID: 2130
            STYPE_HOUSE1,
            // Token: 0x04000853 RID: 2131
            STYPE_D35HQ = 2,
            // Token: 0x04000854 RID: 2132
            STYPE_D5AHQ,
            // Token: 0x04000855 RID: 2133
            STYPE_14CHQ,
            // Token: 0x04000856 RID: 2134
            STYPE_JUNCTION1 = 1,
            // Token: 0x04000857 RID: 2135
            STYPE_J43E,
            // Token: 0x04000858 RID: 2136
            STYPE_J437,
            // Token: 0x04000859 RID: 2137
            STYPE_J43B,
            // Token: 0x0400085A RID: 2138
            STYPE_J43D,
            // Token: 0x0400085B RID: 2139
            STYPE_JA3F,
            // Token: 0x0400085C RID: 2140
            STYPE_J324,
            // Token: 0x0400085D RID: 2141
            STYPE_J40B,
            // Token: 0x0400085E RID: 2142
            STYPE_J435,
            // Token: 0x0400085F RID: 2143
            STYPE_J439,
            // Token: 0x04000860 RID: 2144
            STYPE_J444,
            // Token: 0x04000861 RID: 2145
            STYPE_J446,
            // Token: 0x04000862 RID: 2146
            STYPE_J83A,
            // Token: 0x04000863 RID: 2147
            STYPE_J844,
            // Token: 0x04000864 RID: 2148
            STYPE_J235,
            // Token: 0x04000865 RID: 2149
            STYPE_JA35,
            // Token: 0x04000866 RID: 2150
            STYPE_JA37,
            // Token: 0x04000867 RID: 2151
            STYPE_JA3A,
            // Token: 0x04000868 RID: 2152
            STYPE_JA3B,
            // Token: 0x04000869 RID: 2153
            STYPE_JA3D,
            // Token: 0x0400086A RID: 2154
            STYPE_JA3E,
            // Token: 0x0400086B RID: 2155
            STYPE_JD37,
            // Token: 0x0400086C RID: 2156
            STYPE_JD39,
            // Token: 0x0400086D RID: 2157
            STYPE_JD3B,
            // Token: 0x0400086E RID: 2158
            STYPE_JD3D,
            // Token: 0x0400086F RID: 2159
            STYPE_JD3E,
            // Token: 0x04000870 RID: 2160
            STYPE_JEC1,
            // Token: 0x04000871 RID: 2161
            STYPE_137_JUNCT,
            // Token: 0x04000872 RID: 2162
            STYPE_12E_JCT,
            // Token: 0x04000873 RID: 2163
            STYPE_12D_JCT,
            // Token: 0x04000874 RID: 2164
            STYPE_138_JCT,
            // Token: 0x04000875 RID: 2165
            STYPE_127_JCT,
            // Token: 0x04000876 RID: 2166
            STYPE_12A_JCT,
            // Token: 0x04000877 RID: 2167
            STYPE_12B_JCT,
            // Token: 0x04000878 RID: 2168
            STYPE_125_JCT,
            // Token: 0x04000879 RID: 2169
            STYPE_NAV1 = 1,
            // Token: 0x0400087A RID: 2170
            STYPE_NAV_BEACON1 = 1,
            // Token: 0x0400087B RID: 2171
            STYPE_NUCLEAR1 = 1,
            // Token: 0x0400087C RID: 2172
            STYPE_NUCLEAR2,
            // Token: 0x0400087D RID: 2173
            STYPE_14DNUKE2 = 1,
            // Token: 0x0400087E RID: 2174
            STYPE_79BNUKE1,
            // Token: 0x0400087F RID: 2175
            STYPE_805NUKE1,
            // Token: 0x04000880 RID: 2176
            STYPE_817NUKE1,
            // Token: 0x04000881 RID: 2177
            STYPE_84BNUKE1,
            // Token: 0x04000882 RID: 2178
            STYPE_14DNUKE1,
            // Token: 0x04000883 RID: 2179
            STYPE_D35NUKE1,
            // Token: 0x04000884 RID: 2180
            STYPE_D3ANUKE1,
            // Token: 0x04000885 RID: 2181
            STYPE_D3BNUKE1,
            // Token: 0x04000886 RID: 2182
            STYPE_D3CNUKE2,
            // Token: 0x04000887 RID: 2183
            STYPE_D5ANUKE1,
            // Token: 0x04000888 RID: 2184
            STYPE_D5ANUKE2,
            // Token: 0x04000889 RID: 2185
            STYPE_D89NUKE1,
            // Token: 0x0400088A RID: 2186
            STYPE_DA7NUKE1,
            // Token: 0x0400088B RID: 2187
            STYPE_EE1NUKE1,
            // Token: 0x0400088C RID: 2188
            STYPE_EE2NUKE1,
            // Token: 0x0400088D RID: 2189
            STYPE_D5CNUKE1,
            // Token: 0x0400088E RID: 2190
            STYPE_PYONGNUKE,
            // Token: 0x0400088F RID: 2191
            STYPE_NUKE_PLANT1 = 1,
            // Token: 0x04000890 RID: 2192
            STYPE_NUKE_PLANT2,
            // Token: 0x04000891 RID: 2193
            STYPE_OFFICE3 = 1,
            // Token: 0x04000892 RID: 2194
            STYPE_OFFICE2 = 3,
            // Token: 0x04000893 RID: 2195
            STYPE_OFFICE1,
            // Token: 0x04000894 RID: 2196
            STYPE_OFFICE7,
            // Token: 0x04000895 RID: 2197
            STYPE_OFFICE4,
            // Token: 0x04000896 RID: 2198
            STYPE_OFFICE5,
            // Token: 0x04000897 RID: 2199
            STYPE_OFFICE6,
            // Token: 0x04000898 RID: 2200
            STYPE_OFFICE8,
            // Token: 0x04000899 RID: 2201
            STYPE_OFFICE9 = 12,
            // Token: 0x0400089A RID: 2202
            STYPE_OFFICE10,
            // Token: 0x0400089B RID: 2203
            STYPE_OFFICE11,
            // Token: 0x0400089C RID: 2204
            STYPE_OFFICE12,
            // Token: 0x0400089D RID: 2205
            STYPE_OFFICE13,
            // Token: 0x0400089E RID: 2206
            STYPE_OFFICE14,
            // Token: 0x0400089F RID: 2207
            STYPE_OFFICE15,
            // Token: 0x040008A0 RID: 2208
            STYPE_OFFICE16,
            // Token: 0x040008A1 RID: 2209
            STYPE_OFFICE17,
            // Token: 0x040008A2 RID: 2210
            STYPE_OFFICE18,
            // Token: 0x040008A3 RID: 2211
            STYPE_OFFICE19,
            // Token: 0x040008A4 RID: 2212
            STYPE_OFFICE20,
            // Token: 0x040008A5 RID: 2213
            STYPE_OFFICE21,
            // Token: 0x040008A6 RID: 2214
            STYPE_OFFICE22,
            // Token: 0x040008A7 RID: 2215
            STYPE_OFFICE23,
            // Token: 0x040008A8 RID: 2216
            STYPE_OFFICE24,
            // Token: 0x040008A9 RID: 2217
            STYPE_OFFICE25,
            // Token: 0x040008AA RID: 2218
            STYPE_OFFICE26,
            // Token: 0x040008AB RID: 2219
            STYPE_OFFICE_CHEM,
            // Token: 0x040008AC RID: 2220
            STYPE_OFF_BLOCK1 = 1,
            // Token: 0x040008AD RID: 2221
            STYPE_OFF_BLOCK2,
            // Token: 0x040008AE RID: 2222
            STYPE_OFF_BLOCK3,
            // Token: 0x040008AF RID: 2223
            STYPE_OFF_BLOCK4,
            // Token: 0x040008B0 RID: 2224
            STYPE_OFF_BLOCK5,
            // Token: 0x040008B1 RID: 2225
            STYPE_OFF_BLOCK6,
            // Token: 0x040008B2 RID: 2226
            STYPE_OFF_BLOCK7,
            // Token: 0x040008B3 RID: 2227
            STYPE_OFF_BLOCK8,
            // Token: 0x040008B4 RID: 2228
            STYPE_OFF_BLOCK9,
            // Token: 0x040008B5 RID: 2229
            STYPE_PARK1 = 1,
            // Token: 0x040008B6 RID: 2230
            STYPE_PARKINGLOT1 = 1,
            // Token: 0x040008B7 RID: 2231
            STYPE_PARKINGLOT2,
            // Token: 0x040008B8 RID: 2232
            STYPE_PASS = 1,
            // Token: 0x040008B9 RID: 2233
            STYPE_PIER1 = 1,
            // Token: 0x040008BA RID: 2234
            STYPE_PORT1 = 1,
            // Token: 0x040008BB RID: 2235
            STYPE_PORT_66B,
            // Token: 0x040008BC RID: 2236
            STYPE_00CPORT,
            // Token: 0x040008BD RID: 2237
            STYPE_66DPORT,
            // Token: 0x040008BE RID: 2238
            STYPE_731PORT,
            // Token: 0x040008BF RID: 2239
            STYPE_795PORT,
            // Token: 0x040008C0 RID: 2240
            STYPE_79APORT,
            // Token: 0x040008C1 RID: 2241
            STYPE_79BPORT,
            // Token: 0x040008C2 RID: 2242
            STYPE_79DPORT,
            // Token: 0x040008C3 RID: 2243
            STYPE_79EPORT,
            // Token: 0x040008C4 RID: 2244
            STYPE_7A0PORT,
            // Token: 0x040008C5 RID: 2245
            STYPE_7A1PORT,
            // Token: 0x040008C6 RID: 2246
            STYPE_7A2PORT,
            // Token: 0x040008C7 RID: 2247
            STYPE_7A5PORT,
            // Token: 0x040008C8 RID: 2248
            STYPE_7A6PORT,
            // Token: 0x040008C9 RID: 2249
            STYPE_6CEPORT,
            // Token: 0x040008CA RID: 2250
            STYPE_6CCPORT,
            // Token: 0x040008CB RID: 2251
            STYPE_798PORT,
            // Token: 0x040008CC RID: 2252
            STYPE_PPOLE1 = 1,
            // Token: 0x040008CD RID: 2253
            STYPE_PTOWER1 = 1,
            // Token: 0x040008CE RID: 2254
            STYPE_PPLANT1 = 1,
            // Token: 0x040008CF RID: 2255
            STYPE_RADAR1 = 1,
            // Token: 0x040008D0 RID: 2256
            STYPE_RADAR2,
            // Token: 0x040008D1 RID: 2257
            STYPE_RADAR3,
            // Token: 0x040008D2 RID: 2258
            STYPE_RADAR4,
            // Token: 0x040008D3 RID: 2259
            STYPE_RADAR5,
            // Token: 0x040008D4 RID: 2260
            STYPE_RADAR6,
            // Token: 0x040008D5 RID: 2261
            STYPE_RADAR7,
            // Token: 0x040008D6 RID: 2262
            STYPE_RADAR8,
            // Token: 0x040008D7 RID: 2263
            STYPE_RADAR_SITE1 = 1,
            // Token: 0x040008D8 RID: 2264
            STYPE_FEFRADAR,
            // Token: 0x040008D9 RID: 2265
            STYPE_D35RADAR,
            // Token: 0x040008DA RID: 2266
            STYPE_D3ARADAR,
            // Token: 0x040008DB RID: 2267
            STYPE_D48RADAR,
            // Token: 0x040008DC RID: 2268
            STYPE_20FRADAR,
            // Token: 0x040008DD RID: 2269
            STYPE_DEPOTONE = 9,
            // Token: 0x040008DE RID: 2270
            STYPE_21BRADAR = 7,
            // Token: 0x040008DF RID: 2271
            STYPE_RTOWER01 = 6,
            // Token: 0x040008E0 RID: 2272
            STYPE_21CRADAR = 8,
            // Token: 0x040008E1 RID: 2273
            STYPE_2DFRADAR,
            // Token: 0x040008E2 RID: 2274
            STYPE_F00RADAR,
            // Token: 0x040008E3 RID: 2275
            STYPE_F0FRADAR,
            // Token: 0x040008E4 RID: 2276
            STYPE_A34RADAR,
            // Token: 0x040008E5 RID: 2277
            STYPE_A3ERADAR,
            // Token: 0x040008E6 RID: 2278
            STYPE_BA2RADAR,
            // Token: 0x040008E7 RID: 2279
            STYPE_BA7RADAR,
            // Token: 0x040008E8 RID: 2280
            STYPE_BCFRADAR,
            // Token: 0x040008E9 RID: 2281
            STYPE_DA9RADAR,
            // Token: 0x040008EA RID: 2282
            STYPE_RADAR9 = 10,
            // Token: 0x040008EB RID: 2283
            STYPE_RADIO_TOWER1 = 1,
            // Token: 0x040008EC RID: 2284
            STYPE_RTOWER1 = 1,
            // Token: 0x040008ED RID: 2285
            STYPE_RTOWER2,
            // Token: 0x040008EE RID: 2286
            STYPE_RAIL_TERMINAL1 = 1,
            // Token: 0x040008EF RID: 2287
            STYPE_RAILROAD1 = 1,
            // Token: 0x040008F0 RID: 2288
            STYPE_REFINERY1 = 1,
            // Token: 0x040008F1 RID: 2289
            STYPE_REFINERY2,
            // Token: 0x040008F2 RID: 2290
            STYPE_436REFIN = 2,
            // Token: 0x040008F3 RID: 2291
            STYPE_807REFIN,
            // Token: 0x040008F4 RID: 2292
            STYPE_41EREFIN,
            // Token: 0x040008F5 RID: 2293
            STYPE_EC2REFIN,
            // Token: 0x040008F6 RID: 2294
            STYPE_ECAREFIN,
            // Token: 0x040008F7 RID: 2295
            STYPE_ROAD = 1,
            // Token: 0x040008F8 RID: 2296
            STYPE_4KRUNWAY = 5,
            // Token: 0x040008F9 RID: 2297
            STYPE_SAM1 = 1,
            // Token: 0x040008FA RID: 2298
            STYPE_24ESAM,
            // Token: 0x040008FB RID: 2299
            STYPE_D4FSAM,
            // Token: 0x040008FC RID: 2300
            STYPE_D4ESAM,
            // Token: 0x040008FD RID: 2301
            STYPE_A4FSAM,
            // Token: 0x040008FE RID: 2302
            STYPE_A4ESAM,
            // Token: 0x040008FF RID: 2303
            STYPE_24FSAM,
            // Token: 0x04000900 RID: 2304
            STYPE_SEA = 1,
            // Token: 0x04000901 RID: 2305
            STYPE_SEARCH_RADAR1 = 9,
            // Token: 0x04000902 RID: 2306
            STYPE_SHED1 = 1,
            // Token: 0x04000903 RID: 2307
            STYPE_SHED2,
            // Token: 0x04000904 RID: 2308
            STYPE_SHED3,
            // Token: 0x04000905 RID: 2309
            STYPE_SHED4,
            // Token: 0x04000906 RID: 2310
            STYPE_SHOP2 = 1,
            // Token: 0x04000907 RID: 2311
            STYPE_SHOP1,
            // Token: 0x04000908 RID: 2312
            STYPE_SHOP3,
            // Token: 0x04000909 RID: 2313
            STYPE_SHOP4,
            // Token: 0x0400090A RID: 2314
            STYPE_SHOP5,
            // Token: 0x0400090B RID: 2315
            STYPE_SHOP6,
            // Token: 0x0400090C RID: 2316
            STYPE_SHOP7,
            // Token: 0x0400090D RID: 2317
            STYPE_SHOPBLK01 = 1,
            // Token: 0x0400090E RID: 2318
            STYPE_SHOPBLK02,
            // Token: 0x0400090F RID: 2319
            STYPE_SHOPBLK03,
            // Token: 0x04000910 RID: 2320
            STYPE_SHOPBLK04,
            // Token: 0x04000911 RID: 2321
            STYPE_SHRINE1 = 1,
            // Token: 0x04000912 RID: 2322
            STYPE_SITE1 = 1,
            // Token: 0x04000913 RID: 2323
            STYPE_SKYSCRAPER1 = 10,
            // Token: 0x04000914 RID: 2324
            STYPE_SKYSCRAPER2,
            // Token: 0x04000915 RID: 2325
            STYPE_SMALL_CRATER = 1,
            // Token: 0x04000916 RID: 2326
            STYPE_SM_FACT1 = 5,
            // Token: 0x04000917 RID: 2327
            STYPE_SM_FACT2,
            // Token: 0x04000918 RID: 2328
            STYPE_SM_FACT3,
            // Token: 0x04000919 RID: 2329
            STYPE_STABLE1 = 3,
            // Token: 0x0400091A RID: 2330
            STYPE_STROBE_1 = 1,
            // Token: 0x0400091B RID: 2331
            STYPE_STROBE_2,
            // Token: 0x0400091C RID: 2332
            STYPE_TANK1 = 1,
            // Token: 0x0400091D RID: 2333
            STYPE_TANK2,
            // Token: 0x0400091E RID: 2334
            STYPE_TANK3,
            // Token: 0x0400091F RID: 2335
            STYPE_TANK4,
            // Token: 0x04000920 RID: 2336
            STYPE_TAXIWAY1 = 1,
            // Token: 0x04000921 RID: 2337
            STYPE_TAXIWAY2,
            // Token: 0x04000922 RID: 2338
            STYPE_TEMPLE1 = 2,
            // Token: 0x04000923 RID: 2339
            STYPE_TEMPLE2 = 4,
            // Token: 0x04000924 RID: 2340
            STYPE_TOWN_D47 = 1,
            // Token: 0x04000925 RID: 2341
            STYPE_TOWN_D48,
            // Token: 0x04000926 RID: 2342
            STYPE_TOWN_D37,
            // Token: 0x04000927 RID: 2343
            STYPE_TOWN_D3B,
            // Token: 0x04000928 RID: 2344
            STYPE_TOWN_D3D,
            // Token: 0x04000929 RID: 2345
            STYPE_TOWN_D3E,
            // Token: 0x0400092A RID: 2346
            STYPE_TOWN_D3F,
            // Token: 0x0400092B RID: 2347
            STYPE_EED_TOWN,
            // Token: 0x0400092C RID: 2348
            STYPE_EEF_TOWN,
            // Token: 0x0400092D RID: 2349
            STYPE_ECF_TOWN,
            // Token: 0x0400092E RID: 2350
            STYPE_EC1_TOWN,
            // Token: 0x0400092F RID: 2351
            STYPE_D35_TOWN,
            // Token: 0x04000930 RID: 2352
            STYPE_D3A_TOWN,
            // Token: 0x04000931 RID: 2353
            STYPE_237_TOWN,
            // Token: 0x04000932 RID: 2354
            STYPE_23A_TOWN,
            // Token: 0x04000933 RID: 2355
            STYPE_23B_TOWN,
            // Token: 0x04000934 RID: 2356
            STYPE_23D_TOWN,
            // Token: 0x04000935 RID: 2357
            STYPE_23E_TOWN,
            // Token: 0x04000936 RID: 2358
            STYPE_247_TOWN,
            // Token: 0x04000937 RID: 2359
            STYPE_248_TOWN,
            // Token: 0x04000938 RID: 2360
            STYPE_235_TOWN,
            // Token: 0x04000939 RID: 2361
            STYPE_A35_TOWN,
            // Token: 0x0400093A RID: 2362
            STYPE_A37_TOWN,
            // Token: 0x0400093B RID: 2363
            STYPE_A3A_TOWN,
            // Token: 0x0400093C RID: 2364
            STYPE_A3B_TOWN,
            // Token: 0x0400093D RID: 2365
            STYPE_A3D_TOWN,
            // Token: 0x0400093E RID: 2366
            STYPE_A3E_TOWN,
            // Token: 0x0400093F RID: 2367
            STYPE_A47_TOWN,
            // Token: 0x04000940 RID: 2368
            STYPE_A48_TOWN,
            // Token: 0x04000941 RID: 2369
            STYPE_C2F_TOWN,
            // Token: 0x04000942 RID: 2370
            STYPE_B2B_TOWN = 38,
            // Token: 0x04000943 RID: 2371
            STYPE_D38_TOWN = 31,
            // Token: 0x04000944 RID: 2372
            STYPE_446_TOWN,
            // Token: 0x04000945 RID: 2373
            STYPE_30D_TOWN,
            // Token: 0x04000946 RID: 2374
            STYPE_30E_TOWN,
            // Token: 0x04000947 RID: 2375
            STYPE_E8B_TOWN,
            // Token: 0x04000948 RID: 2376
            STYPE_E8E_TOWN,
            // Token: 0x04000949 RID: 2377
            STYPE_307_TOWN,
            // Token: 0x0400094A RID: 2378
            STYPE_B2F_TOWN = 39,
            // Token: 0x0400094B RID: 2379
            STYPE_137_TOWN,
            // Token: 0x0400094C RID: 2380
            STYPE_12E_TOWN,
            // Token: 0x0400094D RID: 2381
            STYPE_12D_TOWN = 43,
            // Token: 0x0400094E RID: 2382
            STYPE_138_TOWN,
            // Token: 0x0400094F RID: 2383
            STYPE_127_TOWN,
            // Token: 0x04000950 RID: 2384
            STYPE_12A_TOWN,
            // Token: 0x04000951 RID: 2385
            STYPE_12B_TOWN,
            // Token: 0x04000952 RID: 2386
            STYPE_125_TOWN,
            // Token: 0x04000953 RID: 2387
            STYPE_TRANSFORMER1 = 1,
            // Token: 0x04000954 RID: 2388
            STYPE_TREE2,
            // Token: 0x04000955 RID: 2389
            STYPE_TREE3,
            // Token: 0x04000956 RID: 2390
            STYPE_TREE4,
            // Token: 0x04000957 RID: 2391
            STYPE_TVSTN1 = 1,
            // Token: 0x04000958 RID: 2392
            STYPE_TWNHALL1 = 1,
            // Token: 0x04000959 RID: 2393
            STYPE_TREE1 = 1,
            // Token: 0x0400095A RID: 2394
            STYPE_VASI_N = 1,
            // Token: 0x0400095B RID: 2395
            STYPE_VASI_F,
            // Token: 0x0400095C RID: 2396
            STYPE_VASI_RB,
            // Token: 0x0400095D RID: 2397
            STYPE_VASI_RF,
            // Token: 0x0400095E RID: 2398
            STYPE_D37_VILLAGE = 1,
            // Token: 0x0400095F RID: 2399
            STYPE_D3F_VILLAGE,
            // Token: 0x04000960 RID: 2400
            STYPE_D3E_VILLAGE,
            // Token: 0x04000961 RID: 2401
            STYPE_D3B_VILLAGE,
            // Token: 0x04000962 RID: 2402
            STYPE_D3A_VILLAGE,
            // Token: 0x04000963 RID: 2403
            STYPE_D35_VILLAGE,
            // Token: 0x04000964 RID: 2404
            STYPE_234_VILLAGE,
            // Token: 0x04000965 RID: 2405
            STYPE_D39_VILLAGE,
            // Token: 0x04000966 RID: 2406
            STYPE_324_VILLAGE,
            // Token: 0x04000967 RID: 2407
            STYPE_A33_VILLAGE = 9,
            // Token: 0x04000968 RID: 2408
            STYPE_A3E_VILLAGE,
            // Token: 0x04000969 RID: 2409
            STYPE_235_VILLAGE,
            // Token: 0x0400096A RID: 2410
            STYPE_23A_VILLAGE,
            // Token: 0x0400096B RID: 2411
            STYPE_237_VILLAGE,
            // Token: 0x0400096C RID: 2412
            STYPE_D38_VILLAGE,
            // Token: 0x0400096D RID: 2413
            STYPE_23B_VILLAGE,
            // Token: 0x0400096E RID: 2414
            STYPE_23D_VILLAGE,
            // Token: 0x0400096F RID: 2415
            STYPE_23E_VILLAGE,
            // Token: 0x04000970 RID: 2416
            STYPE_A35_VILLAGE,
            // Token: 0x04000971 RID: 2417
            STYPE_A37_VILLAGE = 20,
            // Token: 0x04000972 RID: 2418
            STYPE_A3A_VILLAGE,
            // Token: 0x04000973 RID: 2419
            STYPE_A3B_VILLAGE,
            // Token: 0x04000974 RID: 2420
            STYPE_A3D_VILLAGE,
            // Token: 0x04000975 RID: 2421
            STYPE_A3F_VILLAGE,
            // Token: 0x04000976 RID: 2422
            STYPE_VILL_D3D,
            // Token: 0x04000977 RID: 2423
            STYPE_VILL_D37,
            // Token: 0x04000978 RID: 2424
            STYPE_137_VILLAGE,
            // Token: 0x04000979 RID: 2425
            STYPE_12E_VILLAGE,
            // Token: 0x0400097A RID: 2426
            STYPE_12D_VILLAGE,
            // Token: 0x0400097B RID: 2427
            STYPE_138_VILLAGE,
            // Token: 0x0400097C RID: 2428
            STYPE_127_VILLAGE,
            // Token: 0x0400097D RID: 2429
            STYPE_12A_VILLAGE,
            // Token: 0x0400097E RID: 2430
            STYPE_12B_VILLAGE,
            // Token: 0x0400097F RID: 2431
            STYPE_125_VILLAGE,
            // Token: 0x04000980 RID: 2432
            STYPE_WAREHOUSE2 = 1,
            // Token: 0x04000981 RID: 2433
            STYPE_WAREHOUSE1,
            // Token: 0x04000982 RID: 2434
            STYPE_WAREHOUSE3,
            // Token: 0x04000983 RID: 2435
            STYPE_WAREHOUSE4,
            // Token: 0x04000984 RID: 2436
            STYPE_WAREHOUSE5,
            // Token: 0x04000985 RID: 2437
            STYPE_WAREHOUSE_CHEM,
            // Token: 0x04000986 RID: 2438
            STYPE_WAREHOUSE_CHEM2,
            // Token: 0x04000987 RID: 2439
            STYPE_WTOWER1 = 1,
            // Token: 0x04000988 RID: 2440
            STYPE_WTOWER2,
            // Token: 0x04000989 RID: 2441
            STYPE_WTOWER3,
            // Token: 0x0400098A RID: 2442
            STYPE_WTOWER4,
            // Token: 0x0400098B RID: 2443
            STYPE_DAEWOO,
            // Token: 0x0400098C RID: 2444
            STYPE_AB1TL8 = 1,
            // Token: 0x0400098D RID: 2445
            STYPE_AB1TMD2,
            // Token: 0x0400098E RID: 2446
            STYPE_AB9TL5 = 7,
            // Token: 0x0400098F RID: 2447
            STYPE_AB6UTL1,
            // Token: 0x04000990 RID: 2448
            STYPE_AB6TL1,
            // Token: 0x04000991 RID: 2449
            STYPE_AB8TMD2 = 19,
            // Token: 0x04000992 RID: 2450
            STYPE_ABLTL1 = 19,
            // Token: 0x04000993 RID: 2451
            STYPE_AB1TL2,
            // Token: 0x04000994 RID: 2452
            STYPE_AB1TL3,
            // Token: 0x04000995 RID: 2453
            STYPE_AB1TL4,
            // Token: 0x04000996 RID: 2454
            STYPE_AB1TL5,
            // Token: 0x04000997 RID: 2455
            STYPE_AB1TL7,
            // Token: 0x04000998 RID: 2456
            STYPE_AB7TMD1,
            // Token: 0x04000999 RID: 2457
            STYPE_AB1TMD3,
            // Token: 0x0400099A RID: 2458
            STYPE_AB5TL1,
            // Token: 0x0400099B RID: 2459
            STYPE_AB5TL2,
            // Token: 0x0400099C RID: 2460
            STYPE_AB5TL3,
            // Token: 0x0400099D RID: 2461
            STYPE_AB5TL4,
            // Token: 0x0400099E RID: 2462
            STYPE_AB5TL5,
            // Token: 0x0400099F RID: 2463
            STYPE_AB6TMD1,
            // Token: 0x040009A0 RID: 2464
            STYPE_AB6TMD2,
            // Token: 0x040009A1 RID: 2465
            STYPE_AB6TMD3,
            // Token: 0x040009A2 RID: 2466
            STYPE_AB6TMD4,
            // Token: 0x040009A3 RID: 2467
            STYPE_AB6TL3,
            // Token: 0x040009A4 RID: 2468
            STYPE_AB7TL1,
            // Token: 0x040009A5 RID: 2469
            STYPE_AB6UTMD2,
            // Token: 0x040009A6 RID: 2470
            STYPE_AB6UTMD3,
            // Token: 0x040009A7 RID: 2471
            STYPE_AB6UTL2,
            // Token: 0x040009A8 RID: 2472
            STYPE_AB7TMD3,
            // Token: 0x040009A9 RID: 2473
            STYPE_AB8TMD1,
            // Token: 0x040009AA RID: 2474
            STYPE_AB7TMD2,
            // Token: 0x040009AB RID: 2475
            STYPE_AB1TL1,
            // Token: 0x040009AC RID: 2476
            STYPE_AB9TMD1,
            // Token: 0x040009AD RID: 2477
            STYPE_AB9TMD2,
            // Token: 0x040009AE RID: 2478
            STYPE_AB9TMD3,
            // Token: 0x040009AF RID: 2479
            STYPE_AB9TMD4 = 57,
            // Token: 0x040009B0 RID: 2480
            STYPE_AB9TL1 = 48,
            // Token: 0x040009B1 RID: 2481
            STYPE_AB9TL2,
            // Token: 0x040009B2 RID: 2482
            STYPE_AB9TL4,
            // Token: 0x040009B3 RID: 2483
            STYPE_AB9TL3,
            // Token: 0x040009B4 RID: 2484
            STYPE_AB9TL6,
            // Token: 0x040009B5 RID: 2485
            STYPE_AB6UTMD1,
            // Token: 0x040009B6 RID: 2486
            STYPE_AB5TMD1,
            // Token: 0x040009B7 RID: 2487
            STYPE_AB5TMD2,
            // Token: 0x040009B8 RID: 2488
            STYPE_AB5TMD3,
            // Token: 0x040009B9 RID: 2489
            STYPE_DA8PP = 5,
            // Token: 0x040009BA RID: 2490
            STYPE_40CPP,
            // Token: 0x040009BB RID: 2491
            STYPE_40APP,
            // Token: 0x040009BC RID: 2492
            STYPE_DA7PP,
            // Token: 0x040009BD RID: 2493
            STYPE_44BPP,
            // Token: 0x040009BE RID: 2494
            STYPE_EE2PP,
            // Token: 0x040009BF RID: 2495
            STYPE_322PP,
            // Token: 0x040009C0 RID: 2496
            STYPE_235PP,
            // Token: 0x040009C1 RID: 2497
            STYPE_ARCH = 1,
            // Token: 0x040009C2 RID: 2498
            STYPE_STARCH,
            // Token: 0x040009C3 RID: 2499
            STYPE_KORYO,
            // Token: 0x040009C4 RID: 2500
            STYPE_RYUGYONG,
            // Token: 0x040009C5 RID: 2501
            STYPE_STOWER,
            // Token: 0x040009C6 RID: 2502
            STYPE_OLY1 = 2,
            // Token: 0x040009C7 RID: 2503
            STYPE_OLY2,
            // Token: 0x040009C8 RID: 2504
            STYPE_OLY3,
            // Token: 0x040009C9 RID: 2505
            STYPE_OLY4,
            // Token: 0x040009CA RID: 2506
            STYPE_OLY5,
            // Token: 0x040009CB RID: 2507
            STYPE_KIM2 = 3,
            // Token: 0x040009CC RID: 2508
            STYPE_PMJ1 = 2,
            // Token: 0x040009CD RID: 2509
            STYPE_PMJ2,
            // Token: 0x040009CE RID: 2510
            STYPE_CLUBBLK = 5,
            // Token: 0x040009CF RID: 2511
            STYPE_DMZSFNC = 7,
            // Token: 0x040009D0 RID: 2512
            STYPE_NBBRD1,
            // Token: 0x040009D1 RID: 2513
            STYPE_NBBRD2,
            // Token: 0x040009D2 RID: 2514
            STYPE_KOEX = 31,
            // Token: 0x040009D3 RID: 2515
            STYPE_STADOBJ = 36,
            // Token: 0x040009D4 RID: 2516
            STYPE_PANMUN,
            // Token: 0x040009D5 RID: 2517
            STYPE_40FKOEX,
            // Token: 0x040009D6 RID: 2518
            STYPE_80FSTARCH,
            // Token: 0x040009D7 RID: 2519
            STYPE_80FKYORO,
            // Token: 0x040009D8 RID: 2520
            STYPE_80FRYUGNG,
            // Token: 0x040009D9 RID: 2521
            STYPE_5F0TOWER,
            // Token: 0x040009DA RID: 2522
            STYPE_MAYDAYOBJ,
            // Token: 0x040009DB RID: 2523
            STYPE_RWYLIT = 5,
            // Token: 0x040009DC RID: 2524
            STYPE_GRLINE,
            // Token: 0x040009DD RID: 2525
            STYPE_YRLINE,
            // Token: 0x040009DE RID: 2526
            STYPE_MNAVBEAC,
            // Token: 0x040009DF RID: 2527
            STYPE_LB02 = 37,
            // Token: 0x040009E0 RID: 2528
            STYPE_LB01,
            // Token: 0x040009E1 RID: 2529
            STYPE_LB03,
            // Token: 0x040009E2 RID: 2530
            STYPE_LB04,
            // Token: 0x040009E3 RID: 2531
            STYPE_THP = 10,
            // Token: 0x040009E4 RID: 2532
            STYPE_THPX,
            // Token: 0x040009E5 RID: 2533
            STYPE_THA,
            // Token: 0x040009E6 RID: 2534
            STYPE_THB,
            // Token: 0x040009E7 RID: 2535
            STYPE_THC,
            // Token: 0x040009E8 RID: 2536
            STYPE_THD,
            // Token: 0x040009E9 RID: 2537
            STYPE_THE,
            // Token: 0x040009EA RID: 2538
            STYPE_THF,
            // Token: 0x040009EB RID: 2539
            STYPE_THG,
            // Token: 0x040009EC RID: 2540
            STYPE_AB5_THP1 = 34,
            // Token: 0x040009ED RID: 2541
            STYPE_AB5_THP2A,
            // Token: 0x040009EE RID: 2542
            STYPE_AB5_THP3,
            // Token: 0x040009EF RID: 2543
            STYPE_AB5_THP4,
            // Token: 0x040009F0 RID: 2544
            STYPE_AB5_THP7,
            // Token: 0x040009F1 RID: 2545
            STYPE_AB5_TMD1,
            // Token: 0x040009F2 RID: 2546
            STYPE_AB5_TMD2,
            // Token: 0x040009F3 RID: 2547
            STYPE_AB5_TMD3,
            // Token: 0x040009F4 RID: 2548
            STYPE_AB5_TMD4,
            // Token: 0x040009F5 RID: 2549
            STYPE_AB5_THP5,
            // Token: 0x040009F6 RID: 2550
            STYPE_AB5_THP6,
            // Token: 0x040009F7 RID: 2551
            STYPE_AB5_THP2B,
            // Token: 0x040009F8 RID: 2552
            STYPE_THP27 = 58,
            // Token: 0x040009F9 RID: 2553
            STYPE_THP09,
            // Token: 0x040009FA RID: 2554
            STYPE_THP01,
            // Token: 0x040009FB RID: 2555
            STYPE_THP02,
            // Token: 0x040009FC RID: 2556
            STYPE_THP02LR,
            // Token: 0x040009FD RID: 2557
            STYPE_THP02RL,
            // Token: 0x040009FE RID: 2558
            STYPE_THP03,
            // Token: 0x040009FF RID: 2559
            STYPE_THP05LR,
            // Token: 0x04000A00 RID: 2560
            STYPE_THP05RL,
            // Token: 0x04000A01 RID: 2561
            STYPE_THP08,
            // Token: 0x04000A02 RID: 2562
            STYPE_THP11,
            // Token: 0x04000A03 RID: 2563
            STYPE_THP12,
            // Token: 0x04000A04 RID: 2564
            STYPE_THP14,
            // Token: 0x04000A05 RID: 2565
            STYPE_THP14LR,
            // Token: 0x04000A06 RID: 2566
            STYPE_THP14RL,
            // Token: 0x04000A07 RID: 2567
            STYPE_THP15,
            // Token: 0x04000A08 RID: 2568
            STYPE_THP16,
            // Token: 0x04000A09 RID: 2569
            STYPE_THP16LR,
            // Token: 0x04000A0A RID: 2570
            STYPE_THP16RL,
            // Token: 0x04000A0B RID: 2571
            STYPE_THP18,
            // Token: 0x04000A0C RID: 2572
            STYPE_THP19,
            // Token: 0x04000A0D RID: 2573
            STYPE_THP20,
            // Token: 0x04000A0E RID: 2574
            STYPE_THP20LR,
            // Token: 0x04000A0F RID: 2575
            STYPE_THP20RL,
            // Token: 0x04000A10 RID: 2576
            STYPE_THP21,
            // Token: 0x04000A11 RID: 2577
            STYPE_THP23LR,
            // Token: 0x04000A12 RID: 2578
            STYPE_THP23RL,
            // Token: 0x04000A13 RID: 2579
            STYPE_THP26,
            // Token: 0x04000A14 RID: 2580
            STYPE_THP29,
            // Token: 0x04000A15 RID: 2581
            STYPE_THP30,
            // Token: 0x04000A16 RID: 2582
            STYPE_THP32,
            // Token: 0x04000A17 RID: 2583
            STYPE_THP32LR,
            // Token: 0x04000A18 RID: 2584
            STYPE_THP32RL,
            // Token: 0x04000A19 RID: 2585
            STYPE_THP33,
            // Token: 0x04000A1A RID: 2586
            STYPE_THP34,
            // Token: 0x04000A1B RID: 2587
            STYPE_THP34LR,
            // Token: 0x04000A1C RID: 2588
            STYPE_THP34RL,
            // Token: 0x04000A1D RID: 2589
            STYPE_THP36,
            // Token: 0x04000A1E RID: 2590
            STYPE_00CPORTLIT = 17,
            // Token: 0x04000A1F RID: 2591
            STYPE_66DPORTLIT,
            // Token: 0x04000A20 RID: 2592
            STYPE_731PORTLIT,
            // Token: 0x04000A21 RID: 2593
            STYPE_795PORTLIT,
            // Token: 0x04000A22 RID: 2594
            STYPE_79APORTLIT,
            // Token: 0x04000A23 RID: 2595
            STYPE_79BPORTLIT,
            // Token: 0x04000A24 RID: 2596
            STYPE_79DPORTLIT,
            // Token: 0x04000A25 RID: 2597
            STYPE_79EPORTLIT,
            // Token: 0x04000A26 RID: 2598
            STYPE_7A0PORTLIT,
            // Token: 0x04000A27 RID: 2599
            STYPE_7A1PORTLIT,
            // Token: 0x04000A28 RID: 2600
            STYPE_7A2PORTLIT,
            // Token: 0x04000A29 RID: 2601
            STYPE_7A5PORTLIT,
            // Token: 0x04000A2A RID: 2602
            STYPE_7A6PORTLIT,
            // Token: 0x04000A2B RID: 2603
            STYPE_FUELTRUCK = 1,
            // Token: 0x04000A2C RID: 2604
            STYPE_SM977,
            // Token: 0x04000A2D RID: 2605
            STYPE_APU,
            // Token: 0x04000A2E RID: 2606
            STYPE_WTRAILER,
            // Token: 0x04000A2F RID: 2607
            STYPE_WLOADER,
            // Token: 0x04000A30 RID: 2608
            STYPE_WHSE06 = 8,
            // Token: 0x04000A31 RID: 2609
            STYPE_CTR01 = 3,
            // Token: 0x04000A32 RID: 2610
            STYPE_CTR03,
            // Token: 0x04000A33 RID: 2611
            STYPE_LGTNK_05 = 3,
            // Token: 0x04000A34 RID: 2612
            STYPE_LGTNK_06,
            // Token: 0x04000A35 RID: 2613
            STYPE_LGTNK_07,
            // Token: 0x04000A36 RID: 2614
            STYPE_RTWR_03 = 3,
            // Token: 0x04000A37 RID: 2615
            STYPE_RTWR_04,
            // Token: 0x04000A38 RID: 2616
            STYPE_HNGR05 = 11,
            // Token: 0x04000A39 RID: 2617
            STYPE_CMTWR_01 = 14,
            // Token: 0x04000A3A RID: 2618
            STYPE_SILO_01,
            // Token: 0x04000A3B RID: 2619
            STYPE_CMTWR_02,
            // Token: 0x04000A3C RID: 2620
            STYPE_DEPO03 = 1,
            // Token: 0x04000A3D RID: 2621
            STYPE_R02OVER,
            // Token: 0x04000A3E RID: 2622
            STYPE_R04AGA = 21,
            // Token: 0x04000A3F RID: 2623
            STYPE_R04AGB,
            // Token: 0x04000A40 RID: 2624
            STYPE_R04AGC,
            // Token: 0x04000A41 RID: 2625
            STYPE_R04BGA,
            // Token: 0x04000A42 RID: 2626
            STYPE_R04BGB,
            // Token: 0x04000A43 RID: 2627
            STYPE_R04BGC,
            // Token: 0x04000A44 RID: 2628
            STYPE_LANDL,
            // Token: 0x04000A45 RID: 2629
            STYPE_RV82A,
            // Token: 0x04000A46 RID: 2630
            STYPE_RV82B,
            // Token: 0x04000A47 RID: 2631
            STYPE_RV82C,
            // Token: 0x04000A48 RID: 2632
            STYPE_R06RGA,
            // Token: 0x04000A49 RID: 2633
            STYPE_R06RGB,
            // Token: 0x04000A4A RID: 2634
            STYPE_R06RGC,
            // Token: 0x04000A4B RID: 2635
            STYPE_R06LGA,
            // Token: 0x04000A4C RID: 2636
            STYPE_R06LGB,
            // Token: 0x04000A4D RID: 2637
            STYPE_R06LGC,
            // Token: 0x04000A4E RID: 2638
            STYPE_FLAND,
            // Token: 0x04000A4F RID: 2639
            STYPE_FLAND27,
            // Token: 0x04000A50 RID: 2640
            STYPE_BLDG01 = 1,
            // Token: 0x04000A51 RID: 2641
            STYPE_BLDG02,
            // Token: 0x04000A52 RID: 2642
            STYPE_BLDG03,
            // Token: 0x04000A53 RID: 2643
            STYPE_BLDG04,
            // Token: 0x04000A54 RID: 2644
            STYPE_BLDG05,
            // Token: 0x04000A55 RID: 2645
            STYPE_80F_9CC2 = 8,
            // Token: 0x04000A56 RID: 2646
            STYPE_40F_9CC2,
            // Token: 0x04000A57 RID: 2647
            STYPE_80F_9CC1,
            // Token: 0x04000A58 RID: 2648
            STYPE_30F_9CC1 = 18,
            // Token: 0x04000A59 RID: 2649
            STYPE_40F_9CC1 = 23,
            // Token: 0x04000A5A RID: 2650
            STYPE_C01_OBJ = 1,
            // Token: 0x04000A5B RID: 2651
            STYPE_C02_OBJ,
            // Token: 0x04000A5C RID: 2652
            STYPE_C03_OBJ,
            // Token: 0x04000A5D RID: 2653
            STYPE_C01_02 = 1,
            // Token: 0x04000A5E RID: 2654
            STYPE_C01_03,
            // Token: 0x04000A5F RID: 2655
            STYPE_C01_04 = 4,
            // Token: 0x04000A60 RID: 2656
            STYPE_C01_05,
            // Token: 0x04000A61 RID: 2657
            STYPE_C01_06,
            // Token: 0x04000A62 RID: 2658
            STYPE_C01_10,
            // Token: 0x04000A63 RID: 2659
            STYPE_C02_01 = 2,
            // Token: 0x04000A64 RID: 2660
            STYPE_C02_02 = 8,
            // Token: 0x04000A65 RID: 2661
            STYPE_C02_03,
            // Token: 0x04000A66 RID: 2662
            STYPE_C02_04,
            // Token: 0x04000A67 RID: 2663
            STYPE_C02_05,
            // Token: 0x04000A68 RID: 2664
            STYPE_C02_06,
            // Token: 0x04000A69 RID: 2665
            STYPE_C02_07,
            // Token: 0x04000A6A RID: 2666
            STYPE_C03_01 = 17,
            // Token: 0x04000A6B RID: 2667
            STYPE_F803_1 = 1,
            // Token: 0x04000A6C RID: 2668
            STYPE_F80F_1,
            // Token: 0x04000A6D RID: 2669
            STYPE_F405_1,
            // Token: 0x04000A6E RID: 2670
            STYPE_F303_1 = 5,
            // Token: 0x04000A6F RID: 2671
            STYPE_F30E_1,
            // Token: 0x04000A70 RID: 2672
            STYPE_F66C_1,
            // Token: 0x04000A71 RID: 2673
            STYPE_F801_1,
            // Token: 0x04000A72 RID: 2674
            STYPE_F802_1,
            // Token: 0x04000A73 RID: 2675
            STYPE_F804_1,
            // Token: 0x04000A74 RID: 2676
            STYPE_F805_1,
            // Token: 0x04000A75 RID: 2677
            STYPE_F80A_1,
            // Token: 0x04000A76 RID: 2678
            STYPE_F80B_1,
            // Token: 0x04000A77 RID: 2679
            STYPE_F80C_1,
            // Token: 0x04000A78 RID: 2680
            STYPE_FEC1_1,
            // Token: 0x04000A79 RID: 2681
            STYPE_FEC2_1,
            // Token: 0x04000A7A RID: 2682
            STYPE_FEC8_1,
            // Token: 0x04000A7B RID: 2683
            STYPE_F05_OBJ,
            // Token: 0x04000A7C RID: 2684
            STYPE_F03_OBJ,
            // Token: 0x04000A7D RID: 2685
            STYPE_F02_05 = 1,
            // Token: 0x04000A7E RID: 2686
            STYPE_F02_02,
            // Token: 0x04000A7F RID: 2687
            STYPE_F02_04,
            // Token: 0x04000A80 RID: 2688
            STYPE_F05_01 = 11,
            // Token: 0x04000A81 RID: 2689
            STYPE_F05_02,
            // Token: 0x04000A82 RID: 2690
            STYPE_F05_03,
            // Token: 0x04000A83 RID: 2691
            STYPE_F05_04,
            // Token: 0x04000A84 RID: 2692
            STYPE_F05_05,
            // Token: 0x04000A85 RID: 2693
            STYPE_F05_06,
            // Token: 0x04000A86 RID: 2694
            STYPE_F05_07,
            // Token: 0x04000A87 RID: 2695
            STYPE_F05_08,
            // Token: 0x04000A88 RID: 2696
            STYPE_F05_09,
            // Token: 0x04000A89 RID: 2697
            STYPE_F03_01,
            // Token: 0x04000A8A RID: 2698
            STYPE_F03_02,
            // Token: 0x04000A8B RID: 2699
            STYPE_F03_03,
            // Token: 0x04000A8C RID: 2700
            STYPE_F03_04,
            // Token: 0x04000A8D RID: 2701
            STYPE_F03_05,
            // Token: 0x04000A8E RID: 2702
            STYPE_F02_03,
            // Token: 0x04000A8F RID: 2703
            STYPE_F02_01,
            // Token: 0x04000A90 RID: 2704
            STYPE_N02_OBJ = 3,
            // Token: 0x04000A91 RID: 2705
            STYPE_N03_OBJ,
            // Token: 0x04000A92 RID: 2706
            STYPE_N04_OBJ,
            // Token: 0x04000A93 RID: 2707
            STYPE_N02_01 = 3,
            // Token: 0x04000A94 RID: 2708
            STYPE_N02_02,
            // Token: 0x04000A95 RID: 2709
            STYPE_N02_03,
            // Token: 0x04000A96 RID: 2710
            STYPE_N02_04,
            // Token: 0x04000A97 RID: 2711
            STYPE_N02_05,
            // Token: 0x04000A98 RID: 2712
            STYPE_N03_01 = 9,
            // Token: 0x04000A99 RID: 2713
            STYPE_N03_02,
            // Token: 0x04000A9A RID: 2714
            STYPE_N03_03,
            // Token: 0x04000A9B RID: 2715
            STYPE_N03_04,
            // Token: 0x04000A9C RID: 2716
            STYPE_N03_05,
            // Token: 0x04000A9D RID: 2717
            STYPE_N03_06,
            // Token: 0x04000A9E RID: 2718
            STYPE_N04_01,
            // Token: 0x04000A9F RID: 2719
            STYPE_N04_02,
            // Token: 0x04000AA0 RID: 2720
            STYPE_N04_03,
            // Token: 0x04000AA1 RID: 2721
            STYPE_N04_04,
            // Token: 0x04000AA2 RID: 2722
            STYPE_NUM160 = 1,
            // Token: 0x04000AA3 RID: 2723
            STYPE_NUM380,
            // Token: 0x04000AA4 RID: 2724
            STYPE_NUM270,
            // Token: 0x04000AA5 RID: 2725
            STYPE_PP01_OBJ = 1,
            // Token: 0x04000AA6 RID: 2726
            STYPE_PP02_OBJ,
            // Token: 0x04000AA7 RID: 2727
            STYPE_PP03_OBJ,
            // Token: 0x04000AA8 RID: 2728
            STYPE_PP04_OBJ,
            // Token: 0x04000AA9 RID: 2729
            STYPE_PP01_01 = 2,
            // Token: 0x04000AAA RID: 2730
            STYPE_PP02_01,
            // Token: 0x04000AAB RID: 2731
            STYPE_PP02_02 = 2,
            // Token: 0x04000AAC RID: 2732
            STYPE_PP02_03 = 4,
            // Token: 0x04000AAD RID: 2733
            STYPE_PP03_01,
            // Token: 0x04000AAE RID: 2734
            STYPE_PP03_02,
            // Token: 0x04000AAF RID: 2735
            STYPE_PP03_03,
            // Token: 0x04000AB0 RID: 2736
            STYPE_PP04_01,
            // Token: 0x04000AB1 RID: 2737
            STYPE_PP01_04,
            // Token: 0x04000AB2 RID: 2738
            STYPE_PP01_05,
            // Token: 0x04000AB3 RID: 2739
            STYPE_PP01_02,
            // Token: 0x04000AB4 RID: 2740
            STYPE_PP01_03,
            // Token: 0x04000AB5 RID: 2741
            STYPE_PTWR_03 = 2,
            // Token: 0x04000AB6 RID: 2742
            STYPE_PTWR02 = 2,
            // Token: 0x04000AB7 RID: 2743
            STYPE_PTWR03,
            // Token: 0x04000AB8 RID: 2744
            STYPE_R02_OBJ = 3,
            // Token: 0x04000AB9 RID: 2745
            STYPE_R03_OBJ = 3,
            // Token: 0x04000ABA RID: 2746
            STYPE_R02_01 = 2,
            // Token: 0x04000ABB RID: 2747
            STYPE_R02_02,
            // Token: 0x04000ABC RID: 2748
            STYPE_R02_03,
            // Token: 0x04000ABD RID: 2749
            STYPE_R02_04,
            // Token: 0x04000ABE RID: 2750
            STYPE_R02_05,
            // Token: 0x04000ABF RID: 2751
            STYPE_R02_06,
            // Token: 0x04000AC0 RID: 2752
            STYPE_R02_07,
            // Token: 0x04000AC1 RID: 2753
            STYPE_R02_08,
            // Token: 0x04000AC2 RID: 2754
            STYPE_R02_09,
            // Token: 0x04000AC3 RID: 2755
            STYPE_R02_10,
            // Token: 0x04000AC4 RID: 2756
            STYPE_R02_11,
            // Token: 0x04000AC5 RID: 2757
            STYPE_R02_12,
            // Token: 0x04000AC6 RID: 2758
            STYPE_R02_13,
            // Token: 0x04000AC7 RID: 2759
            STYPE_R03_01,
            // Token: 0x04000AC8 RID: 2760
            STYPE_R03_02,
            // Token: 0x04000AC9 RID: 2761
            STYPE_R03_03,
            // Token: 0x04000ACA RID: 2762
            STYPE_R03_04,
            // Token: 0x04000ACB RID: 2763
            STYPE_R03_05,
            // Token: 0x04000ACC RID: 2764
            STYPE_R03_06,
            // Token: 0x04000ACD RID: 2765
            STYPE_R03_07,
            // Token: 0x04000ACE RID: 2766
            STYPE_R02_NPGA = 1,
            // Token: 0x04000ACF RID: 2767
            STYPE_R01_PFLA = 3,
            // Token: 0x04000AD0 RID: 2768
            STYPE_R02_PGC = 3,
            // Token: 0x04000AD1 RID: 2769
            STYPE_R01_PFLB,
            // Token: 0x04000AD2 RID: 2770
            STYPE_R03_NPGA = 4,
            // Token: 0x04000AD3 RID: 2771
            STYPE_R02_NPGB = 6,
            // Token: 0x04000AD4 RID: 2772
            STYPE_R02_NPGC,
            // Token: 0x04000AD5 RID: 2773
            STYPE_R02_NPGD,
            // Token: 0x04000AD6 RID: 2774
            STYPE_R02_PGA,
            // Token: 0x04000AD7 RID: 2775
            STYPE_R02_PGB,
            // Token: 0x04000AD8 RID: 2776
            STYPE_R01_NPGB,
            // Token: 0x04000AD9 RID: 2777
            STYPE_R01_NPGA,
            // Token: 0x04000ADA RID: 2778
            STYPE_R01_NPGC,
            // Token: 0x04000ADB RID: 2779
            STYPE_R01_PGA,
            // Token: 0x04000ADC RID: 2780
            STYPE_R01_PGB,
            // Token: 0x04000ADD RID: 2781
            STYPE_R03_NPGB,
            // Token: 0x04000ADE RID: 2782
            STYPE_R03_PGA,
            // Token: 0x04000ADF RID: 2783
            STYPE_R03_NPGC,
            // Token: 0x04000AE0 RID: 2784
            STYPE_R03_PGB,
            // Token: 0x04000AE1 RID: 2785
            STYPE_R03_PGC,
            // Token: 0x04000AE2 RID: 2786
            STYPE_R03PGD = 39,
            // Token: 0x04000AE3 RID: 2787
            STYPE_R06RGD,
            // Token: 0x04000AE4 RID: 2788
            STYPE_R03OPGA = 43,
            // Token: 0x04000AE5 RID: 2789
            STYPE_R03OPGD
        }

        // Token: 0x020000AA RID: 170
        public enum Specific_Types
        {
            // Token: 0x04000AE7 RID: 2791
            SPTYPE_20mmAAA = 2,
            // Token: 0x04000AE8 RID: 2792
            SPTYPE_P3 = 1,
            // Token: 0x04000AE9 RID: 2793
            SPTYPE_S3,
            // Token: 0x04000AEA RID: 2794
            SPTYPE_A10 = 1,
            // Token: 0x04000AEB RID: 2795
            SPTYPE_A37B,
            // Token: 0x04000AEC RID: 2796
            SPTYPE_A6E,
            // Token: 0x04000AED RID: 2797
            SPTYPE_AC130U,
            // Token: 0x04000AEE RID: 2798
            SPTYPE_F4G,
            // Token: 0x04000AEF RID: 2799
            SPTYPE_FB111,
            // Token: 0x04000AF0 RID: 2800
            SPTYPE_HARRIER,
            // Token: 0x04000AF1 RID: 2801
            SPTYPE_IL28,
            // Token: 0x04000AF2 RID: 2802
            SPTYPE_MIG27,
            // Token: 0x04000AF3 RID: 2803
            SPTYPE_Q5,
            // Token: 0x04000AF4 RID: 2804
            SPTYPE_SU24,
            // Token: 0x04000AF5 RID: 2805
            SPTYPE_SU25,
            // Token: 0x04000AF6 RID: 2806
            SPTYPE_SU7,
            // Token: 0x04000AF7 RID: 2807
            SPTYPE_AH1 = 1,
            // Token: 0x04000AF8 RID: 2808
            SPTYPE_AH64,
            // Token: 0x04000AF9 RID: 2809
            SPTYPE_AH64D,
            // Token: 0x04000AFA RID: 2810
            SPTYPE_AH66,
            // Token: 0x04000AFB RID: 2811
            SPTYPE_KA50,
            // Token: 0x04000AFC RID: 2812
            SPTYPE_MI24,
            // Token: 0x04000AFD RID: 2813
            SPTYPE_MI28,
            // Token: 0x04000AFE RID: 2814
            SPTYPE_MI8,
            // Token: 0x04000AFF RID: 2815
            SPTYPE_A50 = 1,
            // Token: 0x04000B00 RID: 2816
            SPTYPE_E2C,
            // Token: 0x04000B01 RID: 2817
            SPTYPE_E3,
            // Token: 0x04000B02 RID: 2818
            SPTYPE_B1B = 1,
            // Token: 0x04000B03 RID: 2819
            SPTYPE_B2,
            // Token: 0x04000B04 RID: 2820
            SPTYPE_B52G,
            // Token: 0x04000B05 RID: 2821
            SPTYPE_TU16,
            // Token: 0x04000B06 RID: 2822
            SPTYPE_TU160,
            // Token: 0x04000B07 RID: 2823
            SPTYPE_TU22,
            // Token: 0x04000B08 RID: 2824
            SPTYPE_TU95,
            // Token: 0x04000B09 RID: 2825
            SPTYPE_EA6B = 1,
            // Token: 0x04000B0A RID: 2826
            SPTYPE_EF111,
            // Token: 0x04000B0B RID: 2827
            SPTYPE_F14A = 2,
            // Token: 0x04000B0C RID: 2828
            SPTYPE_F15C,
            // Token: 0x04000B0D RID: 2829
            SPTYPE_F22,
            // Token: 0x04000B0E RID: 2830
            SPTYPE_F4E,
            // Token: 0x04000B0F RID: 2831
            SPTYPE_F5E,
            // Token: 0x04000B10 RID: 2832
            SPTYPE_J7,
            // Token: 0x04000B11 RID: 2833
            SPTYPE_J8,
            // Token: 0x04000B12 RID: 2834
            SPTYPE_MIG19 = 10,
            // Token: 0x04000B13 RID: 2835
            SPTYPE_MIG21,
            // Token: 0x04000B14 RID: 2836
            SPTYPE_MIG23MS,
            // Token: 0x04000B15 RID: 2837
            SPTYPE_MIG25,
            // Token: 0x04000B16 RID: 2838
            SPTYPE_MIG29,
            // Token: 0x04000B17 RID: 2839
            SPTYPE_MIG31,
            // Token: 0x04000B18 RID: 2840
            SPTYPE_SU15 = 9,
            // Token: 0x04000B19 RID: 2841
            SPTYPE_SU27 = 1,
            // Token: 0x04000B1A RID: 2842
            SPTYPE_F117 = 1,
            // Token: 0x04000B1B RID: 2843
            SPTYPE_F15E,
            // Token: 0x04000B1C RID: 2844
            SPTYPE_F16C,
            // Token: 0x04000B1D RID: 2845
            SPTYPE_F18C,
            // Token: 0x04000B1E RID: 2846
            SPTYPE_J5,
            // Token: 0x04000B1F RID: 2847
            SPTYPE_E8C = 1,
            // Token: 0x04000B20 RID: 2848
            SPTYPE_OV10D = 1,
            // Token: 0x04000B21 RID: 2849
            SPTYPE_RC135,
            // Token: 0x04000B22 RID: 2850
            SPTYPE_SR71,
            // Token: 0x04000B23 RID: 2851
            SPTYPE_TR1,
            // Token: 0x04000B24 RID: 2852
            SPTYPE_TR2,
            // Token: 0x04000B25 RID: 2853
            SPTYPE_U2,
            // Token: 0x04000B26 RID: 2854
            SPTYPE_MD500 = 1,
            // Token: 0x04000B27 RID: 2855
            SPTYPE_OH58D,
            // Token: 0x04000B28 RID: 2856
            SPTYPE_IL78 = 1,
            // Token: 0x04000B29 RID: 2857
            SPTYPE_KC10,
            // Token: 0x04000B2A RID: 2858
            SPTYPE_KC130R,
            // Token: 0x04000B2B RID: 2859
            SPTYPE_KC135,
            // Token: 0x04000B2C RID: 2860
            SPTYPE_TU16N,
            // Token: 0x04000B2D RID: 2861
            SPTYPE_AN12 = 1,
            // Token: 0x04000B2E RID: 2862
            SPTYPE_AN124,
            // Token: 0x04000B2F RID: 2863
            SPTYPE_AN2,
            // Token: 0x04000B30 RID: 2864
            SPTYPE_AN225,
            // Token: 0x04000B31 RID: 2865
            SPTYPE_AN70,
            // Token: 0x04000B32 RID: 2866
            SPTYPE_AN72,
            // Token: 0x04000B33 RID: 2867
            SPTYPE_C130,
            // Token: 0x04000B34 RID: 2868
            SPTYPE_C141,
            // Token: 0x04000B35 RID: 2869
            SPTYPE_C17,
            // Token: 0x04000B36 RID: 2870
            SPTYPE_C5,
            // Token: 0x04000B37 RID: 2871
            SPTYPE_IL76M,
            // Token: 0x04000B38 RID: 2872
            SPTYPE_MV22,
            // Token: 0x04000B39 RID: 2873
            SPTYPE_Y8,
            // Token: 0x04000B3A RID: 2874
            SPTYPE_CH46 = 1,
            // Token: 0x04000B3B RID: 2875
            SPTYPE_CH47,
            // Token: 0x04000B3C RID: 2876
            SPTYPE_CH53,
            // Token: 0x04000B3D RID: 2877
            SPTYPE_MI26,
            // Token: 0x04000B3E RID: 2878
            SPTYPE_UH1N,
            // Token: 0x04000B3F RID: 2879
            SPTYPE_UH60L,
            // Token: 0x04000B40 RID: 2880
            SPTYPE_SACRAMENTO = 1,
            // Token: 0x04000B41 RID: 2881
            SPTYPE_FAGLST = 1,
            // Token: 0x04000B42 RID: 2882
            SPTYPE_120mmAP = 28,
            // Token: 0x04000B43 RID: 2883
            SPTYPE_120mmHEAT,
            // Token: 0x04000B44 RID: 2884
            SPTYPE_105mm = 1,
            // Token: 0x04000B45 RID: 2885
            SPTYPE_152mm,
            // Token: 0x04000B46 RID: 2886
            SPTYPE_73mm,
            // Token: 0x04000B47 RID: 2887
            SPTYPE_BOFORS,
            // Token: 0x04000B48 RID: 2888
            SPTYPE_BLU109B = 1,
            // Token: 0x04000B49 RID: 2889
            SPTYPE_BLU27,
            // Token: 0x04000B4A RID: 2890
            SPTYPE_CBU52BB,
            // Token: 0x04000B4B RID: 2891
            SPTYPE_CBU58AB,
            // Token: 0x04000B4C RID: 2892
            SPTYPE_CBU87,
            // Token: 0x04000B4D RID: 2893
            SPTYPE_CBU89B,
            // Token: 0x04000B4E RID: 2894
            SPTYPE_DURANDAL,
            // Token: 0x04000B4F RID: 2895
            SPTYPE_MK20ROCKEYE,
            // Token: 0x04000B50 RID: 2896
            SPTYPE_GBU10AB = 1,
            // Token: 0x04000B51 RID: 2897
            SPTYPE_GBU12B,
            // Token: 0x04000B52 RID: 2898
            SPTYPE_GBU24B,
            // Token: 0x04000B53 RID: 2899
            SPTYPE_MK82 = 1,
            // Token: 0x04000B54 RID: 2900
            SPTYPE_MK82SNAKEYE,
            // Token: 0x04000B55 RID: 2901
            SPTYPE_MK84,
            // Token: 0x04000B56 RID: 2902
            SPTYPE_MK84AIR,
            // Token: 0x04000B57 RID: 2903
            SPTYPE_LOWALT = 1,
            // Token: 0x04000B58 RID: 2904
            SPTYPE_CV67KENNEDY = 1,
            // Token: 0x04000B59 RID: 2905
            SPTYPE_CG47 = 1,
            // Token: 0x04000B5A RID: 2906
            SPTYPE_DECK_CLOUD1 = 1,
            // Token: 0x04000B5B RID: 2907
            SPTYPE_DEPTHCHARGE = 1,
            // Token: 0x04000B5C RID: 2908
            SPTYPE_ALQ131 = 1,
            // Token: 0x04000B5D RID: 2909
            SPTYPE_ALLM16SQD = 1,
            // Token: 0x04000B5E RID: 2910
            SPTYPE_ALLM4SQD,
            // Token: 0x04000B5F RID: 2911
            SPTYPE_ALLM60SQD,
            // Token: 0x04000B60 RID: 2912
            SPTYPE_CISARTSQD,
            // Token: 0x04000B61 RID: 2913
            SPTYPE_CISATMISSQD,
            // Token: 0x04000B62 RID: 2914
            SPTYPE_CISMORTSQD,
            // Token: 0x04000B63 RID: 2915
            SPTYPE_CISSAMSQD,
            // Token: 0x04000B64 RID: 2916
            SPTYPE_DPRKARTSQD,
            // Token: 0x04000B65 RID: 2917
            SPTYPE_DPRKATMISSQD,
            // Token: 0x04000B66 RID: 2918
            SPTYPE_DPRKMORTSQD,
            // Token: 0x04000B67 RID: 2919
            SPTYPE_DPRKSAMSQD,
            // Token: 0x04000B68 RID: 2920
            SPTYPE_PRCARTSQD,
            // Token: 0x04000B69 RID: 2921
            SPTYPE_PRCATMISSQD,
            // Token: 0x04000B6A RID: 2922
            SPTYPE_PRCMORTSQD,
            // Token: 0x04000B6B RID: 2923
            SPTYPE_PRCSAMSQD,
            // Token: 0x04000B6C RID: 2924
            SPTYPE_ROKARTSQD,
            // Token: 0x04000B6D RID: 2925
            SPTYPE_ROKATMISSQD,
            // Token: 0x04000B6E RID: 2926
            SPTYPE_ROKMORTSQD,
            // Token: 0x04000B6F RID: 2927
            SPTYPE_ROKSAMSQD,
            // Token: 0x04000B70 RID: 2928
            SPTYPE_USARTSQD,
            // Token: 0x04000B71 RID: 2929
            SPTYPE_USATMISSQD,
            // Token: 0x04000B72 RID: 2930
            SPTYPE_USMORTSQD,
            // Token: 0x04000B73 RID: 2931
            SPTYPE_USSAMSQUAD,
            // Token: 0x04000B74 RID: 2932
            SPTYPE_JANGWEI = 1,
            // Token: 0x04000B75 RID: 2933
            SPTYPE_ULSAN,
            // Token: 0x04000B76 RID: 2934
            SPTYPE_100GAL = 1,
            // Token: 0x04000B77 RID: 2935
            SPTYPE_300GAL,
            // Token: 0x04000B78 RID: 2936
            SPTYPE_370GAL,
            // Token: 0x04000B79 RID: 2937
            SPTYPE_500GAL,
            // Token: 0x04000B7A RID: 2938
            SPTYPE_600GAL,
            // Token: 0x04000B7B RID: 2939
            SPTYPE_GEARDEST = 1,
            // Token: 0x04000B7C RID: 2940
            SPTYPE_CARGOSHP = 1,
            // Token: 0x04000B7D RID: 2941
            SPTYPE_GENTANKER,
            // Token: 0x04000B7E RID: 2942
            SPTYPE_12_7mm = 1,
            // Token: 0x04000B7F RID: 2943
            SPTYPE_20mm,
            // Token: 0x04000B80 RID: 2944
            SPTYPE_30mm,
            // Token: 0x04000B81 RID: 2945
            SPTYPE_40mmGL,
            // Token: 0x04000B82 RID: 2946
            SPTYPE_7_62mm,
            // Token: 0x04000B83 RID: 2947
            SPTYPE_7_62mmPKT,
            // Token: 0x04000B84 RID: 2948
            SPTYPE_76mm_3in_50cal,
            // Token: 0x04000B85 RID: 2949
            SPTYPE_GAU12U,
            // Token: 0x04000B86 RID: 2950
            SPTYPE_GAU8,
            // Token: 0x04000B87 RID: 2951
            SPTYPE_GSH23,
            // Token: 0x04000B88 RID: 2952
            SPTYPE_M16GUN,
            // Token: 0x04000B89 RID: 2953
            SPTYPE_M46130mm,
            // Token: 0x04000B8A RID: 2954
            SPTYPE_M4GUN,
            // Token: 0x04000B8B RID: 2955
            SPTYPE_M60MGUN,
            // Token: 0x04000B8C RID: 2956
            SPTYPE_MK15PHALANX,
            // Token: 0x04000B8D RID: 2957
            SPTYPE_MK45,
            // Token: 0x04000B8E RID: 2958
            SPTYPE_MNCLRBLADE = 1,
            // Token: 0x04000B8F RID: 2959
            SPTYPE_AA1 = 1,
            // Token: 0x04000B90 RID: 2960
            SPTYPE_AA10,
            // Token: 0x04000B91 RID: 2961
            SPTYPE_AA10C,
            // Token: 0x04000B92 RID: 2962
            SPTYPE_AA11,
            // Token: 0x04000B93 RID: 2963
            SPTYPE_AA12,
            // Token: 0x04000B94 RID: 2964
            SPTYPE_AA2,
            // Token: 0x04000B95 RID: 2965
            SPTYPE_AA2R,
            // Token: 0x04000B96 RID: 2966
            SPTYPE_AA3,
            // Token: 0x04000B97 RID: 2967
            SPTYPE_AA7,
            // Token: 0x04000B98 RID: 2968
            SPTYPE_AA7R,
            // Token: 0x04000B99 RID: 2969
            SPTYPE_AA8,
            // Token: 0x04000B9A RID: 2970
            SPTYPE_AA9,
            // Token: 0x04000B9B RID: 2971
            SPTYPE_AIM120,
            // Token: 0x04000B9C RID: 2972
            SPTYPE_AIM54,
            // Token: 0x04000B9D RID: 2973
            SPTYPE_AIM7,
            // Token: 0x04000B9E RID: 2974
            SPTYPE_AIM9M,
            // Token: 0x04000B9F RID: 2975
            SPTYPE_AIM9P,
            // Token: 0x04000BA0 RID: 2976
            SPTYPE_AIM9R,
            // Token: 0x04000BA1 RID: 2977
            SPTYPE_AGM114 = 1,
            // Token: 0x04000BA2 RID: 2978
            SPTYPE_AGM119,
            // Token: 0x04000BA3 RID: 2979
            SPTYPE_AGM122,
            // Token: 0x04000BA4 RID: 2980
            SPTYPE_AGM45,
            // Token: 0x04000BA5 RID: 2981
            SPTYPE_AGM65A,
            // Token: 0x04000BA6 RID: 2982
            SPTYPE_AGM65B,
            // Token: 0x04000BA7 RID: 2983
            SPTYPE_AGM65D,
            // Token: 0x04000BA8 RID: 2984
            SPTYPE_AGM65G,
            // Token: 0x04000BA9 RID: 2985
            SPTYPE_AGM78,
            // Token: 0x04000BAA RID: 2986
            SPTYPE_AGM84,
            // Token: 0x04000BAB RID: 2987
            SPTYPE_AGM88,
            // Token: 0x04000BAC RID: 2988
            SPTYPE_AS10,
            // Token: 0x04000BAD RID: 2989
            SPTYPE_AS11,
            // Token: 0x04000BAE RID: 2990
            SPTYPE_AS12,
            // Token: 0x04000BAF RID: 2991
            SPTYPE_AS14,
            // Token: 0x04000BB0 RID: 2992
            SPTYPE_AS15,
            // Token: 0x04000BB1 RID: 2993
            SPTYPE_AS7,
            // Token: 0x04000BB2 RID: 2994
            SPTYPE_AS9,
            // Token: 0x04000BB3 RID: 2995
            SPTYPE_AT2 = 10,
            // Token: 0x04000BB4 RID: 2996
            SPTYPE_AT6 = 20,
            // Token: 0x04000BB5 RID: 2997
            SPTYPE_HELLFIRE,
            // Token: 0x04000BB6 RID: 2998
            SPTYPE_AS4 = 1,
            // Token: 0x04000BB7 RID: 2999
            SPTYPE_AS6,
            // Token: 0x04000BB8 RID: 3000
            SPTYPE_ADATS = 1,
            // Token: 0x04000BB9 RID: 3001
            SPTYPE_CHAPARRAL,
            // Token: 0x04000BBA RID: 3002
            SPTYPE_HAWK,
            // Token: 0x04000BBB RID: 3003
            SPTYPE_HN_5_A,
            // Token: 0x04000BBC RID: 3004
            SPTYPE_HYDRA,
            // Token: 0x04000BBD RID: 3005
            SPTYPE_MK26,
            // Token: 0x04000BBE RID: 3006
            SPTYPE_NIKE,
            // Token: 0x04000BBF RID: 3007
            SPTYPE_PATRIOT,
            // Token: 0x04000BC0 RID: 3008
            SPTYPE_RAPIER,
            // Token: 0x04000BC1 RID: 3009
            SPTYPE_RIM7,
            // Token: 0x04000BC2 RID: 3010
            SPTYPE_SA13 = 12,
            // Token: 0x04000BC3 RID: 3011
            SPTYPE_SA14,
            // Token: 0x04000BC4 RID: 3012
            SPTYPE_SA15,
            // Token: 0x04000BC5 RID: 3013
            SPTYPE_SA19,
            // Token: 0x04000BC6 RID: 3014
            SPTYPE_SA2,
            // Token: 0x04000BC7 RID: 3015
            SPTYPE_SA3,
            // Token: 0x04000BC8 RID: 3016
            SPTYPE_SA4,
            // Token: 0x04000BC9 RID: 3017
            SPTYPE_SA5,
            // Token: 0x04000BCA RID: 3018
            SPTYPE_SA6,
            // Token: 0x04000BCB RID: 3019
            SPTYPE_SA7,
            // Token: 0x04000BCC RID: 3020
            SPTYPE_SA8,
            // Token: 0x04000BCD RID: 3021
            SPTYPE_SA9,
            // Token: 0x04000BCE RID: 3022
            SPTYPE_SAN5,
            // Token: 0x04000BCF RID: 3023
            SPTYPE_STINGER,
            // Token: 0x04000BD0 RID: 3024
            SPTYPE_TOWM1046 = 1,
            // Token: 0x04000BD1 RID: 3025
            SPTYPE_122mmAProcket = 1,
            // Token: 0x04000BD2 RID: 3026
            SPTYPE_122mmHErocket,
            // Token: 0x04000BD3 RID: 3027
            SPTYPE_240mmROCKET,
            // Token: 0x04000BD4 RID: 3028
            SPTYPE_ASROC,
            // Token: 0x04000BD5 RID: 3029
            SPTYPE_AT3,
            // Token: 0x04000BD6 RID: 3030
            SPTYPE_AT5,
            // Token: 0x04000BD7 RID: 3031
            SPTYPE_FROG7,
            // Token: 0x04000BD8 RID: 3032
            SPTYPE_M47,
            // Token: 0x04000BD9 RID: 3033
            SPTYPE_MINUTEMAN,
            // Token: 0x04000BDA RID: 3034
            SPTYPE_PEACEKEEPER = 11,
            // Token: 0x04000BDB RID: 3035
            SPTYPE_RPG_7VAT,
            // Token: 0x04000BDC RID: 3036
            SPTYPE_SCUD,
            // Token: 0x04000BDD RID: 3037
            SPTYPE_SS1,
            // Token: 0x04000BDE RID: 3038
            SPTYPE_SS18,
            // Token: 0x04000BDF RID: 3039
            SPTYPE_SS21,
            // Token: 0x04000BE0 RID: 3040
            SPTYPE_SS24,
            // Token: 0x04000BE1 RID: 3041
            SPTYPE_SS45,
            // Token: 0x04000BE2 RID: 3042
            SPTYPE_SSN2 = 3,
            // Token: 0x04000BE3 RID: 3043
            SPTYPE_160mmMORT = 1,
            // Token: 0x04000BE4 RID: 3044
            SPTYPE_60mmMORT,
            // Token: 0x04000BE5 RID: 3045
            SPTYPE_M1937MORT,
            // Token: 0x04000BE6 RID: 3046
            SPTYPE_M252MORT,
            // Token: 0x04000BE7 RID: 3047
            SPTYPE_LST1179 = 1,
            // Token: 0x04000BE8 RID: 3048
            SPTYPE_NOTHING = 1,
            // Token: 0x04000BE9 RID: 3049
            SPTYPE_NOWEAPON,
            // Token: 0x04000BEA RID: 3050
            SPTYPE_OSA2 = 1,
            // Token: 0x04000BEB RID: 3051
            SPTYPE_WILDCAT,
            // Token: 0x04000BEC RID: 3052
            SPTYPE_PONTOONBRIDGE = 1,
            // Token: 0x04000BED RID: 3053
            SPTYPE_PUFFY_CLOUD1 = 1,
            // Token: 0x04000BEE RID: 3054
            SPTYPE_SINGLE = 1,
            // Token: 0x04000BEF RID: 3055
            SPTYPE_TRIPLE,
            // Token: 0x04000BF0 RID: 3056
            SPTYPE_LAU3A = 1,
            // Token: 0x04000BF1 RID: 3057
            SPTYPE_UB3257,
            // Token: 0x04000BF2 RID: 3058
            SPTYPE_VIKHR = 22,
            // Token: 0x04000BF3 RID: 3059
            SPTYPE_SMALL_CRATER1 = 1,
            // Token: 0x04000BF4 RID: 3060
            SPTYPE_FIRETEAM = 1,
            // Token: 0x04000BF5 RID: 3061
            SPTYPE_DD963 = 1,
            // Token: 0x04000BF6 RID: 3062
            SPTYPE_DELTA = 1,
            // Token: 0x04000BF7 RID: 3063
            SPTYPE_TRIDENT,
            // Token: 0x04000BF8 RID: 3064
            SPTYPE_PTK250 = 9,
            // Token: 0x04000BF9 RID: 3065
            SPTYPE_TYPHOON = 3,
            // Token: 0x04000BFA RID: 3066
            SPTYPE_OSCAR = 1,
            // Token: 0x04000BFB RID: 3067
            SPTYPE_AKULA = 1,
            // Token: 0x04000BFC RID: 3068
            SPTYPE_KILO,
            // Token: 0x04000BFD RID: 3069
            SPTYPE_LOSANGELES,
            // Token: 0x04000BFE RID: 3070
            SPTYPE_SEAWOLF,
            // Token: 0x04000BFF RID: 3071
            SPTYPE_MK32 = 1,
            // Token: 0x04000C00 RID: 3072
            SPTYPE_M167 = 1,
            // Token: 0x04000C01 RID: 3073
            SPTYPE_2A65 = 1,
            // Token: 0x04000C02 RID: 3074
            SPTYPE_M198,
            // Token: 0x04000C03 RID: 3075
            SPTYPE_M163 = 1,
            // Token: 0x04000C04 RID: 3076
            SPTYPE_P76ZSU23_4,
            // Token: 0x04000C05 RID: 3077
            SPTYPE_ZSU57_2 = 4,
            // Token: 0x04000C06 RID: 3078
            SPTYPE_CHAPARRALL = 1,
            // Token: 0x04000C07 RID: 3079
            SPTYPE_M2A2ADATS,
            // Token: 0x04000C08 RID: 3080
            SPTYPE_M2A2ADV,
            // Token: 0x04000C09 RID: 3081
            SPTYPE_SA13L,
            // Token: 0x04000C0A RID: 3082
            SPTYPE_SA15L_GM569,
            // Token: 0x04000C0B RID: 3083
            SPTYPE_SA2L,
            // Token: 0x04000C0C RID: 3084
            SPTYPE_SA4L,
            // Token: 0x04000C0D RID: 3085
            SPTYPE_SA6L,
            // Token: 0x04000C0E RID: 3086
            SPTYPE_M1A1 = 5,
            // Token: 0x04000C0F RID: 3087
            SPTYPE_M1A2,
            // Token: 0x04000C10 RID: 3088
            SPTYPE_M2A2,
            // Token: 0x04000C11 RID: 3089
            SPTYPE_M2A2BC,
            // Token: 0x04000C12 RID: 3090
            SPTYPE_M48A5TNK,
            // Token: 0x04000C13 RID: 3091
            SPTYPE_M60,
            // Token: 0x04000C14 RID: 3092
            SPTYPE_PT76 = 13,
            // Token: 0x04000C15 RID: 3093
            SPTYPE_T55,
            // Token: 0x04000C16 RID: 3094
            SPTYPE_T62,
            // Token: 0x04000C17 RID: 3095
            SPTYPE_T72,
            // Token: 0x04000C18 RID: 3096
            SPTYPE_T80,
            // Token: 0x04000C19 RID: 3097
            SPTYPE_T90,
            // Token: 0x04000C1A RID: 3098
            SPTYPE_TYPE62,
            // Token: 0x04000C1B RID: 3099
            SPTYPE_TYPE80,
            // Token: 0x04000C1C RID: 3100
            SPTYPE_TYPE85II,
            // Token: 0x04000C1D RID: 3101
            SPTYPE_TYPE90II,
            // Token: 0x04000C1E RID: 3102
            SPTYPE_XM8AGS,
            // Token: 0x04000C1F RID: 3103
            SPTYPE_2S19 = 1,
            // Token: 0x04000C20 RID: 3104
            SPTYPE_2S3,
            // Token: 0x04000C21 RID: 3105
            SPTYPE_M109,
            // Token: 0x04000C22 RID: 3106
            SPTYPE_M110A2,
            // Token: 0x04000C23 RID: 3107
            SPTYPE_M1973SPARTY,
            // Token: 0x04000C24 RID: 3108
            SPTYPE_M1974SPARTY,
            // Token: 0x04000C25 RID: 3109
            SPTYPE_MLRS,
            // Token: 0x04000C26 RID: 3110
            SPTYPE_SM240 = 9,
            // Token: 0x04000C27 RID: 3111
            SPTYPE_AVLM = 1,
            // Token: 0x04000C28 RID: 3112
            SPTYPE_M1MS,
            // Token: 0x04000C29 RID: 3113
            SPTYPE_M60AVLB,
            // Token: 0x04000C2A RID: 3114
            SPTYPE_M88AVRV,
            // Token: 0x04000C2B RID: 3115
            SPTYPE_M9ACE,
            // Token: 0x04000C2C RID: 3116
            SPTYPE_P76MDK_2DOZER,
            // Token: 0x04000C2D RID: 3117
            SPTYPE_P76MT_55BRGLY,
            // Token: 0x04000C2E RID: 3118
            SPTYPE_ACRV = 1,
            // Token: 0x04000C2F RID: 3119
            SPTYPE_MTLBU = 3,
            // Token: 0x04000C30 RID: 3120
            SPTYPE_AAV7A1 = 1,
            // Token: 0x04000C31 RID: 3121
            SPTYPE_AAVC7A1,
            // Token: 0x04000C32 RID: 3122
            SPTYPE_BMD,
            // Token: 0x04000C33 RID: 3123
            SPTYPE_BMP1,
            // Token: 0x04000C34 RID: 3124
            SPTYPE_BMP1ATG,
            // Token: 0x04000C35 RID: 3125
            SPTYPE_BMP2,
            // Token: 0x04000C36 RID: 3126
            SPTYPE_BMP3,
            // Token: 0x04000C37 RID: 3127
            SPTYPE_M113 = 9,
            // Token: 0x04000C38 RID: 3128
            SPTYPE_M113A3,
            // Token: 0x04000C39 RID: 3129
            SPTYPE_M901,
            // Token: 0x04000C3A RID: 3130
            SPTYPE_160mmMRTL = 1,
            // Token: 0x04000C3B RID: 3131
            SPTYPE_FROG7L_ZIL135 = 1,
            // Token: 0x04000C3C RID: 3132
            SPTYPE_MTLB = 3,
            // Token: 0x04000C3D RID: 3133
            SPTYPE_YW_534_APC,
            // Token: 0x04000C3E RID: 3134
            SPTYPE_BRIGADE = 1,
            // Token: 0x04000C3F RID: 3135
            SPTYPE_CHINESE_SA6,
            // Token: 0x04000C40 RID: 3136
            SPTYPE_CHINESE_ZU23,
            // Token: 0x04000C41 RID: 3137
            SPTYPE_DPRK_SA2,
            // Token: 0x04000C42 RID: 3138
            SPTYPE_DPRK_SA3,
            // Token: 0x04000C43 RID: 3139
            SPTYPE_DPRK_SA5,
            // Token: 0x04000C44 RID: 3140
            SPTYPE_DPRK_ZSU57,
            // Token: 0x04000C45 RID: 3141
            SPTYPE_ROK_HAWK,
            // Token: 0x04000C46 RID: 3142
            SPTYPE_30mmAAA = 1,
            // Token: 0x04000C47 RID: 3143
            SPTYPE_203mm = 6,
            // Token: 0x04000C48 RID: 3144
            SPTYPE_25mm = 25,
            // Token: 0x04000C49 RID: 3145
            SPTYPE_M2A3 = 8,
            // Token: 0x04000C4A RID: 3146
            SPTYPE_HUMMVSTD = 15,
            // Token: 0x04000C4B RID: 3147
            SPTYPE_HUMMVCARGO = 14,
            // Token: 0x04000C4C RID: 3148
            SPTYPE_HMMWV_AMB = 13,
            // Token: 0x04000C4D RID: 3149
            SPTYPE_ROK_NIKE = 9,
            // Token: 0x04000C4E RID: 3150
            SPTYPE_SOVIET_SA15,
            // Token: 0x04000C4F RID: 3151
            SPTYPE_SOVIET_SA6,
            // Token: 0x04000C50 RID: 3152
            SPTYPE_SOVIET_SA8,
            // Token: 0x04000C51 RID: 3153
            SPTYPE_US_HAWK,
            // Token: 0x04000C52 RID: 3154
            SPTYPE_US_PATRIOT = 7,
            // Token: 0x04000C53 RID: 3155
            SPTYPE_SOVIET_AIR = 1,
            // Token: 0x04000C54 RID: 3156
            SPTYPE_US_AIR,
            // Token: 0x04000C55 RID: 3157
            SPTYPE_DPRK_AMPH = 1,
            // Token: 0x04000C56 RID: 3158
            SPTYPE_SOVIET_AMPH,
            // Token: 0x04000C57 RID: 3159
            SPTYPE_US_AMPH,
            // Token: 0x04000C58 RID: 3160
            SPTYPE_CHINESE_TYPE80 = 2,
            // Token: 0x04000C59 RID: 3161
            SPTYPE_CHINESE_TYPE85II,
            // Token: 0x04000C5A RID: 3162
            SPTYPE_CHINESE_TYPE90II,
            // Token: 0x04000C5B RID: 3163
            SPTYPE_DPRK_T62,
            // Token: 0x04000C5C RID: 3164
            SPTYPE_ROK_M48,
            // Token: 0x04000C5D RID: 3165
            SPTYPE_SOVIET_T72,
            // Token: 0x04000C5E RID: 3166
            SPTYPE_SOVIET_T80,
            // Token: 0x04000C5F RID: 3167
            SPTYPE_SOVIET_T90,
            // Token: 0x04000C60 RID: 3168
            SPTYPE_US_M1,
            // Token: 0x04000C61 RID: 3169
            SPTYPE_US_M60,
            // Token: 0x04000C62 RID: 3170
            SPTYPE_US_CAV = 1,
            // Token: 0x04000C63 RID: 3171
            SPTYPE_CHINESE_BB = 1,
            // Token: 0x04000C64 RID: 3172
            SPTYPE_SOVIET_BB,
            // Token: 0x04000C65 RID: 3173
            SPTYPE_US_BB,
            // Token: 0x04000C66 RID: 3174
            SPTYPE_CHINESE_CV = 1,
            // Token: 0x04000C67 RID: 3175
            SPTYPE_SOVIET_CV,
            // Token: 0x04000C68 RID: 3176
            SPTYPE_US_CV,
            // Token: 0x04000C69 RID: 3177
            SPTYPE_CHINESE_CR = 1,
            // Token: 0x04000C6A RID: 3178
            SPTYPE_SOVIET_CR,
            // Token: 0x04000C6B RID: 3179
            SPTYPE_US_CR,
            // Token: 0x04000C6C RID: 3180
            SPTYPE_ROK_DD = 1,
            // Token: 0x04000C6D RID: 3181
            SPTYPE_SOVIET_DD,
            // Token: 0x04000C6E RID: 3182
            SPTYPE_US_DD,
            // Token: 0x04000C6F RID: 3183
            SPTYPE_SOVIET_ENG = 2,
            // Token: 0x04000C70 RID: 3184
            SPTYPE_US_ENG = 1,
            // Token: 0x04000C71 RID: 3185
            SPTYPE_CHINESE_FF = 1,
            // Token: 0x04000C72 RID: 3186
            SPTYPE_ROK_FF,
            // Token: 0x04000C73 RID: 3187
            SPTYPE_SOVIET_FF,
            // Token: 0x04000C74 RID: 3188
            SPTYPE_CHINESE_HQ = 2,
            // Token: 0x04000C75 RID: 3189
            SPTYPE_DPRK_HQ,
            // Token: 0x04000C76 RID: 3190
            SPTYPE_ROK_HQ,
            // Token: 0x04000C77 RID: 3191
            SPTYPE_SOVIET_HQ,
            // Token: 0x04000C78 RID: 3192
            SPTYPE_US_HQ = 1,
            // Token: 0x04000C79 RID: 3193
            SPTYPE_CHINESE_INF,
            // Token: 0x04000C7A RID: 3194
            SPTYPE_DPRK_INF,
            // Token: 0x04000C7B RID: 3195
            SPTYPE_ROK_INF,
            // Token: 0x04000C7C RID: 3196
            SPTYPE_SOVIET_INF,
            // Token: 0x04000C7D RID: 3197
            SPTYPE_US_INF = 1,
            // Token: 0x04000C7E RID: 3198
            SPTYPE_SOVIET_MARINE,
            // Token: 0x04000C7F RID: 3199
            SPTYPE_US_LAV25 = 1,
            // Token: 0x04000C80 RID: 3200
            SPTYPE_CHINESE_MECH,
            // Token: 0x04000C81 RID: 3201
            SPTYPE_DPRK_BMP1,
            // Token: 0x04000C82 RID: 3202
            SPTYPE_ROK_M113,
            // Token: 0x04000C83 RID: 3203
            SPTYPE_SOVIET_MECH,
            // Token: 0x04000C84 RID: 3204
            SPTYPE_US_M2 = 1,
            // Token: 0x04000C85 RID: 3205
            SPTYPE_DPRK_PAT = 1,
            // Token: 0x04000C86 RID: 3206
            SPTYPE_SOVIET_BM21,
            // Token: 0x04000C87 RID: 3207
            SPTYPE_SOVIET_BM24,
            // Token: 0x04000C88 RID: 3208
            SPTYPE_SOVIET_BM9A52,
            // Token: 0x04000C89 RID: 3209
            SPTYPE_US_MLRS,
            // Token: 0x04000C8A RID: 3210
            SPTYPE_ANY_SS = 1,
            // Token: 0x04000C8B RID: 3211
            SPTYPE_SOVIET_SS,
            // Token: 0x04000C8C RID: 3212
            SPTYPE_US_SS,
            // Token: 0x04000C8D RID: 3213
            SPTYPE_ANY_TANK = 1,
            // Token: 0x04000C8E RID: 3214
            SPTYPE_SOVIET_TRAN = 1,
            // Token: 0x04000C8F RID: 3215
            SPTYPE_US_TRAN,
            // Token: 0x04000C90 RID: 3216
            SPTYPE_CHINESE_SP = 2,
            // Token: 0x04000C91 RID: 3217
            SPTYPE_ROK_SP = 4,
            // Token: 0x04000C92 RID: 3218
            SPTYPE_SOVIET_SP,
            // Token: 0x04000C93 RID: 3219
            SPTYPE_US_M109,
            // Token: 0x04000C94 RID: 3220
            SPTYPE_SOVIET_FROG7 = 2,
            // Token: 0x04000C95 RID: 3221
            SPTYPE_SOVIET_SCUD,
            // Token: 0x04000C96 RID: 3222
            SPTYPE_CHINESE_SSBN = 1,
            // Token: 0x04000C97 RID: 3223
            SPTYPE_SOVIET_SSBN,
            // Token: 0x04000C98 RID: 3224
            SPTYPE_US_SSBN,
            // Token: 0x04000C99 RID: 3225
            SPTYPE_CHINESE_SSGN = 1,
            // Token: 0x04000C9A RID: 3226
            SPTYPE_SOVIET_SSGN,
            // Token: 0x04000C9B RID: 3227
            SPTYPE_US_SSGN,
            // Token: 0x04000C9C RID: 3228
            SPTYPE_CHINESE_SSN = 1,
            // Token: 0x04000C9D RID: 3229
            SPTYPE_SOVIET_SSN,
            // Token: 0x04000C9E RID: 3230
            SPTYPE_US_SSN,
            // Token: 0x04000C9F RID: 3231
            SPTYPE_SOVIET_SUP = 2,
            // Token: 0x04000CA0 RID: 3232
            SPTYPE_US_SUP = 1,
            // Token: 0x04000CA1 RID: 3233
            SPTYPE_CHINESE_ART,
            // Token: 0x04000CA2 RID: 3234
            SPTYPE_SOVIET_ART,
            // Token: 0x04000CA3 RID: 3235
            SPTYPE_US_M198 = 1,
            // Token: 0x04000CA4 RID: 3236
            SPTYPE_LHD1 = 1,
            // Token: 0x04000CA5 RID: 3237
            SPTYPE_ZSU30 = 1,
            // Token: 0x04000CA6 RID: 3238
            SPTYPE_ZU_23AAA,
            // Token: 0x04000CA7 RID: 3239
            SPTYPE_2S6_TUNGUSKA = 1,
            // Token: 0x04000CA8 RID: 3240
            SPTYPE_HAWKL,
            // Token: 0x04000CA9 RID: 3241
            SPTYPE_HUMMVAVG,
            // Token: 0x04000CAA RID: 3242
            SPTYPE_LAVADATS,
            // Token: 0x04000CAB RID: 3243
            SPTYPE_LAVADV,
            // Token: 0x04000CAC RID: 3244
            SPTYPE_MK29L,
            // Token: 0x04000CAD RID: 3245
            SPTYPE_NIKEL,
            // Token: 0x04000CAE RID: 3246
            SPTYPE_PATRIOTL,
            // Token: 0x04000CAF RID: 3247
            SPTYPE_SA2R,
            // Token: 0x04000CB0 RID: 3248
            SPTYPE_SA3L,
            // Token: 0x04000CB1 RID: 3249
            SPTYPE_SA3R,
            // Token: 0x04000CB2 RID: 3250
            SPTYPE_SA4R,
            // Token: 0x04000CB3 RID: 3251
            SPTYPE_SA5L,
            // Token: 0x04000CB4 RID: 3252
            SPTYPE_SA5R,
            // Token: 0x04000CB5 RID: 3253
            SPTYPE_SA8L,
            // Token: 0x04000CB6 RID: 3254
            SPTYPE_SA9L,
            // Token: 0x04000CB7 RID: 3255
            SPTYPE_BM21MLRS = 1,
            // Token: 0x04000CB8 RID: 3256
            SPTYPE_BM24MLRS,
            // Token: 0x04000CB9 RID: 3257
            SPTYPE_BM9A52,
            // Token: 0x04000CBA RID: 3258
            SPTYPE_HUMMVTOW = 16,
            // Token: 0x04000CBB RID: 3259
            SPTYPE_LAVR = 1,
            // Token: 0x04000CBC RID: 3260
            SPTYPE_FIRETRUCK = 1,
            // Token: 0x04000CBD RID: 3261
            SPTYPE_HAWKRADAR = 17,
            // Token: 0x04000CBE RID: 3262
            SPTYPE_M997HQ = 1,
            // Token: 0x04000CBF RID: 3263
            SPTYPE_NIKERADAR = 18,
            // Token: 0x04000CC0 RID: 3264
            SPTYPE_PATRIOTR,
            // Token: 0x04000CC1 RID: 3265
            SPTYPE_SA6RADAR,
            // Token: 0x04000CC2 RID: 3266
            SPTYPE_BRDM1 = 1,
            // Token: 0x04000CC3 RID: 3267
            SPTYPE_BRDM2,
            // Token: 0x04000CC4 RID: 3268
            SPTYPE_BRDM3,
            // Token: 0x04000CC5 RID: 3269
            SPTYPE_BTR70,
            // Token: 0x04000CC6 RID: 3270
            SPTYPE_BTR80,
            // Token: 0x04000CC7 RID: 3271
            SPTYPE_FAV,
            // Token: 0x04000CC8 RID: 3272
            SPTYPE_LAV25,
            // Token: 0x04000CC9 RID: 3273
            SPTYPE_LAVC2,
            // Token: 0x04000CCA RID: 3274
            SPTYPE_LAVM,
            // Token: 0x04000CCB RID: 3275
            SPTYPE_LAVTOW,
            // Token: 0x04000CCC RID: 3276
            SPTYPE_M998 = 12,
            // Token: 0x04000CCD RID: 3277
            SPTYPE_CAR = 2,
            // Token: 0x04000CCE RID: 3278
            SPTYPE_CARGOTRUCK,
            // Token: 0x04000CCF RID: 3279
            SPTYPE_FUELTRUCK,
            // Token: 0x04000CD0 RID: 3280
            SPTYPE_JEEP,
            // Token: 0x04000CD1 RID: 3281
            SPTYPE_KrAz255B,
            // Token: 0x04000CD2 RID: 3282
            SPTYPE_KrAzFUEL,
            // Token: 0x04000CD3 RID: 3283
            SPTYPE_M977,
            // Token: 0x04000CD4 RID: 3284
            SPTYPE_M977_FUEL,
            // Token: 0x04000CD5 RID: 3285
            SPTYPE_M977CARGO,
            // Token: 0x04000CD6 RID: 3286
            SPTYPE_SCUDL,
            // Token: 0x04000CD7 RID: 3287
            SPTYPE_WC_551_APC,
            // Token: 0x04000CD8 RID: 3288
            SPTYPE_120mmHE = 26,
            // Token: 0x04000CD9 RID: 3289
            SPTYPE_105mmAP = 17,
            // Token: 0x04000CDA RID: 3290
            SPTYPE_105mmHE,
            // Token: 0x04000CDB RID: 3291
            SPTYPE_115mmAP,
            // Token: 0x04000CDC RID: 3292
            SPTYPE_115mmHE,
            // Token: 0x04000CDD RID: 3293
            SPTYPE_125mmAP,
            // Token: 0x04000CDE RID: 3294
            SPTYPE_125mmHE,
            // Token: 0x04000CDF RID: 3295
            SPTYPE_135mmAP,
            // Token: 0x04000CE0 RID: 3296
            SPTYPE_135mmHE,
            // Token: 0x04000CE1 RID: 3297
            SPTYPE_155mmAAA = 3,
            // Token: 0x04000CE2 RID: 3298
            SPTYPE_155mmHE = 7,
            // Token: 0x04000CE3 RID: 3299
            SPTYPE_122mmHE = 5,
            // Token: 0x04000CE4 RID: 3300
            SPTYPE_2S1 = 8,
            // Token: 0x04000CE5 RID: 3301
            SPTYPE_ZIL135 = 1,
            // Token: 0x04000CE6 RID: 3302
            SPTYPE_DPRK_SP_152 = 1,
            // Token: 0x04000CE7 RID: 3303
            SPTYPE_DPRK_AAA = 1,
            // Token: 0x04000CE8 RID: 3304
            SPTYPE_DPRK_SP_122 = 3,
            // Token: 0x04000CE9 RID: 3305
            SPTYPE_DPRK_FROG,
            // Token: 0x04000CEA RID: 3306
            SPTYPE_TEST = 1,
            // Token: 0x04000CEB RID: 3307
            SPTYPE_DPRK_SCUD = 1,
            // Token: 0x04000CEC RID: 3308
            SPTYPE_DPRK_T55 = 1,
            // Token: 0x04000CED RID: 3309
            SPTYPE_DPRK_AIR_MOBILE = 3,
            // Token: 0x04000CEE RID: 3310
            SPTYPE_DPRK_BM21 = 1,
            // Token: 0x04000CEF RID: 3311
            SPTYPE_2_75mm = 4,
            // Token: 0x04000CF0 RID: 3312
            SPTYPE_GBU15 = 4,
            // Token: 0x04000CF1 RID: 3313
            SPTYPE_F18D = 6,
            // Token: 0x04000CF2 RID: 3314
            SPTYPE_F18A,
            // Token: 0x04000CF3 RID: 3315
            SPTYPE_F18E = 4,
            // Token: 0x04000CF4 RID: 3316
            SPTYPE_AN24 = 14,
            // Token: 0x04000CF5 RID: 3317
            SPTYPE_MK46 = 2,
            // Token: 0x04000CF6 RID: 3318
            SPTYPE_GPU5 = 27,
            // Token: 0x04000CF7 RID: 3319
            SPTYPE_FAB250LD = 6,
            // Token: 0x04000CF8 RID: 3320
            SPTYPE_FAB250HD,
            // Token: 0x04000CF9 RID: 3321
            SPTYPE_GBU28B = 7,
            // Token: 0x04000CFA RID: 3322
            SPTYPE_FAB250LGB = 5,
            // Token: 0x04000CFB RID: 3323
            SPTYPE_FAB1000LD = 8,
            // Token: 0x04000CFC RID: 3324
            SPTYPE_FAB1000HD,
            // Token: 0x04000CFD RID: 3325
            SPTYPE_FAB1000LGB = 6,
            // Token: 0x04000CFE RID: 3326
            SPTYPE_LANTIRN_NAV = 1,
            // Token: 0x04000CFF RID: 3327
            SPTYPE_LANTIRN_TARG,
            // Token: 0x04000D00 RID: 3328
            SPTYPE_AGM130 = 19,
            // Token: 0x04000D01 RID: 3329
            SPTYPE_AT4 = 2,
            // Token: 0x04000D02 RID: 3330
            SPTYPE_SA12 = 11,
            // Token: 0x04000D03 RID: 3331
            SPTYPE_MLRS_ROCKET = 5,
            // Token: 0x04000D04 RID: 3332
            SPTYPE_UB1957 = 3,
            // Token: 0x04000D05 RID: 3333
            SPTYPE_RPK180 = 10,
            // Token: 0x04000D06 RID: 3334
            SPTYPE_RPK500,
            // Token: 0x04000D07 RID: 3335
            SPTYPE_AA8R = 19,
            // Token: 0x04000D08 RID: 3336
            SPTYPE_CHAFF1 = 1,
            // Token: 0x04000D09 RID: 3337
            SPTYPE_300GALW = 6,
            // Token: 0x04000D0A RID: 3338
            SPTYPE_57MMROCK = 6,
            // Token: 0x04000D0B RID: 3339
            SPTYPE_DESTBOMBER = 8,
            // Token: 0x04000D0C RID: 3340
            SPTYPE_DISRUPTOR = 20,
            // Token: 0x04000D0D RID: 3341
            SPTYPE_FFG = 3,
            // Token: 0x04000D0E RID: 3342
            SPTYPE_ENFAC = 3,
            // Token: 0x04000D0F RID: 3343
            SPTYPE_DESTF16_1 = 8,
            // Token: 0x04000D10 RID: 3344
            SPTYPE_DESTF16_2,
            // Token: 0x04000D11 RID: 3345
            SPTYPE_DESTMIG29 = 17,
            // Token: 0x04000D12 RID: 3346
            SPTYPE_KIROV = 2,
            // Token: 0x04000D13 RID: 3347
            SPTYPE_ROK_MARINE,
            // Token: 0x04000D14 RID: 3348
            SPTYPE_ROK_AAA = 14,
            // Token: 0x04000D15 RID: 3349
            SPTYPE_ROK_M198 = 4,
            // Token: 0x04000D16 RID: 3350
            SPTYPE_DESTASW = 3,
            // Token: 0x04000D17 RID: 3351
            SPTYPE_DESTATTACK = 14,
            // Token: 0x04000D18 RID: 3352
            SPTYPE_DESTAWACS = 4,
            // Token: 0x04000D19 RID: 3353
            SPTYPE_DESTECM = 3,
            // Token: 0x04000D1A RID: 3354
            SPTYPE_DESTJSTAR = 2,
            // Token: 0x04000D1B RID: 3355
            SPTYPE_DESTRECON = 7,
            // Token: 0x04000D1C RID: 3356
            SPTYPE_DESTTANKER = 6,
            // Token: 0x04000D1D RID: 3357
            SPTYPE_DESTTRANSPORT = 15,
            // Token: 0x04000D1E RID: 3358
            SPTYPE_DESTATTHELO = 9,
            // Token: 0x04000D1F RID: 3359
            SPTYPE_DESTRECHELO = 3,
            // Token: 0x04000D20 RID: 3360
            SPTYPE_DESTTRANHELO = 7,
            // Token: 0x04000D21 RID: 3361
            SPTYPE_DESTMIG19 = 18,
            // Token: 0x04000D22 RID: 3362
            SPTYPE_DESTMIG21,
            // Token: 0x04000D23 RID: 3363
            SPTYPE_RIFLE = 30,
            // Token: 0x04000D24 RID: 3364
            SPTYPE_RES_INF_SQUAD = 24,
            // Token: 0x04000D25 RID: 3365
            SPTYPE_ALL_RESERVE = 1,
            // Token: 0x04000D26 RID: 3366
            SPTYPE_DEBRIS1 = 1,
            // Token: 0x04000D27 RID: 3367
            SPTYPE_DEBRIS2,
            // Token: 0x04000D28 RID: 3368
            SPTYPE_DEBRIS3,
            // Token: 0x04000D29 RID: 3369
            SPTYPE_CRATER2 = 1,
            // Token: 0x04000D2A RID: 3370
            SPTYPE_CRATER3,
            // Token: 0x04000D2B RID: 3371
            SPTYPE_CRATER4,
            // Token: 0x04000D2C RID: 3372
            SPTYPE_DESTIL28 = 15,
            // Token: 0x04000D2D RID: 3373
            SPTYPE_DESTMIG23MS = 20,
            // Token: 0x04000D2E RID: 3374
            SPTYPE_DESTSU25 = 16,
            // Token: 0x04000D2F RID: 3375
            SPTYPE_DESTSU27 = 21,
            // Token: 0x04000D30 RID: 3376
            SPTYPE_DESTAN2 = 16,
            // Token: 0x04000D31 RID: 3377
            SPTYPE_30MM_TAIL_GUN = 1,
            // Token: 0x04000D32 RID: 3378
            SPTYPE_DPRK_BMP2 = 6,
            // Token: 0x04000D33 RID: 3379
            SPTYPE_DPRK_TOW_ART = 1,
            // Token: 0x04000D34 RID: 3380
            SPTYPE_D30 = 3,
            // Token: 0x04000D35 RID: 3381
            SPTYPE_SIX = 3,
            // Token: 0x04000D36 RID: 3382
            SPTYPE_QUAD,
            // Token: 0x04000D37 RID: 3383
            SPTYPE_GUYDIE = 25,
            // Token: 0x04000D38 RID: 3384
            SPTYPE_DOWN_PILOT,
            // Token: 0x04000D39 RID: 3385
            SPTYPE_DPRK_FF = 3,
            // Token: 0x04000D3A RID: 3386
            SPTYPE_ROK_PATROL = 2,
            // Token: 0x04000D3B RID: 3387
            SPTYPE_240MM = 8,
            // Token: 0x04000D3C RID: 3388
            SPTYPE_NUM380 = 1,
            // Token: 0x04000D3D RID: 3389
            SPTYPE_NUM270,
            // Token: 0x04000D3E RID: 3390
            SPTYPE_NUM160,
            // Token: 0x04000D3F RID: 3391
            SPTYPE_NAJIN,
            // Token: 0x04000D40 RID: 3392
            SPTYPE_AC130 = 16,
            // Token: 0x04000D41 RID: 3393
            SPTYPE_F16BLU = 14,
            // Token: 0x04000D42 RID: 3394
            SPTYPE_F4,
            // Token: 0x04000D43 RID: 3395
            SPTYPE_F5,
            // Token: 0x04000D44 RID: 3396
            SPTYPE_F16B = 8,
            // Token: 0x04000D45 RID: 3397
            SPTYPE_PRC_MIG21 = 16,
            // Token: 0x04000D46 RID: 3398
            SPTYPE_CIS_MIG29,
            // Token: 0x04000D47 RID: 3399
            SPTYPE_CIS_SU27,
            // Token: 0x04000D48 RID: 3400
            SPTYPE_PRC_SU27,
            // Token: 0x04000D49 RID: 3401
            SPTYPE_57MM_HE = 31,
            // Token: 0x04000D4A RID: 3402
            SPTYPE_SINGLE_AA = 5,
            // Token: 0x04000D4B RID: 3403
            SPTYPE_2RAIL,
            // Token: 0x04000D4C RID: 3404
            SPTYPE_MAVRACK,
            // Token: 0x04000D4D RID: 3405
            SPTYPE_MUH1 = 7,
            // Token: 0x04000D4E RID: 3406
            SPTYPE_CUH1,
            // Token: 0x04000D4F RID: 3407
            SPTYPE_NUM01 = 4,
            // Token: 0x04000D50 RID: 3408
            SPTYPE_RCKT1 = 1,
            // Token: 0x04000D51 RID: 3409
            SPTYPE_AA10A = 21,
            // Token: 0x04000D52 RID: 3410
            SPTYPE_DPRK_HART = 5,
            // Token: 0x04000D53 RID: 3411
            SPTYPE_ALL_AK47SQUAD = 27,
            // Token: 0x04000D54 RID: 3412
            SPTYPE_AK47 = 32,
            // Token: 0x04000D55 RID: 3413
            SPTYPE_CF16A = 8,
            // Token: 0x04000D56 RID: 3414
            SPTYPE_BIRACK = 8,
            // Token: 0x04000D57 RID: 3415
            SPTYPE_HBIRACK,
            // Token: 0x04000D58 RID: 3416
            SPTYPE_HTRIRACK,
            // Token: 0x04000D59 RID: 3417
            SPTYPE_HONERACK,
            // Token: 0x04000D5A RID: 3418
            SPTYPE_RTRIRACK,
            // Token: 0x04000D5B RID: 3419
            SPTYPE_ONELAU3A = 1,
            // Token: 0x04000D5C RID: 3420
            SPTYPE_BILAU3A,
            // Token: 0x04000D5D RID: 3421
            SPTYPE_TRILAU3A,
            // Token: 0x04000D5E RID: 3422
            SPTYPE_NUM23RW = 5,
            // Token: 0x04000D5F RID: 3423
            SPTYPE_NUM05LW,
            // Token: 0x04000D60 RID: 3424
            SPTYPE_WLOADER = 2,
            // Token: 0x04000D61 RID: 3425
            SPTYPE_APU,
            // Token: 0x04000D62 RID: 3426
            SPTYPE_WTRAILER,
            // Token: 0x04000D63 RID: 3427
            SPTYPE_CARRIER = 7
        }

        // Token: 0x020000AB RID: 171
        public enum Mode_Types
        {
            // Token: 0x04000D65 RID: 3429
            MODE_CRIMSON = 1,
            // Token: 0x04000D66 RID: 3430
            MODE_NORMAL = 0,
            // Token: 0x04000D67 RID: 3431
            MODE_SHARK = 2,
            // Token: 0x04000D68 RID: 3432
            MODE_TIGER = 4,
            // Token: 0x04000D69 RID: 3433
            MODE_VIPER = 3
        }

        // Token: 0x020000AC RID: 172
        public enum Data_Types
        {
            // Token: 0x04000D6B RID: 3435
            DTYPE_FEATURE = 1,
            // Token: 0x04000D6C RID: 3436
            DTYPE_NONE,
            // Token: 0x04000D6D RID: 3437
            DTYPE_OBJECTIVE,
            // Token: 0x04000D6E RID: 3438
            DTYPE_UNIT,
            // Token: 0x04000D6F RID: 3439
            DTYPE_VEHICLE,
            // Token: 0x04000D70 RID: 3440
            DTYPE_WEAPON
        }

        // Token: 0x020000AD RID: 173
        public enum Bbox_Types
        {
            // Token: 0x04000D72 RID: 3442
            BBOX_NOTHING,
            // Token: 0x04000D73 RID: 3443
            BBOX_120MMAP,
            // Token: 0x04000D74 RID: 3444
            BBOX_275ROCK,
            // Token: 0x04000D75 RID: 3445
            BBOX_2S19,
            // Token: 0x04000D76 RID: 3446
            BBOX_2S6,
            // Token: 0x04000D77 RID: 3447
            BBOX_370GAL,
            // Token: 0x04000D78 RID: 3448
            BBOX_A10,
            // Token: 0x04000D79 RID: 3449
            BBOX_A37,
            // Token: 0x04000D7A RID: 3450
            BBOX_A50,
            // Token: 0x04000D7B RID: 3451
            BBOX_A6,
            // Token: 0x04000D7C RID: 3452
            BBOX_AA10,
            // Token: 0x04000D7D RID: 3453
            BBOX_AA10C,
            // Token: 0x04000D7E RID: 3454
            BBOX_AA11,
            // Token: 0x04000D7F RID: 3455
            BBOX_AA12,
            // Token: 0x04000D80 RID: 3456
            BBOX_AA2,
            // Token: 0x04000D81 RID: 3457
            BBOX_AA2R,
            // Token: 0x04000D82 RID: 3458
            BBOX_AA3,
            // Token: 0x04000D83 RID: 3459
            BBOX_AA7,
            // Token: 0x04000D84 RID: 3460
            BBOX_AA7R,
            // Token: 0x04000D85 RID: 3461
            BBOX_AA8,
            // Token: 0x04000D86 RID: 3462
            BBOX_AA9,
            // Token: 0x04000D87 RID: 3463
            BBOX_AAV7A1,
            // Token: 0x04000D88 RID: 3464
            BBOX_AC130,
            // Token: 0x04000D89 RID: 3465
            BBOX_AGM114,
            // Token: 0x04000D8A RID: 3466
            BBOX_AGM119,
            // Token: 0x04000D8B RID: 3467
            BBOX_AGM122,
            // Token: 0x04000D8C RID: 3468
            BBOX_AGM45,
            // Token: 0x04000D8D RID: 3469
            BBOX_AGM65B,
            // Token: 0x04000D8E RID: 3470
            BBOX_AGM65D,
            // Token: 0x04000D8F RID: 3471
            BBOX_AGM65G,
            // Token: 0x04000D90 RID: 3472
            BBOX_AGM78,
            // Token: 0x04000D91 RID: 3473
            BBOX_AGM84,
            // Token: 0x04000D92 RID: 3474
            BBOX_AGM88,
            // Token: 0x04000D93 RID: 3475
            BBOX_AH1,
            // Token: 0x04000D94 RID: 3476
            BBOX_AH64,
            // Token: 0x04000D95 RID: 3477
            BBOX_AH64D,
            // Token: 0x04000D96 RID: 3478
            BBOX_AH66,
            // Token: 0x04000D97 RID: 3479
            BBOX_AIM120,
            // Token: 0x04000D98 RID: 3480
            BBOX_AIM54,
            // Token: 0x04000D99 RID: 3481
            BBOX_AIM7,
            // Token: 0x04000D9A RID: 3482
            BBOX_AIM9M,
            // Token: 0x04000D9B RID: 3483
            BBOX_AIM9P,
            // Token: 0x04000D9C RID: 3484
            BBOX_AIM9R,
            // Token: 0x04000D9D RID: 3485
            BBOX_AKULA,
            // Token: 0x04000D9E RID: 3486
            BBOX_ALQ131,
            // Token: 0x04000D9F RID: 3487
            BBOX_AN12,
            // Token: 0x04000DA0 RID: 3488
            BBOX_AN124,
            // Token: 0x04000DA1 RID: 3489
            BBOX_AN14,
            // Token: 0x04000DA2 RID: 3490
            BBOX_AN2,
            // Token: 0x04000DA3 RID: 3491
            BBOX_AN225,
            // Token: 0x04000DA4 RID: 3492
            BBOX_AN24,
            // Token: 0x04000DA5 RID: 3493
            BBOX_AN70,
            // Token: 0x04000DA6 RID: 3494
            BBOX_AN72,
            // Token: 0x04000DA7 RID: 3495
            BBOX_APT1,
            // Token: 0x04000DA8 RID: 3496
            BBOX_AS10,
            // Token: 0x04000DA9 RID: 3497
            BBOX_AS14,
            // Token: 0x04000DAA RID: 3498
            BBOX_AS15,
            // Token: 0x04000DAB RID: 3499
            BBOX_AS4,
            // Token: 0x04000DAC RID: 3500
            BBOX_AS6,
            // Token: 0x04000DAD RID: 3501
            BBOX_AS7,
            // Token: 0x04000DAE RID: 3502
            BBOX_AS9,
            // Token: 0x04000DAF RID: 3503
            BBOX_AT3,
            // Token: 0x04000DB0 RID: 3504
            BBOX_B1,
            // Token: 0x04000DB1 RID: 3505
            BBOX_B2,
            // Token: 0x04000DB2 RID: 3506
            BBOX_B52,
            // Token: 0x04000DB3 RID: 3507
            BBOX_B52G,
            // Token: 0x04000DB4 RID: 3508
            BBOX_BARRACKS,
            // Token: 0x04000DB5 RID: 3509
            BBOX_BM24,
            // Token: 0x04000DB6 RID: 3510
            BBOX_BMP,
            // Token: 0x04000DB7 RID: 3511
            BBOX_BRDM2,
            // Token: 0x04000DB8 RID: 3512
            BBOX_BRIDGE1,
            // Token: 0x04000DB9 RID: 3513
            BBOX_BRIDGE2,
            // Token: 0x04000DBA RID: 3514
            BBOX_BRIDGE3,
            // Token: 0x04000DBB RID: 3515
            BBOX_BTR80,
            // Token: 0x04000DBC RID: 3516
            BBOX_BUILD1,
            // Token: 0x04000DBD RID: 3517
            BBOX_BUILD2,
            // Token: 0x04000DBE RID: 3518
            BBOX_BUNKER1,
            // Token: 0x04000DBF RID: 3519
            BBOX_C130,
            // Token: 0x04000DC0 RID: 3520
            BBOX_C141,
            // Token: 0x04000DC1 RID: 3521
            BBOX_C17,
            // Token: 0x04000DC2 RID: 3522
            BBOX_C5,
            // Token: 0x04000DC3 RID: 3523
            BBOX_CBU528,
            // Token: 0x04000DC4 RID: 3524
            BBOX_CH46,
            // Token: 0x04000DC5 RID: 3525
            BBOX_CH47,
            // Token: 0x04000DC6 RID: 3526
            BBOX_CHAPARRAL,
            // Token: 0x04000DC7 RID: 3527
            BBOX_CITY_HALL,
            // Token: 0x04000DC8 RID: 3528
            BBOX_CNC1,
            // Token: 0x04000DC9 RID: 3529
            BBOX_DELTA,
            // Token: 0x04000DCA RID: 3530
            BBOX_DOCK1,
            // Token: 0x04000DCB RID: 3531
            BBOX_DURANDAL,
            // Token: 0x04000DCC RID: 3532
            BBOX_E2C,
            // Token: 0x04000DCD RID: 3533
            BBOX_E3,
            // Token: 0x04000DCE RID: 3534
            BBOX_E3BOOM,
            // Token: 0x04000DCF RID: 3535
            BBOX_E8C,
            // Token: 0x04000DD0 RID: 3536
            BBOX_EA6B,
            // Token: 0x04000DD1 RID: 3537
            BBOX_EF111,
            // Token: 0x04000DD2 RID: 3538
            BBOX_EF2000,
            // Token: 0x04000DD3 RID: 3539
            BBOX_F117,
            // Token: 0x04000DD4 RID: 3540
            BBOX_F14,
            // Token: 0x04000DD5 RID: 3541
            BBOX_F15C,
            // Token: 0x04000DD6 RID: 3542
            BBOX_F15E,
            // Token: 0x04000DD7 RID: 3543
            BBOX_F16A,
            // Token: 0x04000DD8 RID: 3544
            BBOX_F16C,
            // Token: 0x04000DD9 RID: 3545
            BBOX_F18,
            // Token: 0x04000DDA RID: 3546
            BBOX_F18A,
            // Token: 0x04000DDB RID: 3547
            BBOX_F18D,
            // Token: 0x04000DDC RID: 3548
            BBOX_F18E,
            // Token: 0x04000DDD RID: 3549
            BBOX_F22,
            // Token: 0x04000DDE RID: 3550
            BBOX_F4,
            // Token: 0x04000DDF RID: 3551
            BBOX_F4G,
            // Token: 0x04000DE0 RID: 3552
            BBOX_F5,
            // Token: 0x04000DE1 RID: 3553
            BBOX_F5E,
            // Token: 0x04000DE2 RID: 3554
            BBOX_FAB250,
            // Token: 0x04000DE3 RID: 3555
            BBOX_FACTORY1,
            // Token: 0x04000DE4 RID: 3556
            BBOX_FACTORY2,
            // Token: 0x04000DE5 RID: 3557
            BBOX_FB111,
            // Token: 0x04000DE6 RID: 3558
            BBOX_FROG7,
            // Token: 0x04000DE7 RID: 3559
            BBOX_FROG7L,
            // Token: 0x04000DE8 RID: 3560
            BBOX_FUELTANK2,
            // Token: 0x04000DE9 RID: 3561
            BBOX_FUELTRUCK,
            // Token: 0x04000DEA RID: 3562
            BBOX_GBU10,
            // Token: 0x04000DEB RID: 3563
            BBOX_GBU12,
            // Token: 0x04000DEC RID: 3564
            BBOX_GBU15,
            // Token: 0x04000DED RID: 3565
            BBOX_GBU24B,
            // Token: 0x04000DEE RID: 3566
            BBOX_HARRIER,
            // Token: 0x04000DEF RID: 3567
            BBOX_HAWK,
            // Token: 0x04000DF0 RID: 3568
            BBOX_HAWKL,
            // Token: 0x04000DF1 RID: 3569
            BBOX_HELLFIRE,
            // Token: 0x04000DF2 RID: 3570
            BBOX_HIGHRISE1,
            // Token: 0x04000DF3 RID: 3571
            BBOX_HMMWV,
            // Token: 0x04000DF4 RID: 3572
            BBOX_HMVAMB,
            // Token: 0x04000DF5 RID: 3573
            BBOX_HMVAVG,
            // Token: 0x04000DF6 RID: 3574
            BBOX_HMVCAR,
            // Token: 0x04000DF7 RID: 3575
            BBOX_HMVTOW,
            // Token: 0x04000DF8 RID: 3576
            BBOX_HOUSE1,
            // Token: 0x04000DF9 RID: 3577
            BBOX_HOUSE2,
            // Token: 0x04000DFA RID: 3578
            BBOX_HOUSE3,
            // Token: 0x04000DFB RID: 3579
            BBOX_HOUSE4,
            // Token: 0x04000DFC RID: 3580
            BBOX_IL28,
            // Token: 0x04000DFD RID: 3581
            BBOX_IL76,
            // Token: 0x04000DFE RID: 3582
            BBOX_IL78,
            // Token: 0x04000DFF RID: 3583
            BBOX_J5,
            // Token: 0x04000E00 RID: 3584
            BBOX_J7,
            // Token: 0x04000E01 RID: 3585
            BBOX_J8,
            // Token: 0x04000E02 RID: 3586
            BBOX_KC10,
            // Token: 0x04000E03 RID: 3587
            BBOX_KC130,
            // Token: 0x04000E04 RID: 3588
            BBOX_KC135,
            // Token: 0x04000E05 RID: 3589
            BBOX_KH50,
            // Token: 0x04000E06 RID: 3590
            BBOX_KILO,
            // Token: 0x04000E07 RID: 3591
            BBOX_LAU3A,
            // Token: 0x04000E08 RID: 3592
            BBOX_LAV25,
            // Token: 0x04000E09 RID: 3593
            BBOX_LAVADV,
            // Token: 0x04000E0A RID: 3594
            BBOX_LAVTOW,
            // Token: 0x04000E0B RID: 3595
            BBOX_LOSANGELES,
            // Token: 0x04000E0C RID: 3596
            BBOX_M110A2,
            // Token: 0x04000E0D RID: 3597
            BBOX_M113,
            // Token: 0x04000E0E RID: 3598
            BBOX_M163,
            // Token: 0x04000E0F RID: 3599
            BBOX_M1A1,
            // Token: 0x04000E10 RID: 3600
            BBOX_M2,
            // Token: 0x04000E11 RID: 3601
            BBOX_M2ADAT,
            // Token: 0x04000E12 RID: 3602
            BBOX_M2ADV,
            // Token: 0x04000E13 RID: 3603
            BBOX_M48,
            // Token: 0x04000E14 RID: 3604
            BBOX_M60,
            // Token: 0x04000E15 RID: 3605
            BBOX_M88,
            // Token: 0x04000E16 RID: 3606
            BBOX_M901,
            // Token: 0x04000E17 RID: 3607
            BBOX_M977C,
            // Token: 0x04000E18 RID: 3608
            BBOX_M977F,
            // Token: 0x04000E19 RID: 3609
            BBOX_M997,
            // Token: 0x04000E1A RID: 3610
            BBOX_M998,
            // Token: 0x04000E1B RID: 3611
            BBOX_MI24,
            // Token: 0x04000E1C RID: 3612
            BBOX_MI26,
            // Token: 0x04000E1D RID: 3613
            BBOX_MI8,
            // Token: 0x04000E1E RID: 3614
            BBOX_MIG19,
            // Token: 0x04000E1F RID: 3615
            BBOX_MIG21,
            // Token: 0x04000E20 RID: 3616
            BBOX_MIG23,
            // Token: 0x04000E21 RID: 3617
            BBOX_MIG25,
            // Token: 0x04000E22 RID: 3618
            BBOX_MIG27,
            // Token: 0x04000E23 RID: 3619
            BBOX_MIG29,
            // Token: 0x04000E24 RID: 3620
            BBOX_MIG31,
            // Token: 0x04000E25 RID: 3621
            BBOX_MINUTEMAN,
            // Token: 0x04000E26 RID: 3622
            BBOX_MIRAGE,
            // Token: 0x04000E27 RID: 3623
            BBOX_MK82,
            // Token: 0x04000E28 RID: 3624
            BBOX_MK84,
            // Token: 0x04000E29 RID: 3625
            BBOX_MLRS,
            // Token: 0x04000E2A RID: 3626
            BBOX_MTLBU,
            // Token: 0x04000E2B RID: 3627
            BBOX_MV22,
            // Token: 0x04000E2C RID: 3628
            BBOX_NEW1,
            // Token: 0x04000E2D RID: 3629
            BBOX_NEW2,
            // Token: 0x04000E2E RID: 3630
            BBOX_NEW3,
            // Token: 0x04000E2F RID: 3631
            BBOX_NEW4,
            // Token: 0x04000E30 RID: 3632
            BBOX_NONE,
            // Token: 0x04000E31 RID: 3633
            BBOX_NUKE_PLANT,
            // Token: 0x04000E32 RID: 3634
            BBOX_OFFICE1,
            // Token: 0x04000E33 RID: 3635
            BBOX_OFFICE2,
            // Token: 0x04000E34 RID: 3636
            BBOX_OH58,
            // Token: 0x04000E35 RID: 3637
            BBOX_OSCAR,
            // Token: 0x04000E36 RID: 3638
            BBOX_OV10D,
            // Token: 0x04000E37 RID: 3639
            BBOX_P3,
            // Token: 0x04000E38 RID: 3640
            BBOX_PATLAUNCH,
            // Token: 0x04000E39 RID: 3641
            BBOX_PATRIOT,
            // Token: 0x04000E3A RID: 3642
            BBOX_PEACEKEEPER,
            // Token: 0x04000E3B RID: 3643
            BBOX_PT76,
            // Token: 0x04000E3C RID: 3644
            BBOX_Q5,
            // Token: 0x04000E3D RID: 3645
            BBOX_RAIL1,
            // Token: 0x04000E3E RID: 3646
            BBOX_RAPIER,
            // Token: 0x04000E3F RID: 3647
            BBOX_RC135,
            // Token: 0x04000E40 RID: 3648
            BBOX_REFINERY1,
            // Token: 0x04000E41 RID: 3649
            BBOX_RTOWER,
            // Token: 0x04000E42 RID: 3650
            BBOX_S_RADAR,
            // Token: 0x04000E43 RID: 3651
            BBOX_S1,
            // Token: 0x04000E44 RID: 3652
            BBOX_S3,
            // Token: 0x04000E45 RID: 3653
            BBOX_SA10,
            // Token: 0x04000E46 RID: 3654
            BBOX_SA13,
            // Token: 0x04000E47 RID: 3655
            BBOX_SA13L,
            // Token: 0x04000E48 RID: 3656
            BBOX_SA2,
            // Token: 0x04000E49 RID: 3657
            BBOX_SA2L,
            // Token: 0x04000E4A RID: 3658
            BBOX_SA2R,
            // Token: 0x04000E4B RID: 3659
            BBOX_SA3,
            // Token: 0x04000E4C RID: 3660
            BBOX_SA3L,
            // Token: 0x04000E4D RID: 3661
            BBOX_SA3R,
            // Token: 0x04000E4E RID: 3662
            BBOX_SA4,
            // Token: 0x04000E4F RID: 3663
            BBOX_SA4L,
            // Token: 0x04000E50 RID: 3664
            BBOX_SA4R,
            // Token: 0x04000E51 RID: 3665
            BBOX_SA5,
            // Token: 0x04000E52 RID: 3666
            BBOX_SA5L,
            // Token: 0x04000E53 RID: 3667
            BBOX_SA5R,
            // Token: 0x04000E54 RID: 3668
            BBOX_SA6,
            // Token: 0x04000E55 RID: 3669
            BBOX_SA6L,
            // Token: 0x04000E56 RID: 3670
            BBOX_SA7,
            // Token: 0x04000E57 RID: 3671
            BBOX_SA8,
            // Token: 0x04000E58 RID: 3672
            BBOX_SA8L,
            // Token: 0x04000E59 RID: 3673
            BBOX_SCUDL,
            // Token: 0x04000E5A RID: 3674
            BBOX_SEAWOLF,
            // Token: 0x04000E5B RID: 3675
            BBOX_SH3,
            // Token: 0x04000E5C RID: 3676
            BBOX_SINGLE_RACK,
            // Token: 0x04000E5D RID: 3677
            BBOX_SMALL_CRATER1,
            // Token: 0x04000E5E RID: 3678
            BBOX_SR71,
            // Token: 0x04000E5F RID: 3679
            BBOX_SS1,
            // Token: 0x04000E60 RID: 3680
            BBOX_SS18,
            // Token: 0x04000E61 RID: 3681
            BBOX_SS21,
            // Token: 0x04000E62 RID: 3682
            BBOX_SS24,
            // Token: 0x04000E63 RID: 3683
            BBOX_SS45,
            // Token: 0x04000E64 RID: 3684
            BBOX_STINGER,
            // Token: 0x04000E65 RID: 3685
            BBOX_SU15,
            // Token: 0x04000E66 RID: 3686
            BBOX_SU24,
            // Token: 0x04000E67 RID: 3687
            BBOX_SU25,
            // Token: 0x04000E68 RID: 3688
            BBOX_SU27,
            // Token: 0x04000E69 RID: 3689
            BBOX_SU7,
            // Token: 0x04000E6A RID: 3690
            BBOX_T62,
            // Token: 0x04000E6B RID: 3691
            BBOX_T72,
            // Token: 0x04000E6C RID: 3692
            BBOX_T80,
            // Token: 0x04000E6D RID: 3693
            BBOX_TAXI2,
            // Token: 0x04000E6E RID: 3694
            BBOX_TR1,
            // Token: 0x04000E6F RID: 3695
            BBOX_TR2,
            // Token: 0x04000E70 RID: 3696
            BBOX_TRIDENT,
            // Token: 0x04000E71 RID: 3697
            BBOX_TRIPLE_RACK,
            // Token: 0x04000E72 RID: 3698
            BBOX_TU16,
            // Token: 0x04000E73 RID: 3699
            BBOX_TU160,
            // Token: 0x04000E74 RID: 3700
            BBOX_TU16N,
            // Token: 0x04000E75 RID: 3701
            BBOX_TU20,
            // Token: 0x04000E76 RID: 3702
            BBOX_TU22,
            // Token: 0x04000E77 RID: 3703
            BBOX_TU95,
            // Token: 0x04000E78 RID: 3704
            BBOX_TYPHOON,
            // Token: 0x04000E79 RID: 3705
            BBOX_U2,
            // Token: 0x04000E7A RID: 3706
            BBOX_UH1H,
            // Token: 0x04000E7B RID: 3707
            BBOX_UH60,
            // Token: 0x04000E7C RID: 3708
            BBOX_UH60L,
            // Token: 0x04000E7D RID: 3709
            BBOX_WAREHOUSE1,
            // Token: 0x04000E7E RID: 3710
            BBOX_WAReHOUSE2,
            // Token: 0x04000E7F RID: 3711
            BBOX_Y12,
            // Token: 0x04000E80 RID: 3712
            BBOX_Y8,
            // Token: 0x04000E81 RID: 3713
            BBOX_ZIL135,
            // Token: 0x04000E82 RID: 3714
            BBOX_ZSU23_4,
            // Token: 0x04000E83 RID: 3715
            BBOX_ZSU30,
            // Token: 0x04000E84 RID: 3716
            BBOX_ZSU57,
            // Token: 0x04000E85 RID: 3717
            BBOX_M109 = 277,
            // Token: 0x04000E86 RID: 3718
            BBOX_GPU5,
            // Token: 0x04000E87 RID: 3719
            BBOX_GBU28B,
            // Token: 0x04000E88 RID: 3720
            BBOX_FAB1000,
            // Token: 0x04000E89 RID: 3721
            BBOX_LNTRN,
            // Token: 0x04000E8A RID: 3722
            BBOX_AGM130,
            // Token: 0x04000E8B RID: 3723
            BBOX_AT4,
            // Token: 0x04000E8C RID: 3724
            BBOX_SA14,
            // Token: 0x04000E8D RID: 3725
            BBOX_SA12,
            // Token: 0x04000E8E RID: 3726
            BBOX_CHAPMIS,
            // Token: 0x04000E8F RID: 3727
            BBOX_HYDRA,
            // Token: 0x04000E90 RID: 3728
            BBOX_UB1957,
            // Token: 0x04000E91 RID: 3729
            BBOX_PTK250,
            // Token: 0x04000E92 RID: 3730
            BBOX_RPK180,
            // Token: 0x04000E93 RID: 3731
            BBOX_RPK500,
            // Token: 0x04000E94 RID: 3732
            BBOX_TOWM1046,
            // Token: 0x04000E95 RID: 3733
            BBOX_M47,
            // Token: 0x04000E96 RID: 3734
            BBOX_AA8R,
            // Token: 0x04000E97 RID: 3735
            BBOX_300GALW,
            // Token: 0x04000E98 RID: 3736
            BBOX_300GAL,
            // Token: 0x04000E99 RID: 3737
            BBOX_CHAFF,
            // Token: 0x04000E9A RID: 3738
            BBOX_57MMROCK,
            // Token: 0x04000E9B RID: 3739
            BBOX_M198,
            // Token: 0x04000E9C RID: 3740
            BBOX_KRAZ255B,
            // Token: 0x04000E9D RID: 3741
            BBOX_APT4,
            // Token: 0x04000E9E RID: 3742
            BBOX_APT5,
            // Token: 0x04000E9F RID: 3743
            BBOX_HOUSE6,
            // Token: 0x04000EA0 RID: 3744
            BBOX_HOUSE7,
            // Token: 0x04000EA1 RID: 3745
            BBOX_HOUSE8,
            // Token: 0x04000EA2 RID: 3746
            BBOX_BARN1,
            // Token: 0x04000EA3 RID: 3747
            BBOX_BARN2,
            // Token: 0x04000EA4 RID: 3748
            BBOX_HOUSE9,
            // Token: 0x04000EA5 RID: 3749
            BBOX_HOUSE10,
            // Token: 0x04000EA6 RID: 3750
            BBOX_HOUSE11,
            // Token: 0x04000EA7 RID: 3751
            BBOX_TWNHALL1,
            // Token: 0x04000EA8 RID: 3752
            BBOX_YARD1,
            // Token: 0x04000EA9 RID: 3753
            BBOX_SHOP4,
            // Token: 0x04000EAA RID: 3754
            BBOX_SHOP5,
            // Token: 0x04000EAB RID: 3755
            BBOX_HANGAR9,
            // Token: 0x04000EAC RID: 3756
            BBOX_HANGAR10,
            // Token: 0x04000EAD RID: 3757
            BBOX_RUNWAY3,
            // Token: 0x04000EAE RID: 3758
            BBOX_RUNWAY4,
            // Token: 0x04000EAF RID: 3759
            BBOX_TEMPLE1,
            // Token: 0x04000EB0 RID: 3760
            BBOX_SHOP6,
            // Token: 0x04000EB1 RID: 3761
            BBOX_HOUSE5,
            // Token: 0x04000EB2 RID: 3762
            BBOX_SHED2,
            // Token: 0x04000EB3 RID: 3763
            BBOX_SHED3,
            // Token: 0x04000EB4 RID: 3764
            BBOX_WTOWER2,
            // Token: 0x04000EB5 RID: 3765
            BBOX_WTOWER3,
            // Token: 0x04000EB6 RID: 3766
            BBOX_SHRINE1,
            // Token: 0x04000EB7 RID: 3767
            BBOX_OFFICE7,
            // Token: 0x04000EB8 RID: 3768
            BBOX_APARTMENT6,
            // Token: 0x04000EB9 RID: 3769
            BBOX_RAMP,
            // Token: 0x04000EBA RID: 3770
            BBOX_RAMP2,
            // Token: 0x04000EBB RID: 3771
            BBOX_STABLE1,
            // Token: 0x04000EBC RID: 3772
            BBOX_PARK1,
            // Token: 0x04000EBD RID: 3773
            BBOX_TREE2,
            // Token: 0x04000EBE RID: 3774
            BBOX_TREE3,
            // Token: 0x04000EBF RID: 3775
            BBOX_TREE4,
            // Token: 0x04000EC0 RID: 3776
            BBOX_HOUSE12,
            // Token: 0x04000EC1 RID: 3777
            BBOX_OFFICE3,
            // Token: 0x04000EC2 RID: 3778
            BBOX_OFFICE4,
            // Token: 0x04000EC3 RID: 3779
            BBOX_OFFICE5,
            // Token: 0x04000EC4 RID: 3780
            BBOX_OFFICE6,
            // Token: 0x04000EC5 RID: 3781
            BBOX_OFFICE8,
            // Token: 0x04000EC6 RID: 3782
            BBOX_SKYSCRAPER1,
            // Token: 0x04000EC7 RID: 3783
            BBOX_SKYSCRAPER2,
            // Token: 0x04000EC8 RID: 3784
            BBOX_OFF_BLOCK,
            // Token: 0x04000EC9 RID: 3785
            BBOX_APARTMENT3,
            // Token: 0x04000ECA RID: 3786
            BBOX_CITY_HALL2,
            // Token: 0x04000ECB RID: 3787
            BBOX_BARRACKS2,
            // Token: 0x04000ECC RID: 3788
            BBOX_CHURCH2,
            // Token: 0x04000ECD RID: 3789
            BBOX_TEMPLE2,
            // Token: 0x04000ECE RID: 3790
            BBOX_RPG_7VAT,
            // Token: 0x04000ECF RID: 3791
            BBOX_HN_5_A,
            // Token: 0x04000ED0 RID: 3792
            BBOX_ADATS,
            // Token: 0x04000ED1 RID: 3793
            BBOX_BLOWNUP,
            // Token: 0x04000ED2 RID: 3794
            BBOX_OFFICE9,
            // Token: 0x04000ED3 RID: 3795
            BBOX_OFFICE10,
            // Token: 0x04000ED4 RID: 3796
            BBOX_OFFICE11,
            // Token: 0x04000ED5 RID: 3797
            BBOX_OFFICE12,
            // Token: 0x04000ED6 RID: 3798
            BBOX_OFFICE13,
            // Token: 0x04000ED7 RID: 3799
            BBOX_OFFICE14,
            // Token: 0x04000ED8 RID: 3800
            BBOX_OFFICE15,
            // Token: 0x04000ED9 RID: 3801
            BBOX_OFFICE16,
            // Token: 0x04000EDA RID: 3802
            BBOX_OFFICE17,
            // Token: 0x04000EDB RID: 3803
            BBOX_RAMP1,
            // Token: 0x04000EDC RID: 3804
            BBOX_LRAMP1,
            // Token: 0x04000EDD RID: 3805
            BBOX_LSPAN1,
            // Token: 0x04000EDE RID: 3806
            BBOX_LTOWER1,
            // Token: 0x04000EDF RID: 3807
            BBOX_LRAMP2,
            // Token: 0x04000EE0 RID: 3808
            BBOX_LSPAN2,
            // Token: 0x04000EE1 RID: 3809
            BBOX_TEST,
            // Token: 0x04000EE2 RID: 3810
            BBOX_OFF_BLOCK2,
            // Token: 0x04000EE3 RID: 3811
            BBOX_OFF_BLOCK3,
            // Token: 0x04000EE4 RID: 3812
            BBOX_OFF_BLOCK4,
            // Token: 0x04000EE5 RID: 3813
            BBOX_OFF_BLOCK5,
            // Token: 0x04000EE6 RID: 3814
            BBOX_OFF_BLOCK6,
            // Token: 0x04000EE7 RID: 3815
            BBOX_OFF_BLOCK7,
            // Token: 0x04000EE8 RID: 3816
            BBOX_OFF_BLOCK9,
            // Token: 0x04000EE9 RID: 3817
            BBOX_WAREHOUSE3,
            // Token: 0x04000EEA RID: 3818
            BBOX_WAREHOUSE4,
            // Token: 0x04000EEB RID: 3819
            BBOX_TVSTN1,
            // Token: 0x04000EEC RID: 3820
            BBOX_HOTEL1,
            // Token: 0x04000EED RID: 3821
            BBOX_SM_BRIDGE3,
            // Token: 0x04000EEE RID: 3822
            BBOX_MISS_LAUN,
            // Token: 0x04000EEF RID: 3823
            BBOX_SAM_LAUN,
            // Token: 0x04000EF0 RID: 3824
            BBOX_MISS_FLAME,
            // Token: 0x04000EF1 RID: 3825
            BBOX_ENG_FIRE,
            // Token: 0x04000EF2 RID: 3826
            BBOX_SM_FACT1,
            // Token: 0x04000EF3 RID: 3827
            BBOX_SM_FACT2,
            // Token: 0x04000EF4 RID: 3828
            BBOX_SM_FACT3,
            // Token: 0x04000EF5 RID: 3829
            BBOX_4KRUNWAY,
            // Token: 0x04000EF6 RID: 3830
            BBOX_FLARE1,
            // Token: 0x04000EF7 RID: 3831
            BBOX_EXPLOSION1,
            // Token: 0x04000EF8 RID: 3832
            BBOX_TANK_HULK,
            // Token: 0x04000EF9 RID: 3833
            BBOX_RUN2K,
            // Token: 0x04000EFA RID: 3834
            BBOX_RN23K,
            // Token: 0x04000EFB RID: 3835
            BBOX_RN2MID,
            // Token: 0x04000EFC RID: 3836
            BBOX_RN2NUM,
            // Token: 0x04000EFD RID: 3837
            BBOX_RN2THR,
            // Token: 0x04000EFE RID: 3838
            BBOX_FFG,
            // Token: 0x04000EFF RID: 3839
            BBOX_ENFAC,
            // Token: 0x04000F00 RID: 3840
            BBOX_GENTANKER,
            // Token: 0x04000F01 RID: 3841
            BBOX_CV67,
            // Token: 0x04000F02 RID: 3842
            BBOX_CG47,
            // Token: 0x04000F03 RID: 3843
            BBOX_ULSAN,
            // Token: 0x04000F04 RID: 3844
            BBOX_OFFICE18,
            // Token: 0x04000F05 RID: 3845
            BBOX_OFFICE19,
            // Token: 0x04000F06 RID: 3846
            BBOX_OFFICE20,
            // Token: 0x04000F07 RID: 3847
            BBOX_OFFICE21,
            // Token: 0x04000F08 RID: 3848
            BBOX_OFFICE22,
            // Token: 0x04000F09 RID: 3849
            BBOX_OFFICE23,
            // Token: 0x04000F0A RID: 3850
            BBOX_OFFICE24,
            // Token: 0x04000F0B RID: 3851
            BBOX_OFFICE25,
            // Token: 0x04000F0C RID: 3852
            BBOX_OFFICE26,
            // Token: 0x04000F0D RID: 3853
            BBOX_KIROV,
            // Token: 0x04000F0E RID: 3854
            BBOX_RUNWAY,
            // Token: 0x04000F0F RID: 3855
            BBOX_RUNWAY_GA,
            // Token: 0x04000F10 RID: 3856
            BBOX_RUNWAY_NPGA,
            // Token: 0x04000F11 RID: 3857
            BBOX_RUNWAY_NPGB,
            // Token: 0x04000F12 RID: 3858
            BBOX_RUNWAY_NPGC,
            // Token: 0x04000F13 RID: 3859
            BBOX_RUNWAY_PFLA,
            // Token: 0x04000F14 RID: 3860
            BBOX_RUNWAY_PFGB,
            // Token: 0x04000F15 RID: 3861
            BBOX_RUNWAY_PFGA,
            // Token: 0x04000F16 RID: 3862
            BBOX_RUNWAY_PFLB,
            // Token: 0x04000F17 RID: 3863
            BBOX_LIGHTS_1,
            // Token: 0x04000F18 RID: 3864
            BBOX_LIGHTS_2,
            // Token: 0x04000F19 RID: 3865
            BBOX_HANGAR11,
            // Token: 0x04000F1A RID: 3866
            BBOX_HANGAR12,
            // Token: 0x04000F1B RID: 3867
            BBOX_WTOWER4,
            // Token: 0x04000F1C RID: 3868
            BBOX_CTRL_TOWER2,
            // Token: 0x04000F1D RID: 3869
            BBOX_EJECT1,
            // Token: 0x04000F1E RID: 3870
            BBOX_EJECT2,
            // Token: 0x04000F1F RID: 3871
            BBOX_VASI_LB,
            // Token: 0x04000F20 RID: 3872
            BBOX_VASI_LF,
            // Token: 0x04000F21 RID: 3873
            BBOX_VASI_RB,
            // Token: 0x04000F22 RID: 3874
            BBOX_VASI_RF,
            // Token: 0x04000F23 RID: 3875
            BBOX_AEXPLOSION1,
            // Token: 0x04000F24 RID: 3876
            BBOX_SIX_RACK,
            // Token: 0x04000F25 RID: 3877
            BBOX_QUAD_RACK
        }

        // Token: 0x020000AE RID: 174
        public enum Vis_Types
        {
            // Token: 0x04000F27 RID: 3879
            VIS_BRIDGE1 = 159,
            // Token: 0x04000F28 RID: 3880
            VIS_A10 = 891,
            // Token: 0x04000F29 RID: 3881
            VIS_F16C = 1052,
            // Token: 0x04000F2A RID: 3882
            VIS_B52G = 1051,
            // Token: 0x04000F2B RID: 3883
            VIS_M1A1 = 118,
            // Token: 0x04000F2C RID: 3884
            VIS_MIG29 = 74,
            // Token: 0x04000F2D RID: 3885
            VIS_A50 = 904,
            // Token: 0x04000F2E RID: 3886
            VIS_AA10 = 881,
            // Token: 0x04000F2F RID: 3887
            VIS_AA10C,
            // Token: 0x04000F30 RID: 3888
            VIS_AA11,
            // Token: 0x04000F31 RID: 3889
            VIS_AA2,
            // Token: 0x04000F32 RID: 3890
            VIS_AA2R = 931,
            // Token: 0x04000F33 RID: 3891
            VIS_AA7,
            // Token: 0x04000F34 RID: 3892
            VIS_AA7R,
            // Token: 0x04000F35 RID: 3893
            VIS_AA8,
            // Token: 0x04000F36 RID: 3894
            VIS_AA9,
            // Token: 0x04000F37 RID: 3895
            VIS_AAV7A1 = 209,
            // Token: 0x04000F38 RID: 3896
            VIS_AGM45 = 920,
            // Token: 0x04000F39 RID: 3897
            VIS_AGM65B = 936,
            // Token: 0x04000F3A RID: 3898
            VIS_AGM65D,
            // Token: 0x04000F3B RID: 3899
            VIS_AGM65G,
            // Token: 0x04000F3C RID: 3900
            VIS_AGM84,
            // Token: 0x04000F3D RID: 3901
            VIS_AGM88,
            // Token: 0x04000F3E RID: 3902
            VIS_AIM120 = 886,
            // Token: 0x04000F3F RID: 3903
            VIS_AIM54 = 941,
            // Token: 0x04000F40 RID: 3904
            VIS_AIM7 = 887,
            // Token: 0x04000F41 RID: 3905
            VIS_AIM9M = 1054,
            // Token: 0x04000F42 RID: 3906
            VIS_AS10 = 942,
            // Token: 0x04000F43 RID: 3907
            VIS_AS14,
            // Token: 0x04000F44 RID: 3908
            VIS_AS4,
            // Token: 0x04000F45 RID: 3909
            VIS_AS6,
            // Token: 0x04000F46 RID: 3910
            VIS_AS7,
            // Token: 0x04000F47 RID: 3911
            VIS_AS9,
            // Token: 0x04000F48 RID: 3912
            VIS_SCUDL = 132,
            // Token: 0x04000F49 RID: 3913
            VIS_BMP = 211,
            // Token: 0x04000F4A RID: 3914
            VIS_BRDM2,
            // Token: 0x04000F4B RID: 3915
            VIS_C130 = 894,
            // Token: 0x04000F4C RID: 3916
            VIS_CHAPARRAL = 991,
            // Token: 0x04000F4D RID: 3917
            VIS_DCLUBBLK = 792,
            // Token: 0x04000F4E RID: 3918
            VIS_DCNC02,
            // Token: 0x04000F4F RID: 3919
            VIS_DCOOLT01 = 161,
            // Token: 0x04000F50 RID: 3920
            VIS_DCTR03 = 146,
            // Token: 0x04000F51 RID: 3921
            VIS_DDEPOT02 = 204,
            // Token: 0x04000F52 RID: 3922
            VIS_DDEPOT01 = 900,
            // Token: 0x04000F53 RID: 3923
            VIS_DDEPOT03 = 17,
            // Token: 0x04000F54 RID: 3924
            VIS_DDOCK01,
            // Token: 0x04000F55 RID: 3925
            VIS_DDOCK06 = 516,
            // Token: 0x04000F56 RID: 3926
            VIS_DDUMP01 = 526,
            // Token: 0x04000F57 RID: 3927
            VIS_DF02_01,
            // Token: 0x04000F58 RID: 3928
            VIS_DF02_02 = 671,
            // Token: 0x04000F59 RID: 3929
            VIS_DF02_03 = 794,
            // Token: 0x04000F5A RID: 3930
            VIS_E3 = 1069,
            // Token: 0x04000F5B RID: 3931
            VIS_EF111 = 896,
            // Token: 0x04000F5C RID: 3932
            VIS_F117 = 889,
            // Token: 0x04000F5D RID: 3933
            VIS_F14 = 897,
            // Token: 0x04000F5E RID: 3934
            VIS_F15C,
            // Token: 0x04000F5F RID: 3935
            VIS_F4,
            // Token: 0x04000F60 RID: 3936
            VIS_F5E = 901,
            // Token: 0x04000F61 RID: 3937
            VIS_FB111 = 888,
            // Token: 0x04000F62 RID: 3938
            VIS_HAWK = 240,
            // Token: 0x04000F63 RID: 3939
            VIS_IL76 = 903,
            // Token: 0x04000F64 RID: 3940
            VIS_KC10 = 907,
            // Token: 0x04000F65 RID: 3941
            VIS_KC135 = 906,
            // Token: 0x04000F66 RID: 3942
            VIS_LAV25 = 222,
            // Token: 0x04000F67 RID: 3943
            VIS_M113 = 226,
            // Token: 0x04000F68 RID: 3944
            VIS_M163 = 990,
            // Token: 0x04000F69 RID: 3945
            VIS_M2 = 244,
            // Token: 0x04000F6A RID: 3946
            VIS_MIG19 = 908,
            // Token: 0x04000F6B RID: 3947
            VIS_MIG21,
            // Token: 0x04000F6C RID: 3948
            VIS_MIG23,
            // Token: 0x04000F6D RID: 3949
            VIS_MIG25,
            // Token: 0x04000F6E RID: 3950
            VIS_MK82 = 142,
            // Token: 0x04000F6F RID: 3951
            VIS_MK84 = 959,
            // Token: 0x04000F70 RID: 3952
            VIS_MLRS = 880,
            // Token: 0x04000F71 RID: 3953
            VIS_F18A = 139,
            // Token: 0x04000F72 RID: 3954
            VIS_AN24 = 929,
            // Token: 0x04000F73 RID: 3955
            VIS_F18D = 138,
            // Token: 0x04000F74 RID: 3956
            VIS_HANGAR9 = 1009,
            // Token: 0x04000F75 RID: 3957
            VIS_T62 = 136,
            // Token: 0x04000F76 RID: 3958
            VIS_SA2R = 833,
            // Token: 0x04000F77 RID: 3959
            VIS_SA3R,
            // Token: 0x04000F78 RID: 3960
            VIS_SA4R,
            // Token: 0x04000F79 RID: 3961
            VIS_SA5R,
            // Token: 0x04000F7A RID: 3962
            VIS_UB1957 = 70,
            // Token: 0x04000F7B RID: 3963
            VIS_DF02_04 = 795,
            // Token: 0x04000F7C RID: 3964
            VIS_DF02_05,
            // Token: 0x04000F7D RID: 3965
            VIS_DHANGAR07,
            // Token: 0x04000F7E RID: 3966
            VIS_DHANGAR08,
            // Token: 0x04000F7F RID: 3967
            VIS_DHANGAR09,
            // Token: 0x04000F80 RID: 3968
            VIS_DHOSP02,
            // Token: 0x04000F81 RID: 3969
            VIS_DN01_01,
            // Token: 0x04000F82 RID: 3970
            VIS_DN01_02,
            // Token: 0x04000F83 RID: 3971
            VIS_DN01_03,
            // Token: 0x04000F84 RID: 3972
            VIS_DN01_04,
            // Token: 0x04000F85 RID: 3973
            VIS_DN01_05,
            // Token: 0x04000F86 RID: 3974
            VIS_DOBLK09,
            // Token: 0x04000F87 RID: 3975
            VIS_DPP01_01,
            // Token: 0x04000F88 RID: 3976
            VIS_DPP01_02,
            // Token: 0x04000F89 RID: 3977
            VIS_DPP01_03,
            // Token: 0x04000F8A RID: 3978
            VIS_DPP01_04,
            // Token: 0x04000F8B RID: 3979
            VIS_DPP01_05,
            // Token: 0x04000F8C RID: 3980
            VIS_SA12 = 979,
            // Token: 0x04000F8D RID: 3981
            VIS_SA13 = 962,
            // Token: 0x04000F8E RID: 3982
            VIS_SA13L = 133,
            // Token: 0x04000F8F RID: 3983
            VIS_SA2 = 230,
            // Token: 0x04000F90 RID: 3984
            VIS_SA4 = 234,
            // Token: 0x04000F91 RID: 3985
            VIS_SA4L,
            // Token: 0x04000F92 RID: 3986
            VIS_SA6 = 242,
            // Token: 0x04000F93 RID: 3987
            VIS_SA6L,
            // Token: 0x04000F94 RID: 3988
            VIS_SA8 = 238,
            // Token: 0x04000F95 RID: 3989
            VIS_STINGER = 957,
            // Token: 0x04000F96 RID: 3990
            VIS_SU25 = 913,
            // Token: 0x04000F97 RID: 3991
            VIS_SU27,
            // Token: 0x04000F98 RID: 3992
            VIS_T55 = 137,
            // Token: 0x04000F99 RID: 3993
            VIS_T72 = 877,
            // Token: 0x04000F9A RID: 3994
            VIS_T80,
            // Token: 0x04000F9B RID: 3995
            VIS_AEXPLOSION1 = 120,
            // Token: 0x04000F9C RID: 3996
            VIS_BLU109B = 965,
            // Token: 0x04000F9D RID: 3997
            VIS_AN2 = 893,
            // Token: 0x04000F9E RID: 3998
            VIS_AH64 = 892,
            // Token: 0x04000F9F RID: 3999
            VIS_DURANDAL = 923,
            // Token: 0x04000FA0 RID: 4000
            VIS_GBU10 = 953,
            // Token: 0x04000FA1 RID: 4001
            VIS_BARRACKS1 = 145,
            // Token: 0x04000FA2 RID: 4002
            VIS_TANKLG01 = 147,
            // Token: 0x04000FA3 RID: 4003
            VIS_HANGAR2,
            // Token: 0x04000FA4 RID: 4004
            VIS_R02_NPGA,
            // Token: 0x04000FA5 RID: 4005
            VIS_UB3257 = 71,
            // Token: 0x04000FA6 RID: 4006
            VIS_RPK500,
            // Token: 0x04000FA7 RID: 4007
            VIS_DPP02_01 = 812,
            // Token: 0x04000FA8 RID: 4008
            VIS_DPP02_02,
            // Token: 0x04000FA9 RID: 4009
            VIS_DPP02_03,
            // Token: 0x04000FAA RID: 4010
            VIS_DPP03_01,
            // Token: 0x04000FAB RID: 4011
            VIS_DPP03_02,
            // Token: 0x04000FAC RID: 4012
            VIS_DPP03_03,
            // Token: 0x04000FAD RID: 4013
            VIS_DPP04_01,
            // Token: 0x04000FAE RID: 4014
            VIS_DR03_05,
            // Token: 0x04000FAF RID: 4015
            VIS_DR03_06,
            // Token: 0x04000FB0 RID: 4016
            VIS_DSHED04,
            // Token: 0x04000FB1 RID: 4017
            VIS_DTANKSM01,
            // Token: 0x04000FB2 RID: 4018
            VIS_DTRNSFR01,
            // Token: 0x04000FB3 RID: 4019
            VIS_DUPTANK01,
            // Token: 0x04000FB4 RID: 4020
            VIS_DWAREHS02,
            // Token: 0x04000FB5 RID: 4021
            VIS_DWAREHS03,
            // Token: 0x04000FB6 RID: 4022
            VIS_DWAREHS05,
            // Token: 0x04000FB7 RID: 4023
            VIS_BLU27 = 922,
            // Token: 0x04000FB8 RID: 4024
            VIS_CBU = 951,
            // Token: 0x04000FB9 RID: 4025
            VIS_MK82SnakeEye = 958,
            // Token: 0x04000FBA RID: 4026
            VIS_ALQ131 = 921,
            // Token: 0x04000FBB RID: 4027
            VIS_300GAL = 918,
            // Token: 0x04000FBC RID: 4028
            VIS_370GAL,
            // Token: 0x04000FBD RID: 4029
            VIS_600GAL = 930,
            // Token: 0x04000FBE RID: 4030
            VIS_CH47 = 895,
            // Token: 0x04000FBF RID: 4031
            VIS_RECPOD = 961,
            // Token: 0x04000FC0 RID: 4032
            VIS_LAU3A = 924,
            // Token: 0x04000FC1 RID: 4033
            VIS_M109 = 225,
            // Token: 0x04000FC2 RID: 4034
            VIS_AGM65A = 885,
            // Token: 0x04000FC3 RID: 4035
            VIS_AT6 = 948,
            // Token: 0x04000FC4 RID: 4036
            VIS_OH58D = 912,
            // Token: 0x04000FC5 RID: 4037
            VIS_HANGAR8 = 144,
            // Token: 0x04000FC6 RID: 4038
            VIS_GBU28B = 73,
            // Token: 0x04000FC7 RID: 4039
            VIS_FACTORY1L = 75,
            // Token: 0x04000FC8 RID: 4040
            VIS_FACTORY1R,
            // Token: 0x04000FC9 RID: 4041
            VIS_FACTORY1_SHIP,
            // Token: 0x04000FCA RID: 4042
            VIS_DWTRTWR01 = 828,
            // Token: 0x04000FCB RID: 4043
            VIS_MAYDAY = 269,
            // Token: 0x04000FCC RID: 4044
            VIS_KOEX = 271,
            // Token: 0x04000FCD RID: 4045
            VIS_ARCH = 273,
            // Token: 0x04000FCE RID: 4046
            VIS_KORYO = 275,
            // Token: 0x04000FCF RID: 4047
            VIS_STOWER = 277,
            // Token: 0x04000FD0 RID: 4048
            VIS_RYUGYONG = 285,
            // Token: 0x04000FD1 RID: 4049
            VIS_DRYUGYONG = 830,
            // Token: 0x04000FD2 RID: 4050
            VIS_M48,
            // Token: 0x04000FD3 RID: 4051
            VIS_SM240,
            // Token: 0x04000FD4 RID: 4052
            VIS_SA6R = 837,
            // Token: 0x04000FD5 RID: 4053
            VIS_HAWKRADAR,
            // Token: 0x04000FD6 RID: 4054
            VIS_PATRIOTRAD,
            // Token: 0x04000FD7 RID: 4055
            VIS_KRAZ255BF,
            // Token: 0x04000FD8 RID: 4056
            VIS_OLY1,
            // Token: 0x04000FD9 RID: 4057
            VIS_OLY2,
            // Token: 0x04000FDA RID: 4058
            VIS_OLY3,
            // Token: 0x04000FDB RID: 4059
            VIS_OLY4,
            // Token: 0x04000FDC RID: 4060
            VIS_OLY5,
            // Token: 0x04000FDD RID: 4061
            VIS_PMJ1,
            // Token: 0x04000FDE RID: 4062
            VIS_BRIDGE1_1D = 1189,
            // Token: 0x04000FDF RID: 4063
            VIS_AH1 = 829,
            // Token: 0x04000FE0 RID: 4064
            VIS_AH64D = 3,
            // Token: 0x04000FE1 RID: 4065
            VIS_IL28 = 902,
            // Token: 0x04000FE2 RID: 4066
            VIS_KA50 = 905,
            // Token: 0x04000FE3 RID: 4067
            VIS_MD500 = 890,
            // Token: 0x04000FE4 RID: 4068
            VIS_MI24 = 119,
            // Token: 0x04000FE5 RID: 4069
            VIS_TU16N = 915,
            // Token: 0x04000FE6 RID: 4070
            VIS_UH1H,
            // Token: 0x04000FE7 RID: 4071
            VIS_UH60L,
            // Token: 0x04000FE8 RID: 4072
            VIS_OFFICE7 = 121,
            // Token: 0x04000FE9 RID: 4073
            VIS_SINGLE_RACK = 140,
            // Token: 0x04000FEA RID: 4074
            VIS_TRIPLE_RACK,
            // Token: 0x04000FEB RID: 4075
            VIS_PUFFY_CLOUD1 = 7,
            // Token: 0x04000FEC RID: 4076
            VIS_WAREHOUSE1 = 560,
            // Token: 0x04000FED RID: 4077
            VIS_SMALL_CRATER1 = 143,
            // Token: 0x04000FEE RID: 4078
            VIS_PMJ2 = 847,
            // Token: 0x04000FEF RID: 4079
            VIS_DMZSFNC,
            // Token: 0x04000FF0 RID: 4080
            VIS_KIM2,
            // Token: 0x04000FF1 RID: 4081
            VIS_NBBRD1,
            // Token: 0x04000FF2 RID: 4082
            VIS_NBBRD2,
            // Token: 0x04000FF3 RID: 4083
            VIS_CLUBBLK,
            // Token: 0x04000FF4 RID: 4084
            VIS_RWYPATCH,
            // Token: 0x04000FF5 RID: 4085
            VIS_NAJIN,
            // Token: 0x04000FF6 RID: 4086
            VIS_OSA2,
            // Token: 0x04000FF7 RID: 4087
            VIS_WILDCAT,
            // Token: 0x04000FF8 RID: 4088
            VIS_HELLFIRE,
            // Token: 0x04000FF9 RID: 4089
            VIS_MK84AIR,
            // Token: 0x04000FFA RID: 4090
            VIS_CSHIP1,
            // Token: 0x04000FFB RID: 4091
            VIS_CSHIP2,
            // Token: 0x04000FFC RID: 4092
            VIS_CSHIP3,
            // Token: 0x04000FFD RID: 4093
            VIS_CSHIP4,
            // Token: 0x04000FFE RID: 4094
            VIS_AC130,
            // Token: 0x04000FFF RID: 4095
            VIS_F15E,
            // Token: 0x04001000 RID: 4096
            VIS_ZIL135 = 1053,
            // Token: 0x04001001 RID: 4097
            VIS_WEXPLOSION1 = 47,
            // Token: 0x04001002 RID: 4098
            VIS_TAXI_01,
            // Token: 0x04001003 RID: 4099
            VIS_AV8B = 865,
            // Token: 0x04001004 RID: 4100
            VIS_PRC_MIG21,
            // Token: 0x04001005 RID: 4101
            VIS_CIS_MIG29,
            // Token: 0x04001006 RID: 4102
            VIS_CIS_SU27,
            // Token: 0x04001007 RID: 4103
            VIS_PRC_SU27,
            // Token: 0x04001008 RID: 4104
            VIS_TYPE85II = 166,
            // Token: 0x04001009 RID: 4105
            VIS_VRCOCKPIT_MP = 870,
            // Token: 0x0400100A RID: 4106
            VIS_2RAIL,
            // Token: 0x0400100B RID: 4107
            VIS_1RAIL,
            // Token: 0x0400100C RID: 4108
            VIS_MAVRACK,
            // Token: 0x0400100D RID: 4109
            VIS_MUH1 = 181,
            // Token: 0x0400100E RID: 4110
            VIS_UPTANK1 = 78,
            // Token: 0x0400100F RID: 4111
            VIS_SMOKESTACK1 = 80,
            // Token: 0x04001010 RID: 4112
            VIS_PARKINGLOT1,
            // Token: 0x04001011 RID: 4113
            VIS_HOUSE1 = 300,
            // Token: 0x04001012 RID: 4114
            VIS_DAPT01,
            // Token: 0x04001013 RID: 4115
            VIS_NUM380 = 151,
            // Token: 0x04001014 RID: 4116
            VIS_CUH1 = 874,
            // Token: 0x04001015 RID: 4117
            VIS_BRIDGE1_2D = 1190,
            // Token: 0x04001016 RID: 4118
            VIS_RWYLIT,
            // Token: 0x04001017 RID: 4119
            VIS_GRLINE,
            // Token: 0x04001018 RID: 4120
            VIS_YRLINE,
            // Token: 0x04001019 RID: 4121
            VIS_THR160,
            // Token: 0x0400101A RID: 4122
            VIS_MNAVBEAC,
            // Token: 0x0400101B RID: 4123
            VIS_F16PIT,
            // Token: 0x0400101C RID: 4124
            VIS_F16PIT_MP,
            // Token: 0x0400101D RID: 4125
            VIS_NUM01,
            // Token: 0x0400101E RID: 4126
            VIS_LB02W,
            // Token: 0x0400101F RID: 4127
            VIS_LB02,
            // Token: 0x04001020 RID: 4128
            VIS_HOUSE5 = 171,
            // Token: 0x04001021 RID: 4129
            VIS_HOUSE4 = 170,
            // Token: 0x04001022 RID: 4130
            VIS_HOUSE3 = 169,
            // Token: 0x04001023 RID: 4131
            VIS_SHOP1 = 163,
            // Token: 0x04001024 RID: 4132
            VIS_HOUSE2 = 167,
            // Token: 0x04001025 RID: 4133
            VIS_APT1 = 158,
            // Token: 0x04001026 RID: 4134
            VIS_OFFICE2 = 1040,
            // Token: 0x04001027 RID: 4135
            VIS_TANKSM01 = 1034,
            // Token: 0x04001028 RID: 4136
            VIS_DOCK1 = 165,
            // Token: 0x04001029 RID: 4137
            VIS_REFINERY1 = 179,
            // Token: 0x0400102A RID: 4138
            VIS_RAIL1,
            // Token: 0x0400102B RID: 4139
            VIS_CITY_HALL = 162,
            // Token: 0x0400102C RID: 4140
            VIS_RTOWER = 178,
            // Token: 0x0400102D RID: 4141
            VIS_N01_01 = 172,
            // Token: 0x0400102E RID: 4142
            VIS_OFFICE1,
            // Token: 0x0400102F RID: 4143
            VIS_SHOP2 = 164,
            // Token: 0x04001030 RID: 4144
            VIS_FACTORY2 = 157,
            // Token: 0x04001031 RID: 4145
            VIS_WAREHOUSE2 = 117,
            // Token: 0x04001032 RID: 4146
            VIS_R02_OVER = 152,
            // Token: 0x04001033 RID: 4147
            VIS_ADMIN1 = 150,
            // Token: 0x04001034 RID: 4148
            VIS_FAB1000LGB = 966,
            // Token: 0x04001035 RID: 4149
            VIS_FAB1000HD,
            // Token: 0x04001036 RID: 4150
            VIS_FAB1000LD,
            // Token: 0x04001037 RID: 4151
            VIS_NUM270 = 153,
            // Token: 0x04001038 RID: 4152
            VIS_ADMIN02,
            // Token: 0x04001039 RID: 4153
            VIS_CTR01,
            // Token: 0x0400103A RID: 4154
            VIS_DEPO03,
            // Token: 0x0400103B RID: 4155
            VIS_R02OVER = 160,
            // Token: 0x0400103C RID: 4156
            VIS_TAXIS02 = 993,
            // Token: 0x0400103D RID: 4157
            VIS_APT2 = 168,
            // Token: 0x0400103E RID: 4158
            VIS_CBU89 = 950,
            // Token: 0x0400103F RID: 4159
            VIS_N01_03 = 82,
            // Token: 0x04001040 RID: 4160
            VIS_N01_04,
            // Token: 0x04001041 RID: 4161
            VIS_PARKINGLOT2,
            // Token: 0x04001042 RID: 4162
            VIS_COOL_TWR1,
            // Token: 0x04001043 RID: 4163
            VIS_CONT_DOME1,
            // Token: 0x04001044 RID: 4164
            VIS_R03_NPGB = 1006,
            // Token: 0x04001045 RID: 4165
            VIS_R03_PGA = 1023,
            // Token: 0x04001046 RID: 4166
            VIS_R03_PGB = 1030,
            // Token: 0x04001047 RID: 4167
            VIS_DARCH = 1201,
            // Token: 0x04001048 RID: 4168
            VIS_DOLY1,
            // Token: 0x04001049 RID: 4169
            VIS_DOLY2,
            // Token: 0x0400104A RID: 4170
            VIS_DOLY3,
            // Token: 0x0400104B RID: 4171
            VIS_DOLY4,
            // Token: 0x0400104C RID: 4172
            VIS_DOLY5,
            // Token: 0x0400104D RID: 4173
            VIS_DKORYO,
            // Token: 0x0400104E RID: 4174
            VIS_DMAYDAY,
            // Token: 0x0400104F RID: 4175
            VIS_DKIM2,
            // Token: 0x04001050 RID: 4176
            VIS_DKOEX,
            // Token: 0x04001051 RID: 4177
            VIS_LB01,
            // Token: 0x04001052 RID: 4178
            VIS_LB03,
            // Token: 0x04001053 RID: 4179
            VIS_LB04,
            // Token: 0x04001054 RID: 4180
            VIS_POPMENU,
            // Token: 0x04001055 RID: 4181
            VIS_KC10BOOM,
            // Token: 0x04001056 RID: 4182
            VIS_BMP2,
            // Token: 0x04001057 RID: 4183
            VIS_BMP3,
            // Token: 0x04001058 RID: 4184
            VIS_IL78,
            // Token: 0x04001059 RID: 4185
            VIS_DBMB = 1036,
            // Token: 0x0400105A RID: 4186
            VIS_DBMBLW,
            // Token: 0x0400105B RID: 4187
            VIS_DBMBRW,
            // Token: 0x0400105C RID: 4188
            VIS_N01_05 = 88,
            // Token: 0x0400105D RID: 4189
            VIS_TRANSFORMER1,
            // Token: 0x0400105E RID: 4190
            VIS_R03_PGC = 1035,
            // Token: 0x0400105F RID: 4191
            VIS_TAXIS03L = 68,
            // Token: 0x04001060 RID: 4192
            VIS_ZU23 = 1219,
            // Token: 0x04001061 RID: 4193
            VIS_ZSU57_2,
            // Token: 0x04001062 RID: 4194
            VIS_KC135BOOM,
            // Token: 0x04001063 RID: 4195
            VIS_BM21,
            // Token: 0x04001064 RID: 4196
            VIS_RDROGUE,
            // Token: 0x04001065 RID: 4197
            VIS_HTS,
            // Token: 0x04001066 RID: 4198
            VIS_LANTIRN,
            // Token: 0x04001067 RID: 4199
            VIS_NIKEL,
            // Token: 0x04001068 RID: 4200
            VIS_RCKT1,
            // Token: 0x04001069 RID: 4201
            VIS_FAB250LGB = 969,
            // Token: 0x0400106A RID: 4202
            VIS_FAB250LD,
            // Token: 0x0400106B RID: 4203
            VIS_FAB250HD = 927,
            // Token: 0x0400106C RID: 4204
            VIS_KRAZ255B = 994,
            // Token: 0x0400106D RID: 4205
            VIS_SHED4 = 90,
            // Token: 0x0400106E RID: 4206
            VIS_WAREHOUSE5,
            // Token: 0x0400106F RID: 4207
            VIS_DMIG19FUS,
            // Token: 0x04001070 RID: 4208
            VIS_DMIG19LW,
            // Token: 0x04001071 RID: 4209
            VIS_DMIG19RW,
            // Token: 0x04001072 RID: 4210
            VIS_DMIG19TL,
            // Token: 0x04001073 RID: 4211
            VIS_DMIG21FUS,
            // Token: 0x04001074 RID: 4212
            VIS_R03OPGA = 1228,
            // Token: 0x04001075 RID: 4213
            VIS_R03OPGD,
            // Token: 0x04001076 RID: 4214
            VIS_OSANLIT,
            // Token: 0x04001077 RID: 4215
            VIS_1RWYLIT,
            // Token: 0x04001078 RID: 4216
            VIS_2RWYLIT,
            // Token: 0x04001079 RID: 4217
            VIS_CF16FRN,
            // Token: 0x0400107A RID: 4218
            VIS_CF16LST,
            // Token: 0x0400107B RID: 4219
            VIS_CF16LWG,
            // Token: 0x0400107C RID: 4220
            VIS_CF16MID,
            // Token: 0x0400107D RID: 4221
            VIS_CF16NOS,
            // Token: 0x0400107E RID: 4222
            VIS_CF16RST,
            // Token: 0x0400107F RID: 4223
            VIS_AT3 = 210,
            // Token: 0x04001080 RID: 4224
            VIS_BTR80 = 213,
            // Token: 0x04001081 RID: 4225
            VIS_FROG7,
            // Token: 0x04001082 RID: 4226
            VIS_BR_TOP1_1 = 1073,
            // Token: 0x04001083 RID: 4227
            VIS_BR_TOP1_2 = 1081,
            // Token: 0x04001084 RID: 4228
            VIS_TAXIS03U = 69,
            // Token: 0x04001085 RID: 4229
            VIS_F02_03 = 79,
            // Token: 0x04001086 RID: 4230
            VIS_CF16RWG = 1239,
            // Token: 0x04001087 RID: 4231
            VIS_KIMPOLIT,
            // Token: 0x04001088 RID: 4232
            VIS_SEOULLIT,
            // Token: 0x04001089 RID: 4233
            VIS_SUNANLIT,
            // Token: 0x0400108A RID: 4234
            VIS_SUNANLIT2,
            // Token: 0x0400108B RID: 4235
            VIS_WONSANLIT,
            // Token: 0x0400108C RID: 4236
            VIS_GENCARGOSHP,
            // Token: 0x0400108D RID: 4237
            VIS_F5SHADOW,
            // Token: 0x0400108E RID: 4238
            VIS_F14SHADOW,
            // Token: 0x0400108F RID: 4239
            VIS_F15SHADOW,
            // Token: 0x04001090 RID: 4240
            VIS_F18SHADOW,
            // Token: 0x04001091 RID: 4241
            VIS_THP01,
            // Token: 0x04001092 RID: 4242
            VIS_DMIG21LW = 97,
            // Token: 0x04001093 RID: 4243
            VIS_DMIG21RW,
            // Token: 0x04001094 RID: 4244
            VIS_DMIG21TL,
            // Token: 0x04001095 RID: 4245
            VIS_R03_NPGC = 87,
            // Token: 0x04001096 RID: 4246
            VIS_HNGR05 = 116,
            // Token: 0x04001097 RID: 4247
            VIS_R04AGA = 456,
            // Token: 0x04001098 RID: 4248
            VIS_R04AGB,
            // Token: 0x04001099 RID: 4249
            VIS_THP02 = 1251,
            // Token: 0x0400109A RID: 4250
            VIS_THP02LR,
            // Token: 0x0400109B RID: 4251
            VIS_THP02RL,
            // Token: 0x0400109C RID: 4252
            VIS_THP03,
            // Token: 0x0400109D RID: 4253
            VIS_THP05LR,
            // Token: 0x0400109E RID: 4254
            VIS_THP05RL,
            // Token: 0x0400109F RID: 4255
            VIS_THP08,
            // Token: 0x040010A0 RID: 4256
            VIS_THP11,
            // Token: 0x040010A1 RID: 4257
            VIS_THP12,
            // Token: 0x040010A2 RID: 4258
            VIS_THP14,
            // Token: 0x040010A3 RID: 4259
            VIS_THP14LR,
            // Token: 0x040010A4 RID: 4260
            VIS_THP14RL,
            // Token: 0x040010A5 RID: 4261
            VIS_THP15,
            // Token: 0x040010A6 RID: 4262
            VIS_THP16,
            // Token: 0x040010A7 RID: 4263
            VIS_THP16LR,
            // Token: 0x040010A8 RID: 4264
            VIS_THP16RL,
            // Token: 0x040010A9 RID: 4265
            VIS_THP18,
            // Token: 0x040010AA RID: 4266
            VIS_THP19,
            // Token: 0x040010AB RID: 4267
            VIS_PP01_01 = 174,
            // Token: 0x040010AC RID: 4268
            VIS_WTOWER1,
            // Token: 0x040010AD RID: 4269
            VIS_RADAR1,
            // Token: 0x040010AE RID: 4270
            VIS_RADAR2,
            // Token: 0x040010AF RID: 4271
            VIS_BUNKER2 = 182,
            // Token: 0x040010B0 RID: 4272
            VIS_CHURCH1,
            // Token: 0x040010B1 RID: 4273
            VIS_DEPOT1,
            // Token: 0x040010B2 RID: 4274
            VIS_DEPOT2,
            // Token: 0x040010B3 RID: 4275
            VIS_FACTORY3,
            // Token: 0x040010B4 RID: 4276
            VIS_DOCK2,
            // Token: 0x040010B5 RID: 4277
            VIS_HANGAR1,
            // Token: 0x040010B6 RID: 4278
            VIS_HANGAR3,
            // Token: 0x040010B7 RID: 4279
            VIS_HANGAR6,
            // Token: 0x040010B8 RID: 4280
            VIS_HANGAR7,
            // Token: 0x040010B9 RID: 4281
            VIS_N01_02,
            // Token: 0x040010BA RID: 4282
            VIS_HELIPAD1,
            // Token: 0x040010BB RID: 4283
            VIS_PIER1,
            // Token: 0x040010BC RID: 4284
            VIS_PPOLE1,
            // Token: 0x040010BD RID: 4285
            VIS_PTOWER1,
            // Token: 0x040010BE RID: 4286
            VIS_RTOWER2,
            // Token: 0x040010BF RID: 4287
            VIS_RADAR3,
            // Token: 0x040010C0 RID: 4288
            VIS_RADAR4,
            // Token: 0x040010C1 RID: 4289
            VIS_RADAR5,
            // Token: 0x040010C2 RID: 4290
            VIS_RADAR6,
            // Token: 0x040010C3 RID: 4291
            VIS_RADAR7,
            // Token: 0x040010C4 RID: 4292
            VIS_RADAR8,
            // Token: 0x040010C5 RID: 4293
            VIS_SHOP3 = 205,
            // Token: 0x040010C6 RID: 4294
            VIS_2S19,
            // Token: 0x040010C7 RID: 4295
            VIS_2S6,
            // Token: 0x040010C8 RID: 4296
            VIS_BM24,
            // Token: 0x040010C9 RID: 4297
            VIS_FROG7L = 215,
            // Token: 0x040010CA RID: 4298
            VIS_FUELTRUCK,
            // Token: 0x040010CB RID: 4299
            VIS_HMVAVG,
            // Token: 0x040010CC RID: 4300
            VIS_THP20 = 1269,
            // Token: 0x040010CD RID: 4301
            VIS_THP20LR,
            // Token: 0x040010CE RID: 4302
            VIS_GBU15 = 928,
            // Token: 0x040010CF RID: 4303
            VIS_CBU58 = 949,
            // Token: 0x040010D0 RID: 4304
            VIS_PATRIOT = 952,
            // Token: 0x040010D1 RID: 4305
            VIS_GBU24 = 954,
            // Token: 0x040010D2 RID: 4306
            VIS_GSH23,
            // Token: 0x040010D3 RID: 4307
            VIS_MK20,
            // Token: 0x040010D4 RID: 4308
            VIS_MK46 = 992,
            // Token: 0x040010D5 RID: 4309
            VIS_NIKE = 960,
            // Token: 0x040010D6 RID: 4310
            VIS_GPU5 = 964,
            // Token: 0x040010D7 RID: 4311
            VIS_LNTRN_N = 971,
            // Token: 0x040010D8 RID: 4312
            VIS_LNTRN_T,
            // Token: 0x040010D9 RID: 4313
            VIS_AGM130,
            // Token: 0x040010DA RID: 4314
            VIS_AT2,
            // Token: 0x040010DB RID: 4315
            VIS_AT4,
            // Token: 0x040010DC RID: 4316
            VIS_VIKHR,
            // Token: 0x040010DD RID: 4317
            VIS_AT5,
            // Token: 0x040010DE RID: 4318
            VIS_SA14,
            // Token: 0x040010DF RID: 4319
            VIS_CHAPMIS = 963,
            // Token: 0x040010E0 RID: 4320
            VIS_PTK250 = 980,
            // Token: 0x040010E1 RID: 4321
            VIS_RPK180,
            // Token: 0x040010E2 RID: 4322
            VIS_TOWM1046,
            // Token: 0x040010E3 RID: 4323
            VIS_M47,
            // Token: 0x040010E4 RID: 4324
            VIS_AA8R,
            // Token: 0x040010E5 RID: 4325
            VIS_CHAFF = 986,
            // Token: 0x040010E6 RID: 4326
            VIS_300GALW,
            // Token: 0x040010E7 RID: 4327
            VIS_57MMROCK,
            // Token: 0x040010E8 RID: 4328
            VIS_M198,
            // Token: 0x040010E9 RID: 4329
            VIS_APT4 = 995,
            // Token: 0x040010EA RID: 4330
            VIS_HMVTOW = 218,
            // Token: 0x040010EB RID: 4331
            VIS_HMMWV,
            // Token: 0x040010EC RID: 4332
            VIS_HMVCAR,
            // Token: 0x040010ED RID: 4333
            VIS_HMVAMB,
            // Token: 0x040010EE RID: 4334
            VIS_LAVADV = 223,
            // Token: 0x040010EF RID: 4335
            VIS_LAVTOW,
            // Token: 0x040010F0 RID: 4336
            VIS_M88 = 227,
            // Token: 0x040010F1 RID: 4337
            VIS_M977F,
            // Token: 0x040010F2 RID: 4338
            VIS_M977C,
            // Token: 0x040010F3 RID: 4339
            VIS_SA2L = 231,
            // Token: 0x040010F4 RID: 4340
            VIS_SA3,
            // Token: 0x040010F5 RID: 4341
            VIS_SA3L,
            // Token: 0x040010F6 RID: 4342
            VIS_SA5 = 236,
            // Token: 0x040010F7 RID: 4343
            VIS_SA5L,
            // Token: 0x040010F8 RID: 4344
            VIS_SA8L = 239,
            // Token: 0x040010F9 RID: 4345
            VIS_HAWKL = 241,
            // Token: 0x040010FA RID: 4346
            VIS_M2ADAT = 875,
            // Token: 0x040010FB RID: 4347
            VIS_M2ADV,
            // Token: 0x040010FC RID: 4348
            VIS_ZSU23_4 = 879,
            // Token: 0x040010FD RID: 4349
            VIS_GBU12 = 925,
            // Token: 0x040010FE RID: 4350
            VIS_275ROCK,
            // Token: 0x040010FF RID: 4351
            VIS_APT5 = 996,
            // Token: 0x04001100 RID: 4352
            VIS_SHOP4 = 1007,
            // Token: 0x04001101 RID: 4353
            VIS_THP20RL = 1271,
            // Token: 0x04001102 RID: 4354
            VIS_HOUSE6 = 997,
            // Token: 0x04001103 RID: 4355
            VIS_HOUSE7,
            // Token: 0x04001104 RID: 4356
            VIS_HOUSE8,
            // Token: 0x04001105 RID: 4357
            VIS_BARN1,
            // Token: 0x04001106 RID: 4358
            VIS_BARN2,
            // Token: 0x04001107 RID: 4359
            VIS_HOUSE9,
            // Token: 0x04001108 RID: 4360
            VIS_HOUSE10,
            // Token: 0x04001109 RID: 4361
            VIS_HOUSE11,
            // Token: 0x0400110A RID: 4362
            VIS_TWNHALL1,
            // Token: 0x0400110B RID: 4363
            VIS_SHOP5 = 1008,
            // Token: 0x0400110C RID: 4364
            VIS_HANGAR10 = 1010,
            // Token: 0x0400110D RID: 4365
            VIS_R02_PGC,
            // Token: 0x0400110E RID: 4366
            VIS_R03_NPGA,
            // Token: 0x0400110F RID: 4367
            VIS_TEMPLE1,
            // Token: 0x04001110 RID: 4368
            VIS_SHOP6,
            // Token: 0x04001111 RID: 4369
            VIS_SHED2,
            // Token: 0x04001112 RID: 4370
            VIS_SHED3,
            // Token: 0x04001113 RID: 4371
            VIS_WTOWER2,
            // Token: 0x04001114 RID: 4372
            VIS_WTOWER3,
            // Token: 0x04001115 RID: 4373
            VIS_SHRINE1,
            // Token: 0x04001116 RID: 4374
            VIS_APT6,
            // Token: 0x04001117 RID: 4375
            VIS_STABLE1,
            // Token: 0x04001118 RID: 4376
            VIS_PARK1,
            // Token: 0x04001119 RID: 4377
            VIS_TREE2 = 1024,
            // Token: 0x0400111A RID: 4378
            VIS_TREE3,
            // Token: 0x0400111B RID: 4379
            VIS_TREE4,
            // Token: 0x0400111C RID: 4380
            VIS_HOUSE12,
            // Token: 0x0400111D RID: 4381
            VIS_OFFICE3,
            // Token: 0x0400111E RID: 4382
            VIS_OFFICE4,
            // Token: 0x0400111F RID: 4383
            VIS_OFFICE5 = 1031,
            // Token: 0x04001120 RID: 4384
            VIS_OFFICE6,
            // Token: 0x04001121 RID: 4385
            VIS_DAPT02 = 302,
            // Token: 0x04001122 RID: 4386
            VIS_DCHALL01,
            // Token: 0x04001123 RID: 4387
            VIS_R04AGC = 458,
            // Token: 0x04001124 RID: 4388
            VIS_THP21 = 1272,
            // Token: 0x04001125 RID: 4389
            VIS_THP23LR,
            // Token: 0x04001126 RID: 4390
            VIS_THP23RL,
            // Token: 0x04001127 RID: 4391
            VIS_OFFICE8 = 1033,
            // Token: 0x04001128 RID: 4392
            VIS_DBMBTL = 1039,
            // Token: 0x04001129 RID: 4393
            VIS_VRCOCKPIT = 1,
            // Token: 0x0400112A RID: 4394
            VIS_OFFICE9 = 1041,
            // Token: 0x0400112B RID: 4395
            VIS_OFFICE10,
            // Token: 0x0400112C RID: 4396
            VIS_OFFICE11,
            // Token: 0x0400112D RID: 4397
            VIS_OFFICE12,
            // Token: 0x0400112E RID: 4398
            VIS_OFFICE13,
            // Token: 0x0400112F RID: 4399
            VIS_OFFICE14,
            // Token: 0x04001130 RID: 4400
            VIS_OFFICE15,
            // Token: 0x04001131 RID: 4401
            VIS_OFFICE16,
            // Token: 0x04001132 RID: 4402
            VIS_OFFICE17,
            // Token: 0x04001133 RID: 4403
            VIS_LRAMP1 = 1087,
            // Token: 0x04001134 RID: 4404
            VIS_LSPAN1 = 1080,
            // Token: 0x04001135 RID: 4405
            VIS_LTOWER1 = 1072,
            // Token: 0x04001136 RID: 4406
            VIS_LRAMP2 = 1118,
            // Token: 0x04001137 RID: 4407
            VIS_LSPAN2 = 1101,
            // Token: 0x04001138 RID: 4408
            VIS_PILEBIG = 1055,
            // Token: 0x04001139 RID: 4409
            VIS_PILESML,
            // Token: 0x0400113A RID: 4410
            VIS_TEST,
            // Token: 0x0400113B RID: 4411
            VIS_OFF_BLOCK,
            // Token: 0x0400113C RID: 4412
            VIS_OFF_BLOCK2,
            // Token: 0x0400113D RID: 4413
            VIS_OFF_BLOCK3,
            // Token: 0x0400113E RID: 4414
            VIS_OFF_BLOCK4,
            // Token: 0x0400113F RID: 4415
            VIS_OFF_BLOCK5,
            // Token: 0x04001140 RID: 4416
            VIS_OFF_BLOCK6,
            // Token: 0x04001141 RID: 4417
            VIS_OFF_BLOCK7,
            // Token: 0x04001142 RID: 4418
            VIS_OFF_BLOCK8,
            // Token: 0x04001143 RID: 4419
            VIS_OFF_BLOCK9 = 1068,
            // Token: 0x04001144 RID: 4420
            VIS_WAREHOUSE3 = 1070,
            // Token: 0x04001145 RID: 4421
            VIS_WAREHOUSE4,
            // Token: 0x04001146 RID: 4422
            VIS_TVSTN1 = 1050,
            // Token: 0x04001147 RID: 4423
            VIS_HOTEL1 = 2,
            // Token: 0x04001148 RID: 4424
            VIS_R04BGA = 459,
            // Token: 0x04001149 RID: 4425
            VIS_R04BGB,
            // Token: 0x0400114A RID: 4426
            VIS_R04BGC,
            // Token: 0x0400114B RID: 4427
            VIS_SM_BRIDGE3 = 19,
            // Token: 0x0400114C RID: 4428
            VIS_MFLAME_S = 483,
            // Token: 0x0400114D RID: 4429
            VIS_SAM_LAUN = 561,
            // Token: 0x0400114E RID: 4430
            VIS_MISS_FLAME = 1067,
            // Token: 0x0400114F RID: 4431
            VIS_ENG_FIRE = 1066,
            // Token: 0x04001150 RID: 4432
            VIS_SM_FACT1 = 10,
            // Token: 0x04001151 RID: 4433
            VIS_SM_FACT2 = 122,
            // Token: 0x04001152 RID: 4434
            VIS_SM_FACT3 = 8,
            // Token: 0x04001153 RID: 4435
            VIS_BARRACKS2 = 291,
            // Token: 0x04001154 RID: 4436
            VIS_4KRUNWAY = 9,
            // Token: 0x04001155 RID: 4437
            VIS_FLARE1 = 6,
            // Token: 0x04001156 RID: 4438
            VIS_C01_02 = 570,
            // Token: 0x04001157 RID: 4439
            VIS_TANK_HULK = 985,
            // Token: 0x04001158 RID: 4440
            VIS_R02_NPGB = 12,
            // Token: 0x04001159 RID: 4441
            VIS_R02_NPGC,
            // Token: 0x0400115A RID: 4442
            VIS_R02_NPGD,
            // Token: 0x0400115B RID: 4443
            VIS_R02_PGA,
            // Token: 0x0400115C RID: 4444
            VIS_R02_PGB,
            // Token: 0x0400115D RID: 4445
            VIS_FFG = 20,
            // Token: 0x0400115E RID: 4446
            VIS_ENFAC,
            // Token: 0x0400115F RID: 4447
            VIS_GENTANKER,
            // Token: 0x04001160 RID: 4448
            VIS_CV67,
            // Token: 0x04001161 RID: 4449
            VIS_CG47,
            // Token: 0x04001162 RID: 4450
            VIS_ULSAN,
            // Token: 0x04001163 RID: 4451
            VIS_OFFICE18,
            // Token: 0x04001164 RID: 4452
            VIS_OFFICE19,
            // Token: 0x04001165 RID: 4453
            VIS_OFFICE20,
            // Token: 0x04001166 RID: 4454
            VIS_OFFICE21,
            // Token: 0x04001167 RID: 4455
            VIS_OFFICE22,
            // Token: 0x04001168 RID: 4456
            VIS_OFFICE23,
            // Token: 0x04001169 RID: 4457
            VIS_OFFICE24,
            // Token: 0x0400116A RID: 4458
            VIS_OFFICE25,
            // Token: 0x0400116B RID: 4459
            VIS_N02_01 = 373,
            // Token: 0x0400116C RID: 4460
            VIS_DN02_01,
            // Token: 0x0400116D RID: 4461
            VIS_THP26 = 1275,
            // Token: 0x0400116E RID: 4462
            VIS_DHELI1BOD = 101,
            // Token: 0x0400116F RID: 4463
            VIS_DHELI1TL,
            // Token: 0x04001170 RID: 4464
            VIS_DHELI1PT,
            // Token: 0x04001171 RID: 4465
            VIS_DCOMV,
            // Token: 0x04001172 RID: 4466
            VIS_DNTRUK1,
            // Token: 0x04001173 RID: 4467
            VIS_DNTRUK2,
            // Token: 0x04001174 RID: 4468
            VIS_DTRUCK1,
            // Token: 0x04001175 RID: 4469
            VIS_DTANK1,
            // Token: 0x04001176 RID: 4470
            VIS_DTANK2,
            // Token: 0x04001177 RID: 4471
            VIS_DTANK3,
            // Token: 0x04001178 RID: 4472
            VIS_DJEEP2,
            // Token: 0x04001179 RID: 4473
            VIS_DJEEP3,
            // Token: 0x0400117A RID: 4474
            VIS_DLNCHR,
            // Token: 0x0400117B RID: 4475
            VIS_RADAR9,
            // Token: 0x0400117C RID: 4476
            VIS_AMMO_DUMP1,
            // Token: 0x0400117D RID: 4477
            VIS_LSPAN4 = 1133,
            // Token: 0x0400117E RID: 4478
            VIS_LSPAN5 = 1147,
            // Token: 0x0400117F RID: 4479
            VIS_LSPAN6 = 1156,
            // Token: 0x04001180 RID: 4480
            VIS_LSPAN7_1 = 1180,
            // Token: 0x04001181 RID: 4481
            VIS_LSPAN6_2 = 1163,
            // Token: 0x04001182 RID: 4482
            VIS_DEBRIS1 = 123,
            // Token: 0x04001183 RID: 4483
            VIS_DEBRIS2,
            // Token: 0x04001184 RID: 4484
            VIS_DEBRIS3,
            // Token: 0x04001185 RID: 4485
            VIS_AEXPLOSION2,
            // Token: 0x04001186 RID: 4486
            VIS_CRATER2,
            // Token: 0x04001187 RID: 4487
            VIS_CRATER3,
            // Token: 0x04001188 RID: 4488
            VIS_CRATER4,
            // Token: 0x04001189 RID: 4489
            VIS_FIREBALL,
            // Token: 0x0400118A RID: 4490
            VIS_SCUD,
            // Token: 0x0400118B RID: 4491
            VIS_SA15L = 134,
            // Token: 0x0400118C RID: 4492
            VIS_PATRIOTL,
            // Token: 0x0400118D RID: 4493
            VIS_N02_02 = 375,
            // Token: 0x0400118E RID: 4494
            VIS_DN02_02,
            // Token: 0x0400118F RID: 4495
            VIS_TAXIS04 = 462,
            // Token: 0x04001190 RID: 4496
            VIS_OFFICE26 = 34,
            // Token: 0x04001191 RID: 4497
            VIS_D1F16LW,
            // Token: 0x04001192 RID: 4498
            VIS_D1F16RW,
            // Token: 0x04001193 RID: 4499
            VIS_D1F16FUS,
            // Token: 0x04001194 RID: 4500
            VIS_D1F16NOS,
            // Token: 0x04001195 RID: 4501
            VIS_D2F16FUS,
            // Token: 0x04001196 RID: 4502
            VIS_D2F16STB,
            // Token: 0x04001197 RID: 4503
            VIS_D1MIG29L,
            // Token: 0x04001198 RID: 4504
            VIS_D1MIG29R,
            // Token: 0x04001199 RID: 4505
            VIS_D1MIG29F,
            // Token: 0x0400119A RID: 4506
            VIS_D1MIG29N,
            // Token: 0x0400119B RID: 4507
            VIS_KIROV,
            // Token: 0x0400119C RID: 4508
            VIS_DUST1,
            // Token: 0x0400119D RID: 4509
            VIS_R01_NPGA = 49,
            // Token: 0x0400119E RID: 4510
            VIS_R01_NPGB,
            // Token: 0x0400119F RID: 4511
            VIS_R01_NPGC,
            // Token: 0x040011A0 RID: 4512
            VIS_R01_PFLA,
            // Token: 0x040011A1 RID: 4513
            VIS_R01_PGB,
            // Token: 0x040011A2 RID: 4514
            VIS_R01_PGA,
            // Token: 0x040011A3 RID: 4515
            VIS_R01_PFLB,
            // Token: 0x040011A4 RID: 4516
            VIS_LIGHTS_1,
            // Token: 0x040011A5 RID: 4517
            VIS_LIGHTS_2,
            // Token: 0x040011A6 RID: 4518
            VIS_HANGAR11,
            // Token: 0x040011A7 RID: 4519
            VIS_HANGAR12,
            // Token: 0x040011A8 RID: 4520
            VIS_DHANGAR1,
            // Token: 0x040011A9 RID: 4521
            VIS_DHANGAR2,
            // Token: 0x040011AA RID: 4522
            VIS_WTOWER4,
            // Token: 0x040011AB RID: 4523
            VIS_CTRL_TOWER2,
            // Token: 0x040011AC RID: 4524
            VIS_EJECT1,
            // Token: 0x040011AD RID: 4525
            VIS_EJECT2,
            // Token: 0x040011AE RID: 4526
            VIS_VASI_N,
            // Token: 0x040011AF RID: 4527
            VIS_VASI_F,
            // Token: 0x040011B0 RID: 4528
            VIS_DHELI1ROT = 100,
            // Token: 0x040011B1 RID: 4529
            VIS_LANDL = 463,
            // Token: 0x040011B2 RID: 4530
            VIS_NUM160,
            // Token: 0x040011B3 RID: 4531
            VIS_RV82A,
            // Token: 0x040011B4 RID: 4532
            VIS_DMIG23RW = 250,
            // Token: 0x040011B5 RID: 4533
            VIS_DMIG23NOS,
            // Token: 0x040011B6 RID: 4534
            VIS_DSU25FUS,
            // Token: 0x040011B7 RID: 4535
            VIS_DSU25LW,
            // Token: 0x040011B8 RID: 4536
            VIS_DSU25RW,
            // Token: 0x040011B9 RID: 4537
            VIS_DSU25NOS,
            // Token: 0x040011BA RID: 4538
            VIS_DSU27FUS,
            // Token: 0x040011BB RID: 4539
            VIS_DSU27LW,
            // Token: 0x040011BC RID: 4540
            VIS_DSU27RW,
            // Token: 0x040011BD RID: 4541
            VIS_DSU27NOS,
            // Token: 0x040011BE RID: 4542
            VIS_DIL28NOS,
            // Token: 0x040011BF RID: 4543
            VIS_APT3,
            // Token: 0x040011C0 RID: 4544
            VIS_PLOT_F01_04,
            // Token: 0x040011C1 RID: 4545
            VIS_PLOT_F01_05,
            // Token: 0x040011C2 RID: 4546
            VIS_APT7,
            // Token: 0x040011C3 RID: 4547
            VIS_EJECT3,
            // Token: 0x040011C4 RID: 4548
            VIS_FIRE1,
            // Token: 0x040011C5 RID: 4549
            VIS_EJECT4,
            // Token: 0x040011C6 RID: 4550
            VIS_CANOPY1,
            // Token: 0x040011C7 RID: 4551
            VIS_DC01_02 = 270,
            // Token: 0x040011C8 RID: 4552
            VIS_DC01_03 = 272,
            // Token: 0x040011C9 RID: 4553
            VIS_DC01_04 = 274,
            // Token: 0x040011CA RID: 4554
            VIS_DC01_05 = 276,
            // Token: 0x040011CB RID: 4555
            VIS_DC01_06 = 278,
            // Token: 0x040011CC RID: 4556
            VIS_C01_07,
            // Token: 0x040011CD RID: 4557
            VIS_DC01_07,
            // Token: 0x040011CE RID: 4558
            VIS_C01_08,
            // Token: 0x040011CF RID: 4559
            VIS_DC01_08,
            // Token: 0x040011D0 RID: 4560
            VIS_N02_03 = 377,
            // Token: 0x040011D1 RID: 4561
            VIS_THP29 = 1276,
            // Token: 0x040011D2 RID: 4562
            VIS_THP30,
            // Token: 0x040011D3 RID: 4563
            VIS_THP32,
            // Token: 0x040011D4 RID: 4564
            VIS_THP32LR,
            // Token: 0x040011D5 RID: 4565
            VIS_THP32RL,
            // Token: 0x040011D6 RID: 4566
            VIS_THP33,
            // Token: 0x040011D7 RID: 4567
            VIS_LTOWER2 = 1109,
            // Token: 0x040011D8 RID: 4568
            VIS_LSPAN6_3 = 1168,
            // Token: 0x040011D9 RID: 4569
            VIS_LTOWER1_W = 1079,
            // Token: 0x040011DA RID: 4570
            VIS_LTOWER1_P = 1076,
            // Token: 0x040011DB RID: 4571
            VIS_LTOWER1_N = 1075,
            // Token: 0x040011DC RID: 4572
            VIS_LTOWER1_R = 1077,
            // Token: 0x040011DD RID: 4573
            VIS_LSPAN1_W = 1086,
            // Token: 0x040011DE RID: 4574
            VIS_LSPAN1_P = 1084,
            // Token: 0x040011DF RID: 4575
            VIS_LSPAN1_N = 1083,
            // Token: 0x040011E0 RID: 4576
            VIS_LSPAN1_R = 1085,
            // Token: 0x040011E1 RID: 4577
            VIS_LRAMP1_W = 1088,
            // Token: 0x040011E2 RID: 4578
            VIS_LSPAN2_W = 1108,
            // Token: 0x040011E3 RID: 4579
            VIS_LSPAN2_P = 1105,
            // Token: 0x040011E4 RID: 4580
            VIS_LSPAN2_N = 1104,
            // Token: 0x040011E5 RID: 4581
            VIS_LSPAN2_R = 1106,
            // Token: 0x040011E6 RID: 4582
            VIS_LTOWER2_W = 1117,
            // Token: 0x040011E7 RID: 4583
            VIS_LTOWER2_P = 1114,
            // Token: 0x040011E8 RID: 4584
            VIS_LTOWER2_N = 1113,
            // Token: 0x040011E9 RID: 4585
            VIS_LTOWER2_R = 1115,
            // Token: 0x040011EA RID: 4586
            VIS_LTOWER2_B = 1111,
            // Token: 0x040011EB RID: 4587
            VIS_LRAMP2_W = 1123,
            // Token: 0x040011EC RID: 4588
            VIS_LRAMP2_R = 1121,
            // Token: 0x040011ED RID: 4589
            VIS_LSPAN3 = 1124,
            // Token: 0x040011EE RID: 4590
            VIS_LSPAN3_W = 1132,
            // Token: 0x040011EF RID: 4591
            VIS_LSPAN3_P = 1129,
            // Token: 0x040011F0 RID: 4592
            VIS_LSPAN3_N = 1128,
            // Token: 0x040011F1 RID: 4593
            VIS_LSPAN3_R = 1130,
            // Token: 0x040011F2 RID: 4594
            VIS_LSPAN3_B = 1126,
            // Token: 0x040011F3 RID: 4595
            VIS_LSPAN4_W = 1139,
            // Token: 0x040011F4 RID: 4596
            VIS_LSPAN4_P = 1137,
            // Token: 0x040011F5 RID: 4597
            VIS_LSPAN4_N = 1136,
            // Token: 0x040011F6 RID: 4598
            VIS_LSPAN4_R = 1138,
            // Token: 0x040011F7 RID: 4599
            VIS_LSPAN5_W = 1155,
            // Token: 0x040011F8 RID: 4600
            VIS_LSPAN5_P = 1152,
            // Token: 0x040011F9 RID: 4601
            VIS_LSPAN5_N = 1151,
            // Token: 0x040011FA RID: 4602
            VIS_LSPAN5_R = 1153,
            // Token: 0x040011FB RID: 4603
            VIS_LSPAN5_B = 1149,
            // Token: 0x040011FC RID: 4604
            VIS_LSPAN6_W = 1162,
            // Token: 0x040011FD RID: 4605
            VIS_LSPAN6_R = 1161,
            // Token: 0x040011FE RID: 4606
            VIS_LSPAN6_P = 1160,
            // Token: 0x040011FF RID: 4607
            VIS_LSPAN6_N = 1159,
            // Token: 0x04001200 RID: 4608
            VIS_LSPAN6_2W = 1167,
            // Token: 0x04001201 RID: 4609
            VIS_LSPAN6_2R = 1166,
            // Token: 0x04001202 RID: 4610
            VIS_LSPAN6_2P = 1165,
            // Token: 0x04001203 RID: 4611
            VIS_LSPAN6_2N = 1164,
            // Token: 0x04001204 RID: 4612
            VIS_LSPAN6_3W = 1172,
            // Token: 0x04001205 RID: 4613
            VIS_LSPAN6_3R = 1171,
            // Token: 0x04001206 RID: 4614
            VIS_LSPAN6_3P = 1170,
            // Token: 0x04001207 RID: 4615
            VIS_LSPAN6_3N = 1169,
            // Token: 0x04001208 RID: 4616
            VIS_LSPAN7_W = 1188,
            // Token: 0x04001209 RID: 4617
            VIS_LSPAN7_R = 1186,
            // Token: 0x0400120A RID: 4618
            VIS_LSPAN7_P = 1185,
            // Token: 0x0400120B RID: 4619
            VIS_LSPAN7_N = 1184,
            // Token: 0x0400120C RID: 4620
            VIS_LSPAN7_B = 1182,
            // Token: 0x0400120D RID: 4621
            VIS_BRIDGE1_X2 = 1089,
            // Token: 0x0400120E RID: 4622
            VIS_BR_TOP1_X2A,
            // Token: 0x0400120F RID: 4623
            VIS_BRIDGE1_X3 = 1095,
            // Token: 0x04001210 RID: 4624
            VIS_BR_TOP1_X3A,
            // Token: 0x04001211 RID: 4625
            VIS_BR_TOP2_1A = 1102,
            // Token: 0x04001212 RID: 4626
            VIS_BR_TOP2_2A = 1110,
            // Token: 0x04001213 RID: 4627
            VIS_BR_TOP2_3A = 1119,
            // Token: 0x04001214 RID: 4628
            VIS_BR_TOP3_1A = 1125,
            // Token: 0x04001215 RID: 4629
            VIS_BR_TOP4_1A = 1134,
            // Token: 0x04001216 RID: 4630
            VIS_BR_TOP4_X2A = 1141,
            // Token: 0x04001217 RID: 4631
            VIS_BRIDGE4_X2 = 1140,
            // Token: 0x04001218 RID: 4632
            VIS_BR_TOP5_1A = 1148,
            // Token: 0x04001219 RID: 4633
            VIS_BR_TOP6_1A = 1157,
            // Token: 0x0400121A RID: 4634
            VIS_BRIDGE6_X2 = 1173,
            // Token: 0x0400121B RID: 4635
            VIS_BR_TOP6_X2A,
            // Token: 0x0400121C RID: 4636
            VIS_BR_TOP7_1A = 1181,
            // Token: 0x0400121D RID: 4637
            VIS_BR_TOP1_1D = 1074,
            // Token: 0x0400121E RID: 4638
            VIS_BR_TOP1_1R = 1078,
            // Token: 0x0400121F RID: 4639
            VIS_BR_TOP1_2D = 1082,
            // Token: 0x04001220 RID: 4640
            VIS_BR_TOP2_1D = 1103,
            // Token: 0x04001221 RID: 4641
            VIS_BR_TOP2_1R = 1107,
            // Token: 0x04001222 RID: 4642
            VIS_BR_TOP2_2D = 1112,
            // Token: 0x04001223 RID: 4643
            VIS_BR_TOP2_2R = 1116,
            // Token: 0x04001224 RID: 4644
            VIS_BR_TOP2_3D = 1120,
            // Token: 0x04001225 RID: 4645
            VIS_BR_TOP2_3R = 1122,
            // Token: 0x04001226 RID: 4646
            VIS_BR_TOP3_1D = 1127,
            // Token: 0x04001227 RID: 4647
            VIS_BR_TOP3_1R = 1131,
            // Token: 0x04001228 RID: 4648
            VIS_BR_TOP4_1D = 1135,
            // Token: 0x04001229 RID: 4649
            VIS_BR_TOP4_X2D = 1142,
            // Token: 0x0400122A RID: 4650
            VIS_BR_TOP5_1D = 1150,
            // Token: 0x0400122B RID: 4651
            VIS_BR_TOP5_1R = 1154,
            // Token: 0x0400122C RID: 4652
            VIS_BR_TOP6_1D = 1158,
            // Token: 0x0400122D RID: 4653
            VIS_BR_TOP6_X2D = 1176,
            // Token: 0x0400122E RID: 4654
            VIS_BR_TOP7_1D = 1183,
            // Token: 0x0400122F RID: 4655
            VIS_BR_TOP7_1R = 1187,
            // Token: 0x04001230 RID: 4656
            VIS_BRIDGE1_X3B = 1100,
            // Token: 0x04001231 RID: 4657
            VIS_BRIDGE1_X3N = 1097,
            // Token: 0x04001232 RID: 4658
            VIS_BRIDGE1_X3W = 1099,
            // Token: 0x04001233 RID: 4659
            VIS_BRIDGE4_X2B = 1146,
            // Token: 0x04001234 RID: 4660
            VIS_BRIDGE4_X2N = 1143,
            // Token: 0x04001235 RID: 4661
            VIS_BRIDGE4_X2P,
            // Token: 0x04001236 RID: 4662
            VIS_BRIDGE4_X2W,
            // Token: 0x04001237 RID: 4663
            VIS_BRIDGE6_X2B = 1175,
            // Token: 0x04001238 RID: 4664
            VIS_BRIDGE6_X2N = 1177,
            // Token: 0x04001239 RID: 4665
            VIS_BRIDGE6_X2P,
            // Token: 0x0400123A RID: 4666
            VIS_BRIDGE6_X2W,
            // Token: 0x0400123B RID: 4667
            VIS_BRIDGE1_X2B = 1094,
            // Token: 0x0400123C RID: 4668
            VIS_BRIDGE1_X2N = 1091,
            // Token: 0x0400123D RID: 4669
            VIS_BRIDGE1_X2P,
            // Token: 0x0400123E RID: 4670
            VIS_BRIDGE1_X2W,
            // Token: 0x0400123F RID: 4671
            VIS_BRIDGE1_X3P = 1098,
            // Token: 0x04001240 RID: 4672
            VIS_DIL28FUS = 245,
            // Token: 0x04001241 RID: 4673
            VIS_DIL28LW,
            // Token: 0x04001242 RID: 4674
            VIS_DIL28RW,
            // Token: 0x04001243 RID: 4675
            VIS_DMIG23FUS,
            // Token: 0x04001244 RID: 4676
            VIS_DMIG23LW,
            // Token: 0x04001245 RID: 4677
            VIS_C01_09 = 283,
            // Token: 0x04001246 RID: 4678
            VIS_TANKLG02 = 286,
            // Token: 0x04001247 RID: 4679
            VIS_DTANKLG02,
            // Token: 0x04001248 RID: 4680
            VIS_TANKLG03,
            // Token: 0x04001249 RID: 4681
            VIS_DTANKLG03,
            // Token: 0x0400124A RID: 4682
            VIS_TANKLG04,
            // Token: 0x0400124B RID: 4683
            VIS_CRACKER1 = 292,
            // Token: 0x0400124C RID: 4684
            VIS_DCRACKER1,
            // Token: 0x0400124D RID: 4685
            VIS_CRACKER2,
            // Token: 0x0400124E RID: 4686
            VIS_REL_VALVE1,
            // Token: 0x0400124F RID: 4687
            VIS_DREL_VALVE1,
            // Token: 0x04001250 RID: 4688
            VIS_DCRACKER2,
            // Token: 0x04001251 RID: 4689
            VIS_PROC_TANK1,
            // Token: 0x04001252 RID: 4690
            VIS_EJECT5,
            // Token: 0x04001253 RID: 4691
            VIS_DPROC_TANK1 = 284,
            // Token: 0x04001254 RID: 4692
            VIS_DCHURCH01 = 304,
            // Token: 0x04001255 RID: 4693
            VIS_DF01_01,
            // Token: 0x04001256 RID: 4694
            VIS_DF01_02,
            // Token: 0x04001257 RID: 4695
            VIS_DF01_03,
            // Token: 0x04001258 RID: 4696
            VIS_DF01_04,
            // Token: 0x04001259 RID: 4697
            VIS_DF01_05,
            // Token: 0x0400125A RID: 4698
            VIS_DOBLK01,
            // Token: 0x0400125B RID: 4699
            VIS_DOFF02,
            // Token: 0x0400125C RID: 4700
            VIS_DOFF03,
            // Token: 0x0400125D RID: 4701
            VIS_DOFF04,
            // Token: 0x0400125E RID: 4702
            VIS_DOFF05,
            // Token: 0x0400125F RID: 4703
            VIS_DOFF08,
            // Token: 0x04001260 RID: 4704
            VIS_R02_01,
            // Token: 0x04001261 RID: 4705
            VIS_R02_02,
            // Token: 0x04001262 RID: 4706
            VIS_R02_03,
            // Token: 0x04001263 RID: 4707
            VIS_R02_04,
            // Token: 0x04001264 RID: 4708
            VIS_R02_05,
            // Token: 0x04001265 RID: 4709
            VIS_R02_06,
            // Token: 0x04001266 RID: 4710
            VIS_R02_07,
            // Token: 0x04001267 RID: 4711
            VIS_R02_08,
            // Token: 0x04001268 RID: 4712
            VIS_DN02_03 = 378,
            // Token: 0x04001269 RID: 4713
            VIS_THP34 = 1282,
            // Token: 0x0400126A RID: 4714
            VIS_R02_09 = 324,
            // Token: 0x0400126B RID: 4715
            VIS_R02_10,
            // Token: 0x0400126C RID: 4716
            VIS_R02_11,
            // Token: 0x0400126D RID: 4717
            VIS_R02_12,
            // Token: 0x0400126E RID: 4718
            VIS_R02_13,
            // Token: 0x0400126F RID: 4719
            VIS_F05_01,
            // Token: 0x04001270 RID: 4720
            VIS_F05_02,
            // Token: 0x04001271 RID: 4721
            VIS_F05_03,
            // Token: 0x04001272 RID: 4722
            VIS_F05_04,
            // Token: 0x04001273 RID: 4723
            VIS_F05_05,
            // Token: 0x04001274 RID: 4724
            VIS_F05_06,
            // Token: 0x04001275 RID: 4725
            VIS_F05_07,
            // Token: 0x04001276 RID: 4726
            VIS_F05_08,
            // Token: 0x04001277 RID: 4727
            VIS_F05_09,
            // Token: 0x04001278 RID: 4728
            VIS_DR02_01,
            // Token: 0x04001279 RID: 4729
            VIS_DR02_02,
            // Token: 0x0400127A RID: 4730
            VIS_DR02_03,
            // Token: 0x0400127B RID: 4731
            VIS_DR02_04,
            // Token: 0x0400127C RID: 4732
            VIS_DR02_05,
            // Token: 0x0400127D RID: 4733
            VIS_DR02_06,
            // Token: 0x0400127E RID: 4734
            VIS_DR02_07,
            // Token: 0x0400127F RID: 4735
            VIS_DR02_08,
            // Token: 0x04001280 RID: 4736
            VIS_DR02_09,
            // Token: 0x04001281 RID: 4737
            VIS_DR02_10,
            // Token: 0x04001282 RID: 4738
            VIS_DR02_11,
            // Token: 0x04001283 RID: 4739
            VIS_DR02_12,
            // Token: 0x04001284 RID: 4740
            VIS_DR02_13,
            // Token: 0x04001285 RID: 4741
            VIS_DF05_01,
            // Token: 0x04001286 RID: 4742
            VIS_DF05_02,
            // Token: 0x04001287 RID: 4743
            VIS_DF05_03,
            // Token: 0x04001288 RID: 4744
            VIS_DF05_04,
            // Token: 0x04001289 RID: 4745
            VIS_DF05_05,
            // Token: 0x0400128A RID: 4746
            VIS_DF05_06,
            // Token: 0x0400128B RID: 4747
            VIS_DF05_07,
            // Token: 0x0400128C RID: 4748
            VIS_DF05_08,
            // Token: 0x0400128D RID: 4749
            VIS_DF05_09,
            // Token: 0x0400128E RID: 4750
            VIS_DTNHL01,
            // Token: 0x0400128F RID: 4751
            VIS_DTVSTN01,
            // Token: 0x04001290 RID: 4752
            VIS_DSMLMF01,
            // Token: 0x04001291 RID: 4753
            VIS_DSHRINE01,
            // Token: 0x04001292 RID: 4754
            VIS_DOCK06,
            // Token: 0x04001293 RID: 4755
            VIS_HOTEL02,
            // Token: 0x04001294 RID: 4756
            VIS_HOSPITAL01,
            // Token: 0x04001295 RID: 4757
            VIS_HOSPITAL02,
            // Token: 0x04001296 RID: 4758
            VIS_HOSPITAL03,
            // Token: 0x04001297 RID: 4759
            VIS_SHOPBLK01,
            // Token: 0x04001298 RID: 4760
            VIS_SHOPBLK02,
            // Token: 0x04001299 RID: 4761
            VIS_SHOPBLK03,
            // Token: 0x0400129A RID: 4762
            VIS_SHOPBLK04,
            // Token: 0x0400129B RID: 4763
            VIS_N02_04 = 379,
            // Token: 0x0400129C RID: 4764
            VIS_DN02_04,
            // Token: 0x0400129D RID: 4765
            VIS_N02_05,
            // Token: 0x0400129E RID: 4766
            VIS_DN02_05,
            // Token: 0x0400129F RID: 4767
            VIS_COOLT2,
            // Token: 0x040012A0 RID: 4768
            VIS_DCOOLT2,
            // Token: 0x040012A1 RID: 4769
            VIS_N03_01,
            // Token: 0x040012A2 RID: 4770
            VIS_DN03_01,
            // Token: 0x040012A3 RID: 4771
            VIS_N03_02,
            // Token: 0x040012A4 RID: 4772
            VIS_DN03_02,
            // Token: 0x040012A5 RID: 4773
            VIS_N03_03,
            // Token: 0x040012A6 RID: 4774
            VIS_DN03_03,
            // Token: 0x040012A7 RID: 4775
            VIS_N03_04,
            // Token: 0x040012A8 RID: 4776
            VIS_DN03_04,
            // Token: 0x040012A9 RID: 4777
            VIS_N03_05,
            // Token: 0x040012AA RID: 4778
            VIS_DN03_05,
            // Token: 0x040012AB RID: 4779
            VIS_N03_06,
            // Token: 0x040012AC RID: 4780
            VIS_DN03_06,
            // Token: 0x040012AD RID: 4781
            VIS_N04_01,
            // Token: 0x040012AE RID: 4782
            VIS_N04_02,
            // Token: 0x040012AF RID: 4783
            VIS_N04_03,
            // Token: 0x040012B0 RID: 4784
            VIS_N04_04,
            // Token: 0x040012B1 RID: 4785
            VIS_DN04_01,
            // Token: 0x040012B2 RID: 4786
            VIS_DN04_02,
            // Token: 0x040012B3 RID: 4787
            VIS_DN04_03,
            // Token: 0x040012B4 RID: 4788
            VIS_DN04_04,
            // Token: 0x040012B5 RID: 4789
            VIS_C02_01,
            // Token: 0x040012B6 RID: 4790
            VIS_C02_02,
            // Token: 0x040012B7 RID: 4791
            VIS_C02_03,
            // Token: 0x040012B8 RID: 4792
            VIS_C02_04,
            // Token: 0x040012B9 RID: 4793
            VIS_C02_05,
            // Token: 0x040012BA RID: 4794
            VIS_C02_06,
            // Token: 0x040012BB RID: 4795
            VIS_C02_07,
            // Token: 0x040012BC RID: 4796
            VIS_DC02_01,
            // Token: 0x040012BD RID: 4797
            VIS_DC02_02,
            // Token: 0x040012BE RID: 4798
            VIS_DC02_03,
            // Token: 0x040012BF RID: 4799
            VIS_DC02_04,
            // Token: 0x040012C0 RID: 4800
            VIS_DC02_05,
            // Token: 0x040012C1 RID: 4801
            VIS_DC02_06,
            // Token: 0x040012C2 RID: 4802
            VIS_DC02_07,
            // Token: 0x040012C3 RID: 4803
            VIS_LGTNK_05,
            // Token: 0x040012C4 RID: 4804
            VIS_LGTNK_06,
            // Token: 0x040012C5 RID: 4805
            VIS_LGTNK_07,
            // Token: 0x040012C6 RID: 4806
            VIS_RTWR_03,
            // Token: 0x040012C7 RID: 4807
            VIS_RTWR_04,
            // Token: 0x040012C8 RID: 4808
            VIS_CMTWR_01,
            // Token: 0x040012C9 RID: 4809
            VIS_SILO_01,
            // Token: 0x040012CA RID: 4810
            VIS_CMTWR_02,
            // Token: 0x040012CB RID: 4811
            VIS_C03_01,
            // Token: 0x040012CC RID: 4812
            VIS_PP02_01,
            // Token: 0x040012CD RID: 4813
            VIS_PP02_02,
            // Token: 0x040012CE RID: 4814
            VIS_PP02_03,
            // Token: 0x040012CF RID: 4815
            VIS_PP03_01,
            // Token: 0x040012D0 RID: 4816
            VIS_PP03_02,
            // Token: 0x040012D1 RID: 4817
            VIS_PP03_03,
            // Token: 0x040012D2 RID: 4818
            VIS_PP04_01,
            // Token: 0x040012D3 RID: 4819
            VIS_PTWR03,
            // Token: 0x040012D4 RID: 4820
            VIS_PP01_04,
            // Token: 0x040012D5 RID: 4821
            VIS_PP01_05,
            // Token: 0x040012D6 RID: 4822
            VIS_PTWR02,
            // Token: 0x040012D7 RID: 4823
            VIS_F03_01,
            // Token: 0x040012D8 RID: 4824
            VIS_F03_02,
            // Token: 0x040012D9 RID: 4825
            VIS_F03_03,
            // Token: 0x040012DA RID: 4826
            VIS_F03_04,
            // Token: 0x040012DB RID: 4827
            VIS_F03_05,
            // Token: 0x040012DC RID: 4828
            VIS_DF03_01,
            // Token: 0x040012DD RID: 4829
            VIS_DF03_02,
            // Token: 0x040012DE RID: 4830
            VIS_DF03_03,
            // Token: 0x040012DF RID: 4831
            VIS_DF03_04,
            // Token: 0x040012E0 RID: 4832
            VIS_DF03_05,
            // Token: 0x040012E1 RID: 4833
            VIS_R03_01,
            // Token: 0x040012E2 RID: 4834
            VIS_R03_02,
            // Token: 0x040012E3 RID: 4835
            VIS_R03_03,
            // Token: 0x040012E4 RID: 4836
            VIS_R03_04,
            // Token: 0x040012E5 RID: 4837
            VIS_R03_05,
            // Token: 0x040012E6 RID: 4838
            VIS_R03_06,
            // Token: 0x040012E7 RID: 4839
            VIS_R03_07,
            // Token: 0x040012E8 RID: 4840
            VIS_RV82B = 466,
            // Token: 0x040012E9 RID: 4841
            VIS_RV82C,
            // Token: 0x040012EA RID: 4842
            VIS_TAXIS05,
            // Token: 0x040012EB RID: 4843
            VIS_CTR03,
            // Token: 0x040012EC RID: 4844
            VIS_TAXIS06,
            // Token: 0x040012ED RID: 4845
            VIS_R06RGA,
            // Token: 0x040012EE RID: 4846
            VIS_R06RGB,
            // Token: 0x040012EF RID: 4847
            VIS_R06RGC,
            // Token: 0x040012F0 RID: 4848
            VIS_R06LGA,
            // Token: 0x040012F1 RID: 4849
            VIS_R06LGB,
            // Token: 0x040012F2 RID: 4850
            VIS_R06LGC,
            // Token: 0x040012F3 RID: 4851
            VIS_FLAND,
            // Token: 0x040012F4 RID: 4852
            VIS_BLDG01,
            // Token: 0x040012F5 RID: 4853
            VIS_BLDG02,
            // Token: 0x040012F6 RID: 4854
            VIS_BLDG03,
            // Token: 0x040012F7 RID: 4855
            VIS_BLDG04,
            // Token: 0x040012F8 RID: 4856
            VIS_BLDG05,
            // Token: 0x040012F9 RID: 4857
            VIS_END_MISSION = 4,
            // Token: 0x040012FA RID: 4858
            VIS_SHOP7 = 485,
            // Token: 0x040012FB RID: 4859
            VIS_SIX_RACK,
            // Token: 0x040012FC RID: 4860
            VIS_QUAD_RACK,
            // Token: 0x040012FD RID: 4861
            VIS_THP27,
            // Token: 0x040012FE RID: 4862
            VIS_THP09,
            // Token: 0x040012FF RID: 4863
            VIS_THA,
            // Token: 0x04001300 RID: 4864
            VIS_THP2R,
            // Token: 0x04001301 RID: 4865
            VIS_THC,
            // Token: 0x04001302 RID: 4866
            VIS_THD,
            // Token: 0x04001303 RID: 4867
            VIS_THE,
            // Token: 0x04001304 RID: 4868
            VIS_THF,
            // Token: 0x04001305 RID: 4869
            VIS_THG,
            // Token: 0x04001306 RID: 4870
            VIS_AB1TL1,
            // Token: 0x04001307 RID: 4871
            VIS_AB1TL2,
            // Token: 0x04001308 RID: 4872
            VIS_AB1TL3,
            // Token: 0x04001309 RID: 4873
            VIS_AB1TL4,
            // Token: 0x0400130A RID: 4874
            VIS_AB1TL5,
            // Token: 0x0400130B RID: 4875
            VIS_AB1TL7,
            // Token: 0x0400130C RID: 4876
            VIS_AB1TMD2,
            // Token: 0x0400130D RID: 4877
            VIS_AB1TMD3,
            // Token: 0x0400130E RID: 4878
            VIS_AB5TL1,
            // Token: 0x0400130F RID: 4879
            VIS_AB5TL2,
            // Token: 0x04001310 RID: 4880
            VIS_AB5TL3,
            // Token: 0x04001311 RID: 4881
            VIS_AB5TL4,
            // Token: 0x04001312 RID: 4882
            VIS_FLAND27,
            // Token: 0x04001313 RID: 4883
            VIS_AB5TL5,
            // Token: 0x04001314 RID: 4884
            VIS_AB6TMD2,
            // Token: 0x04001315 RID: 4885
            VIS_AB5THP1,
            // Token: 0x04001316 RID: 4886
            VIS_AB6TMD3,
            // Token: 0x04001317 RID: 4887
            VIS_AB6TMD4,
            // Token: 0x04001318 RID: 4888
            VIS_AB6TL3,
            // Token: 0x04001319 RID: 4889
            VIS_AB6UTMD2 = 517,
            // Token: 0x0400131A RID: 4890
            VIS_AB6UTMD3,
            // Token: 0x0400131B RID: 4891
            VIS_AB6UTL2,
            // Token: 0x0400131C RID: 4892
            VIS_AB8TMD1,
            // Token: 0x0400131D RID: 4893
            VIS_AB7TMD2,
            // Token: 0x0400131E RID: 4894
            VIS_AB5THP6,
            // Token: 0x0400131F RID: 4895
            VIS_AB7TMD3,
            // Token: 0x04001320 RID: 4896
            VIS_DEPOT2_F,
            // Token: 0x04001321 RID: 4897
            VIS_SHADOW,
            // Token: 0x04001322 RID: 4898
            VIS_CRANE1 = 528,
            // Token: 0x04001323 RID: 4899
            VIS_DAEWOO,
            // Token: 0x04001324 RID: 4900
            VIS_BUNKER3,
            // Token: 0x04001325 RID: 4901
            VIS_DOCK07,
            // Token: 0x04001326 RID: 4902
            VIS_FOOT_SQUAD,
            // Token: 0x04001327 RID: 4903
            VIS_ALLM4SQD,
            // Token: 0x04001328 RID: 4904
            VIS_DPRKATMISSQD,
            // Token: 0x04001329 RID: 4905
            VIS_PRCATMISSQD,
            // Token: 0x0400132A RID: 4906
            VIS_PRCARTSQD,
            // Token: 0x0400132B RID: 4907
            VIS_DPRKARTSQD,
            // Token: 0x0400132C RID: 4908
            VIS_ALLM16SQD,
            // Token: 0x0400132D RID: 4909
            VIS_USSAMSQUAD,
            // Token: 0x0400132E RID: 4910
            VIS_ROKSAMSQD,
            // Token: 0x0400132F RID: 4911
            VIS_CISSAMSQD,
            // Token: 0x04001330 RID: 4912
            VIS_DPRKSAMSQD,
            // Token: 0x04001331 RID: 4913
            VIS_USATMISSQD,
            // Token: 0x04001332 RID: 4914
            VIS_USARTSQD,
            // Token: 0x04001333 RID: 4915
            VIS_ROKATMISSQD,
            // Token: 0x04001334 RID: 4916
            VIS_CISATMISSQD,
            // Token: 0x04001335 RID: 4917
            VIS_ROKARTSQD,
            // Token: 0x04001336 RID: 4918
            VIS_CISARTSQD,
            // Token: 0x04001337 RID: 4919
            VIS_PRCSAMSQD,
            // Token: 0x04001338 RID: 4920
            VIS_ALLM60SQD,
            // Token: 0x04001339 RID: 4921
            VIS_USMORTSQD,
            // Token: 0x0400133A RID: 4922
            VIS_PRCMORTSQD,
            // Token: 0x0400133B RID: 4923
            VIS_DPRKMORTSQD,
            // Token: 0x0400133C RID: 4924
            VIS_ROKMORTSQD,
            // Token: 0x0400133D RID: 4925
            VIS_RES_INF_SQUAD,
            // Token: 0x0400133E RID: 4926
            VIS_GUYDIE,
            // Token: 0x0400133F RID: 4927
            VIS_DOWN_PILOT,
            // Token: 0x04001340 RID: 4928
            VIS_DOCK04,
            // Token: 0x04001341 RID: 4929
            VIS_DOCK05,
            // Token: 0x04001342 RID: 4930
            VIS_F16CBLU = 5,
            // Token: 0x04001343 RID: 4931
            VIS_F16CGRN = 562,
            // Token: 0x04001344 RID: 4932
            VIS_F16CORG,
            // Token: 0x04001345 RID: 4933
            VIS_F16CRED,
            // Token: 0x04001346 RID: 4934
            VIS_C01_03,
            // Token: 0x04001347 RID: 4935
            VIS_C01_04,
            // Token: 0x04001348 RID: 4936
            VIS_C01_05,
            // Token: 0x04001349 RID: 4937
            VIS_C01_06,
            // Token: 0x0400134A RID: 4938
            VIS_C01_10,
            // Token: 0x0400134B RID: 4939
            VIS_D1MIG29FBLU = 571,
            // Token: 0x0400134C RID: 4940
            VIS_D1MIG29FGRN,
            // Token: 0x0400134D RID: 4941
            VIS_D1MIG29FORG,
            // Token: 0x0400134E RID: 4942
            VIS_D1MIG29FRED,
            // Token: 0x0400134F RID: 4943
            VIS_D1MIG29LBLU,
            // Token: 0x04001350 RID: 4944
            VIS_D1MIG29LGRN,
            // Token: 0x04001351 RID: 4945
            VIS_D1MIG29LRED,
            // Token: 0x04001352 RID: 4946
            VIS_D1MIG29LORG,
            // Token: 0x04001353 RID: 4947
            VIS_D1MIG29NBLU,
            // Token: 0x04001354 RID: 4948
            VIS_D1MIG29NGRN,
            // Token: 0x04001355 RID: 4949
            VIS_D1MIG29NORG,
            // Token: 0x04001356 RID: 4950
            VIS_D1MIG29NRED,
            // Token: 0x04001357 RID: 4951
            VIS_D1MIG29RBLU,
            // Token: 0x04001358 RID: 4952
            VIS_D1MIG29RGRN,
            // Token: 0x04001359 RID: 4953
            VIS_D1MIG29RORG,
            // Token: 0x0400135A RID: 4954
            VIS_D1MIG29RRED,
            // Token: 0x0400135B RID: 4955
            VIS_DMIG19FUSBLU,
            // Token: 0x0400135C RID: 4956
            VIS_DMIG19FUSGRN,
            // Token: 0x0400135D RID: 4957
            VIS_DMIG19FUSORG,
            // Token: 0x0400135E RID: 4958
            VIS_DMIG19FUSRED,
            // Token: 0x0400135F RID: 4959
            VIS_DMIG19LWBLU,
            // Token: 0x04001360 RID: 4960
            VIS_DMIG19LWGRN,
            // Token: 0x04001361 RID: 4961
            VIS_DMIG19LWORG,
            // Token: 0x04001362 RID: 4962
            VIS_DMIG19LWRED,
            // Token: 0x04001363 RID: 4963
            VIS_THP34LR = 1283,
            // Token: 0x04001364 RID: 4964
            VIS_DMIG19RWBLU = 595,
            // Token: 0x04001365 RID: 4965
            VIS_DMIG19RWGRN,
            // Token: 0x04001366 RID: 4966
            VIS_DMIG19RWORG,
            // Token: 0x04001367 RID: 4967
            VIS_DMIG19RWRED,
            // Token: 0x04001368 RID: 4968
            VIS_DMIG19TLBLU,
            // Token: 0x04001369 RID: 4969
            VIS_DMIG19TLGRN,
            // Token: 0x0400136A RID: 4970
            VIS_DMIG19TLORG,
            // Token: 0x0400136B RID: 4971
            VIS_DMIG19TLRED,
            // Token: 0x0400136C RID: 4972
            VIS_DMIG21FUSBLU,
            // Token: 0x0400136D RID: 4973
            VIS_DMIG21FUSGRN,
            // Token: 0x0400136E RID: 4974
            VIS_DMIG21FUSORG,
            // Token: 0x0400136F RID: 4975
            VIS_DMIG21FUSRED,
            // Token: 0x04001370 RID: 4976
            VIS_DMIG21LWBLU,
            // Token: 0x04001371 RID: 4977
            VIS_DMIG21LWGRN,
            // Token: 0x04001372 RID: 4978
            VIS_DMIG21LWORG,
            // Token: 0x04001373 RID: 4979
            VIS_DMIG21LWRED,
            // Token: 0x04001374 RID: 4980
            VIS_DMIG21RWBLU,
            // Token: 0x04001375 RID: 4981
            VIS_DMIG21RWGRN,
            // Token: 0x04001376 RID: 4982
            VIS_DMIG21RWORG,
            // Token: 0x04001377 RID: 4983
            VIS_DMIG21RWRED,
            // Token: 0x04001378 RID: 4984
            VIS_DMIG21TLBLU,
            // Token: 0x04001379 RID: 4985
            VIS_DMIG21TLGRN,
            // Token: 0x0400137A RID: 4986
            VIS_DMIG21TLORG,
            // Token: 0x0400137B RID: 4987
            VIS_DMIG21TLRED,
            // Token: 0x0400137C RID: 4988
            VIS_DMIG23FUSBLU,
            // Token: 0x0400137D RID: 4989
            VIS_DMIG23FUSGRN,
            // Token: 0x0400137E RID: 4990
            VIS_DMIG23FUSORG,
            // Token: 0x0400137F RID: 4991
            VIS_DMIG23FUSRED,
            // Token: 0x04001380 RID: 4992
            VIS_DMIG23LWBLU,
            // Token: 0x04001381 RID: 4993
            VIS_DMIG23LWGRN,
            // Token: 0x04001382 RID: 4994
            VIS_DMIG23LWORG,
            // Token: 0x04001383 RID: 4995
            VIS_DMIG23LWRED,
            // Token: 0x04001384 RID: 4996
            VIS_DMIG23RWBLU,
            // Token: 0x04001385 RID: 4997
            VIS_DMIG23RWGRN,
            // Token: 0x04001386 RID: 4998
            VIS_DMIG23RWORG,
            // Token: 0x04001387 RID: 4999
            VIS_DMIG23RWRED,
            // Token: 0x04001388 RID: 5000
            VIS_DMIG23NOSBLU,
            // Token: 0x04001389 RID: 5001
            VIS_DMIG23NOSGRN,
            // Token: 0x0400138A RID: 5002
            VIS_DMIG23NOSORG,
            // Token: 0x0400138B RID: 5003
            VIS_DMIG23NOSRED,
            // Token: 0x0400138C RID: 5004
            VIS_MIG29BLU,
            // Token: 0x0400138D RID: 5005
            VIS_MIG29ORG,
            // Token: 0x0400138E RID: 5006
            VIS_MIG29GRN,
            // Token: 0x0400138F RID: 5007
            VIS_MIG29RED,
            // Token: 0x04001390 RID: 5008
            VIS_MIG19BLU,
            // Token: 0x04001391 RID: 5009
            VIS_MIG19RED,
            // Token: 0x04001392 RID: 5010
            VIS_MIG19GRN,
            // Token: 0x04001393 RID: 5011
            VIS_MIG19ORG,
            // Token: 0x04001394 RID: 5012
            VIS_MIG21BLU,
            // Token: 0x04001395 RID: 5013
            VIS_MIG21GRN,
            // Token: 0x04001396 RID: 5014
            VIS_MIG21ORG,
            // Token: 0x04001397 RID: 5015
            VIS_MIG23BLU,
            // Token: 0x04001398 RID: 5016
            VIS_MIG23GRN,
            // Token: 0x04001399 RID: 5017
            VIS_MIG23ORG,
            // Token: 0x0400139A RID: 5018
            VIS_F14BLU,
            // Token: 0x0400139B RID: 5019
            VIS_F14GRN,
            // Token: 0x0400139C RID: 5020
            VIS_F14ORG,
            // Token: 0x0400139D RID: 5021
            VIS_F15CBLU,
            // Token: 0x0400139E RID: 5022
            VIS_F15CGRN,
            // Token: 0x0400139F RID: 5023
            VIS_F15CORG,
            // Token: 0x040013A0 RID: 5024
            VIS_F15CRED,
            // Token: 0x040013A1 RID: 5025
            VIS_F18ABLU,
            // Token: 0x040013A2 RID: 5026
            VIS_F18AGRN,
            // Token: 0x040013A3 RID: 5027
            VIS_F18AORG,
            // Token: 0x040013A4 RID: 5028
            VIS_F18ARED,
            // Token: 0x040013A5 RID: 5029
            VIS_F5BLU,
            // Token: 0x040013A6 RID: 5030
            VIS_F5GRN,
            // Token: 0x040013A7 RID: 5031
            VIS_F5ORG,
            // Token: 0x040013A8 RID: 5032
            VIS_F5RED,
            // Token: 0x040013A9 RID: 5033
            VIS_MIG25BLU,
            // Token: 0x040013AA RID: 5034
            VIS_MIG25GRN,
            // Token: 0x040013AB RID: 5035
            VIS_MIG25ORG,
            // Token: 0x040013AC RID: 5036
            VIS_F4BLU,
            // Token: 0x040013AD RID: 5037
            VIS_F4GRN,
            // Token: 0x040013AE RID: 5038
            VIS_F4ORG,
            // Token: 0x040013AF RID: 5039
            VIS_F4RED,
            // Token: 0x040013B0 RID: 5040
            VIS_MFLAME_L = 672,
            // Token: 0x040013B1 RID: 5041
            VIS_NOTHING = 0,
            // Token: 0x040013B2 RID: 5042
            VIS_AB1TL8 = 675,
            // Token: 0x040013B3 RID: 5043
            VIS_AB7TMD1,
            // Token: 0x040013B4 RID: 5044
            VIS_THP,
            // Token: 0x040013B5 RID: 5045
            VIS_THPX,
            // Token: 0x040013B6 RID: 5046
            VIS_THB,
            // Token: 0x040013B7 RID: 5047
            VIS_AB7TL1,
            // Token: 0x040013B8 RID: 5048
            VIS_AB9TMD1,
            // Token: 0x040013B9 RID: 5049
            VIS_AB9TMD2,
            // Token: 0x040013BA RID: 5050
            VIS_AB9TMD3,
            // Token: 0x040013BB RID: 5051
            VIS_AB9TMD4,
            // Token: 0x040013BC RID: 5052
            VIS_AB9TL1,
            // Token: 0x040013BD RID: 5053
            VIS_AB9TL2,
            // Token: 0x040013BE RID: 5054
            VIS_AB9TL4,
            // Token: 0x040013BF RID: 5055
            VIS_AB9TL3,
            // Token: 0x040013C0 RID: 5056
            VIS_AB9TL6,
            // Token: 0x040013C1 RID: 5057
            VIS_AB9TL5,
            // Token: 0x040013C2 RID: 5058
            VIS_AB6UTMD1,
            // Token: 0x040013C3 RID: 5059
            VIS_AB6TMD1,
            // Token: 0x040013C4 RID: 5060
            VIS_R03PGD,
            // Token: 0x040013C5 RID: 5061
            VIS_AB6TL1,
            // Token: 0x040013C6 RID: 5062
            VIS_R06RGD,
            // Token: 0x040013C7 RID: 5063
            VIS_D1F16NOSRED = 697,
            // Token: 0x040013C8 RID: 5064
            VIS_D1F16FUSRED,
            // Token: 0x040013C9 RID: 5065
            VIS_D1F16LWRED,
            // Token: 0x040013CA RID: 5066
            VIS_DSU27RWBLU = 732,
            // Token: 0x040013CB RID: 5067
            VIS_DSU27RWGRN,
            // Token: 0x040013CC RID: 5068
            VIS_DSU27RWRED,
            // Token: 0x040013CD RID: 5069
            VIS_DSU27RWORG,
            // Token: 0x040013CE RID: 5070
            VIS_DSU27NOSORG,
            // Token: 0x040013CF RID: 5071
            VIS_DSU27NOSRED,
            // Token: 0x040013D0 RID: 5072
            VIS_DSU27NOSBLU,
            // Token: 0x040013D1 RID: 5073
            VIS_DSU27NOSGRN,
            // Token: 0x040013D2 RID: 5074
            VIS_SU27RED,
            // Token: 0x040013D3 RID: 5075
            VIS_HWYTAX1 = 674,
            // Token: 0x040013D4 RID: 5076
            VIS_MIG25RED = 741,
            // Token: 0x040013D5 RID: 5077
            VIS_F02_02,
            // Token: 0x040013D6 RID: 5078
            VIS_F02_04,
            // Token: 0x040013D7 RID: 5079
            VIS_F02_05,
            // Token: 0x040013D8 RID: 5080
            VIS_WHSE06,
            // Token: 0x040013D9 RID: 5081
            VIS_F02_01,
            // Token: 0x040013DA RID: 5082
            VIS_UGNDFACT,
            // Token: 0x040013DB RID: 5083
            VIS_FENCE1,
            // Token: 0x040013DC RID: 5084
            VIS_FENCE2,
            // Token: 0x040013DD RID: 5085
            VIS_FENCE3,
            // Token: 0x040013DE RID: 5086
            VIS_FENCE4,
            // Token: 0x040013DF RID: 5087
            VIS_PP01_02,
            // Token: 0x040013E0 RID: 5088
            VIS_PP01_03,
            // Token: 0x040013E1 RID: 5089
            VIS_F16_SHADOW,
            // Token: 0x040013E2 RID: 5090
            VIS_F111_SHADOW,
            // Token: 0x040013E3 RID: 5091
            VIS_F18_SHADOW,
            // Token: 0x040013E4 RID: 5092
            VIS_KC10_SHADOW,
            // Token: 0x040013E5 RID: 5093
            VIS_B52_SHADOW,
            // Token: 0x040013E6 RID: 5094
            VIS_C130_SHADOW,
            // Token: 0x040013E7 RID: 5095
            VIS_MIG21_SHADOW,
            // Token: 0x040013E8 RID: 5096
            VIS_MIG19_SHADOW,
            // Token: 0x040013E9 RID: 5097
            VIS_SU25_SHADOW,
            // Token: 0x040013EA RID: 5098
            VIS_F117_SHADOW,
            // Token: 0x040013EB RID: 5099
            VIS_AN2_SHADOW,
            // Token: 0x040013EC RID: 5100
            VIS_A10_SHADOW,
            // Token: 0x040013ED RID: 5101
            VIS_D1F16RWRED = 700,
            // Token: 0x040013EE RID: 5102
            VIS_D1F16RWBLU,
            // Token: 0x040013EF RID: 5103
            VIS_D1F16LWBLU,
            // Token: 0x040013F0 RID: 5104
            VIS_D1F16NOSBLU,
            // Token: 0x040013F1 RID: 5105
            VIS_D1F16FUSBLU,
            // Token: 0x040013F2 RID: 5106
            VIS_D1F16FUSGRN,
            // Token: 0x040013F3 RID: 5107
            VIS_D1F16LWGRN,
            // Token: 0x040013F4 RID: 5108
            VIS_D1F16RWGRN,
            // Token: 0x040013F5 RID: 5109
            VIS_D1F16NOSGRN,
            // Token: 0x040013F6 RID: 5110
            VIS_D1F16NOSORG,
            // Token: 0x040013F7 RID: 5111
            VIS_D1F16FUSORG,
            // Token: 0x040013F8 RID: 5112
            VIS_D1F16LWORG,
            // Token: 0x040013F9 RID: 5113
            VIS_D1F16RWORG,
            // Token: 0x040013FA RID: 5114
            VIS_AB5TMD1,
            // Token: 0x040013FB RID: 5115
            VIS_AB5TMD2,
            // Token: 0x040013FC RID: 5116
            VIS_AB5TMD3,
            // Token: 0x040013FD RID: 5117
            VIS_MIG23RED,
            // Token: 0x040013FE RID: 5118
            VIS_MIG21RED,
            // Token: 0x040013FF RID: 5119
            VIS_F14RED,
            // Token: 0x04001400 RID: 5120
            VIS_SU27BLU = 720,
            // Token: 0x04001401 RID: 5121
            VIS_SU27GRN,
            // Token: 0x04001402 RID: 5122
            VIS_SU27ORG,
            // Token: 0x04001403 RID: 5123
            VIS_AB8TMD2,
            // Token: 0x04001404 RID: 5124
            VIS_AB6UTL1 = 673,
            // Token: 0x04001405 RID: 5125
            VIS_DSU27FUSBLU = 724,
            // Token: 0x04001406 RID: 5126
            VIS_DSU27FUSGRN,
            // Token: 0x04001407 RID: 5127
            VIS_DSU27FUSRED,
            // Token: 0x04001408 RID: 5128
            VIS_DSU27FUSORG,
            // Token: 0x04001409 RID: 5129
            VIS_DSU27LWBLU,
            // Token: 0x0400140A RID: 5130
            VIS_DSU27LWGRN,
            // Token: 0x0400140B RID: 5131
            VIS_DSU27LWRED,
            // Token: 0x0400140C RID: 5132
            VIS_DSU27LWORG,
            // Token: 0x0400140D RID: 5133
            VIS_THP34RL = 1284,
            // Token: 0x0400140E RID: 5134
            VIS_IL28_SHADOW = 766,
            // Token: 0x0400140F RID: 5135
            VIS_AH64_SHADOW,
            // Token: 0x04001410 RID: 5136
            VIS_UH1N_SHADOW,
            // Token: 0x04001411 RID: 5137
            VIS_CH47_SHADOW,
            // Token: 0x04001412 RID: 5138
            VIS_500MG_SHADOW,
            // Token: 0x04001413 RID: 5139
            VIS_OH58_SHADOW,
            // Token: 0x04001414 RID: 5140
            VIS_DUGNDFACT,
            // Token: 0x04001415 RID: 5141
            VIS_TAXIOSAN,
            // Token: 0x04001416 RID: 5142
            VIS_RWYDIST1,
            // Token: 0x04001417 RID: 5143
            VIS_RWYDIST2,
            // Token: 0x04001418 RID: 5144
            VIS_RWYDIST3,
            // Token: 0x04001419 RID: 5145
            VIS_RWYDIST4,
            // Token: 0x0400141A RID: 5146
            VIS_PILEREC01,
            // Token: 0x0400141B RID: 5147
            VIS_PILEREC02,
            // Token: 0x0400141C RID: 5148
            VIS_PILEREC03,
            // Token: 0x0400141D RID: 5149
            VIS_PILEREC04,
            // Token: 0x0400141E RID: 5150
            VIS_PILESQ01,
            // Token: 0x0400141F RID: 5151
            VIS_PILESQ02,
            // Token: 0x04001420 RID: 5152
            VIS_PILESQ03,
            // Token: 0x04001421 RID: 5153
            VIS_PILESQ04,
            // Token: 0x04001422 RID: 5154
            VIS_DADMIN01,
            // Token: 0x04001423 RID: 5155
            VIS_DADMIN02,
            // Token: 0x04001424 RID: 5156
            VIS_DBARR01,
            // Token: 0x04001425 RID: 5157
            VIS_DBARR02,
            // Token: 0x04001426 RID: 5158
            VIS_DC01_09,
            // Token: 0x04001427 RID: 5159
            VIS_DC03_01,
            // Token: 0x04001428 RID: 5160
            VIS_THP36 = 1285,
            // Token: 0x04001429 RID: 5161
            VIS_00CPORTLIT,
            // Token: 0x0400142A RID: 5162
            VIS_66DPORTLIT,
            // Token: 0x0400142B RID: 5163
            VIS_CF16A,
            // Token: 0x0400142C RID: 5164
            VIS_731PORTLIT,
            // Token: 0x0400142D RID: 5165
            VIS_795PORTLIT,
            // Token: 0x0400142E RID: 5166
            VIS_79APORTLIT,
            // Token: 0x0400142F RID: 5167
            VIS_79BPORTLIT,
            // Token: 0x04001430 RID: 5168
            VIS_TU95 = 1330,
            // Token: 0x04001431 RID: 5169
            VIS_F22,
            // Token: 0x04001432 RID: 5170
            VIS_LITEPOOL,
            // Token: 0x04001433 RID: 5171
            VIS_WLOADER,
            // Token: 0x04001434 RID: 5172
            VIS_APU,
            // Token: 0x04001435 RID: 5173
            VIS_WTRAILER,
            // Token: 0x04001436 RID: 5174
            VIS_EA6SH,
            // Token: 0x04001437 RID: 5175
            VIS_TU95SH,
            // Token: 0x04001438 RID: 5176
            VIS_F22SH,
            // Token: 0x04001439 RID: 5177
            VIS_B1BSH,
            // Token: 0x0400143A RID: 5178
            VIS_SFULTRK,
            // Token: 0x0400143B RID: 5179
            VIS_SM977,
            // Token: 0x0400143C RID: 5180
            VIS_79DPORTLIT = 1293,
            // Token: 0x0400143D RID: 5181
            VIS_79EPORTLIT,
            // Token: 0x0400143E RID: 5182
            VIS_7A0PORTLIT,
            // Token: 0x0400143F RID: 5183
            VIS_7A1PORTLIT,
            // Token: 0x04001440 RID: 5184
            VIS_7A2PORTLIT,
            // Token: 0x04001441 RID: 5185
            VIS_7A5PORTLIT,
            // Token: 0x04001442 RID: 5186
            VIS_7A6PORTLIT,
            // Token: 0x04001443 RID: 5187
            VIS_TU16SH,
            // Token: 0x04001444 RID: 5188
            VIS_BIRACK,
            // Token: 0x04001445 RID: 5189
            VIS_HBIRACK,
            // Token: 0x04001446 RID: 5190
            VIS_HTRIRACK,
            // Token: 0x04001447 RID: 5191
            VIS_HONERACK,
            // Token: 0x04001448 RID: 5192
            VIS_RTRIRACK,
            // Token: 0x04001449 RID: 5193
            VIS_ONELAU3A,
            // Token: 0x0400144A RID: 5194
            VIS_BILAU3A,
            // Token: 0x0400144B RID: 5195
            VIS_TRILAU3A,
            // Token: 0x0400144C RID: 5196
            VIS_DNAVBEAC,
            // Token: 0x0400144D RID: 5197
            VIS_DTHP,
            // Token: 0x0400144E RID: 5198
            VIS_DTHALPH,
            // Token: 0x0400144F RID: 5199
            VIS_DEPOTONE,
            // Token: 0x04001450 RID: 5200
            VIS_RTOWER01,
            // Token: 0x04001451 RID: 5201
            VIS_MIG29SH,
            // Token: 0x04001452 RID: 5202
            VIS_SU27SH,
            // Token: 0x04001453 RID: 5203
            VIS_MIG23SH,
            // Token: 0x04001454 RID: 5204
            VIS_MIG25SH,
            // Token: 0x04001455 RID: 5205
            VIS_KA50SH,
            // Token: 0x04001456 RID: 5206
            VIS_PCHUTESH,
            // Token: 0x04001457 RID: 5207
            VIS_MISSILESH,
            // Token: 0x04001458 RID: 5208
            VIS_LB01W,
            // Token: 0x04001459 RID: 5209
            VIS_LB03W,
            // Token: 0x0400145A RID: 5210
            VIS_LB04W,
            // Token: 0x0400145B RID: 5211
            VIS_DSMSTK01,
            // Token: 0x0400145C RID: 5212
            VIS_NUM23RW = 1326,
            // Token: 0x0400145D RID: 5213
            VIS_NUM05LW,
            // Token: 0x0400145E RID: 5214
            VIS_EA6,
            // Token: 0x0400145F RID: 5215
            VIS_B1B
        }

        // Token: 0x020000AF RID: 175
        public enum Veh_types
        {
            // Token: 0x04001461 RID: 5217
            A10_DEF,
            // Token: 0x04001462 RID: 5218
            An2_DEF,
            // Token: 0x04001463 RID: 5219
            B1B_DEF,
            // Token: 0x04001464 RID: 5220
            B52_DEF,
            // Token: 0x04001465 RID: 5221
            C130_DEF,
            // Token: 0x04001466 RID: 5222
            EA6_DEF,
            // Token: 0x04001467 RID: 5223
            F111_DEF,
            // Token: 0x04001468 RID: 5224
            F14_DEF,
            // Token: 0x04001469 RID: 5225
            F15_DEF,
            // Token: 0x0400146A RID: 5226
            F16_DEF,
            // Token: 0x0400146B RID: 5227
            F18_DEF,
            // Token: 0x0400146C RID: 5228
            F22_DEF,
            // Token: 0x0400146D RID: 5229
            F4_DEF,
            // Token: 0x0400146E RID: 5230
            F5_DEF,
            // Token: 0x0400146F RID: 5231
            GEN_BOMBER_DEF,
            // Token: 0x04001470 RID: 5232
            GEN_FIGHTER_DEF,
            // Token: 0x04001471 RID: 5233
            GEN_TANKER_DEF,
            // Token: 0x04001472 RID: 5234
            KC10_DEF,
            // Token: 0x04001473 RID: 5235
            Mig19_DEF,
            // Token: 0x04001474 RID: 5236
            Mig21_DEF,
            // Token: 0x04001475 RID: 5237
            Mig23_DEF,
            // Token: 0x04001476 RID: 5238
            Mig25_DEF,
            // Token: 0x04001477 RID: 5239
            Mig27_DEF,
            // Token: 0x04001478 RID: 5240
            Mig29_DEF,
            // Token: 0x04001479 RID: 5241
            Mig31_DEF,
            // Token: 0x0400147A RID: 5242
            Su25_DEF,
            // Token: 0x0400147B RID: 5243
            Su27_DEF,
            // Token: 0x0400147C RID: 5244
            Tu16_DEF,
            // Token: 0x0400147D RID: 5245
            TU95_DEF
        }

        // Token: 0x020000B0 RID: 176
        public enum SimWeap_types
        {
            // Token: 0x0400147F RID: 5247
            AA10_DEF,
            // Token: 0x04001480 RID: 5248
            AA10C_DEF,
            // Token: 0x04001481 RID: 5249
            AA11_DEF,
            // Token: 0x04001482 RID: 5250
            AA2_DEF,
            // Token: 0x04001483 RID: 5251
            AA2R_DEF,
            // Token: 0x04001484 RID: 5252
            AA7_DEF,
            // Token: 0x04001485 RID: 5253
            AA7R_DEF,
            // Token: 0x04001486 RID: 5254
            AA9_DEF,
            // Token: 0x04001487 RID: 5255
            AGM45_DEF,
            // Token: 0x04001488 RID: 5256
            AGM65A_DEF,
            // Token: 0x04001489 RID: 5257
            AGM65B_DEF,
            // Token: 0x0400148A RID: 5258
            AGM65D_DEF,
            // Token: 0x0400148B RID: 5259
            AGM65G_DEF,
            // Token: 0x0400148C RID: 5260
            AGM84_DEF,
            // Token: 0x0400148D RID: 5261
            AGM88_DEF,
            // Token: 0x0400148E RID: 5262
            Aim120_DEF,
            // Token: 0x0400148F RID: 5263
            Aim54_DEF,
            // Token: 0x04001490 RID: 5264
            Aim7_DEF,
            // Token: 0x04001491 RID: 5265
            Aim9M_DEF,
            // Token: 0x04001492 RID: 5266
            Aim9P_DEF,
            // Token: 0x04001493 RID: 5267
            ALQ131_DEF,
            // Token: 0x04001494 RID: 5268
            B49_DEF,
            // Token: 0x04001495 RID: 5269
            B50_DEF,
            // Token: 0x04001496 RID: 5270
            BLU107_DEF,
            // Token: 0x04001497 RID: 5271
            BLU109_DEF,
            // Token: 0x04001498 RID: 5272
            BLU27_DEF,
            // Token: 0x04001499 RID: 5273
            Bofors_DEF,
            // Token: 0x0400149A RID: 5274
            CBU52B_DEF,
            // Token: 0x0400149B RID: 5275
            CBU58B_DEF,
            // Token: 0x0400149C RID: 5276
            CBU87_DEF,
            // Token: 0x0400149D RID: 5277
            CBU89D_DEF,
            // Token: 0x0400149E RID: 5278
            GAU12_DEF,
            // Token: 0x0400149F RID: 5279
            GBU10_DEF,
            // Token: 0x040014A0 RID: 5280
            GBU12_DEF,
            // Token: 0x040014A1 RID: 5281
            GBU15_DEF,
            // Token: 0x040014A2 RID: 5282
            GBU24_DEF,
            // Token: 0x040014A3 RID: 5283
            GBU28_DEF,
            // Token: 0x040014A4 RID: 5284
            GEN_AAM_DEF,
            // Token: 0x040014A5 RID: 5285
            GEN_AGM_DEF,
            // Token: 0x040014A6 RID: 5286
            GEN_BMB_DEF,
            // Token: 0x040014A7 RID: 5287
            GEN_BOMB_DEF,
            // Token: 0x040014A8 RID: 5288
            GEN_DEPTH_CHARGE_DEF,
            // Token: 0x040014A9 RID: 5289
            GEN_GBU_DEF,
            // Token: 0x040014AA RID: 5290
            GEN_GUN_DEF,
            // Token: 0x040014AB RID: 5291
            GEN_MISSILE_DEF,
            // Token: 0x040014AC RID: 5292
            GEN_SAM_DEF,
            // Token: 0x040014AD RID: 5293
            GEN_TK_DEF,
            // Token: 0x040014AE RID: 5294
            GEN_TORPEDO_DEF,
            // Token: 0x040014AF RID: 5295
            GUN105MM_DEF,
            // Token: 0x040014B0 RID: 5296
            GUN20mm_DEF,
            // Token: 0x040014B1 RID: 5297
            GUN30MMTailGun_DEF,
            // Token: 0x040014B2 RID: 5298
            MK20D_DEF,
            // Token: 0x040014B3 RID: 5299
            MK82_DEF,
            // Token: 0x040014B4 RID: 5300
            MK84_DEF,
            // Token: 0x040014B5 RID: 5301
            NO_WEAP_DEF,
            // Token: 0x040014B6 RID: 5302
            PGU28_DEF,
            // Token: 0x040014B7 RID: 5303
            Rocket_DEF,
            // Token: 0x040014B8 RID: 5304
            Rpod_DEF,
            // Token: 0x040014B9 RID: 5305
            SA13_DEF,
            // Token: 0x040014BA RID: 5306
            SA14_DEF,
            // Token: 0x040014BB RID: 5307
            SA15_DEF,
            // Token: 0x040014BC RID: 5308
            SA2_DEF,
            // Token: 0x040014BD RID: 5309
            SA3_DEF,
            // Token: 0x040014BE RID: 5310
            SA4_DEF,
            // Token: 0x040014BF RID: 5311
            SA5_DEF,
            // Token: 0x040014C0 RID: 5312
            SA6_DEF,
            // Token: 0x040014C1 RID: 5313
            SA7_DEF,
            // Token: 0x040014C2 RID: 5314
            SA8_DEF,
            // Token: 0x040014C3 RID: 5315
            SA9_DEF,
            // Token: 0x040014C4 RID: 5316
            TK300GAL_DEF,
            // Token: 0x040014C5 RID: 5317
            TK370GAL_DEF,
            // Token: 0x040014C6 RID: 5318
            TK600GAL_DEF
        }

        // Token: 0x020000B1 RID: 177
        public enum OldVeh_types
        {
            // Token: 0x040014C8 RID: 5320
            NO_VEHICLE,
            // Token: 0x040014C9 RID: 5321
            GEN_FIGHTER,
            // Token: 0x040014CA RID: 5322
            GEN_BOMBER,
            // Token: 0x040014CB RID: 5323
            GEN_TANK,
            // Token: 0x040014CC RID: 5324
            GEN_HELICOPTER,
            // Token: 0x040014CD RID: 5325
            GEN_TRUCK,
            // Token: 0x040014CE RID: 5326
            GEN_MISSILE,
            // Token: 0x040014CF RID: 5327
            GEN_ROCKET,
            // Token: 0x040014D0 RID: 5328
            GEN_BOMB,
            // Token: 0x040014D1 RID: 5329
            GEN_SHIP,
            // Token: 0x040014D2 RID: 5330
            GEN_SUB,
            // Token: 0x040014D3 RID: 5331
            GEN_TORPEDO,
            // Token: 0x040014D4 RID: 5332
            GEN_DEPTHCHARGE,
            // Token: 0x040014D5 RID: 5333
            GEN_FOOT,
            // Token: 0x040014D6 RID: 5334
            GUN_20_MM,
            // Token: 0x040014D7 RID: 5335
            AGM_45,
            // Token: 0x040014D8 RID: 5336
            AGM_65A,
            // Token: 0x040014D9 RID: 5337
            AGM_65B,
            // Token: 0x040014DA RID: 5338
            AGM_65D,
            // Token: 0x040014DB RID: 5339
            AGM_65G,
            // Token: 0x040014DC RID: 5340
            AGM_88,
            // Token: 0x040014DD RID: 5341
            AIM_9P,
            // Token: 0x040014DE RID: 5342
            AIM_120,
            // Token: 0x040014DF RID: 5343
            ALQ_131,
            // Token: 0x040014E0 RID: 5344
            GBU_24,
            // Token: 0x040014E1 RID: 5345
            MK_82,
            // Token: 0x040014E2 RID: 5346
            MK_84,
            // Token: 0x040014E3 RID: 5347
            SAM,
            // Token: 0x040014E4 RID: 5348
            TANK_300,
            // Token: 0x040014E5 RID: 5349
            TANK_370,
            // Token: 0x040014E6 RID: 5350
            TANK_600,
            // Token: 0x040014E7 RID: 5351
            AGMxxx,
            // Token: 0x040014E8 RID: 5352
            AIMxxx,
            // Token: 0x040014E9 RID: 5353
            ALQxxx,
            // Token: 0x040014EA RID: 5354
            GBUxxx,
            // Token: 0x040014EB RID: 5355
            GUNxxx,
            // Token: 0x040014EC RID: 5356
            Mkxxx,
            // Token: 0x040014ED RID: 5357
            TANKxxx,
            // Token: 0x040014EE RID: 5358
            F16_VEH,
            // Token: 0x040014EF RID: 5359
            TU16_VEH,
            // Token: 0x040014F0 RID: 5360
            AN2_VEH,
            // Token: 0x040014F1 RID: 5361
            KC10_VEH,
            // Token: 0x040014F2 RID: 5362
            MIG29_VEH,
            // Token: 0x040014F3 RID: 5363
            MIG19_VEH,
            // Token: 0x040014F4 RID: 5364
            SU27_VEH,
            // Token: 0x040014F5 RID: 5365
            AH64_VEH,
            // Token: 0x040014F6 RID: 5366
            AIM_7,
            // Token: 0x040014F7 RID: 5367
            GBU_10,
            // Token: 0x040014F8 RID: 5368
            GBU_15,
            // Token: 0x040014F9 RID: 5369
            GBU_28,
            // Token: 0x040014FA RID: 5370
            GBU_12,
            // Token: 0x040014FB RID: 5371
            AIM_9LM,
            // Token: 0x040014FC RID: 5372
            CAMERA,
            // Token: 0x040014FD RID: 5373
            MIG21_VEH,
            // Token: 0x040014FE RID: 5374
            F14_VEH,
            // Token: 0x040014FF RID: 5375
            F15_VEH,
            // Token: 0x04001500 RID: 5376
            F18_VEH,
            // Token: 0x04001501 RID: 5377
            F4_VEH,
            // Token: 0x04001502 RID: 5378
            F5_VEH,
            // Token: 0x04001503 RID: 5379
            SU25_VEH,
            // Token: 0x04001504 RID: 5380
            MIG23_VEH,
            // Token: 0x04001505 RID: 5381
            MIG25_VEH,
            // Token: 0x04001506 RID: 5382
            MIG27_VEH,
            // Token: 0x04001507 RID: 5383
            MIG31_VEH,
            // Token: 0x04001508 RID: 5384
            A10_VEH,
            // Token: 0x04001509 RID: 5385
            C130_VEH,
            // Token: 0x0400150A RID: 5386
            F111_VEH,
            // Token: 0x0400150B RID: 5387
            AGM_84,
            // Token: 0x0400150C RID: 5388
            AIM54_VEH,
            // Token: 0x0400150D RID: 5389
            AA7_VEH,
            // Token: 0x0400150E RID: 5390
            AA7R_VEH,
            // Token: 0x0400150F RID: 5391
            AA9_VEH,
            // Token: 0x04001510 RID: 5392
            AA10_VEH,
            // Token: 0x04001511 RID: 5393
            AA10C_VEH,
            // Token: 0x04001512 RID: 5394
            AA11_VEH,
            // Token: 0x04001513 RID: 5395
            SA2_VEH,
            // Token: 0x04001514 RID: 5396
            SA3_VEH,
            // Token: 0x04001515 RID: 5397
            SA4_VEH,
            // Token: 0x04001516 RID: 5398
            SA5_VEH,
            // Token: 0x04001517 RID: 5399
            SA6_VEH,
            // Token: 0x04001518 RID: 5400
            SA7_VEH,
            // Token: 0x04001519 RID: 5401
            SA8_VEH,
            // Token: 0x0400151A RID: 5402
            SA9_VEH,
            // Token: 0x0400151B RID: 5403
            SA13_VEH,
            // Token: 0x0400151C RID: 5404
            SA14_VEH,
            // Token: 0x0400151D RID: 5405
            SA15_VEH,
            // Token: 0x0400151E RID: 5406
            Chaparral,
            // Token: 0x0400151F RID: 5407
            Patriot,
            // Token: 0x04001520 RID: 5408
            Stinger,
            // Token: 0x04001521 RID: 5409
            Hawk,
            // Token: 0x04001522 RID: 5410
            Nike,
            // Token: 0x04001523 RID: 5411
            ADATS,
            // Token: 0x04001524 RID: 5412
            Rocket
        }

        // Token: 0x020000B2 RID: 178
        public enum Radar_types
        {
            // Token: 0x04001526 RID: 5414
            RDR_NO_RADAR,
            // Token: 0x04001527 RID: 5415
            RDR_F16,
            // Token: 0x04001528 RID: 5416
            RDR_F16_SIMPLE,
            // Token: 0x04001529 RID: 5417
            RDR_F16_360,
            // Token: 0x0400152A RID: 5418
            RDR_AMRAAM,
            // Token: 0x0400152B RID: 5419
            RDR_Mig21,
            // Token: 0x0400152C RID: 5420
            RDR_Mig23,
            // Token: 0x0400152D RID: 5421
            RDR_Mig25,
            // Token: 0x0400152E RID: 5422
            RDR_Mig31,
            // Token: 0x0400152F RID: 5423
            RDR_2S6,
            // Token: 0x04001530 RID: 5424
            RDR_A50,
            // Token: 0x04001531 RID: 5425
            RDR_ADATS,
            // Token: 0x04001532 RID: 5426
            RDR_AEGIS,
            // Token: 0x04001533 RID: 5427
            RDR_AH66,
            // Token: 0x04001534 RID: 5428
            RDR_AV8B,
            // Token: 0x04001535 RID: 5429
            RDR_BarLock,
            // Token: 0x04001536 RID: 5430
            RDR_Chapparal,
            // Token: 0x04001537 RID: 5431
            RDR_E2C,
            // Token: 0x04001538 RID: 5432
            RDR_E3,
            // Token: 0x04001539 RID: 5433
            RDR_F14,
            // Token: 0x0400153A RID: 5434
            RDR_F15,
            // Token: 0x0400153B RID: 5435
            RDR_ZUES,
            // Token: 0x0400153C RID: 5436
            RDR_F22,
            // Token: 0x0400153D RID: 5437
            RDR_F4,
            // Token: 0x0400153E RID: 5438
            RDR_F5,
            // Token: 0x0400153F RID: 5439
            RDR_Hawk = 27,
            // Token: 0x04001540 RID: 5440
            RDR_Nike,
            // Token: 0x04001541 RID: 5441
            RDR_J5,
            // Token: 0x04001542 RID: 5442
            RDR_J7,
            // Token: 0x04001543 RID: 5443
            RDR_LongTrack = 32,
            // Token: 0x04001544 RID: 5444
            RDR_LowBlowSearch,
            // Token: 0x04001545 RID: 5445
            RDR_MPQ54,
            // Token: 0x04001546 RID: 5446
            RDR_MSQ48,
            // Token: 0x04001547 RID: 5447
            RDR_MSQ50,
            // Token: 0x04001548 RID: 5448
            RDR_Patriot,
            // Token: 0x04001549 RID: 5449
            RDR_PHOENIX,
            // Token: 0x0400154A RID: 5450
            RDR_FanSong,
            // Token: 0x0400154B RID: 5451
            RDR_LowBlow,
            // Token: 0x0400154C RID: 5452
            RDR_PatHand,
            // Token: 0x0400154D RID: 5453
            RDR_SquarePair,
            // Token: 0x0400154E RID: 5454
            RDR_StraightFlush,
            // Token: 0x0400154F RID: 5455
            RDR_LandRoll,
            // Token: 0x04001550 RID: 5456
            RDR_SA9,
            // Token: 0x04001551 RID: 5457
            RDR_FlapLid,
            // Token: 0x04001552 RID: 5458
            RDR_SnapShot,
            // Token: 0x04001553 RID: 5459
            RDR_Slotback,
            // Token: 0x04001554 RID: 5460
            RDR_SpoonRest,
            // Token: 0x04001555 RID: 5461
            RDR_SU15,
            // Token: 0x04001556 RID: 5462
            RDR_TPS63,
            // Token: 0x04001557 RID: 5463
            RDR_SA15,
            // Token: 0x04001558 RID: 5464
            RDR_ANVPS2,
            // Token: 0x04001559 RID: 5465
            RDR_DrumTilt,
            // Token: 0x0400155A RID: 5466
            RDR_PopGroup,
            // Token: 0x0400155B RID: 5467
            RDR_TopDome,
            // Token: 0x0400155C RID: 5468
            RDR_ANSPS10,
            // Token: 0x0400155D RID: 5469
            RDR_ANAPQ114,
            // Token: 0x0400155E RID: 5470
            RDR_AGOnly
        }

        // Token: 0x020000B3 RID: 179
        public enum Rwr_Symbols
        {
            // Token: 0x04001560 RID: 5472
            RWRSYM_NONE,
            // Token: 0x04001561 RID: 5473
            RWRSYM_UNKNOWN,
            // Token: 0x04001562 RID: 5474
            RWRSYM_ADVANCED_INTERCEPTOR,
            // Token: 0x04001563 RID: 5475
            RWRSYM_BASIC_INTERCEPTOR,
            // Token: 0x04001564 RID: 5476
            RWRSYM_ACTIVE_MISSILE,
            // Token: 0x04001565 RID: 5477
            RWRSYM_HAWK,
            // Token: 0x04001566 RID: 5478
            RWRSYM_PATRIOT,
            // Token: 0x04001567 RID: 5479
            RWRSYM_SA2,
            // Token: 0x04001568 RID: 5480
            RWRSYM_SA3,
            // Token: 0x04001569 RID: 5481
            RWRSYM_SA4,
            // Token: 0x0400156A RID: 5482
            RWRSYM_SA5,
            // Token: 0x0400156B RID: 5483
            RWRSYM_SA6,
            // Token: 0x0400156C RID: 5484
            RWRSYM_SA8,
            // Token: 0x0400156D RID: 5485
            RWRSYM_SA9,
            // Token: 0x0400156E RID: 5486
            RWRSYM_SA10,
            // Token: 0x0400156F RID: 5487
            RWRSYM_SA13,
            // Token: 0x04001570 RID: 5488
            RWRSYM_AAA,
            // Token: 0x04001571 RID: 5489
            RWRSYM_SEARCH,
            // Token: 0x04001572 RID: 5490
            RWRSYM_NAVAL,
            // Token: 0x04001573 RID: 5491
            RWRSYM_CHAPARAL,
            // Token: 0x04001574 RID: 5492
            RWRSYM_SA15,
            // Token: 0x04001575 RID: 5493
            RWRSYM_NIKE
        }

        // Token: 0x020000B4 RID: 180
        public enum RadarModes
        {
            // Token: 0x04001577 RID: 5495
            FEC_RADAR_OFF,
            // Token: 0x04001578 RID: 5496
            FEC_RADAR_SEARCH_100,
            // Token: 0x04001579 RID: 5497
            FEC_RADAR_SEARCH_1,
            // Token: 0x0400157A RID: 5498
            FEC_RADAR_SEARCH_2,
            // Token: 0x0400157B RID: 5499
            FEC_RADAR_SEARCH_3,
            // Token: 0x0400157C RID: 5500
            FEC_RADAR_AQUIRE,
            // Token: 0x0400157D RID: 5501
            FEC_RADAR_GUIDE,
            // Token: 0x0400157E RID: 5502
            FEC_RADAR_CHANGEMODE
        }

        // Token: 0x020000B5 RID: 181
        public enum CountryListEnum
        {
            // Token: 0x04001580 RID: 5504
            COUN_NONE,
            // Token: 0x04001581 RID: 5505
            COUN_US,
            // Token: 0x04001582 RID: 5506
            COUN_SOUTH_KOREA,
            // Token: 0x04001583 RID: 5507
            COUN_JAPAN,
            // Token: 0x04001584 RID: 5508
            COUN_RUSSIA,
            // Token: 0x04001585 RID: 5509
            COUN_CHINA,
            // Token: 0x04001586 RID: 5510
            COUN_NORTH_KOREA,
            // Token: 0x04001587 RID: 5511
            COUN_GORN,
            // Token: 0x04001588 RID: 5512
            NUM_COUNS
        }

        // Token: 0x020000B6 RID: 182
        public enum DamageDataType
        {
            // Token: 0x0400158A RID: 5514
            NoDamage,
            // Token: 0x0400158B RID: 5515
            PenetrationDam,
            // Token: 0x0400158C RID: 5516
            HighExplosiveDam,
            // Token: 0x0400158D RID: 5517
            HeaveDam,
            // Token: 0x0400158E RID: 5518
            IncendairyDam,
            // Token: 0x0400158F RID: 5519
            ProximityDam,
            // Token: 0x04001590 RID: 5520
            KineticDam,
            // Token: 0x04001591 RID: 5521
            HydrostaticDam,
            // Token: 0x04001592 RID: 5522
            ChemicalDam,
            // Token: 0x04001593 RID: 5523
            NuclearDam,
            // Token: 0x04001594 RID: 5524
            OtherDam,
            // Token: 0x04001595 RID: 5525
            DAMAGE_TYPES
        }

        // Token: 0x020000B7 RID: 183
        public enum MoveType
        {
            // Token: 0x04001597 RID: 5527
            NoMove,
            // Token: 0x04001598 RID: 5528
            Foot,
            // Token: 0x04001599 RID: 5529
            Wheeled,
            // Token: 0x0400159A RID: 5530
            Tracked,
            // Token: 0x0400159B RID: 5531
            LowAir,
            // Token: 0x0400159C RID: 5532
            Air,
            // Token: 0x0400159D RID: 5533
            Naval,
            // Token: 0x0400159E RID: 5534
            Rail,
            // Token: 0x0400159F RID: 5535
            MOVEMENT_TYPES
        }

        // Token: 0x020000B8 RID: 184
        public enum ObjFlags
        {
            // Token: 0x040015A1 RID: 5537
            O_FRONTLINE = 1,
            // Token: 0x040015A2 RID: 5538
            O_SECONDLINE,
            // Token: 0x040015A3 RID: 5539
            O_THIRDLINE = 4,
            // Token: 0x040015A4 RID: 5540
            O_B3 = 8,
            // Token: 0x040015A5 RID: 5541
            O_JAMMED = 16,
            // Token: 0x040015A6 RID: 5542
            O_BEACH = 32,
            // Token: 0x040015A7 RID: 5543
            O_B1 = 64,
            // Token: 0x040015A8 RID: 5544
            O_B2 = 128,
            // Token: 0x040015A9 RID: 5545
            O_MANUAL_SET = 256,
            // Token: 0x040015AA RID: 5546
            O_MOUNTAIN_SITE = 512,
            // Token: 0x040015AB RID: 5547
            O_SAM_SITE = 1024,
            // Token: 0x040015AC RID: 5548
            O_ARTILLERY_SITE = 2048,
            // Token: 0x040015AD RID: 5549
            O_AMBUSHCAP_SITE = 4096,
            // Token: 0x040015AE RID: 5550
            O_BORDER_SITE = 8192,
            // Token: 0x040015AF RID: 5551
            O_COMMANDO_SITE = 16384,
            // Token: 0x040015B0 RID: 5552
            O_FLAT_SITE = 32768,
            // Token: 0x040015B1 RID: 5553
            O_RADAR_SITE = 65536,
            // Token: 0x040015B2 RID: 5554
            O_NEED_REPAIR = 131072,
            // Token: 0x040015B3 RID: 5555
            O_ENGINEERS_ASSIGNED = 262144,
            // Token: 0x040015B4 RID: 5556
            O_EMPTY2 = 524288,
            // Token: 0x040015B5 RID: 5557
            O_ABANDONED = 1048576,
            // Token: 0x040015B6 RID: 5558
            O_HAS_NCTR = 2097152,
            // Token: 0x040015B7 RID: 5559
            O_IS_GCI = 4194304
        }

        // Token: 0x020000B9 RID: 185
        public enum PointFlags
        {
            // Token: 0x040015B9 RID: 5561
            PT_FIRST = 1,
            // Token: 0x040015BA RID: 5562
            PT_LAST,
            // Token: 0x040015BB RID: 5563
            PT_OCCUPIED = 4
        }

        // Token: 0x020000BA RID: 186
        public enum FeatureFlags
        {
            // Token: 0x040015BD RID: 5565
            FEAT_EREPAIR = 1,
            // Token: 0x040015BE RID: 5566
            FEAT_VIRTUAL,
            // Token: 0x040015BF RID: 5567
            FEAT_HAS_LIGHT_SWITCH = 4,
            // Token: 0x040015C0 RID: 5568
            FEAT_HAS_SMOKE_STACK = 8,
            // Token: 0x040015C1 RID: 5569
            FEAT_NO_HITEVAL = 16,
            // Token: 0x040015C2 RID: 5570
            FEAT_POINT_TRACKABLE = 32,
            // Token: 0x040015C3 RID: 5571
            FEAT_TACAN = 64,
            // Token: 0x040015C4 RID: 5572
            FEAT_FLAT_CONTAINER = 256,
            // Token: 0x040015C5 RID: 5573
            FEAT_ELEV_CONTAINER = 512,
            // Token: 0x040015C6 RID: 5574
            FEAT_CAN_EXPLODE = 1024,
            // Token: 0x040015C7 RID: 5575
            FEAT_CAN_BURN = 2048,
            // Token: 0x040015C8 RID: 5576
            FEAT_CAN_SMOKE = 4096,
            // Token: 0x040015C9 RID: 5577
            FEAT_CAN_COLAPSE = 8192,
            // Token: 0x040015CA RID: 5578
            FEAT_CONTAINER_TOP = 16384,
            // Token: 0x040015CB RID: 5579
            FEAT_NEXT_IS_TOP = 32768
        }

        // Token: 0x020000BB RID: 187
        public enum FeatureEntryflags
        {
            // Token: 0x040015CD RID: 5581
            FEAT_PREV_CRIT = 1,
            // Token: 0x040015CE RID: 5582
            FEAT_NEXT_CRIT,
            // Token: 0x040015CF RID: 5583
            FEAT_PREV_NORM = 4,
            // Token: 0x040015D0 RID: 5584
            FEAT_NEXT_NORM = 8
        }

        // Token: 0x020000BC RID: 188
        public enum UnitBaseFlagTrans
        {
            // Token: 0x040015D2 RID: 5586
            CBC_EMITTING = 1,
            // Token: 0x040015D3 RID: 5587
            CBC_JAMMED = 4
        }

        // Token: 0x020000BD RID: 189
        public enum UnitBaseFlagLocal
        {
            // Token: 0x040015D5 RID: 5589
            CBC_CHECKED = 1,
            // Token: 0x040015D6 RID: 5590
            CBC_AWAKE,
            // Token: 0x040015D7 RID: 5591
            CBC_IN_PACKAGE = 4,
            // Token: 0x040015D8 RID: 5592
            CBC_HAS_DELTA = 8,
            // Token: 0x040015D9 RID: 5593
            CBC_IN_SIM_LIST = 16,
            // Token: 0x040015DA RID: 5594
            CBC_INTEREST = 32,
            // Token: 0x040015DB RID: 5595
            CBC_RESERVED_ONLY = 64,
            // Token: 0x040015DC RID: 5596
            CBC_AGGREGATE = 128,
            // Token: 0x040015DD RID: 5597
            CBC_HAS_TACAN = 256
        }

        // Token: 0x020000BE RID: 190
        public enum UnitFlags
        {
            // Token: 0x040015DF RID: 5599
            U_DEAD = 1,
            // Token: 0x040015E0 RID: 5600
            U_B3,
            // Token: 0x040015E1 RID: 5601
            U_ASSIGNED = 4,
            // Token: 0x040015E2 RID: 5602
            U_ORDERED = 8,
            // Token: 0x040015E3 RID: 5603
            U_NO_PLANNING = 16,
            // Token: 0x040015E4 RID: 5604
            U_PARENT = 32,
            // Token: 0x040015E5 RID: 5605
            U_ENGAGED = 64,
            // Token: 0x040015E6 RID: 5606
            U_HUMAN_CONTROLLED = 128,
            // Token: 0x040015E7 RID: 5607
            U_SCRIPTED = 256,
            // Token: 0x040015E8 RID: 5608
            U_COMMANDO = 512,
            // Token: 0x040015E9 RID: 5609
            U_MOVING = 1024,
            // Token: 0x040015EA RID: 5610
            U_REFUSED = 2048,
            // Token: 0x040015EB RID: 5611
            U_HASECM = 4096,
            // Token: 0x040015EC RID: 5612
            U_CARGO = 8192,
            // Token: 0x040015ED RID: 5613
            U_COMBAT = 16384,
            // Token: 0x040015EE RID: 5614
            U_BROKEN = 32768,
            // Token: 0x040015EF RID: 5615
            U_LOSSES = 65536,
            // Token: 0x040015F0 RID: 5616
            U_INACTIVE = 131072,
            // Token: 0x040015F1 RID: 5617
            U_FRAGMENTED = 262144,
            // Token: 0x040015F2 RID: 5618
            U_UNLOAD_CFT = 524288,
            // Token: 0x040015F3 RID: 5619
            U_TARGETED = 1048576,
            // Token: 0x040015F4 RID: 5620
            U_RETREATING = 2097152,
            // Token: 0x040015F5 RID: 5621
            U_DETACHED = 4194304,
            // Token: 0x040015F6 RID: 5622
            U_SUPPORTED = 8388608,
            // Token: 0x040015F7 RID: 5623
            U_TEMP_DEST = 16777216,
            // Token: 0x040015F8 RID: 5624
            U_FINAL = 1048576,
            // Token: 0x040015F9 RID: 5625
            U_HAS_PILOTS = 2097152,
            // Token: 0x040015FA RID: 5626
            U_DIVERTED = 4194304,
            // Token: 0x040015FB RID: 5627
            U_FIRED = 8388608,
            // Token: 0x040015FC RID: 5628
            U_LOCKED = 16777216,
            // Token: 0x040015FD RID: 5629
            U_IA_KILL = 33554432,
            // Token: 0x040015FE RID: 5630
            U_NO_ABORT = 67108864
        }

        // Token: 0x020000BF RID: 191
        public enum Vehflags
        {
            // Token: 0x04001600 RID: 5632
            VEH_AIRFORCE = 1,
            // Token: 0x04001601 RID: 5633
            VEH_NAVY,
            // Token: 0x04001602 RID: 5634
            VEH_MARINES = 4,
            // Token: 0x04001603 RID: 5635
            VEH_ARMY = 8,
            // Token: 0x04001604 RID: 5636
            VEH_ALLWEATHER = 16,
            // Token: 0x04001605 RID: 5637
            VEH_STEALTH = 32,
            // Token: 0x04001606 RID: 5638
            VEH_NIGHT = 64,
            // Token: 0x04001607 RID: 5639
            VEH_VTOL = 128,
            // Token: 0x04001608 RID: 5640
            VEH_FLAT_CONTAINER = 256,
            // Token: 0x04001609 RID: 5641
            VEH_ELEV_CONTAINER = 512,
            // Token: 0x0400160A RID: 5642
            VEH_CAN_EXPLODE = 1024,
            // Token: 0x0400160B RID: 5643
            VEH_CAN_BURN = 2048,
            // Token: 0x0400160C RID: 5644
            VEH_CAN_SMOKE = 4096,
            // Token: 0x0400160D RID: 5645
            VEH_CAN_COLAPSE = 8192,
            // Token: 0x0400160E RID: 5646
            VEH_HAS_CREW = 16384,
            // Token: 0x0400160F RID: 5647
            VEH_IS_TOWED = 32768,
            // Token: 0x04001610 RID: 5648
            VEH_HAS_JAMMER = 65536,
            // Token: 0x04001611 RID: 5649
            VEH_IS_AIR_DEFENSE = 131072,
            // Token: 0x04001612 RID: 5650
            VEH_HAS_NCTR = 262144,
            // Token: 0x04001613 RID: 5651
            VEH_HAS_EXACT_RWR = 524288,
            // Token: 0x04001614 RID: 5652
            VEH_USES_UNIT_RADAR = 1048576,
            // Token: 0x04001615 RID: 5653
            VEH_SERVICE_MASK = 15,
            // Token: 0x04001616 RID: 5654
            VEH_CAPIBILITY_MASK = 240
        }

        // Token: 0x020000C0 RID: 192
        public enum ElmentFlags
        {
            // Token: 0x04001618 RID: 5656
            BATT_ELMT_FLAG_IS_FCR = 1,
            // Token: 0x04001619 RID: 5657
            BATT_ELMT_FLAG_IS_TAR,
            // Token: 0x0400161A RID: 5658
            BATT_ELMT_FLAG_IS_EWR = 4,
            // Token: 0x0400161B RID: 5659
            BATT_ELMT_FLAG_IS_HFR = 8,
            // Token: 0x0400161C RID: 5660
            BATT_ELMT_FLAG_IS_ECS = 16,
            // Token: 0x0400161D RID: 5661
            BATT_ELMT_FLAG_IS_NCS = 32,
            // Token: 0x0400161E RID: 5662
            BATT_ELMT_FLAG_IS_EPP = 64,
            // Token: 0x0400161F RID: 5663
            BATT_ELMT_FLAG_IS_RES_01 = 128,
            // Token: 0x04001620 RID: 5664
            BATT_ELMT_FLAG_IS_RDR_DECOY = 256
        }

        // Token: 0x020000C1 RID: 193
        public enum RelType
        {
            // Token: 0x04001622 RID: 5666
            NoRelations,
            // Token: 0x04001623 RID: 5667
            Allied,
            // Token: 0x04001624 RID: 5668
            Friendly,
            // Token: 0x04001625 RID: 5669
            Neutral,
            // Token: 0x04001626 RID: 5670
            Hostile,
            // Token: 0x04001627 RID: 5671
            War
        }

        // Token: 0x020000C2 RID: 194
        public enum WptAction
        {
            // Token: 0x04001629 RID: 5673
            WP_NOTHING,
            // Token: 0x0400162A RID: 5674
            WP_TAKEOFF,
            // Token: 0x0400162B RID: 5675
            WP_PUSH,
            // Token: 0x0400162C RID: 5676
            WP_SPLIT,
            // Token: 0x0400162D RID: 5677
            WP_REFUEL,
            // Token: 0x0400162E RID: 5678
            WP_REARM,
            // Token: 0x0400162F RID: 5679
            WP_PICKUP,
            // Token: 0x04001630 RID: 5680
            WP_LAND,
            // Token: 0x04001631 RID: 5681
            WP_TIMING,
            // Token: 0x04001632 RID: 5682
            WP_CASCP,
            // Token: 0x04001633 RID: 5683
            WP_ESCORT,
            // Token: 0x04001634 RID: 5684
            WP_CA,
            // Token: 0x04001635 RID: 5685
            WP_CAP,
            // Token: 0x04001636 RID: 5686
            WP_INTERCEPT,
            // Token: 0x04001637 RID: 5687
            WP_GNDSTRIKE,
            // Token: 0x04001638 RID: 5688
            WP_NAVSTRIKE,
            // Token: 0x04001639 RID: 5689
            WP_SAD,
            // Token: 0x0400163A RID: 5690
            WP_STRIKE,
            // Token: 0x0400163B RID: 5691
            WP_BOMB,
            // Token: 0x0400163C RID: 5692
            WP_SEAD,
            // Token: 0x0400163D RID: 5693
            WP_ELINT,
            // Token: 0x0400163E RID: 5694
            WP_RECON,
            // Token: 0x0400163F RID: 5695
            WP_RESCUE,
            // Token: 0x04001640 RID: 5696
            WP_ASW,
            // Token: 0x04001641 RID: 5697
            WP_TANKER,
            // Token: 0x04001642 RID: 5698
            WP_AIRDROP,
            // Token: 0x04001643 RID: 5699
            WP_JAM
        }

        // Token: 0x020000C3 RID: 195
        public enum WptFlags
        {
            // Token: 0x04001645 RID: 5701
            WPF_TARGET = 1,
            // Token: 0x04001646 RID: 5702
            WPF_ASSEMBLE,
            // Token: 0x04001647 RID: 5703
            WPF_BREAKPOINT = 4,
            // Token: 0x04001648 RID: 5704
            WPF_IP = 8,
            // Token: 0x04001649 RID: 5705
            WPF_TURNPOINT = 16,
            // Token: 0x0400164A RID: 5706
            WPF_CP = 32,
            // Token: 0x0400164B RID: 5707
            WPF_REPEAT = 64,
            // Token: 0x0400164C RID: 5708
            WPF_TAKEOFF = 128,
            // Token: 0x0400164D RID: 5709
            WPF_LAND = 256,
            // Token: 0x0400164E RID: 5710
            WPF_DIVERT = 512,
            // Token: 0x0400164F RID: 5711
            WPF_ALTERNATE = 1024,
            // Token: 0x04001650 RID: 5712
            WPF_HOLDCURRENT = 2048,
            // Token: 0x04001651 RID: 5713
            WPF_REPEAT_CONTINUOUS = 4096,
            // Token: 0x04001652 RID: 5714
            WPF_IN_PACKAGE = 8192,
            // Token: 0x04001653 RID: 5715
            WPF_TIME_LOCKED = 16384,
            // Token: 0x04001654 RID: 5716
            WPF_SPEED_LOCKED = 32768,
            // Token: 0x04001655 RID: 5717
            WPF_REFUEL_INFORMATION = 65536,
            // Token: 0x04001656 RID: 5718
            WPF_REQHELP = 131072,
            // Token: 0x04001657 RID: 5719
            WPF_FUEL_TIMING = 262144,
            // Token: 0x04001658 RID: 5720
            WPF_TIMING = 524288,
            // Token: 0x04001659 RID: 5721
            WPF_CRITICAL_MASK = 2047
        }

        // Token: 0x020000C4 RID: 196
        public enum Have
        {
            // Token: 0x0400165B RID: 5723
            WP_HAVE_DEPTIME = 1,
            // Token: 0x0400165C RID: 5724
            WP_HAVE_TARGET
        }

        // Token: 0x020000C5 RID: 197
        public enum GOrder
        {
            // Token: 0x0400165E RID: 5726
            GORD_RESERVE,
            // Token: 0x0400165F RID: 5727
            GORD_CAPTURE,
            // Token: 0x04001660 RID: 5728
            GORD_SECURE,
            // Token: 0x04001661 RID: 5729
            GORD_ASSAULT,
            // Token: 0x04001662 RID: 5730
            GORD_AIRBORNE,
            // Token: 0x04001663 RID: 5731
            GORD_COMMANDO,
            // Token: 0x04001664 RID: 5732
            GORD_DEFEND,
            // Token: 0x04001665 RID: 5733
            GORD_SUPPORT,
            // Token: 0x04001666 RID: 5734
            GORD_REPAIR,
            // Token: 0x04001667 RID: 5735
            GORD_AIRDEFENSE,
            // Token: 0x04001668 RID: 5736
            GORD_RECON,
            // Token: 0x04001669 RID: 5737
            GORD_RADAR,
            // Token: 0x0400166A RID: 5738
            GORD_LAST
        }

        // Token: 0x020000C6 RID: 198
        public enum GRole
        {
            // Token: 0x0400166C RID: 5740
            GRO_RESERVE,
            // Token: 0x0400166D RID: 5741
            GRO_ATTACK,
            // Token: 0x0400166E RID: 5742
            GRO_ASSAULT,
            // Token: 0x0400166F RID: 5743
            GRO_AIRBORNE,
            // Token: 0x04001670 RID: 5744
            GRO_DEFENSE,
            // Token: 0x04001671 RID: 5745
            GRO_AIRDEFENSE,
            // Token: 0x04001672 RID: 5746
            GRO_FIRESUPPORT,
            // Token: 0x04001673 RID: 5747
            GRO_ENGINEER,
            // Token: 0x04001674 RID: 5748
            GRO_RECON,
            // Token: 0x04001675 RID: 5749
            GRO_LAST
        }

        // Token: 0x020000C7 RID: 199
        public enum MissionRollEnum
        {
            // Token: 0x04001677 RID: 5751
            ARO_UNUSED,
            // Token: 0x04001678 RID: 5752
            ARO_CA,
            // Token: 0x04001679 RID: 5753
            ARO_TACTRANS,
            // Token: 0x0400167A RID: 5754
            ARO_S,
            // Token: 0x0400167B RID: 5755
            ARO_GA,
            // Token: 0x0400167C RID: 5756
            ARO_SB,
            // Token: 0x0400167D RID: 5757
            ARO_ECM,
            // Token: 0x0400167E RID: 5758
            ARO_SEAD,
            // Token: 0x0400167F RID: 5759
            ARO_ASW,
            // Token: 0x04001680 RID: 5760
            ARO_ASHIP,
            // Token: 0x04001681 RID: 5761
            ARO_REC,
            // Token: 0x04001682 RID: 5762
            ARO_TRANS,
            // Token: 0x04001683 RID: 5763
            ARO_AWACS,
            // Token: 0x04001684 RID: 5764
            ARO_JSTAR,
            // Token: 0x04001685 RID: 5765
            ARO_ELINT = 13,
            // Token: 0x04001686 RID: 5766
            ARO_TANK,
            // Token: 0x04001687 RID: 5767
            ARO_FAC,
            // Token: 0x04001688 RID: 5768
            ARO_OTHER
        }

        // Token: 0x020000C8 RID: 200
        public enum AirTacticTypeEnum
        {
            // Token: 0x0400168A RID: 5770
            TAT_DEFENSIVE = 1,
            // Token: 0x0400168B RID: 5771
            TAT_OFFENSIVE,
            // Token: 0x0400168C RID: 5772
            TAT_INTERDICT,
            // Token: 0x0400168D RID: 5773
            TAT_ATTRITION,
            // Token: 0x0400168E RID: 5774
            TAT_CAS
        }

        // Token: 0x020000C9 RID: 201
        public enum MissionTypeEnum
        {
            // Token: 0x04001690 RID: 5776
            AMIS_NONE,
            // Token: 0x04001691 RID: 5777
            AMIS_BARCAP1,
            // Token: 0x04001692 RID: 5778
            AMIS_BARCAP2,
            // Token: 0x04001693 RID: 5779
            AMIS_HAVCAP,
            // Token: 0x04001694 RID: 5780
            AMIS_TARCAP,
            // Token: 0x04001695 RID: 5781
            AMIS_RESCORT,
            // Token: 0x04001696 RID: 5782
            AMIS_AMBUSHCAP,
            // Token: 0x04001697 RID: 5783
            AMIS_SWEEP,
            // Token: 0x04001698 RID: 5784
            AMIS_ALERT,
            // Token: 0x04001699 RID: 5785
            AMIS_INTERCEPT,
            // Token: 0x0400169A RID: 5786
            AMIS_ESCORT,
            // Token: 0x0400169B RID: 5787
            AMIS_SEADSTRIKE,
            // Token: 0x0400169C RID: 5788
            AMIS_SEADESCORT,
            // Token: 0x0400169D RID: 5789
            AMIS_OCASTRIKE,
            // Token: 0x0400169E RID: 5790
            AMIS_INTSTRIKE,
            // Token: 0x0400169F RID: 5791
            AMIS_STRIKE,
            // Token: 0x040016A0 RID: 5792
            AMIS_DEEPSTRIKE,
            // Token: 0x040016A1 RID: 5793
            AMIS_STSTRIKE,
            // Token: 0x040016A2 RID: 5794
            AMIS_STRATBOMB,
            // Token: 0x040016A3 RID: 5795
            AMIS_FAC,
            // Token: 0x040016A4 RID: 5796
            AMIS_ONCALLCAS,
            // Token: 0x040016A5 RID: 5797
            AMIS_PRPLANCAS,
            // Token: 0x040016A6 RID: 5798
            AMIS_CAS,
            // Token: 0x040016A7 RID: 5799
            AMIS_SAD,
            // Token: 0x040016A8 RID: 5800
            AMIS_INT,
            // Token: 0x040016A9 RID: 5801
            AMIS_BAI,
            // Token: 0x040016AA RID: 5802
            AMIS_AWACS,
            // Token: 0x040016AB RID: 5803
            AMIS_JSTAR,
            // Token: 0x040016AC RID: 5804
            AMIS_ELINT = 27,
            // Token: 0x040016AD RID: 5805
            AMIS_TANKER,
            // Token: 0x040016AE RID: 5806
            AMIS_RECON,
            // Token: 0x040016AF RID: 5807
            AMIS_BDA,
            // Token: 0x040016B0 RID: 5808
            AMIS_ECM,
            // Token: 0x040016B1 RID: 5809
            AMIS_AIRCAV,
            // Token: 0x040016B2 RID: 5810
            AMIS_AIRLIFT,
            // Token: 0x040016B3 RID: 5811
            AMIS_SAR,
            // Token: 0x040016B4 RID: 5812
            AMIS_ASW,
            // Token: 0x040016B5 RID: 5813
            AMIS_ASHIP,
            // Token: 0x040016B6 RID: 5814
            AMIS_PATROL,
            // Token: 0x040016B7 RID: 5815
            AMIS_RECONPATROL,
            // Token: 0x040016B8 RID: 5816
            AMIS_ABORT,
            // Token: 0x040016B9 RID: 5817
            AMIS_TRAINING,
            // Token: 0x040016BA RID: 5818
            AMIS_RELOCATE,
            // Token: 0x040016BB RID: 5819
            AMIS_DUMMY_02,
            // Token: 0x040016BC RID: 5820
            AMIS_DUMMY_03,
            // Token: 0x040016BD RID: 5821
            AMIS_DUMMY_04,
            // Token: 0x040016BE RID: 5822
            AMIS_DUMMY_05,
            // Token: 0x040016BF RID: 5823
            AMIS_DUMMY_06,
            // Token: 0x040016C0 RID: 5824
            AMIS_DUMMY_07,
            // Token: 0x040016C1 RID: 5825
            AMIS_DUMMY_08,
            // Token: 0x040016C2 RID: 5826
            AMIS_DUMMY_09,
            // Token: 0x040016C3 RID: 5827
            AMIS_OTHER,
            // Token: 0x040016C4 RID: 5828
            AMIS_OTHER_LEGACY = 41
        }

        // Token: 0x020000CA RID: 202
        public enum Mission_Flag
        {
            // Token: 0x040016C6 RID: 5830
            AMIS_ADDAWACS = 1,
            // Token: 0x040016C7 RID: 5831
            AMIS_ADDJSTAR,
            // Token: 0x040016C8 RID: 5832
            AMIS_ADDECM = 4,
            // Token: 0x040016C9 RID: 5833
            AMIS_ADDBDA = 8,
            // Token: 0x040016CA RID: 5834
            AMIS_ADDESCORT = 16,
            // Token: 0x040016CB RID: 5835
            AMIS_ADDSEAD = 32,
            // Token: 0x040016CC RID: 5836
            AMIS_ADDBARCAP = 64,
            // Token: 0x040016CD RID: 5837
            AMIS_ADDSWEEP = 128,
            // Token: 0x040016CE RID: 5838
            AMIS_ADDOCASTRIKE = 256,
            // Token: 0x040016CF RID: 5839
            AMIS_ADDTANKER = 512,
            // Token: 0x040016D0 RID: 5840
            AMIS_NEEDTANKER = 1024,
            // Token: 0x040016D1 RID: 5841
            AMIS_ADDFAC = 2048,
            // Token: 0x040016D2 RID: 5842
            AMIS_ADDINTERCEPT = 4096,
            // Token: 0x040016D3 RID: 5843
            AMIS_NOTHREAT = 8192,
            // Token: 0x040016D4 RID: 5844
            AMIS_AVOIDTHREAT = 16384,
            // Token: 0x040016D5 RID: 5845
            AMIS_HIGHTHREAT = 32768,
            // Token: 0x040016D6 RID: 5846
            AMIS_ADJUST_ALT = 65536,
            // Token: 0x040016D7 RID: 5847
            AMIS_MATCHSPEED = 131072,
            // Token: 0x040016D8 RID: 5848
            AMIS_TARGET_ONLY = 262144,
            // Token: 0x040016D9 RID: 5849
            AMIS_NO_BREAKPT = 524288,
            // Token: 0x040016DA RID: 5850
            AMIS_DONT_COORD = 1048576,
            // Token: 0x040016DB RID: 5851
            AMIS_DONT_USE_HELIS = 2097152,
            // Token: 0x040016DC RID: 5852
            AMIS_DONT_USE_AC = 4194304,
            // Token: 0x040016DD RID: 5853
            AMIS_LOITER_PATTERN_8 = 8388608,
            // Token: 0x040016DE RID: 5854
            AMIS_FUDGE_RANGE = 16777216,
            // Token: 0x040016DF RID: 5855
            AMIS_EXPECT_DIVERT = 33554432,
            // Token: 0x040016E0 RID: 5856
            AMIS_ASSIGNED_TAR = 67108864,
            // Token: 0x040016E1 RID: 5857
            AMIS_NO_DIST_BONUS = 134217728,
            // Token: 0x040016E2 RID: 5858
            AMIS_NO_TARGETABORT = 268435456,
            // Token: 0x040016E3 RID: 5859
            AMIS_FLYALWAYS = 536870912,
            // Token: 0x040016E4 RID: 5860
            AMIS_HELP_REQUEST = 1073741824
        }

        // Token: 0x020000CB RID: 203
        public enum SpecialCap
        {
            // Token: 0x040016E6 RID: 5862
            UNIT_FLAG_AIRFORCE = 1,
            // Token: 0x040016E7 RID: 5863
            UNIT_FLAG_NAVY,
            // Token: 0x040016E8 RID: 5864
            UNIT_FLAG_MARINES = 4,
            // Token: 0x040016E9 RID: 5865
            UNIT_FLAG_ARMY = 8,
            // Token: 0x040016EA RID: 5866
            UNIT_FLAG_ALLWEATHER = 16,
            // Token: 0x040016EB RID: 5867
            UNIT_FLAG_STEALTH = 32,
            // Token: 0x040016EC RID: 5868
            UNIT_FLAG_NIGHT = 64,
            // Token: 0x040016ED RID: 5869
            UNIT_FLAG_VTOL = 128
        }

        // Token: 0x020000CC RID: 204
        public enum GuidanceFlags
        {
            // Token: 0x040016EF RID: 5871
            WEAP_VISUALONLY,
            // Token: 0x040016F0 RID: 5872
            WEAP_ANTIRADATION,
            // Token: 0x040016F1 RID: 5873
            WEAP_HEATSEEKER,
            // Token: 0x040016F2 RID: 5874
            WEAP_RADAR = 4,
            // Token: 0x040016F3 RID: 5875
            WEAP_LASER = 8,
            // Token: 0x040016F4 RID: 5876
            WEAP_TV = 16,
            // Token: 0x040016F5 RID: 5877
            WEAP_REAR_ASPECT = 32,
            // Token: 0x040016F6 RID: 5878
            WEAP_FRONT_ASPECT = 64,
            // Token: 0x040016F7 RID: 5879
            WEAP_DUMB_ONLY = 4096,
            // Token: 0x040016F8 RID: 5880
            WEAP_NOGPS_ONLY = 8192,
            // Token: 0x040016F9 RID: 5881
            WEAP_GUIDED_MASK = 31
        }

        // Token: 0x020000CD RID: 205
        public enum WeaponType
        {
            // Token: 0x040016FB RID: 5883
            wtGuns,
            // Token: 0x040016FC RID: 5884
            wtAim9,
            // Token: 0x040016FD RID: 5885
            wtAim120,
            // Token: 0x040016FE RID: 5886
            wtAgm88,
            // Token: 0x040016FF RID: 5887
            wtAgm65,
            // Token: 0x04001700 RID: 5888
            wtMk82,
            // Token: 0x04001701 RID: 5889
            wtMk84,
            // Token: 0x04001702 RID: 5890
            wtGBU,
            // Token: 0x04001703 RID: 5891
            wtSAM,
            // Token: 0x04001704 RID: 5892
            wtLAU,
            // Token: 0x04001705 RID: 5893
            wtFixed,
            // Token: 0x04001706 RID: 5894
            wtGPS,
            // Token: 0x04001707 RID: 5895
            wtWCMD,
            // Token: 0x04001708 RID: 5896
            wtGBU15,
            // Token: 0x04001709 RID: 5897
            wtLGM,
            // Token: 0x0400170A RID: 5898
            wtAgm84,
            // Token: 0x0400170B RID: 5899
            wtLJDAM,
            // Token: 0x0400170C RID: 5900
            wtNone
        }

        // Token: 0x020000CE RID: 206
        public enum WeaponClass
        {
            // Token: 0x0400170E RID: 5902
            wcAimWpn,
            // Token: 0x0400170F RID: 5903
            wcRocketWpn,
            // Token: 0x04001710 RID: 5904
            wcBombWpn,
            // Token: 0x04001711 RID: 5905
            wcGunWpn,
            // Token: 0x04001712 RID: 5906
            wcECM,
            // Token: 0x04001713 RID: 5907
            wcTank,
            // Token: 0x04001714 RID: 5908
            wcAgmWpn,
            // Token: 0x04001715 RID: 5909
            wcHARMWpn,
            // Token: 0x04001716 RID: 5910
            wcSamWpn,
            // Token: 0x04001717 RID: 5911
            wcGbuWpn,
            // Token: 0x04001718 RID: 5912
            wcCamera,
            // Token: 0x04001719 RID: 5913
            wcNoWpn
        }

        // Token: 0x020000CF RID: 207
        public enum WeaponDomain
        {
            // Token: 0x0400171B RID: 5915
            wdAir = 1,
            // Token: 0x0400171C RID: 5916
            wdGround,
            // Token: 0x0400171D RID: 5917
            wdBoth,
            // Token: 0x0400171E RID: 5918
            wdNoDomain = 0
        }

        // Token: 0x020000D0 RID: 208
        public enum PointTypes
        {
            // Token: 0x04001720 RID: 5920
            NoPt,
            // Token: 0x04001721 RID: 5921
            RunwayPt,
            // Token: 0x04001722 RID: 5922
            TakeoffPt,
            // Token: 0x04001723 RID: 5923
            TaxiPt,
            // Token: 0x04001724 RID: 5924
            SAMPt,
            // Token: 0x04001725 RID: 5925
            ArtilleryPt,
            // Token: 0x04001726 RID: 5926
            AAAPt,
            // Token: 0x04001727 RID: 5927
            RadarPt,
            // Token: 0x04001728 RID: 5928
            RunwayDimPt,
            // Token: 0x04001729 RID: 5929
            SupportPt,
            // Token: 0x0400172A RID: 5930
            StaticRadarPt,
            // Token: 0x0400172B RID: 5931
            SmallParkPt,
            // Token: 0x0400172C RID: 5932
            LargeParkPt,
            // Token: 0x0400172D RID: 5933
            SmallDockPt,
            // Token: 0x0400172E RID: 5934
            LargeDockPt,
            // Token: 0x0400172F RID: 5935
            TakeRunwayPt,
            // Token: 0x04001730 RID: 5936
            HelicopterPt,
            // Token: 0x04001731 RID: 5937
            FollowMePt,
            // Token: 0x04001732 RID: 5938
            TrackPt,
            // Token: 0x04001733 RID: 5939
            CritTaxiPt,
            // Token: 0x04001734 RID: 5940
            MpdPt,
            // Token: 0x04001735 RID: 5941
            VacatePt
        }

        // Token: 0x020000D1 RID: 209
        public enum PointListTypes
        {
            // Token: 0x04001737 RID: 5943
            NoList,
            // Token: 0x04001738 RID: 5944
            RunwayListType,
            // Token: 0x04001739 RID: 5945
            NoName2,
            // Token: 0x0400173A RID: 5946
            NoName3,
            // Token: 0x0400173B RID: 5947
            SAMListType,
            // Token: 0x0400173C RID: 5948
            ArtListType,
            // Token: 0x0400173D RID: 5949
            AAAListType,
            // Token: 0x0400173E RID: 5950
            NoName7,
            // Token: 0x0400173F RID: 5951
            RnwyDimListType,
            // Token: 0x04001740 RID: 5952
            NoName9,
            // Token: 0x04001741 RID: 5953
            StaticRadarListType,
            // Token: 0x04001742 RID: 5954
            ParkListType,
            // Token: 0x04001743 RID: 5955
            RnwyListLtType,
            // Token: 0x04001744 RID: 5956
            RnwyListRtType,
            // Token: 0x04001745 RID: 5957
            HeliListType,
            // Token: 0x04001746 RID: 5958
            FollowListType,
            // Token: 0x04001747 RID: 5959
            DockListType,
            // Token: 0x04001748 RID: 5960
            TrackListType,
            // Token: 0x04001749 RID: 5961
            EngListType,
            // Token: 0x0400174A RID: 5962
            GenListType,
            // Token: 0x0400174B RID: 5963
            RdrListType,
            // Token: 0x0400174C RID: 5964
            LstListType
        }

        // Token: 0x020000D2 RID: 210
        public enum SensorType
        {
            // Token: 0x0400174E RID: 5966
            IRST,
            // Token: 0x0400174F RID: 5967
            Radar,
            // Token: 0x04001750 RID: 5968
            RWR,
            // Token: 0x04001751 RID: 5969
            Visual,
            // Token: 0x04001752 RID: 5970
            HTS,
            // Token: 0x04001753 RID: 5971
            TargetingPod,
            // Token: 0x04001754 RID: 5972
            RadarHoming,
            // Token: 0x04001755 RID: 5973
            DataLinkPod
        }

        // Token: 0x020000D3 RID: 211
        public enum MFD_Color
        {
            // Token: 0x04001757 RID: 5975
            MFD_GREEN,
            // Token: 0x04001758 RID: 5976
            MFD_WHITE,
            // Token: 0x04001759 RID: 5977
            MFD_RED,
            // Token: 0x0400175A RID: 5978
            MFD_YELLOW,
            // Token: 0x0400175B RID: 5979
            MFD_CYAN,
            // Token: 0x0400175C RID: 5980
            MFD_MAGENTA,
            // Token: 0x0400175D RID: 5981
            MFD_BLUE,
            // Token: 0x0400175E RID: 5982
            MFD_GREY,
            // Token: 0x0400175F RID: 5983
            MFD_BRIGHT_GREEN,
            // Token: 0x04001760 RID: 5984
            MFD_WHITY_GRAY,
            // Token: 0x04001761 RID: 5985
            MFD_DARK_GRAY,
            // Token: 0x04001762 RID: 5986
            MFD_BLACK,
            // Token: 0x04001763 RID: 5987
            MFD_DARK_GREEN
        }

        // Token: 0x020000D4 RID: 212
        public enum CallsignUsage
        {
            // Token: 0x04001765 RID: 5989
            Call1 = 1,
            // Token: 0x04001766 RID: 5990
            Call2,
            // Token: 0x04001767 RID: 5991
            Call3 = 4,
            // Token: 0x04001768 RID: 5992
            Call4 = 8,
            // Token: 0x04001769 RID: 5993
            Call5 = 16,
            // Token: 0x0400176A RID: 5994
            Call6 = 32,
            // Token: 0x0400176B RID: 5995
            Call7 = 64,
            // Token: 0x0400176C RID: 5996
            Call8 = 128
        }

        public class IconIDs: IDisposable
        {
            // Token: 0x04001BBE RID: 7102
            public string Name = string.Empty;

            // Token: 0x04001BBF RID: 7103
            public Bitmap Icon = null;

            public void Dispose()
            {
                if (Icon != null)
                {
                    Icon.Dispose();
                }
            }
        }

        public struct ImageId
        {
            // Token: 0x04001BBC RID: 7100
            public string Name;

            // Token: 0x04001BBD RID: 7101
            public int ID;
        }
    }
}
