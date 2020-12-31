namespace ManisaCode
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbStartCode = new System.Windows.Forms.TextBox();
            this.tbEndCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGenerateCode = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnRequest = new System.Windows.Forms.Button();
            this.btnCopyStartCode = new System.Windows.Forms.Button();
            this.btnCopyEndCode = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.plot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbPreset = new System.Windows.Forms.ComboBox();
            this.ucConfigStartCode = new Config.UcConfigStartCode();
            this.ucConfigEndCode = new Config.UcConfigEndCode();
            this.label3 = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plot)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.Controls.Add(this.label2, 1, 1);
            this.tlpMain.Controls.Add(this.tbStartCode, 0, 3);
            this.tlpMain.Controls.Add(this.tbEndCode, 1, 3);
            this.tlpMain.Controls.Add(this.ucConfigStartCode, 0, 2);
            this.tlpMain.Controls.Add(this.ucConfigEndCode, 1, 2);
            this.tlpMain.Controls.Add(this.label1, 0, 1);
            this.tlpMain.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tlpMain.Controls.Add(this.panel1, 2, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(1472, 961);
            this.tlpMain.TabIndex = 0;
            this.tlpMain.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpMain_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(493, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(484, 35);
            this.label2.TabIndex = 4;
            this.label2.Text = "엔드코드";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbStartCode
            // 
            this.tbStartCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbStartCode.Location = new System.Drawing.Point(3, 664);
            this.tbStartCode.Multiline = true;
            this.tbStartCode.Name = "tbStartCode";
            this.tbStartCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbStartCode.Size = new System.Drawing.Size(484, 294);
            this.tbStartCode.TabIndex = 0;
            // 
            // tbEndCode
            // 
            this.tbEndCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEndCode.Location = new System.Drawing.Point(493, 664);
            this.tbEndCode.Multiline = true;
            this.tbEndCode.Name = "tbEndCode";
            this.tbEndCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbEndCode.Size = new System.Drawing.Size(484, 294);
            this.tbEndCode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(3, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(484, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "스타트코드";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.tlpMain.SetColumnSpan(this.flowLayoutPanel1, 3);
            this.flowLayoutPanel1.Controls.Add(this.btnGenerateCode);
            this.flowLayoutPanel1.Controls.Add(this.btnApply);
            this.flowLayoutPanel1.Controls.Add(this.btnCopyStartCode);
            this.flowLayoutPanel1.Controls.Add(this.btnCopyEndCode);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.cbPreset);
            this.flowLayoutPanel1.Controls.Add(this.btnRequest);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1472, 35);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // btnGenerateCode
            // 
            this.btnGenerateCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnGenerateCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateCode.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGenerateCode.Location = new System.Drawing.Point(0, 0);
            this.btnGenerateCode.Margin = new System.Windows.Forms.Padding(0);
            this.btnGenerateCode.Name = "btnGenerateCode";
            this.btnGenerateCode.Size = new System.Drawing.Size(100, 33);
            this.btnGenerateCode.TabIndex = 0;
            this.btnGenerateCode.Text = "코드생성";
            this.btnGenerateCode.UseVisualStyleBackColor = true;
            this.btnGenerateCode.Click += new System.EventHandler(this.btnGenerateCode_Click);
            // 
            // btnApply
            // 
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnApply.Location = new System.Drawing.Point(100, 0);
            this.btnApply.Margin = new System.Windows.Forms.Padding(0);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 33);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "저장";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnRequest
            // 
            this.btnRequest.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequest.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRequest.Location = new System.Drawing.Point(724, 0);
            this.btnRequest.Margin = new System.Windows.Forms.Padding(0);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(120, 33);
            this.btnRequest.TabIndex = 1;
            this.btnRequest.Text = "요청사항전송";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // btnCopyStartCode
            // 
            this.btnCopyStartCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyStartCode.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCopyStartCode.Location = new System.Drawing.Point(200, 0);
            this.btnCopyStartCode.Margin = new System.Windows.Forms.Padding(0);
            this.btnCopyStartCode.Name = "btnCopyStartCode";
            this.btnCopyStartCode.Size = new System.Drawing.Size(167, 33);
            this.btnCopyStartCode.TabIndex = 1;
            this.btnCopyStartCode.Text = "스타트코드복사";
            this.btnCopyStartCode.UseVisualStyleBackColor = true;
            this.btnCopyStartCode.Click += new System.EventHandler(this.btnCopyStartCode_Click);
            // 
            // btnCopyEndCode
            // 
            this.btnCopyEndCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyEndCode.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCopyEndCode.Location = new System.Drawing.Point(367, 0);
            this.btnCopyEndCode.Margin = new System.Windows.Forms.Padding(0);
            this.btnCopyEndCode.Name = "btnCopyEndCode";
            this.btnCopyEndCode.Size = new System.Drawing.Size(167, 33);
            this.btnCopyEndCode.TabIndex = 1;
            this.btnCopyEndCode.Text = "엔드코드복사";
            this.btnCopyEndCode.UseVisualStyleBackColor = true;
            this.btnCopyEndCode.Click += new System.EventHandler(this.btnCopyEndCode_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.plot);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(983, 73);
            this.panel1.Name = "panel1";
            this.tlpMain.SetRowSpan(this.panel1, 2);
            this.panel1.Size = new System.Drawing.Size(486, 885);
            this.panel1.TabIndex = 7;
            // 
            // plot
            // 
            chartArea1.Name = "ChartArea1";
            this.plot.ChartAreas.Add(chartArea1);
            this.plot.Location = new System.Drawing.Point(-48, 0);
            this.plot.Name = "plot";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.IsVisibleInLegend = false;
            series1.Name = "Series1";
            this.plot.Series.Add(series1);
            this.plot.Size = new System.Drawing.Size(373, 314);
            this.plot.TabIndex = 6;
            // 
            // cbPreset
            // 
            this.cbPreset.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbPreset.FormattingEnabled = true;
            this.cbPreset.Location = new System.Drawing.Point(600, 3);
            this.cbPreset.Name = "cbPreset";
            this.cbPreset.Size = new System.Drawing.Size(121, 27);
            this.cbPreset.TabIndex = 3;
            // 
            // ucConfigStartCode
            // 
            this.ucConfigStartCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucConfigStartCode.Location = new System.Drawing.Point(3, 73);
            this.ucConfigStartCode.Name = "ucConfigStartCode";
            this.ucConfigStartCode.Size = new System.Drawing.Size(484, 585);
            this.ucConfigStartCode.TabIndex = 1;
            // 
            // ucConfigEndCode
            // 
            this.ucConfigEndCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucConfigEndCode.Location = new System.Drawing.Point(493, 73);
            this.ucConfigEndCode.Name = "ucConfigEndCode";
            this.ucConfigEndCode.Size = new System.Drawing.Size(484, 585);
            this.ucConfigEndCode.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(537, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "프리셋";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1472, 961);
            this.Controls.Add(this.tlpMain);
            this.Name = "MainForm";
            this.Text = "ManisaCode - 스타트/엔드 코드 생성기";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TextBox tbStartCode;
        private System.Windows.Forms.TextBox tbEndCode;
        private Config.UcConfigStartCode ucConfigStartCode;
        private Config.UcConfigEndCode ucConfigEndCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnGenerateCode;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.DataVisualization.Charting.Chart plot;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCopyStartCode;
        private System.Windows.Forms.Button btnCopyEndCode;
        private System.Windows.Forms.ComboBox cbPreset;
        private System.Windows.Forms.Label label3;
    }
}

