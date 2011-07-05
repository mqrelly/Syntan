using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Syntan.SyntacticAnalysis;
using Xunit.Extensions;

namespace Syntan.UnitTests.SyntacticAnalysis
{
    public class ExtendedGrammarTests
    {
        [Fact]
        public void CreateWithNullBaseGrammar()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => new ExtendedGrammar(null)
            );

            Assert.Equal("grammar", ex.ParamName);
        }

        [Theory]
        [PropertyData("CreateWithValidGrammarFixtures")]
        public void CreateWithValidGrammar( RestrictedStartSymbolGrammar restricted_grammar )
        {
            var eg = new ExtendedGrammar(restricted_grammar);

            Assert.NotNull(eg);
            Assert.Equal(restricted_grammar, eg.RestrictedGrammar);
            Assert.Equal(restricted_grammar.Terminals.Count + 1, eg.Terminals.Count);
            Assert.NotNull(eg.EndOfSourceSymbol);
            Assert.Equal(eg.EndOfSourceSymbol, eg.Terminals[eg.Terminals.Count - 1]);
            Assert.Equal(restricted_grammar.StartRule.RightHandSide.Count + 1, eg.StartRule.RightHandSide.Count);
            Assert.Equal(eg.EndOfSourceSymbol, eg.StartRule.RightHandSide[eg.StartRule.RightHandSide.Count - 1]);
        }

        public static IEnumerable<object[]> CreateWithValidGrammarFixtures
        {
            get
            {
                yield return new object[] { Fixtures.EmptyGrammar.RestrictedGrammar };
                yield return new object[] { Fixtures.Grammar1.RestrictedGrammar };
                yield return new object[] { Fixtures.Grammar2.RestrictedGrammar };
                yield return new object[] { Fixtures.Grammar3.RestrictedGrammar };
            }
        }
    }
}
