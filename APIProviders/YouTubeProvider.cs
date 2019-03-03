using System;
using System.Collections.Generic;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;
using NowMineCommon.Models;
using System.Threading.Tasks;

namespace NowMine.APIProviders
{

    public class YouTubeProvider : IAPIProvider
    {
        private const string SEARCH = "http://gdata.youtube.com/feeds/api/videos?q={0}&alt=rss&&max-results=20&v=1";
        YouTubeService youtubeService = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = "AIzaSyC5zI6qk0KkTtePHp5yh23fcPgSLnio2V4",
            ApplicationName = "Play Mine!"
        });

        /// <summary>
        /// Returns a List<see cref="ClipInfo">YouTubeInfo</see> which represent
        /// the YouTube videos that matched the keyWord input parameter
        /// </summary>
        public async Task<List<ClipInfo>> GetSearchClipInfos(string keyWord)
        {
            var SearchRequest = youtubeService.Search.List("snippet");
            SearchRequest.Q = keyWord; // Replace with your search term.
            SearchRequest.MaxResults = 20;
            Google.Apis.YouTube.v3.Data.SearchListResponse SearchList = null;
            try
            {
                SearchList = await SearchRequest.ExecuteAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine(string.Format("Error in GetSearchClipInfos {0}", e.Message));
                return new List<ClipInfo>();
            }

            List<ClipInfo> resultInfo = new List<ClipInfo>();

            foreach (var SearchItem in SearchList.Items)
            {
                ClipInfo result = new ClipInfo();
                switch (SearchItem.Id.Kind)
                {
                    case "youtube#video":
                        result.Title = SearchItem.Snippet.Title;
                        result.ChannelName = SearchItem.Snippet.ChannelTitle;
                        result.ID = SearchItem.Id.VideoId;
                        result.Thumbnail = new Uri(SearchItem.Snippet.Thumbnails.Default__.Url);
                        resultInfo.Add(result);
                        break;

                    case "youtube#channel":
                        break;

                    case "youtube#playlist":
                        break;
                }
            }
            return resultInfo;
        }
    }
}
