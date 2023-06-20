using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.Toolkit.Uwp.Notifications;
using Microsoft.WindowsAPICodePack.Dialogs;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace ExportCadTool2
{
    public partial class CadDataExportTool : Form
    {
        SldWorks SolidworksApp = new SldWorks();
        public CadDataExportTool()
        {
            InitializeComponent();
        }

        private void SelectFile_ListBox_DragEnter(object sender, DragEventArgs e) //ドラッグ＆ドロップでリストに表示
        {
            e.Effect = DragDropEffects.All;
        }
        private void SelectFile_ListBox_DragDrop(object sender, DragEventArgs e) //ドラッグ＆ドロップでリストに表示
        {
            foreach (string item in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                SelectFile_ListBox.Items.Add(item);
                Toggle_GroupBox();
            }
        }

        private void SelectFile_Button_Click(object sender, EventArgs e) //元ファイル選択 複数選択可能なファイルダイアログを表示
        {
            SelectFile_OpenFileDialog.Filter = "SolidWorksファイル|*.SLDDRW;*.SLDPRT|すべてのファイル|*.*";
            // ダイアログボックスの表示
            if (SelectFile_OpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                // 選択されたファイルをテキストボックスに表示する
                foreach (string strFilePath in SelectFile_OpenFileDialog.FileNames)
                {
                    // リストボックスにファイル名を表示
                    SelectFile_ListBox.Items.Add(strFilePath);
                    Toggle_GroupBox();
                }
            }

        }

        private void SelectFile_KeyDown(object sender, KeyEventArgs e)//ファイル選択リストの選択したアイテムをdelete削除
        {
            // Deleteキーが押されたら項目を削除
            if (e.KeyData == Keys.Delete)
            {
                if (this.SelectFile_ListBox.SelectedItems.Count > 0)
                {
                    // 現在選択している行のインデックスを取得
                    int index = this.SelectFile_ListBox.SelectedIndex;

                    if ((0 <= index) && (index < this.SelectFile_ListBox.Items.Count))
                    {
                        // 項目を削除
                        this.SelectFile_ListBox.Items.RemoveAt(index);

                        // 次の選択行を決定
                        if (this.SelectFile_ListBox.Items.Count > 0)
                        {
                            int nextIndex = index - 1;
                            if (this.SelectFile_ListBox.Items.Count > index)
                            {
                                nextIndex = index;
                            }
                            this.SelectFile_ListBox.SelectedIndex = nextIndex;
                        }
                    }
                }
            }
            Toggle_GroupBox();
        }
        private void ExportFolderPath_ListBox_KeyDown(object sender, KeyEventArgs e)//出力フォルダリストの選択したものをDeleteで削除
        {
            // Deleteキーが押されたら項目を削除
            if (e.KeyData == Keys.Delete)
            {
                if (this.ExportFolderPath_ListBox.SelectedItems.Count > 0)
                {
                    // 現在選択している行のインデックスを取得
                    int index = this.ExportFolderPath_ListBox.SelectedIndex;

                    if ((0 <= index) && (index < this.ExportFolderPath_ListBox.Items.Count))
                    {
                        // 項目を削除
                        this.ExportFolderPath_ListBox.Items.RemoveAt(index);

                        // 次の選択行を決定
                        if (this.ExportFolderPath_ListBox.Items.Count > 0)
                        {
                            int nextIndex = index - 1;
                            if (this.ExportFolderPath_ListBox.Items.Count > index)
                            {
                                nextIndex = index;
                            }
                            this.ExportFolderPath_ListBox.SelectedIndex = nextIndex;
                        }
                    }
                }
            }
        }

        private void MoveExportFile_CheckBox_CheckedChanged(object sender, EventArgs e) //MoveExportFlieとNoMoveExportFileをお互いにONOFFする
        {
            if (MoveExportFile_CheckBox.Checked == true)
            {
                NoMoveExportFile_CheckBox.Checked = false;
                MoveExportFile_CheckBox.Checked = true;
                ExportFolderPath_ListBox.Enabled = true;
                MoveExportFile_CheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else
            {
                NoMoveExportFile_CheckBox.Checked = true;
                SelectExportFolderPath_Button.Enabled = true;
                ExportFolderPath_ListBox.Enabled = false;
                MoveExportFile_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        private void NoMoveExportFile_CheckBox_CheckedChanged(object sender, EventArgs e) //MoveExportFlieとNoMoveExportFileをお互いにONOFFする
        {
            if (NoMoveExportFile_CheckBox.Checked == true)
            {
                MoveExportFile_CheckBox.Checked = false;
                SelectExportFolderPath_Button.Enabled = false;
                ExportFolderPath_ListBox.Enabled = false;
                NoMoveExportFile_CheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else
            {
                MoveExportFile_CheckBox.Checked = true;
                SelectExportFolderPath_Button.Enabled = true;
                ExportFolderPath_ListBox.Enabled = true;
                NoMoveExportFile_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        private void SeparateFolderByExtension_CheckBox_CheckedChanged(object sender, EventArgs e) //SeparateFoleder ByExtensionとByPartnameをお互いにONOFFする
        {
            if (SeparateFolderByExtension_CheckBox.Checked == true)
            {
                SeparateFoldersByPartname_CheckBox.Checked = false;
                SeparateFolderByExtension_CheckBox.Checked = true;
                SeparateFolderByExtension_CheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else
            {
                SeparateFoldersByPartname_CheckBox.Checked = true;
                SeparateFolderByExtension_CheckBox.Checked = false;
                SeparateFolderByExtension_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        private void SeparateFoldersByPartname_CheckBox_CheckedChanged(object sender, EventArgs e) //SeparateFoleder ByExtensionとByPartnameをお互いにONOFFする
        {
            if (SeparateFoldersByPartname_CheckBox.Checked == true)
            {
                SeparateFolderByExtension_CheckBox.Checked = false;
                SeparateFoldersByPartname_CheckBox.Checked = true;
                SeparateFoldersByPartname_CheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else
            {
                SeparateFolderByExtension_CheckBox.Checked = true;
                SeparateFoldersByPartname_CheckBox.Checked = false;
                SeparateFoldersByPartname_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        private void MakeZipFileByPartName_CheckBox_CheckedChanged(object sender, EventArgs e) //Zipファイルを生成しない場合にZipファイルオプションを無効にする
        {
            if (MakeZipFileByPartName_CheckBox.Checked == true)
            {
                MakeZipSameExportFolderPath_CheckBox.Enabled = true;
                MakeZipAnotherFolderPath_CheckBox.Enabled = true;
                MakeZipSameExportFolderPath_CheckBox.Checked = true;
                MakeZipFileByPartName_CheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else
            {
                MakeZipAnotherFolderPath_CheckBox.Enabled = false;
                MakeZipAnotherFolderPath_CheckBox.Checked = false;
                MakeZipSameExportFolderPath_CheckBox.Enabled = false;
                ZipFolderPath_ListBox.Enabled = false;
                SelectZipFolderPath_Button.Enabled = false;
                ZipFolderPath_ListBox.Enabled = false;
                MakeZipFileByPartName_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        private void MakeZipSameExportFolderPath_CheckBox_CheckedChanged(object sender, EventArgs e) //Zipファイルを出力フォルダと同じ場所に作るかをお互いにONOFFする
        {
            if (MakeZipSameExportFolderPath_CheckBox.Checked == true)
            {
                MakeZipAnotherFolderPath_CheckBox.Checked = false;
                MakeZipSameExportFolderPath_CheckBox.Checked = true;
                MakeZipSameExportFolderPath_CheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else
            {
                MakeZipSameExportFolderPath_CheckBox.Checked = false;
                MakeZipAnotherFolderPath_CheckBox.Checked = true;
                MakeZipSameExportFolderPath_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        private void MakeZipAnotherFolderPath_CheckBox_CheckedChanged(object sender, EventArgs e) //Zipファイルを出力フォルダと同じ場所に作るかをお互いにONOFFする
        {
            if (MakeZipAnotherFolderPath_CheckBox.Checked == true)
            {
                MakeZipSameExportFolderPath_CheckBox.Checked = false;
                MakeZipAnotherFolderPath_CheckBox.Checked = true;
                ZipFolderPath_ListBox.Enabled = true;
                SelectZipFolderPath_Button.Enabled = true;
                MakeZipAnotherFolderPath_CheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else
            {
                MakeZipAnotherFolderPath_CheckBox.Checked = false;
                MakeZipSameExportFolderPath_CheckBox.Checked = true;
                ZipFolderPath_ListBox.Enabled = false;
                SelectZipFolderPath_Button.Enabled = false;
                MakeZipAnotherFolderPath_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        private void PDF_CheckBox_CheckedChanged(object sender, EventArgs e) //チェックしてないときに文字をグレーアウト
        {
            if (PDF_CheckBox.Checked == true)
            {
                PDF_CheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else
            {
                PDF_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        private void DXF_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DXF_CheckBox.Checked == true)
            {
                DXF_CheckBox.ForeColor = ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else
            {
                DXF_CheckBox.ForeColor = ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        private void STEP_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (STEP_CheckBox.Checked == true)
            {
                STEP_CheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else
            {
                STEP_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        private void IGS_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IGS_CheckBox.Checked == true)
            {
                IGS_CheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else
            {
                IGS_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        private void STL_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (STL_CheckBox.Checked == true)
            {
                STL_CheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else
            {
                STL_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        private void AddPrefix_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AddPrefix_CheckBox.Checked == true)
            {
                AddPrefix_CheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
                Prefix_TextBox.Enabled = true;
            }
            else
            {
                AddPrefix_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
                Prefix_TextBox.Enabled = false;
            }
        }

        private void AddSuffix_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AddSuffix_CheckBox.Checked == true)
            {
                AddSuffix_CheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
                Suffix_TextBox.Enabled = true;
            }
            else
            {
                AddSuffix_CheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
                Suffix_TextBox.Enabled = false;
            }
        }

        private void Toggle_GroupBox() //グループボックスのONOFFを切り替える
        {
            DocumentExportExtension_GroupBox.Enabled = false;
            ModelExportExtension_GroupBox.Enabled = false;

            foreach (string i in SelectFile_ListBox.Items)
            {
                switch (Path.GetExtension(i))
                {
                    case ".SLDDRW":
                        DocumentExportExtension_GroupBox.Enabled = true;
                        break;

                    case ".SLDPRT":
                        ModelExportExtension_GroupBox.Enabled = true;
                        break;
                }
            }
            if (SelectFile_ListBox.Items.Count > 0)
            {
                ExportOption_GroupBox.Enabled = true;
                StartExoport_GroupBox.Enabled = true;
                SelectExportFilePath_GroupBox.Enabled=true;
                Option_GroupBox.Enabled = true;
            }
            else
            {
                ExportOption_GroupBox.Enabled = false;
                StartExoport_GroupBox.Enabled = false;
                SelectExportFilePath_GroupBox.Enabled = false;
                Option_GroupBox.Enabled = false;
            }
        }

        private void ExportFolderPath_ListBox_EnabledChanged(object sender, EventArgs e) //出力フォルダリストボックス Enable==falseの時にグレーアウト
        {
            if (ExportFolderPath_ListBox.Enabled == false)
            {
                ExportFolderPath_ListBox.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                ExportFolderPath_ListBox.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        private void ZipFolderPath_ListBox_EnabledChanged(object sender, EventArgs e)
        {
            if (ZipFolderPath_ListBox.Enabled == false)
            {
                ZipFolderPath_ListBox.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                ZipFolderPath_ListBox.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        private void SelectExportFolderPath_Button_Click(object sender, EventArgs e) //出力フォルダ選択
        {
            if (SelectFile_ListBox.Items.Count > 0)
            {
                ExportFolderPath_ListBox.Items.Clear();
                var cofd = new CommonOpenFileDialog();
                cofd.InitialDirectory = Path.GetDirectoryName((string)SelectFile_ListBox.Items[0]);
                cofd.IsFolderPicker = true;
                if (cofd.ShowDialog() != CommonFileDialogResult.Ok)
                {
                    return;
                }
                ExportFolderPath_ListBox.Items.Add(cofd.FileName);

            }
        }

        private void SelectZipFolderPath_Button_Click(object sender, EventArgs e)
        {
            if (SelectFile_ListBox.Items.Count > 0)
            {
                ZipFolderPath_ListBox.Items.Clear();
                var cofd = new CommonOpenFileDialog();
                cofd.InitialDirectory = Path.GetDirectoryName((string)SelectFile_ListBox.Items[0]);
                cofd.IsFolderPicker = true;
                if (cofd.ShowDialog() != CommonFileDialogResult.Ok)
                {
                    return;
                }
                ZipFolderPath_ListBox.Items.Add(cofd.FileName);

            }
        }

        private void ExportCADFile(ListBox.ObjectCollection OriginalFilePath,string ExportFolderPath,string ZipFolderPath, string[] ExportPath) //拡張子ごとにファイルを出力する ついでにZipファイルにも保存する
        {
            string ExportFilePath;
            StringBuilder LabelText= new StringBuilder();

            for(int i=0; i < OriginalFilePath.Count; i++) 
            {
                string OriginalFile = (string)OriginalFilePath[i];

            string FileExtension = Path.GetExtension(OriginalFile);
                switch (FileExtension)
                {
                    case ".SLDDRW":
                        if (PDF_CheckBox.Checked == true)
                        {
                            //エクスポートして保存
                            LabelText.Append("Export PDF : ");
                            LabelText.Append(Path.GetFileName(OriginalFile));
                            Progress_Label.Text =LabelText.ToString();
                            Task_ProgressBar.Value++;
                            Progress_Label.Update();

                            ExportFilePath = ExportPdf(OriginalFile, ExportPath[1]);

                            //Zipファイルオプションが選択されている場合はZipファイルに保存
                            if (MakeZipFileByPartName_CheckBox.Checked == true)
                            {
                                Progress_Label.Text = "Zipping : " + Path.GetFileName(OriginalFile);
                                Task_ProgressBar.Value++;
                                Progress_Label.Update();
                                using (ZipArchive ZipCADFile = ZipFile.Open(ZipFolderPath + "\\" + Path.GetFileNameWithoutExtension(OriginalFile) + ".zip", ZipArchiveMode.Update))
                                {
                                    ZipCADFile.CreateEntryFromFile(ExportFilePath, Path.GetFileName(ExportFilePath), CompressionLevel.Optimal);
                                }
                            }
                        }
                        if (DXF_CheckBox.Checked == true)
                        {
                            LabelText.Append("Export DXF : ");
                            LabelText.Append(Path.GetFileName(OriginalFile));
                            Progress_Label.Text = LabelText.ToString();
                            Task_ProgressBar.Value++;
                            Progress_Label.Update();

                            ExportFilePath = ExportDxf(OriginalFile, ExportPath[2]);

                            //Zipファイルオプションが選択されている場合はZipファイルに保存
                            if (MakeZipFileByPartName_CheckBox.Checked == true)
                            {
                                Progress_Label.Text = "Zipping: " + Path.GetFileName(OriginalFile);
                                Task_ProgressBar.Value++;
                                Progress_Label.Update();
                                using (ZipArchive ZipCADFile = ZipFile.Open(ZipFolderPath + "\\" + Path.GetFileNameWithoutExtension(OriginalFile) + ".zip", ZipArchiveMode.Update))
                                {
                                    ZipCADFile.CreateEntryFromFile(ExportFilePath, Path.GetFileName(ExportFilePath), CompressionLevel.Optimal);
                                }
                            }
                        }
                        break;
                    case ".SLDPRT":
                        if (IGS_CheckBox.Checked == true)
                        {
                            LabelText.Append("Export IGS : ");
                            LabelText.Append(Path.GetFileName(OriginalFile));
                            Progress_Label.Text = LabelText.ToString();
                            Task_ProgressBar.Value++;
                            Progress_Label.Update();

                            ExportFilePath = ExportIges(OriginalFile, ExportPath[3]);

                            //Zipファイルオプションが選択されている場合はZipファイルに保存
                            if (MakeZipFileByPartName_CheckBox.Checked == true)
                            {
                                Progress_Label.Text = "Zipping: " + Path.GetFileName(OriginalFile);
                                Task_ProgressBar.Value++;
                                Progress_Label.Update();
                                using (ZipArchive ZipCADFile = ZipFile.Open(ZipFolderPath + "\\" + Path.GetFileNameWithoutExtension(OriginalFile) + ".zip", ZipArchiveMode.Update))
                                {
                                    ZipCADFile.CreateEntryFromFile(ExportFilePath, Path.GetFileName(ExportFilePath), CompressionLevel.Optimal);
                                }
                            }
                        }
                        if (STEP_CheckBox.Checked == true)
                        {
                            LabelText.Append("Export STEP : ");
                            LabelText.Append(Path.GetFileName(OriginalFile));
                            Progress_Label.Text = LabelText.ToString();
                            Task_ProgressBar.Value++;
                            Progress_Label.Update();
                            ExportFilePath = ExportStep(OriginalFile, ExportPath[4]);

                            //Zipファイルオプションが選択されている場合はZipファイルに保存
                            if (MakeZipFileByPartName_CheckBox.Checked == true)
                            {
                                Progress_Label.Text = "Zipping: " + Path.GetFileName(OriginalFile);
                                Task_ProgressBar.Value++;
                                Progress_Label.Update();
                                using (ZipArchive ZipCADFile = ZipFile.Open(ZipFolderPath + "\\" + Path.GetFileNameWithoutExtension(OriginalFile) + ".zip", ZipArchiveMode.Update))
                                {
                                    ZipCADFile.CreateEntryFromFile(ExportFilePath, Path.GetFileName(ExportFilePath), CompressionLevel.Optimal);
                                }
                            }
                        }
                        if (STL_CheckBox.Checked == true)
                        {
                            Progress_Label.Text = "Export STL : " + Path.GetFileName(OriginalFile);
                            Task_ProgressBar.Value++;
                            Progress_Label.Update();
                            ExportFilePath = ExportStl(OriginalFile, ExportPath[5]);

                            //Zipファイルオプションが選択されている場合はZipファイルに保存
                            if (MakeZipFileByPartName_CheckBox.Checked == true)
                            {
                                Progress_Label.Text = "Zipping: " + Path.GetFileName(OriginalFile);
                                Task_ProgressBar.Value++;
                                Progress_Label.Update();
                                using (ZipArchive ZipCADFile = ZipFile.Open(ZipFolderPath + "\\" + Path.GetFileNameWithoutExtension(OriginalFile) + ".zip", ZipArchiveMode.Update))
                                {
                                    ZipCADFile.CreateEntryFromFile(ExportFilePath, Path.GetFileName(ExportFilePath), CompressionLevel.Optimal);
                                }
                            }

                        }
                        break;
                }
            }
        }

        private void MakeExportExtensionFolder(String ExportFilePath) //オプションで選択した拡張子ごとのフォルダを作成する
        {
            if (PDF_CheckBox.Checked == true)
            {
                Directory.CreateDirectory(ExportFilePath + "\\" + "pdf");
            }
            if(DXF_CheckBox.Checked==true)
            {
                Directory.CreateDirectory(ExportFilePath + "\\" + "dxf");
            }
            if (IGS_CheckBox.Checked == true)
            {
                Directory.CreateDirectory(ExportFilePath + "\\" + "igs");
            }
            if (STEP_CheckBox.Checked == true)
            {
                Directory.CreateDirectory(ExportFilePath + "\\" + "step");
            }
            if (STL_CheckBox.Checked == true)
            {
                Directory.CreateDirectory(ExportFilePath + "\\" + "stl");
            }
        }

        public string ExportDxf(string OriginalFilePath, string ExportFolderPath)
        {
            try
            {
                ModelDoc2 SolidworksDocument;
                ModelDocExtension SolidworksModelExtension = default(ModelDocExtension);
                int FileErro = 0;
                int FileWarning = 0;
                bool bRet;
                string ExportFilePath;
                ExportFilePath = ExportFolderPath + "\\" + (string)Path.GetFileName(Path.ChangeExtension(OriginalFilePath, ".DXF"));

                SolidworksDocument = (ModelDoc2)SolidworksApp.OpenDoc6(
                    OriginalFilePath,
                    (int)swDocumentTypes_e.swDocDRAWING,
                    (int)swOpenDocOptions_e.swOpenDocOptions_Silent,
                    "",
                    ref FileErro,
                    ref FileWarning
                    );

                SolidworksModelExtension = (ModelDocExtension)SolidworksDocument.Extension;

                bRet = SolidworksModelExtension.SaveAs3(
                    ExportFilePath,
                    (int)swSaveAsVersion_e.swSaveAsCurrentVersion,
                    (int)swSaveAsOptions_e.swSaveAsOptions_Silent,
                    null,
                    null,
                    ref FileErro,
                    ref FileWarning
                    );

                SolidworksApp.CloseDoc(OriginalFilePath);
                return ExportFilePath;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return e.ToString();
            }
        }
        
        public string ExportPdf(string OriginalFilePath, string ExportFolderPath)
        {
            try
            {
                ModelDoc2 SolidworksDocument;
                ModelDocExtension SolidworksModelExtension = default(ModelDocExtension);
                int FileErro = 0;
                int FileWarning = 0;
                bool bRet;
                string ExportFilePath;
                ExportFilePath = ExportFolderPath + "\\" + (string)Path.GetFileName(Path.ChangeExtension(OriginalFilePath, ".pdf"));

                SolidworksDocument = (ModelDoc2)SolidworksApp.OpenDoc6(
                    OriginalFilePath,
                    (int)swDocumentTypes_e.swDocDRAWING,
                    (int)swOpenDocOptions_e.swOpenDocOptions_Silent,
                    "",
                    ref FileErro,
                    ref FileWarning
                    );

                SolidworksModelExtension = (ModelDocExtension)SolidworksDocument.Extension;

                bRet = SolidworksModelExtension.SaveAs3(
                    ExportFilePath,
                    (int)swSaveAsVersion_e.swSaveAsCurrentVersion,
                    (int)swSaveAsOptions_e.swSaveAsOptions_Silent,
                    null,
                    null,
                    ref FileErro,
                    ref FileWarning
                    );

                SolidworksApp.CloseDoc(OriginalFilePath);
                return ExportFilePath;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return e.ToString();
            }
        }
        
        public string ExportStep(string OriginalFilePath, string ExportFolderPath)
        {
            try
            {

                PartDoc SolidworksDocumen = default(PartDoc);
                ModelDoc2 SolidworksModel;
                ModelDocExtension SolidworksModelExtension = default(ModelDocExtension);
                int FileError = 0;
                int FileWarning = 0;
                bool bRet = false;
                string ExportFilePath;
                ExportFilePath = ExportFolderPath + "\\" + (string)Path.GetFileName(Path.ChangeExtension(OriginalFilePath, ".STEP"));

                SolidworksDocumen = (PartDoc)SolidworksApp.OpenDoc6(
                    OriginalFilePath,
                    (int)swDocumentTypes_e.swDocPART,
                    (int)swOpenDocOptions_e.swOpenDocOptions_Silent,
                    "",
                    ref FileError,
                    ref FileWarning
                    );

                SolidworksModel = (ModelDoc2)SolidworksDocumen;
                SolidworksModelExtension = (ModelDocExtension)SolidworksModel.Extension;

                bRet = SolidworksModelExtension.SaveAs3(
                    ExportFilePath,
                    (int)swSaveAsVersion_e.swSaveAsCurrentVersion,
                    (int)swSaveAsOptions_e.swSaveAsOptions_Silent,
                    null,
                    null,
                    ref FileError,
                    ref FileWarning
                    );
                SolidworksApp.CloseDoc(OriginalFilePath);
                return ExportFilePath;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return e.ToString();
            }

        }
        
        public string ExportIges(string OriginalFilePath, string ExportFolderPath)
        {
            try
            {

                PartDoc SolidworksDocumen = default(PartDoc);
                ModelDoc2 SolidworksModel;
                ModelDocExtension SolidworksModelExtension = default(ModelDocExtension);
                int FileError = 0;
                int FileWarning = 0;
                bool bRet = false;
                string ExportFilePath;
                ExportFilePath = ExportFolderPath + "\\" + (string)Path.GetFileName(Path.ChangeExtension(OriginalFilePath, ".IGS"));

                SolidworksDocumen = (PartDoc)SolidworksApp.OpenDoc6(
                    OriginalFilePath,
                    (int)swDocumentTypes_e.swDocPART,
                    (int)swOpenDocOptions_e.swOpenDocOptions_Silent,
                    "",
                    ref FileError,
                    ref FileWarning
                    );

                SolidworksModel = (ModelDoc2)SolidworksDocumen;
                SolidworksModelExtension = (ModelDocExtension)SolidworksModel.Extension;

                bRet = SolidworksModelExtension.SaveAs3(
                    ExportFilePath,
                    (int)swSaveAsVersion_e.swSaveAsCurrentVersion,
                    (int)swSaveAsOptions_e.swSaveAsOptions_Silent,
                    null,
                    null,
                    ref FileError,
                    ref FileWarning
                    );
                SolidworksApp.CloseDoc(OriginalFilePath);
                return ExportFilePath;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return e.ToString();
            }
        }
        
        public string ExportStl(string OriginalFilePath, string ExportFolderPath)
        {
            try
            {
                PartDoc SolidworksDocumen = default(PartDoc);
                ModelDoc2 SolidworksModel;
                ModelDocExtension SolidworksModelExtension = default(ModelDocExtension);
                int FileError = 0;
                int FileWarning = 0;
                bool bRet = false;
                string ExportFilePath;
                ExportFilePath = ExportFolderPath + "\\" + (string)Path.GetFileName(Path.ChangeExtension(OriginalFilePath, ".STL"));

                SolidworksDocumen = (PartDoc)SolidworksApp.OpenDoc6(
                    OriginalFilePath,
                    (int)swDocumentTypes_e.swDocPART,
                    (int)swOpenDocOptions_e.swOpenDocOptions_Silent,
                    "",
                    ref FileError,
                    ref FileWarning
                    );

                SolidworksModel = (ModelDoc2)SolidworksDocumen;
                SolidworksModelExtension = (ModelDocExtension)SolidworksModel.Extension;

                bRet = SolidworksModelExtension.SaveAs3(
                    ExportFilePath,
                    (int)swSaveAsVersion_e.swSaveAsCurrentVersion,
                    (int)swSaveAsOptions_e.swSaveAsOptions_Silent,
                    null,
                    null,
                    ref FileError,
                    ref FileWarning
                    );
                SolidworksApp.CloseDoc(OriginalFilePath);
                return ExportFilePath;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return e.ToString();
            }
        }


        private void StartExport_Button_Click(object sender, EventArgs e)//変換開始処理
        {
            if (MoveExportFile_CheckBox.Checked == true && ExportFolderPath_ListBox.Items.Count <= 0)
            {
                MessageBox.Show("出力フォルダを指定してください");
            }
            else if (MakeZipAnotherFolderPath_CheckBox.Checked == true && ZipFolderPath_ListBox.Items.Count <= 0)
            {
                MessageBox.Show("Zipファイル保存フォルダを指定してください");
            }
            else
            {
                GetUserLog();
                string ZipFolderPath;
                string ExportFolderPath;

                Task_ProgressBar.Minimum = 0;
                Task_ProgressBar.Maximum = CountTask();
                Task_ProgressBar.Value = 0;

                AllGroupBoxONOFF(false);

                List<string> AllFilePath = new List<string>();
                //同じフォルダに保存オプション
                if (NoMoveExportFile_CheckBox.Checked == true)
                {
                    ExportFolderPath = Path.GetDirectoryName((string)SelectFile_ListBox.Items[0]);
                }
                else
                {
                    ExportFolderPath = (string)ExportFolderPath_ListBox.Items[0];
                }

                //拡張子ごとにファイルを分けるONの場合はファイルを作る
                if (SeparateFolderByExtension_CheckBox.Checked == true)
                {
                    MakeExportExtensionFolder(ExportFolderPath);
                }

                if (SeparateFoldersByPartname_CheckBox.Checked == true)
                {

                }


                //Zipファイルを同じフォルダに保存オプション
                if (MakeZipFileByPartName_CheckBox.Checked == true)
                {
                    if (MakeZipAnotherFolderPath_CheckBox.Checked == true)
                    {
                        ZipFolderPath = (string)ZipFolderPath_ListBox.Items[0];
                    }
                    else
                    {
                        ZipFolderPath = ExportFolderPath;
                    }
                }
                else
                {
                    ZipFolderPath = null;
                }
                string[] ExportExtentionPath = new string[6];
                ExportExtentionPath[0] = ExportFolderPath;
                //オプションで拡張子ごとのファイルに分ける場合は直下の拡張子ごとのフォルダに保存する
                if (SeparateFolderByExtension_CheckBox.Checked == true)
                {
                    if (PDF_CheckBox.Checked == true) ExportExtentionPath[1] = ExportFolderPath + "\\" + "pdf";
                    if (DXF_CheckBox.Checked == true) ExportExtentionPath[2] = ExportFolderPath + "\\" + "dxf";
                    if (IGS_CheckBox.Checked == true) ExportExtentionPath[3] = ExportFolderPath + "\\" + "igs";
                    if (STEP_CheckBox.Checked == true) ExportExtentionPath[4] = ExportFolderPath + "\\" + "step";
                    if (STL_CheckBox.Checked == true) ExportExtentionPath[5] = ExportFolderPath + "\\" + "stl";
                }
                else
                {
                    for (int i = 0; i < ExportExtentionPath.Length; i++) ExportExtentionPath[i] = ExportFolderPath;
                }

                ExportCADFile(SelectFile_ListBox.Items, ExportFolderPath, ZipFolderPath,ExportExtentionPath);

                Task_ProgressBar.Value = 0;
                Progress_Label.Text = "処理待ち";
                this.Update();
                AllGroupBoxONOFF(true);
                EndToast();
            }
        }

        private int CountTask() //プログレスバー用タスクカウンター
        {
            int TaskCount = 0;
            int ModelCount = 0;
            int DrawCount = 0;
            int ModelOption = 0;
            int DrawOption = 0;
            int ZipOption = 1;

            for(int i=0;i<SelectFile_ListBox.Items.Count;i++)
            {
                if (Path.GetExtension((string)SelectFile_ListBox.Items[i]) == ".SLDDRW")
                {
                    DrawCount++;
                }
                else if(Path.GetExtension((string)SelectFile_ListBox.Items[i]) == ".SLDPRT")
                {
                    ModelCount++;
                }
            }
            if (DXF_CheckBox.Checked == true) DrawOption++;
            if(PDF_CheckBox.Checked==true) DrawOption++;
            if(IGS_CheckBox.Checked==true) ModelOption++;
            if (STEP_CheckBox.Checked == true) ModelOption++;
            if (STL_CheckBox.Checked == true) ModelOption++;
            if (MakeZipFileByPartName_CheckBox.Checked == true) ZipOption = 2;

            TaskCount=(DrawCount*DrawOption+ModelCount*ModelOption)*ZipOption;

            return TaskCount;
        }

        private void Task_ProgressBar_Click(object sender, EventArgs e)
        {

        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AllGroupBoxONOFF(bool ONOFF)//全てのグローブボックスのONOFF
        {
            SelectExportFilePath_GroupBox.Enabled = ONOFF;
            FileSelect_GroupBox.Enabled = ONOFF;
            DocumentExportExtension_GroupBox.Enabled = ONOFF;
            ModelExportExtension_GroupBox.Enabled=ONOFF;
            ExportOption_GroupBox.Enabled=ONOFF;
            StartExoport_GroupBox.Enabled=ONOFF;
            Option_GroupBox.Enabled=ONOFF;
        }

        private void OptionReset() //オプションの選択をデフォルト状態にリセット
        {
            ExportFolderPath_ListBox.Items.Clear();
            ZipFolderPath_ListBox.Items.Clear();

            PDF_CheckBox.Checked = false;
            DXF_CheckBox.Checked = false;
            STEP_CheckBox.Checked = false;
            IGS_CheckBox.Checked = false;
            STL_CheckBox.Checked = false;
            NoMoveExportFile_CheckBox.Checked = true;
            MakeZipFileByPartName_CheckBox.Checked = false;
            AddPrefix_CheckBox.Checked = false;
            AddSuffix_CheckBox.Checked = false;
        }

        private void FileSelectRest_Button_Click(object sender, EventArgs e) //ファイル選択をリセット
        {
            SelectFile_ListBox.Items.Clear();
            Toggle_GroupBox();
        }

        private void GetUserLog()//使用したユーザー名と時刻をCSVファイルに保存
        {
            DataTable dataTable= new DataTable();
            dataTable.Columns.Add(System.Environment.UserName);
            dataTable.Columns.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            //CSV出力用変数の作成
            List<string> lines = new List<string>();

            //列名をカンマ区切りで1行に連結
            List<string> header = new List<string>();
            foreach (DataColumn dr in dataTable.Columns)
            {
                header.Add(dr.ColumnName);
            }
            lines.Add(string.Join(",", header));

            //列の値をカンマ区切りで1行に連結
            foreach (DataRow dr in dataTable.Rows)
            {
                lines.Add(string.Join(",", dr.ItemArray));
            }

            using (StreamWriter sw = new StreamWriter(@"log.csv", true,
                                          Encoding.GetEncoding("shift-jis")))
            {
                foreach (string line in lines)
                {
                    sw.WriteLine(line);
                }
            }
        }

        private void EndToast() //作業終了時にトースト通知を発行
        {
            new ToastContentBuilder()
                .AddText("CADデータ出力ツール")
                .AddText("作業が終了しました")
                .Show();
        }

        private void OptionRest_Button_Click(object sender, EventArgs e)
        {
            OptionReset();
        }

        private void Suffix_TextBox_TextChanged(object sender, EventArgs e)
        {
            string DefaultExampleFileName = "XXX";
            string DefaultExampleFileName2 = ".SDDRW";
            FileName_Label.Text = Prefix_TextBox.Text + DefaultExampleFileName + Suffix_TextBox.Text+DefaultExampleFileName2;
            FileName_Label.Update();
        }

        private void Prefix_TextBox_TextChanged(object sender, EventArgs e)
        {
            string DefaultExampleFileName = "XXX";
            string DefaultExampleFileName2 = ".SDDRW";
            FileName_Label.Text = Prefix_TextBox.Text+ DefaultExampleFileName + Suffix_TextBox.Text + DefaultExampleFileName2;
            FileName_Label.Update();
        }
    }
}