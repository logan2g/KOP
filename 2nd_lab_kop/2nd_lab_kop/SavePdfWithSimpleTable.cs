using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System.Collections.Generic;
using System;

namespace _2nd_lab_kop
{
    public class SavePdfWithSimpleTable
    {
        private Document _document;

        private Section _section;

        private Table _table;

        internal static void DefineStyles(Document document)
        {
            var style = document.Styles["Normal"];
            style.Font.Name = "Times New Roman";
            style.Font.Size = 14;
            style = document.Styles.AddStyle("NormalTitle", "Normal");
            style.Font.Bold = true;
        }

        public void CreatePdf(string filename, string title, List<string[][]> data)
        {
            if (string.IsNullOrEmpty(filename) || string.IsNullOrEmpty(title) || data.Count == 0)
            {
                throw new Exception("Некорректные входные данные!");
            }

            _document = new Document();
            DefineStyles(_document);
            _section = _document.AddSection();

            var paragraph = _section.AddParagraph(title);
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "NormalTitle";

            foreach(var table in data)
            {
                    

                for(int i = 0; i < table[0].Length; i++)
                {
                    _table.AddColumn("3cm");
                }

                foreach (var row in table)
                {
                    CreateRow(row);
                }
            }

            var renderer = new PdfDocumentRenderer(true)
            {
                Document = _document
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(filename);
        }

        private void CreateRow(string[] text)
        {
            var row = _table.AddRow();
            for (int i = 0; i < text.Length; ++i)
            {
                row.Cells[i].AddParagraph(text[i]);

                Unit borderWidth = 0.5;

                row.Cells[i].Borders.Left.Width = borderWidth;
                row.Cells[i].Borders.Right.Width = borderWidth;
                row.Cells[i].Borders.Top.Width = borderWidth;
                row.Cells[i].Borders.Bottom.Width = borderWidth;

                row.Cells[i].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[i].VerticalAlignment = VerticalAlignment.Center;
            }
        }
    }
}
