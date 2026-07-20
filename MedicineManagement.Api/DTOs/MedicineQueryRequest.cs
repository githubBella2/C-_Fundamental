public class MedicineQueryRequest
{
    public int Page {get; set;}
    public int PageSize {get; set;}
    public string? Sort {get;set;}
    public decimal? MinPrice{get;set;}
    public decimal? MaxPrice{get;set;}
    public string? Name{get;set;}
}