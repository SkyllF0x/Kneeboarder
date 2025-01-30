using BMSKneeboarder.Bms.Model;
using BMSKneeboarder.Bms.UI;
using Microsoft.Toolkit.HighPerformance;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Microsoft.VisualBasic.CompilerServices;
using System.Numerics;
using Microsoft.Toolkit.HighPerformance.Helpers;
using Microsoft.VisualBasic.Logging;
using log4net.Repository.Hierarchy;

namespace BMSKneeboarder.Bms
{
    public static class BmsUtils
    {
        private const uint CampaignHours = 3600000;
        public static string GetBmsDir()
        {
            string s = ConfigurationManager.AppSettings.Get("BmsDir");
            if (!string.IsNullOrEmpty(s) && !s.EndsWith(Path.DirectorySeparatorChar))
                s += Path.DirectorySeparatorChar;
            return s;
        }

        public static int GridXToCtlX(float gridX, MapSettings mapSettings, int controlWidth, int controlHeight)
        {
            return Convert.ToInt32((gridX - mapSettings.Center.X) * mapSettings.GetScale(controlWidth)) + controlWidth / 2;
        }

        public static int GridYToCtlY(float gridY, MapSettings mapSettings, int controlWidth, int controlHeight)
        {
            return Convert.ToInt32((-gridY + mapSettings.Center.Y) * mapSettings.GetScale(controlWidth)) + controlHeight / 2;
        }

        public static int PreciseXToCtlX(double preciseX, MapSettings mapSettings, int controlWidth, int controlHeight)
        {
            return Convert.ToInt32((preciseX / Constants.KM_TO_FT - mapSettings.Center.X) * mapSettings.GetScale(controlWidth)) + controlWidth / 2;
        }

        public static int PreciseYToCtlY(double preciseY, MapSettings mapSettings, int controlWidth, int controlHeight)
        {
            return Convert.ToInt32((mapSettings.Center.Y - (preciseY / Constants.KM_TO_FT)) * mapSettings.GetScale(controlWidth)) + controlHeight / 2;
        }

        public static bool insideDrawRegion(Vector2 regionSize, Vector2 point) {
            return point.X > 0 && point.Y > 0 && point.X < regionSize.X && point.Y < regionSize.Y;
        }

        private static void DrawOtherFlights(MissionData missionData, MapSettings mapSettings, int controlWidth, int controlHeight, Graphics graphics)
        {
            foreach (FlightMapSettings fms in mapSettings.OtherFlights)
            {
                if (fms.ShowOnMap)
                {
                    int wx_prev = 0;
                    int wy_prev = 0;

                    Pen penSolid = new Pen(fms.FlightPlanPen.Color, fms.FlightPlanPen.Width);

                    for (int i = 0; i < fms.Flight.waypoints.Length; i++)
                    {
                        Waypoint w = fms.Flight.waypoints[i];

                        int wx = PreciseXToCtlX((float)w.GridX * Constants.KM_TO_FT, mapSettings, controlWidth, controlHeight);
                        int wy = PreciseYToCtlY((float)w.GridY * Constants.KM_TO_FT, mapSettings, controlWidth, controlHeight);

                        if (i > 0 && fms.Flight.waypoints[i - 1].Action != 4 && fms.Flight.waypoints[i - 1].Action != 7 && fms.Flight.waypoints[i - 1].Action != 27)
                        {
                            graphics.DrawLine(fms.FlightPlanPen, wx, wy, wx_prev, wy_prev);
                        }

                        if (i == 0 || (fms.Flight.waypoints[i - 1].Action != 4 && fms.Flight.waypoints[i - 1].Action != 7 && fms.Flight.waypoints[i - 1].Action != 27))
                        {
                            if (w.IsTgtWaypoint)
                            {
                                graphics.DrawLines(penSolid, new Point[] {
                                    new Point(wx, wy - 30),
                                    new Point(wx - 20, wy + 10),
                                    new Point(wx + 20, wy + 10),
                                    new Point(wx, wy - 30)
                                });
                            }
                            else
                                graphics.DrawEllipse(penSolid, new Rectangle(wx - 15, wy - 15, 30, 30));
                        }

                        //if (mapSettings.ShowWptLabels)
                          //  graphics.DrawString((i + 1).ToString(), fnt, wptLabelBrush, wx + 12, wy);

                        wx_prev = wx;
                        wy_prev = wy;
                    }
                }
            }
        }
        private static void DrawStptLines(MissionData missionData, MapSettings mapSettings, int controlWidth, int controlHeight, Graphics graphics)
        {
            Pen[] pens = new Pen[] { mapSettings.STPTLine1Pen, mapSettings.STPTLine2Pen, mapSettings.STPTLine3Pen, mapSettings.STPTLine4Pen };
            bool[] show = new bool[] { mapSettings.ShowSTPTLine1, mapSettings.ShowSTPTLine2, mapSettings.ShowSTPTLine3, mapSettings.ShowSTPTLine4 };
            for (int n = 0; n < 4; n++)
            {
                if (show[n])
                {
                    for (int i = n * 6 + 1; i < (n + 1) * 6; i++)
                    {
                        if (!missionData.PilotStptLines[i - 1].IsZero && !missionData.PilotStptLines[i].IsZero)
                        {
                            graphics.DrawLine(pens[n],
                                PreciseXToCtlX(missionData.PilotStptLines[i - 1].X, mapSettings, controlWidth, controlHeight),
                                PreciseYToCtlY(missionData.PilotStptLines[i - 1].Y, mapSettings, controlWidth, controlHeight),
                                PreciseXToCtlX(missionData.PilotStptLines[i].X, mapSettings, controlWidth, controlHeight),
                                PreciseYToCtlY(missionData.PilotStptLines[i].Y, mapSettings, controlWidth, controlHeight)
                            );
                        }
                    }
                }
            }
        }

