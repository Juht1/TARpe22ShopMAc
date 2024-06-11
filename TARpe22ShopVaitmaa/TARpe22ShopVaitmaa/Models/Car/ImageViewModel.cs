namespace TARpe22ShopVaitmaa.Models.Car
{
    public class ImageViewModel
    {
        public Guid ImageId { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string Image { get; set; }
        public Guid? CarId { get; set; }
    }
}
