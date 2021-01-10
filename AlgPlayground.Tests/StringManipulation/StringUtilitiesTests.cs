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
    }



}