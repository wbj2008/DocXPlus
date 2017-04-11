﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DocXPlusTests
{
    [TestClass]
    public class SectionTests : TestBase
    {
        [TestMethod]
        public void SectionPageBreak()
        {
            var filename = Path.Combine(TempDirectory, "SectionPageBreak.docx");

            var doc = DocXPlus.DocX.Create(filename, DocumentFormat.OpenXml.WordprocessingDocumentType.Document);

            doc.AddParagraph().Append("Page 1");

            doc.InsertSectionPageBreak();

            doc.AddParagraph().Append("Page 2");

            doc.InsertSectionPageBreak();

            doc.AddParagraph().Append("Page 3");

            doc.Close();

            ValidateWordDocument(filename);

            Launch(filename);
        }

        [TestMethod]
        public void SectionPageBreakLandscapePortrait()
        {
            var filename = Path.Combine(TempDirectory, "SectionPageBreakLandscapePortrait.docx");

            var doc = DocXPlus.DocX.Create(filename, DocumentFormat.OpenXml.WordprocessingDocumentType.Document);

            doc.Orientation = DocumentFormat.OpenXml.Wordprocessing.PageOrientationValues.Landscape;

            doc.AddParagraph().Append("Landscape");

            doc.InsertSectionPageBreak();

            doc.Orientation = DocumentFormat.OpenXml.Wordprocessing.PageOrientationValues.Portrait;

            doc.AddParagraph().Append("Portrait");

            doc.Close();

            ValidateWordDocument(filename);

            Launch(filename);
        }

        [TestMethod]
        public void SectionPageBreakLandscapePortraitLandscape()
        {
            var filename = Path.Combine(TempDirectory, "SectionPageBreakLandscapePortraitLandscape.docx");

            var doc = DocXPlus.DocX.Create(filename, DocumentFormat.OpenXml.WordprocessingDocumentType.Document);

            doc.Orientation = DocumentFormat.OpenXml.Wordprocessing.PageOrientationValues.Landscape;

            doc.AddParagraph().Append("Landscape");

            doc.InsertSectionPageBreak();

            doc.Orientation = DocumentFormat.OpenXml.Wordprocessing.PageOrientationValues.Portrait;

            doc.AddParagraph().Append("Portrait");

            doc.InsertSectionPageBreak();

            doc.Orientation = DocumentFormat.OpenXml.Wordprocessing.PageOrientationValues.Landscape;

            doc.AddParagraph().Append("Landscape");

            doc.Close();

            ValidateWordDocument(filename);

            Launch(filename);
        }

        [TestMethod]
        public void SectionPageBreakPortraitLandscape()
        {
            var filename = Path.Combine(TempDirectory, "SectionPageBreakPortraitLandscape.docx");

            var doc = DocXPlus.DocX.Create(filename, DocumentFormat.OpenXml.WordprocessingDocumentType.Document);

            doc.AddParagraph().Append("Portrait");

            doc.InsertSectionPageBreak();

            doc.Orientation = DocumentFormat.OpenXml.Wordprocessing.PageOrientationValues.Landscape;

            doc.AddParagraph().Append("Landscape");

            doc.Close();

            ValidateWordDocument(filename);

            Launch(filename);
        }

        [TestMethod]
        public void SectionPageBreakPortraitLandscapePortrait()
        {
            var filename = Path.Combine(TempDirectory, "SectionPageBreakPortraitLandscapePortrait.docx");

            var doc = DocXPlus.DocX.Create(filename, DocumentFormat.OpenXml.WordprocessingDocumentType.Document);

            doc.AddParagraph().Append("Portrait");

            doc.InsertSectionPageBreak();

            doc.Orientation = DocumentFormat.OpenXml.Wordprocessing.PageOrientationValues.Landscape;

            doc.AddParagraph().Append("Landscape");

            doc.InsertSectionPageBreak();

            doc.Orientation = DocumentFormat.OpenXml.Wordprocessing.PageOrientationValues.Portrait;

            doc.AddParagraph().Append("Portrait");

            doc.Close();

            ValidateWordDocument(filename);

            Launch(filename);
        }
    }
}