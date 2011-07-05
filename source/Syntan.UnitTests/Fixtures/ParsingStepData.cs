using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.UnitTests.Fixtures
{
    public class ParsingStepData
    {
        public Syntan.SyntacticAnalysis.LR.ParsingPhase Phase;

        public bool IsParsing;

        public bool IsFinished;

        public int StepCount;

        public int CurrentState;

        public Syntan.SyntacticAnalysis.TerminalSymbol CurrentInputSymbol;

        public int ActionArgument;

        public bool AreReductionPropertiesSet;

        public int GotoState;

        public Syntan.SyntacticAnalysis.GrammaticalSymbol GotoSymbol;

        public Syntan.SyntacticAnalysis.Rule ReductionRule;
    }
}
