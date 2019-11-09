﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dexture.Models;
using Dexture.Models.DataManager;
using Dexture.Models.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Dexture
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = Configuration["Jwt:Issuer"],
            ValidAudience = Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
        };
    });

            services.AddDbContext<Context>(opts => opts.UseSqlServer(Configuration["ConnectionString:DextureDB"]));
            services.AddScoped<IDataRepository<Farmer>, FarmerManager>();
            services.AddScoped<IDataRepository<Admin>, AdminManager>();
            services.AddScoped<IDataRepository<Land>, LandManager>();
            services.AddScoped<IDataRepository<Harvest>, HarvestManager>();
            services.AddScoped<IDataRepository<FutureCultivation>, FutureCultivationManager>();
            services.AddScoped<IDataRepository<Prediction>, PredictionManager>();
            services.AddScoped<IDataRepository<Land_Harvest>, Land_Harvest_Manager>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
