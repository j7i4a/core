namespace WindowsWLEDI
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SELECTID = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SHIP_COD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHIP_NAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHIP_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VOYAGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BERTH_COD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.I_E_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(387, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "退出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SELECTID,
            this.SHIP_COD,
            this.SHIP_NAM,
            this.SHIP_NO,
            this.VOYAGE,
            this.BERTH_COD,
            this.I_E_ID});
            this.dataGridView1.Location = new System.Drawing.Point(3, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(545, 182);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // SELECTID
            // 
            this.SELECTID.FalseValue = "0";
            this.SELECTID.HeaderText = "选";
            this.SELECTID.Name = "SELECTID";
            this.SELECTID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SELECTID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SELECTID.TrueValue = "1";
            this.SELECTID.Width = 20;
            // 
            // SHIP_COD
            // 
            this.SHIP_COD.HeaderText = "船代码";
            this.SHIP_COD.Name = "SHIP_COD";
            // 
            // SHIP_NAM
            // 
            this.SHIP_NAM.HeaderText = "船名";
            this.SHIP_NAM.Name = "SHIP_NAM";
            // 
            // SHIP_NO
            // 
            this.SHIP_NO.HeaderText = "船编号";
            this.SHIP_NO.Name = "SHIP_NO";
            this.SHIP_NO.Width = 80;
            // 
            // VOYAGE
            // 
            this.VOYAGE.HeaderText = "航次";
            this.VOYAGE.Name = "VOYAGE";
            this.VOYAGE.Width = 80;
            // 
            // BERTH_COD
            // 
            this.BERTH_COD.HeaderText = "泊位";
            this.BERTH_COD.Name = "BERTH_COD";
            this.BERTH_COD.Width = 40;
            // 
            // I_E_ID
            // 
            this.I_E_ID.HeaderText = "进出口";
            this.I_E_ID.Name = "I_E_ID";
            this.I_E_ID.Width = 80;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(164, 200);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(83, 214);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "查询";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(164, 214);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "生成文件";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(245, 214);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 16;
            this.button5.Text = "生成文件";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 244);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "海事舱单报文";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SELECTID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHIP_COD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHIP_NAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHIP_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn VOYAGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn BERTH_COD;
        private System.Windows.Forms.DataGridViewTextBoxColumn I_E_ID;
        private System.Windows.Forms.Button button5;
    }
}

