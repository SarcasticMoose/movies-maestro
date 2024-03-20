using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesMaestro.Models
{
    public class NavigationViewItemTemplate
    {
        public NavigationViewItemTemplate(string content, string iconSource, string tag)
        {
            Content = content;
            IconSource = iconSource;
            Tag = tag;
        }

        public string? Content { get; }
        public string? IconSource { get; }
        public string? Tag { get; }
    }
}
