using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Syntan.SyntacticAnalysis;
using Xunit.Extensions;

namespace Syntan.UnitTests.SyntacticAnalysis
{
    public class FirstSetsTests
    {
        public static IEnumerable<object[]> ValidFixtures
        {
            get
            {
                yield return new object[] 
                { 
                    Fixtures.EmptyGrammar.ExtendedGrammar, 
                    Fixtures.EmptyGrammar.EpsilonGrammaticals, 
                    Fixtures.EmptyGrammar.FirstSets 
                };
                yield return new object[] 
                { 
                    Fixtures.Grammar1.ExtendedGrammar, 
                    Fixtures.Grammar1.EpsilonGrammaticals, 
                    Fixtures.Grammar1.FirstSets 
                };
                yield return new object[]
                {
                    Fixtures.Grammar2.ExtendedGrammar, 
                    Fixtures.Grammar2.EpsilonGrammaticals, 
                    Fixtures.Grammar2.FirstSets 
                };
            }
        }

        [Fact]
        public void BuildWithNullGrammar()
        {
            Assert.Throws<ArgumentNullException>(
                () => FirstSets.Build(null, new HashSet<GrammaticalSymbol>())
            );
        }

        [Fact]
        public void BuildWithNullEpsilonGrammaticals()
        {
            Assert.Throws<ArgumentNullException>(
                () => FirstSets.Build(Fixtures.Grammar1.ExtendedGrammar, null)
            );
        }

        [Theory]
        [PropertyData("ValidFixtures")]
        public void BuildWithValidData( ExtendedGrammar grammar,
            ISet<GrammaticalSymbol> epsilon_grammaticals,
            IDictionary<GrammaticalSymbol, ISet<TerminalSymbol>> first_sets )
        {
            var fs = FirstSets.Build(grammar, epsilon_grammaticals);

            foreach( var gr in grammar.Grammaticals )
                Assert.True(fs[gr].SetEquals(first_sets[gr]));
        }
    }
}
