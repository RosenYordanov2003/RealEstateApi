namespace RealEstate.Core.Models.Property
{
    public class FilterPropertyModel
    {
        public int? CityId { get; set; } 
        public decimal? MaxPrice { get; set; }
        public int? PropertyCategoryId { get; set; }
        public int? SaleCategoryId { get; set; }
        public decimal? MinSquareMeters { get; set; }
        public decimal? MaxSquareMeters { get; set; }
        public int? BedRoomsCount { get; set; }
        public int? BathRoomsCount { get; set; }
    }
}
