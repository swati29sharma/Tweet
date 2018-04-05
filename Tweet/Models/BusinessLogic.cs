using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tweet.Models;

namespace Tweets.Models
    {
        public class BusinessLogic
        {
            
            public RootObject getTweet(TweetRequest tweetRequest)
            {
                string baseURL = ConfigurationManager.AppSettings["baseURL"].ToString();
                string endPoint = ConfigurationManager.AppSettings["entryPoint"].ToString();
                string URI = baseURL + endPoint + "?startDate=" + tweetRequest.startDate + "&endDate=" + tweetRequest.endDate;

                List<RootObject> tweetResponselist = new List<RootObject>();
                RootObject tweetResponse = null;
                HttpWebRequest httpWebRequest = null;
                HttpWebResponse httpWebResponse = null;
                try
                {
                   
                    httpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URI);
                    httpWebRequest.Method = "GET";
                    httpWebRequest.ContentType = "text/plain";
                   
                    //Get Response
                    httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                        tweetResponse = JsonConvert.DeserializeObject<RootObject>(result);
                        tweetResponselist.Add(tweetResponse);
                        checkForData(tweetResponselist.Count(),tweetRequest, tweetResponselist);
                    }
                } 
                catch (HttpException httpException) { }
                catch (Exception exception) { }
                return tweetResponse;


            }
            public void checkForData(int count, TweetRequest request, List<RootObject> getTweetList)
            {
            if(count.Equals(100))
            {
                TweetRequest tweetRequest = new TweetRequest();
                if(getTweetList.Last().stamp< DateTime.Parse(request.endDate))
                {
                    tweetRequest.startDate =getTweetList.Last().stamp.ToString();
                    tweetRequest.endDate = request.endDate;
                    getTweet(tweetRequest);
                }
                    
             }
                
            }
        }


    }
