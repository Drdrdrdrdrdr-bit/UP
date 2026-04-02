using System;
using System.Collections.Generic;
using System.Text;

namespace UP5Lib
{
    public interface IWork
    {
        string PatchLoad{ get; }
        string PatchSave{ get; }
        void PrintMassage(string text);
    }
}
