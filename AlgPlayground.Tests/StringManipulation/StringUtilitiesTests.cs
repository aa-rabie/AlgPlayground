using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using AlgPlayGroundApp.DataStructures;
using AlgPlayGroundApp.Helpers;
using AlgPlayGroundApp.Sorting;
using AlgPlayGroundApp.StringManipulation;
using NUnit.Framework;

namespace AlgPlayground.Tests
{
    public class StringUtilsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCountVowelsWorksCorrectlyInNonEmptyString()
        {
            var actual = StringUtilities.CountVowels("Hello World");
            Assert.That(3 , Is.EqualTo(actual));
        }

        [Test]
        public void TestCountVowelsWorksCorrectlyInEmptyString()
        {
            var actual = StringUtilities.CountVowels(string.Empty);
            Assert.That(0, Is.EqualTo(actual));
        }

        [Test]
        public void TestReverseWorksCorrectly()
        {
            var actual = StringUtilities.Reverse(string.Empty);
            Assert.That(string.Empty, Is.EqualTo(actual));

            actual = StringUtilities.Reverse(null);
            Assert.That(string.Empty, Is.EqualTo(actual));

            actual = StringUtilities.Reverse("ahmed");
            Assert.That("demha", Is.EqualTo(actual));

            actual = StringUtilities.Reverse("abcd");
            Assert.That("dcba", Is.EqualTo(actual));
        }

        [Test]
        public void TestReverseWordsWorksCorrectly()
        {
            var actual = StringUtilities.ReverseWords(string.Empty);
            Assert.That(string.Empty, Is.EqualTo(actual));

            actual = StringUtilities.ReverseWords(null);
            Assert.That(string.Empty, Is.EqualTo(actual));

            actual = StringUtilities.ReverseWords("   ");
            Assert.That(string.Empty, Is.EqualTo(actual));

            actual = StringUtilities.ReverseWords("   ahmed  ");
            Assert.That("ahmed", Is.EqualTo(actual));

            actual = StringUtilities.ReverseWords("Trees are beautiful");
            Assert.That("beautiful are Trees", Is.EqualTo(actual));
        }

        [Test]
        public void TestAreRotationsWorksCorrectly()
        {
            var actual = StringUtilities.AreRotations(string.Empty, string.Empty);
            Assert.That(false, Is.EqualTo(actual));

            actual = StringUtilities.AreRotations(null, null);
            Assert.That(false, Is.EqualTo(actual));

            actual = StringUtilities.AreRotations("ABCD", "CDAB");
            Assert.That(true, Is.EqualTo(actual));

            actual = StringUtilities.AreRotations("ABCD", "CDABQ");
            Assert.That(false, Is.EqualTo(actual));

            actual = StringUtilities.AreRotations("ABCD", "BDCA");
            Assert.That(false, Is.EqualTo(actual));
        }
    }



}