        private static void DrawString(Graphics graphics, string text, Font fnt, Brush textBrush, float x, float y, bool addOutline)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddString(text, fnt.FontFamily, (int)fnt.Style, fnt.Size, new PointF(x, y), new StringFormat());
            if (addOutline)
            {
                Color c = ((SolidBrush)textBrush).Color;
                Color c2;
                if (c.R + c.G + c.B > 3 * 128)
                    c2 = Color.Black;
                else
                    c2 = Color.White;
                graphics.DrawPath(new Pen(c2, 4), gp);
            }
            
            graphics.FillPath(textBrush, gp);
        }

        private static void DrawPpts(MissionData missionData, MapSettings mapSettings, int controlWidth, int controlHeight, Graphics graphics)
        {
            Pen p = mapSettings.PPTPen;
            Font fnt = new Font("MS Sans Serif", mapSettings.PPTNamesSize, FontStyle.Regular, GraphicsUnit.Pixel);
            Font fntNum = new Font("MS Sans Serif", mapSettings.PPTNumbersSize, FontStyle.Regular, GraphicsUnit.Pixel);
            Brush textBrush = new SolidBrush(mapSettings.PPTNamesColor);
            Brush textNumBrush = new SolidBrush(mapSettings.PPTNumbersColor);
            SolidBrush pptBrush = new SolidBrush(mapSettings.PPTPen.Color);
            
            for (int i = 0; i < 15; i++)
            {
                if (mapSettings.ShowPptNums.Contains(missionData.PilotPpts[i].PptNum) && !missionData.PilotPpts[i].IsZero)
                {
                    int x = PreciseXToCtlX(missionData.PilotPpts[i].X, mapSettings, controlWidth, controlHeight);
                    int y = PreciseYToCtlY(missionData.PilotPpts[i].Y, mapSettings, controlWidth, controlHeight);
                    int r = Convert.ToInt32(missionData.PilotPpts[i].R / Constants.KM_TO_FT * mapSettings.GetScale(controlWidth));

                    if (r > 5)
                    {
                        graphics.FillEllipse(mapSettings.PPTBrush, x - r, y - r, 2 * r, 2 * r);
                        graphics.DrawEllipse(p, x - r, y - r, 2 * r, 2 * r);

                        bool shiftText = mapSettings.ShowPptNames && mapSettings.ShowPptNumbers;
                        if (mapSettings.ShowPptNames && !string.IsNullOrEmpty(missionData.PilotPpts[i].Text))
                        {
                            SizeF sz = graphics.MeasureString(missionData.PilotPpts[i].Text, fnt);
                            if (sz.Width < 2 * r)
                            {
                                DrawString(graphics, missionData.PilotPpts[i].Text, fnt, textBrush, x - sz.Width / 2, shiftText ? (y - sz.Height - 1) : (y - sz.Height / 2), true);
                            } 
                            else shiftText = false;
                        }
                        if (mapSettings.ShowPptNumbers)
                        {
                            SizeF sz = graphics.MeasureString(missionData.PilotPpts[i].PptNum.ToString(), fntNum);
                            if (sz.Width < 2 * r)
                                DrawString(graphics, missionData.PilotPpts[i].PptNum.ToString(), fntNum, textNumBrush, x - sz.Width / 2, shiftText ? (y + 1) : (y - sz.Height / 2), true);
                        }
                    } else
                    {
                        graphics.FillPolygon(pptBrush, new Point[]
                        {
                            new Point(x, y- 10),
                            new Point(x + 10, y),
                            new Point(x, y + 10),
                            new Point(x - 10, y)
                        });

                        if (mapSettings.ShowPptNames && !string.IsNullOrEmpty(missionData.PilotPpts[i].Text))
                        {
                            SizeF sz = graphics.MeasureString(missionData.PilotPpts[i].Text, fnt);
                            DrawString(graphics, missionData.PilotPpts[i].Text, fnt, textBrush, x - sz.Width / 2, y - 10 - sz.Height, true);
                        }
                        if (mapSettings.ShowPptNumbers)
                        {
                            SizeF sz = graphics.MeasureString(missionData.PilotPpts[i].PptNum.ToString(), fntNum);
                            DrawString(graphics, missionData.PilotPpts[i].PptNum.ToString(), fntNum, textNumBrush, x - sz.Width / 2, y + 3, true);
                        }
                    }
                }
            }
        }

