namespace GISFinal
{
    partial class mainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.shapefile文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.antMap文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.添加数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.保存BMPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ShapeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑选中要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除选中要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.按属性选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除所选要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.插入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加图层ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.添加要素ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.制图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加静态注记ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加指北针ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加比例尺ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.使用帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于蚁图ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusScale = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.statuSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.layerTreeView = new System.Windows.Forms.TreeView();
            this.layerImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.新建 = new System.Windows.Forms.ToolStripButton();
            this.打开 = new System.Windows.Forms.ToolStripButton();
            this.保存 = new System.Windows.Forms.ToolStripButton();
            this.添加数据 = new System.Windows.Forms.ToolStripButton();
            this.放大 = new System.Windows.Forms.ToolStripButton();
            this.缩小 = new System.Windows.Forms.ToolStripButton();
            this.平移 = new System.Windows.Forms.ToolStripButton();
            this.固定比例放大 = new System.Windows.Forms.ToolStripButton();
            this.固定比例缩小 = new System.Windows.Forms.ToolStripButton();
            this.选择要素 = new System.Windows.Forms.ToolStripButton();
            this.识别 = new System.Windows.Forms.ToolStripButton();
            this.转到XY = new System.Windows.Forms.ToolStripButton();
            this.openShapefileDialog = new System.Windows.Forms.OpenFileDialog();
            this.layerContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开属性表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩放至图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openProjectFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mcMap = new GISDesign_ZY.MapControl();
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.layerContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.选择ToolStripMenuItem,
            this.插入ToolStripMenuItem,
            this.制图ToolStripMenuItem,
            this.帮助ToolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip.Size = new System.Drawing.Size(957, 24);
            this.menuStrip.TabIndex = 0;
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.打开ToolStripMenuItem1,
            this.toolStripSeparator1,
            this.另存为ToolStripMenuItem,
            this.toolStripSeparator2,
            this.添加数据ToolStripMenuItem,
            this.toolStripSeparator3,
            this.保存BMPToolStripMenuItem,
            this.保存ShapeFileToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.打开ToolStripMenuItem.Text = "新建";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 打开ToolStripMenuItem1
            // 
            this.打开ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shapefile文件ToolStripMenuItem,
            this.antMap文件ToolStripMenuItem});
            this.打开ToolStripMenuItem1.Name = "打开ToolStripMenuItem1";
            this.打开ToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.打开ToolStripMenuItem1.Text = "打开";
            this.打开ToolStripMenuItem1.Click += new System.EventHandler(this.打开ToolStripMenuItem1_Click);
            // 
            // shapefile文件ToolStripMenuItem
            // 
            this.shapefile文件ToolStripMenuItem.Name = "shapefile文件ToolStripMenuItem";
            this.shapefile文件ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.shapefile文件ToolStripMenuItem.Text = "shapefile文件";
            this.shapefile文件ToolStripMenuItem.Click += new System.EventHandler(this.Shapefile文件ToolStripMenuItem_Click);
            // 
            // antMap文件ToolStripMenuItem
            // 
            this.antMap文件ToolStripMenuItem.Name = "antMap文件ToolStripMenuItem";
            this.antMap文件ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.antMap文件ToolStripMenuItem.Text = "AntMap文件";
            this.antMap文件ToolStripMenuItem.Click += new System.EventHandler(this.AntMap文件ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // 另存为ToolStripMenuItem
            // 
            this.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            this.另存为ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.另存为ToolStripMenuItem.Text = "另存为";
            this.另存为ToolStripMenuItem.Click += new System.EventHandler(this.另存为ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
            // 
            // 添加数据ToolStripMenuItem
            // 
            this.添加数据ToolStripMenuItem.Name = "添加数据ToolStripMenuItem";
            this.添加数据ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.添加数据ToolStripMenuItem.Text = "添加数据";
            this.添加数据ToolStripMenuItem.Click += new System.EventHandler(this.添加数据ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(152, 6);
            // 
            // 保存BMPToolStripMenuItem
            // 
            this.保存BMPToolStripMenuItem.Name = "保存BMPToolStripMenuItem";
            this.保存BMPToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.保存BMPToolStripMenuItem.Text = "保存BMP";
            this.保存BMPToolStripMenuItem.Click += new System.EventHandler(this.保存BMPToolStripMenuItem_Click);
            // 
            // 保存ShapeFileToolStripMenuItem
            // 
            this.保存ShapeFileToolStripMenuItem.Name = "保存ShapeFileToolStripMenuItem";
            this.保存ShapeFileToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.保存ShapeFileToolStripMenuItem.Text = "保存ShapeFile";
            this.保存ShapeFileToolStripMenuItem.Click += new System.EventHandler(this.保存ShapeFileToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑选中要素ToolStripMenuItem,
            this.删除选中要素ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 编辑选中要素ToolStripMenuItem
            // 
            this.编辑选中要素ToolStripMenuItem.Name = "编辑选中要素ToolStripMenuItem";
            this.编辑选中要素ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.编辑选中要素ToolStripMenuItem.Text = "编辑要素节点";
            this.编辑选中要素ToolStripMenuItem.Click += new System.EventHandler(this.编辑选中要素ToolStripMenuItem_Click);
            // 
            // 删除选中要素ToolStripMenuItem
            // 
            this.删除选中要素ToolStripMenuItem.Name = "删除选中要素ToolStripMenuItem";
            this.删除选中要素ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除选中要素ToolStripMenuItem.Text = "删除选中要素";
            this.删除选中要素ToolStripMenuItem.Click += new System.EventHandler(this.删除选中要素ToolStripMenuItem_Click);
            // 
            // 选择ToolStripMenuItem
            // 
            this.选择ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择要素ToolStripMenuItem,
            this.按属性选择ToolStripMenuItem,
            this.清除所选要素ToolStripMenuItem});
            this.选择ToolStripMenuItem.Name = "选择ToolStripMenuItem";
            this.选择ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.选择ToolStripMenuItem.Text = "选择";
            // 
            // 选择要素ToolStripMenuItem
            // 
            this.选择要素ToolStripMenuItem.Name = "选择要素ToolStripMenuItem";
            this.选择要素ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.选择要素ToolStripMenuItem.Text = "选择要素";
            this.选择要素ToolStripMenuItem.Click += new System.EventHandler(this.选择要素ToolStripMenuItem_Click);
            // 
            // 按属性选择ToolStripMenuItem
            // 
            this.按属性选择ToolStripMenuItem.Name = "按属性选择ToolStripMenuItem";
            this.按属性选择ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.按属性选择ToolStripMenuItem.Text = "按属性选择";
            this.按属性选择ToolStripMenuItem.Click += new System.EventHandler(this.按属性选择ToolStripMenuItem_Click);
            // 
            // 清除所选要素ToolStripMenuItem
            // 
            this.清除所选要素ToolStripMenuItem.Name = "清除所选要素ToolStripMenuItem";
            this.清除所选要素ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.清除所选要素ToolStripMenuItem.Text = "清除所选要素";
            this.清除所选要素ToolStripMenuItem.Click += new System.EventHandler(this.清除所选要素ToolStripMenuItem_Click);
            // 
            // 插入ToolStripMenuItem
            // 
            this.插入ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加图层ToolStripMenuItem1,
            this.添加要素ToolStripMenuItem1});
            this.插入ToolStripMenuItem.Name = "插入ToolStripMenuItem";
            this.插入ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.插入ToolStripMenuItem.Text = "添加";
            // 
            // 添加图层ToolStripMenuItem1
            // 
            this.添加图层ToolStripMenuItem1.Name = "添加图层ToolStripMenuItem1";
            this.添加图层ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.添加图层ToolStripMenuItem1.Text = "添加图层";
            this.添加图层ToolStripMenuItem1.Click += new System.EventHandler(this.添加图层ToolStripMenuItem1_Click);
            // 
            // 添加要素ToolStripMenuItem1
            // 
            this.添加要素ToolStripMenuItem1.Name = "添加要素ToolStripMenuItem1";
            this.添加要素ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.添加要素ToolStripMenuItem1.Text = "添加要素";
            this.添加要素ToolStripMenuItem1.Click += new System.EventHandler(this.添加要素ToolStripMenuItem1_Click);
            // 
            // 制图ToolStripMenuItem
            // 
            this.制图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加静态注记ToolStripMenuItem,
            this.添加指北针ToolStripMenuItem,
            this.添加比例尺ToolStripMenuItem});
            this.制图ToolStripMenuItem.Name = "制图ToolStripMenuItem";
            this.制图ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.制图ToolStripMenuItem.Text = "制图";
            // 
            // 添加静态注记ToolStripMenuItem
            // 
            this.添加静态注记ToolStripMenuItem.Name = "添加静态注记ToolStripMenuItem";
            this.添加静态注记ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.添加静态注记ToolStripMenuItem.Text = "添加静态注记";
            this.添加静态注记ToolStripMenuItem.Click += new System.EventHandler(this.添加静态注记ToolStripMenuItem_Click);
            // 
            // 添加指北针ToolStripMenuItem
            // 
            this.添加指北针ToolStripMenuItem.Name = "添加指北针ToolStripMenuItem";
            this.添加指北针ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.添加指北针ToolStripMenuItem.Text = "添加指北针";
            this.添加指北针ToolStripMenuItem.Click += new System.EventHandler(this.添加指北针ToolStripMenuItem_Click);
            // 
            // 添加比例尺ToolStripMenuItem
            // 
            this.添加比例尺ToolStripMenuItem.Name = "添加比例尺ToolStripMenuItem";
            this.添加比例尺ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.添加比例尺ToolStripMenuItem.Text = "添加比例尺";
            this.添加比例尺ToolStripMenuItem.Click += new System.EventHandler(this.添加比例尺ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem1
            // 
            this.帮助ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.使用帮助ToolStripMenuItem,
            this.关于蚁图ToolStripMenuItem1});
            this.帮助ToolStripMenuItem1.Name = "帮助ToolStripMenuItem1";
            this.帮助ToolStripMenuItem1.Size = new System.Drawing.Size(44, 22);
            this.帮助ToolStripMenuItem1.Text = "帮助";
            // 
            // 使用帮助ToolStripMenuItem
            // 
            this.使用帮助ToolStripMenuItem.Name = "使用帮助ToolStripMenuItem";
            this.使用帮助ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.使用帮助ToolStripMenuItem.Text = "使用帮助";
            // 
            // 关于蚁图ToolStripMenuItem1
            // 
            this.关于蚁图ToolStripMenuItem1.Name = "关于蚁图ToolStripMenuItem1";
            this.关于蚁图ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.关于蚁图ToolStripMenuItem1.Text = "关于蚁图";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusScale,
            this.statusPosition,
            this.statuSelected});
            this.statusStrip1.Location = new System.Drawing.Point(124, 459);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(802, 30);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusScale
            // 
            this.statusScale.AutoSize = false;
            this.statusScale.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusScale.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusScale.Name = "statusScale";
            this.statusScale.Size = new System.Drawing.Size(310, 25);
            this.statusScale.Text = "1:1";
            this.statusScale.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // statusPosition
            // 
            this.statusPosition.AutoSize = false;
            this.statusPosition.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusPosition.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusPosition.Name = "statusPosition";
            this.statusPosition.Size = new System.Drawing.Size(310, 25);
            this.statusPosition.Text = "X:0.0, Y:0.0";
            // 
            // statuSelected
            // 
            this.statuSelected.AutoSize = false;
            this.statuSelected.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statuSelected.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statuSelected.Name = "statuSelected";
            this.statuSelected.Size = new System.Drawing.Size(165, 25);
            this.statuSelected.Text = "(null)";
            // 
            // layerTreeView
            // 
            this.layerTreeView.AllowDrop = true;
            this.layerTreeView.ImageIndex = 0;
            this.layerTreeView.ImageList = this.layerImageList;
            this.layerTreeView.Location = new System.Drawing.Point(0, 57);
            this.layerTreeView.Name = "layerTreeView";
            this.layerTreeView.SelectedImageIndex = 0;
            this.layerTreeView.Size = new System.Drawing.Size(172, 432);
            this.layerTreeView.TabIndex = 3;
            this.layerTreeView.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.TreeView1_DrawNode);
            this.layerTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.LayerTreeView_ItemDrag);
            this.layerTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.LayerTreeView_DragDrop);
            this.layerTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.LayerTreeView_DragEnter);
            this.layerTreeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LayerTreeView_MouseUp);
            // 
            // layerImageList
            // 
            this.layerImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("layerImageList.ImageStream")));
            this.layerImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.layerImageList.Images.SetKeyName(0, "LayerGroup.png");
            this.layerImageList.Images.SetKeyName(1, "LayerPoint.png");
            this.layerImageList.Images.SetKeyName(2, "LayerLine.png");
            this.layerImageList.Images.SetKeyName(3, "LayerPolygon.png");
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.CanOverflow = false;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建,
            this.打开,
            this.保存,
            this.添加数据,
            this.放大,
            this.缩小,
            this.平移,
            this.固定比例放大,
            this.固定比例缩小,
            this.选择要素,
            this.识别,
            this.转到XY});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip.Size = new System.Drawing.Size(957, 30);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "工具栏";
            // 
            // 新建
            // 
            this.新建.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.新建.Image = ((System.Drawing.Image)(resources.GetObject("新建.Image")));
            this.新建.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.新建.Name = "新建";
            this.新建.Size = new System.Drawing.Size(36, 27);
            this.新建.Text = "新建";
            this.新建.ToolTipText = "新建";
            this.新建.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // 打开
            // 
            this.打开.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.打开.Image = ((System.Drawing.Image)(resources.GetObject("打开.Image")));
            this.打开.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打开.Name = "打开";
            this.打开.Size = new System.Drawing.Size(36, 27);
            this.打开.Text = "打开";
            this.打开.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // 保存
            // 
            this.保存.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.保存.Image = ((System.Drawing.Image)(resources.GetObject("保存.Image")));
            this.保存.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.保存.Name = "保存";
            this.保存.Size = new System.Drawing.Size(36, 27);
            this.保存.Text = "保存";
            this.保存.Click += new System.EventHandler(this.保存_Click);
            // 
            // 添加数据
            // 
            this.添加数据.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.添加数据.Image = ((System.Drawing.Image)(resources.GetObject("添加数据.Image")));
            this.添加数据.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.添加数据.Name = "添加数据";
            this.添加数据.Size = new System.Drawing.Size(36, 27);
            this.添加数据.Text = "添加数据";
            this.添加数据.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // 放大
            // 
            this.放大.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.放大.Image = ((System.Drawing.Image)(resources.GetObject("放大.Image")));
            this.放大.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.放大.Name = "放大";
            this.放大.Size = new System.Drawing.Size(36, 27);
            this.放大.Text = "放大";
            this.放大.Click += new System.EventHandler(this.放大_Click);
            // 
            // 缩小
            // 
            this.缩小.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.缩小.Image = ((System.Drawing.Image)(resources.GetObject("缩小.Image")));
            this.缩小.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.缩小.Name = "缩小";
            this.缩小.Size = new System.Drawing.Size(36, 27);
            this.缩小.Text = "缩小";
            this.缩小.Click += new System.EventHandler(this.缩小_Click);
            // 
            // 平移
            // 
            this.平移.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.平移.Image = ((System.Drawing.Image)(resources.GetObject("平移.Image")));
            this.平移.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.平移.Name = "平移";
            this.平移.Size = new System.Drawing.Size(36, 27);
            this.平移.Text = "平移";
            this.平移.Click += new System.EventHandler(this.平移_Click);
            // 
            // 固定比例放大
            // 
            this.固定比例放大.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.固定比例放大.Image = ((System.Drawing.Image)(resources.GetObject("固定比例放大.Image")));
            this.固定比例放大.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.固定比例放大.Name = "固定比例放大";
            this.固定比例放大.Size = new System.Drawing.Size(36, 27);
            this.固定比例放大.Text = "固定比例放大";
            // 
            // 固定比例缩小
            // 
            this.固定比例缩小.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.固定比例缩小.Image = ((System.Drawing.Image)(resources.GetObject("固定比例缩小.Image")));
            this.固定比例缩小.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.固定比例缩小.Name = "固定比例缩小";
            this.固定比例缩小.Size = new System.Drawing.Size(36, 27);
            this.固定比例缩小.Text = "固定比例缩小";
            // 
            // 选择要素
            // 
            this.选择要素.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.选择要素.Image = ((System.Drawing.Image)(resources.GetObject("选择要素.Image")));
            this.选择要素.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.选择要素.Name = "选择要素";
            this.选择要素.Size = new System.Drawing.Size(36, 27);
            this.选择要素.Text = "选择要素";
            this.选择要素.Click += new System.EventHandler(this.选择要素_Click);
            // 
            // 识别
            // 
            this.识别.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.识别.Image = ((System.Drawing.Image)(resources.GetObject("识别.Image")));
            this.识别.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.识别.Name = "识别";
            this.识别.Size = new System.Drawing.Size(36, 27);
            this.识别.Text = "识别";
            this.识别.Click += new System.EventHandler(this.识别_Click);
            // 
            // 转到XY
            // 
            this.转到XY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.转到XY.Image = ((System.Drawing.Image)(resources.GetObject("转到XY.Image")));
            this.转到XY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.转到XY.Name = "转到XY";
            this.转到XY.Size = new System.Drawing.Size(36, 27);
            this.转到XY.Text = "转到XY";
            // 
            // openShapefileDialog
            // 
            this.openShapefileDialog.FileName = "openFileDialog1";
            this.openShapefileDialog.Filter = "|*.shp";
            // 
            // layerContextMenuStrip
            // 
            this.layerContextMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.layerContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.属性ToolStripMenuItem,
            this.打开属性表ToolStripMenuItem,
            this.缩放至图层ToolStripMenuItem,
            this.删除图层ToolStripMenuItem,
            this.toolStripMenuItem1});
            this.layerContextMenuStrip.Name = "layerContextMenuStrip";
            this.layerContextMenuStrip.Size = new System.Drawing.Size(181, 136);
            // 
            // 属性ToolStripMenuItem
            // 
            this.属性ToolStripMenuItem.Name = "属性ToolStripMenuItem";
            this.属性ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.属性ToolStripMenuItem.Text = "属性";
            this.属性ToolStripMenuItem.Click += new System.EventHandler(this.属性ToolStripMenuItem_Click);
            // 
            // 打开属性表ToolStripMenuItem
            // 
            this.打开属性表ToolStripMenuItem.Name = "打开属性表ToolStripMenuItem";
            this.打开属性表ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.打开属性表ToolStripMenuItem.Text = "打开属性表";
            this.打开属性表ToolStripMenuItem.Click += new System.EventHandler(this.打开属性表ToolStripMenuItem_Click);
            // 
            // 缩放至图层ToolStripMenuItem
            // 
            this.缩放至图层ToolStripMenuItem.Name = "缩放至图层ToolStripMenuItem";
            this.缩放至图层ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.缩放至图层ToolStripMenuItem.Text = "缩放至图层";
            this.缩放至图层ToolStripMenuItem.Click += new System.EventHandler(this.缩放至图层ToolStripMenuItem_Click);
            // 
            // 删除图层ToolStripMenuItem
            // 
            this.删除图层ToolStripMenuItem.Name = "删除图层ToolStripMenuItem";
            this.删除图层ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.删除图层ToolStripMenuItem.Text = "移除图层";
            this.删除图层ToolStripMenuItem.Click += new System.EventHandler(this.删除图层ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "添加标注";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // saveProjectFileDialog
            // 
            this.saveProjectFileDialog.Filter = "|*.ant";
            // 
            // openProjectFileDialog
            // 
            this.openProjectFileDialog.Filter = "|*.ant";
            // 
            // mcMap
            // 
            this.mcMap.BackColor = System.Drawing.Color.White;
            this.mcMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mcMap.Layers = new GISDesign_ZY.Layer[0];
            this.mcMap.Location = new System.Drawing.Point(177, 57);
            this.mcMap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mcMap.Name = "mcMap";
            this.mcMap.SelectedLayers = new GISDesign_ZY.Layer[0];
            this.mcMap.SelfMouseWheel = true;
            this.mcMap.Size = new System.Drawing.Size(780, 400);
            this.mcMap.TabIndex = 5;
            this.mcMap.DisplayScaleChanged += new GISDesign_ZY.MapControl.DisplayScaleChangedHandle(this.McMap_DisplayScaleChanged);
            this.mcMap.SelectingByBoxFinished += new GISDesign_ZY.MapControl.SelectingByBoxFinishedHandle(this.McMap_SelectingByBoxFinished);
            this.mcMap.SelectingByPointFinished += new GISDesign_ZY.MapControl.SelectingByPointFinishedHandle(this.McMap_SelectingByPointFinished);
            this.mcMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.McMap_MouseMove);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 498);
            this.Controls.Add(this.mcMap);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.layerTreeView);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximumSize = new System.Drawing.Size(973, 537);
            this.Name = "mainForm";
            this.Text = "AntMap";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.layerContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 插入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 制图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加静态注记ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加指北针ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusScale;
        private System.Windows.Forms.ToolStripStatusLabel statusPosition;
        private System.Windows.Forms.TreeView layerTreeView;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton 新建;
        private System.Windows.Forms.ToolStripButton 打开;
        private System.Windows.Forms.ToolStripStatusLabel statuSelected;
        private System.Windows.Forms.ImageList layerImageList;
        private System.Windows.Forms.ToolStripButton 保存;
        private System.Windows.Forms.ToolStripButton 添加数据;
        private System.Windows.Forms.ToolStripButton 放大;
        private System.Windows.Forms.ToolStripButton 缩小;
        private System.Windows.Forms.ToolStripButton 平移;
        private System.Windows.Forms.ToolStripButton 固定比例放大;
        private System.Windows.Forms.ToolStripButton 固定比例缩小;
        private System.Windows.Forms.ToolStripButton 选择要素;
        private System.Windows.Forms.ToolStripButton 转到XY;
        private System.Windows.Forms.ToolStripButton 识别;
        private System.Windows.Forms.ToolStripMenuItem 编辑选中要素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除选中要素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择要素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加图层ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 添加要素ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 另存为ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 添加数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem shapefile文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem antMap文件ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openShapefileDialog;
        private System.Windows.Forms.ContextMenuStrip layerContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 属性ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开属性表ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveProjectFileDialog;
        private System.Windows.Forms.OpenFileDialog openProjectFileDialog;
        private GISDesign_ZY.MapControl mcMap;
        private System.Windows.Forms.ToolStripMenuItem 按属性选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 使用帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于蚁图ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 添加比例尺ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缩放至图层ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存BMPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ShapeFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除图层ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除所选要素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

