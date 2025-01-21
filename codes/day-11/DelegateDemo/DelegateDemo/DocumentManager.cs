using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    internal class DocumentManager
    {
        public bool EditDocument(string filePath)
        {
            return true;
        }
        public static bool CreateDocument(string filePath)
        {
            return true;
        }
    }
}
