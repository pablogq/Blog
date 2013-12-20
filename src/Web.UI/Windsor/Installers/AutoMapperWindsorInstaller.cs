#region Libraries
using AutoMapper;
using Blog.ServiceModel;
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
                  .ReverseMap();
            Mapper.CreateMap<EntryContract, EntrySummaryViewModel>()
                  .ForMember(destination => destination.CreatedAt, opt => opt.MapFrom(source => source.CreatedAt.ToDateString()))
                  .ForMember(destination => destination.PrettyDate, opt => opt.MapFrom(source => source.CreatedAt.ToPrettyDate()));

        }
    }
}