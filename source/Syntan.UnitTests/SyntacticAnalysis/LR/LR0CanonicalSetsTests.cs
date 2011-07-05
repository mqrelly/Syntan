using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Extensions;
using Syntan.SyntacticAnalysis.LR;
using Syntan.SyntacticAnalysis;

namespace Syntan.UnitTests.SyntacticAnalysis.LR
{
    public class LR0CanonicalSetsTests
    {
        [Fact]
        public void NullSetsAreEqual()
        {
            Assert.True(LR0CanonicalSets.AreEqual(null, null));
        }

        [Fact]
        public void NullAndNotNullSetsAreNotEqual()
        {
            Assert.True(!LR0CanonicalSets.AreEqual(null, new HashSet<LR0Item>()));
        }

        [Fact]
        public void DifferentSizedSetsAreNotEqual()
        {
            Assert.True(!LR0CanonicalSets.AreEqual(
                new HashSet<LR0Item>(),
                Fixtures.EmptyGrammar.LR0CanonicalSets.Sets[0]));
        }

        public static IEnumerable<object[]> CanonicalSetEqualityFixtures
        {
            get
            {
                yield return new object[] { new HashSet<LR0Item>(), new HashSet<LR0Item>(), true };

                yield return new object[] { 
                    new HashSet<LR0Item>(new LR0Item[] {
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[0], 0)
                    }),
                    new HashSet<LR0Item>(new LR0Item[] {
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[0], 0)
                    }),
                    true,
                };

