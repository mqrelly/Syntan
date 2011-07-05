using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Syntan.SyntacticAnalysis.LR;
using Xunit.Extensions;

namespace Syntan.UnitTests.SyntacticAnalysis.LR
{
    public class ParserTableTests
    {
        [Fact]
        public void CreateWithInvalidStateCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new ParserTable(0, 1, 1)
            );
        }

        [Fact]
        public void CreateWithInvalidTerminalCounts()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new ParserTable(1, 0, 1)
            );
        }

        [Fact]
        public void CreateWithInvalidGrammaticalCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new ParserTable(1, 1, 0)
            );
        }

        [Fact]
        public void CreateWithValidDimensions()
        {
            var t = new ParserTable(1, 2, 3);

            Assert.NotNull(t);
            Assert.Equal(1, t.StateCount);
            Assert.Equal(2, t.TerminalCount);
            Assert.Equal(3, t.GrammaticalCount);
        }

        [Fact]
        public void NotSetActionDefaultsToError()
        {
            var t = new ParserTable(1, 1, 1);
            var a = t.GetAction(0, 0);
            Assert.Equal(ParserTable.ActionType.Error, a.Type);
            Assert.Equal(0, a.Argument);
        }

        [Fact]
        public void NotSetGotoDefaultsToError()
        {
            var t = new ParserTable(1, 1, 1);
            Assert.Equal(-1, t.GetGoto(0, 0));
        }

        public static IEnumerable<object[]> SetGetActionFixtures
        {
            get
            {
                yield return new object[] { 3, 3, 3, 0, 0, ParserTable.Action.Accept() };
                yield return new object[] { 3, 3, 3, 1, 0, ParserTable.Action.Error() };
                yield return new object[] { 3, 3, 3, 0, 2, ParserTable.Action.Step(5) };
                yield return new object[] { 3, 3, 3, 2, 1, ParserTable.Action.Reduction(71) };
            }
        }

        [Theory]
        [PropertyData("SetGetActionFixtures")]
        public void SetGetAction( int state_count, int terminal_count, int grammatical_count,
            int state_index, int terminal_index, ParserTable.Action action )
        {
            var t = new ParserTable(state_count, terminal_count, grammatical_count);
            t.SetAction(state_index, terminal_index, action);
            Assert.Equal(action, t.GetAction(state_index, terminal_index));
        }

        public static IEnumerable<object[]> SetGetGotoFixtures
        {
            get
            {
                yield return new object[] { 3, 3, 3, 0, 0, 0 };
                yield return new object[] { 3, 3, 3, 1, 0, 7 };
                yield return new object[] { 3, 3, 3, 2, 1, 13 };
                yield return new object[] { 3, 3, 3, 0, 2, -1 };
            }
        }

        [Theory]
        [PropertyData("SetGetGotoFixtures")]
        public void SetGetGoto( int state_count, int terminal_count, int grammatical_count,
            int state_index, int grammatical_index, int goto_arg )
        {
            var t = new ParserTable(state_count, terminal_count, grammatical_count);
            t.SetGoto(state_index, grammatical_index, goto_arg);
            Assert.Equal(goto_arg, t.GetGoto(state_index, grammatical_index));
        }
    }
}
