using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.Rendering;
using System;

namespace _2nd_lab_kop
{
    public class SavePdfWithPlot
    {
        private Document _document;

        private Section _section;

        public void CreatePdf(string filename, string docTitle, string plotTitle, LegendPostion position, 
            string seriesName, double[] data)
        {
            if (string.IsNullOrEmpty(filename) || string.IsNullOrEmpty(docTitle) || string.IsNullOrEmpty(plotTitle)
                || string.IsNullOrEmpty(seriesName) || data == null)
            {
                throw new Exception("Некорректные входные данные!");
            }
            _document = new Document();
            SavePdfWithSimpleTable.DefineStyles(_document);
            _section = _document.AddSection();

            var paragraph = _section.AddParagraph(docTitle);
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "NormalTitle";

            var chart = _document.LastSection.AddChart(ChartType.Column2D);
            chart.HeaderArea.AddParagraph(plotTitle);

            chart.Width = 450;
            chart.Height = 500;
            
            var series = chart.SeriesCollection.AddSeries();
            series.Name = seriesName;
            series.Add(data);

            switch (position)
            {
                case LegendPostion.Top:
                    chart.TopArea.AddLegend();
                    break;
                case LegendPostion.Bottom:
                    chart.BottomArea.AddLegend();
                    break;
                case LegendPostion.Left:
                    chart.LeftArea.AddLegend();
                    break;
                case LegendPostion.Right:
                    chart.RightArea.AddLegend();
                    break;
            }
            
            chart.XAxis.MajorTickMark = TickMarkType.Outside;
            chart.XAxis.Title.Caption = "X-Axis";

            chart.YAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.HasMajorGridlines = true;
            chart.YAxis.Title.Caption = "Y-Axis";

            chart.PlotArea.LineFormat.Color = Color.Parse("Blue");
            chart.PlotArea.LineFormat.Width = 1;
            chart.PlotArea.LineFormat.Visible = true;

            chart.DataLabel.Type = DataLabelType.Value;
            chart.DataLabel.Position = DataLabelPosition.OutsideEnd;

            var renderer = new PdfDocumentRenderer(true)
            {
                Document = _document
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(filename);
        }
    }
}
