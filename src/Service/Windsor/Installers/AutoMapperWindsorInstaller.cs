#region Libraries
using AutoMapper;
using Blog.Domain.Model;
using Blog.ServiceModel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
#endregion

namespace Blog.Service.Windsor.Installers
{
    public class AutoMapperWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Mapper.CreateMap<EntryContract, Entry>()
                  .ConstructUsing((EntryContract contract) => new Entry(contract.Slug, contract.Title, contract.Markdown, contract.Author))
                  .ReverseMap();
        }
    }
}