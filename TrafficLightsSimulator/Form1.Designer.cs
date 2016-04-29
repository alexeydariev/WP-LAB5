namespace TrafficLight
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gpTools = new System.Windows.Forms.GroupBox();
            this.btnStopSimulation = new System.Windows.Forms.Button();
            this.btnStartSimulation = new System.Windows.Forms.Button();
            this.gpPedestrians = new System.Windows.Forms.GroupBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.btnRemoveAllPedestrians = new System.Windows.Forms.Button();
            this.btnRemovePedestrian = new System.Windows.Forms.Button();
            this.btnAddEditPedestrian = new System.Windows.Forms.Button();
            this.gpTraffic = new System.Windows.Forms.GroupBox();
            this.btnRemoveAllCarStreams = new System.Windows.Forms.Button();
            this.btnRemoveCarStream = new System.Windows.Forms.Button();
            this.btnAddEditStream = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.gpGrid = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnRemoveCrossing = new System.Windows.Forms.Button();
            this.btnAddComplex = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClearGrid = new System.Windows.Forms.Button();
            this.btnAddSimple = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbSave = new System.Windows.Forms.ToolStripSplitButton();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbNewGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tbLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.gpTools.SuspendLayout();
            this.gpPedestrians.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.gpTraffic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.gpGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpTools
            // 
            this.gpTools.Controls.Add(this.btnStopSimulation);
            this.gpTools.Controls.Add(this.btnStartSimulation);
            this.gpTools.Controls.Add(this.gpPedestrians);
            this.gpTools.Controls.Add(this.gpTraffic);
            this.gpTools.Controls.Add(this.gpGrid);
            this.gpTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gpTools.Location = new System.Drawing.Point(16, 31);
            this.gpTools.Name = "gpTools";
            this.gpTools.Size = new System.Drawing.Size(233, 658);
            this.gpTools.TabIndex = 0;
            this.gpTools.TabStop = false;
            this.gpTools.Text = "Tools";
            // 
            // btnStopSimulation
            // 
            this.btnStopSimulation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopSimulation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStopSimulation.Location = new System.Drawing.Point(6, 611);
            this.btnStopSimulation.Name = "btnStopSimulation";
            this.btnStopSimulation.Size = new System.Drawing.Size(220, 40);
            this.btnStopSimulation.TabIndex = 4;
            this.btnStopSimulation.Text = "Stop Simulation";
            this.btnStopSimulation.UseVisualStyleBackColor = true;
            this.btnStopSimulation.Visible = false;
            this.btnStopSimulation.Click += new System.EventHandler(this.btnStopSimulation_Click);
            // 
            // btnStartSimulation
            // 
            this.btnStartSimulation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartSimulation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStartSimulation.Location = new System.Drawing.Point(6, 611);
            this.btnStartSimulation.Name = "btnStartSimulation";
            this.btnStartSimulation.Size = new System.Drawing.Size(220, 40);
            this.btnStartSimulation.TabIndex = 3;
            this.btnStartSimulation.Text = "Start Simulation";
            this.btnStartSimulation.UseVisualStyleBackColor = true;
            this.btnStartSimulation.Click += new System.EventHandler(this.btnStartSimulation_Click);
            // 
            // gpPedestrians
            // 
            this.gpPedestrians.Controls.Add(this.pictureBox9);
            this.gpPedestrians.Controls.Add(this.pictureBox8);
            this.gpPedestrians.Controls.Add(this.pictureBox7);
            this.gpPedestrians.Controls.Add(this.btnRemoveAllPedestrians);
            this.gpPedestrians.Controls.Add(this.btnRemovePedestrian);
            this.gpPedestrians.Controls.Add(this.btnAddEditPedestrian);
            this.gpPedestrians.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gpPedestrians.Location = new System.Drawing.Point(6, 423);
            this.gpPedestrians.Name = "gpPedestrians";
            this.gpPedestrians.Size = new System.Drawing.Size(220, 182);
            this.gpPedestrians.TabIndex = 2;
            this.gpPedestrians.TabStop = false;
            this.gpPedestrians.Text = "Pedestrians";
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(8, 121);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(50, 50);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 12;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(8, 70);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(50, 50);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 18;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(8, 19);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(50, 50);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 15;
            this.pictureBox7.TabStop = false;
            // 
            // btnRemoveAllPedestrians
            // 
            this.btnRemoveAllPedestrians.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAllPedestrians.Location = new System.Drawing.Point(78, 123);
            this.btnRemoveAllPedestrians.Name = "btnRemoveAllPedestrians";
            this.btnRemoveAllPedestrians.Size = new System.Drawing.Size(128, 42);
            this.btnRemoveAllPedestrians.TabIndex = 17;
            this.btnRemoveAllPedestrians.Text = "Remove all streams";
            this.btnRemoveAllPedestrians.UseVisualStyleBackColor = true;
            this.btnRemoveAllPedestrians.Click += new System.EventHandler(this.btnRemoveAllPedestrians_Click);
            // 
            // btnRemovePedestrian
            // 
            this.btnRemovePedestrian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemovePedestrian.Location = new System.Drawing.Point(78, 72);
            this.btnRemovePedestrian.Name = "btnRemovePedestrian";
            this.btnRemovePedestrian.Size = new System.Drawing.Size(128, 42);
            this.btnRemovePedestrian.TabIndex = 16;
            this.btnRemovePedestrian.Text = "Remove pedestrian stream";
            this.btnRemovePedestrian.UseVisualStyleBackColor = true;
            this.btnRemovePedestrian.Click += new System.EventHandler(this.btnRemovePedestrian_Click);
            // 
            // btnAddEditPedestrian
            // 
            this.btnAddEditPedestrian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEditPedestrian.Location = new System.Drawing.Point(78, 21);
            this.btnAddEditPedestrian.Name = "btnAddEditPedestrian";
            this.btnAddEditPedestrian.Size = new System.Drawing.Size(128, 42);
            this.btnAddEditPedestrian.TabIndex = 15;
            this.btnAddEditPedestrian.Text = "Add/Edit pedestrians";
            this.btnAddEditPedestrian.UseVisualStyleBackColor = true;
            this.btnAddEditPedestrian.Click += new System.EventHandler(this.btnAddEditPedestrian_Click);
            // 
            // gpTraffic
            // 
            this.gpTraffic.Controls.Add(this.btnRemoveAllCarStreams);
            this.gpTraffic.Controls.Add(this.btnRemoveCarStream);
            this.gpTraffic.Controls.Add(this.btnAddEditStream);
            this.gpTraffic.Controls.Add(this.pictureBox6);
            this.gpTraffic.Controls.Add(this.pictureBox5);
            this.gpTraffic.Controls.Add(this.pictureBox4);
            this.gpTraffic.Location = new System.Drawing.Point(6, 238);
            this.gpTraffic.Name = "gpTraffic";
            this.gpTraffic.Size = new System.Drawing.Size(217, 179);
            this.gpTraffic.TabIndex = 1;
            this.gpTraffic.TabStop = false;
            this.gpTraffic.Text = "Traffic";
            // 
            // btnRemoveAllCarStreams
            // 
            this.btnRemoveAllCarStreams.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAllCarStreams.Location = new System.Drawing.Point(78, 123);
            this.btnRemoveAllCarStreams.Name = "btnRemoveAllCarStreams";
            this.btnRemoveAllCarStreams.Size = new System.Drawing.Size(128, 42);
            this.btnRemoveAllCarStreams.TabIndex = 14;
            this.btnRemoveAllCarStreams.Text = "Remove all streams";
            this.btnRemoveAllCarStreams.UseVisualStyleBackColor = true;
            this.btnRemoveAllCarStreams.Click += new System.EventHandler(this.btnRemoveAllCarStreams_Click);
            // 
            // btnRemoveCarStream
            // 
            this.btnRemoveCarStream.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveCarStream.Location = new System.Drawing.Point(78, 72);
            this.btnRemoveCarStream.Name = "btnRemoveCarStream";
            this.btnRemoveCarStream.Size = new System.Drawing.Size(128, 42);
            this.btnRemoveCarStream.TabIndex = 13;
            this.btnRemoveCarStream.Text = "Remove car stream";
            this.btnRemoveCarStream.UseVisualStyleBackColor = true;
            this.btnRemoveCarStream.Click += new System.EventHandler(this.btnRemoveCarStream_Click);
            // 
            // btnAddEditStream
            // 
            this.btnAddEditStream.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEditStream.Location = new System.Drawing.Point(78, 19);
            this.btnAddEditStream.Name = "btnAddEditStream";
            this.btnAddEditStream.Size = new System.Drawing.Size(128, 42);
            this.btnAddEditStream.TabIndex = 11;
            this.btnAddEditStream.Text = "Add/Edit Car Stream";
            this.btnAddEditStream.UseVisualStyleBackColor = true;
            this.btnAddEditStream.Click += new System.EventHandler(this.btnAddEditStream_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(8, 121);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(50, 50);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 7;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(8, 70);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(50, 50);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 12;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(8, 19);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(50, 50);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 11;
            this.pictureBox4.TabStop = false;
            // 
            // gpGrid
            // 
            this.gpGrid.Controls.Add(this.pictureBox3);
            this.gpGrid.Controls.Add(this.pictureBox2);
            this.gpGrid.Controls.Add(this.btnRemoveCrossing);
            this.gpGrid.Controls.Add(this.btnAddComplex);
            this.gpGrid.Controls.Add(this.pictureBox1);
            this.gpGrid.Controls.Add(this.btnClearGrid);
            this.gpGrid.Controls.Add(this.btnAddSimple);
            this.gpGrid.Location = new System.Drawing.Point(6, 19);
            this.gpGrid.Name = "gpGrid";
            this.gpGrid.Size = new System.Drawing.Size(217, 213);
            this.gpGrid.TabIndex = 0;
            this.gpGrid.TabStop = false;
            this.gpGrid.Text = "Grid";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(8, 121);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(8, 70);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // btnRemoveCrossing
            // 
            this.btnRemoveCrossing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveCrossing.Location = new System.Drawing.Point(78, 123);
            this.btnRemoveCrossing.Name = "btnRemoveCrossing";
            this.btnRemoveCrossing.Size = new System.Drawing.Size(128, 42);
            this.btnRemoveCrossing.TabIndex = 8;
            this.btnRemoveCrossing.Text = "Remove crossing";
            this.btnRemoveCrossing.UseVisualStyleBackColor = true;
            this.btnRemoveCrossing.Click += new System.EventHandler(this.btnRemoveCrossing_Click);
            // 
            // btnAddComplex
            // 
            this.btnAddComplex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddComplex.Location = new System.Drawing.Point(78, 71);
            this.btnAddComplex.Name = "btnAddComplex";
            this.btnAddComplex.Size = new System.Drawing.Size(128, 42);
            this.btnAddComplex.TabIndex = 7;
            this.btnAddComplex.Text = "Add complex crossing";
            this.btnAddComplex.UseVisualStyleBackColor = true;
            this.btnAddComplex.Click += new System.EventHandler(this.btnAddComplex_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnClearGrid
            // 
            this.btnClearGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClearGrid.Location = new System.Drawing.Point(6, 177);
            this.btnClearGrid.Name = "btnClearGrid";
            this.btnClearGrid.Size = new System.Drawing.Size(200, 30);
            this.btnClearGrid.TabIndex = 3;
            this.btnClearGrid.Text = "Clear Grid";
            this.btnClearGrid.UseVisualStyleBackColor = true;
            this.btnClearGrid.Click += new System.EventHandler(this.btnClearGrid_Click);
            // 
            // btnAddSimple
            // 
            this.btnAddSimple.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSimple.Location = new System.Drawing.Point(78, 21);
            this.btnAddSimple.Name = "btnAddSimple";
            this.btnAddSimple.Size = new System.Drawing.Size(128, 42);
            this.btnAddSimple.TabIndex = 0;
            this.btnAddSimple.Text = "Add simple crossing";
            this.btnAddSimple.UseVisualStyleBackColor = true;
            this.btnAddSimple.Click += new System.EventHandler(this.btnAddSimple_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "SIMPLE_CROSSING_FINAL.png");
            this.imageList1.Images.SetKeyName(1, "COMPLEX_CROSSING_FINAL.png");
            this.imageList1.Images.SetKeyName(2, "endstream_button.png");
            this.imageList1.Images.SetKeyName(3, "start_button.png");
            this.imageList1.Images.SetKeyName(4, "car_withBounds.png");
            this.imageList1.Images.SetKeyName(5, "ConcreteTruck.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Silver;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 2, 3);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6,
            this.toolStripSeparator1,
            this.tbSave,
            this.toolStripSeparator5,
            this.toolStripSeparator2,
            this.toolStripSeparator4,
            this.toolStripSeparator3,
            this.tbNewGrid,
            this.toolStripSeparator10,
            this.toolStripSeparator9,
            this.tbLoad,
            this.toolStripSeparator8,
            this.toolStripSeparator7});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1197, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbSave
            // 
            this.tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.saveAllToolStripMenuItem});
            this.tbSave.Image = ((System.Drawing.Image)(resources.GetObject("tbSave.Image")));
            this.tbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(32, 22);
            this.tbSave.Text = "toolStripSplitButton1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.saveAsToolStripMenuItem.Text = "Save as..";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.saveAllToolStripMenuItem.Text = "Save all";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.saveAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tbNewGrid
            // 
            this.tbNewGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbNewGrid.ForeColor = System.Drawing.Color.Black;
            this.tbNewGrid.Image = ((System.Drawing.Image)(resources.GetObject("tbNewGrid.Image")));
            this.tbNewGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbNewGrid.Name = "tbNewGrid";
            this.tbNewGrid.Size = new System.Drawing.Size(60, 22);
            this.tbNewGrid.Text = "New Grid";
            this.tbNewGrid.Click += new System.EventHandler(this.TbNewGrid_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // tbLoad
            // 
            this.tbLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbLoad.ForeColor = System.Drawing.Color.Black;
            this.tbLoad.Image = ((System.Drawing.Image)(resources.GetObject("tbLoad.Image")));
            this.tbLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbLoad.Name = "tbLoad";
            this.tbLoad.Size = new System.Drawing.Size(37, 22);
            this.tbLoad.Text = "Load";
            this.tbLoad.Click += new System.EventHandler(this.tbLoad_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(1185, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Duration :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(1185, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "00:00:00";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 709);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gpTools);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.gpTools.ResumeLayout(false);
            this.gpPedestrians.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.gpTraffic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.gpGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpTools;
        private System.Windows.Forms.Button btnStartSimulation;
        private System.Windows.Forms.GroupBox gpPedestrians;
        private System.Windows.Forms.Button btnRemoveAllPedestrians;
        private System.Windows.Forms.Button btnRemovePedestrian;
        private System.Windows.Forms.Button btnAddEditPedestrian;
        private System.Windows.Forms.GroupBox gpTraffic;
        private System.Windows.Forms.Button btnRemoveAllCarStreams;
        private System.Windows.Forms.Button btnRemoveCarStream;
        private System.Windows.Forms.Button btnAddEditStream;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.GroupBox gpGrid;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnRemoveCrossing;
        private System.Windows.Forms.Button btnAddComplex;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClearGrid;
        private System.Windows.Forms.Button btnAddSimple;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Button btnStopSimulation;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tbNewGrid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton tbLoad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripSplitButton tbSave;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;

    }
}

