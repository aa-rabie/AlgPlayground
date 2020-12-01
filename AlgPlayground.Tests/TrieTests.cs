using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using AlgPlayGroundApp.DataStructures;
using AlgPlayGroundApp.Helpers;
using NUnit.Framework;

namespace AlgPlayground.Tests
{
    public class TrieTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestContainsReturnFalseForIncompleteWord()
        {
           var tmp = new Trie();
           tmp.Insert("canada");
           Assert.That(tmp.Contains("can"), Is.EqualTo(false));
        }

        [Test]
        public void TestContainsReturnTrueForCompleteWord()
        {
            var tmp = new Trie();
            tmp.Insert("canada");
            Assert.That(tmp.Contains("canada"), Is.EqualTo(true));
        }

        [Test]
        public void TestPreOrderTraverse()
        {
            var tmp = new Trie();
            tmp.Insert("canada");
            var data = new string(tmp.PreOrderTraverse().ToArray());
            StringAssert.AreEqualIgnoringCase("canada", data);
        }

        [Test]
        public void TestPostOrderTraverse()
        {
            var tmp = new Trie();
            tmp.Insert("care");
            var data = new string(tmp.PostOrderTraverse().ToArray());
            StringAssert.AreEqualIgnoringCase("erac", data);
        }

        [Test]
        public void TestRemoveExistingWord()
        {
            var tmp = new Trie();
            tmp.Insert("car");
            tmp.Insert("care");
            tmp.Remove("car");
            Assert.That(tmp.Contains("car"), Is.EqualTo(false));
            Assert.That(tmp.Contains("care"), Is.EqualTo(true));
            tmp.Insert("car");
            tmp.Remove("care");
            Assert.That(tmp.Contains("car"), Is.EqualTo(true));
            Assert.That(tmp.Contains("care"), Is.EqualTo(false));
        }

        [Test]
        public void TestAutoCompleteExistingWord()
        {
            var tmp = new Trie();
            tmp.Insert("car");
            tmp.Insert("care");
            tmp.Insert("careful");
            tmp.Insert("cargo");
            tmp.Insert("egg");
            var words = tmp.FindWords("car");
            Assert.That(words[0],Is.EqualTo("car"));
            Assert.That(words[1],Is.EqualTo("care"));
            Assert.That(words[2],Is.EqualTo("careful"));
            Assert.That(words[3],Is.EqualTo("cargo"));

            words = tmp.FindWords("e");
            Assert.That(words[0], Is.EqualTo("egg"));
            Assert.That(words.Count, Is.EqualTo(1));

            words = tmp.FindWords("care");
            Assert.That(words[0], Is.EqualTo("care"));
            Assert.That(words[1], Is.EqualTo("careful"));
            Assert.That(words.Count, Is.EqualTo(2));
        }

        [Test]
        public void TestAutoCompleteNonExistingWord()
        {
            var tmp = new Trie();
            tmp.Insert("car");
            tmp.Insert("care");
            tmp.Insert("careful");
            tmp.Insert("cargo");
            tmp.Insert("egg");
            var words = tmp.FindWords("card");
            Assert.That(words.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestAutoCompleteEmptyWord()
        {
            var tmp = new Trie();
            tmp.Insert("car");
            tmp.Insert("care");
            tmp.Insert("careful");
            tmp.Insert("cargo");
            tmp.Insert("egg");
            var words = tmp.FindWords("");
            Assert.That(words[0], Is.EqualTo("car"));
            Assert.That(words[1], Is.EqualTo("care"));
            Assert.That(words[2], Is.EqualTo("careful"));
            Assert.That(words[3], Is.EqualTo("cargo"));
            Assert.That(words[4], Is.EqualTo("egg"));
        }

        [Test]
        public void TestAutoCompleteNullWord()
        {
            var tmp = new Trie();
            tmp.Insert("car");
            tmp.Insert("care");
            tmp.Insert("careful");
            tmp.Insert("cargo");
            tmp.Insert("egg");
            var words = tmp.FindWords(null);
            Assert.That(words.Count, Is.EqualTo(0));
        }
    }



}