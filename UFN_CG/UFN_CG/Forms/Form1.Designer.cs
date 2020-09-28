namespace UFN_CG
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvas = new System.Windows.Forms.Panel();
            this.btn_Translate = new System.Windows.Forms.Button();
            this.Value_Tx = new System.Windows.Forms.NumericUpDown();
            this.Value_Ty = new System.Windows.Forms.NumericUpDown();
            this.Value_Tz = new System.Windows.Forms.NumericUpDown();
            this.Value_Rz = new System.Windows.Forms.NumericUpDown();
            this.Value_Ry = new System.Windows.Forms.NumericUpDown();
            this.Value_Rx = new System.Windows.Forms.NumericUpDown();
            this.btn_Rotate = new System.Windows.Forms.Button();
            this.Rz = new System.Windows.Forms.NumericUpDown();
            this.Ry = new System.Windows.Forms.NumericUpDown();
            this.Rx = new System.Windows.Forms.NumericUpDown();
            this.Sz = new System.Windows.Forms.NumericUpDown();
            this.Sy = new System.Windows.Forms.NumericUpDown();
            this.Sx = new System.Windows.Forms.NumericUpDown();
            this.Pz = new System.Windows.Forms.NumericUpDown();
            this.Py = new System.Windows.Forms.NumericUpDown();
            this.Px = new System.Windows.Forms.NumericUpDown();
            this.lblPosition = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Value_Ar = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Value_Tx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Value_Ty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Value_Tz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Value_Rz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Value_Ry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Value_Rx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Py)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Px)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Value_Ar)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(12, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(863, 552);
            this.canvas.TabIndex = 0;
            // 
            // btn_Translate
            // 
            this.btn_Translate.Location = new System.Drawing.Point(881, 282);
            this.btn_Translate.Name = "btn_Translate";
            this.btn_Translate.Size = new System.Drawing.Size(75, 20);
            this.btn_Translate.TabIndex = 1;
            this.btn_Translate.Text = "Translate";
            this.btn_Translate.UseVisualStyleBackColor = true;
            this.btn_Translate.Click += new System.EventHandler(this.btn_Translate_Click);
            // 
            // Value_Tx
            // 
            this.Value_Tx.Location = new System.Drawing.Point(962, 282);
            this.Value_Tx.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Value_Tx.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.Value_Tx.Name = "Value_Tx";
            this.Value_Tx.Size = new System.Drawing.Size(37, 20);
            this.Value_Tx.TabIndex = 2;
            // 
            // Value_Ty
            // 
            this.Value_Ty.Location = new System.Drawing.Point(1005, 282);
            this.Value_Ty.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Value_Ty.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.Value_Ty.Name = "Value_Ty";
            this.Value_Ty.Size = new System.Drawing.Size(39, 20);
            this.Value_Ty.TabIndex = 3;
            // 
            // Value_Tz
            // 
            this.Value_Tz.Location = new System.Drawing.Point(1050, 282);
            this.Value_Tz.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Value_Tz.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.Value_Tz.Name = "Value_Tz";
            this.Value_Tz.Size = new System.Drawing.Size(39, 20);
            this.Value_Tz.TabIndex = 4;
            // 
            // Value_Rz
            // 
            this.Value_Rz.Enabled = false;
            this.Value_Rz.Location = new System.Drawing.Point(1050, 256);
            this.Value_Rz.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Value_Rz.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.Value_Rz.Name = "Value_Rz";
            this.Value_Rz.Size = new System.Drawing.Size(39, 20);
            this.Value_Rz.TabIndex = 8;
            // 
            // Value_Ry
            // 
            this.Value_Ry.Enabled = false;
            this.Value_Ry.Location = new System.Drawing.Point(1005, 256);
            this.Value_Ry.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Value_Ry.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.Value_Ry.Name = "Value_Ry";
            this.Value_Ry.Size = new System.Drawing.Size(39, 20);
            this.Value_Ry.TabIndex = 7;
            // 
            // Value_Rx
            // 
            this.Value_Rx.Enabled = false;
            this.Value_Rx.Location = new System.Drawing.Point(962, 256);
            this.Value_Rx.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Value_Rx.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.Value_Rx.Name = "Value_Rx";
            this.Value_Rx.Size = new System.Drawing.Size(37, 20);
            this.Value_Rx.TabIndex = 6;
            // 
            // btn_Rotate
            // 
            this.btn_Rotate.Enabled = false;
            this.btn_Rotate.Location = new System.Drawing.Point(881, 256);
            this.btn_Rotate.Name = "btn_Rotate";
            this.btn_Rotate.Size = new System.Drawing.Size(75, 20);
            this.btn_Rotate.TabIndex = 5;
            this.btn_Rotate.Text = "Rotate";
            this.btn_Rotate.UseVisualStyleBackColor = true;
            this.btn_Rotate.Click += new System.EventHandler(this.btn_Rotate_Click);
            // 
            // Rz
            // 
            this.Rz.Location = new System.Drawing.Point(1050, 75);
            this.Rz.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Rz.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.Rz.Name = "Rz";
            this.Rz.Size = new System.Drawing.Size(39, 20);
            this.Rz.TabIndex = 12;
            this.Rz.ValueChanged += new System.EventHandler(this.Rz_ValueChanged);
            // 
            // Ry
            // 
            this.Ry.Location = new System.Drawing.Point(1005, 75);
            this.Ry.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Ry.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.Ry.Name = "Ry";
            this.Ry.Size = new System.Drawing.Size(39, 20);
            this.Ry.TabIndex = 11;
            this.Ry.ValueChanged += new System.EventHandler(this.Ry_ValueChanged);
            // 
            // Rx
            // 
            this.Rx.Location = new System.Drawing.Point(962, 75);
            this.Rx.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Rx.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.Rx.Name = "Rx";
            this.Rx.Size = new System.Drawing.Size(37, 20);
            this.Rx.TabIndex = 10;
            this.Rx.ValueChanged += new System.EventHandler(this.Rx_ValueChanged);
            // 
            // Sz
            // 
            this.Sz.Location = new System.Drawing.Point(1050, 101);
            this.Sz.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Sz.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.Sz.Name = "Sz";
            this.Sz.Size = new System.Drawing.Size(39, 20);
            this.Sz.TabIndex = 15;
            this.Sz.ValueChanged += new System.EventHandler(this.Sz_ValueChanged);
            // 
            // Sy
            // 
            this.Sy.Location = new System.Drawing.Point(1005, 101);
            this.Sy.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Sy.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.Sy.Name = "Sy";
            this.Sy.Size = new System.Drawing.Size(39, 20);
            this.Sy.TabIndex = 14;
            this.Sy.ValueChanged += new System.EventHandler(this.Sy_ValueChanged);
            // 
            // Sx
            // 
            this.Sx.Location = new System.Drawing.Point(962, 101);
            this.Sx.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Sx.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.Sx.Name = "Sx";
            this.Sx.Size = new System.Drawing.Size(37, 20);
            this.Sx.TabIndex = 13;
            this.Sx.ValueChanged += new System.EventHandler(this.Sx_ValueChanged);
            // 
            // Pz
            // 
            this.Pz.Location = new System.Drawing.Point(1050, 49);
            this.Pz.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Pz.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.Pz.Name = "Pz";
            this.Pz.Size = new System.Drawing.Size(39, 20);
            this.Pz.TabIndex = 18;
            this.Pz.ValueChanged += new System.EventHandler(this.Pz_ValueChanged);
            // 
            // Py
            // 
            this.Py.Location = new System.Drawing.Point(1005, 49);
            this.Py.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Py.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.Py.Name = "Py";
            this.Py.Size = new System.Drawing.Size(39, 20);
            this.Py.TabIndex = 17;
            this.Py.ValueChanged += new System.EventHandler(this.Py_ValueChanged);
            // 
            // Px
            // 
            this.Px.Location = new System.Drawing.Point(962, 49);
            this.Px.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Px.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.Px.Name = "Px";
            this.Px.Size = new System.Drawing.Size(37, 20);
            this.Px.TabIndex = 16;
            this.Px.ValueChanged += new System.EventHandler(this.Px_ValueChanged);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblPosition.Location = new System.Drawing.Point(898, 49);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(58, 17);
            this.lblPosition.TabIndex = 19;
            this.lblPosition.Text = "Position";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(898, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Rotation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(898, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Scale";
            // 
            // Value_Ar
            // 
            this.Value_Ar.Location = new System.Drawing.Point(1005, 227);
            this.Value_Ar.Name = "Value_Ar";
            this.Value_Ar.Size = new System.Drawing.Size(82, 20);
            this.Value_Ar.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(881, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 29);
            this.button1.TabIndex = 22;
            this.button1.Text = "Rotate Angle:";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_Rotate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 602);
            this.Controls.Add(this.Value_Ar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.Pz);
            this.Controls.Add(this.Py);
            this.Controls.Add(this.Px);
            this.Controls.Add(this.Sz);
            this.Controls.Add(this.Sy);
            this.Controls.Add(this.Sx);
            this.Controls.Add(this.Rz);
            this.Controls.Add(this.Ry);
            this.Controls.Add(this.Rx);
            this.Controls.Add(this.Value_Rz);
            this.Controls.Add(this.Value_Ry);
            this.Controls.Add(this.Value_Rx);
            this.Controls.Add(this.btn_Rotate);
            this.Controls.Add(this.Value_Tz);
            this.Controls.Add(this.Value_Ty);
            this.Controls.Add(this.Value_Tx);
            this.Controls.Add(this.btn_Translate);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Value_Tx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Value_Ty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Value_Tz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Value_Rz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Value_Ry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Value_Rx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Py)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Px)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Value_Ar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.Button btn_Translate;
        private System.Windows.Forms.NumericUpDown Value_Tx;
        private System.Windows.Forms.NumericUpDown Value_Ty;
        private System.Windows.Forms.NumericUpDown Value_Tz;
        private System.Windows.Forms.NumericUpDown Value_Rz;
        private System.Windows.Forms.NumericUpDown Value_Ry;
        private System.Windows.Forms.NumericUpDown Value_Rx;
        private System.Windows.Forms.Button btn_Rotate;
        private System.Windows.Forms.NumericUpDown Rz;
        private System.Windows.Forms.NumericUpDown Ry;
        private System.Windows.Forms.NumericUpDown Rx;
        private System.Windows.Forms.NumericUpDown Sz;
        private System.Windows.Forms.NumericUpDown Sy;
        private System.Windows.Forms.NumericUpDown Sx;
        private System.Windows.Forms.NumericUpDown Pz;
        private System.Windows.Forms.NumericUpDown Py;
        private System.Windows.Forms.NumericUpDown Px;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Value_Ar;
        private System.Windows.Forms.Button button1;
    }
}

