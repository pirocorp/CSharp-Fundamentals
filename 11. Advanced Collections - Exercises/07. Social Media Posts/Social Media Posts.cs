using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Social_Media_Posts
{
    class Program
    {
        static void Main()
        {
            //Dictionary <post, comment>, [like, dislike]>
            var posts = new Dictionary<string, int[]>();
            var comments = new Dictionary<string, Dictionary<string, List<string>>>();
            var inputData = Console.ReadLine();

            while (inputData != "drop the media")
            {
                var tokens = inputData.Split(' ').ToList();
                var command = tokens[0];
                var key = tokens[1];

                switch (command)
                {
                    case "post":
                        posts[key] = new int[2];
                        break;
                    case "like":
                        posts[key][0]++;
                        break;
                    case "dislike":
                        posts[key][1]++;
                        break;
                    case "comment":
                        var name = tokens[2];
                        tokens.RemoveRange(0, 3);
                        var comment = String.Join(" ", tokens);

                        if (!comments.ContainsKey(key))
                        {
                            comments[key] = new Dictionary<string, List<string>>();
                        }

                        if (!comments[key].ContainsKey(name))
                        {
                            comments[key][name] = new List<string>();
                        }

                        comments[key][name].Add(comment);
                        break;

                }

                inputData = Console.ReadLine();
            }

            foreach (var post in posts)
            {
                var postName = post.Key;
                var likes = post.Value[0];
                var dislike = post.Value[1];
                Console.WriteLine($"Post: {postName} | Likes: {likes} | Dislikes: {dislike}");
                Console.WriteLine($"Comments:");

                if (comments.ContainsKey(postName))
                {
                    var commentEntries = comments[postName];

                    foreach (var user in commentEntries)
                    {
                        var userName = user.Key;
                        var userComments = user.Value;
                        Console.WriteLine($"*  {userName}: {String.Join(" ", userComments)}");
                    }
                }
                else
                {
                    Console.WriteLine("None");
                }

            }
        }
    }
}
