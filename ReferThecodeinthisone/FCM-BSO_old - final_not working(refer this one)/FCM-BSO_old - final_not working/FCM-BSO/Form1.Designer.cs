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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblItrCount = new System.Windows.Forms.Label();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.radbtnDiabetes = new System.Windows.Forms.RadioButton();
            this.radbtnWINE = new System.Windows.Forms.RadioButton();
            this.radbtnPROTEIN = new System.Windows.Forms.RadioButton();
            this.radbtnIRIS = new System.Windows.Forms.RadioButton();
            this.lblchart1dunn = new System.Windows.Forms.Label();
            this.lbltime_taken = new System.Windows.Forms.Label();
            this.radbtnSGVP = new System.Windows.Forms.RadioButton();
            this.chart5 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labeldb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart5)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 48);
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
            this.button2.Location = new System.Drawing.Point(344, 48);
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
            this.lblItrCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItrCount.Location = new System.Drawing.Point(715, 51);
            this.lblItrCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblItrCount.Name = "lblItrCount";
            this.lblItrCount.Size = new System.Drawing.Size(210, 26);
            this.lblItrCount.TabIndex = 3;
            this.lblItrCount.Text = "Iteration Count = 0";
            this.lblItrCount.Visible = false;
            // 
            // chart4
            // 
            chartArea1.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            legend1.Title = "Clusters";
            this.chart4.Legends.Add(legend1);
            this.chart4.Location = new System.Drawing.Point(13, 98);
            this.chart4.Margin = new System.Windows.Forms.Padding(2);
            this.chart4.Name = "chart4";
            this.chart4.Size = new System.Drawing.Size(649, 491);
            this.chart4.TabIndex = 6;
            this.chart4.Text = "chart4";
            this.chart4.Click += new System.EventHandler(this.chart4_Click);
            // 
            // radbtnDiabetes
            // 
            this.radbtnDiabetes.AutoSize = true;
            this.radbtnDiabetes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radbtnDiabetes.Location = new System.Drawing.Point(518, 10);
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
            this.radbtnWINE.Location = new System.Drawing.Point(344, 10);
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
            this.radbtnPROTEIN.Location = new System.Drawing.Point(159, 10);
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
            this.lblchart1dunn.Location = new System.Drawing.Point(10, 623);
            this.lblchart1dunn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblchart1dunn.Name = "lblchart1dunn";
            this.lblchart1dunn.Size = new System.Drawing.Size(91, 20);
            this.lblchart1dunn.TabIndex = 19;
            this.lblchart1dunn.Text = "Dunn Index";
            // 
            // lbltime_taken
            // 
            this.lbltime_taken.AutoSize = true;
            this.lbltime_taken.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltime_taken.Location = new System.Drawing.Point(753, 10);
            this.lbltime_taken.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbltime_taken.Name = "lbltime_taken";
            this.lbltime_taken.Size = new System.Drawing.Size(57, 24);
            this.lbltime_taken.TabIndex = 20;
            this.lbltime_taken.Text = "Time";
            // 
            // radbtnSGVP
            // 
            this.radbtnSGVP.AutoSize = true;
            this.radbtnSGVP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radbtnSGVP.Location = new System.Drawing.Point(664, 10);
            this.radbtnSGVP.Margin = new System.Windows.Forms.Padding(2);
            this.radbtnSGVP.Name = "radbtnSGVP";
            this.radbtnSGVP.Size = new System.Drawing.Size(72, 24);
            this.radbtnSGVP.TabIndex = 21;
            this.radbtnSGVP.TabStop = true;
            this.radbtnSGVP.Text = "SGVP";
            this.radbtnSGVP.UseVisualStyleBackColor = true;
            this.radbtnSGVP.CheckedChanged += new System.EventHandler(this.radbtnSGVP_CheckedChanged);
            this.radbtnSGVP.Click += new System.EventHandler(this.radbtnSGVP_Click);
            // 
            // chart5
            // 
            chartArea2.Name = "ChartArea1";
            this.chart5.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            legend2.Title = "Clusters";
            this.chart5.Legends.Add(legend2);
            this.chart5.Location = new System.Drawing.Point(680, 98);
            this.chart5.Margin = new System.Windows.Forms.Padding(2);
            this.chart5.Name = "chart5";
            this.chart5.Size = new System.Drawing.Size(532, 491);
            this.chart5.TabIndex = 22;
            this.chart5.Text = "chart5";
            this.chart5.Click += new System.EventHandler(this.chart5_Click);
            // 
            // labeldb
            // 
            this.labeldb.AutoSize = true;
            this.labeldb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldb.Location = new System.Drawing.Point(10, 644);
            this.labeldb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labeldb.Name = "labeldb";
            this.labeldb.Size = new System.Drawing.Size(87, 24);
            this.labeldb.TabIndex = 19;
            this.labeldb.Text = "DB Index";
            this.labeldb.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 602);
            this.Controls.Add(this.labeldb);
            this.Controls.Add(this.chart5);
            this.Controls.Add(this.radbtnSGVP);
            this.Controls.Add(this.lbltime_taken);
            this.Controls.Add(this.lblchart1dunn);
            this.Controls.Add(this.radbtnDiabetes);
            this.Controls.Add(this.radbtnWINE);
            this.Controls.Add(this.radbtnPROTEIN);
            this.Controls.Add(this.radbtnIRIS);
            this.Controls.Add(this.chart4);
            this.Controls.Add(this.lblItrCount);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Brain Storm Optimization";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblItrCount;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart4;
        private System.Windows.Forms.RadioButton radbtnDiabetes;
        private System.Windows.Forms.RadioButton radbtnWINE;
        private System.Windows.Forms.RadioButton radbtnPROTEIN;
        private System.Windows.Forms.RadioButton radbtnIRIS;
        private System.Windows.Forms.Label lblchart1dunn;
        private System.Windows.Forms.Label lbltime_taken;
        private System.Windows.Forms.RadioButton radbtnSGVP;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart5;
        private System.Windows.Forms.Label labeldb;
    }
}

