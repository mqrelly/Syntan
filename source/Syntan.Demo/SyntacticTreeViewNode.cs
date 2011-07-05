using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Syntan.Demo
{
    public class SyntacticTreeViewNode
    {
        public SyntacticTreeViewNode( string name )
        {
            this.name = name;
            this.children = new List<SyntacticTreeViewNode>();
            this.Children = this.children.AsReadOnly();
        }

        private string name;
        private SyntacticTreeViewNode parent;
        private List<SyntacticTreeViewNode> children;

        public string Name
        {
            get { return this.name; }
        }

        public int Level
        {
            get { return this.parent == null ? 0 : this.parent.Level + 1; }
        }

        public SyntacticTreeViewNode Parent
        {
            get { return this.parent; }
        }

        public SyntacticTreeViewNode Root
        {
            get { return this.parent == null ? this : this.parent.Root; }
        }

        public IList<SyntacticTreeViewNode> Children { get; private set; }

        public void ClearChildren()
        {
            for( int i = 0; i < this.children.Count; ++i )
                this.children[i].parent = null;
            this.children.Clear();
        }

        public void AddChild( SyntacticTreeViewNode child )
        {
            if( child == null )
                throw new ArgumentNullException("child");

            if( child.Parent != null )
                child.Parent.RemoveChild(child);

            this.children.Add(child);
            child.parent = this;
        }

        public void RemoveChild( SyntacticTreeViewNode child )
        {
            if( this.children.Remove(child) )
                child.parent = null;
        }

        internal RectangleF NodeBox { get; set; }

        internal RectangleF NodeBBox { get; set; }

        internal RectangleF SubtreeBBox { get; set; }

        internal PointF OffsetFromParent { get; set; }
    }
}
