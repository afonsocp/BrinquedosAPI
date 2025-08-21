namespace BrinquedosAPI.Models
{
    public abstract class ResourceBase
    {
        public List<Link> Links { get; set; } = new List<Link>();

        public void AddLink(string href, string rel, string method)
        {
            Links.Add(new Link(href, rel, method));
        }
    }
}