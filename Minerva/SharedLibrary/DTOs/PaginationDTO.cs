namespace SharedLibrary.DTOs
{
    public class PaginationDTO
    {
        public int Page { get; set; } = 1;

        public int Records { get; set; } = 10;

        public string Total { get; set; } = string.Empty;

        public string? Filter { get; set; }
    }
}
