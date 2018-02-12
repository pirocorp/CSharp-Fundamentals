namespace _08.Commits
{
    using System.Text.RegularExpressions;

    public class Commit
    {
        public Commit(string hashMessage, string message, int additions, int deletions)
        {
            HashMessage = hashMessage;
            Message = message;
            Additions = additions;
            Deletions = deletions;
        }

        public string HashMessage { get; set; }
        public string Message { get; set; }
        public int Additions { get; set; }
        public int Deletions { get; set; }

        public static Commit Parse(string inputData)
        {
            var pattern = @"^(?<hash>[a-fA-F0-9]{40}),(?<message>.+),(?<additions>\d+),(?<deletions>\d+)$";
            var match = Regex.Match(inputData, pattern);
            var hashMessage = match.Groups["hash"].Value;
            var message = match.Groups["message"].Value;
            var additions = int.Parse(match.Groups["additions"].Value);
            var deletions = int.Parse(match.Groups["deletions"].Value);
            var commitObject = new Commit(hashMessage, message, additions, deletions);
            return commitObject;
        }
    }
}
