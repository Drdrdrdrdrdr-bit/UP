using System;
using System.Collections.Generic;
using System.Text;

namespace UP3
{
    public interface ISettings
    {
        int speed { get; set; }
        Color colorStart { get; set; }
        Color colorEnd { get; set; }
        void SetSpeed (int speed);
    }
}
