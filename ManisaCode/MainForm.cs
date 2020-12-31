using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ManisaCode
{
    public partial class MainForm : Form
    {
        Config.Config _config;
        public string _revision { get; set; } = "20201231";
        public MainForm()
        {
            InitializeComponent();
        }
        public enum Preset
        {
            Elf,
            Ender3Standard
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            _config = new Config.Config();
            ucConfigStartCode.Init(ref _config);
            ucConfigEndCode.Init(ref _config);
            tlpMain.ColumnStyles[0].SizeType = SizeType.Absolute;
            tlpMain.ColumnStyles[0].Width = 400;
            tlpMain.ColumnStyles[1].SizeType = SizeType.Absolute;
            tlpMain.ColumnStyles[1].Width = 400;

            cbPreset.DataSource=Enum.GetValues(typeof(Preset));
            cbPreset.SelectedIndexChanged += CbPreset_SelectedIndexChanged;
            InitPreview(900, 900);
        }

        private void CbPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Sender = sender as ComboBox;

            switch (Utils.EnumHelper.ParseEnum<Preset>(Sender.SelectedItem.ToString()))
            {
                case Preset.Elf:
                    ucConfigStartCode.PresetStart_Elf();
                    ucConfigEndCode.PresetEnd_Elf();
                    break;
                case Preset.Ender3Standard:
                    ucConfigStartCode.PresetEnd_Ender3Standard();
                    ucConfigEndCode.PresetEnd_Ender3Standard();
                    break;
                default:
                    break;
            }
        }

        ChartArea chartArea;
        Series series;
        private void InitPreview(int width, int height)
        {
            
            plot.Width = width;
            plot.Height = height;
            plot.ChartAreas.Clear();
            plot.Series.Clear();
            plot.Dock = DockStyle.Fill;
            chartArea = new ChartArea();
            chartArea.Name = "Bed";
            SetAxis(chartArea.AxisX, _config.PrintAreaXmin, _config.PrintAreaXmax, 50, ChartDashStyle.Dot);
            SetAxis(chartArea.AxisY, _config.PrintAreaYmin, _config.PrintAreaYmax, 50, ChartDashStyle.Dot);

            plot.ChartAreas.Add(chartArea);
            series = new Series();
            
            series.ChartArea = "Bed";
            plot.Series.Add(series);
            series.Points.AddXY(0, 0);
            series.ChartType = SeriesChartType.Line;
        }
        private void SetAxis(Axis axis, double min, double max, double interval, ChartDashStyle dash)
        {
            axis.Minimum = min;
            axis.Maximum = max;
            axis.MajorGrid.LineDashStyle = dash;
            axis.MajorGrid.LineColor = Color.Gainsboro;
            axis.MajorGrid.Interval = interval;
            axis.MajorTickMark.Interval = interval;
            axis.LabelStyle.Interval = interval;
        }
        #region Code Generator
        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            InitPreview(900, 900);
            GenerateStartCode();
            GenerateEndCode();
        }
        enum GapDirection
        {
            X,
            Y
        }
        private void GenerateStartCode()
        {
            ucConfigStartCode.Save();
            ucConfigEndCode.Save();
            plot.Series.Clear();
            _lastX = 0;
            _lastY = 0;
            StringBuilder sb = new StringBuilder();
            string preheatBed = string.Empty;
            string preheatNozzle = string.Empty;
            StringBuilder heatBed = new StringBuilder();
            StringBuilder heatNozzle = new StringBuilder();
            string placeholderBedTemp = string.Empty;
            string placeholderNozzleTemp = string.Empty;
            switch (_config.Slicer)
            {
                case Config.Enums.SlicerType.Cura:
                    placeholderBedTemp = "{material_bed_temperature_layer_0}";
                    placeholderNozzleTemp = "{material_nozzle_temperature_layer_0}";
                    break;
                case Config.Enums.SlicerType.Simplify3D:
                    placeholderBedTemp = "[bed0_temperature]";
                    placeholderNozzleTemp = "[extruder0_temperature]";
                    break;
                case Config.Enums.SlicerType.PrusaSlicer:
                    placeholderBedTemp = "[first_layer_bed_temperature]";
                    placeholderNozzleTemp = "[first_layer_temperature]";
                    break;
                default:
                    break;
            }
            if (_config.IsPreheatBedBeforeABL)
            {
                if (_config.IsPreheatBedBeforeABLManual)
                {
                    preheatBed = $"M140 S{_config.PreheatingTempBedBeforeABL}";
                }
                else
                {
                    preheatBed = $"M140 S{placeholderBedTemp}";
                }
            }
            if (_config.IsPreheatNozzleBeforeABL)
            {
                if (_config.IsPreheatNozzleBeforeABLManual)
                {
                    preheatNozzle = $"M104 S{_config.PreheatingTempNozzleBeforeABL}";
                }
                else
                {
                    preheatNozzle = $"M104 S{placeholderNozzleTemp}";
                }
            }
            Append(heatBed, $"M140 S{placeholderBedTemp}");
            heatBed.Append($"M190 S{placeholderBedTemp}");
            Append(heatNozzle, $"M104 S{placeholderNozzleTemp}");
            heatNozzle.Append($"M109 S{placeholderNozzleTemp}");

            if (_config.IsPreheatBedBeforeABL)
            {
                Append(sb, preheatBed);
            }
            if (_config.IsPreheatNozzleBeforeABL)
            {
                Append(sb, preheatNozzle);
            }
            Append(sb, "G90");
            if (_config.IsAutoZalign)
            {
                Append(sb, "G34");
            }
            if (_config.IsAutoLevelling)
            {
                Append(sb, "G29");
            }
            else
            {
                Append(sb, "G28");
            }
            if (_config.IsUseAutoLevellingData)
            {
                Append(sb, "M420 S1");
            }
            Append(sb, $"G1 Z{_config.LiftHeight} F{_config.SpeedMoveZ * 60}");
            Append(sb, $"G1 X{_config.ClearStartX} Y{_config.ClearStartY} F{_config.SpeedMoveXY * 60}");
            PlotSimul(MoveType.Move, _lastX, _lastY, _config.ClearStartX, _config.ClearStartY);
            Append(sb, heatBed.ToString());
            Append(sb, heatNozzle.ToString());
            Append(sb, $"G1 Z{_config.ClearStartZ} F{_config.SpeedMoveZ * 60}");
            Append(sb, "G92 E0");
            
            if (_config.PurgingLineCount<0)
            {
                _config.PurgingLineCount = 1;
            }
            float startX, startY, endX, endY, swapX, swapY;

            startX = _config.ClearStartX;
            startY = _config.ClearStartY;
            endX = _config.ClearStartX;
            endY = _config.ClearStartY;
            switch (_config.PurgingDirection)
            {
                case Config.Enums.PurgingDirectionType.X:
                    endX = startX + _config.PurgingDistance;
                    endY = startY;
                    break;
                case Config.Enums.PurgingDirectionType.Y:
                    endX = startX; 
                    endY=startY+ _config.PurgingDistance;
                    break;
                default:
                    break;
            }

            for (int i = 1; i < _config.PurgingLineCount; i++)
            {
                Append(sb, $"G1 X{endX} Y{endY} E{_config.PurgingFilamentLength} F{_config.PurgingSpeed * 60}");
                PlotSimul(MoveType.Purge, _lastX, _lastY, endX, endY);
                Append(sb, "G92 E0");
                switch (_config.PurgingDirection)
                {
                    case Config.Enums.PurgingDirectionType.X:
                        endY += _config.PurgingLineGap;
                        Append(sb, $"G1 X{endX} Y{endY} E{_config.PurgingFilamentLength} F{_config.PurgingSpeed * 60}");
                        PlotSimul(MoveType.Purge, _lastX, _lastY, endX, endY);
                        Append(sb, "G92 E0");
                        swapX = endX;
                        endX = startX;
                        startX = swapX;
                        break;
                    case Config.Enums.PurgingDirectionType.Y:
                        endX += _config.PurgingLineGap;
                        Append(sb, $"G1 X{endX} Y{endY} E{_config.PurgingFilamentLength} F{_config.SpeedMoveE * 60}");
                        PlotSimul(MoveType.Purge, _lastX, _lastY, endX, endY);
                        Append(sb, "G92 E0");
                        swapY = endY;
                        endY = startY;
                        startY = swapY;
                        break;
                    default:
                        break;
                }

            }

            //퍼징
            var retractionAfterPurging = _config.RetractionLength;
            if (retractionAfterPurging > 0)
            {
                retractionAfterPurging *= -1;
            }
            Append(sb, $"G92 E{retractionAfterPurging} F{_config.SpeedRetraction * 60}");
            Append(sb, "G92 E0");
            Append(sb, $"G1 Z{_config.LiftHeight} F{_config.SpeedMoveZ * 60}");
            tbStartCode.Text = sb.ToString();
        }
        private void GenerateEndCode()
        {
            StringBuilder sb = new StringBuilder();
            var retractionLength = _config.RetractionLength;
            if (retractionLength > 0)
            {
                retractionLength *= -1;
            }
            
            Append(sb, $"G92 E{retractionLength} F{_config.SpeedRetraction * 60}");
            Append(sb, "G92 E0");
            Append(sb, $"M140 S{_config.EndTempBed}");
            if (_config.EndTempBed>0)
            {
                Append(sb, $"M190 S{_config.EndTempBed}");
            }
            Append(sb, $"M104 S{_config.EndTempNozzle}");
            if (_config.EndTempNozzle > 0)
            {
                Append(sb, $"M109 S{_config.EndTempNozzle}");
            }
            Append(sb, "G91");
            Append(sb, $"G1 Z{_config.EndLiftZ} F{_config.SpeedMoveZ * 60}");
            Append(sb, "G90");
            
            switch (_config.MoveAxisAfterEnd_X)
            {
                case Config.Enums.MoveAxisAfterEndType.홈:
                    Append(sb, "G28 X");
                    break;
                case Config.Enums.MoveAxisAfterEndType.지정위치:
                    Append(sb, $"G1 X{_config.EndPosX} F{_config.SpeedMoveXY * 60}");
                    break;
                case Config.Enums.MoveAxisAfterEndType.이동안함:
                    break;
                default:
                    break;
            }
            switch (_config.MoveAxisAfterEnd_Y)
            {
                case Config.Enums.MoveAxisAfterEndType.홈:
                    Append(sb, "G28 Y");
                    break;
                case Config.Enums.MoveAxisAfterEndType.지정위치:
                    Append(sb, $"G1 Y{_config.EndPosX} F{_config.SpeedMoveXY * 60}");
                    break;
                case Config.Enums.MoveAxisAfterEndType.이동안함:
                    break;
                default:
                    break;
            }
            if (_config.IsMotorOff)
            {
                Append(sb, "M84");
            }
            if (_config.IsFanOff)
            {
                Append(sb, $"G4 S{_config.FanOffWaitTime}");
                Append(sb, "M107");
            }
            tbEndCode.Text = sb.ToString();

        }

        #endregion Code Generator
        private static void Append(StringBuilder sb, string text)
        {
            sb.Append(text);
            sb.AppendLine();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ucConfigStartCode.Save();
            ucConfigEndCode.Save();
            _config.SaveToFile();
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            //https://docs.google.com/forms/d/1MmjkzOThd5EY81itcsdWzEyIDuKiV9y6ZVVtMY_O3_M/edit
            var text = "본 프로그램은 2020년 메이커 창작프로젝트(자율) 과제에 선정되어 제작되었습니다.\n" +
                "요청사항을 남겨 주시면 최대한 반영해서 개선하도록 하겠습니다.\n" +
                "2020년 12월 31일 과제 완료 후 공개하여 모두 사용하실 수 있도록 하겠습니다.\n" +
                "요청사항 전송폼으로 이동하시겠습니까?";
            var result = MessageBox.Show(text, "요청사항 전송", MessageBoxButtons.YesNo);
            if (result== DialogResult.Yes)
            {
                WebBrowser webBrowser = new WebBrowser();
                System.Diagnostics.Process.Start("https://docs.google.com/forms/d/1MmjkzOThd5EY81itcsdWzEyIDuKiV9y6ZVVtMY_O3_M");
            }
        }

        private void tlpMain_SizeChanged(object sender, EventArgs e)
        {
            MessageBox.Show($"Size Changed {((TableLayoutPanel)sender).Width}, {((TableLayoutPanel)sender).Height}");
        }

        private void tlpMain_Paint(object sender, PaintEventArgs e)
        {

        }
        private Series SetSeries(SeriesChartType type, Color color, int width, ChartDashStyle style)
        {
            Series serie = new Series();
            serie.ChartType = type;
            serie.Color = color;
            serie.BorderWidth = width;
            serie.BorderDashStyle = style;
            return serie;
        }
        enum MoveType
        {
            Move,
            Purge
        }
        float _lastX, _lastY;
        private async void PlotSimul(MoveType moveType, float startX, float startY, float endX, float endY)
        {
            int length = 5;
            _lastX = endX;
            _lastY = endY;
            ChartDashStyle style;
            int width = 0;
            switch (moveType)
            {
                case MoveType.Move:
                    style = ChartDashStyle.Dot;
                    width = 1;
                    break;
                case MoveType.Purge:
                    style = ChartDashStyle.Solid;
                    width = 3;
                    break;
                default:
                    style = ChartDashStyle.Solid;
                    width = 3;
                    break;
            }
            var line = SetSeries(SeriesChartType.Line, Color.Red, width, style);
            
            plot.Series.Add(line);
            line.Points.AddXY(startX, startY);
            await Task.Delay(10);
            line.Points.AddXY(endX, endY);
            var stepX = (endX - startX) / length;
            var stepY = (endY - startY) / length;
            for (int i = 0; i < length; i++)
            {
                line.Points.AddXY(startX+ stepX*i, startY+ stepY*i);
                await Task.Delay(1000);
            }
        }

        private void btnCopyStartCode_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(tbStartCode.Text);
            }
            catch (Exception)
            {

            }
        }

        private void btnCopyEndCode_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(tbEndCode.Text);
            }
            catch (Exception)
            {

            }
        }

        private void btnPreset_Click(object sender, EventArgs e)
        {
            ucConfigStartCode.PresetStart_Elf();
        }

        private async void btnSimulStart_Click(object sender, EventArgs e)
        {
            try
            {
                series.Points.Clear();
                var line1 = SetSeries(SeriesChartType.Line, Color.Red, 3, ChartDashStyle.Solid);
                plot.Series.Add(line1);
                for (int i = 0; i < 100; i++)
                {
                    line1.Points.AddXY(100, 100+i);
                    await Task.Delay(10);
                }
                var line2 = SetSeries(SeriesChartType.Line, Color.Red, 1, ChartDashStyle.Dot);
                plot.Series.Add(line2);
                for (int i = 0; i < 100; i++)
                {
                    line2.Points.AddXY(100+i, 200);
                    await Task.Delay(10);
                }

            }
            catch (Exception)
            {

            }
        }
    }
}
