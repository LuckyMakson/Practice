namespace HTML_Parser_WinForm
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Back = new System.Windows.Forms.Button();
            this.DataView = new System.Windows.Forms.DataGridView();
            this.ShowProducts = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).BeginInit();
            this.SuspendLayout();
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(590, 418);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(71, 20);
            this.Back.TabIndex = 2;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.ToMain_Click);
            // 
            // DataView
            // 
            this.DataView.AllowUserToDeleteRows = false;
            this.DataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataView.Location = new System.Drawing.Point(12, 12);
            this.DataView.Name = "DataView";
            this.DataView.ReadOnly = true;
            this.DataView.Size = new System.Drawing.Size(960, 400);
            this.DataView.TabIndex = 7;
            // 
            // ShowProducts
            // 
            this.ShowProducts.Location = new System.Drawing.Point(744, 418);
            this.ShowProducts.Name = "ShowProducts";
            this.ShowProducts.Size = new System.Drawing.Size(105, 20);
            this.ShowProducts.TabIndex = 8;
            this.ShowProducts.Text = "Show products";
            this.ShowProducts.UseVisualStyleBackColor = true;
            this.ShowProducts.Click += new System.EventHandler(this.GetProducts_Click);
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(667, 418);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(71, 20);
            this.Next.TabIndex = 9;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 450);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.ShowProducts);
            this.Controls.Add(this.DataView);
            this.Controls.Add(this.Back);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.DataGridView DataView;
        private System.Windows.Forms.Button ShowProducts;
        private System.Windows.Forms.Button Next;
    }
}

