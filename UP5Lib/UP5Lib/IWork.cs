using System;
using System.Collections.Generic;
using System.Text;

namespace UP5Lib
{
    public interface IWork
    {
        string PatchLoad { get; set; }
        string PatchSave { get; set; }
        void PrintMassage(string text);
    }
}