        private static void DrawTheaterMap(MissionData missionData, MapSettings mapSettings, int controlWidth, int controlHeight, Graphics graphics, bool noEffects)
        {
            if (mapSettings.MapIndex > 0)
            {
                {
                    Bitmap map = BMSKneeboarderDB.Instance.ReadTheaterMap(missionData.CampaignTable[0].TheaterName, mapSettings.MapIndex);
                    
                    {
                        if (map != null)
                        {
                            graphics.DrawImage(map,
                                new Rectangle(
                                    GridXToCtlX(0, mapSettings, controlWidth, controlHeight),
                                    GridYToCtlY(missionData.CampaignTable[0].TheaterSizeY, mapSettings, controlWidth, controlHeight),
                                    Convert.ToInt32(missionData.CampaignTable[0].TheaterSizeX * mapSettings.GetScale(controlWidth)),
                                    Convert.ToInt32(missionData.CampaignTable[0].TheaterSizeY * mapSettings.GetScale(controlWidth))
                                ),
                                0, 0, map.Width, map.Height,
                                GraphicsUnit.Pixel,
                                noEffects ? null : BmsUtils.GetImageAttributes(mapSettings.MapSaturation, mapSettings.MapBrightness)
                            );


                            /*double scale = mapSettings.GetScale(controlWidth);
                            

                            graphics.DrawImage(map, new Rectangle(0, 0, controlWidth, controlHeight),
                                Convert.ToSingle((mapSettings.Center.X - (double)(controlWidth / 2)) / scale * map.Width / missionData.CampaignTable[0].TheaterSizeX),
                                Convert.ToSingle((-mapSettings.Center.Y + (double)(controlHeight / 2)) / scale * map.Height / missionData.CampaignTable[0].TheaterSizeY),
                                Convert.ToSingle(controlWidth / scale * map.Width / missionData.CampaignTable[0].TheaterSizeX),
                                Convert.ToSingle(controlHeight / scale * map.Width / missionData.CampaignTable[0].TheaterSizeY),
                                GraphicsUnit.Pixel,
                                BmsUtils.GetImageAttributes(mapSettings.MapSaturation)
                            );*/
                        }
                    }
                }
                //GC.Collect();
            }

            if (mapSettings.ShowAirports)
            {
                foreach (Objective ab in missionData.GetAirbases())
                {
                    DrawAirbase(ab, missionData, mapSettings, controlWidth, controlHeight, graphics);
                }
            }

            if (mapSettings.ShowAirstrips)
            {
                foreach (Objective ab in missionData.GetAirstrips())
                {
                    DrawAirstrip(ab, missionData, mapSettings, controlWidth, controlHeight, graphics);
                }
            }
        }

        public static int GetObjectiveNr(BmsStructs.BmsId id, MissionData missionData)
        {
            int num = -1;
            checked
            {
                for (int i = 0; i < missionData.ObjectiveList.Count; i++)
                {
                    if (missionData.ObjectiveList[i].id.num == id.num)
                    {
                        num = i;
                        break;
                    }
                }
                return num;
            }
        }
        

        public static Bitmap GetObjectiveIcon(Objective obj, MissionData missionData)
        {
            Bitmap bmp = null;
            if (obj.entityType >= 100)
            {
                int color = 0;
                int objOwner = missionData.GetObjectiveOwner(obj.id);
                if (objOwner >= 0 && objOwner < missionData.TeamTable.Count)
                {
                    color = missionData.TeamTable[objOwner].teamColor;
                }
                short dt = missionData.classTableEntries[obj.entityType - 100].dataType;
                if (dt >= 0 && dt < missionData.ObjectDataEntries.Count)
                {
                    IconColor ic = (IconColor)color;
                    BmsStructs.ImageId imId = missionData.ImageIds.FirstOrDefault(x => x.ID == missionData.ObjectDataEntries[dt].IconIndex);
                    BmsStructs.IconIDs icId = missionData.Icons[ic].FirstOrDefault(x => x.Name == imId.Name);
                    if (icId != null)
                        bmp = icId.Icon;
                }
            }
            return bmp;
        }

        private static void DrawAirbase(Objective ab, MissionData missionData, MapSettings mapSettings, int controlWidth, int controlHeight, Graphics graphics)
        {
            int x = PreciseXToCtlX(ab.simPostion.x, mapSettings, controlWidth, controlHeight);
            int y = PreciseYToCtlY(ab.simPostion.y, mapSettings, controlWidth, controlHeight);
            
            if (!insideDrawRegion(new Vector2(controlWidth, controlHeight), new Vector2(x, y))) {
                return;
            }
            
            Bitmap bmp = GetObjectiveIcon(ab, missionData);

            if (bmp != null)
            {
                //bmp.MakeTransparent(Color.FromArgb(255, 248, 0, 248));

                int bmpW = Convert.ToInt32(bmp.Width * (float)mapSettings.AirportIconSize / 100);
                int bmpH = Convert.ToInt32(bmp.Height * (float)mapSettings.AirportIconSize / 100);
                graphics.DrawImage(bmp, new Rectangle(x - bmpW / 2, y - bmpH / 2, bmpW, bmpH));
            }
            else
            {
                graphics.FillRectangle(Brushes.White, new Rectangle(x - 25, y - 12, 50, 12));
                graphics.DrawRectangle(new Pen(Color.Black, 4), new Rectangle(x - 25, y - 12, 50, 12));
                graphics.FillRectangle(Brushes.White, new Rectangle(x - 15, y, 50, 12));
                graphics.DrawRectangle(new Pen(Color.Black, 4), new Rectangle(x - 15, y, 50, 12));
            }
        }

