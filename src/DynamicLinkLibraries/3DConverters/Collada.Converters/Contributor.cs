using System.Xml;

namespace Collada.Converters
{
    public class Contributor
    {
        public string Author { get; private set; }

        public string AuthoringTool { get; private set; }

        public string Comments { get; private set; }
        public string Copyright { get; private set; }

        public Contributor(string author, string authoringTool, string comments, string copyright)
        {
            Author = author;
            AuthoringTool = authoringTool;
            Comments = comments;
            Copyright = copyright;
        }

        public void Set(XmlDocument doc)
        {
            var e = doc.GetElementsByTagName("contributor")[0];
            foreach (var c in e.ChildNodes)
            {
                if (c is XmlElement child)
                {
                    switch (child.Name)
                    {
                        case "author":
                            child.InnerText = Author;
                            break;
                        case "authoring_tool":
                            child.InnerText = AuthoringTool;
                            break;
                        case "comments":
                            child.InnerText = Comments;
                            break;
                        case "copyright":
                            child.InnerText = Copyright;
                            break;
                     }
                }
            }
        }
    }
}