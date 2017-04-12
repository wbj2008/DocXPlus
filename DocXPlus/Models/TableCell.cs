﻿using DocumentFormat.OpenXml.Wordprocessing;
using System.Linq;

namespace DocXPlus.Models
{
    public class TableCell
    {
        private int mergeRight;
        private DocumentFormat.OpenXml.Wordprocessing.TableCell tableCell;

        private TableRow tableRow;

        internal TableCell(TableRow tableRow, DocumentFormat.OpenXml.Wordprocessing.TableCell tableCell)
        {
            this.tableRow = tableRow;
            this.tableCell = tableCell;
        }

        public Borders Borders
        {
            get
            {
                return new Borders(GetTableCellBorders());
            }
        }

        /// <summary>
        /// Merges this cell with the cells to the right. Does not merge the cell contents.
        /// </summary>
        public int MergeRight
        {
            get
            {
                return mergeRight;
            }
            set
            {
                if (mergeRight != value)
                {
                    mergeRight = value;

                    tableRow.MergeCells(this, value);

                    GetGridSpan().Val = value;
                }
            }
        }

        public Paragraph[] Paragraphs
        {
            get
            {
                var paragraphs = tableCell.Descendants<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().ToList();

                var result = new Paragraph[paragraphs.Count()];

                for (int i = 0; i < paragraphs.Count(); i++)
                {
                    result[i] = new Paragraph(paragraphs[i]);
                }

                return result;
            }
        }

        public Shading Shading
        {
            get
            {
                return new Shading(GetTableCellShading());
            }
        }

        internal bool IsMerged { get; set; }

        /// <summary>
        /// Adds a paragraph to the table cell
        /// </summary>
        /// <returns></returns>
        public Paragraph AddParagraph()
        {
            var paragraph = tableCell.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
            return new Paragraph(paragraph);
        }

        public TableCell SetVerticalAlignment(TableVerticalAlignmentValues value)
        {
            var tableCellVerticalAlignment = GetTableCellProperties().GetOrCreate<TableCellVerticalAlignment>();
            tableCellVerticalAlignment.Val = value;

            return this;
        }

        internal GridSpan GetGridSpan()
        {
            return GetTableCellProperties().GetOrCreate<GridSpan>();
        }

        internal TableCellBorders GetTableCellBorders()
        {
            return GetTableCellProperties().GetOrCreate<TableCellBorders>();
        }

        internal TableCellProperties GetTableCellProperties()
        {
            return tableCell.GetOrCreate<TableCellProperties>();
        }

        internal DocumentFormat.OpenXml.Wordprocessing.Shading GetTableCellShading()
        {
            return GetTableCellProperties().GetOrCreate<DocumentFormat.OpenXml.Wordprocessing.Shading>();
        }

        internal void RemoveFromRow()
        {
            tableCell.Remove();
        }
    }
}