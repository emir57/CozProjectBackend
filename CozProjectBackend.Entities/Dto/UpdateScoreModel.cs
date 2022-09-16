namespace CozProject.Entities.Dto
{
    public class UpdateScoreModel
    {
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public bool Result { get; set; }
        public int Score { get; set; }
    }
}
