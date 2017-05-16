using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OTS.Helper.ExportImport.Help;
using OTS.Model;

namespace OTS.Helper.ExportImport
{
    public class ImportManager
    {
        public virtual void ImportInventoriesFromXlsx(Stream stream, int userLogin)
        {
            using (var xlPackage = new ExcelPackage(stream))
            {
                // get the first worksheet in the workbook
                var worksheet = xlPackage.Workbook.Worksheets.FirstOrDefault();
                if (worksheet == null)
                    throw new Exception("No worksheet found");

                //the columns
                var properties = GetPropertiesByExcelCells<Inventory>(worksheet);

                var manager = new PropertyManager<Inventory>(properties);

                var iRow = 2;

                while (true)
                {
                    var allColumnsAreEmpty = manager.GetProperties
                        .Select(property => worksheet.Cells[iRow, property.PropertyOrderPosition])
                        .All(cell => cell == null || cell.Value == null || String.IsNullOrEmpty(cell.Value.ToString()));

                    if (allColumnsAreEmpty)
                        break;

                    manager.ReadFromXlsx(worksheet, iRow);

                    var inventory = BLL.Inventory.Instance.SelectOne(manager.GetProperty("InventoryID").IntValue);

                    var isNew = inventory == null;

                    inventory = inventory ?? new Inventory();

                    if (isNew)
                    {
                        inventory.CreatedDate = DateTime.UtcNow;
                        inventory.CreatedBy = userLogin;
                    }

                    foreach (var property in manager.GetProperties)
                    {
                        switch (property.PropertyName)
                        {
                            case "Name":
                                inventory.name = property.StringValue;
                                break;
                            case "Description":
                                inventory.description = property.StringValue;
                                break;
                            case "IsActive":
                                inventory.IsActive = property.BooleanValue;
                                break;
                        }
                    }

                    inventory.ModifiedDate = DateTime.UtcNow;
                    inventory.ModifiedBy = userLogin;

                    if (isNew)
                        BLL.Inventory.Instance.Add(inventory);
                    else
                        BLL.Inventory.Instance.Update(inventory);

                    iRow++;
                }
            }
        }

        public virtual void ImportSubInventoriesFromXlsx(Stream stream, int userLogin)
        {
            using (var xlPackage = new ExcelPackage(stream))
            {
                // get the first worksheet in the workbook
                var worksheet = xlPackage.Workbook.Worksheets.FirstOrDefault();
                if (worksheet == null)
                    throw new Exception("No worksheet found");

                //the columns
                var properties = GetPropertiesByExcelCells<Inventory>(worksheet);

                var manager = new PropertyManager<Inventory>(properties);

                var iRow = 2;

                while (true)
                {
                    var allColumnsAreEmpty = manager.GetProperties
                        .Select(property => worksheet.Cells[iRow, property.PropertyOrderPosition])
                        .All(cell => cell == null || cell.Value == null || String.IsNullOrEmpty(cell.Value.ToString()));

                    if (allColumnsAreEmpty)
                        break;

                    manager.ReadFromXlsx(worksheet, iRow);

                    var subinventory = BLL.SubInventory.Instance.SelectOne(manager.GetProperty("SubInventoryID").IntValue);

                    var isNew = subinventory == null;

                    subinventory = subinventory ?? new SubInventory();

                    if (isNew)
                    {
                        subinventory.CreatedDate = DateTime.UtcNow;
                        subinventory.CreatedBy = userLogin;
                    }

                    foreach (var property in manager.GetProperties)
                    {
                        switch (property.PropertyName)
                        {
                            case "Name":
                                subinventory.name = property.StringValue;
                                break;
                            case "Description":
                                subinventory.description = property.StringValue;
                                break;
                            case "InventoryID":
                                subinventory.InventoryID = property.IntValue;
                                break;
                            case "IsActive":
                                subinventory.IsActive = property.BooleanValue;
                                break;
                        }
                    }

                    subinventory.ModifiedDate = DateTime.UtcNow;
                    subinventory.ModifiedBy = userLogin;

                    if (isNew)
                        BLL.SubInventory.Instance.Add(subinventory);
                    else
                        BLL.SubInventory.Instance.Update(subinventory);

                    iRow++;
                }
            }
        }

