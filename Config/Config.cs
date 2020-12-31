using AMS.Profile;
using System;
using System.IO;
using System.Linq.Expressions;
using static Config.Enums;

namespace Config
{
    public class Config
    {

        #region Constructor & Destructor

        public Config()
        {
            LoadFromFile();
        }

        ~Config()
        {
        }
        public static string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            MemberExpression body = (MemberExpression)expression.Body;
            
            return body.Member.Name;
        }
        #endregion

        public SlicerType Slicer  { get; set; }
        public EndStop EndStopZ { get; set; }
        public PurgingDirectionType PurgingDirection { get; set; }
        public float PrintAreaXmin { get; set; }
        public float PrintAreaXmax { get; set; }
        public float PrintAreaYmin { get; set; }
        public float PrintAreaYmax { get; set; }
        #region StartCode
        public bool IsAutoZalign { get; set; }
        public bool IsAutoLevelling { get; set; }
        public bool IsUseAutoLevellingData { get; set; }
        public bool IsPreheatBedBeforeABL { get; set; }
        public bool IsPreheatNozzleBeforeABL { get; set; }
        public bool IsPreheatBedBeforeABLManual { get; set; }
        public bool IsPreheatNozzleBeforeABLManual { get; set; }
        public float PreheatingTempBedBeforeABL { get; set; }
        public float PreheatingTempNozzleBeforeABL { get; set; }
        public float LiftHeight { get; set; }
        public float ClearStartZ { get; set; }
        public float ClearStartX { get; set; }
        public float ClearStartY { get; set; }
        public float ClearEndX { get; set; }
        public float ClearEndY { get; set; }
        public float PurgingFilamentLength { get; set; }
        public float RetractionLength { get; set; }
        public float SpeedMoveXY { get; set; }
        public float SpeedMoveZ { get; set; }
        public float SpeedMoveE { get; set; }
        public float SpeedRetraction { get; set; }
        public int PurgingLineCount { get; set; }
        public float PurgingLineGap { get; set; }
        public float PurgingSpeed { get; set; }
        public float PurgingDistance { get; set; }
        private void SaveStartCode(Ini config)
        {
            var section = "PrinterProperty";
            config.SetValue(section, "Slicer", Slicer);
            config.SetValue(section, "PrintAreaXmin", PrintAreaXmin);
            config.SetValue(section, "PrintAreaYmin", PrintAreaYmin);
            config.SetValue(section, "PrintAreaXmax", PrintAreaXmax);
            config.SetValue(section, "PrintAreaYmax", PrintAreaYmax);

            section = "StartCode";
            config.SetValue(section, "IsAutoZalign", IsAutoZalign);
            config.SetValue(section, "IsAutoLevelling", IsAutoLevelling);
            config.SetValue(section, "IsUseAutoLevellingData", IsUseAutoLevellingData);

            config.SetValue(section, "IsPreheatBedBeforeABL", IsPreheatBedBeforeABL);
            config.SetValue(section, "IsPreheatNozzleBeforeABL", IsPreheatNozzleBeforeABL);
            config.SetValue(section, "IsPreheatBedBeforeABLManual", IsPreheatBedBeforeABLManual);
            config.SetValue(section, "IsPreheatNozzleBeforeABLManual", IsPreheatNozzleBeforeABLManual);
            config.SetValue(section, "PreheatingTempBedBeforeABL", PreheatingTempBedBeforeABL);
            config.SetValue(section, "PreheatingTempNozzleBeforeABL", PreheatingTempNozzleBeforeABL);

            config.SetValue(section, "LiftHeight", LiftHeight);
            config.SetValue(section, "ClearStartZ", ClearStartZ);
            config.SetValue(section, "ClearStartX", ClearStartX);
            config.SetValue(section, "ClearStartY", ClearStartY);
            config.SetValue(section, "ClearEndX", ClearEndX);
            config.SetValue(section, "ClearEndY", ClearEndY);
            config.SetValue(section, "PurgingLength", PurgingFilamentLength);
            config.SetValue(section, "RetractionLength", RetractionLength);
            config.SetValue(section, "PurgingLineCount", PurgingLineCount);
            config.SetValue(section, "PurgingLineGap", PurgingLineGap);
            config.SetValue(section, "PurgingSpeed", PurgingSpeed);
            config.SetValue(section, "PurgingDistance", PurgingDistance);
            config.SetValue(section, "PurgingDir", PurgingDirection);

            config.SetValue(section, "SpeedMoveXY", SpeedMoveXY);
            config.SetValue(section, "SpeedMoveZ", SpeedMoveZ);
            config.SetValue(section, "SpeedMoveE", SpeedMoveE);
            config.SetValue(section, "SpeedRetraction", SpeedRetraction);
        }
        private void LoadStartCode(Ini config)
        {
            var section = "PrinterProperty";
            Slicer = Utils.EnumHelper.ParseEnum<SlicerType>(config.GetValue(section, "Slicer", SlicerType.Cura.ToString()));
            PrintAreaXmin = config.GetValue(section, GetPropertyName(() => PrintAreaXmin), 0);
            PrintAreaXmax = config.GetValue(section, GetPropertyName(() => PrintAreaXmax), 300);
            PrintAreaYmin = config.GetValue(section, GetPropertyName(() => PrintAreaYmin), 0);
            PrintAreaYmax = config.GetValue(section, GetPropertyName(() => PrintAreaYmax), 300);
            section = "StartCode";
            IsAutoZalign = config.GetValue(section, "IsAutoZalign", false);
            IsAutoLevelling = config.GetValue(section, "IsAutoLevelling", false);
            IsUseAutoLevellingData = config.GetValue(section, "IsUseAutoLevellingData", false);

            IsPreheatBedBeforeABL = config.GetValue(section, "IsPreheatBedBeforeABL", false);
            IsPreheatNozzleBeforeABL = config.GetValue(section, "IsPreheatNozzleBeforeABL", false);
            IsPreheatBedBeforeABLManual = config.GetValue(section, GetPropertyName(() => IsPreheatBedBeforeABLManual), false);
            IsPreheatNozzleBeforeABLManual = config.GetValue(section, GetPropertyName(() => IsPreheatNozzleBeforeABLManual), false);
            PreheatingTempBedBeforeABL = config.GetValue(section, GetPropertyName(() => PreheatingTempBedBeforeABL), 70);
            PreheatingTempNozzleBeforeABL = config.GetValue(section, GetPropertyName(() => PreheatingTempNozzleBeforeABL), 110);

            LiftHeight = config.GetValue(section, GetPropertyName(() => LiftHeight), 5);
            ClearStartZ = (float)config.GetValue(section, GetPropertyName(() => ClearStartZ), 0.3f);
            ClearStartX = config.GetValue(section, GetPropertyName(() => ClearStartX), 5);
            ClearStartY = config.GetValue(section, GetPropertyName(() => ClearStartY), 5);
            ClearEndX = config.GetValue(section, GetPropertyName(() => ClearEndX), 5);
            ClearEndY = config.GetValue(section, GetPropertyName(() => ClearEndY), 5);
            PurgingFilamentLength = config.GetValue(section, GetPropertyName(() => PurgingFilamentLength), 10);
            RetractionLength = config.GetValue(section, GetPropertyName(() => RetractionLength), -1);
            PurgingLineCount = config.GetValue(section, GetPropertyName(() => PurgingLineCount), 1);
            PurgingLineGap = config.GetValue(section, GetPropertyName(() => PurgingLineGap), 5);
            PurgingSpeed = config.GetValue(section, GetPropertyName(() => PurgingSpeed), 5);
            PurgingDistance = config.GetValue(section, GetPropertyName(() => PurgingDistance), 100);
            PurgingDirection = Utils.EnumHelper.ParseEnum<PurgingDirectionType>(config.GetValue(section, GetPropertyName(() => PurgingDirection), PurgingDirectionType.X.ToString()));

            SpeedMoveXY = config.GetValue(section, GetPropertyName(() => SpeedMoveXY), 80);
            SpeedMoveZ = config.GetValue(section, GetPropertyName(() => SpeedMoveZ), 4);
            SpeedMoveE = config.GetValue(section, GetPropertyName(() => SpeedMoveE), 4);
            SpeedRetraction = config.GetValue(section, GetPropertyName(() => SpeedRetraction), 30);
        }
        #endregion StartCode

