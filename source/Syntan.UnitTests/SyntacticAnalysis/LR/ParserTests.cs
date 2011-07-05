using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Syntan.SyntacticAnalysis.LR;
using Xunit.Extensions;
using Syntan.SyntacticAnalysis;

namespace Syntan.UnitTests.SyntacticAnalysis.LR
{
    public class ParserTests
    {
        [Fact]
        public void CreateNeedsNothing()
        {
            var p = new Parser();

            Assert.Equal(ParsingPhase.NotParsing, p.Phase);
        }

        [Fact]
        public void StartWithNullGrammar()
        {
            var p = new Parser();

            var ex = Assert.Throws<ArgumentNullException>(
                () => p.Start(
                    null,
                    Fixtures.EmptyGrammar.SLR1ParserTable,
                    new Syntan.SyntacticAnalysis.TerminalSymbol[0])
            );

            Assert.Equal("grammar", ex.ParamName);
        }

        [Fact]
        public void StartWithNullParserTable()
        {
            var p = new Parser();

            var ex = Assert.Throws<ArgumentNullException>(
                () => p.Start(
                    Fixtures.EmptyGrammar.ExtendedGrammar,
                    null,
                    new Syntan.SyntacticAnalysis.TerminalSymbol[0])
            );

            Assert.Equal("table", ex.ParamName);
        }

        [Fact]
        public void StartWithNullInput()
        {
            var p = new Parser();

            var ex = Assert.Throws<ArgumentNullException>(
                () => p.Start(
                    Fixtures.EmptyGrammar.ExtendedGrammar,
                    Fixtures.EmptyGrammar.SLR1ParserTable,
                    null)
            );

            Assert.Equal("input", ex.ParamName);
        }

        [Fact]
        public void StartWithEmptyInput()
        {
            var p = new Parser();

            Assert.Throws<UnexpectedEndOfSourceException>(
                () => p.Start(
                    Fixtures.EmptyGrammar.ExtendedGrammar,
                    Fixtures.EmptyGrammar.SLR1ParserTable,
                    new Syntan.SyntacticAnalysis.TerminalSymbol[0])
            );
        }

        [Fact]
        public void StartWithValidEmptyGrammar()
        {
            var p = new Parser();

            p.Start(
                Fixtures.EmptyGrammar.ExtendedGrammar,
                Fixtures.EmptyGrammar.SLR1ParserTable,
                new Syntan.SyntacticAnalysis.TerminalSymbol[] { Fixtures.EmptyGrammar.ExtendedGrammar.EndOfSourceSymbol });

            Assert.Equal(ParsingPhase.Accept, p.Phase);
        }

        [Fact]
        public void StartWhenParsing()
        {
            var p = new Parser();

            p.Start(
                Fixtures.EmptyGrammar.ExtendedGrammar,
                Fixtures.EmptyGrammar.SLR1ParserTable,
                new Syntan.SyntacticAnalysis.TerminalSymbol[] { Fixtures.EmptyGrammar.ExtendedGrammar.EndOfSourceSymbol });

            Assert.Throws<InvalidOperationException>(
                () => p.Start(
                    Fixtures.EmptyGrammar.ExtendedGrammar,
                    Fixtures.EmptyGrammar.SLR1ParserTable,
                    new Syntan.SyntacticAnalysis.TerminalSymbol[] { Fixtures.EmptyGrammar.ExtendedGrammar.EndOfSourceSymbol })
            );
        }

        [Fact]
        public void StepWhenNotParsing()
        {
            var p = new Parser();

            Assert.Throws<InvalidOperationException>(
                () => p.StepPhase()
            );
        }

        [Fact]
        public void SetpAfterAccept()
        {
            var p = new Parser();
            p.Start(
                Fixtures.EmptyGrammar.ExtendedGrammar,
                Fixtures.EmptyGrammar.SLR1ParserTable,
                new Syntan.SyntacticAnalysis.TerminalSymbol[] { Fixtures.EmptyGrammar.ExtendedGrammar.EndOfSourceSymbol });

            Assert.Throws<InvalidOperationException>(
                () => p.StepPhase()
            );
        }

        [Fact]
        public void StepAfterError()
        {
            var p = new Parser();
            p.Start(
                Fixtures.Grammar2.ExtendedGrammar,
                Fixtures.Grammar2.SLR1ParserTable,
                new TerminalSymbol[] { Fixtures.Grammar2.ExtendedGrammar.EndOfSourceSymbol });

            Assert.Throws<InvalidOperationException>(
                () => p.StepPhase()
            );
        }

        [Fact]
        public void StopWhenNotParsing()
        {
            var p = new Parser();
            p.Stop();

            Assert.True(!p.IsParsing);
            Assert.Equal(Syntan.SyntacticAnalysis.LR.ParsingPhase.NotParsing, p.Phase);
        }

        [Fact]
        public void StopAfterAccept()
        {
            var p = new Parser();
            p.Start(
                Fixtures.EmptyGrammar.ExtendedGrammar,
                Fixtures.EmptyGrammar.SLR1ParserTable,
                new Syntan.SyntacticAnalysis.TerminalSymbol[] { Fixtures.EmptyGrammar.ExtendedGrammar.EndOfSourceSymbol });

            p.Stop();
            Assert.Equal(ParsingPhase.NotParsing, p.Phase);
            Assert.True(!p.IsParsing);
        }


        [Fact]
        public void StopAfterError()
        {
            var p = new Parser();
            p.Start(
                   Fixtures.Grammar2.ExtendedGrammar,
                   Fixtures.Grammar2.SLR1ParserTable,
                   new TerminalSymbol[] { Fixtures.Grammar2.ExtendedGrammar.EndOfSourceSymbol });

            p.Stop();
            Assert.Equal(ParsingPhase.NotParsing, p.Phase);
            Assert.True(!p.IsParsing);
        }


        [Theory(Skip="Missing fixtures.")]
        public void ParsingSteps(
            Syntan.SyntacticAnalysis.ExtendedGrammar grammar,
            Syntan.SyntacticAnalysis.LR.ParserTable table,
            IEnumerable<Syntan.SyntacticAnalysis.TerminalSymbol> input,
            IEnumerable<Fixtures.ParsingStepData> expected_parsing_steps )
        {
            var p = new Parser();

            p.Start(grammar, table, input);

            foreach( var step in expected_parsing_steps )
            {
                Assert.Equal(step.Phase, p.Phase);
                Assert.Equal(step.IsParsing, p.IsParsing);
                Assert.Equal(step.IsFinished, p.IsFinished);
                Assert.Equal(step.StepCount, p.StepCount);
                Assert.Equal(step.CurrentState, p.CurrentState);
                Assert.Equal(step.CurrentInputSymbol, p.CurrentInputSymbol);
                Assert.Equal(step.ActionArgument, p.ActionArgument);
                if( step.AreReductionPropertiesSet )
                {
                    Assert.Equal(step.GotoState, p.GotoState);
                    Assert.Equal(step.GotoSymbol, p.GotoSymbol);
                    Assert.Equal(step.ReductionRule, p.ReductionRule);
                }

                p.StepPhase();
            }
        }
    }
}
