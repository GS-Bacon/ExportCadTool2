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
                SelectExportFilePath_GroupBox.Enabled = true;
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
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AllGroupBoxONOFF(bool ONOFF)//全てのグローブボックスのONOFF
        {
            SelectExportFilePath_GroupBox.Enabled = ONOFF;
            FileSelect_GroupBox.Enabled = ONOFF;
            DocumentExportExtension_GroupBox.Enabled = ONOFF;
            ModelExportExtension_GroupBox.Enabled = ONOFF;
            ExportOption_GroupBox.Enabled = ONOFF;
            StartExoport_GroupBox.Enabled = ONOFF;
            Option_GroupBox.Enabled = ONOFF;
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

    }
}