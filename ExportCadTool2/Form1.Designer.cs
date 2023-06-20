namespace ExportCadTool2
{
    partial class CadDataExportTool
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectFile_ListBox = new System.Windows.Forms.ListBox();
            this.FileSelect_GroupBox = new System.Windows.Forms.GroupBox();
            this.FileSelectRest_Button = new System.Windows.Forms.Button();
            this.SelectFile_Button = new System.Windows.Forms.Button();
            this.DocumentExportExtension_GroupBox = new System.Windows.Forms.GroupBox();
            this.DXF_CheckBox = new System.Windows.Forms.CheckBox();
            this.PDF_CheckBox = new System.Windows.Forms.CheckBox();
            this.ModelExportExtension_GroupBox = new System.Windows.Forms.GroupBox();
            this.STL_CheckBox = new System.Windows.Forms.CheckBox();
            this.IGS_CheckBox = new System.Windows.Forms.CheckBox();
            this.STEP_CheckBox = new System.Windows.Forms.CheckBox();
            this.SelectExportFilePath_GroupBox = new System.Windows.Forms.GroupBox();
            this.SelectExportFolderPath_Button = new System.Windows.Forms.Button();
            this.ExportFolderPath_ListBox = new System.Windows.Forms.ListBox();
            this.MoveExportFile_CheckBox = new System.Windows.Forms.CheckBox();
            this.NoMoveExportFile_CheckBox = new System.Windows.Forms.CheckBox();
            this.ExportOption_GroupBox = new System.Windows.Forms.GroupBox();
            this.FileName_Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Suffix_TextBox = new System.Windows.Forms.TextBox();
            this.Prefix_TextBox = new System.Windows.Forms.TextBox();
            this.SelectZipFolderPath_Button = new System.Windows.Forms.Button();
            this.SeparateFoldersByPartname_CheckBox = new System.Windows.Forms.CheckBox();
            this.ZipFolderPath_ListBox = new System.Windows.Forms.ListBox();
            this.AddSuffix_CheckBox = new System.Windows.Forms.CheckBox();
            this.AddPrefix_CheckBox = new System.Windows.Forms.CheckBox();
            this.MakeZipAnotherFolderPath_CheckBox = new System.Windows.Forms.CheckBox();
            this.MakeZipSameExportFolderPath_CheckBox = new System.Windows.Forms.CheckBox();
            this.MakeZipFileByPartName_CheckBox = new System.Windows.Forms.CheckBox();
            this.SeparateFolderByExtension_CheckBox = new System.Windows.Forms.CheckBox();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.StartExport_Button = new System.Windows.Forms.Button();
            this.Task_ProgressBar = new System.Windows.Forms.ProgressBar();
            this.Progress_Label = new System.Windows.Forms.Label();
            this.StartExoport_GroupBox = new System.Windows.Forms.GroupBox();
            this.SelectFile_OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Option_GroupBox = new System.Windows.Forms.GroupBox();
            this.OptionRest_Button = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.FileSelect_GroupBox.SuspendLayout();
            this.DocumentExportExtension_GroupBox.SuspendLayout();
            this.ModelExportExtension_GroupBox.SuspendLayout();
            this.SelectExportFilePath_GroupBox.SuspendLayout();
            this.ExportOption_GroupBox.SuspendLayout();
            this.StartExoport_GroupBox.SuspendLayout();
            this.Option_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectFile_ListBox
            // 
            this.SelectFile_ListBox.AllowDrop = true;
            this.SelectFile_ListBox.FormattingEnabled = true;
            this.SelectFile_ListBox.HorizontalScrollbar = true;
            this.SelectFile_ListBox.ItemHeight = 12;
            this.SelectFile_ListBox.Location = new System.Drawing.Point(6, 44);
            this.SelectFile_ListBox.Name = "SelectFile_ListBox";
            this.SelectFile_ListBox.Size = new System.Drawing.Size(370, 532);
            this.SelectFile_ListBox.TabIndex = 0;
            this.SelectFile_ListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.SelectFile_ListBox_DragDrop);
            this.SelectFile_ListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.SelectFile_ListBox_DragEnter);
            this.SelectFile_ListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectFile_KeyDown);
            // 
            // FileSelect_GroupBox
            // 
            this.FileSelect_GroupBox.Controls.Add(this.FileSelectRest_Button);
            this.FileSelect_GroupBox.Controls.Add(this.SelectFile_Button);
            this.FileSelect_GroupBox.Controls.Add(this.SelectFile_ListBox);
            this.FileSelect_GroupBox.Location = new System.Drawing.Point(12, 12);
            this.FileSelect_GroupBox.Name = "FileSelect_GroupBox";
            this.FileSelect_GroupBox.Size = new System.Drawing.Size(387, 584);
            this.FileSelect_GroupBox.TabIndex = 1;
            this.FileSelect_GroupBox.TabStop = false;
            this.FileSelect_GroupBox.Text = "ファイル選択";
            // 
            // FileSelectRest_Button
            // 
            this.FileSelectRest_Button.Location = new System.Drawing.Point(247, 15);
            this.FileSelectRest_Button.Name = "FileSelectRest_Button";
            this.FileSelectRest_Button.Size = new System.Drawing.Size(75, 23);
            this.FileSelectRest_Button.TabIndex = 2;
            this.FileSelectRest_Button.Text = "選択リセット";
            this.FileSelectRest_Button.UseVisualStyleBackColor = true;
            this.FileSelectRest_Button.Click += new System.EventHandler(this.FileSelectRest_Button_Click);
            // 
            // SelectFile_Button
            // 
            this.SelectFile_Button.Location = new System.Drawing.Point(328, 15);
            this.SelectFile_Button.Name = "SelectFile_Button";
            this.SelectFile_Button.Size = new System.Drawing.Size(50, 23);
            this.SelectFile_Button.TabIndex = 1;
            this.SelectFile_Button.Text = "参照";
            this.SelectFile_Button.UseVisualStyleBackColor = true;
            this.SelectFile_Button.Click += new System.EventHandler(this.SelectFile_Button_Click);
            // 
            // DocumentExportExtension_GroupBox
            // 
            this.DocumentExportExtension_GroupBox.Controls.Add(this.DXF_CheckBox);
            this.DocumentExportExtension_GroupBox.Controls.Add(this.PDF_CheckBox);
            this.DocumentExportExtension_GroupBox.Enabled = false;
            this.DocumentExportExtension_GroupBox.Location = new System.Drawing.Point(9, 43);
            this.DocumentExportExtension_GroupBox.Name = "DocumentExportExtension_GroupBox";
            this.DocumentExportExtension_GroupBox.Size = new System.Drawing.Size(458, 41);
            this.DocumentExportExtension_GroupBox.TabIndex = 2;
            this.DocumentExportExtension_GroupBox.TabStop = false;
            this.DocumentExportExtension_GroupBox.Text = "図面エクスポート形式";
            // 
            // DXF_CheckBox
            // 
            this.DXF_CheckBox.AutoSize = true;
            this.DXF_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.DXF_CheckBox.Location = new System.Drawing.Point(52, 18);
            this.DXF_CheckBox.Name = "DXF_CheckBox";
            this.DXF_CheckBox.Size = new System.Drawing.Size(40, 16);
            this.DXF_CheckBox.TabIndex = 0;
            this.DXF_CheckBox.Text = "dxf";
            this.DXF_CheckBox.UseVisualStyleBackColor = true;
            this.DXF_CheckBox.CheckedChanged += new System.EventHandler(this.DXF_CheckBox_CheckedChanged);
            // 
            // PDF_CheckBox
            // 
            this.PDF_CheckBox.AutoSize = true;
            this.PDF_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.PDF_CheckBox.Location = new System.Drawing.Point(6, 18);
            this.PDF_CheckBox.Name = "PDF_CheckBox";
            this.PDF_CheckBox.Size = new System.Drawing.Size(40, 16);
            this.PDF_CheckBox.TabIndex = 0;
            this.PDF_CheckBox.Text = "pdf";
            this.PDF_CheckBox.UseVisualStyleBackColor = true;
            this.PDF_CheckBox.CheckedChanged += new System.EventHandler(this.PDF_CheckBox_CheckedChanged);
            // 
            // ModelExportExtension_GroupBox
            // 
            this.ModelExportExtension_GroupBox.Controls.Add(this.STL_CheckBox);
            this.ModelExportExtension_GroupBox.Controls.Add(this.IGS_CheckBox);
            this.ModelExportExtension_GroupBox.Controls.Add(this.STEP_CheckBox);
            this.ModelExportExtension_GroupBox.Enabled = false;
            this.ModelExportExtension_GroupBox.Location = new System.Drawing.Point(9, 90);
            this.ModelExportExtension_GroupBox.Name = "ModelExportExtension_GroupBox";
            this.ModelExportExtension_GroupBox.Size = new System.Drawing.Size(458, 41);
            this.ModelExportExtension_GroupBox.TabIndex = 3;
            this.ModelExportExtension_GroupBox.TabStop = false;
            this.ModelExportExtension_GroupBox.Text = "モデルエクスポート形式";
            // 
            // STL_CheckBox
            // 
            this.STL_CheckBox.AutoSize = true;
            this.STL_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.STL_CheckBox.Location = new System.Drawing.Point(97, 18);
            this.STL_CheckBox.Name = "STL_CheckBox";
            this.STL_CheckBox.Size = new System.Drawing.Size(37, 16);
            this.STL_CheckBox.TabIndex = 0;
            this.STL_CheckBox.Text = "stl";
            this.STL_CheckBox.UseVisualStyleBackColor = true;
            this.STL_CheckBox.CheckedChanged += new System.EventHandler(this.STL_CheckBox_CheckedChanged);
            // 
            // IGS_CheckBox
            // 
            this.IGS_CheckBox.AutoSize = true;
            this.IGS_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.IGS_CheckBox.Location = new System.Drawing.Point(52, 19);
            this.IGS_CheckBox.Name = "IGS_CheckBox";
            this.IGS_CheckBox.Size = new System.Drawing.Size(39, 16);
            this.IGS_CheckBox.TabIndex = 0;
            this.IGS_CheckBox.Text = "igs";
            this.IGS_CheckBox.UseVisualStyleBackColor = true;
            this.IGS_CheckBox.CheckedChanged += new System.EventHandler(this.IGS_CheckBox_CheckedChanged);
            // 
            // STEP_CheckBox
            // 
            this.STEP_CheckBox.AutoSize = true;
            this.STEP_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.STEP_CheckBox.Location = new System.Drawing.Point(6, 18);
            this.STEP_CheckBox.Name = "STEP_CheckBox";
            this.STEP_CheckBox.Size = new System.Drawing.Size(46, 16);
            this.STEP_CheckBox.TabIndex = 0;
            this.STEP_CheckBox.Text = "step";
            this.STEP_CheckBox.UseVisualStyleBackColor = true;
            this.STEP_CheckBox.CheckedChanged += new System.EventHandler(this.STEP_CheckBox_CheckedChanged);
            // 
            // SelectExportFilePath_GroupBox
            // 
            this.SelectExportFilePath_GroupBox.Controls.Add(this.SelectExportFolderPath_Button);
            this.SelectExportFilePath_GroupBox.Controls.Add(this.ExportFolderPath_ListBox);
            this.SelectExportFilePath_GroupBox.Controls.Add(this.MoveExportFile_CheckBox);
            this.SelectExportFilePath_GroupBox.Controls.Add(this.NoMoveExportFile_CheckBox);
            this.SelectExportFilePath_GroupBox.Enabled = false;
            this.SelectExportFilePath_GroupBox.Location = new System.Drawing.Point(9, 137);
            this.SelectExportFilePath_GroupBox.Name = "SelectExportFilePath_GroupBox";
            this.SelectExportFilePath_GroupBox.Size = new System.Drawing.Size(458, 129);
            this.SelectExportFilePath_GroupBox.TabIndex = 3;
            this.SelectExportFilePath_GroupBox.TabStop = false;
            this.SelectExportFilePath_GroupBox.Text = "出力フォルダ";
            // 
            // SelectExportFolderPath_Button
            // 
            this.SelectExportFolderPath_Button.Enabled = false;
            this.SelectExportFolderPath_Button.Location = new System.Drawing.Point(400, 63);
            this.SelectExportFolderPath_Button.Name = "SelectExportFolderPath_Button";
            this.SelectExportFolderPath_Button.Size = new System.Drawing.Size(50, 23);
            this.SelectExportFolderPath_Button.TabIndex = 2;
            this.SelectExportFolderPath_Button.Text = "参照";
            this.SelectExportFolderPath_Button.UseVisualStyleBackColor = true;
            this.SelectExportFolderPath_Button.Click += new System.EventHandler(this.SelectExportFolderPath_Button_Click);
            // 
            // ExportFolderPath_ListBox
            // 
            this.ExportFolderPath_ListBox.BackColor = System.Drawing.SystemColors.Control;
            this.ExportFolderPath_ListBox.Enabled = false;
            this.ExportFolderPath_ListBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ExportFolderPath_ListBox.FormattingEnabled = true;
            this.ExportFolderPath_ListBox.HorizontalScrollbar = true;
            this.ExportFolderPath_ListBox.ItemHeight = 12;
            this.ExportFolderPath_ListBox.Location = new System.Drawing.Point(6, 63);
            this.ExportFolderPath_ListBox.Name = "ExportFolderPath_ListBox";
            this.ExportFolderPath_ListBox.Size = new System.Drawing.Size(387, 52);
            this.ExportFolderPath_ListBox.TabIndex = 1;
            this.ExportFolderPath_ListBox.EnabledChanged += new System.EventHandler(this.ExportFolderPath_ListBox_EnabledChanged);
            this.ExportFolderPath_ListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExportFolderPath_ListBox_KeyDown);
            // 
            // MoveExportFile_CheckBox
            // 
            this.MoveExportFile_CheckBox.AutoSize = true;
            this.MoveExportFile_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.MoveExportFile_CheckBox.Location = new System.Drawing.Point(6, 40);
            this.MoveExportFile_CheckBox.Name = "MoveExportFile_CheckBox";
            this.MoveExportFile_CheckBox.Size = new System.Drawing.Size(93, 16);
            this.MoveExportFile_CheckBox.TabIndex = 0;
            this.MoveExportFile_CheckBox.Text = "以下のフォルダ";
            this.MoveExportFile_CheckBox.UseVisualStyleBackColor = true;
            this.MoveExportFile_CheckBox.CheckedChanged += new System.EventHandler(this.MoveExportFile_CheckBox_CheckedChanged);
            // 
            // NoMoveExportFile_CheckBox
            // 
            this.NoMoveExportFile_CheckBox.AutoSize = true;
            this.NoMoveExportFile_CheckBox.Checked = true;
            this.NoMoveExportFile_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NoMoveExportFile_CheckBox.Location = new System.Drawing.Point(6, 18);
            this.NoMoveExportFile_CheckBox.Name = "NoMoveExportFile_CheckBox";
            this.NoMoveExportFile_CheckBox.Size = new System.Drawing.Size(133, 16);
            this.NoMoveExportFile_CheckBox.TabIndex = 0;
            this.NoMoveExportFile_CheckBox.Text = "元のファイルと同じ場所";
            this.NoMoveExportFile_CheckBox.UseVisualStyleBackColor = true;
            this.NoMoveExportFile_CheckBox.CheckedChanged += new System.EventHandler(this.NoMoveExportFile_CheckBox_CheckedChanged);
            // 
            // ExportOption_GroupBox
            // 
            this.ExportOption_GroupBox.Controls.Add(this.FileName_Label);
            this.ExportOption_GroupBox.Controls.Add(this.label1);
            this.ExportOption_GroupBox.Controls.Add(this.Suffix_TextBox);
            this.ExportOption_GroupBox.Controls.Add(this.Prefix_TextBox);
            this.ExportOption_GroupBox.Controls.Add(this.SelectZipFolderPath_Button);
            this.ExportOption_GroupBox.Controls.Add(this.SeparateFoldersByPartname_CheckBox);
            this.ExportOption_GroupBox.Controls.Add(this.ZipFolderPath_ListBox);
            this.ExportOption_GroupBox.Controls.Add(this.AddSuffix_CheckBox);
            this.ExportOption_GroupBox.Controls.Add(this.AddPrefix_CheckBox);
            this.ExportOption_GroupBox.Controls.Add(this.MakeZipAnotherFolderPath_CheckBox);
            this.ExportOption_GroupBox.Controls.Add(this.MakeZipSameExportFolderPath_CheckBox);
            this.ExportOption_GroupBox.Controls.Add(this.MakeZipFileByPartName_CheckBox);
            this.ExportOption_GroupBox.Controls.Add(this.SeparateFolderByExtension_CheckBox);
            this.ExportOption_GroupBox.Enabled = false;
            this.ExportOption_GroupBox.Location = new System.Drawing.Point(9, 272);
            this.ExportOption_GroupBox.Name = "ExportOption_GroupBox";
            this.ExportOption_GroupBox.Size = new System.Drawing.Size(458, 233);
            this.ExportOption_GroupBox.TabIndex = 3;
            this.ExportOption_GroupBox.TabStop = false;
            this.ExportOption_GroupBox.Text = "その他";
            // 
            // FileName_Label
            // 
            this.FileName_Label.AutoSize = true;
            this.FileName_Label.Location = new System.Drawing.Point(343, 183);
            this.FileName_Label.Name = "FileName_Label";
            this.FileName_Label.Size = new System.Drawing.Size(68, 12);
            this.FileName_Label.TabIndex = 4;
            this.FileName_Label.Text = "XXX.SDDRW";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "ファイル名例：";
            // 
            // Suffix_TextBox
            // 
            this.Suffix_TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.Suffix_TextBox.Enabled = false;
            this.Suffix_TextBox.Location = new System.Drawing.Point(145, 207);
            this.Suffix_TextBox.Name = "Suffix_TextBox";
            this.Suffix_TextBox.Size = new System.Drawing.Size(117, 19);
            this.Suffix_TextBox.TabIndex = 3;
            this.Suffix_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Suffix_TextBox.TextChanged += new System.EventHandler(this.Suffix_TextBox_TextChanged);
            // 
            // Prefix_TextBox
            // 
            this.Prefix_TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.Prefix_TextBox.Enabled = false;
            this.Prefix_TextBox.Location = new System.Drawing.Point(145, 183);
            this.Prefix_TextBox.Name = "Prefix_TextBox";
            this.Prefix_TextBox.Size = new System.Drawing.Size(117, 19);
            this.Prefix_TextBox.TabIndex = 3;
            this.Prefix_TextBox.TextChanged += new System.EventHandler(this.Prefix_TextBox_TextChanged);
            // 
            // SelectZipFolderPath_Button
            // 
            this.SelectZipFolderPath_Button.Enabled = false;
            this.SelectZipFolderPath_Button.Location = new System.Drawing.Point(401, 128);
            this.SelectZipFolderPath_Button.Name = "SelectZipFolderPath_Button";
            this.SelectZipFolderPath_Button.Size = new System.Drawing.Size(49, 23);
            this.SelectZipFolderPath_Button.TabIndex = 2;
            this.SelectZipFolderPath_Button.Text = "参照";
            this.SelectZipFolderPath_Button.UseVisualStyleBackColor = true;
            this.SelectZipFolderPath_Button.Click += new System.EventHandler(this.SelectZipFolderPath_Button_Click);
            // 
            // SeparateFoldersByPartname_CheckBox
            // 
            this.SeparateFoldersByPartname_CheckBox.AutoSize = true;
            this.SeparateFoldersByPartname_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.SeparateFoldersByPartname_CheckBox.Location = new System.Drawing.Point(6, 40);
            this.SeparateFoldersByPartname_CheckBox.Name = "SeparateFoldersByPartname_CheckBox";
            this.SeparateFoldersByPartname_CheckBox.Size = new System.Drawing.Size(161, 16);
            this.SeparateFoldersByPartname_CheckBox.TabIndex = 0;
            this.SeparateFoldersByPartname_CheckBox.Text = "部品名ごとにフォルダを分ける";
            this.SeparateFoldersByPartname_CheckBox.UseVisualStyleBackColor = true;
            this.SeparateFoldersByPartname_CheckBox.CheckedChanged += new System.EventHandler(this.SeparateFoldersByPartname_CheckBox_CheckedChanged);
            // 
            // ZipFolderPath_ListBox
            // 
            this.ZipFolderPath_ListBox.BackColor = System.Drawing.SystemColors.Control;
            this.ZipFolderPath_ListBox.Enabled = false;
            this.ZipFolderPath_ListBox.FormattingEnabled = true;
            this.ZipFolderPath_ListBox.ItemHeight = 12;
            this.ZipFolderPath_ListBox.Location = new System.Drawing.Point(19, 128);
            this.ZipFolderPath_ListBox.Name = "ZipFolderPath_ListBox";
            this.ZipFolderPath_ListBox.Size = new System.Drawing.Size(374, 52);
            this.ZipFolderPath_ListBox.TabIndex = 1;
            this.ZipFolderPath_ListBox.EnabledChanged += new System.EventHandler(this.ZipFolderPath_ListBox_EnabledChanged);
            // 
            // AddSuffix_CheckBox
            // 
            this.AddSuffix_CheckBox.AutoSize = true;
            this.AddSuffix_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.AddSuffix_CheckBox.Location = new System.Drawing.Point(6, 210);
            this.AddSuffix_CheckBox.Name = "AddSuffix_CheckBox";
            this.AddSuffix_CheckBox.Size = new System.Drawing.Size(125, 16);
            this.AddSuffix_CheckBox.TabIndex = 0;
            this.AddSuffix_CheckBox.Text = "サフィックスを追加する";
            this.AddSuffix_CheckBox.UseVisualStyleBackColor = true;
            this.AddSuffix_CheckBox.CheckedChanged += new System.EventHandler(this.AddSuffix_CheckBox_CheckedChanged);
            // 
            // AddPrefix_CheckBox
            // 
            this.AddPrefix_CheckBox.AutoSize = true;
            this.AddPrefix_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.AddPrefix_CheckBox.Location = new System.Drawing.Point(6, 186);
            this.AddPrefix_CheckBox.Name = "AddPrefix_CheckBox";
            this.AddPrefix_CheckBox.Size = new System.Drawing.Size(133, 16);
            this.AddPrefix_CheckBox.TabIndex = 0;
            this.AddPrefix_CheckBox.Text = "プレフィックスを追加する";
            this.AddPrefix_CheckBox.UseVisualStyleBackColor = true;
            this.AddPrefix_CheckBox.CheckedChanged += new System.EventHandler(this.AddPrefix_CheckBox_CheckedChanged);
            // 
            // MakeZipAnotherFolderPath_CheckBox
            // 
            this.MakeZipAnotherFolderPath_CheckBox.AutoSize = true;
            this.MakeZipAnotherFolderPath_CheckBox.Enabled = false;
            this.MakeZipAnotherFolderPath_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.MakeZipAnotherFolderPath_CheckBox.Location = new System.Drawing.Point(19, 106);
            this.MakeZipAnotherFolderPath_CheckBox.Name = "MakeZipAnotherFolderPath_CheckBox";
            this.MakeZipAnotherFolderPath_CheckBox.Size = new System.Drawing.Size(93, 16);
            this.MakeZipAnotherFolderPath_CheckBox.TabIndex = 0;
            this.MakeZipAnotherFolderPath_CheckBox.Text = "以下のフォルダ";
            this.MakeZipAnotherFolderPath_CheckBox.UseVisualStyleBackColor = true;
            this.MakeZipAnotherFolderPath_CheckBox.CheckedChanged += new System.EventHandler(this.MakeZipAnotherFolderPath_CheckBox_CheckedChanged);
            // 
            // MakeZipSameExportFolderPath_CheckBox
            // 
            this.MakeZipSameExportFolderPath_CheckBox.AutoSize = true;
            this.MakeZipSameExportFolderPath_CheckBox.Enabled = false;
            this.MakeZipSameExportFolderPath_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.MakeZipSameExportFolderPath_CheckBox.Location = new System.Drawing.Point(19, 84);
            this.MakeZipSameExportFolderPath_CheckBox.Name = "MakeZipSameExportFolderPath_CheckBox";
            this.MakeZipSameExportFolderPath_CheckBox.Size = new System.Drawing.Size(136, 16);
            this.MakeZipSameExportFolderPath_CheckBox.TabIndex = 0;
            this.MakeZipSameExportFolderPath_CheckBox.Text = "出力フォルダと同じ場所";
            this.MakeZipSameExportFolderPath_CheckBox.UseVisualStyleBackColor = true;
            this.MakeZipSameExportFolderPath_CheckBox.CheckedChanged += new System.EventHandler(this.MakeZipSameExportFolderPath_CheckBox_CheckedChanged);
            // 
            // MakeZipFileByPartName_CheckBox
            // 
            this.MakeZipFileByPartName_CheckBox.AutoSize = true;
            this.MakeZipFileByPartName_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.MakeZipFileByPartName_CheckBox.Location = new System.Drawing.Point(6, 62);
            this.MakeZipFileByPartName_CheckBox.Name = "MakeZipFileByPartName_CheckBox";
            this.MakeZipFileByPartName_CheckBox.Size = new System.Drawing.Size(177, 16);
            this.MakeZipFileByPartName_CheckBox.TabIndex = 0;
            this.MakeZipFileByPartName_CheckBox.Text = "部品ごとのZipファイルを生成する";
            this.MakeZipFileByPartName_CheckBox.UseVisualStyleBackColor = true;
            this.MakeZipFileByPartName_CheckBox.CheckedChanged += new System.EventHandler(this.MakeZipFileByPartName_CheckBox_CheckedChanged);
            // 
            // SeparateFolderByExtension_CheckBox
            // 
            this.SeparateFolderByExtension_CheckBox.AutoSize = true;
            this.SeparateFolderByExtension_CheckBox.Checked = true;
            this.SeparateFolderByExtension_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SeparateFolderByExtension_CheckBox.Location = new System.Drawing.Point(6, 18);
            this.SeparateFolderByExtension_CheckBox.Name = "SeparateFolderByExtension_CheckBox";
            this.SeparateFolderByExtension_CheckBox.Size = new System.Drawing.Size(161, 16);
            this.SeparateFolderByExtension_CheckBox.TabIndex = 0;
            this.SeparateFolderByExtension_CheckBox.Text = "拡張子ごとにフォルダを分ける";
            this.SeparateFolderByExtension_CheckBox.UseVisualStyleBackColor = true;
            this.SeparateFolderByExtension_CheckBox.CheckedChanged += new System.EventHandler(this.SeparateFolderByExtension_CheckBox_CheckedChanged);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Location = new System.Drawing.Point(389, 34);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(60, 23);
            this.Cancel_Button.TabIndex = 2;
            this.Cancel_Button.Text = "終了";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // StartExport_Button
            // 
            this.StartExport_Button.Location = new System.Drawing.Point(308, 34);
            this.StartExport_Button.Name = "StartExport_Button";
            this.StartExport_Button.Size = new System.Drawing.Size(75, 23);
            this.StartExport_Button.TabIndex = 2;
            this.StartExport_Button.Text = "変換開始";
            this.StartExport_Button.UseVisualStyleBackColor = true;
            this.StartExport_Button.Click += new System.EventHandler(this.StartExport_Button_Click);
            // 
            // Task_ProgressBar
            // 
            this.Task_ProgressBar.Location = new System.Drawing.Point(6, 34);
            this.Task_ProgressBar.Name = "Task_ProgressBar";
            this.Task_ProgressBar.Size = new System.Drawing.Size(296, 23);
            this.Task_ProgressBar.TabIndex = 4;
            this.Task_ProgressBar.Click += new System.EventHandler(this.Task_ProgressBar_Click);
            // 
            // Progress_Label
            // 
            this.Progress_Label.AutoSize = true;
            this.Progress_Label.Location = new System.Drawing.Point(6, 15);
            this.Progress_Label.Name = "Progress_Label";
            this.Progress_Label.Size = new System.Drawing.Size(50, 12);
            this.Progress_Label.TabIndex = 5;
            this.Progress_Label.Text = "処理待ち";
            // 
            // StartExoport_GroupBox
            // 
            this.StartExoport_GroupBox.Controls.Add(this.Cancel_Button);
            this.StartExoport_GroupBox.Controls.Add(this.StartExport_Button);
            this.StartExoport_GroupBox.Controls.Add(this.Progress_Label);
            this.StartExoport_GroupBox.Controls.Add(this.Task_ProgressBar);
            this.StartExoport_GroupBox.Enabled = false;
            this.StartExoport_GroupBox.Location = new System.Drawing.Point(9, 511);
            this.StartExoport_GroupBox.Name = "StartExoport_GroupBox";
            this.StartExoport_GroupBox.Size = new System.Drawing.Size(458, 63);
            this.StartExoport_GroupBox.TabIndex = 6;
            this.StartExoport_GroupBox.TabStop = false;
            // 
            // SelectFile_OpenFileDialog
            // 
            this.SelectFile_OpenFileDialog.FileName = "SelectFile_OpenFileDialg";
            this.SelectFile_OpenFileDialog.Multiselect = true;
            // 
            // Option_GroupBox
            // 
            this.Option_GroupBox.Controls.Add(this.OptionRest_Button);
            this.Option_GroupBox.Controls.Add(this.ExportOption_GroupBox);
            this.Option_GroupBox.Controls.Add(this.DocumentExportExtension_GroupBox);
            this.Option_GroupBox.Controls.Add(this.StartExoport_GroupBox);
            this.Option_GroupBox.Controls.Add(this.ModelExportExtension_GroupBox);
            this.Option_GroupBox.Controls.Add(this.SelectExportFilePath_GroupBox);
            this.Option_GroupBox.Enabled = false;
            this.Option_GroupBox.Location = new System.Drawing.Point(406, 13);
            this.Option_GroupBox.Name = "Option_GroupBox";
            this.Option_GroupBox.Size = new System.Drawing.Size(473, 583);
            this.Option_GroupBox.TabIndex = 7;
            this.Option_GroupBox.TabStop = false;
            this.Option_GroupBox.Text = "出力オプション";
            // 
            // OptionRest_Button
            // 
            this.OptionRest_Button.Location = new System.Drawing.Point(366, 14);
            this.OptionRest_Button.Name = "OptionRest_Button";
            this.OptionRest_Button.Size = new System.Drawing.Size(101, 23);
            this.OptionRest_Button.TabIndex = 1;
            this.OptionRest_Button.Text = "オプションリセット";
            this.OptionRest_Button.UseVisualStyleBackColor = true;
            this.OptionRest_Button.Click += new System.EventHandler(this.OptionRest_Button_Click);
            // 
            // CadDataExportTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 601);
            this.Controls.Add(this.FileSelect_GroupBox);
            this.Controls.Add(this.Option_GroupBox);
            this.MinimumSize = new System.Drawing.Size(900, 640);
            this.Name = "CadDataExportTool";
            this.Text = "CADデータ出力ツール";
            this.FileSelect_GroupBox.ResumeLayout(false);
            this.DocumentExportExtension_GroupBox.ResumeLayout(false);
            this.DocumentExportExtension_GroupBox.PerformLayout();
            this.ModelExportExtension_GroupBox.ResumeLayout(false);
            this.ModelExportExtension_GroupBox.PerformLayout();
            this.SelectExportFilePath_GroupBox.ResumeLayout(false);
            this.SelectExportFilePath_GroupBox.PerformLayout();
            this.ExportOption_GroupBox.ResumeLayout(false);
            this.ExportOption_GroupBox.PerformLayout();
            this.StartExoport_GroupBox.ResumeLayout(false);
            this.StartExoport_GroupBox.PerformLayout();
            this.Option_GroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox SelectFile_ListBox;
        private System.Windows.Forms.GroupBox FileSelect_GroupBox;
        private System.Windows.Forms.Button SelectFile_Button;
        private System.Windows.Forms.GroupBox DocumentExportExtension_GroupBox;
        private System.Windows.Forms.CheckBox DXF_CheckBox;
        private System.Windows.Forms.CheckBox PDF_CheckBox;
        private System.Windows.Forms.GroupBox ModelExportExtension_GroupBox;
        private System.Windows.Forms.CheckBox STL_CheckBox;
        private System.Windows.Forms.CheckBox IGS_CheckBox;
        private System.Windows.Forms.CheckBox STEP_CheckBox;
        private System.Windows.Forms.GroupBox SelectExportFilePath_GroupBox;
        private System.Windows.Forms.Button SelectExportFolderPath_Button;
        private System.Windows.Forms.ListBox ExportFolderPath_ListBox;
        private System.Windows.Forms.CheckBox MoveExportFile_CheckBox;
        private System.Windows.Forms.CheckBox NoMoveExportFile_CheckBox;
        private System.Windows.Forms.GroupBox ExportOption_GroupBox;
        private System.Windows.Forms.Button SelectZipFolderPath_Button;
        private System.Windows.Forms.CheckBox SeparateFoldersByPartname_CheckBox;
        private System.Windows.Forms.ListBox ZipFolderPath_ListBox;
        private System.Windows.Forms.CheckBox SeparateFolderByExtension_CheckBox;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button StartExport_Button;
        private System.Windows.Forms.ProgressBar Task_ProgressBar;
        private System.Windows.Forms.CheckBox MakeZipFileByPartName_CheckBox;
        private System.Windows.Forms.CheckBox AddPrefix_CheckBox;
        private System.Windows.Forms.TextBox Suffix_TextBox;
        private System.Windows.Forms.CheckBox AddSuffix_CheckBox;
        private System.Windows.Forms.Label Progress_Label;
        private System.Windows.Forms.GroupBox StartExoport_GroupBox;
        private System.Windows.Forms.CheckBox MakeZipAnotherFolderPath_CheckBox;
        private System.Windows.Forms.CheckBox MakeZipSameExportFolderPath_CheckBox;
        private System.Windows.Forms.OpenFileDialog SelectFile_OpenFileDialog;
        private System.Windows.Forms.TextBox Prefix_TextBox;
        private System.Windows.Forms.Label FileName_Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button FileSelectRest_Button;
        private System.Windows.Forms.GroupBox Option_GroupBox;
        private System.Windows.Forms.Button OptionRest_Button;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

