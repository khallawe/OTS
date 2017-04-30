using OTS.Model;
using OTS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTS.Models
{
    public class QuestionModel
    {
        public QuestionModel()
        {
            AvailableAnswers = new List<Answer>();
            AvailableInventories = new List<SelectListItem>();
            AvailableSubInventories = new List<SelectListItem>();
        }
        public int Id { get; set; }
        public string Question { get; set; }
        public int NumberOfAnswers { get; set; }
        public int SubInventoryId { get; set; }
        public string SubInventoryName { get; set; }
        public int InventoryId { get; set; }
        public string InventoryName { get; set; }

        public List<Answer> AvailableAnswers { get; set; }

        public List<SelectListItem> AvailableInventories { get; set; }
        public List<SelectListItem> AvailableSubInventories { get; set; }
    }

    public class AnswerModel
    {
        public int AnswerID { get; set; }
        public string answer { get; set; }
        public int QuestionID { get; set; }
        public bool isCorrect { get; set; }
    }
}