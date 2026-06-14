namespace Notion.Client
{
    public class MovePageBodyParameters : IMovePageBodyParameters
    {
        public MovePageParent Parent { get; set; }

        public static MovePageBodyParameters FromRequest(IMovePageBodyParameters request)
        {
            return new MovePageBodyParameters
            {
                Parent = request.Parent
            };
        }
    }
}