                yield return new object[] { 
                    new HashSet<LR0Item>(new LR0Item[] {
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[0], 0),
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[0], 1),
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[0], 2),
                    }),
                    new HashSet<LR0Item>(new LR0Item[] {
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[0], 0),
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[0], 1),
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[0], 2),
                    }),
                    true,
                };

                yield return new object[] { 
                    new HashSet<LR0Item>(new LR0Item[] {
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[0], 0),
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[0], 1),
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[0], 2),
                    }),
                    new HashSet<LR0Item>(new LR0Item[] {
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[0], 2),
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[0], 1),
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[0], 0),
                    }),
                    true,
                };

                yield return new object[] { 
                    new HashSet<LR0Item>(new LR0Item[] {
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[0], 0),
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[1], 1),
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[2], 2),
                    }),
                    new HashSet<LR0Item>(new LR0Item[] {
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[0], 0),
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[1], 1),
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[2], 2),
                    }),
                    true,
                };

                yield return new object[] { 
                    new HashSet<LR0Item>(new LR0Item[] {
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[0], 0),
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[1], 1),
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[2], 2),
                    }),
                    new HashSet<LR0Item>(new LR0Item[] {
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[0], 0),
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[2], 2),
                    }),
                    false,
                };

                yield return new object[] { 
                    new HashSet<LR0Item>(new LR0Item[] {
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[0], 0),
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[2], 2),
                    }),
                    new HashSet<LR0Item>(new LR0Item[] {
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[0], 0),
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[1], 1),
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[2], 2),
                    }),
                    false,
                };

                yield return new object[] { 
                    new HashSet<LR0Item>(new LR0Item[] {
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[0], 0),
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[2], 2),
                    }),
                    new HashSet<LR0Item>(new LR0Item[] {
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[0], 0),
                        new LR0Item(Fixtures.Grammar2.ExtendedGrammar.Rules[1], 1),
                    }),
                    false,
                };
            }
        }

        [Theory]
        [PropertyData("CanonicalSetEqualityFixtures")]
        public void CanonicalSetsEquality( ISet<LR0Item> one, ISet<LR0Item> other, bool expected )
        {
            Assert.Equal(expected, LR0CanonicalSets.AreEqual(one, other));
        }

        [Fact]
        public void ClosureWithNullSet()
        {
            Assert.Throws<ArgumentNullException>(
                () => LR0CanonicalSets.Closure(null, Fixtures.EmptyGrammar.RestrictedGrammar)
            );
        }

        [Fact]
        public void ClosureWithNullGrammar()
        {
            Assert.Throws<ArgumentNullException>(
                () => LR0CanonicalSets.Closure(new HashSet<LR0Item>(), null)
            );
        }

        [Fact]
        public void ClosureWithEmptySet()
        {
            var actual = LR0CanonicalSets.Closure(new HashSet<LR0Item>(), Fixtures.EmptyGrammar.RestrictedGrammar);
            Assert.NotNull(actual);
            Assert.True(LR0CanonicalSets.AreEqual(actual, new HashSet<LR0Item>()));
        }

        public static IEnumerable<object[]> ValidClosureFixtures
        {
            get
            {
                // [S->.aS]
                yield return new object[]
                {
                    new HashSet<LR0Item>(new LR0Item[]
                        {
                            new LR0Item(Fixtures.Grammar1.RestrictedGrammar.Rules[1], 0),
                        }),
                    Fixtures.Grammar1.RestrictedGrammar,
                    new HashSet<LR0Item>(new LR0Item[]
                        {
                            new LR0Item(Fixtures.Grammar1.RestrictedGrammar.Rules[1], 0),
                        }),
                };

                // [S->a.S] => [S->a.S],[S->.aS],[S->.]
                yield return new object[]
                {
                    new HashSet<LR0Item>(new LR0Item[]
                        {
                            new LR0Item(Fixtures.Grammar1.RestrictedGrammar.Rules[1], 1),
                        }),
                    Fixtures.Grammar1.RestrictedGrammar,
                    new HashSet<LR0Item>(new LR0Item[]
                        {
                            new LR0Item(Fixtures.Grammar1.RestrictedGrammar.Rules[1], 0),
                            new LR0Item(Fixtures.Grammar1.RestrictedGrammar.Rules[1], 1),
                            new LR0Item(Fixtures.Grammar1.RestrictedGrammar.Rules[2], 0),
                        }),
                };

                // [S->aS.]
                yield return new object[]
                {
                    new HashSet<LR0Item>(new LR0Item[]
                        {
                            new LR0Item(Fixtures.Grammar1.RestrictedGrammar.Rules[1], 2),
                        }),
                    Fixtures.Grammar1.RestrictedGrammar,
                    new HashSet<LR0Item>(new LR0Item[]
                        {
                            new LR0Item(Fixtures.Grammar1.RestrictedGrammar.Rules[1], 2),
                        }),
                };

                // [S->.E] => [S->.E],[E->.TE'],[T->.FT'],[F->.i],[F->.(E)]
                yield return new object[]
                {
                    new HashSet<LR0Item>(new LR0Item[]
                        {
                            new LR0Item(Fixtures.Grammar2.RestrictedGrammar.Rules[0], 0),
                        }),
                    Fixtures.Grammar2.RestrictedGrammar,
                    new HashSet<LR0Item>(new LR0Item[]
                        {
                            new LR0Item(Fixtures.Grammar2.RestrictedGrammar.Rules[0], 0),
                            new LR0Item(Fixtures.Grammar2.RestrictedGrammar.Rules[1], 0),
                            new LR0Item(Fixtures.Grammar2.RestrictedGrammar.Rules[4], 0),
                            new LR0Item(Fixtures.Grammar2.RestrictedGrammar.Rules[7], 0),
                            new LR0Item(Fixtures.Grammar2.RestrictedGrammar.Rules[8], 0),
                        }),
                };
            }
        }

        [Theory]
        [PropertyData("ValidClosureFixtures")]
        public void ClosureWithValidData( ISet<LR0Item> set, RestrictedStartSymbolGrammar grammar, ISet<LR0Item> expected )
        {
            var actual = LR0CanonicalSets.Closure(set, grammar);
            Assert.NotNull(actual);
            Assert.True(LR0CanonicalSets.AreEqual(actual, expected));
        }

        [Fact]
        public void ReadWithNullSet()
        {
            Assert.Throws<ArgumentNullException>(
                () => LR0CanonicalSets.Read(null, new EndOfSourceSymbol(), Fixtures.EmptyGrammar.RestrictedGrammar)
            );
        }

        [Fact]
        public void ReadWithNullSymbol()
        {
            Assert.Throws<ArgumentNullException>(
                () => LR0CanonicalSets.Read(new HashSet<LR0Item>(), null, Fixtures.EmptyGrammar.RestrictedGrammar)
            );
        }

        [Fact]
        public void ReadWithNullGrammar()
        {
            Assert.Throws<ArgumentNullException>(
                () => LR0CanonicalSets.Read(new HashSet<LR0Item>(), new EndOfSourceSymbol(), null)
            );
        }

        public static IEnumerable<object[]> ValidReadFixtures
        {
            get
            {
                // Read([S->.aS], a)
                yield return new object[]
                {
                    new HashSet<LR0Item>(new LR0Item[]
                        {
                            new LR0Item(Fixtures.Grammar1.RestrictedGrammar.Rules[1], 0),
                        }),
                    Fixtures.Grammar1.RestrictedGrammar.Terminals[0],
                    Fixtures.Grammar1.RestrictedGrammar,
                    new HashSet<LR0Item>(new LR0Item[]
                        {
                            new LR0Item(Fixtures.Grammar1.RestrictedGrammar.Rules[1], 1),
                            new LR0Item(Fixtures.Grammar1.RestrictedGrammar.Rules[1], 0),
                            new LR0Item(Fixtures.Grammar1.RestrictedGrammar.Rules[2], 0),
                        }),
                };

                // Read([S->.aS], S)
                yield return new object[]
                {
                    new HashSet<LR0Item>(new LR0Item[]
                        {
                            new LR0Item(Fixtures.Grammar1.RestrictedGrammar.Rules[1], 0),
                        }),
                    Fixtures.Grammar1.RestrictedGrammar.Grammaticals[1],
                    Fixtures.Grammar1.RestrictedGrammar,
                    new HashSet<LR0Item>(),
                };

                // Read([S->a.S],[S->.aS],[S->.], a) => [S->aS.]
                yield return new object[]
                {
                    new HashSet<LR0Item>(new LR0Item[]
                        {
                            new LR0Item(Fixtures.Grammar1.RestrictedGrammar.Rules[1], 1),
                            new LR0Item(Fixtures.Grammar1.RestrictedGrammar.Rules[1], 0),
                            new LR0Item(Fixtures.Grammar1.RestrictedGrammar.Rules[2], 0),
                        }),
                    Fixtures.Grammar1.RestrictedGrammar.Grammaticals[1],
                    Fixtures.Grammar1.RestrictedGrammar,
                    new HashSet<LR0Item>(new LR0Item[]
                        {
                            new LR0Item(Fixtures.Grammar1.RestrictedGrammar.Rules[1], 2),
                        }),
                };
            }
        }

        [Theory]
        [PropertyData("ValidReadFixtures")]
        public void ReadWithValidData( ISet<LR0Item> set, Symbol symbol, RestrictedStartSymbolGrammar grammar, ISet<LR0Item> expected )
        {
            var actual = LR0CanonicalSets.Read(set, symbol, grammar);
            Assert.NotNull(actual);
            Assert.True(LR0CanonicalSets.AreEqual(actual, expected));
        }

        [Fact]
        public void BuildWithNullGrammar()
        {
            Assert.Throws<ArgumentNullException>(
                () => LR0CanonicalSets.Build(null)
            );
        }

        public static IEnumerable<object[]> ValidBuildFixtures
        {
            get
            {
                yield return new object[] 
                { 
                    Fixtures.EmptyGrammar.RestrictedGrammar, 
                    Fixtures.EmptyGrammar.LR0CanonicalSets
                };

                //TODO: more fixtures
            }
        }

        [Theory]
        [PropertyData("ValidBuildFixtures")]
        public void BuildWithValidGrammar( RestrictedStartSymbolGrammar grammar, LR0CanonicalSets expected )
        {
            var actual = LR0CanonicalSets.Build(grammar);
            Assert.NotNull(actual);
            Assert.True(actual.Equals(expected));
        }
    }
}
