using Microsoft.AspNetCore.Mvc;
using MyBlogProject.Models;

namespace MyBlogProject.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    ID = 1,
                    Username = "Test",
                },
                new UserComment
                {
                    ID = 2,
                    Username = "deneme"
                },
                new UserComment
                {
                    ID = 3,
                    Username = "deneme2"
                }
            };
            return View(commentValues);
        }
    }
}
