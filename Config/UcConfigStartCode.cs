using System;
using System.Windows.Forms;
using MyHelpers;
using static Config.Config;
using static Config.Enums;

namespace Config
{
    public partial class UcConfigStartCode : UserControl
    {
        public Config _config;
        public UcConfigStartCode()
        {
            InitializeComponent();
        }
        public void Init(ref Config config)
        {
            _config = config;
            LoadProperties();
        }
        public void Save()
        {
            ApplyProperties();
        }

        #region Properties
        CustomClass customClass;
        CustomProperty IsAutoZalign;
        CustomProperty IsAutoLevelling;
        CustomProperty IsUseAutoLevellingData;
        CustomProperty IsPreheatBedBeforeABL;
        CustomProperty IsPreheatNozzleBeforeABL;
        CustomProperty IsPreheatBedBeforeABLManual;
        CustomProperty IsPreheatNozzleBeforeABLManual;
        CustomProperty PreheatingTempBedBeforeABL;
        CustomProperty PreheatingTempNozzleBeforeABL;
        CustomProperty LiftHeight;
        CustomProperty ClearStartZ;
        CustomProperty ClearStartX;
        CustomProperty ClearStartY;
        CustomProperty PurgingLength;
        CustomProperty RetractionLength;
        CustomProperty PurgingLineCount;
        CustomProperty PurgingLineGap;
        CustomProperty PurgingSpeed;
        CustomProperty PurgingDistance;
        CustomProperty PurgingDirection;
        CustomProperty Slicer;
        CustomProperty SpeedMoveXY;
        CustomProperty SpeedMoveZ;
        CustomProperty SpeedMoveE;
        CustomProperty SpeedMoveRetraction;
        CustomProperty PrintAreaXmin;
        CustomProperty PrintAreaYmin;
        CustomProperty PrintAreaXmax;
        CustomProperty PrintAreaYmax;
        #endregion Properties
        private void LoadProperties()
        {
            if (customClass == null)
            {
                customClass = new CustomClass();
                propertyGrid.SelectedObject = customClass;
            }
            bool isVisibleCategory = true;
            string strCategory = "1. 슬라이서 세팅";
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref Slicer, strCategory, "슬라이서 종류", "   1. 슬라이서 종류", _config.Slicer, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref SpeedMoveXY, strCategory, "헤드의 X와 Y 이동 속도(mm/s)", "   2. 이동속도(mm/s) : XY", _config.SpeedMoveXY, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref SpeedMoveZ, strCategory, "베드 이동 속도(mm/s)", "   3. 이동속도(mm/s) : Z", _config.SpeedMoveZ, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref SpeedMoveE, strCategory, "익스트루더 압출 속도(mm/s)", "   4. 이동속도(mm/s) : E", _config.SpeedMoveE, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref SpeedMoveRetraction, strCategory, "리트랙션 속도. 스타트코드 내에서만 적용됩니다.", "   5. 리트랙션 속도(mm/s) : E", _config.SpeedRetraction, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref RetractionLength, strCategory, "리트랙션 길이", "   6. 노즐 청소 후 리트랙션 길이", _config.RetractionLength, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref PrintAreaXmin, strCategory, "출력영역 X Min(mm)", "   7. 출력영역 X Min(mm)", _config.PrintAreaXmin, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref PrintAreaXmax, strCategory, "출력영역 X Max(mm)", "   8. 출력영역 X Max(mm)", _config.PrintAreaXmax, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref PrintAreaYmin, strCategory, "출력영역 Y Min(mm)", "   9. 출력영역 Y Min(mm)", _config.PrintAreaYmin, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref PrintAreaYmax, strCategory, "출력영역 Y Max(mm)", "  10. 출력영역 Y Max(mm)", _config.PrintAreaYmax, false, isVisibleCategory);

            strCategory = "2. 오토레벨링";
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref IsAutoZalign, strCategory, "Z축 자동 정렬 기능 사용여부\r\n펌웨어에서 지원하는 경우에만 동작합니다.\r\nG34 삽입", "   1. Z축 자동 정렬", _config.IsAutoZalign, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref IsAutoLevelling, strCategory, "오토레벨링 실행\r\n펌웨어에서 지원하는 경우에만 동작합니다.\r\nG29 삽입", "   2. 오토레벨링 실행", _config.IsAutoLevelling, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref IsUseAutoLevellingData, strCategory, "펌웨어에 저장되어 있는 오토레벨링 데이터 사용\r\n레벨링 관련 기능을 사용하신다면 이 옵션을 꼭 켜주세요.\r\nM420 S1 삽입", "   3. 오토레벨링 데이터 사용", _config.IsUseAutoLevellingData, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref LiftHeight, strCategory, "오토홈 또는 오토레벨링 후에 해당 높이만큼 노즐과 베드 간격을 띄웁니다.\r\n베드 클립의 높이보다 높게 설정해주세요.", "   4. 레벨링 후 Z높이", _config.LiftHeight, false, isVisibleCategory);

