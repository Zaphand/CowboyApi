using CowboyApi.Contracts;
using CowboyClientLib.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CowboyClientLib.Classes
{
	public static class DependencyManager
	{
		public static IServiceCollection AddCowboy(this IServiceCollection serviceProvider)
		{
			
			serviceProvider.AddScoped<ICowboyRepository, CowboyRepositoryService>();


			return serviceProvider;
		}
	}
}
