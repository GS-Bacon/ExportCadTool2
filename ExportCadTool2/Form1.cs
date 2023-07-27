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

        ExportOpotion2 exportOpotion2 = new ExportOpotion2();

        private void ExportCADFile(ListBox.ObjectCollection OriginalFilePath, string ExportFolderPath, string ZipFolderPath, string[] ExportPath) //拡張子ごとにファイルを出力する ついでにZipファイルにも保存する
        {
            string ExportFilePath;
            StringBuilder LabelText = new StringBuilder();

            for (int i = 0; i < OriginalFilePath.Count; i++)
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
                            Progress_Label.Text = LabelText.ToString();
                            Task_ProgressBar.Value++;
                            Progress_Label.Update();
                            LabelText.Clear();

                            Task.Run(() =>
                            {
                                ExportFilePath = ExportPdf(OriginalFile, ExportPath[1]);

                                //Zipファイルオプションが選択されている場合はZipファイルに保存
                                if (MakeZipFileByPartName_CheckBox.Checked == true)
                                {
                                    Progress_Label.Text = "Zipping : " + Path.GetFileName(OriginalFile);
                                    Task_ProgressBar.Value++;
                                    Progress_Label.Update();
                                    LabelText.Clear();
                                    using (ZipArchive ZipCADFile = ZipFile.Open(ZipFolderPath + "\\" + Path.GetFileNameWithoutExtension(OriginalFile) + ".zip", ZipArchiveMode.Update))
                                    {
                                        ZipCADFile.CreateEntryFromFile(ExportFilePath, Path.GetFileName(ExportFilePath), CompressionLevel.Optimal);
                                    }
                                }
                            });
                        }
                        if (DXF_CheckBox.Checked == true)
                        {
                            Task.Run(() =>
                            {
                                LabelText.Append("Export DXF : ");
                                LabelText.Append(Path.GetFileName(OriginalFile));
                                Progress_Label.Text = LabelText.ToString();
                                Task_ProgressBar.Value++;
                                Progress_Label.Update();
                                LabelText.Clear();

                                ExportFilePath = ExportDxf(OriginalFile, ExportPath[2]);

                                //Zipファイルオプションが選択されている場合はZipファイルに保存
                                if (MakeZipFileByPartName_CheckBox.Checked == true)
                                {
                                    Progress_Label.Text = "Zipping: " + Path.GetFileName(OriginalFile);
                                    Task_ProgressBar.Value++;
                                    Progress_Label.Update();
                                    LabelText.Clear();
                                    using (ZipArchive ZipCADFile = ZipFile.Open(ZipFolderPath + "\\" + Path.GetFileNameWithoutExtension(OriginalFile) + ".zip", ZipArchiveMode.Update))
                                    {
                                        ZipCADFile.CreateEntryFromFile(ExportFilePath, Path.GetFileName(ExportFilePath), CompressionLevel.Optimal);
                                    }
                                }
                            });
                        }
                        break;
                    case ".SLDPRT":
                        if (IGS_CheckBox.Checked == true)
                        {
                            Task.Run(() =>
                            {
                                LabelText.Append("Export IGS : ");
                                LabelText.Append(Path.GetFileName(OriginalFile));
                                Progress_Label.Text = LabelText.ToString();
                                Task_ProgressBar.Value++;
                                Progress_Label.Update();
                                LabelText.Clear();

                                ExportFilePath = ExportIges(OriginalFile, ExportPath[3]);

                                //Zipファイルオプションが選択されている場合はZipファイルに保存
                                if (MakeZipFileByPartName_CheckBox.Checked == true)
                                {
                                    Progress_Label.Text = "Zipping: " + Path.GetFileName(OriginalFile);
                                    Task_ProgressBar.Value++;
                                    Progress_Label.Update();
                                    LabelText.Clear();
                                    using (ZipArchive ZipCADFile = ZipFile.Open(ZipFolderPath + "\\" + Path.GetFileNameWithoutExtension(OriginalFile) + ".zip", ZipArchiveMode.Update))
                                    {
                                        ZipCADFile.CreateEntryFromFile(ExportFilePath, Path.GetFileName(ExportFilePath), CompressionLevel.Optimal);
                                    }
                                }
                            });
                        }
                        if (STEP_CheckBox.Checked == true)
                        {
                            Task.Run(() =>
                            {
                                LabelText.Append("Export STEP : ");
                                LabelText.Append(Path.GetFileName(OriginalFile));
                                Progress_Label.Text = LabelText.ToString();
                                Task_ProgressBar.Value++;
                                Progress_Label.Update();
                                LabelText.Clear();
                                ExportFilePath = ExportStep(OriginalFile, ExportPath[4]);

                                //Zipファイルオプションが選択されている場合はZipファイルに保存
                                if (MakeZipFileByPartName_CheckBox.Checked == true)
                                {
                                    Progress_Label.Text = "Zipping: " + Path.GetFileName(OriginalFile);
                                    Task_ProgressBar.Value++;
                                    Progress_Label.Update();
                                    LabelText.Clear();
                                    using (ZipArchive ZipCADFile = ZipFile.Open(ZipFolderPath + "\\" + Path.GetFileNameWithoutExtension(OriginalFile) + ".zip", ZipArchiveMode.Update))
                                    {
                                        ZipCADFile.CreateEntryFromFile(ExportFilePath, Path.GetFileName(ExportFilePath), CompressionLevel.Optimal);
                                    }
                                }
                            });
                        }
                        if (STL_CheckBox.Checked == true)
                        {
                            Task.Run(() =>
                            {
                                Progress_Label.Text = "Export STL : " + Path.GetFileName(OriginalFile);
                                Task_ProgressBar.Value++;
                                Progress_Label.Update();
                                LabelText.Clear();
                                ExportFilePath = ExportStl(OriginalFile, ExportPath[5]);

                                //Zipファイルオプションが選択されている場合はZipファイルに保存
                                if (MakeZipFileByPartName_CheckBox.Checked == true)
                                {
                                    Progress_Label.Text = "Zipping: " + Path.GetFileName(OriginalFile);
                                    Task_ProgressBar.Value++;
                                    Progress_Label.Update();
                                    LabelText.Clear();
                                    using (ZipArchive ZipCADFile = ZipFile.Open(ZipFolderPath + "\\" + Path.GetFileNameWithoutExtension(OriginalFile) + ".zip", ZipArchiveMode.Update))
                                    {
                                        ZipCADFile.CreateEntryFromFile(ExportFilePath, Path.GetFileName(ExportFilePath), CompressionLevel.Optimal);
                                    }
                                }
                            });

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
            if (DXF_CheckBox.Checked == true)
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

                ExportCADFile(SelectFile_ListBox.Items, ExportFolderPath, ZipFolderPath, ExportExtentionPath);

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

            for (int i = 0; i < SelectFile_ListBox.Items.Count; i++)
            {
                if (Path.GetExtension((string)SelectFile_ListBox.Items[i]) == ".SLDDRW")
                {
                    DrawCount++;
                }
                else if (Path.GetExtension((string)SelectFile_ListBox.Items[i]) == ".SLDPRT")
                {
                    ModelCount++;
                }
            }
            if (DXF_CheckBox.Checked == true) DrawOption++;
            if (PDF_CheckBox.Checked == true) DrawOption++;
            if (IGS_CheckBox.Checked == true) ModelOption++;
            if (STEP_CheckBox.Checked == true) ModelOption++;
            if (STL_CheckBox.Checked == true) ModelOption++;
            if (MakeZipFileByPartName_CheckBox.Checked == true) ZipOption = 2;

            TaskCount = (DrawCount * DrawOption + ModelCount * ModelOption) * ZipOption;

            return TaskCount;
        }

        private void GetUserLog()//使用したユーザー名と時刻をCSVファイルに保存
        {
            DataTable dataTable = new DataTable();
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

        private void Suffix_TextBox_TextChanged(object sender, EventArgs e)// サフィックス追加
        {
            string DefaultExampleFileName = "XXX";
            string DefaultExampleFileName2 = ".SDDRW";
            FileName_Label.Text = Prefix_TextBox.Text + DefaultExampleFileName + Suffix_TextBox.Text + DefaultExampleFileName2;
            FileName_Label.Update();
        }

        private void Prefix_TextBox_TextChanged(object sender, EventArgs e)// プレフィックス追加
        {
            string DefaultExampleFileName = "XXX";
            string DefaultExampleFileName2 = ".SDDRW";
            FileName_Label.Text = Prefix_TextBox.Text + DefaultExampleFileName + Suffix_TextBox.Text + DefaultExampleFileName2;
            FileName_Label.Update();
        }

        private void OptionSetting()
        {
            exportOpotion2.filePath = SelectFile_ListBox.Items;
        }
    }
}