using System;
using System.Collections.Generic;
using System.IO;
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
        public ListBox filePath { get; set; }//出力前のデーターファイルリスト
        public CheckBox moveExportFolderOption { get; set; }//別のフォルダに出力するオプション
        public ListBox exportFolderPath { get; set; } //出力するフォルダのパス
        public List<string> exportFilePath { get; set; } //個別ファイル出力パス
        public string zipFolderPath { get; set; }
        public string pdfFolderPath { get; set; }
        public string dxfFolderPath { get; set; }
        public string igsFloderPath { get; set; }
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
