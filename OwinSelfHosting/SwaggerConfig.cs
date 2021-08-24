using Swashbuckle.Application;
using System;
using System.Web.Http;

namespace OwinSelfHosting
{
    internal class SwaggerConfig
    {
        internal static void Configure(HttpConfiguration config)
        {
            //config.EnableSwagger(c => { c.SingleApiVersion("v1", "nameofAPi"); }).EnableSwaggerUi(c => { });
            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("1.0", "Demo API")
                .Description("API hosted as Owin project and Swagger Enabled")
                .License(license =>
                {
                    license.Name("(c) vishwas All rights reserved").Url("");
                }).Contact(contact =>
                {
                    contact.Name("Vishwas").Url("https://vishwas")
                    .Email("vishwas.sl@hotmail.com");
                });

                c.DescribeAllEnumsAsStrings(true);
                //c.IncludeXmlComments("");
                //c.CleanUnusedDefinitions()
            }).EnableSwaggerUi(c =>
            {
                c.DisableValidator();
            });
        }
    }
}