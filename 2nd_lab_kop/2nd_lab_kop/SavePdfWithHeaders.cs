using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System.Collections.Generic;
using System.Reflection;
using System;

namespace _2nd_lab_kop
{
    public class SavePdfWithHeaders
    {
        private Document _document;

        private Section _section;

        private Table _table;

        private static void DefineStyles(Document document)
        {
            var style = document.Styles["Normal"];
            style.Font.Name = "Times New Roman";
            style.Font.Size = 14;
            style = document.Styles.AddStyle("NormalTitle", "Normal");
            style.Font.Bold = true;
        }

        public void CreatePdf<T>(string filename, string title, List<string> width, List<string> height, List<Tuple<string, string>> header, List<T> data)
        {
            if (string.IsNullOrEmpty(filename) || string.IsNullOrEmpty(title) || data.Count == 0 
                || width.Count == 0 || height.Count == 0)
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

            _table = _document.LastSection.AddTable();
            foreach(var colW in width)
            {
                _table.AddColumn(colW);
            }
            foreach(var rowH in height)
            {
                var row = _table.AddRow();
                row.Height = rowH;
            }

            Unit borderWidth = 0.5;
            for (int i = 0; i < header.Count; i++)
            {
                Paragraph par = new Paragraph();
                par.AddText(header[i].Item1);
                par.Style = "NormalTitle";

                _table.Rows[0].Cells[i].Borders.Left.Width = borderWidth;
                _table.Rows[0].Cells[i].Borders.Right.Width = borderWidth;
                _table.Rows[0].Cells[i].Borders.Top.Width = borderWidth;
                _table.Rows[0].Cells[i].Borders.Bottom.Width = borderWidth;

                _table.Rows[0].Cells[i].Format.Alignment = ParagraphAlignment.Center;
                _table.Rows[0].Cells[i].VerticalAlignment = VerticalAlignment.Center;

                _table.Rows[0].Cells[i].Add(par);
            }

            for (int j = 0; j < data.Count; j++)
            {
                for (int i = 0; i < header.Count; i++)
                {
                    string style;
                    if (i == 0) style = "NormalTitle";
                    else style = "Normal";
                    Paragraph par = new Paragraph();
                    par.AddText(data[j].GetType().GetProperty(header[i].Item2).GetValue(data[j]).ToString());
                    par.Style = style;

                    _table.Rows[j + 1].Cells[i].Borders.Left.Width = borderWidth;
                    _table.Rows[j + 1].Cells[i].Borders.Right.Width = borderWidth;
                    _table.Rows[j + 1].Cells[i].Borders.Top.Width = borderWidth;
                    _table.Rows[j + 1].Cells[i].Borders.Bottom.Width = borderWidth;

                    _table.Rows[j + 1].Cells[i].Format.Alignment = ParagraphAlignment.Center;
                    _table.Rows[j + 1].Cells[i].VerticalAlignment = VerticalAlignment.Center;

                    _table.Rows[j + 1].Cells[i].Add(par);
                }
            }

            var renderer = new PdfDocumentRenderer(true)
            {
                Document = _document
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(filename);
        }

        private Paragraph InsertCell(string text, string style)
        {
            Paragraph paragraph = new Paragraph();
            paragraph.AddText(text);
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = style;
            return paragraph;
        }
    }
}
