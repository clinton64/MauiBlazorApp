using Microsoft.AspNetCore.Components.WebView.Maui;
using MauiBlazorApp.Data;
using MauiBlazorApp.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace MauiBlazorApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
		builder.Services.AddAuthorizationCore();
		builder.Services.AddScoped<CustomAuthenticationStateProvider>();
		builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomAuthenticationStateProvider>());
		builder.Services.AddScoped<FRCM_API_Service>();
		builder.Services.AddSingleton<DatabaseLocal>();
		builder.Services.AddScoped<DataService>();
		return builder.Build();
	}
}
