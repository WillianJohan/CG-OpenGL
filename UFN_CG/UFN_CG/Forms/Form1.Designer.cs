namespace UFN_CG
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.canvas = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this._ObjectTransformRotation_X = new System.Windows.Forms.NumericUpDown();
            this._ObjectTransformRotation_Y = new System.Windows.Forms.NumericUpDown();
            this._ObjectTransformRotation_Z = new System.Windows.Forms.NumericUpDown();
            this._ObjectTransformScale_X = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this._ObjectTransformScale_Y = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this._ObjectTransformScale_Z = new System.Windows.Forms.NumericUpDown();
            this._ObjectTransformPosition_X = new System.Windows.Forms.NumericUpDown();
            this._ObjectTransformPosition_Z = new System.Windows.Forms.NumericUpDown();
            this._ObjectTransformPosition_Y = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_Rotate = new System.Windows.Forms.Button();
            this.btn_Translate = new System.Windows.Forms.Button();
            this._ObjectCommandsTranslate_X = new System.Windows.Forms.NumericUpDown();
            this._ObjectCommandsRotate_Z = new System.Windows.Forms.NumericUpDown();
            this._ObjectCommandsRotate_Y = new System.Windows.Forms.NumericUpDown();
            this._ObjectCommandsTranslate_Y = new System.Windows.Forms.NumericUpDown();
            this._ObjectCommandsRotate_X = new System.Windows.Forms.NumericUpDown();
            this._ObjectCommandsTranslate_Z = new System.Windows.Forms.NumericUpDown();
            this.btn_Import3DModel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this._VirtualCameraRotation_X = new System.Windows.Forms.NumericUpDown();
            this._VirtualCameraRotation_Y = new System.Windows.Forms.NumericUpDown();
            this._VirtualCameraRotation_Z = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this._VirtualCameraPosition_X = new System.Windows.Forms.NumericUpDown();
            this._VirtualCameraPosition_Z = new System.Windows.Forms.NumericUpDown();
            this._VirtualCameraPosition_Y = new System.Windows.Forms.NumericUpDown();
            this.canvas.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectTransformRotation_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectTransformRotation_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectTransformRotation_Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectTransformScale_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectTransformScale_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectTransformScale_Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectTransformPosition_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectTransformPosition_Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectTransformPosition_Y)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectCommandsTranslate_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectCommandsRotate_Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectCommandsRotate_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectCommandsTranslate_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectCommandsRotate_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectCommandsTranslate_Z)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._VirtualCameraRotation_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._VirtualCameraRotation_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._VirtualCameraRotation_Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._VirtualCameraPosition_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._VirtualCameraPosition_Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._VirtualCameraPosition_Y)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Controls.Add(this.groupBox4);
            this.canvas.Controls.Add(this.groupBox1);
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Margin = new System.Windows.Forms.Padding(0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1254, 681);
            this.canvas.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.btn_Import3DModel);
            this.groupBox4.Location = new System.Drawing.Point(978, 101);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(248, 244);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "3D Object";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblPosition);
            this.groupBox2.Controls.Add(this._ObjectTransformRotation_X);
            this.groupBox2.Controls.Add(this._ObjectTransformRotation_Y);
            this.groupBox2.Controls.Add(this._ObjectTransformRotation_Z);
            this.groupBox2.Controls.Add(this._ObjectTransformScale_X);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this._ObjectTransformScale_Y);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this._ObjectTransformScale_Z);
            this.groupBox2.Controls.Add(this._ObjectTransformPosition_X);
            this.groupBox2.Controls.Add(this._ObjectTransformPosition_Z);
            this.groupBox2.Controls.Add(this._ObjectTransformPosition_Y);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 110);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transform";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(23, 26);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(56, 16);
            this.lblPosition.TabIndex = 19;
            this.lblPosition.Text = "Position";
            // 
            // _ObjectTransformRotation_X
            // 
            this._ObjectTransformRotation_X.Location = new System.Drawing.Point(87, 48);
            this._ObjectTransformRotation_X.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._ObjectTransformRotation_X.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this._ObjectTransformRotation_X.Name = "_ObjectTransformRotation_X";
            this._ObjectTransformRotation_X.Size = new System.Drawing.Size(37, 20);
            this._ObjectTransformRotation_X.TabIndex = 10;
            this._ObjectTransformRotation_X.ValueChanged += new System.EventHandler(this.GraphicObject_RotationX_ValueChanged);
            // 
            // _ObjectTransformRotation_Y
            // 
            this._ObjectTransformRotation_Y.Location = new System.Drawing.Point(130, 48);
            this._ObjectTransformRotation_Y.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._ObjectTransformRotation_Y.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this._ObjectTransformRotation_Y.Name = "_ObjectTransformRotation_Y";
            this._ObjectTransformRotation_Y.Size = new System.Drawing.Size(39, 20);
            this._ObjectTransformRotation_Y.TabIndex = 11;
            this._ObjectTransformRotation_Y.ValueChanged += new System.EventHandler(this.GraphicObject_RotationY_ValueChanged);
            // 
            // _ObjectTransformRotation_Z
            // 
            this._ObjectTransformRotation_Z.Location = new System.Drawing.Point(175, 48);
            this._ObjectTransformRotation_Z.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._ObjectTransformRotation_Z.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this._ObjectTransformRotation_Z.Name = "_ObjectTransformRotation_Z";
            this._ObjectTransformRotation_Z.Size = new System.Drawing.Size(39, 20);
            this._ObjectTransformRotation_Z.TabIndex = 12;
            this._ObjectTransformRotation_Z.ValueChanged += new System.EventHandler(this.GraphicObject_RotationZ_ValueChanged);
            // 
            // _ObjectTransformScale_X
            // 
            this._ObjectTransformScale_X.Location = new System.Drawing.Point(87, 74);
            this._ObjectTransformScale_X.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._ObjectTransformScale_X.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this._ObjectTransformScale_X.Name = "_ObjectTransformScale_X";
            this._ObjectTransformScale_X.Size = new System.Drawing.Size(37, 20);
            this._ObjectTransformScale_X.TabIndex = 13;
            this._ObjectTransformScale_X.ValueChanged += new System.EventHandler(this.Sx_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Scale";
            // 
            // _ObjectTransformScale_Y
            // 
            this._ObjectTransformScale_Y.Location = new System.Drawing.Point(130, 74);
            this._ObjectTransformScale_Y.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._ObjectTransformScale_Y.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this._ObjectTransformScale_Y.Name = "_ObjectTransformScale_Y";
            this._ObjectTransformScale_Y.Size = new System.Drawing.Size(39, 20);
            this._ObjectTransformScale_Y.TabIndex = 14;
            this._ObjectTransformScale_Y.ValueChanged += new System.EventHandler(this.Sy_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Rotation";
            // 
            // _ObjectTransformScale_Z
            // 
            this._ObjectTransformScale_Z.Location = new System.Drawing.Point(175, 74);
            this._ObjectTransformScale_Z.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._ObjectTransformScale_Z.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this._ObjectTransformScale_Z.Name = "_ObjectTransformScale_Z";
            this._ObjectTransformScale_Z.Size = new System.Drawing.Size(39, 20);
            this._ObjectTransformScale_Z.TabIndex = 15;
            this._ObjectTransformScale_Z.ValueChanged += new System.EventHandler(this.Sz_ValueChanged);
            // 
            // _ObjectTransformPosition_X
            // 
            this._ObjectTransformPosition_X.Location = new System.Drawing.Point(87, 22);
            this._ObjectTransformPosition_X.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._ObjectTransformPosition_X.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this._ObjectTransformPosition_X.Name = "_ObjectTransformPosition_X";
            this._ObjectTransformPosition_X.Size = new System.Drawing.Size(37, 20);
            this._ObjectTransformPosition_X.TabIndex = 16;
            this._ObjectTransformPosition_X.ValueChanged += new System.EventHandler(this.GraphicObject_PositionX_ValueChanged);
            // 
            // _ObjectTransformPosition_Z
            // 
            this._ObjectTransformPosition_Z.Location = new System.Drawing.Point(175, 22);
            this._ObjectTransformPosition_Z.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._ObjectTransformPosition_Z.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this._ObjectTransformPosition_Z.Name = "_ObjectTransformPosition_Z";
            this._ObjectTransformPosition_Z.Size = new System.Drawing.Size(39, 20);
            this._ObjectTransformPosition_Z.TabIndex = 18;
            this._ObjectTransformPosition_Z.ValueChanged += new System.EventHandler(this.GraphicObject_PositionZ_ValueChanged);
            // 
            // _ObjectTransformPosition_Y
            // 
            this._ObjectTransformPosition_Y.Location = new System.Drawing.Point(130, 22);
            this._ObjectTransformPosition_Y.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._ObjectTransformPosition_Y.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this._ObjectTransformPosition_Y.Name = "_ObjectTransformPosition_Y";
            this._ObjectTransformPosition_Y.Size = new System.Drawing.Size(39, 20);
            this._ObjectTransformPosition_Y.TabIndex = 17;
            this._ObjectTransformPosition_Y.ValueChanged += new System.EventHandler(this.GraphicObject_PositionY_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_Rotate);
            this.groupBox3.Controls.Add(this.btn_Translate);
            this.groupBox3.Controls.Add(this._ObjectCommandsTranslate_X);
            this.groupBox3.Controls.Add(this._ObjectCommandsRotate_Z);
            this.groupBox3.Controls.Add(this._ObjectCommandsRotate_Y);
            this.groupBox3.Controls.Add(this._ObjectCommandsTranslate_Y);
            this.groupBox3.Controls.Add(this._ObjectCommandsRotate_X);
            this.groupBox3.Controls.Add(this._ObjectCommandsTranslate_Z);
            this.groupBox3.Location = new System.Drawing.Point(6, 135);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(234, 73);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Commands";
            // 
            // btn_Rotate
            // 
            this.btn_Rotate.Enabled = false;
            this.btn_Rotate.Location = new System.Drawing.Point(6, 47);
            this.btn_Rotate.Name = "btn_Rotate";
            this.btn_Rotate.Size = new System.Drawing.Size(75, 20);
            this.btn_Rotate.TabIndex = 5;
            this.btn_Rotate.Text = "Rotate";
            this.btn_Rotate.UseVisualStyleBackColor = true;
            this.btn_Rotate.Click += new System.EventHandler(this.btn_Rotate_Click);
            // 
            // btn_Translate
            // 
            this.btn_Translate.Location = new System.Drawing.Point(6, 21);
            this.btn_Translate.Name = "btn_Translate";
            this.btn_Translate.Size = new System.Drawing.Size(75, 20);
            this.btn_Translate.TabIndex = 1;
            this.btn_Translate.Text = "Translate";
            this.btn_Translate.UseVisualStyleBackColor = true;
            this.btn_Translate.Click += new System.EventHandler(this.btn_Translate_Click);
            // 
            // _ObjectCommandsTranslate_X
            // 
            this._ObjectCommandsTranslate_X.Location = new System.Drawing.Point(87, 21);
            this._ObjectCommandsTranslate_X.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._ObjectCommandsTranslate_X.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this._ObjectCommandsTranslate_X.Name = "_ObjectCommandsTranslate_X";
            this._ObjectCommandsTranslate_X.Size = new System.Drawing.Size(37, 20);
            this._ObjectCommandsTranslate_X.TabIndex = 2;
            // 
            // _ObjectCommandsRotate_Z
            // 
            this._ObjectCommandsRotate_Z.Enabled = false;
            this._ObjectCommandsRotate_Z.Location = new System.Drawing.Point(175, 47);
            this._ObjectCommandsRotate_Z.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._ObjectCommandsRotate_Z.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this._ObjectCommandsRotate_Z.Name = "_ObjectCommandsRotate_Z";
            this._ObjectCommandsRotate_Z.Size = new System.Drawing.Size(39, 20);
            this._ObjectCommandsRotate_Z.TabIndex = 8;
            // 
            // _ObjectCommandsRotate_Y
            // 
            this._ObjectCommandsRotate_Y.Enabled = false;
            this._ObjectCommandsRotate_Y.Location = new System.Drawing.Point(130, 47);
            this._ObjectCommandsRotate_Y.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._ObjectCommandsRotate_Y.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this._ObjectCommandsRotate_Y.Name = "_ObjectCommandsRotate_Y";
            this._ObjectCommandsRotate_Y.Size = new System.Drawing.Size(39, 20);
            this._ObjectCommandsRotate_Y.TabIndex = 7;
            // 
            // _ObjectCommandsTranslate_Y
            // 
            this._ObjectCommandsTranslate_Y.Location = new System.Drawing.Point(130, 21);
            this._ObjectCommandsTranslate_Y.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._ObjectCommandsTranslate_Y.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this._ObjectCommandsTranslate_Y.Name = "_ObjectCommandsTranslate_Y";
            this._ObjectCommandsTranslate_Y.Size = new System.Drawing.Size(39, 20);
            this._ObjectCommandsTranslate_Y.TabIndex = 3;
            // 
            // _ObjectCommandsRotate_X
            // 
            this._ObjectCommandsRotate_X.Enabled = false;
            this._ObjectCommandsRotate_X.Location = new System.Drawing.Point(87, 47);
            this._ObjectCommandsRotate_X.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._ObjectCommandsRotate_X.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this._ObjectCommandsRotate_X.Name = "_ObjectCommandsRotate_X";
            this._ObjectCommandsRotate_X.Size = new System.Drawing.Size(37, 20);
            this._ObjectCommandsRotate_X.TabIndex = 6;
            // 
            // _ObjectCommandsTranslate_Z
            // 
            this._ObjectCommandsTranslate_Z.Location = new System.Drawing.Point(175, 21);
            this._ObjectCommandsTranslate_Z.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._ObjectCommandsTranslate_Z.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this._ObjectCommandsTranslate_Z.Name = "_ObjectCommandsTranslate_Z";
            this._ObjectCommandsTranslate_Z.Size = new System.Drawing.Size(39, 20);
            this._ObjectCommandsTranslate_Z.TabIndex = 4;
            // 
            // btn_Import3DModel
            // 
            this.btn_Import3DModel.Location = new System.Drawing.Point(6, 214);
            this.btn_Import3DModel.Name = "btn_Import3DModel";
            this.btn_Import3DModel.Size = new System.Drawing.Size(234, 23);
            this.btn_Import3DModel.TabIndex = 24;
            this.btn_Import3DModel.Text = "Import 3D Model";
            this.btn_Import3DModel.UseVisualStyleBackColor = true;
            this.btn_Import3DModel.Click += new System.EventHandler(this.btn_Import3DModel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._VirtualCameraRotation_X);
            this.groupBox1.Controls.Add(this._VirtualCameraRotation_Y);
            this.groupBox1.Controls.Add(this._VirtualCameraRotation_Z);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this._VirtualCameraPosition_X);
            this.groupBox1.Controls.Add(this._VirtualCameraPosition_Z);
            this.groupBox1.Controls.Add(this._VirtualCameraPosition_Y);
            this.groupBox1.Location = new System.Drawing.Point(978, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 83);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Virtual Camera";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Position";
            // 
            // _VirtualCameraRotation_X
            // 
            this._VirtualCameraRotation_X.Location = new System.Drawing.Point(91, 51);
            this._VirtualCameraRotation_X.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._VirtualCameraRotation_X.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this._VirtualCameraRotation_X.Name = "_VirtualCameraRotation_X";
            this._VirtualCameraRotation_X.Size = new System.Drawing.Size(37, 20);
            this._VirtualCameraRotation_X.TabIndex = 21;
            this._VirtualCameraRotation_X.ValueChanged += new System.EventHandler(this._VirtualCameraRotation_X_ValueChanged);
            // 
            // _VirtualCameraRotation_Y
            // 
            this._VirtualCameraRotation_Y.Location = new System.Drawing.Point(134, 51);
            this._VirtualCameraRotation_Y.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._VirtualCameraRotation_Y.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this._VirtualCameraRotation_Y.Name = "_VirtualCameraRotation_Y";
            this._VirtualCameraRotation_Y.Size = new System.Drawing.Size(39, 20);
            this._VirtualCameraRotation_Y.TabIndex = 22;
            this._VirtualCameraRotation_Y.ValueChanged += new System.EventHandler(this._VirtualCameraRotation_Y_ValueChanged);
            // 
            // _VirtualCameraRotation_Z
            // 
            this._VirtualCameraRotation_Z.Location = new System.Drawing.Point(179, 51);
            this._VirtualCameraRotation_Z.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._VirtualCameraRotation_Z.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this._VirtualCameraRotation_Z.Name = "_VirtualCameraRotation_Z";
            this._VirtualCameraRotation_Z.Size = new System.Drawing.Size(39, 20);
            this._VirtualCameraRotation_Z.TabIndex = 23;
            this._VirtualCameraRotation_Z.ValueChanged += new System.EventHandler(this._VirtualCameraRotation_Z_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "Rotation";
            // 
            // _VirtualCameraPosition_X
            // 
            this._VirtualCameraPosition_X.Location = new System.Drawing.Point(91, 25);
            this._VirtualCameraPosition_X.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._VirtualCameraPosition_X.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this._VirtualCameraPosition_X.Name = "_VirtualCameraPosition_X";
            this._VirtualCameraPosition_X.Size = new System.Drawing.Size(37, 20);
            this._VirtualCameraPosition_X.TabIndex = 24;
            this._VirtualCameraPosition_X.ValueChanged += new System.EventHandler(this._VirtualCameraPosition_X_ValueChanged);
            // 
            // _VirtualCameraPosition_Z
            // 
            this._VirtualCameraPosition_Z.Location = new System.Drawing.Point(179, 25);
            this._VirtualCameraPosition_Z.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._VirtualCameraPosition_Z.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this._VirtualCameraPosition_Z.Name = "_VirtualCameraPosition_Z";
            this._VirtualCameraPosition_Z.Size = new System.Drawing.Size(39, 20);
            this._VirtualCameraPosition_Z.TabIndex = 26;
            this._VirtualCameraPosition_Z.ValueChanged += new System.EventHandler(this._VirtualCameraPosition_Z_ValueChanged);
            // 
            // _VirtualCameraPosition_Y
            // 
            this._VirtualCameraPosition_Y.Location = new System.Drawing.Point(134, 25);
            this._VirtualCameraPosition_Y.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._VirtualCameraPosition_Y.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this._VirtualCameraPosition_Y.Name = "_VirtualCameraPosition_Y";
            this._VirtualCameraPosition_Y.Size = new System.Drawing.Size(39, 20);
            this._VirtualCameraPosition_Y.TabIndex = 25;
            this._VirtualCameraPosition_Y.ValueChanged += new System.EventHandler(this._VirtualCameraPosition_Y_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 681);
            this.Controls.Add(this.canvas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "UFN_Computação Gráfica";
            this.canvas.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectTransformRotation_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectTransformRotation_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectTransformRotation_Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectTransformScale_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectTransformScale_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectTransformScale_Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectTransformPosition_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectTransformPosition_Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectTransformPosition_Y)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._ObjectCommandsTranslate_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectCommandsRotate_Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectCommandsRotate_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectCommandsTranslate_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectCommandsRotate_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ObjectCommandsTranslate_Z)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._VirtualCameraRotation_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._VirtualCameraRotation_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._VirtualCameraRotation_Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._VirtualCameraPosition_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._VirtualCameraPosition_Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._VirtualCameraPosition_Y)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.Button btn_Translate;
        private System.Windows.Forms.NumericUpDown _ObjectCommandsTranslate_X;
        private System.Windows.Forms.NumericUpDown _ObjectCommandsTranslate_Y;
        private System.Windows.Forms.NumericUpDown _ObjectCommandsTranslate_Z;
        private System.Windows.Forms.NumericUpDown _ObjectCommandsRotate_Z;
        private System.Windows.Forms.NumericUpDown _ObjectCommandsRotate_Y;
        private System.Windows.Forms.NumericUpDown _ObjectCommandsRotate_X;
        private System.Windows.Forms.Button btn_Rotate;
        private System.Windows.Forms.NumericUpDown _ObjectTransformRotation_Z;
        private System.Windows.Forms.NumericUpDown _ObjectTransformRotation_Y;
        private System.Windows.Forms.NumericUpDown _ObjectTransformRotation_X;
        private System.Windows.Forms.NumericUpDown _ObjectTransformScale_Z;
        private System.Windows.Forms.NumericUpDown _ObjectTransformScale_Y;
        private System.Windows.Forms.NumericUpDown _ObjectTransformScale_X;
        private System.Windows.Forms.NumericUpDown _ObjectTransformPosition_Z;
        private System.Windows.Forms.NumericUpDown _ObjectTransformPosition_Y;
        private System.Windows.Forms.NumericUpDown _ObjectTransformPosition_X;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Import3DModel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown _VirtualCameraRotation_X;
        private System.Windows.Forms.NumericUpDown _VirtualCameraRotation_Y;
        private System.Windows.Forms.NumericUpDown _VirtualCameraRotation_Z;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown _VirtualCameraPosition_X;
        private System.Windows.Forms.NumericUpDown _VirtualCameraPosition_Z;
        private System.Windows.Forms.NumericUpDown _VirtualCameraPosition_Y;
    }
}

