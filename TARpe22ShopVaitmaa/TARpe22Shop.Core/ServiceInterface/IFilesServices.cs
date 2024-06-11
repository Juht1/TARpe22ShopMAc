using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe22ShopVaitmaa.Core.Domain;
using TARpe22ShopVaitmaa.Core.Dto;

namespace TARpe22ShopVaitmaa.Core.ServiceInterface
{
    public interface IFilesServices
    {
        void UploadFilesToDatabase(SpaceshipDto dto, Spaceship domain);
        void UploadFilesToDatabase(CarDto dto, Car domain);

        Task<FileToDatabase> RemoveImage(FileToDatabaseDto dto);
        Task<List<FileToDatabase>> RemoveImagesFromDatabase(FileToDatabaseDto[] dtos);
        void FilesToApi(RealEstateDto dto, RealEstate realEstate);
        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos);
        Task<FileToApi> RemoveImageFromApi(FileToApiDto dto);
    }
}
