using System.Collections.Generic;
using System.Linq;

namespace AlgPlayGroundApp.DataStructures
{
    public class Trie
    {
        public class Node
        {
            private char _value;
            private System.Collections.Generic.Dictionary<char,Node> _children = new Dictionary<char, Node>();

            public bool IsEndOfWord { get; set; }

            public Node(char value) => _value = value;
            public char Value => _value;

            public override string ToString()
            {
                return $"value : {_value}";
            }

            public bool HasChild(char ch) => _children.ContainsKey(ch);

            public Node GetChild(char ch)
            {
                return HasChild(ch) ? _children[ch] : null;
            }

            public void AddChild(char ch)
            {
                if(!HasChild(ch))
                    _children.Add(ch, new Node(ch));
            }

            public List<Node> GetChildren()
            {
                return _children.Values.ToList();
            }

            public void RemoveChild(char ch)
            {
                if (HasChild(ch))
                    _children.Remove(ch);
            }

            public bool HasChildren => _children.Count > 0;
        }

        // root node does not store any value/character but it is defined because tree should have a root
        private Node _root = new Node(' ');

        public void Insert(string word)
        {
            if(string.IsNullOrEmpty(word))
                return;
            //this line is added by me (to make Trie store words regardless of characters are small or capital 
            word = word.Trim().ToLowerInvariant();
            //set current node to root 
            var current = _root;
            foreach (var ch in word)
            {
                //ask current node if it has current character in its children collection 
                if(!current.HasChild(ch))
                    // add character to current node's children
                    current.AddChild(ch);

                // update current node; it will point to current-character's Node (the node that we created in AddChild(ch) call above
                current = current.GetChild(ch);
            }
            //we added all word characters to Trie
            // current node points to last character in word & we should set IsEndOfWord = true
            current.IsEndOfWord = true;
        }

        public bool Contains(string word)
        {
            if (string.IsNullOrEmpty(word))
                return false;

            //this line is added by me (to make Trie store words regardless of characters are small or capital 
            word = word.Trim().ToLowerInvariant();
            //set current node to root 
            var current = _root;
            foreach (var ch in word)
            {
                //ask current node if it has current character in its children collection 
                if (!current.HasChild(ch))
                    return false;

                // update current node; so we can search for next character in next iteration in foreach-loop
                current = current.GetChild(ch);
            }
            // current node points to last character in word 
            // return true only if current node refers to last character in a word
            return current.IsEndOfWord;
        }

        #region Traverse methods
        public IList<char> PreOrderTraverse()
        {
            var list = PreOrderTraverse(_root);
            return list;
        }

        private IList<char> PreOrderTraverse(Node node)
        {
            var list = new List<char>();
            //we add node-value first 
            if(node != _root) // root value is dummy value - we do not need to add it
                list.Add(node.Value);

            // then add children values
            var children = node.GetChildren();
            foreach (var child in children)
            {
                list.AddRange(PreOrderTraverse(child));
            }
            return list;
        }

        public IList<char> PostOrderTraverse()
        {
            return PostOrderTraverse(_root);
        }

        private IList<char> PostOrderTraverse(Node node)
        {
            var list = new List<char>();
            //add children values
            var children = node.GetChildren();
            foreach (var child in children)
            {
                list.AddRange(PostOrderTraverse(child));
            }
            // then we add node-value
            if (node != _root) // root value is dummy value - we do not need to add it
                list.Add(node.Value);
            
            return list;
        }
        #endregion

        #region Remove
        public void Remove(string word)
        {
            if(string.IsNullOrEmpty(word))
                return;

            Remove(_root, word, index: 0);
        }

        private void Remove(Node parentNode, string word, int index)
        {
            if (index == word.Length)
            {
                //if we reached last character in word we need to set IsEndOfWord = false
                parentNode.IsEndOfWord = false;
                return;
            }

            var ch = word[index];
            var child = parentNode.GetChild(ch);
            if(child == null)
                // if word does not exist in trie then exit
                return;

            //use post-traversal to remove characters
            // remove next character
            Remove(child, word, index + 1);

            //remove node/character from trie only when
            // 1) it has no children
            // 2) is not end of word (may be the current character "we are checking now" is endOfWord for another word in trie  
            if(!child.IsEndOfWord && !child.HasChildren)
                parentNode.RemoveChild(ch);
        }
        #endregion

        #region FindWords - auto-complete related methods

        /// <summary>
        /// this function will return list of words that auto-complete specific prefix (if any) in Trie
        /// for example if Trie contains [car,care,cargo,egg,careful] & prefix is "care"
        /// then list will contain [care,careful]
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public List<string> FindWords(string prefix)
        {
            var words = new List<string>();
            var lastCharNode = FindLastNodeOfWord(prefix);
            if (lastCharNode == null)
            {
                return words;
            }

            FindWords(lastCharNode, prefix, words);

            return words;
        }

        private void FindWords(Node root, string prefix, List<string> words)
        {
            if(root == null)
                return;
            if (root.IsEndOfWord)
            {
                //the prefix already is complete word, so we need to add it to words array
                words.Add(prefix);
            }

            var children = root.GetChildren();
            foreach (var child in children)
            {
                //for each char in Children
                // we will concatenate the char to prefix and create "new-prefix"
                // then we try to search and see if there are any words that auto-complete the new-prefix
                var newPrefix = $"{prefix}{child.Value}";
                FindWords(child, newPrefix , words);
            }
        }

        private Node FindLastNodeOfWord(string prefix)
        {
            if (prefix == null)
                return null;

            var current = _root;
            foreach (var ch in prefix)
            {
                if (!current.HasChild(ch))
                    return null;

                current = current.GetChild(ch);
            }
            //now current points to last character in Prefix
            return current;
        }

        #endregion
    }
}