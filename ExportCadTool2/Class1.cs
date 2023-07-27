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
    public class ExportOpotion2
    {
        public ListBox.ObjectCollection filePath { get; set; }
        public string exportFolderPath { get; set; }
        public string zipFolderPath { get; set; }
        public string pdfFolderPath { get; set; }
        public string dxfFolderPath { get; set; }
        public string igsFloderPaht { get; set; }
        public string stepFolderPath { get; set; }
        public string stlFolderPath { get; set; }
        public bool moveExportFolderOption { get; set; }
        public bool makeExtetionFolderOption { get; set; }
        public bool pdfOption { get; set; }
        public bool dxfOption { get; set; }
        public bool igsOption { get; set; }
        public bool stepOption { get; set; }
        public bool stlOption { get; set; }
    }
}
