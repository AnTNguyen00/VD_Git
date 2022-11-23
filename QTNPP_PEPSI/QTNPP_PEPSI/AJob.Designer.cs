
namespace QTNPP_PEPSI
{
    partial class AJob
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ckDone = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtCongViec = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.nmTu_Gio = new System.Windows.Forms.NumericUpDown();
            this.nmTu_Phut = new System.Windows.Forms.NumericUpDown();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.nmDen_Phut = new System.Windows.Forms.NumericUpDown();
            this.nmDen_Gio = new System.Windows.Forms.NumericUpDown();
            this.cbbTrangThai = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.command1 = new DevComponents.DotNetBar.Command(this.components);
            this.btnSua = new DevComponents.DotNetBar.ButtonX();
            this.btnXoa = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.nmTu_Gio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTu_Phut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDen_Phut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDen_Gio)).BeginInit();
            this.SuspendLayout();
            // 
            // ckDone
            // 
            // 
            // 
            // 
            this.ckDone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ckDone.Location = new System.Drawing.Point(11, 11);
            this.ckDone.Name = "ckDone";
            this.ckDone.Size = new System.Drawing.Size(27, 23);
            this.ckDone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ckDone.TabIndex = 0;
            this.ckDone.CheckedChanged += new System.EventHandler(this.ckDone_CheckedChanged);
            // 
            // txtCongViec
            // 
            // 
            // 
            // 
            this.txtCongViec.Border.Class = "TextBoxBorder";
            this.txtCongViec.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCongViec.Location = new System.Drawing.Point(44, 12);
            this.txtCongViec.Name = "txtCongViec";
            this.txtCongViec.PreventEnterBeep = true;
            this.txtCongViec.Size = new System.Drawing.Size(440, 22);
            this.txtCongViec.TabIndex = 1;
            // 
            // nmTu_Gio
            // 
            this.nmTu_Gio.Location = new System.Drawing.Point(44, 49);
            this.nmTu_Gio.Name = "nmTu_Gio";
            this.nmTu_Gio.Size = new System.Drawing.Size(56, 22);
            this.nmTu_Gio.TabIndex = 2;
            // 
            // nmTu_Phut
            // 
            this.nmTu_Phut.Location = new System.Drawing.Point(106, 48);
            this.nmTu_Phut.Name = "nmTu_Phut";
            this.nmTu_Phut.Size = new System.Drawing.Size(56, 22);
            this.nmTu_Phut.TabIndex = 3;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(168, 49);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(33, 23);
            this.labelX1.TabIndex = 25;
            this.labelX1.Text = "Đến";
            // 
            // nmDen_Phut
            // 
            this.nmDen_Phut.Location = new System.Drawing.Point(269, 47);
            this.nmDen_Phut.Name = "nmDen_Phut";
            this.nmDen_Phut.Size = new System.Drawing.Size(56, 22);
            this.nmDen_Phut.TabIndex = 27;
            // 
            // nmDen_Gio
            // 
            this.nmDen_Gio.Location = new System.Drawing.Point(207, 48);
            this.nmDen_Gio.Name = "nmDen_Gio";
            this.nmDen_Gio.Size = new System.Drawing.Size(56, 22);
            this.nmDen_Gio.TabIndex = 26;
            // 
            // cbbTrangThai
            // 
            this.cbbTrangThai.DisplayMember = "Text";
            this.cbbTrangThai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbTrangThai.FormattingEnabled = true;
            this.cbbTrangThai.ItemHeight = 16;
            this.cbbTrangThai.Location = new System.Drawing.Point(331, 48);
            this.cbbTrangThai.Name = "cbbTrangThai";
            this.cbbTrangThai.Size = new System.Drawing.Size(153, 22);
            this.cbbTrangThai.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbTrangThai.TabIndex = 28;
            // 
            // command1
            // 
            this.command1.Name = "command1";
            // 
            // btnSua
            // 
            this.btnSua.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSua.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSua.Location = new System.Drawing.Point(499, 12);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(63, 22);
            this.btnSua.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSua.TabIndex = 29;
            this.btnSua.Text = "Cập nhật";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXoa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXoa.Location = new System.Drawing.Point(499, 47);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(63, 22);
            this.btnXoa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXoa.TabIndex = 30;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // AJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.cbbTrangThai);
            this.Controls.Add(this.nmDen_Phut);
            this.Controls.Add(this.nmDen_Gio);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.nmTu_Phut);
            this.Controls.Add(this.nmTu_Gio);
            this.Controls.Add(this.txtCongViec);
            this.Controls.Add(this.ckDone);
            this.Name = "AJob";
            this.Size = new System.Drawing.Size(579, 82);
            ((System.ComponentModel.ISupportInitialize)(this.nmTu_Gio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTu_Phut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDen_Phut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDen_Gio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.CheckBoxX ckDone;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCongViec;
        private System.Windows.Forms.NumericUpDown nmTu_Gio;
        private System.Windows.Forms.NumericUpDown nmTu_Phut;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.NumericUpDown nmDen_Phut;
        private System.Windows.Forms.NumericUpDown nmDen_Gio;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbTrangThai;
        private DevComponents.DotNetBar.Command command1;
        private DevComponents.DotNetBar.ButtonX btnSua;
        private DevComponents.DotNetBar.ButtonX btnXoa;
    }
}
