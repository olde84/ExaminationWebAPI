using AutoMapper;
using StoreWebAPI_Assignment.Models.Category;
using StoreWebAPI_Assignment.Models.Order;
using StoreWebAPI_Assignment.Models.Product;
using StoreWebAPI_Assignment.Models.User;

namespace StoreWebAPI_Assignment.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
            CreateMap<UserRequest, UserEntity>();

            CreateMap<ProductEntity, ProductModel>().ReverseMap();
            CreateMap<ProductRequest, ProductEntity>();

            CreateMap<CategoryEntity, CategoryModel>().ReverseMap();
            CreateMap<CategoryRequest, CategoryEntity>();

            CreateMap<OrderEntity, Order>().ReverseMap();
        }
    }
}
