namespace BTLCSharp
{
    partial class Manage
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DS = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Froms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlightNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aircraft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EconomyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BusinessPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstClassPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mtbOutbound = new System.Windows.Forms.MaskedTextBox();
            this.cboFrom = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtFlightNumber = new System.Windows.Forms.TextBox();
            this.cboTo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cboSort = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelFlight = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnEditFlight = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnImportChange = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.DS, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.15663F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.84337F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1164, 629);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // DS
            // 
            this.DS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Time,
            this.Froms,
            this.Tos,
            this.FlightNumber,
            this.Aircraft,
            this.EconomyPrice,
            this.BusinessPrice,
            this.FirstClassPrice});
            this.DS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DS.Location = new System.Drawing.Point(3, 211);
            this.DS.Name = "DS";
            this.DS.RowHeadersWidth = 51;
            this.DS.RowTemplate.Height = 24;
            this.DS.Size = new System.Drawing.Size(1158, 318);
            this.DS.TabIndex = 1;
            this.DS.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            // 
            // Time
            // 
            this.Time.DataPropertyName = "Time";
            this.Time.HeaderText = "Time";
            this.Time.MinimumWidth = 6;
            this.Time.Name = "Time";
            // 
            // Froms
            // 
            this.Froms.DataPropertyName = "Froms";
            this.Froms.HeaderText = "From";
            this.Froms.MinimumWidth = 6;
            this.Froms.Name = "Froms";
            // 
            // Tos
            // 
            this.Tos.DataPropertyName = "Tos";
            this.Tos.HeaderText = "To";
            this.Tos.MinimumWidth = 6;
            this.Tos.Name = "Tos";
            // 
            // FlightNumber
            // 
            this.FlightNumber.DataPropertyName = "FlightNumber";
            this.FlightNumber.HeaderText = "Flight Number";
            this.FlightNumber.MinimumWidth = 6;
            this.FlightNumber.Name = "FlightNumber";
            // 
            // Aircraft
            // 
            this.Aircraft.DataPropertyName = "Aircraft";
            this.Aircraft.HeaderText = "Aircraft";
            this.Aircraft.MinimumWidth = 6;
            this.Aircraft.Name = "Aircraft";
            // 
            // EconomyPrice
            // 
            this.EconomyPrice.DataPropertyName = "EconomyPrice";
            this.EconomyPrice.HeaderText = "Economy Price";
            this.EconomyPrice.MinimumWidth = 6;
            this.EconomyPrice.Name = "EconomyPrice";
            // 
            // BusinessPrice
            // 
            this.BusinessPrice.DataPropertyName = "BusinessPrice";
            this.BusinessPrice.HeaderText = "Business Price";
            this.BusinessPrice.MinimumWidth = 6;
            this.BusinessPrice.Name = "BusinessPrice";
            // 
            // FirstClassPrice
            // 
            this.FirstClassPrice.DataPropertyName = "FirstClassPrice";
            this.FirstClassPrice.HeaderText = "First Class Price";
            this.FirstClassPrice.MinimumWidth = 6;
            this.FirstClassPrice.Name = "FirstClassPrice";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1158, 202);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter by";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.4127F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.5873F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 343F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1152, 175);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.mtbOutbound);
            this.panel2.Controls.Add(this.cboFrom);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(385, 169);
            this.panel2.TabIndex = 0;
            // 
            // mtbOutbound
            // 
            this.mtbOutbound.Location = new System.Drawing.Point(118, 97);
            this.mtbOutbound.Mask = "dd/MM/yyyy";
            this.mtbOutbound.Name = "mtbOutbound";
            this.mtbOutbound.Size = new System.Drawing.Size(165, 28);
            this.mtbOutbound.TabIndex = 5;
            this.mtbOutbound.ValidatingType = typeof(System.DateTime);
            this.mtbOutbound.Enter += new System.EventHandler(this.mtbOutbound_Enter);
            this.mtbOutbound.Leave += new System.EventHandler(this.mtbOutbound_Leave);
            // 
            // cboFrom
            // 
            this.cboFrom.FormattingEnabled = true;
            this.cboFrom.Items.AddRange(new object[] {
            "Chọn điểm đi"});
            this.cboFrom.Location = new System.Drawing.Point(100, 32);
            this.cboFrom.Name = "cboFrom";
            this.cboFrom.Size = new System.Drawing.Size(183, 30);
            this.cboFrom.TabIndex = 4;
            this.cboFrom.SelectedValueChanged += new System.EventHandler(this.cboFrom_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(37, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Outbound";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtFlightNumber);
            this.panel3.Controls.Add(this.cboTo);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(394, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(411, 169);
            this.panel3.TabIndex = 1;
            this.panel3.Tag = "hjmhjm";
            // 
            // txtFlightNumber
            // 
            this.txtFlightNumber.Location = new System.Drawing.Point(131, 100);
            this.txtFlightNumber.Name = "txtFlightNumber";
            this.txtFlightNumber.Size = new System.Drawing.Size(157, 28);
            this.txtFlightNumber.TabIndex = 6;
            this.txtFlightNumber.Text = "[xx]";
            this.txtFlightNumber.Enter += new System.EventHandler(this.txtFlightNumber_Enter);
            this.txtFlightNumber.Leave += new System.EventHandler(this.txtFlightNumber_Leave);
            // 
            // cboTo
            // 
            this.cboTo.FormattingEnabled = true;
            this.cboTo.Location = new System.Drawing.Point(88, 32);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(183, 30);
            this.cboTo.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Flight Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "To";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cboSort);
            this.panel4.Controls.Add(this.btnApply);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(811, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(338, 169);
            this.panel4.TabIndex = 2;
            // 
            // cboSort
            // 
            this.cboSort.DisplayMember = "dgrg";
            this.cboSort.FormattingEnabled = true;
            this.cboSort.Items.AddRange(new object[] {
            "Date - Time",
            "Economy Price",
            "Confirmed"});
            this.cboSort.Location = new System.Drawing.Point(81, 32);
            this.cboSort.Name = "cboSort";
            this.cboSort.Size = new System.Drawing.Size(183, 30);
            this.cboSort.TabIndex = 6;
            this.cboSort.SelectedValueChanged += new System.EventHandler(this.cboSort_SelectedValueChanged);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(103, 112);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 33);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sort by";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.89154F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.10846F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 517F));
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel6, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 535);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1158, 91);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancelFlight);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 85);
            this.panel1.TabIndex = 0;
            // 
            // btnCancelFlight
            // 
            this.btnCancelFlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelFlight.Image = global::BTLCSharp.Properties.Resources._117176389_763522694447860_8125836641994537154_n;
            this.btnCancelFlight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelFlight.Location = new System.Drawing.Point(72, 23);
            this.btnCancelFlight.Name = "btnCancelFlight";
            this.btnCancelFlight.Size = new System.Drawing.Size(170, 38);
            this.btnCancelFlight.TabIndex = 0;
            this.btnCancelFlight.Text = "Cancel Flight";
            this.btnCancelFlight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelFlight.UseVisualStyleBackColor = true;
            this.btnCancelFlight.Click += new System.EventHandler(this.btnCancelFlight_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnEditFlight);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(322, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(315, 85);
            this.panel5.TabIndex = 1;
            // 
            // btnEditFlight
            // 
            this.btnEditFlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditFlight.Image = global::BTLCSharp.Properties.Resources._79325861_486871175289620_6213448970019012608_n;
            this.btnEditFlight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditFlight.Location = new System.Drawing.Point(58, 23);
            this.btnEditFlight.Name = "btnEditFlight";
            this.btnEditFlight.Size = new System.Drawing.Size(147, 38);
            this.btnEditFlight.TabIndex = 1;
            this.btnEditFlight.Text = "Edit Flight";
            this.btnEditFlight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditFlight.UseVisualStyleBackColor = true;
            this.btnEditFlight.Click += new System.EventHandler(this.btnEditFlight_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnImportChange);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(643, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(512, 85);
            this.panel6.TabIndex = 2;
            // 
            // btnImportChange
            // 
            this.btnImportChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportChange.Image = global::BTLCSharp.Properties.Resources.icons8_import_35;
            this.btnImportChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportChange.Location = new System.Drawing.Point(184, 23);
            this.btnImportChange.Name = "btnImportChange";
            this.btnImportChange.Size = new System.Drawing.Size(187, 38);
            this.btnImportChange.TabIndex = 2;
            this.btnImportChange.Text = "Import Change";
            this.btnImportChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImportChange.UseVisualStyleBackColor = true;
            this.btnImportChange.Click += new System.EventHandler(this.btnImportChange_Click);
            // 
            // Manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 629);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Manage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Flight Schedules";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnImportChange;
        private System.Windows.Forms.Button btnEditFlight;
        private System.Windows.Forms.Button btnCancelFlight;
        private System.Windows.Forms.DataGridView DS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cboFrom;
        private System.Windows.Forms.TextBox txtFlightNumber;
        private System.Windows.Forms.ComboBox cboTo;
        private System.Windows.Forms.ComboBox cboSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Froms;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tos;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlightNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aircraft;
        private System.Windows.Forms.DataGridViewTextBoxColumn EconomyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn BusinessPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstClassPrice;
        private System.Windows.Forms.MaskedTextBox mtbOutbound;
    }
}

