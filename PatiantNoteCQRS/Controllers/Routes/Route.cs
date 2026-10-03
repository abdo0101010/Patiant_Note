namespace PatiantNoteCQRS.Controllers.Routes
{
    public class Route
    {
        public class UserRoutes
        {
            public const string baseurl = "/User";
            public const string create = baseurl + "/create";
            public const string update = baseurl + "/update";
            public const string deleteby = baseurl + "/delete"+"/{UserId}";


        }
    }
}
