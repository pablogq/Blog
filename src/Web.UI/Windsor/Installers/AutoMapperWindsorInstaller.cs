#region Libraries
using AutoMapper;
using Blog.ServiceModel;
using Blog.Web.Model.Infrastructure.Configuration;
using Blog.Web.Model.ViewModels;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace Blog.Web.UI.Windsor.Installers
{
    public class AutoMapperWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Mapper.CreateMap<EntryContract, EntryViewModel>()
                  .ForMember(destination => destination.Content, opt => opt.ResolveUsing(source => ContentTransformator.Current.Transform(source.Content)))
                  .ReverseMap()
                  .ForMember(destination => destination.CreatedAt, conf => conf.Ignore());
            
            Mapper.CreateMap<EntryContract, EntrySummaryViewModel>()
                  .ForMember(destination => destination.CreatedAt, opt => opt.MapFrom(source => source.CreatedAt.ToDateString()))
                  .ForMember(destination => destination.PrettyDate, opt => opt.MapFrom(source => source.CreatedAt.ToPrettyDate()))
                  .ForMember(destination => destination.TruncatedContent, opt => opt.MapFrom(source => ContentTransformator.Current.Transform(source.Content).Truncate(300)));

            Mapper.CreateMap<EntryContract, EditorViewModel>()
                  .ReverseMap();

            Mapper.CreateMap<EntryContract, DeleteViewModel>()
                  .ReverseMap();

            Mapper.CreateMap<ConfigurationContract, BlogConfiguration>();

            Mapper.CreateMap<ConfigurationContract, ConfigurationViewModel>()
                .ForMember(destination => destination.Admins, opt => opt.MapFrom(source => source.Admins.IsNullOrEmpty() ? String.Empty : String.Join(",", source.Admins)))
                  .ReverseMap()
                  .ForMember(destination => destination.Admins, opt => opt.MapFrom(source => source.Admins.IsNullOrEmpty() ? Enumerable.Empty<string>().ToList() : source.Admins.Split(',').ToList()));


        }
    }
}