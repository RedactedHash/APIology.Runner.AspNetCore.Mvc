namespace APIology.Runner.AspNetCore.Mvc
{
	using System.Diagnostics.CodeAnalysis;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.DependencyInjection;

	[SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
	public abstract class ServiceBase<TAPIBase, TConfiguration> : AspNetCore.ServiceBase<TAPIBase, TConfiguration>
		where TAPIBase : ServiceBase<TAPIBase, TConfiguration>
		where TConfiguration : Configuration, new()
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
