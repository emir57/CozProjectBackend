using Core.Dtos.Abstract;

namespace CozProject.Dto.Concrete;

public sealed class CategoryWriteDto : IWriteDto
{
    public string Name { get; set; }
    public string BackgroundColor { get; set; }
    public string TextColor { get; set; }
    public bool IsComplete { get; set; }
}
