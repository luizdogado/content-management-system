using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlContent.ContentPages.Dtos.Input;

public class PagedContentPageInputDto
{
    public string Sorting { get; set; } = "id";
    public int SkipCount { get; set; } = 0;
    public int MaxResult { get; set; }
}
