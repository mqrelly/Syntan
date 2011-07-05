using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Syntan.Demo
{
    class ColorScheme
    {
        public Color NewState { get; set; }

        public Color CurrentState { get; set; }

        public Color CurrentInputSymbol { get; set; }

        public Color RuleLhsToReducate { get; set; }
    }
}
