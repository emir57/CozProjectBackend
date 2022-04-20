using System;
using System.Collections.Generic;
using System.Text;

namespace CozProjectBackend.Entities.Dto
{
    public class UpdateScoreModel
    {
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public bool Result { get; set; }
        public int Score { get; set; }
    }
}
