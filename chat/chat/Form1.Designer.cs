namespace chat
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.text_name = new System.Windows.Forms.TextBox();
            this.lable_phone = new System.Windows.Forms.Label();
            this.text_phone = new System.Windows.Forms.TextBox();
            this.label_price = new System.Windows.Forms.Label();
            this.text_price = new System.Windows.Forms.TextBox();
            this.label_choose = new System.Windows.Forms.Label();
            this.combo_choose = new System.Windows.Forms.ComboBox();
            this.label_chief = new System.Windows.Forms.Label();
            this.text_chief = new System.Windows.Forms.TextBox();
            this.selectbtn = new System.Windows.Forms.Button();
            this.localbtn = new System.Windows.Forms.Button();
            this.modifybtn = new System.Windows.Forms.Button();
            this.deletebtn = new System.Windows.Forms.Button();
            this.addbtn = new System.Windows.Forms.Button();
            this.importbtn = new System.Windows.Forms.Button();
            this.export_txtbtn = new System.Windows.Forms.Button();
            this.export_excelbtn = new System.Windows.Forms.Button();
            this.retbtn = new System.Windows.Forms.Button();
            this.exitbtn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.fContactID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fContactName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fContactPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fContactPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fContactlocal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sum_pricebtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名";
            // 
            // text_name
            // 
            this.text_name.Location = new System.Drawing.Point(47, 9);
            this.text_name.Name = "text_name";
            this.text_name.Size = new System.Drawing.Size(100, 21);
            this.text_name.TabIndex = 1;
            // 
            // lable_phone
            // 
            this.lable_phone.AutoSize = true;
            this.lable_phone.Location = new System.Drawing.Point(173, 12);
            this.lable_phone.Name = "lable_phone";
            this.lable_phone.Size = new System.Drawing.Size(53, 12);
            this.lable_phone.TabIndex = 2;
            this.lable_phone.Text = "电话号码";
            // 
            // text_phone
            // 
            this.text_phone.Location = new System.Drawing.Point(232, 9);
            this.text_phone.Name = "text_phone";
            this.text_phone.Size = new System.Drawing.Size(100, 21);
            this.text_phone.TabIndex = 3;
            // 
            // label_price
            // 
            this.label_price.AutoSize = true;
            this.label_price.Location = new System.Drawing.Point(353, 12);
            this.label_price.Name = "label_price";
            this.label_price.Size = new System.Drawing.Size(29, 12);
            this.label_price.TabIndex = 4;
            this.label_price.Text = "费用";
            // 
            // text_price
            // 
            this.text_price.Location = new System.Drawing.Point(388, 9);
            this.text_price.Name = "text_price";
            this.text_price.Size = new System.Drawing.Size(100, 21);
            this.text_price.TabIndex = 5;
            // 
            // label_choose
            // 
            this.label_choose.AutoSize = true;
            this.label_choose.Location = new System.Drawing.Point(12, 59);
            this.label_choose.Name = "label_choose";
            this.label_choose.Size = new System.Drawing.Size(53, 12);
            this.label_choose.TabIndex = 6;
            this.label_choose.Text = "查询条件";
            // 
            // combo_choose
            // 
            this.combo_choose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_choose.FormattingEnabled = true;
            this.combo_choose.Items.AddRange(new object[] {
            "姓名",
            "电话号码"});
            this.combo_choose.Location = new System.Drawing.Point(71, 56);
            this.combo_choose.Name = "combo_choose";
            this.combo_choose.Size = new System.Drawing.Size(121, 20);
            this.combo_choose.TabIndex = 7;
            // 
            // label_chief
            // 
            this.label_chief.AutoSize = true;
            this.label_chief.Location = new System.Drawing.Point(209, 59);
            this.label_chief.Name = "label_chief";
            this.label_chief.Size = new System.Drawing.Size(41, 12);
            this.label_chief.TabIndex = 8;
            this.label_chief.Text = "关键字";
            // 
            // text_chief
            // 
            this.text_chief.Location = new System.Drawing.Point(256, 55);
            this.text_chief.Name = "text_chief";
            this.text_chief.Size = new System.Drawing.Size(100, 21);
            this.text_chief.TabIndex = 9;
            // 
            // selectbtn
            // 
            this.selectbtn.Location = new System.Drawing.Point(14, 110);
            this.selectbtn.Name = "selectbtn";
            this.selectbtn.Size = new System.Drawing.Size(75, 23);
            this.selectbtn.TabIndex = 11;
            this.selectbtn.Text = "查询";
            this.selectbtn.UseVisualStyleBackColor = true;
            this.selectbtn.Click += new System.EventHandler(this.selectbtn_Click);
            // 
            // localbtn
            // 
            this.localbtn.Location = new System.Drawing.Point(95, 110);
            this.localbtn.Name = "localbtn";
            this.localbtn.Size = new System.Drawing.Size(75, 23);
            this.localbtn.TabIndex = 12;
            this.localbtn.Text = "归属地";
            this.localbtn.UseVisualStyleBackColor = true;
            this.localbtn.Click += new System.EventHandler(this.localbtn_Click);
            // 
            // modifybtn
            // 
            this.modifybtn.Location = new System.Drawing.Point(14, 139);
            this.modifybtn.Name = "modifybtn";
            this.modifybtn.Size = new System.Drawing.Size(75, 23);
            this.modifybtn.TabIndex = 13;
            this.modifybtn.Text = "修改";
            this.modifybtn.UseVisualStyleBackColor = true;
            this.modifybtn.Click += new System.EventHandler(this.modifybtn_Click);
            // 
            // deletebtn
            // 
            this.deletebtn.Location = new System.Drawing.Point(95, 139);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(75, 23);
            this.deletebtn.TabIndex = 14;
            this.deletebtn.Text = "删除";
            this.deletebtn.UseVisualStyleBackColor = true;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(14, 168);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(75, 23);
            this.addbtn.TabIndex = 15;
            this.addbtn.Text = "添加";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // importbtn
            // 
            this.importbtn.Location = new System.Drawing.Point(95, 168);
            this.importbtn.Name = "importbtn";
            this.importbtn.Size = new System.Drawing.Size(75, 23);
            this.importbtn.TabIndex = 16;
            this.importbtn.Text = "导入";
            this.importbtn.UseVisualStyleBackColor = true;
            this.importbtn.Click += new System.EventHandler(this.importbtn_Click);
            // 
            // export_txtbtn
            // 
            this.export_txtbtn.Location = new System.Drawing.Point(57, 206);
            this.export_txtbtn.Name = "export_txtbtn";
            this.export_txtbtn.Size = new System.Drawing.Size(75, 23);
            this.export_txtbtn.TabIndex = 17;
            this.export_txtbtn.Text = "导出txt";
            this.export_txtbtn.UseVisualStyleBackColor = true;
            this.export_txtbtn.Click += new System.EventHandler(this.export_txtbtn_Click);
            // 
            // export_excelbtn
            // 
            this.export_excelbtn.Location = new System.Drawing.Point(57, 235);
            this.export_excelbtn.Name = "export_excelbtn";
            this.export_excelbtn.Size = new System.Drawing.Size(75, 23);
            this.export_excelbtn.TabIndex = 18;
            this.export_excelbtn.Text = "导出excel";
            this.export_excelbtn.UseVisualStyleBackColor = true;
            this.export_excelbtn.Click += new System.EventHandler(this.export_excelbtn_Click);
            // 
            // retbtn
            // 
            this.retbtn.Location = new System.Drawing.Point(14, 275);
            this.retbtn.Name = "retbtn";
            this.retbtn.Size = new System.Drawing.Size(75, 23);
            this.retbtn.TabIndex = 19;
            this.retbtn.Text = "重置";
            this.retbtn.UseVisualStyleBackColor = true;
            this.retbtn.Click += new System.EventHandler(this.retbtn_Click);
            // 
            // exitbtn
            // 
            this.exitbtn.Location = new System.Drawing.Point(95, 275);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(75, 23);
            this.exitbtn.TabIndex = 20;
            this.exitbtn.Text = "退出";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fContactID,
            this.fContactName,
            this.fContactPhone,
            this.fContactPrice,
            this.fContactlocal});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(189, 97);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(300, 201);
            this.listView1.TabIndex = 21;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // fContactID
            // 
            this.fContactID.Text = "编号";
            // 
            // fContactName
            // 
            this.fContactName.Text = "姓名";
            // 
            // fContactPhone
            // 
            this.fContactPhone.Text = "电话号码";
            // 
            // fContactPrice
            // 
            this.fContactPrice.Text = "费用";
            // 
            // fContactlocal
            // 
            this.fContactlocal.Text = "归属地";
            // 
            // sum_pricebtn
            // 
            this.sum_pricebtn.Location = new System.Drawing.Point(388, 57);
            this.sum_pricebtn.Name = "sum_pricebtn";
            this.sum_pricebtn.Size = new System.Drawing.Size(75, 23);
            this.sum_pricebtn.TabIndex = 22;
            this.sum_pricebtn.Text = "费用统计";
            this.sum_pricebtn.UseVisualStyleBackColor = true;
            this.sum_pricebtn.Click += new System.EventHandler(this.sum_pricebtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(501, 333);
            this.Controls.Add(this.sum_pricebtn);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.retbtn);
            this.Controls.Add(this.export_excelbtn);
            this.Controls.Add(this.export_txtbtn);
            this.Controls.Add(this.importbtn);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.deletebtn);
            this.Controls.Add(this.modifybtn);
            this.Controls.Add(this.localbtn);
            this.Controls.Add(this.selectbtn);
            this.Controls.Add(this.text_chief);
            this.Controls.Add(this.label_chief);
            this.Controls.Add(this.combo_choose);
            this.Controls.Add(this.label_choose);
            this.Controls.Add(this.text_price);
            this.Controls.Add(this.label_price);
            this.Controls.Add(this.text_phone);
            this.Controls.Add(this.lable_phone);
            this.Controls.Add(this.text_name);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_name;
        private System.Windows.Forms.Label lable_phone;
        private System.Windows.Forms.TextBox text_phone;
        private System.Windows.Forms.Label label_price;
        private System.Windows.Forms.TextBox text_price;
        private System.Windows.Forms.Label label_choose;
        private System.Windows.Forms.ComboBox combo_choose;
        private System.Windows.Forms.Label label_chief;
        private System.Windows.Forms.TextBox text_chief;
        private System.Windows.Forms.Button selectbtn;
        private System.Windows.Forms.Button localbtn;
        private System.Windows.Forms.Button modifybtn;
        private System.Windows.Forms.Button deletebtn;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.Button importbtn;
        private System.Windows.Forms.Button export_txtbtn;
        private System.Windows.Forms.Button export_excelbtn;
        private System.Windows.Forms.Button retbtn;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button sum_pricebtn;
        private System.Windows.Forms.ColumnHeader fContactID;
        private System.Windows.Forms.ColumnHeader fContactName;
        private System.Windows.Forms.ColumnHeader fContactPhone;
        private System.Windows.Forms.ColumnHeader fContactPrice;
        private System.Windows.Forms.ColumnHeader fContactlocal;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

