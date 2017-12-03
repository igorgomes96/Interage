using InterageApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterageApp.Services.Interfaces
{
    public interface IFeedbacksService
    {
        ICollection<FeedbackDto> List(int codEvento);
        FeedbackDto SaveFeedback(FeedbackDto feedback);
    }
}
