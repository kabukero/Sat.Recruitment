﻿using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Services;
using Sat.Recruitment.Domain.Interfaces;
using Sat.Recruitment.Infrastructure.Data.Repositories;
using System;

namespace Sat.Recruitment.IoC
{
	public class DependencyContainer
	{
		public static void RegisterServices(IServiceCollection services)
		{
			//Sat.Recruitment.Application
			services.AddScoped<IUserService, UserService>();

			//Sat.Recruitment.Domain.Interfaces | Sat.Recruitment.Infra.Data.Repositories
			services.AddScoped<IUserRepository, UserRepository>();
		}
	}
}
