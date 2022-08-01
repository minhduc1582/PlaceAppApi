using AutoMapper;
using PlaceApp.Places;

namespace PlaceApp;

public class PlaceAppApplicationAutoMapperProfile : Profile
{
    public PlaceAppApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<PlaceType, PlaceTypeDto>();
        CreateMap<PlaceTypeRequestDto, PlaceType>();
        CreateMap<PlaceType, PlaceTypeReponseDto>();

        CreateMap<Place, PlaceDto>();
        CreateMap<PlaceRequestReponseDto, Place>();
        CreateMap<Place, PlaceRequestReponseDto>();
        
    }
}
