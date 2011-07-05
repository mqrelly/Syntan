using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Syntan.SyntacticAnalysis;
using Xunit.Extensions;

namespace Syntan.UnitTests.SyntacticAnalysis
{
    public class FollowSetsTests
    {
        public static IEnumerable<object[]> ValidFixtures
        {
            get
            {
                yield return new object[] 
                { 
                    Fixtures.EmptyGrammar.ExtendedGrammar, 
                    Fixtures.EmptyGrammar.EpsilonGrammaticals,
                    Fixtures.EmptyGrammar.FollowSets
                };

                yield return new object[] 
                { 
                    Fixtures.Grammar2.ExtendedGrammar, 
                    Fixtures.Grammar2.EpsilonGrammaticals,
                    Fixtures.Grammar2.FollowSets
                };

                yield return new object[] 
                { 
                    Fixtures.Grammar1.ExtendedGrammar, 
                    Fixtures.Grammar1.EpsilonGrammaticals,
                    Fixtures.Grammar1.FollowSets
                };

                yield return new object[] 
                { 
                    Fixtures.Grammar3.ExtendedGrammar, 
                    Fixtures.Grammar3.EpsilonGrammaticals,
                    Fixtures.Grammar3.FollowSets
                };
            }
        }

        [Fact]
        public void BuildWithNullGrammar()
        {
            Assert.Throws<ArgumentNullException>(
                () => FollowSets.Build(null, Fixtures.EmptyGrammar.EpsilonGrammaticals)
            );
        }

        [Fact]
        public void BuildWithNullEpsilonGrammaticals()
        {
            Assert.Throws<ArgumentNullException>(
                () => FollowSets.Build(Fixtures.Grammar1.ExtendedGrammar, null)
            );
        }

        [Theory]
        [PropertyData("ValidFixtures")]
        public void BuildWithValidData( ExtendedGrammar grammar, 
            ISet<GrammaticalSymbol> epsilon_grammaticals, 
            IDictionary<GrammaticalSymbol, ISet<TerminalSymbol>> follow_sets )
        {
            var fs = FollowSets.Build(grammar, epsilon_grammaticals);

            foreach( var gr in grammar.Grammaticals )
                Assert.True(fs[gr].SetEquals(follow_sets[gr]));
        }
    }
}