        public virtual void ImportQuestionsFromXlsx(Stream stream, int userLogin)
        {
            using (var xlPackage = new ExcelPackage(stream))
            {
                // get the first worksheet in the workbook
                var worksheet = xlPackage.Workbook.Worksheets.FirstOrDefault();
                if (worksheet == null)
                    throw new Exception("No worksheet found");

                //the columns
                var properties = GetPropertiesByExcelCells<Inventory>(worksheet);

                var manager = new PropertyManager<Inventory>(properties);

                var iRow = 2;

                while (true)
                {
                    var allColumnsAreEmpty = manager.GetProperties
                        .Select(property => worksheet.Cells[iRow, property.PropertyOrderPosition])
                        .All(cell => cell == null || cell.Value == null || String.IsNullOrEmpty(cell.Value.ToString()));

                    if (allColumnsAreEmpty)
                        break;

                    manager.ReadFromXlsx(worksheet, iRow);

                    var question = BLL.Question.Instance.SelectOne(manager.GetProperty("QuestionID").IntValue);

                    var isNew = question == null;

                    question = question ?? new Model.Question();

                    if (isNew)
                    {
                        question.CreatedDate = DateTime.UtcNow;
                        question.CreatedBy = userLogin;
                    }

                    foreach (var property in manager.GetProperties)
                    {
                        switch (property.PropertyName)
                        {
                            case "SubInventoryID":
                                question.SubInventoryID = property.IntValue;
                                break;
                            case "QuestionText":
                                question.QuestionText = property.StringValue;
                                break;
                            case "IsActive":
                                question.IsActive = property.BooleanValue;
                                break;
                        }
                    }

                    question.ModifiedDate = DateTime.UtcNow;
                    question.ModifiedBy = userLogin;

                    if (isNew)
                        BLL.Question.Instance.Add(question);
                    else
                        BLL.Question.Instance.Update(question);

                    iRow++;
                }
            }
        }

        public virtual void ImportQuestionsAnswersFromXlsx(Stream stream, int userLogin)
        {
            using (var xlPackage = new ExcelPackage(stream))
            {
                // get the first worksheet in the workbook
                var worksheet = xlPackage.Workbook.Worksheets.FirstOrDefault();
                if (worksheet == null)
                    throw new Exception("No worksheet found");

                //the columns
                var properties = GetPropertiesByExcelCells<Answer>(worksheet);

                var manager = new PropertyManager<Answer>(properties);

                var iRow = 2;

                var currentQuestionId = 0;

                while (true)
                {
                    var allColumnsAreEmpty = manager.GetProperties
                        .Select(property => worksheet.Cells[iRow, property.PropertyOrderPosition])
                        .All(cell => cell == null || cell.Value == null || String.IsNullOrEmpty(cell.Value.ToString()));

                    if (allColumnsAreEmpty)
                        break;

                    manager.ReadFromXlsx(worksheet, iRow);

                    if (manager.GetProperty("QuestionID").IntValue != currentQuestionId)
                    {
                        currentQuestionId = manager.GetProperty("QuestionID").IntValue;

                        var question = BLL.Question.Instance.SelectOne(manager.GetProperty("QuestionID").IntValue);

                        var isQuestionNew = question == null;

                        question = question ?? new Model.Question();

                        if (isQuestionNew)
                        {
                            question.CreatedDate = DateTime.UtcNow;
                            question.CreatedBy = userLogin;
                        }

                        foreach (var property in manager.GetProperties)
                        {
                            switch (property.PropertyName)
                            {
                                case "QuestionID":
                                    question.QuestionID = property.IntValue;
                                    break;
                                case "SubInventoryID":
                                    question.SubInventoryID = property.IntValue;
                                    break;
                                case "QuestionText":
                                    question.QuestionText = property.StringValue;
                                    break;
                                case "IsQuestionActive":
                                    question.IsActive = property.BooleanValue;
                                    break;
                            }
                        }

                        question.ModifiedDate = DateTime.UtcNow;
                        question.ModifiedBy = userLogin;

                        if (isQuestionNew)
                            BLL.Question.Instance.Add(question);
                        else
                            BLL.Question.Instance.Update(question);
                    }

                    var answer = BLL.Answer.Instance.SelectOne(manager.GetProperty("AnswerID").IntValue);

                    var isAnswerNew = answer == null;

                    answer = answer ?? new Model.Answer();

                    if (isAnswerNew)
                    {
                        answer.CreatedDate = DateTime.UtcNow;
                        answer.CreatedBy = userLogin;
                    }

                    foreach (var property in manager.GetProperties)
                    {
                        switch (property.PropertyName)
                        {
                            case "QuestionID":
                                answer.QuestionID = property.IntValue;
                                break;
                            case "AnswerID":
                                answer.AnswerID = property.IntValue;
                                break;
                            case "AnswerText":
                                answer.AnswerText = property.StringValue;
                                break;
                            case "IsCorrect":
                                answer.IsCorrect = property.BooleanValue;
                                break;
                            case "IsAnswerActive":
                                answer.IsActive = property.BooleanValue;
                                break;
                        }
                    }

                    answer.ModifiedDate = DateTime.UtcNow;
                    answer.ModifiedBy = userLogin;

                    if (isAnswerNew)
                        BLL.Answer.Instance.Add(answer);
                    else
                        BLL.Answer.Instance.Update(answer);

                    iRow++;
                }
            }
        }

        protected virtual IList<PropertyByName<T>> GetPropertiesByExcelCells<T>(ExcelWorksheet worksheet)
        {
            var properties = new List<PropertyByName<T>>();
            var poz = 1;
            while (true)
            {
                try
                {
                    var cell = worksheet.Cells[1, poz];

                    if (cell == null || cell.Value == null || string.IsNullOrEmpty(cell.Value.ToString()))
                        break;

                    poz += 1;
                    properties.Add(new PropertyByName<T>(cell.Value.ToString()));
                }
                catch
                {
                    break;
                }
            }

            return properties;
        }
    }
}