        #region EndCode
        public MoveAxisAfterEndType MoveAxisAfterEnd_X { get; set; }
        public MoveAxisAfterEndType MoveAxisAfterEnd_Y { get; set; }
        public float EndTempBed { get; set; }
        public float EndTempNozzle { get; set; }
        public bool IsParkingNozzleAfterEnd { get; set; }
        public float EndPosX { get; set; }
        public float EndPosY { get; set; }
        public float EndLiftZ { get; set; }
        public bool IsMotorOff { get; set; }
        public bool IsFanOff { get; set; }
        public int FanOffWaitTime { get; set; }
        public bool IsEndHomeX { get; set; }
        public bool IsEndHomeY { get; set; }
        public bool IsEndHomeZ { get; set; }
        public float EndRetractionLength { get; set; }
        public int EndRetractionSpeed { get; set; }
        private void SaveEndCode(Ini config)
        {
            var section = "EndCode Position";
            config.SetValue(section, "EndRetractionLength", EndRetractionLength);
            config.SetValue(section, "EndRetractionSpeed", EndRetractionSpeed);
            config.SetValue(section, "EndLiftZ", EndLiftZ);

            config.SetValue(section, "MoveAxisAfterEnd_X", MoveAxisAfterEnd_X);
            config.SetValue(section, "EndPosX", EndPosX);
            config.SetValue(section, "MoveAxisAfterEnd_Y", MoveAxisAfterEnd_Y);
            config.SetValue(section, "EndPosY", EndPosY);

            section = "EndCode Temperature";
            config.SetValue(section, "EndTempBed", EndTempBed);
            config.SetValue(section, "EndTempNozzle", EndTempNozzle);

            section = "EndCode Control";
            config.SetValue(section, "IsMotorOff", IsMotorOff);
            config.SetValue(section, "IsFanOff", IsFanOff);
            config.SetValue(section, "FanOffWaitTime", FanOffWaitTime);
        }
        private void LoadEndCode(Ini config)
        {
            var section = "EndCode Position";
            EndRetractionLength = config.GetValue(section, "EndRetractionLength", -1);
            EndRetractionSpeed = config.GetValue(section, "EndRetractionSpeed", 1800);

            MoveAxisAfterEnd_X = Utils.EnumHelper.ParseEnum <MoveAxisAfterEndType>(config.GetValue(section, "MoveAxisAfterEnd_X", MoveAxisAfterEnd_X.ToString()));
            MoveAxisAfterEnd_Y = Utils.EnumHelper.ParseEnum<MoveAxisAfterEndType>(config.GetValue(section, "MoveAxisAfterEnd_Y", MoveAxisAfterEnd_Y.ToString()));
            EndPosX = config.GetValue(section, "EndPosX", 0);
            EndPosY = config.GetValue(section, "EndPosY", 0);
            EndLiftZ = config.GetValue(section, "EndLiftZ", 5);

            section = "EndCode Temperature";
            EndTempBed = config.GetValue(section, "EndTempBed", 0);
            EndTempNozzle = config.GetValue(section, "EndTempNozzle", 0);

            section = "EndCode Control";
            IsMotorOff = config.GetValue(section, "IsMotorOff", true);
            IsFanOff = config.GetValue(section, "IsFanOff", true);
            FanOffWaitTime = config.GetValue(section, "FanOffWaitTime", 60);
        }
        
        #endregion EndCode

        #region Save to file & Load from file
        public string ConfigFile { get; set; } = Environment.CurrentDirectory+@"\Config\Config.ini";
        public bool SaveToFile()
        {
            //Ini config;
            #region Directory check
            if (!Directory.Exists(Environment.CurrentDirectory + @"\Config\"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\Config\");
            }
            #endregion

            // Config file open
            Ini config = new Ini(ConfigFile);
            try
            {
                SaveStartCode(config);
                SaveEndCode(config);
            }
            catch (Exception ex)
            {
                Logger(ex.Message+ex.StackTrace);
            }
            finally { config = null; }
            return true;
        }

        public bool LoadFromFile()
        {
            Ini config = new Ini(ConfigFile);
            LoadStartCode(config);
            LoadEndCode(config);
            config = null;
            return true;
        }
        #endregion
        private void Logger(string log)
        {
            Console.WriteLine(log);
        }
    }
}
