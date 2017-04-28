using AutoMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using AutoMapper;
using Data.Entities;
using Common.DTOs;
using Common.DTOs.Alexa;

namespace Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(config => {
                //foreach(var assembly in AppDomain.CurrentDomain.GetAssemblies())
                //    {
                //        assembly.MapTypes(config);
                //    }
                config.CreateMap<AlexaAccount, AlexaAccountDTO>().ReverseMap();
                config.CreateMap<AlexaRequest, AlexaRequestDTO>().ReverseMap();

                config.CreateMap<Player, PlayerDTO>().ReverseMap();
                config.CreateMap<Inventory, InventoryDTO>().ReverseMap();
                config.CreateMap<Map, MapDTO>().ReverseMap();
                config.CreateMap<Cell, CellDTO>().ReverseMap();
                config.CreateMap<CellItem, CellItemDTO>().ReverseMap();
                config.CreateMap<Item, ItemDTO>().ReverseMap();
                
                config.CreateMap<Config, ConfigDTO>().ReverseMap();

                config.CreateMap<InventoryDTO, CellItemDTO>().ReverseMap();
            });

        }
    }
}