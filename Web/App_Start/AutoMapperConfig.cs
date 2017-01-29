using AutoMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(config => {
            foreach(var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    assembly.MapTypes(config);
                }
            });
        }
    }
}