using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tweet.Models;
using Tweets.Models;

namespace Tweet.Controllers
{
    public class TweetController : Controller
    {
        // GET: Tweet
        public ActionResult Index()
        {
            TweetRequest tweetRequest = new TweetRequest();
            tweetRequest.startDate = "2016-03-20"; //testing purpose
            tweetRequest.endDate = "2017-03-20"; //testing purpose
            BusinessLogic businessLogic = new BusinessLogic();
            RootObject tweetResponse = businessLogic.getTweet(tweetRequest);
            return View();
        }
    }
}