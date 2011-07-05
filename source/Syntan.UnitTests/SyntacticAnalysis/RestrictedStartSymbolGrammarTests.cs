using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Syntan.SyntacticAnalysis;

namespace Syntan.UnitTests.SyntacticAnalysis
{
    public class RestrictedStartSymbolGrammarTests
    {
        [Fact]
        public void CreateWithNullBaseGrammar()
        {
            Assert.Throws<ArgumentNullException>(
                () => new RestrictedStartSymbolGrammar(null)
            );
        }

        [Fact]
        public void CreateWithEmptyBaseGrammar()
        {
            var gr = new RestrictedStartSymbolGrammar(Grammar.EmptyGrammar);

            Assert.NotNull(gr.StartSymbol);
            Assert.NotNull(gr.StartRule);
            Assert.Equal(1, gr.Grammaticals.Count);
            Assert.Equal(1, gr.Rules.Count);
            Assert.True(gr.StartRule.IsEpsilonRule);
        }

        [Fact]
        public void CreateWithStartSymbolOnTheRightSide()
        {
            var terminals = new TerminalSymbol[]
            {
                new TerminalSymbol("a"),
            };

            var grammaticals = new GrammaticalSymbol[]
            {
                new GrammaticalSymbol("S'"),
            };

            var rules = new Rule[]
            {
                new Rule(grammaticals[0], new Symbol[]{ terminals[0], grammaticals[0] }),
            };


            var gr = new RestrictedStartSymbolGrammar(new Grammar(terminals, grammaticals, rules));

            Assert.Equal(2, gr.Grammaticals.Count);
            Assert.Equal(2, gr.Rules.Count);
            Assert.Equal(1, gr.Rules.Count(r => r.LeftHandSide == gr.StartSymbol));
            Assert.True(gr.Rules.FirstOrDefault(r => r.RightHandSide.IndexOf(gr.StartSymbol) != -1) == null);
            Assert.Equal("S''", gr.StartSymbol.Name);
        }

        [Fact]
        public void CreateWithMultipleStartRules()
        {
            var terminals = new TerminalSymbol[]
            {
                new TerminalSymbol("a"),
                new TerminalSymbol("b"),
            };

            var grammaticals = new GrammaticalSymbol[]
            {
                new GrammaticalSymbol("S"),
            };

            var rules = new Rule[]
            {
                new Rule(grammaticals[0], new Symbol[]{ terminals[0] }),
                new Rule(grammaticals[0], new Symbol[]{ terminals[1] }),
            };


            var gr = new RestrictedStartSymbolGrammar(new Grammar(terminals, grammaticals, rules));

            Assert.Equal(2, gr.Grammaticals.Count);
            Assert.Equal(3, gr.Rules.Count);
            Assert.Equal(1, gr.Rules.Count(r => r.LeftHandSide == gr.StartSymbol));
            Assert.True(gr.Rules.FirstOrDefault(r => r.RightHandSide.IndexOf(gr.StartSymbol) != -1) == null);
        }

        [Fact]
        public void CreateWithStartRuleNotTheFirst()
        {
            var terminals = new TerminalSymbol[]
            {
                new TerminalSymbol("a"),
                new TerminalSymbol("b"),
            };

            var grammaticals = new GrammaticalSymbol[]
            {
                new GrammaticalSymbol("S"),
                new GrammaticalSymbol("A"),
            };

            var rules = new Rule[]
            {
                new Rule(grammaticals[1], new Symbol[]{ terminals[0] }),
                new Rule(grammaticals[0], new Symbol[]{ terminals[1] }),
            };


            var gr = new RestrictedStartSymbolGrammar(new Grammar(terminals, grammaticals, rules));

            Assert.Equal(2, gr.Grammaticals.Count);
            Assert.Equal(2, gr.Rules.Count);
            Assert.Equal(rules[1], gr.StartRule);
        }

        [Fact]
        public void CreateWithNoStartRules()
        {
            var terminals = new TerminalSymbol[]
            {
                new TerminalSymbol("a"),
                new TerminalSymbol("b"),
            };

            var grammaticals = new GrammaticalSymbol[]
            {
                new GrammaticalSymbol("S"),
                new GrammaticalSymbol("A"),
            };

            var rules = new Rule[]
            {
                new Rule(grammaticals[1], new Symbol[]{ terminals[0] }),
                new Rule(grammaticals[1], new Symbol[]{ terminals[1] }),
            };


            var gr = new RestrictedStartSymbolGrammar(new Grammar(terminals, grammaticals, rules));

            Assert.Equal(2, gr.Grammaticals.Count);
            Assert.Equal(3, gr.Rules.Count);
            Assert.Equal(gr.StartSymbol, gr.StartRule.LeftHandSide);
            Assert.True(gr.StartRule.IsEpsilonRule);
        }
    }
}
