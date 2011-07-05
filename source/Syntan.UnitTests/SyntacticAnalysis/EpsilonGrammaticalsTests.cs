using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Syntan.SyntacticAnalysis;
using Xunit.Extensions;

namespace Syntan.UnitTests.SyntacticAnalysis
{
    public class EpsilonGrammaticalsTests
    {
        public static IEnumerable<object[]> ValidFixtures
        {
            get
            {
                yield return new object[] { Fixtures.EmptyGrammar.RestrictedGrammar, Fixtures.EmptyGrammar.EpsilonGrammaticals };
                yield return new object[] { Fixtures.Grammar1.RestrictedGrammar, Fixtures.Grammar1.EpsilonGrammaticals };
                yield return new object[] { Fixtures.Grammar2.RestrictedGrammar, Fixtures.Grammar2.EpsilonGrammaticals };
                yield return new object[] { Fixtures.Grammar3.RestrictedGrammar, Fixtures.Grammar3.EpsilonGrammaticals };
            }
        }

        [Fact]
        public void BuildWithNullGrammar()
        {
            Assert.Throws<ArgumentNullException>(
                () => EpsilonGrammaticals.Build(null)
            );
        }

        [Theory]
        [PropertyData("ValidFixtures")]
        public void BuildWithValidGrammer( RestrictedStartSymbolGrammar grammar, ISet<GrammaticalSymbol> expected_result )
        {
            var actual_result = EpsilonGrammaticals.Build(grammar);
            Assert.True(actual_result.SetEquals(expected_result));
        }
    }
}
