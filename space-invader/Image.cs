using System.Collections.Generic;

namespace space_invader
{
    internal sealed class Image
    {
        public List<string> ImageContent { get; internal set; }

        public Image(List<string> content)
        {
            ImageContent = new List<string>();
            ImageContent.AddRange(content);
        }
    }
}
