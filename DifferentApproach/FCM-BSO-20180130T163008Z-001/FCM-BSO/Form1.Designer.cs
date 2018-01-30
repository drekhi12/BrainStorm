namespace FCM_BSO
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblItrCount = new System.Windows.Forms.Label();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.radbtnDiabetes = new System.Windows.Forms.RadioButton();
            this.radbtnWINE = new System.Windows.Forms.RadioButton();
            this.radbtnPROTEIN = new System.Windows.Forms.RadioButton();
            this.radbtnIRIS = new System.Windows.Forms.RadioButton();
            this.lblchart1dunn = new System.Windows.Forms.Label();
            this.lbltime_taken = new System.Windows.Forms.Label();
            this.radbtnSGVP = new System.Windows.Forms.RadioButton();
            this.chart5 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart6 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.radbtnDUMMY = new System.Windows.Forms.RadioButton();
            this.lbltotaltime = new System.Windows.Forms.Label();
            this.lbldbindex_c4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbldbindex_c5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbldbindex_c6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart6)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea7.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            legend7.Title = "Clusters";
            this.chart1.Legends.Add(legend7);
            this.chart1.Location = new System.Drawing.Point(9, 72);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(376, 282);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 38);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(318, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Initiate Algorithm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(344, 38);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(318, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "Perform BSO";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblItrCount
            // 
            this.lblItrCount.AutoSize = true;
            this.lblItrCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItrCount.Location = new System.Drawing.Point(666, 36);
            this.lblItrCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblItrCount.Name = "lblItrCount";
            this.lblItrCount.Size = new System.Drawing.Size(160, 20);
            this.lblItrCount.TabIndex = 3;
            this.lblItrCount.Text = "Iteration Count = 0";
            this.lblItrCount.Visible = false;
            // 
            // chart2
            // 
            chartArea8.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            legend8.Title = "Clusters";
            this.chart2.Legends.Add(legend8);
            this.chart2.Location = new System.Drawing.Point(428, 72);
            this.chart2.Margin = new System.Windows.Forms.Padding(2);
            this.chart2.Name = "chart2";
            this.chart2.Size = new System.Drawing.Size(406, 283);
            this.chart2.TabIndex = 4;
            this.chart2.Text = "chart2";
            this.chart2.Click += new System.EventHandler(this.chart2_Click);
            // 
            // chart3
            // 
            chartArea9.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea9);
            legend9.Name = "Legend1";
            legend9.Title = "Clusters";
            this.chart3.Legends.Add(legend9);
            this.chart3.Location = new System.Drawing.Point(859, 71);
            this.chart3.Margin = new System.Windows.Forms.Padding(2);
            this.chart3.Name = "chart3";
            this.chart3.Size = new System.Drawing.Size(441, 283);
            this.chart3.TabIndex = 5;
            this.chart3.Text = "chart3";
            this.chart3.Click += new System.EventHandler(this.chart3_Click);
            // 
            // chart4
            // 
            chartArea10.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            legend10.Title = "Clusters";
            this.chart4.Legends.Add(legend10);
            this.chart4.Location = new System.Drawing.Point(458, 370);
            this.chart4.Margin = new System.Windows.Forms.Padding(2);
            this.chart4.Name = "chart4";
            this.chart4.Size = new System.Drawing.Size(376, 331);
            this.chart4.TabIndex = 6;
            this.chart4.Text = "chart4";
            this.chart4.Click += new System.EventHandler(this.chart4_Click);
            // 
            // radbtnDiabetes
            // 
            this.radbtnDiabetes.AutoSize = true;
            this.radbtnDiabetes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radbtnDiabetes.Location = new System.Drawing.Point(401, 10);
            this.radbtnDiabetes.Margin = new System.Windows.Forms.Padding(2);
            this.radbtnDiabetes.Name = "radbtnDiabetes";
            this.radbtnDiabetes.Size = new System.Drawing.Size(91, 24);
            this.radbtnDiabetes.TabIndex = 18;
            this.radbtnDiabetes.TabStop = true;
            this.radbtnDiabetes.Text = "Diabetes";
            this.radbtnDiabetes.UseVisualStyleBackColor = true;
            this.radbtnDiabetes.Click += new System.EventHandler(this.radbtnDiabetes_Click);
            // 
            // radbtnWINE
            // 
            this.radbtnWINE.AutoSize = true;
            this.radbtnWINE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radbtnWINE.Location = new System.Drawing.Point(271, 10);
            this.radbtnWINE.Margin = new System.Windows.Forms.Padding(2);
            this.radbtnWINE.Name = "radbtnWINE";
            this.radbtnWINE.Size = new System.Drawing.Size(127, 24);
            this.radbtnWINE.TabIndex = 17;
            this.radbtnWINE.TabStop = true;
            this.radbtnWINE.Text = "Wine DataSet";
            this.radbtnWINE.UseVisualStyleBackColor = true;
            this.radbtnWINE.Click += new System.EventHandler(this.radbtnWINE_Click);
            // 
            // radbtnPROTEIN
            // 
            this.radbtnPROTEIN.AutoSize = true;
            this.radbtnPROTEIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radbtnPROTEIN.Location = new System.Drawing.Point(131, 10);
            this.radbtnPROTEIN.Margin = new System.Windows.Forms.Padding(2);
            this.radbtnPROTEIN.Name = "radbtnPROTEIN";
            this.radbtnPROTEIN.Size = new System.Drawing.Size(141, 24);
            this.radbtnPROTEIN.TabIndex = 16;
            this.radbtnPROTEIN.TabStop = true;
            this.radbtnPROTEIN.Text = "Protein DataSet";
            this.radbtnPROTEIN.UseVisualStyleBackColor = true;
            this.radbtnPROTEIN.Click += new System.EventHandler(this.radbtnPROTEIN_Click);
            // 
            // radbtnIRIS
            // 
            this.radbtnIRIS.AutoSize = true;
            this.radbtnIRIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radbtnIRIS.Location = new System.Drawing.Point(10, 10);
            this.radbtnIRIS.Margin = new System.Windows.Forms.Padding(2);
            this.radbtnIRIS.Name = "radbtnIRIS";
            this.radbtnIRIS.Size = new System.Drawing.Size(124, 24);
            this.radbtnIRIS.TabIndex = 15;
            this.radbtnIRIS.Text = "IRIS DataSet";
            this.radbtnIRIS.UseVisualStyleBackColor = true;
            this.radbtnIRIS.Click += new System.EventHandler(this.radbtnIRIS_Click);
            // 
            // lblchart1dunn
            // 
            this.lblchart1dunn.AutoSize = true;
            this.lblchart1dunn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblchart1dunn.Location = new System.Drawing.Point(11, 352);
            this.lblchart1dunn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblchart1dunn.Name = "lblchart1dunn";
            this.lblchart1dunn.Size = new System.Drawing.Size(91, 20);
            this.lblchart1dunn.TabIndex = 19;
            this.lblchart1dunn.Text = "Dunn Index";
            this.lblchart1dunn.Click += new System.EventHandler(this.lblchart1dunn_Click);
            // 
            // lbltime_taken
            // 
            this.lbltime_taken.AutoSize = true;
            this.lbltime_taken.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltime_taken.Location = new System.Drawing.Point(717, 7);
            this.lbltime_taken.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbltime_taken.Name = "lbltime_taken";
            this.lbltime_taken.Size = new System.Drawing.Size(0, 29);
            this.lbltime_taken.TabIndex = 20;
            // 
            // radbtnSGVP
            // 
            this.radbtnSGVP.AutoSize = true;
            this.radbtnSGVP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radbtnSGVP.Location = new System.Drawing.Point(497, 10);
            this.radbtnSGVP.Margin = new System.Windows.Forms.Padding(2);
            this.radbtnSGVP.Name = "radbtnSGVP";
            this.radbtnSGVP.Size = new System.Drawing.Size(72, 24);
            this.radbtnSGVP.TabIndex = 21;
            this.radbtnSGVP.TabStop = true;
            this.radbtnSGVP.Text = "SGVP";
            this.radbtnSGVP.UseVisualStyleBackColor = true;
            this.radbtnSGVP.Click += new System.EventHandler(this.radbtnSGVP_Click);
            // 
            // chart5
            // 
            chartArea11.Name = "ChartArea1";
            this.chart5.ChartAreas.Add(chartArea11);
            legend11.Name = "Legend1";
            legend11.Title = "Clusters";
            this.chart5.Legends.Add(legend11);
            this.chart5.Location = new System.Drawing.Point(15, 370);
            this.chart5.Margin = new System.Windows.Forms.Padding(2);
            this.chart5.Name = "chart5";
            this.chart5.Size = new System.Drawing.Size(406, 335);
            this.chart5.TabIndex = 22;
            this.chart5.Text = "chart5";
            this.chart5.Click += new System.EventHandler(this.chart5_Click);
            // 
            // chart6
            // 
            chartArea12.Name = "ChartArea1";
            this.chart6.ChartAreas.Add(chartArea12);
            legend12.Name = "Legend1";
            legend12.Title = "Clusters";
            this.chart6.Legends.Add(legend12);
            this.chart6.Location = new System.Drawing.Point(859, 370);
            this.chart6.Margin = new System.Windows.Forms.Padding(2);
            this.chart6.Name = "chart6";
            this.chart6.Size = new System.Drawing.Size(441, 335);
            this.chart6.TabIndex = 23;
            this.chart6.Text = "chart6";
            this.chart6.Click += new System.EventHandler(this.chart6_Click);
            // 
            // radbtnDUMMY
            // 
            this.radbtnDUMMY.AutoSize = true;
            this.radbtnDUMMY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radbtnDUMMY.Location = new System.Drawing.Point(576, 10);
            this.radbtnDUMMY.Margin = new System.Windows.Forms.Padding(2);
            this.radbtnDUMMY.Name = "radbtnDUMMY";
            this.radbtnDUMMY.Size = new System.Drawing.Size(81, 24);
            this.radbtnDUMMY.TabIndex = 24;
            this.radbtnDUMMY.TabStop = true;
            this.radbtnDUMMY.Text = "Dummy";
            this.radbtnDUMMY.UseVisualStyleBackColor = true;
            this.radbtnDUMMY.CheckedChanged += new System.EventHandler(this.radbtnDUMMY_CheckedChanged);
            // 
            // lbltotaltime
            // 
            this.lbltotaltime.AutoSize = true;
            this.lbltotaltime.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotaltime.Location = new System.Drawing.Point(862, 38);
            this.lbltotaltime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbltotaltime.Name = "lbltotaltime";
            this.lbltotaltime.Size = new System.Drawing.Size(0, 24);
            this.lbltotaltime.TabIndex = 25;
            // 
            // lbldbindex_c4
            // 
            this.lbldbindex_c4.AutoSize = true;
            this.lbldbindex_c4.BackColor = System.Drawing.SystemColors.Window;
            this.lbldbindex_c4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldbindex_c4.Location = new System.Drawing.Point(102, 707);
            this.lbldbindex_c4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbldbindex_c4.Name = "lbldbindex_c4";
            this.lbldbindex_c4.Size = new System.Drawing.Size(57, 17);
            this.lbldbindex_c4.TabIndex = 26;
            this.lbldbindex_c4.Text = "dbindex";
            this.lbldbindex_c4.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 707);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "DB Index:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(455, 707);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "DB Index:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbldbindex_c5
            // 
            this.lbldbindex_c5.AutoSize = true;
            this.lbldbindex_c5.BackColor = System.Drawing.SystemColors.Window;
            this.lbldbindex_c5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldbindex_c5.Location = new System.Drawing.Point(539, 707);
            this.lbldbindex_c5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbldbindex_c5.Name = "lbldbindex_c5";
            this.lbldbindex_c5.Size = new System.Drawing.Size(57, 17);
            this.lbldbindex_c5.TabIndex = 29;
            this.lbldbindex_c5.Text = "dbindex";
            this.lbldbindex_c5.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(856, 707);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 30;
            this.label3.Text = "DB Index:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lbldbindex_c6
            // 
            this.lbldbindex_c6.AutoSize = true;
            this.lbldbindex_c6.BackColor = System.Drawing.SystemColors.Window;
            this.lbldbindex_c6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldbindex_c6.Location = new System.Drawing.Point(938, 707);
            this.lbldbindex_c6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbldbindex_c6.Name = "lbldbindex_c6";
            this.lbldbindex_c6.Size = new System.Drawing.Size(57, 17);
            this.lbldbindex_c6.TabIndex = 31;
            this.lbldbindex_c6.Text = "dbindex";
            this.lbldbindex_c6.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 733);
            this.Controls.Add(this.lbldbindex_c6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbldbindex_c5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbldbindex_c4);
            this.Controls.Add(this.lbltotaltime);
            this.Controls.Add(this.radbtnDUMMY);
            this.Controls.Add(this.chart6);
            this.Controls.Add(this.chart5);
            this.Controls.Add(this.radbtnSGVP);
            this.Controls.Add(this.lbltime_taken);
            this.Controls.Add(this.lblchart1dunn);
            this.Controls.Add(this.radbtnDiabetes);
            this.Controls.Add(this.radbtnWINE);
            this.Controls.Add(this.radbtnPROTEIN);
            this.Controls.Add(this.radbtnIRIS);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.lblItrCount);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart4);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Brain Storm Optimization";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblItrCount;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart4;
        private System.Windows.Forms.RadioButton radbtnDiabetes;
        private System.Windows.Forms.RadioButton radbtnWINE;
        private System.Windows.Forms.RadioButton radbtnPROTEIN;
        private System.Windows.Forms.RadioButton radbtnIRIS;
        private System.Windows.Forms.Label lblchart1dunn;
        private System.Windows.Forms.Label lbltime_taken;
        private System.Windows.Forms.RadioButton radbtnSGVP;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart6;
        private System.Windows.Forms.RadioButton radbtnDUMMY;
        private System.Windows.Forms.Label lbltotaltime;
        private System.Windows.Forms.Label lbldbindex_c4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbldbindex_c5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbldbindex_c6;
    }
}