            strCategory = "3. 베드예열";
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref IsPreheatBedBeforeABL, strCategory, "오토레벨링 전에 베드 가열을 시작합니다.", "   1. 베드 예열", _config.IsPreheatBedBeforeABL, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref IsPreheatBedBeforeABLManual, strCategory, "베드 예열 온도를 수동으로 지정합니다.\r\nTrue: 지정된 온도로 예열\r\nFalse: 슬라이서에 지정된 첫 레이어 온도로 예열", "   2. 예열 온도 지정", _config.IsPreheatBedBeforeABLManual, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref PreheatingTempBedBeforeABL, strCategory, "예열 온도를 지정합니다.", "   3. 예열 온도", _config.PreheatingTempBedBeforeABL, false, isVisibleCategory);
            
            strCategory = "4. 노즐예열";
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref IsPreheatNozzleBeforeABL, strCategory, "오토레벨링 전에 노즐 가열을 시작합니다.", "   1. 노즐 예열", _config.IsPreheatNozzleBeforeABL, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref IsPreheatNozzleBeforeABLManual, strCategory, "노즐 예열 온도를 수동으로 지정합니다.\r\nTrue: 지정된 온도로 예열\r\nFalse: 슬라이서에 지정된 첫 레이어 온도로 예열", "   2. 예열 온도 지정", _config.IsPreheatNozzleBeforeABLManual, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref PreheatingTempNozzleBeforeABL, strCategory, "예열 온도를 지정합니다.\r\n", "   3. 예열 온도", _config.PreheatingTempNozzleBeforeABL, false, isVisibleCategory);

            strCategory = "5. 노즐청소";
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref ClearStartZ, strCategory, "노즐 청소를 진행하는 Z 높이", "   1. 노즐 청소 높이", _config.ClearStartZ, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref ClearStartX, strCategory, "노즐 청소를 위해 이동 시작하는 X 좌표", "   2. 노즐 청소 시작 좌표: X", _config.ClearStartX, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref ClearStartY, strCategory, "노즐 청소를 위해 이동 시작하는 Y 좌표", "   3. 노즐 청소 시작 좌표: Y", _config.ClearStartY, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref PurgingDirection, strCategory, "노즐 청소를 위해 노즐이 이동하는 방향", "   4. 노즐 청소 라인 방향", _config.PurgingDirection, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref PurgingDistance, strCategory, "노즐 청소를 위해 노즐이 이동하는 거리", "   5. 노즐 청소 라인 길이", _config.PurgingDistance, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref PurgingLength, strCategory, "노즐 청소를 위해 짜내는 필라멘트 길이\r\n각 라인마다 이 항목에 설정된 길이의 필라멘트를 압출합니다.", "   6. 필라멘트 길이", _config.PurgingFilamentLength, false, isVisibleCategory);
           

            Utils.BaseHelper.MakePropertyItem(ref customClass, ref PurgingLineCount, strCategory, "노즐 청소를 위해 짜내는 라인 수", "   7. 노즐 청소 라인 수", _config.PurgingLineCount, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref PurgingLineGap, strCategory, "노즐 청소 라인 간의 간격", "   8. 노즐 청소 라인 간격", _config.PurgingLineGap, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref PurgingSpeed, strCategory, "노즐 청소 라인을 출력하는 속도(mm/s)", "   9. 이동 속도", _config.PurgingSpeed, false, isVisibleCategory);

            propertyGrid.PropertyValueChanged += PropertyGrid_PropertyValueChanged;
            propertyGrid.Refresh();
        }

        private void PropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            Save();
        }

        private void ApplyProperties()
        {
            try
            {
                _config.Slicer = Utils.EnumHelper.ParseEnum<SlicerType>(Slicer.Value.ToString());
                _config.SpeedMoveXY = (float)SpeedMoveXY.Value;
                _config.SpeedMoveZ = (float)SpeedMoveZ.Value;
                _config.SpeedMoveE = (float)SpeedMoveE.Value;
                _config.SpeedRetraction = (float)SpeedMoveRetraction.Value;
                _config.PrintAreaXmin = (float)PrintAreaXmin.Value;
                _config.PrintAreaXmax = (float)PrintAreaXmax.Value;
                _config.PrintAreaYmin = (float)PrintAreaYmin.Value;
                _config.PrintAreaYmax = (float)PrintAreaYmax.Value;

                _config.IsAutoZalign = (bool)IsAutoZalign.Value;
                _config.IsAutoLevelling = (bool)IsAutoLevelling.Value;
                _config.IsUseAutoLevellingData = (bool)IsUseAutoLevellingData.Value;

                _config.IsPreheatBedBeforeABL = (bool)IsPreheatBedBeforeABL.Value;
                _config.IsPreheatBedBeforeABLManual = (bool)IsPreheatBedBeforeABLManual.Value;
                _config.PreheatingTempBedBeforeABL = (float)PreheatingTempBedBeforeABL.Value;

                _config.IsPreheatNozzleBeforeABL = (bool)IsPreheatNozzleBeforeABL.Value;
                _config.IsPreheatNozzleBeforeABLManual = (bool)IsPreheatNozzleBeforeABLManual.Value;
                _config.PreheatingTempNozzleBeforeABL = (float)PreheatingTempNozzleBeforeABL.Value;

                _config.LiftHeight = (float)LiftHeight.Value;
                _config.ClearStartZ = (float)ClearStartZ.Value;
                _config.ClearStartX = (float)ClearStartX.Value;
                _config.ClearStartY = (float)ClearStartY.Value;

                _config.PurgingFilamentLength = (float)PurgingLength.Value;
                _config.PurgingDistance = (float)PurgingDistance.Value;
                _config.PurgingDirection = Utils.EnumHelper.ParseEnum<PurgingDirectionType>(PurgingDirection.Value.ToString());
                _config.RetractionLength = (float)RetractionLength.Value;
                _config.PurgingLineCount = (int)PurgingLineCount.Value;
                _config.PurgingLineGap = (float)PurgingLineGap.Value;
                _config.PurgingSpeed = (float)PurgingSpeed.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        #region Presets
        public void PresetStart_Elf()
        {
            try
            {
                _config.Slicer = SlicerType.Cura;
                _config.PrintAreaXmin = 0;
                _config.PrintAreaXmax = 300;
                _config.PrintAreaYmin = 0;
                _config.PrintAreaYmax = 300;
                _config.IsAutoZalign = true;
                _config.IsAutoLevelling = true;
                _config.IsUseAutoLevellingData = true;
                _config.IsPreheatBedBeforeABL = true;
                _config.IsPreheatNozzleBeforeABL = true;
                _config.IsPreheatBedBeforeABLManual = true;
                _config.IsPreheatNozzleBeforeABLManual = true;
                _config.PreheatingTempBedBeforeABL = 70;
                _config.PreheatingTempNozzleBeforeABL = 110;
                _config.LiftHeight = 5;
                _config.ClearStartZ = 0.3f;
                _config.ClearStartX = 10;
                _config.ClearStartY = 10;
                _config.PurgingFilamentLength = 10;
                _config.RetractionLength = -1;
                _config.PurgingLineCount = 5;
                _config.PurgingLineGap = 5;
                _config.PurgingSpeed = 5;
                _config.PurgingDistance = 100;
                _config.PurgingDirection = PurgingDirectionType.X;
                _config.SpeedMoveXY = 80;
                _config.SpeedMoveZ = 4;

                LoadProperties();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        public void PresetEnd_Ender3Standard()
        {
            try
            {
                _config.Slicer = SlicerType.Cura;
                _config.PrintAreaXmin = 0;
                _config.PrintAreaXmax = 220;
                _config.PrintAreaYmin = 0;
                _config.PrintAreaYmax = 220;
                _config.IsAutoZalign = false;
                _config.IsAutoLevelling = false;
                _config.IsUseAutoLevellingData = false;
                _config.IsPreheatBedBeforeABL = true;
                _config.IsPreheatNozzleBeforeABL = true;
                _config.IsPreheatBedBeforeABLManual = true;
                _config.IsPreheatNozzleBeforeABLManual = true;
                _config.PreheatingTempBedBeforeABL = 70;
                _config.PreheatingTempNozzleBeforeABL = 110;
                _config.LiftHeight = 5;
                _config.ClearStartZ = 0.3f;
                _config.ClearStartX = 10;
                _config.ClearStartY = 10;
                _config.PurgingFilamentLength = 10;
                _config.RetractionLength = -1;
                _config.PurgingLineCount = 5;
                _config.PurgingLineGap = 5;
                _config.PurgingSpeed = 5;
                _config.PurgingDistance = 100;
                _config.PurgingDirection = PurgingDirectionType.X;
                _config.SpeedMoveXY = 80;
                _config.SpeedMoveZ = 4;

                LoadProperties();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        #endregion Presets
    }
}
