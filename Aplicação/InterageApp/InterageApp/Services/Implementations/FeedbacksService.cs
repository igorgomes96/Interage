using InterageApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterageApp.DTO;
using InterageApp.Repository.Interfaces;
using InterageApp.Models;

namespace InterageApp.Services.Implementations
{
    public class FeedbacksService : IFeedbacksService
    {
        private readonly IGenericRepository<int, Feedback, FeedbackDto> _feedbackRep;

        public FeedbacksService(IGenericRepository<int, Feedback, FeedbackDto> feedbackRep)
        {
            _feedbackRep = feedbackRep;
        }


        public ICollection<FeedbackDto> List(int codEvento)
        {
            return _feedbackRep.Query(x => x.CodEvento == codEvento);
        }

        public FeedbackDto SaveFeedback(FeedbackDto feedback)
        {
            return _feedbackRep.Save(feedback);
        }
    }
}