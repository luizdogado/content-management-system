using System.ComponentModel.DataAnnotations;

namespace HtmlContent.ContentPages.Dtos.Input;

public class InsertOrUpdateContentInputDto
{
    public int? Id { get; set; }
    [Required]
    [MaxLength(128)]
    public string Name { get; set; }
    [MaxLength(2147483647)]
    public string Content { get; set; }
}
