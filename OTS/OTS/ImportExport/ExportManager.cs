using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OTS.Helper.ExportImport.Help;

using OTS.Model;

namespace OTS.Helper.ExportImport
{
    public class ExportManager
    {

        public virtual byte[] ExportInventoriesToXlsx(IEnumerable<Inventory> inventories)
        {
            //property array
            var properties = new[]
            {
                new PropertyByName<Inventory>("InventoryID", p => p.InventoryID),
                new PropertyByName<Inventory>("Name", p => p.name),
                new PropertyByName<Inventory>("Description", p => p.description),
                new PropertyByName<Inventory>("IsActive", p => p.IsActive)
            };
            return ExportToXlsx(properties, inventories);
        }

        public virtual byte[] ExportSubInventoriesToXlsx(IEnumerable<SubInventory> subinventories)
        {
            //property array
            var properties = new[]
            {
                new PropertyByName<SubInventory>("SubInventoryID", p => p.SubInventoryID),
                new PropertyByName<SubInventory>("Name", p => p.name),
                new PropertyByName<SubInventory>("Description", p => p.description),
                new PropertyByName<SubInventory>("InventoryID", p => p.InventoryID),
                new PropertyByName<SubInventory>("IsActive", p => p.IsActive)
            };
            return ExportToXlsx(properties, subinventories);
        }

        public virtual byte[] ExportQuestionsAnswersToXlsx(IEnumerable<Answer> answers)
        {
            var properties = new[]
            {
                new PropertyByName<Answer>("QuestionID", p => p.QuestionID),
                new PropertyByName<Answer>("SubInventoryID", p => Int32.Parse(GetQuestionInfo(p)[0])),
                new PropertyByName<Answer>("QuestionText", p => GetQuestionInfo(p)[1]),
                new PropertyByName<Answer>("IsQuestionActive", p => Boolean.Parse(GetQuestionInfo(p)[2])),
                new PropertyByName<Answer>("AnswerID", p => p.AnswerID),
                new PropertyByName<Answer>("AnswerText", p => p.AnswerText),
                new PropertyByName<Answer>("IsCorrect", p => p.IsCorrect),
                new PropertyByName<Answer>("IsAnswerActive", p => p.IsActive)
            };

            var answerList = answers.ToList();
            return ExportToXlsx(properties, answerList);
        }

        protected virtual string[] GetQuestionInfo(Answer answer)
        {
            var question = BLL.Question.Instance.SelectOne(answer.QuestionID);
            
            return new[] { question.SubInventoryID.ToString(), question.QuestionText, question.IsActive.ToString() };
        }

        protected virtual byte[] ExportToXlsx<T>(PropertyByName<T>[] properties, IEnumerable<T> itemsToExport)
        {
            using (var stream = new MemoryStream())
            {
                // ok, we can run the real code of the sample now
                using (var xlPackage = new ExcelPackage(stream))
                {
                    // uncomment this line if you want the XML written out to the outputDir
                    //xlPackage.DebugMode = true; 

                    // get handles to the worksheets
                    var worksheet = xlPackage.Workbook.Worksheets.Add(typeof(T).Name);
                    var fWorksheet = xlPackage.Workbook.Worksheets.Add("DataForFilters");
                    fWorksheet.Hidden = eWorkSheetHidden.VeryHidden;

                    //create Headers and format them 
                    var manager = new PropertyManager<T>(properties.Where(p => !p.Ignore));
                    manager.WriteCaption(worksheet, SetCaptionStyle);

                    var row = 2;
                    foreach (var items in itemsToExport)
                    {
                        manager.CurrentObject = items;
                        manager.WriteToXlsx(worksheet, row++, false, fWorksheet: fWorksheet);
                    }

                    xlPackage.Save();
                }
                return stream.ToArray();
            }
        }

        protected virtual void SetCaptionStyle(ExcelStyle style)
        {
            style.Fill.PatternType = ExcelFillStyle.Solid;
            style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
            style.Font.Bold = true;
        }

    }
}
