using AutoMapper;
using CarDealer.DTO.ImportDtos;
using CarDealer.Models;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDto, Supplier>();
            this.CreateMap<ImportPartDto, Part>();
            this.CreateMap<ImportCarDto, Car>()
                .ForMember(dest => dest.PartCars, opt => opt.MapFrom(src => src.PartsId.Distinct()
                .Select(partId => new PartCar
                {
                    PartId = partId
                })));
            this.CreateMap<ImportCustomerDto, Customer>();
            this.CreateMap<ImportSaleDto, Sale>();
        }
    }
}
