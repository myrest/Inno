namespace InnoThink.Domain.Board
{
    #region interface

    public interface IBoard_Info
    {
        string Content { get; set; }

        string DateCreated { get; set; }

        string PublishType { get; set; }

        int TopicSN { get; set; }

        string UserSN { get; set; }
    }

    #endregion interface

    #region Implementation

    [Rest.Core.PetaPoco.TableName("Board")]
    [Rest.Core.PetaPoco.PrimaryKey("")]
    public class Board_Info : IBoard_Info
    {
        #region private fields

        public string Content { get; set; }

        public string DateCreated { get; set; }

        public string PublishType { get; set; }

        public int TopicSN { get; set; }

        public string UserSN { get; set; }

        #endregion private fields

        #region Constructor

        public Board_Info()
        {
        }

        #endregion Constructor
    }

    public class Board_Filter
    {
        //You can copy above Board_Info field for search criteria
    }

    #endregion Implementation
}