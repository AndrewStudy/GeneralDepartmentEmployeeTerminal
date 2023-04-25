
namespace GeneralDepartmentEmployeeTerminal.Views
{
    partial class ModalWindowForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PassesListGridView = new System.Windows.Forms.DataGridView();
            this.RefreshTable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PassesListGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PassesListGridView
            // 
            this.PassesListGridView.AllowUserToAddRows = false;
            this.PassesListGridView.AllowUserToDeleteRows = false;
            this.PassesListGridView.AllowUserToResizeColumns = false;
            this.PassesListGridView.AllowUserToResizeRows = false;
            this.PassesListGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.PassesListGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.PassesListGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.PassesListGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PassesListGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.PassesListGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PassesListGridView.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.PassesListGridView.Location = new System.Drawing.Point(12, 55);
            this.PassesListGridView.MultiSelect = false;
            this.PassesListGridView.Name = "PassesListGridView";
            this.PassesListGridView.ReadOnly = true;
            this.PassesListGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PassesListGridView.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.PassesListGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PassesListGridView.ShowCellErrors = false;
            this.PassesListGridView.ShowRowErrors = false;
            this.PassesListGridView.Size = new System.Drawing.Size(776, 383);
            this.PassesListGridView.TabIndex = 0;
            this.PassesListGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PassesListGridView_CellClick);
            // 
            // RefreshTable
            // 
            this.RefreshTable.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshTable.Location = new System.Drawing.Point(619, 12);
            this.RefreshTable.Name = "RefreshTable";
            this.RefreshTable.Size = new System.Drawing.Size(169, 28);
            this.RefreshTable.TabIndex = 1;
            this.RefreshTable.Text = "Обновить список";
            this.RefreshTable.UseVisualStyleBackColor = true;
            this.RefreshTable.Click += new System.EventHandler(this.RefreshTable_Click);
            // 
            // ModalWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RefreshTable);
            this.Controls.Add(this.PassesListGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModalWindowForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Терминал сотрудника общего отдела: Список заявок";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ModalWindowForm_FormClosed);
            this.Load += new System.EventHandler(this.ModalWindowForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PassesListGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView PassesListGridView;
        private System.Windows.Forms.Button RefreshTable;
    }
}