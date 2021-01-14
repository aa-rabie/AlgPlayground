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

        [Test]
        public void TestRemoveDuplicatesWorksCorrectly()
        {
            var actual = StringUtilities.RemoveDuplicates(string.Empty);
            Assert.That(string.Empty, Is.EqualTo(actual));

            actual = StringUtilities.RemoveDuplicates(null);
            Assert.That(string.Empty, Is.EqualTo(actual));

            actual = StringUtilities.RemoveDuplicates("ABCD");
            Assert.That("ABCD", Is.EqualTo(actual));

            actual = StringUtilities.RemoveDuplicates("AAAAB");
            Assert.That("AB", Is.EqualTo(actual));

            actual = StringUtilities.RemoveDuplicates("     ");
            Assert.That(" ", Is.EqualTo(actual));
        }

        [Test]
        public void TestGetMostOccuringCharWorksCorrectly()
        {
            var actual = StringUtilities.GetMaxOccuringChar("AAAABC");
            Assert.That('A', Is.EqualTo(actual));

            actual = StringUtilities.GetMaxOccuringChar("Trees are beautiful");
            Assert.That('e', Is.EqualTo(actual));

            Assert.Throws(typeof(ArgumentException), () => { StringUtilities.GetMaxOccuringChar(null); });
        }

        [Test]
        public void TestCapitalizeWorksCorrectly()
        {
            var actual = StringUtilities.Capitalize(null);
            Assert.That(string.Empty, Is.EqualTo(actual));

            actual = StringUtilities.Capitalize("");
            Assert.That(string.Empty, Is.EqualTo(actual));

            actual = StringUtilities.Capitalize("    ");
            Assert.That(string.Empty, Is.EqualTo(actual));

            actual = StringUtilities.Capitalize("  A   B   C  ");
            Assert.That("A B C", Is.EqualTo(actual));

            actual = StringUtilities.Capitalize("Today Is GOOD day");
            Assert.That("Today Is Good Day", Is.EqualTo(actual));
        }
    }



}