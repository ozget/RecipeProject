using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RecipeProjectDal.Abstract;
using RecipeProjectDal.Concreate.EntityFramework;
using RecipeProjectEntity;
using RecipeProjectEntity.Concreate;

namespace RecipeProjectWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var connectionString = Configuration["connectionString:DBConnectionString"];
            services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(connectionString));

            
            services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            services.AddScoped<IAmountRepository, EfAmountRepository>();
            services.AddScoped<IIngredientRepository, EfIngredientRepository>();
            services.AddScoped<IRecipeRepository, EfRecipeRepository>();


            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            
           
        }
    }
}
