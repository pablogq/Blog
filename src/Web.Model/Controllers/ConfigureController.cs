#region Libraries
using Blog.ServiceModel;
using Blog.Web.Model.Infrastructure;
using Blog.Web.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
#endregion

namespace Blog.Web.Model.Controllers
{
    public class ConfigureController : LayoutController
    {
        private readonly IClientFactory<IConfigurationClient> configurationService;

        public ConfigureController(IApplicationServices applicationServices, IClientFactory<IConfigurationClient> configurationService)
            : base(applicationServices)
        {
            Guard.IsNotNull(configurationService, "configurationService");

            this.configurationService = configurationService;
        }

        [HttpGet, AdminOnly]
        public ActionResult Edit()
        {
            ConfigurationContract configuration = this.configurationService.Get(client => client.Get());

            ConfigurationViewModel model = this.Services.Mapper.Map<ConfigurationViewModel, ConfigurationContract>(configuration);
            return this.View(model);
        }

        [HttpPost, AdminOnly, ValidateAntiForgeryToken]
        public ActionResult Edit(ConfigurationViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            ConfigurationContract configuration = this.Services.Mapper.Map<ConfigurationContract, ConfigurationViewModel>(model);
            Response response = this.configurationService.Get(client => client.Save(configuration));
            if (!response.Success)
            {
                this.ModelState.AddModelError("Error", "Hubo un problema guardando la configuración.");
                return this.View(model);
            }


            return this.RedirectToAction("Index", "Home");
        }
    }
}
