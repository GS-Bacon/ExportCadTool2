using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Shell;
using Windows.Security.Cryptography.Certificates;

namespace ExportCadTool2
{
    public class CADExportOpotion
    {
        public ListBox filePath { get; set; }//元ファイルパス
        public CheckBox moveExportFolderOption { get; set; } = new CheckBox();
        public ListBox exportFolderPath //出力フォルダパス
        {
            set
            {
                exportFolderPath = value;
            }
            get
            {
                if (moveExportFolderOption.Checked == true)
                {
                    return filePath;
                }
                return exportFolderPath;
            }
        }
        public Dictionary<string, Dictionary<string, string>> exportFilePath //個別ファイル出力パス
        {
            set
            {
                exportFilePath = new Dictionary<string, Dictionary<string, string>>();
            }
            get
            {
                string FileName;
                for (int i = 0; i > filePath.Items.Count; i++)
                {
                    FileName = Path.GetFileNameWithoutExtension((string)filePath.Items[i]);
                    var ExtentionFolder = new Dictionary<string, string>();
                    ExtentionFolder.Add("pdf", pdfFolderPath + "\\" + FileName + ".pdf");
                    ExtentionFolder.Add("dxf", dxfFolderPath + "\\" + FileName + ".dxf");
                    ExtentionFolder.Add("igs", igsFloderPaht + "\\" + FileName + ".igs");
                    ExtentionFolder.Add("step", stepFolderPath + "\\" + FileName + ".step");
                    ExtentionFolder.Add("stl", stlFolderPath + "\\" + FileName + ".stl");
                    ExtentionFolder.Add("zip", zipFolderPath + "\\" + FileName + ".zip");

                    exportFilePath.Add((string)filePath.Items[0], ExtentionFolder);
                }
                return exportFilePath;
            }
        }
        public ListBox zipFolderPath
        {
            set { }
            get
            {
                if (makeZipFileByPartName.Checked == true)
                {
                    if (MakeZipSameExportFolderPath.Checked == true)
                    {
                        return exportFolderPath;
                    }
                    else
                    {
                        return zipFolderPath;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
        public string pdfFolderPath
        {
            set { }
            get
            {
                if (makeExtetionFolderOption.Checked == true)
                {
                    return (string)exportFolderPath.Items[0] + "\\" + "pdf";
                }
                else
                {
                    return (string)exportFolderPath.Items[0];
                }
            }
        }
        public string dxfFolderPath
        {
            set { }
            get
            {
                if (makeExtetionFolderOption.Checked == true)
                {
                    return (string)exportFolderPath.Items[0] + "\\" + "dxf";
                }
                else
                {
                    return (string)exportFolderPath.Items[0];
                }
            }
        }
        public string igsFloderPaht
        {
            set { }
            get
            {
                if (makeExtetionFolderOption.Checked == true)
                {
                    return (string)exportFolderPath.Items[0] + "\\" + "igs";
                }
                else
                {
                    return (string)exportFolderPath.Items[0];
                }
            }
        }
        public string stepFolderPath
        {
            set { }
            get
            {
                if (makeExtetionFolderOption.Checked == true)
                {
                    return (string)exportFolderPath.Items[0] + "\\" + "step";
                }
                else
                {
                    return (string)exportFolderPath.Items[0];
                }
            }
        }
        public string stlFolderPath
        {
            set { }
            get
            {
                if (makeExtetionFolderOption.Checked == true)
                {
                    return (string)exportFolderPath.Items[0] + "\\" + "stl";
                }
                else
                {
                    return (string)exportFolderPath.Items[0];
                }
            }
        }
        public CheckBox makeExtetionFolderOption { get; set; }
        public CheckBox makeZipFileByPartName { get; set; }
        public CheckBox MakeZipSameExportFolderPath { get; set; }
        public CheckBox separateFolderByExtension { get; set; }
        public CheckBox separateFolderByItemName { get; set; }
        public CheckBox pdfOption { get; set; }
        public CheckBox dxfOption { get; set; }
        public CheckBox igsOption { get; set; }
        public CheckBox stepOption { get; set; }
        public CheckBox stlOption { get; set; }
    }
}
