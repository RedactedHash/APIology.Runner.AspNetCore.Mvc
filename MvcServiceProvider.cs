namespace APIology.ServiceProvider
{
	using Configuration;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.DependencyInjection;
	using System.Diagnostics.CodeAnalysis;

	[SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
	public abstract class MvcServiceProvider<TAPIBase, TConfiguration> : AspNetCoreServiceProvider<TAPIBase, TConfiguration>
		where TAPIBase : AspNetCoreServiceProvider<TAPIBase, TConfiguration>
		where TConfiguration : AspNetCoreConfiguration, new()
	{
		public override void ConfigureAspNetCore(IServiceCollection services)
		{
			services.AddMvc();
		}

		public override void BuildAspNetCoreApp(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseBrowserLink();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}

			app.UseStaticFiles();
		}
	}
}