        private static void DrawAirstrip(Objective ab, MissionData missionData, MapSettings mapSettings, int controlWidth, int controlHeight, Graphics graphics)
        {

            int x = PreciseXToCtlX(ab.simPostion.x, mapSettings, controlWidth, controlHeight);
            int y = PreciseYToCtlY(ab.simPostion.y, mapSettings, controlWidth, controlHeight);

            
            if (!insideDrawRegion(new Vector2(controlWidth, controlHeight), new Vector2(x, y)))
            {
                return;
            }
            
            Bitmap bmp = GetObjectiveIcon(ab, missionData);

            if (bmp != null)
            {
                //bmp.MakeTransparent(Color.FromArgb(255, 248, 0, 248));

                int bmpW = Convert.ToInt32(bmp.Width * (float)mapSettings.AirportIconSize / 100);
                int bmpH = Convert.ToInt32(bmp.Height * (float)mapSettings.AirportIconSize / 100);

                graphics.DrawImage(bmp, new Rectangle(x - bmpW / 2, y - bmpH / 2, bmpW, bmpH));

                //Font fnt = new Font("MS Sans Serif", mapSettings.WptLabelSize, FontStyle.Regular, GraphicsUnit.Pixel);
                //graphics.DrawString(ab.id.num.ToString(), fnt, Brushes.Black, x + 20, y);
            }
            else
            {
                graphics.FillRectangle(Brushes.White, new Rectangle(x - 20, y - 4, 40, 8));
                graphics.DrawRectangle(new Pen(Color.Black, 4), new Rectangle(x - 20, y - 4, 40, 8));
            }
        }

        private static void DrawBE(MissionData missionData, MapSettings mapSettings, int controlWidth, int controlHeight, Graphics graphics)
        {
            int beX = GridXToCtlX(missionData.CampaignTable[0].BullseyeX, mapSettings, controlWidth, controlHeight);
            int beY = GridYToCtlY(missionData.CampaignTable[0].BullseyeY, mapSettings, controlWidth, controlHeight);
            
            int r1 = mapSettings.BESize / 12;
            int r2 = mapSettings.BESize / 4;
            int r3 = mapSettings.BESize / 2;
            int w = mapSettings.BESize / 7;

            Brush BEBrush = new SolidBrush(mapSettings.BEColor);
            Pen BEPen = new Pen(mapSettings.BEColor, w);
            
            graphics.FillEllipse(BEBrush, new Rectangle(beX - r1, beY - r1, 2*r1, 2*r1));
            graphics.DrawEllipse(BEPen, new Rectangle(beX - r2, beY - r2, 2*r2, 2*r2));
            graphics.DrawEllipse(BEPen, new Rectangle(beX - r3, beY - r3, 2*r3, 2*r3));
        }

        private static void DrawBEGrid(MissionData missionData, MapSettings mapSettings, int controlWidth, int controlHeight, Graphics graphics)
        {
            int beX = GridXToCtlX(missionData.CampaignTable[0].BullseyeX, mapSettings, controlWidth, controlHeight);
            int beY = GridYToCtlY(missionData.CampaignTable[0].BullseyeY, mapSettings, controlWidth, controlHeight);
            graphics.DrawLine(mapSettings.BEGridPen, beX - 2000, beY, beX + 2000, beY);
            graphics.DrawLine(mapSettings.BEGridPen, beX, beY - 2000, beX, beY + 2000);
            graphics.DrawLine(mapSettings.BEGridPen, beX - 2000, beY - Convert.ToInt32(Math.Tan(Math.PI / 6) * 2000), beX + 2000, beY + Convert.ToInt32(Math.Tan(Math.PI / 6) * 2000));
            graphics.DrawLine(mapSettings.BEGridPen, beX - 2000, beY - Convert.ToInt32(Math.Tan(Math.PI / 3) * 2000), beX + 2000, beY + Convert.ToInt32(Math.Tan(Math.PI / 3) * 2000));
            graphics.DrawLine(mapSettings.BEGridPen, beX - 2000, beY + Convert.ToInt32(Math.Tan(Math.PI / 6) * 2000), beX + 2000, beY - Convert.ToInt32(Math.Tan(Math.PI / 6) * 2000));
            graphics.DrawLine(mapSettings.BEGridPen, beX - 2000, beY + Convert.ToInt32(Math.Tan(Math.PI / 3) * 2000), beX + 2000, beY - Convert.ToInt32(Math.Tan(Math.PI / 3) * 2000));
            double scale = mapSettings.GetScale(controlWidth);
            for (int rad = 30; rad < 220; rad += 30)
            {
                int r = Convert.ToInt32(rad / Constants.KM_TO_NM * scale);
                graphics.DrawEllipse(mapSettings.BEGridPen, beX - r, beY - r, 2 * r, 2 * r);
            }
        }

