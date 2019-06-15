using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Data.Repos.Posts
{
    public interface IPostsRepository
    {
        long GetCollectionSize();
        Dictionary<string, int> GetPostsContentLength(List<string> postsIDs);
    }
}
