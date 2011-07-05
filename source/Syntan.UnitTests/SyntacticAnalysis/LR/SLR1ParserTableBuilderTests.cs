using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Syntan.SyntacticAnalysis.LR;

namespace Syntan.UnitTests.SyntacticAnalysis.LR
{
    public class SLR1ParserTableBuilderTests
    {
        //TODO: test for
        // - non SLR1 grammar specific exceptions
        // - valid input => expected output

        [Fact]
        public void BuildWithNullGrammar()
        {
            Assert.Throws<ArgumentNullException>(
                () => SLR1ParserTableBuilder.Build(
                    null,
                    Fixtures.EmptyGrammar.LR0CanonicalSets,
                    Fixtures.EmptyGrammar.FollowSets)
            );
        }

        [Fact]
        public void BuildWithNullCanonicalSets()
        {
            Assert.Throws<ArgumentNullException>(
                () => SLR1ParserTableBuilder.Build(
                    Fixtures.EmptyGrammar.ExtendedGrammar,
                    null,
                    Fixtures.EmptyGrammar.FollowSets)
            );
        }

        [Fact]
        public void BuildWithNullFollowSets()
        {
            Assert.Throws<ArgumentNullException>(
                () => SLR1ParserTableBuilder.Build(
                    Fixtures.EmptyGrammar.ExtendedGrammar,
                    Fixtures.EmptyGrammar.LR0CanonicalSets,
                    null)
            );
        }

        [Fact]
        public void BuildWithEmptyGrammar()
        {
            var table = SLR1ParserTableBuilder.Build(
                Fixtures.EmptyGrammar.ExtendedGrammar,
                Fixtures.EmptyGrammar.LR0CanonicalSets,
                Fixtures.EmptyGrammar.FollowSets);

            Assert.NotNull(table);
            Assert.Equal(1, table.StateCount);
            Assert.Equal(ParserTable.ActionType.Accept,
                table.GetAction(0, Fixtures.EmptyGrammar.ExtendedGrammar.Terminals.IndexOf(
                    Fixtures.EmptyGrammar.ExtendedGrammar.EndOfSourceSymbol)).Type);
        }
    }
}