        public static void DrawMap(MissionData missionData, MapSettings mapSettings, int controlWidth, int controlHeight, Graphics graphics)
        {
            DrawMap(missionData, mapSettings, controlWidth, controlHeight, graphics, false);
        }
        public static void DrawMap(MissionData missionData, MapSettings mapSettings, int controlWidth, int controlHeight, Graphics graphics, bool noEffects)
        {
            double scale = mapSettings.GetScale(controlWidth);

            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            //graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            //graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            

            graphics.Clear(mapSettings.BackgroundColor);

            DrawTheaterMap(missionData, mapSettings, controlWidth, controlHeight, graphics, noEffects);

            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            //graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            if (mapSettings.ShowBE)
                DrawBE(missionData, mapSettings, controlWidth, controlHeight, graphics);

            if (mapSettings.ShowBEGrid)
                DrawBEGrid(missionData, mapSettings, controlWidth, controlHeight, graphics);

            DrawOtherFlights(missionData, mapSettings, controlWidth, controlHeight, graphics);
            DrawStptLines(missionData, mapSettings, controlWidth, controlHeight, graphics);
            DrawPpts(missionData, mapSettings, controlWidth, controlHeight, graphics);

            Font fnt = new Font("MS Sans Serif", mapSettings.WptLabelSize, FontStyle.Regular, GraphicsUnit.Pixel);
            
            Brush wptLabelBrush = new SolidBrush(mapSettings.WptLabelColor);

            Flight currentFlight = missionData.GetCurrentFlight();

            if (currentFlight != null)
            {
                int wx_prev = 0;
                int wy_prev = 0;

                for (int i = 0; i < currentFlight.waypoints.Length; i++)
                {
                    Waypoint w = currentFlight.waypoints[i];

                    //int wx = PreciseXToCtlX(missionData.PilotStpts[i].X, mapSettings, controlWidth, controlHeight);
                    //int wy = PreciseYToCtlY(missionData.PilotStpts[i].Y, mapSettings, controlWidth, controlHeight);
                    int wx = PreciseXToCtlX(w.GridX * Constants.KM_TO_FT, mapSettings, controlWidth, controlHeight);
                    int wy = PreciseYToCtlY(w.GridY * Constants.KM_TO_FT, mapSettings, controlWidth, controlHeight);

                    if (mapSettings.ShowWptLines && i > 0 && currentFlight.waypoints[i - 1].Action != 4 && currentFlight.waypoints[i - 1].Action != 7 && currentFlight.waypoints[i - 1].Action != 27)
                    {
                        graphics.DrawLine(mapSettings.WptLinePen, wx, wy, wx_prev, wy_prev);
                    }

                    if (w.IsTgtWaypoint)
                    {
                        graphics.DrawLines(mapSettings.WptPen, new Point[] { 
                            new Point(wx, wy - 30),
                            new Point(wx - 20, wy + 10),
                            new Point(wx + 20, wy + 10),
                            new Point(wx, wy - 30)
                        });
                    } else
                        graphics.DrawEllipse(mapSettings.WptPen, new Rectangle(wx - 15, wy - 15, 30, 30));

                    if (mapSettings.ShowWptLabels && w.Action != 7)
                    {
                        string wNo;
                        if (missionData.IsF15Mode)
                            wNo = (i == 0) ? "B" : i.ToString();
                        else
                            wNo = (i+1).ToString();
                        DrawString(graphics, wNo, fnt, wptLabelBrush, wx + 12, wy, true);
                    }

                    wx_prev = wx;
                    wy_prev = wy;
                }

                DrawString(graphics, missionData.GetFlightCallsign(currentFlight), new Font("MS Sans Serif", 60, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Black, 10, 10, true);
            }
        }

        private static ColorMatrix Multiply(float[][] f1, float[][] f2)
        {
            ColorMatrix X = new ColorMatrix();
            
            int size = 5;
            for (int j = 0; j < 5; j++)
            {
                
                for (int i = 0; i < 5; i++)
                {
                    float s = 0;
                    for (int k = 0; k < size; k++)
                    {
                        s += f2[i][k] * f1[k][j];
                    }
                    X[i, j] = s;
                }
            }
            return X;
        }

        public static float[][] matrix1 = new float[][] { new float[5], new float[5], new float[5], new float[5], new float[5] };
        public static float[][] matrix2 = new float[][] { new float[5], new float[5], new float[5], new float[5], new float[5] };

        public static ImageAttributes GetImageAttributes(int saturation, int brightness = 0)
        {
            ImageAttributes imageAtts = new ImageAttributes();
            
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == j)
                    {
                        matrix1[i][j] = 1.0f;
                        matrix2[i][j] = 1.0f;
                    }
                    else
                    {
                        matrix1[i][j] = 0.0f;
                        matrix2[i][j] = 0.0f;
                    }
                }
            }

            matrix1[4][0] = matrix1[4][1] = matrix1[4][2] = (float)brightness / 100.0f;
            
            float sat = (saturation / 100f);

            float baseSat = 1.0f - sat;
            float rwgt = 0.3086f;
            float gwgt = 0.6094f;
            float bwgt = 0.0820f;

            matrix2[0][0] = baseSat * rwgt + sat;
            matrix2[0][1] = baseSat * rwgt;
            matrix2[0][2] = baseSat * rwgt;
            matrix2[1][0] = baseSat * gwgt;
            matrix2[1][1] = baseSat * gwgt + sat;
            matrix2[1][2] = baseSat * gwgt;
            matrix2[2][0] = baseSat * bwgt;
            matrix2[2][1] = baseSat * bwgt;
            matrix2[2][2] = baseSat * bwgt + sat;

            imageAtts.SetColorMatrix(Multiply(matrix1, matrix2), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            //imageAtts.SetColorMatrix(new ColorMatrix(matrix2), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            return imageAtts;
        }

        public static string TypeToString(byte Domain, byte EClass, byte Type)
        {
            string text = "";
            if (Domain == 0)
            {
                text = "0";
            }
            else if (Domain == 1)
            {
                if (EClass == 0)
                {
                    if (Type == 1)
                    {
                        text = "Flying Eye";
                    }
                    else if (Type == 2)
                    {
                        text = "2";
                    }
                    else if (Type == 3)
                    {
                        text = "3";
                    }
                }
                else if (EClass == 3)
                {
                    if (Type == 1)
                    {
                        text = "Team";
                    }
                }
                else if (EClass == 8)
                {
                    switch (Type)
                    {
                        case 1:
                            text = "Nothing";
                            break;
                        case 2:
                            text = "MineSweep";
                            break;
                        case 3:
                            text = "Gun";
                            break;
                        case 4:
                            text = "Rack";
                            break;
                        case 5:
                            text = "Launcher";
                            break;
                    }
                }
                else if ((EClass > 8) & (EClass <= 13))
                {
                    text = "";
                }
                else
                {
                    text = Conversions.ToString(Type);
                }
            }
            else if (Domain == 2)
            {
                if (EClass == 3)
                {
                    if (Type == 1)
                    {
                        text = "ATM";
                    }
                }
                else if (EClass == 5)
                {
                    text = Conversions.ToString(Type);
                }
                else if (EClass == 6)
                {
                    switch (Type)
                    {
                        case 1:
                            text = "Flight";
                            break;
                        case 2:
                            text = "Package";
                            break;
                        case 3:
                            text = "Squadron";
                            break;
                    }
                }
                else if (EClass == 7)
                {
                    switch (Type)
                    {
                        case 1:
                            text = "Airplane";
                            break;
                        case 2:
                            text = "Bomb";
                            break;
                        case 3:
                            text = "External Pod";
                            break;
                        case 4:
                            text = "Fuel Tank";
                            break;
                        case 5:
                            text = "Helicopter";
                            break;
                        case 6:
                            text = "Missile";
                            break;
                        case 7:
                            text = "Recon";
                            break;
                        case 8:
                            text = "Rocket";
                            break;
                        default:
                            text = Type.ToString();
                            break;
                    }
                }
                else if (EClass == 9)
                {
                    byte b = Type;
                    if (b == 1)
                    {
                        text = "Cloud";
                    }
                }
                else
                {
                    text = Type.ToString();
                }
            }
            else if (Domain == 3)
            {
                if (EClass == 0)
                {
                    if (Type == 1)
                    {
                        text = "1";
                    }
                    else if (Type == 2)
                    {
                        text = "2";
                    }
                    else if (Type == 3)
                    {
                        text = "?";
                    }
                }
                else if (EClass == 3)
                {
                    if (Type == 1)
                    {
                        text = "Team";
                    }
                }
                else if (EClass == 2)
                {
                    switch (Type)
                    {
                        case 1:
                            text = "Nothing";
                            break;
                        case 2:
                            text = "Ctrl Tower";
                            break;
                        case 3:
                            text = "Barn";
                            break;
                        case 4:
                            text = "Bunker";
                            break;
                        case 5:
                            text = "Bush";
                            break;
                        case 6:
                            text = "Factorys";
                            break;
                        case 7:
                            text = "Church";
                            break;
                        case 8:
                            text = "City Hall";
                            break;
                        case 9:
                            text = "Dock";
                            break;
                        case 10:
                            text = "Depot";
                            break;
                        case 11:
                            text = "Runway";
                            break;
                        case 12:
                            text = "Warehouse";
                            break;
                        case 13:
                            text = "Helipad";
                            break;
                        case 14:
                            text = "Fuel Tanks";
                            break;
                        case 15:
                            text = "Nuke Plant";
                            break;
                        case 16:
                            text = "Bridges";
                            break;
                        case 17:
                            text = "Pier";
                            break;
                        case 18:
                            text = "Power Pole";
                            break;
                        case 19:
                            text = "Shop";
                            break;
                        case 20:
                            text = "Power Tower";
                            break;
                        case 21:
                            text = "Apartment";
                            break;
                        case 22:
                            text = "House";
                            break;
                        case 23:
                            text = "Power Plant";
                            break;
                        case 24:
                            text = "Taxi Sign";
                            break;
                        case 25:
                            text = "Nav Beacon";
                            break;
                        case 26:
                            text = "Radar Site";
                            break;
                        case 27:
                            text = "Craters";
                            break;
                        case 28:
                            text = "Radars";
                            break;
                        case 29:
                            text = "Radio Tower";
                            break;
                        case 30:
                            text = "Taxiway";
                            break;
                        case 31:
                            text = "Rail Terminals";
                            break;
                        case 32:
                            text = "Refinery";
                            break;
                        case 33:
                            text = "SAM";
                            break;
                        case 34:
                            text = "SHED";
                            break;
                        case 35:
                            text = "Barraks";
                            break;
                        case 36:
                            text = "Tree";
                            break;
                        case 37:
                            text = "Water Tower";
                            break;
                        case 38:
                            text = "Town Hall";
                            break;
                        case 39:
                            text = "Terminal";
                            break;
                        case 40:
                            text = "Shrine";
                            break;
                        case 41:
                            text = "Park";
                            break;
                        case 42:
                            text = "Office Block";
                            break;
                        case 43:
                            text = "TV Station";
                            break;
                        case 44:
                            text = "Hotel";
                            break;
                        case 45:
                            text = "Hanger";
                            break;
                        case 46:
                            text = "Lights";
                            break;
                        case 47:
                            text = "VASI";
                            break;
                        case 48:
                            text = "Tank";
                            break;
                        case 49:
                            text = "Fence";
                            break;
                        case 50:
                            text = "Parking Lot";
                            break;
                        case 51:
                            text = "Smoke Stack";
                            break;
                        case 52:
                            text = "Building";
                            break;
                        case 53:
                            text = "Cool Tower";
                            break;
                        case 54:
                            text = "Cont Dome";
                            break;
                        case 55:
                            text = "Guard House";
                            break;
                        case 56:
                            text = "Transformer";
                            break;
                        case 57:
                            text = "Ammo Dump";
                            break;
                        case 58:
                            text = "Art Site";
                            break;
                        case 59:
                            text = "Office";
                            break;
                        case 60:
                            text = "Chem Plant";
                            break;
                        case 61:
                            text = "Tower";
                            break;
                        case 62:
                            text = "Hospital";
                            break;
                        case 63:
                            text = "Shop Block";
                            break;
                        case 64:
                            text = "Static";
                            break;
                        case 65:
                            text = "Runway Marker";
                            break;
                        case 66:
                            text = "Stadium";
                            break;
                        case 67:
                            text = "Monument";
                            break;
                        case 68:
                            text = "Arrestor Cable";
                            break;
                        default:
                            text = Type.ToString();
                            break;
                    }
                }
                else if (EClass == 3)
                {
                    if (Type == 1)
                    {
                        text = "GTM";
                    }
                }
                else if (EClass == 4)
                {
                    switch (Type)
                    {
                        case 1:
                            text = "Airbase";
                            break;
                        case 2:
                            text = "AirStrip";
                            break;
                        case 3:
                            text = "ArmyBase";
                            break;
                        case 4:
                            text = "Beach";
                            break;
                        case 5:
                            text = "Border";
                            break;
                        case 6:
                            text = "Bridge";
                            break;
                        case 7:
                            text = "Chemical";
                            break;
                        case 8:
                            text = "City";
                            break;
                        case 9:
                            text = "Com Control";
                            break;
                        case 10:
                            text = "Depot";
                            break;
                        case 11:
                            text = "Factory";
                            break;
                        case 12:
                            text = "Fort";
                            break;
                        case 13:
                            text = "Fortification";
                            break;
                        case 14:
                            text = "Scenery";
                            break;
                        case 15:
                            text = "Intersection";
                            break;
                        case 16:
                            text = "Nav Beacon";
                            break;
                        case 17:
                            text = "Nuclear";
                            break;
                        case 18:
                            text = "Pass";
                            break;
                        case 19:
                            text = "Port";
                            break;
                        case 20:
                            text = "Power Plant";
                            break;
                        case 21:
                            text = "Radar";
                            break;
                        case 22:
                            text = "Radio Tower";
                            break;
                        case 23:
                            text = "Rail Terminal";
                            break;
                        case 24:
                            text = "Railroad";
                            break;
                        case 25:
                            text = "Refinery";
                            break;
                        case 26:
                            text = "Road";
                            break;
                        case 27:
                            text = "Sea";
                            break;
                        case 28:
                            text = "Town";
                            break;
                        case 29:
                            text = "Village";
                            break;
                        case 30:
                            text = "Harts";
                            break;
                        case 31:
                            text = "SAM Site";
                            break;
                    }
                }
                else if (EClass == 6)
                {
                    byte b2 = Type;
                    if (b2 != 1)
                    {
                        if (b2 == 2)
                        {
                            text = "Brigade";
                        }
                    }
                    else
                    {
                        text = "Battalion";
                    }
                }
                else if (EClass == 7)
                {
                    switch (Type)
                    {
                        case 1:
                            text = "Foot";
                            break;
                        case 2:
                            text = "Towed";
                            break;
                        case 3:
                            text = "Tracked";
                            break;
                        case 4:
                            text = "Wheeled";
                            break;
                        default:
                            text = Type.ToString();
                            break;
                    }
                }
                else
                {
                    text = Type.ToString();
                }
            }
            else if (Domain == 4)
            {
                if (EClass == 3)
                {
                    if (Type == 1)
                    {
                        text = "NTM";
                    }
                }
                else if (EClass == 6)
                {
                    byte b3 = Type;
                    if (b3 == 1)
                    {
                        text = "TaskForce";
                    }
                }
                else if (EClass == 7)
                {
                    switch (Type)
                    {
                        case 1:
                            text = "Assault";
                            break;
                        case 2:
                            text = "Boat";
                            break;
                        case 3:
                            text = "Buoy";
                            break;
                        case 4:
                            text = "Capital Ship";
                            break;
                        case 5:
                            text = "Cargo";
                            break;
                        case 6:
                            text = "Cruiser";
                            break;
                        case 7:
                            text = "Depth Charge";
                            break;
                        case 8:
                            text = "Destroyer";
                            break;
                        case 9:
                            text = "Frigate";
                            break;
                        case 10:
                            text = "Patrol";
                            break;
                        case 11:
                            text = "Raft";
                            break;
                        case 12:
                            text = "Ship";
                            break;
                        case 13:
                            text = "Tanker";
                            break;
                        case 14:
                            text = "Torpedo";
                            break;
                    }
                }
                else
                {
                    text = Conversions.ToString(Type);
                }
            }
            else if (Domain == 5)
            {
                text = Conversions.ToString(Type);
            }
            else if (Domain == 6)
            {
                text = Conversions.ToString(Type);
            }
            else if (Domain == 7)
            {
                if (EClass == 3)
                {
                    if (Type == 1)
                    {
                        text = "NTM";
                    }
                }
                else if (EClass == 6)
                {
                    byte b4 = Type;
                    if (b4 == 1)
                    {
                        text = "Wolfpack";
                    }
                }
                else if (EClass == 7)
                {
                    byte b5 = Type;
                    if (b5 == 1)
                    {
                        text = "Submarine";
                    }
                }
                else
                {
                    text = Conversions.ToString(Type);
                }
            }
            return text;
        }

        public static string GetTimeString(uint intTime)
        {
            int num = 1;
            string text;
            if (intTime < 0)
                return "";
            else
            {
                double num2 = intTime / (double)CampaignHours;
                checked
                {
                    int num3 = (int)num2;
                    int i = num3;
                    while (i >= 24)
                    {
                        i -= 24;
                        num++;
                    }
                    double num4 = unchecked((num2 - (double)num3) * 60.0);
                    int num5 = (int)num4;
                    double num6 = unchecked((num4 - (double)num5) * 60.0);
                    if (num6 > 59.9999)
                    {
                        num5++;
                        num6 = 0.0;
                    }
                    int num7 = (int)num6;
                    string text2;
                    if (i < 10)
                    {
                        text2 = "0" + Conversions.ToString(i);
                    }
                    else
                    {
                        text2 = Conversions.ToString(i);
                    }
                    string text3;
                    if (num5 < 10)
                    {
                        text3 = "0" + Conversions.ToString(num5);
                    }
                    else
                    {
                        text3 = Conversions.ToString(num5);
                    }
                    string text4;
                    if (num7 < 10)
                    {
                        text4 = "0" + Conversions.ToString(num7);
                    }
                    else
                    {
                        text4 = Conversions.ToString(num7);
                    }
                    text = string.Concat(new string[] { text2, ":", text3, ":", text4 });
                }
            }
            return text;
        }

        public static string FixName(string uName)
        {
            if (uName == null)
                return null;

            int num = uName.IndexOf('\0');
            if (num != -1)
                uName = uName.Substring(0, num);
            num = uName.IndexOf('\n');
            if (num != -1)
                uName = uName.Substring(0, num);
            num = uName.IndexOf('\r');
            if (num != -1)
                uName = uName.Substring(0, num);

            return uName.Trim();
        }

        public static string GetNumSuff(int n)
        {
            string ns = n.ToString();
            string text = ns.Substring(ns.Length - 1);
            string text2 = ns.Length > 1 ? ns.Substring(ns.Length - 2, 1) : "";
            string text3;
            if (text == "1")
            {
                if (n < 10)
                    text3 = "st";
                else if (n == 11)
                    text3 = "th";
                else if (text2 == "1")
                    text3 = "th";
                else
                    text3 = "st";
            }
            else if (text == "2")
            {
                if (n == 12)
                    text3 = "th";
                else if (text2 == "1")
                    text3 = "th";
                else
                    text3 = "nd";
            }
            else if (text == "3")
            {
                if (n == 13)
                    text3 = "th";
                else if (text2 == "1")
                    text3 = "th";
                else
                    text3 = "rd";
            }
            else
                text3 = "th";
            return text3;
        }

        public static string MoveTypeText(int n)
        {
            return Enum.GetNames(typeof(BmsStructs.MoveType))[n];
        }

        public static string DamageDataTypeText(int n)
        {
            return Enum.GetNames(typeof(BmsStructs.DamageDataType))[n];
        }

        public static double GridDistKm(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow((double)(x1 - x2), 2.0) + Math.Pow((double)(y1 - y2), 2.0));
        }
    }
}
