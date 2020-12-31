using System;
using System.Windows.Forms;
using MyHelpers;
using static Config.Enums;

namespace Config
{
    public partial class UcConfigEndCode : UserControl
    {
        public Config _config;
        public UcConfigEndCode()
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
        CustomProperty EndRetractionLength;
        CustomProperty EndRetractionSpeed;
        CustomProperty MoveAxisAfterEnd_X;
        CustomProperty MoveAxisAfterEnd_Y;
        CustomProperty EndPosX;
        CustomProperty EndPosY;
        CustomProperty EndLiftZ;
        CustomProperty EndTempBed;
        CustomProperty EndTempNozzle;
        CustomProperty IsMotorOff;
        CustomProperty IsFanOff;
        CustomProperty FanOffWaitTime;
        #endregion Properties
        private void LoadProperties()
        {
            if (customClass == null)
            {
                customClass = new CustomClass();
                propertyGrid.SelectedObject = customClass;
            }
            string strCategory = "1. 종료 후 리트렉션";
            bool isVisibleCategory = true;

            Utils.BaseHelper.MakePropertyItem(ref customClass, ref EndRetractionLength, strCategory, "종료 후 리트랙션 길이", "   1. 리트랙션 길이", _config.EndRetractionLength, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref EndRetractionSpeed, strCategory, "종료 후 리트랙션 속도(mm/s)", "   2. 리트랙션 속도(mm/s)", _config.EndRetractionSpeed, false, isVisibleCategory);
            strCategory = "2. 종료 후 헤드 이동";
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref MoveAxisAfterEnd_X, strCategory, "출력 종료 후 X축 이동 위치", "   1. 종료 후 노즐 위치 X", _config.MoveAxisAfterEnd_X, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref EndPosX, strCategory, "출력 종료 후 노즐이 이동할 X위치를 지정합니다.(mm)", "   2. 종료 후 노즐 위치 X", _config.EndPosX, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref MoveAxisAfterEnd_Y, strCategory, "출력 종료 후 Y축 이동 위치", "   3. 종료 후 노즐 위치 Y", _config.MoveAxisAfterEnd_Y, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref EndPosY, strCategory, "출력 종료 후 노즐이 이동할 Y위치를 지정합니다.(mm)", "   4. 종료 후 노즐 위치 Y", _config.EndPosY, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref EndLiftZ, strCategory, "출력물 보호를 위해 설정값만큼 노즐을 들어올립니다.(mm)", "   5. 종료 후 Z 이동", _config.EndLiftZ, false, isVisibleCategory);

            strCategory = "3. 종료 후 온도 설정";
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref EndTempBed, strCategory, "출력 종료 후 유지할 온도", "   1. 베드 온도", _config.EndTempBed, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref EndTempNozzle, strCategory, "출력 종료 후 유지할 온도", "   2. 노즐 온도", _config.EndTempNozzle, false, isVisibleCategory);
            
            strCategory = "4. 종료 후 처리";
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref IsMotorOff, strCategory, "출력 종료 후 모터 꺼짐 유무\n종료 후 베드 낙하를 예방하기 위해서는 False로 설정합니다.", "   1. 종료 후 모터 꺼짐", _config.IsMotorOff, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref IsFanOff, strCategory, "출력 종료 후 팬 꺼짐 유무\n지정된 시간 후 팬을 끕니다.", "   2. 종료 후 팬 꺼짐", _config.IsFanOff, false, isVisibleCategory);
            Utils.BaseHelper.MakePropertyItem(ref customClass, ref FanOffWaitTime, strCategory, "팬을 끄기 전 대기 시간입니다.(단위:초)", "   3. 팬 꺼짐 대기 시간", _config.FanOffWaitTime, false, isVisibleCategory);

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
                _config.EndRetractionLength = (float)EndRetractionLength.Value;
                _config.EndRetractionSpeed = (int)EndRetractionSpeed.Value;
                _config.MoveAxisAfterEnd_X = Utils.EnumHelper.ParseEnum<MoveAxisAfterEndType>(MoveAxisAfterEnd_X.Value.ToString());
                _config.EndPosX = (float)EndPosX.Value;
                _config.MoveAxisAfterEnd_Y = Utils.EnumHelper.ParseEnum<MoveAxisAfterEndType>(MoveAxisAfterEnd_Y.Value.ToString());
                _config.EndPosY = (float)EndPosY.Value;
                _config.EndLiftZ = (float)EndLiftZ.Value;
                _config.EndTempBed = (float)EndTempBed.Value;
                _config.EndTempNozzle = (float)EndTempNozzle.Value;
                _config.IsMotorOff = (bool)IsMotorOff.Value;
                _config.IsFanOff = (bool)IsFanOff.Value;
                _config.FanOffWaitTime = (int)FanOffWaitTime.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }
        #region Presets
        public void PresetEnd_Elf()
        {
            _config.EndRetractionLength = 1;
            _config.EndRetractionSpeed = 30;
            _config.MoveAxisAfterEnd_X = MoveAxisAfterEndType.홈;
            _config.EndPosX = 0;
            _config.MoveAxisAfterEnd_Y = MoveAxisAfterEndType.홈;
            _config.EndPosY = 0;
            _config.EndLiftZ = 5;
            _config.EndTempBed = 0;
            _config.EndTempNozzle = 0;
            _config.IsMotorOff = true;
            _config.IsFanOff = false;
            _config.FanOffWaitTime = 0;
        }
        public void PresetEnd_Ender3Standard()
        {
            _config.EndRetractionLength = 5;
            _config.EndRetractionSpeed = 30;
            _config.MoveAxisAfterEnd_X = MoveAxisAfterEndType.홈;
            _config.EndPosX = 0;
            _config.MoveAxisAfterEnd_Y = MoveAxisAfterEndType.홈;
            _config.EndPosY = 0;
            _config.EndLiftZ = 5;
            _config.EndTempBed = 0;
            _config.EndTempNozzle = 0;
            _config.IsMotorOff = true;
            _config.IsFanOff = false;
            _config.FanOffWaitTime = 0;
        }
        #endregion presets


    }
}
