using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            throw new Exception("This is demo exception");
            //_logger.LogInformation("Requested the get method of index page.");
            //try
            //{
            //    for (int i = 0;i < 100; i++)
            //    {
            //        if(i == 50)
            //        {
            //            throw new Exception("This is demo exception");
            //        }
            //        else
            //        {
            //            _logger.LogInformation($"The value of i is {i}.");
            //        }
            //    }
            //}
            //catch(Exception ex){
            //    _logger.LogError(ex, "Exception caught in index get method.");
            //}
        }
    }
}