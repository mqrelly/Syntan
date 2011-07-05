using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.SyntacticAnalysis.LR
{
    /// <summary>
    /// Builds the LR(0) canonical sets of a <see cref="RestrictedStartSymbolGrammar"/>,
    /// and stores to which <see cref="Symbol"/> belongs what state transitions.
    /// </summary>
    //TODO:
    // - Use std collcetions: IList<ISet<LR0Item>> and int[,] for transitions?
    // - OR create a Transitions helper class to make it look cleaner?
    public class LR0CanonicalSets
    {
        #region Public static methods

        /// <summary>
        /// Tells if the two given canonical sets are considered equal.
        /// </summary>
        /// <param name="left">One set.</param>
        /// <param name="right">The other set.</param>
        /// <returns><c>true</c> if the sets are equal, <c>false</c> otherwise.</returns>
        public static bool AreEqual( ISet<LR0Item> left, ISet<LR0Item> right )
        {
            if( left == null && right == null )
                return true;

            if( left == null || right == null )
                return false;

            if( left.Count != right.Count )
                return false;

            var eq = new Utils.DefaultEqualityComparer<LR0Item>();
            foreach( var item in right )
                if( !left.Contains(item, eq) )
                    return false;

            return true;
        }

        /// <summary>
        /// Creates and returns the LR(0) canonical sets for the given <paramref name="grammar"/>.
        /// </summary>
        /// <param name="grammar">The grammar to build the canonical sets for.</param>
        /// <returns>The built canonical sets.</returns>
        /// <exception cref="ArgumentNullException"> if <paramref name="grammar"/> is <c>null</c>.</exception>
        public static LR0CanonicalSets Build( RestrictedStartSymbolGrammar grammar )
        {
            if( grammar == null )
                throw new ArgumentNullException("grammar");

            var terms_and_gramms = new List<Symbol>();
            terms_and_gramms.AddRange(grammar.Grammaticals);
            terms_and_gramms.AddRange(grammar.Terminals);
            var sets = new LR0CanonicalSets();

            // Calculate the I0 canonical set from the 'starting' rule
            var s0 = new HashSet<LR0Item>();
            if( grammar.Rules.Count > 0 )
                s0.Add(new LR0Item(grammar.StartRule, 0));
            var I0 = Closure(s0, grammar);
            sets.Add(I0);


            // Generate LR0CanonicalSets with Read()
            for( int current_set_id = 0; current_set_id < sets.Sets.Count; ++current_set_id )
                // Generate new sets for every symbol read
                foreach( var symbol in terms_and_gramms )
                {
                    var new_I = Read(sets.Sets[current_set_id], symbol, grammar);

                    // If the set is empty then continue
                    if( new_I.Count == 0 )
                        continue;

                    // Identify new_I
                    int next_set_id = sets.IndexOf(new_I);

                    // If this is a new CanonicalSet then add to the group
                    if( next_set_id == -1 )
                        next_set_id = sets.Add(new_I);

                    // Record the state transition
                    sets.SetTransition(current_set_id, symbol, next_set_id);
                }

            return sets;
        }

        /// <summary>
        /// Calculates and returns the closure of the given canonical set.
        /// </summary>
        /// <param name="set">Get the closure of this set.</param>
        /// <param name="grammar">The set belongs to this grammar.</param>
        /// <returns>The closure of the given <paramref name="set"/>.</returns>
        /// <exception cref="ArgumentNullException"> if any of the parameters is <c>null</c>.</exception>
        public static ISet<LR0Item> Closure( ISet<LR0Item> set, RestrictedStartSymbolGrammar grammar )
        {
            if( object.ReferenceEquals(set, null) )
                throw new ArgumentNullException("set");
            if( object.ReferenceEquals(grammar, null) )
                throw new ArgumentNullException("grammar");


            var closure = new List<LR0Item>(set);

            for( int i = 0; i < closure.Count; ++i )
            {
                var item = closure[i];

                // Skip this, if the cursor pos is on the end
                if( item.CursorPosition == item.Rule.RightHandSide.Count )
                    continue;

                // Skip this, if the next_symbol is not grammatical
                var next_symbol = item.Rule.RightHandSide[item.CursorPosition];
                if( !(next_symbol is GrammaticalSymbol) )
                    continue;

                // Get all the rules whit next_symbol on the left hand side
                var rules = from rule in grammar.Rules
                            where rule.LeftHandSide.Equals(next_symbol)
                            select rule;

                // Add all the generated RL(0) items to the closure
                foreach( var rule in rules )
                {
                    var new_item = new LR0Item(rule, 0);
                    if( !closure.Contains(new_item) )
                        closure.Add(new_item);
                }
            }

            return new HashSet<LR0Item>(closure);
        }

        /// <summary>
        /// Calculates and returns the read function on the given <paramref name="set"/>.
        /// </summary>
        /// <param name="set"></param>
        /// <param name="symbol"></param>
        /// <param name="grammar"><paramref name="set"/> and <paramref name="symbol"/> belong to this grammar.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"> if any of the parameters is <c>null</c>.</exception>
        public static ISet<LR0Item> Read( ISet<LR0Item> set, Symbol symbol, RestrictedStartSymbolGrammar grammar )
        {
            if( object.ReferenceEquals(set, null) )
                throw new ArgumentNullException("set");
            if( object.ReferenceEquals(symbol, null) )
                throw new ArgumentNullException("symbol");
            if( object.ReferenceEquals(grammar, null) )
                throw new ArgumentNullException("grammar");


            var result = new HashSet<LR0Item>();

            foreach( var item in set )
                if( item.CursorPosition < item.Rule.RightHandSide.Count &&
                    item.Rule.RightHandSide[item.CursorPosition].Equals(symbol) )
                {
                    // If the next symbol is the reading symbol, advance the CursorPosition
                    // then add the closure of it to the result.
                    var new_set = new HashSet<LR0Item>();
                    new_set.Add(new LR0Item(item.Rule, item.CursorPosition + 1));

                    result.UnionWith(Closure(new_set, grammar));
                }

            return result;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor. Creates an empty instance.
        /// </summary>
        public LR0CanonicalSets()
        {
            this.sets = new List<ISet<LR0Item>>();
            this.Sets = this.sets.AsReadOnly();
            this.transitions = new List<Dictionary<Symbol, int>>();
        }

        #endregion

        #region Private fields

        private List<ISet<LR0Item>> sets;
        private List<Dictionary<Symbol, int>> transitions;

        #endregion

        #region Sets

        /// <summary>
        /// Gets a read-only list of canonicanl sets as ISet of <see cref="LR0Item"/>s.
        /// </summary>
        public IList<ISet<LR0Item>> Sets { get; private set; }

        /// <summary>
        /// Gets the index of the given set.
        /// </summary>
        /// <param name="set">The set.</param>
        /// <returns>The index of the given <paramref name="set"/> if it is present in Sets,
        /// <c>-1</c> otherwise.</returns>
        public int IndexOf( ISet<LR0Item> set )
        {
            for( int i = 0; i < this.sets.Count; ++i )
                if( AreEqual(this.sets[i], set) )
                    return i;

            return -1;
        }

        public int Add( ISet<LR0Item> set )
        {
            this.sets.Add(set);
            this.transitions.Add(new Dictionary<Symbol, int>());

            return this.sets.Count - 1;
        }

        #endregion

        #region Transitions

        public int GetTransition( int start_index, Symbol symbol )
        {
            int target_index;
            if( !this.transitions[start_index].TryGetValue(symbol, out target_index) )
                return -1;

            return target_index;
        }

        internal void SetTransition( int start_index, Symbol symbol, int traget_index )
        {
            this.transitions[start_index][symbol] = traget_index;
        }

        internal void UnsetTransition( int start_index, Symbol symbol )
        {
            this.transitions[start_index].Remove(symbol);
        }

        #endregion

        #region Equality

        public bool Equals( LR0CanonicalSets other )
        {
            if( object.ReferenceEquals(other, null) )
                return false;

            if( !other.Sets.SequenceEqual(other.Sets,
                new Utils.DelegateEqualityComparer<ISet<LR0Item>>(
                    ( x, y ) => LR0CanonicalSets.AreEqual(x, y),
                    ( obj ) => obj.GetHashCode())) )
                return false;

            //TODO: Check transitions too? 
            // If the sets are the same, the transition must be the same too.

            return true;
        }

        public override bool Equals( object obj )
        {
            return this.Equals(obj as LR0CanonicalSets);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
