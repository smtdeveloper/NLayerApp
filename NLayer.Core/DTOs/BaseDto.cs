namespace NLayer.Core.DTOs
{
    public class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDelete { get; set; }

    }
}
