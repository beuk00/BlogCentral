using System.Web.Mvc;

namespace BlogCentralApp.Models
{
    public class TinyTest
    {

            // This attributes allows your HTML Content to be sent up  
            [AllowHtml]
            public string HtmlContent { get; set; }

            public TinyTest()
            {

            }

    }
}
