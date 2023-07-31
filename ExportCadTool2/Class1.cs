using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Security.Cryptography.Certificates;

namespace ExportCadTool2
{
    public class CADExportOpotion2
    {
        public ListBox filePath { get; set; }//元ファイルパス
        public CheckBox moveExportFolderOption { get; set; }
        public ListBox exportFolderPath 
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
        }//出力フォルダパス
        public List<string> exportFilePath { get; set; }//個別ファイル出力パス
        public string zipFolderPath { get; set; }
        public string pdfFolderPath { get; set; }
        public string dxfFolderPath { get; set; }
        public string igsFloderPaht { get; set; }
        public string stepFolderPath { get; set; }
        public string stlFolderPath { get; set; }
        public CheckBox makeExtetionFolderOption { get; set; }
        public CheckBox makeZipFileByPartName { get; set; }
        public CheckBox separateFolderByExtension { get; set; }
        public CheckBox separateFolderByItemName { get; set; }
        public CheckBox pdfOption { get; set; }
        public CheckBox dxfOption { get; set; }
        public CheckBox igsOption { get; set; }
        public CheckBox stepOption { get; set; }
        public CheckBox stlOption { get; set; }
    }
}
