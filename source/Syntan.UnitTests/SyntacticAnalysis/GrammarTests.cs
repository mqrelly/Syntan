using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Syntan.SyntacticAnalysis;

namespace Syntan.UnitTests.SyntacticAnalysis
{
    public class GrammarTests
    {
        [Fact]
        public void CreateWithNullTerminals()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => new Grammar(
                    null,
                    Fixtures.EmptyGrammar.BaseGrammar.Grammaticals,
                    Fixtures.EmptyGrammar.BaseGrammar.Rules)
            );

            Assert.Equal("terminals", ex.ParamName);
        }

        [Fact]
        public void CreateWithNullGrammaticals()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => new Grammar(
                    Fixtures.EmptyGrammar.BaseGrammar.Terminals,
                    null,
                    Fixtures.EmptyGrammar.BaseGrammar.Rules)
            );

            Assert.Equal("grammaticals", ex.ParamName);
        }

        [Fact]
        public void CreateWithNullRules()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => new Grammar(
                    Fixtures.EmptyGrammar.BaseGrammar.Terminals,
                    Fixtures.EmptyGrammar.BaseGrammar.Grammaticals,
                    null)
            );

            Assert.Equal("rules", ex.ParamName);
        }

        [Fact]
        public void CreateWithEndOfSourceInTerminals()
        {
            Assert.Throws<InvalidEndOfSourceSymbolException>(
                () => new Grammar(
                    new TerminalSymbol[] { new EndOfSourceSymbol() },
                    Fixtures.EmptyGrammar.BaseGrammar.Grammaticals,
                    Fixtures.EmptyGrammar.BaseGrammar.Rules)
            );
        }

        [Fact]
        public void CreateWithNoGrammaticals()
        {
            Assert.Throws<MissingStartSymbolException>(
                () => new Grammar(
                    Fixtures.EmptyGrammar.BaseGrammar.Terminals,
                    new GrammaticalSymbol[0],
                    Fixtures.EmptyGrammar.BaseGrammar.Rules)
            );
        }

        [Fact]
        public void CreateWithNoRules()
        {
            Assert.Throws<MissingStartRuleException>(
                () => new Grammar(
                    Fixtures.EmptyGrammar.BaseGrammar.Terminals,
                    Fixtures.EmptyGrammar.BaseGrammar.Grammaticals,
                    new Rule[0])
            );
        }

        [Fact]
        public void CreateWithForeignGrammaticalInRuleLhs()
        {
            var foreign_symbol = new GrammaticalSymbol("TestGrammatical");
            var bad_rule = new Rule(
                foreign_symbol,
                new Symbol[] { Fixtures.EmptyGrammar.BaseGrammar.Grammaticals[0] });

            var ex = Assert.Throws<ForeignSymbolInRuleException>(
                () => new Grammar(
                    Fixtures.EmptyGrammar.BaseGrammar.Terminals,
                    Fixtures.EmptyGrammar.BaseGrammar.Grammaticals,
                    new Rule[]
                    {
                        Fixtures.EmptyGrammar.BaseGrammar.Rules[0],
                        bad_rule,
                    })
            );

            Assert.Equal(bad_rule, ex.Rule);
            Assert.Equal(foreign_symbol, ex.Symbol);
        }

        [Fact]
        public void CreateWithForeignGrammaticalInRuleRhs()
        {
            var foreign_symbol = new GrammaticalSymbol("TestGrammatical");
            var bad_rule = new Rule(
                Fixtures.EmptyGrammar.BaseGrammar.Grammaticals[0],
                new Symbol[] { foreign_symbol });

            var ex = Assert.Throws<ForeignSymbolInRuleException>(
                () => new Grammar(
                    Fixtures.EmptyGrammar.BaseGrammar.Terminals,
                    Fixtures.EmptyGrammar.BaseGrammar.Grammaticals,
                    new Rule[]
                    {
                        Fixtures.EmptyGrammar.BaseGrammar.Rules[0],
                        bad_rule,
                    })
            );

            Assert.Equal(bad_rule, ex.Rule);
            Assert.Equal(foreign_symbol, ex.Symbol);
        }

        [Fact]
        public void CreateWithForeignTerminalInRule()
        {
            var foreign_symbol = new TerminalSymbol("TestTerminal");
            var bad_rule = new Rule(
                Fixtures.EmptyGrammar.BaseGrammar.Grammaticals[0],
                new Symbol[] { foreign_symbol });

            var ex = Assert.Throws<ForeignSymbolInRuleException>(
                () => new Grammar(
                    Fixtures.EmptyGrammar.BaseGrammar.Terminals,
                    Fixtures.EmptyGrammar.BaseGrammar.Grammaticals,
                    new Rule[]
                    {
                        Fixtures.EmptyGrammar.BaseGrammar.Rules[0],
                        bad_rule,
                    })
            );

            Assert.Equal(bad_rule, ex.Rule);
            Assert.Equal(foreign_symbol, ex.Symbol);
        }

        //TODO: CreateWithValidData()
    }
}
