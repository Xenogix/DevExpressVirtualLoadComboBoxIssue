using LoadComboboxFilterIssue.Services;

namespace LoadComboboxFilterIssue.Client;

public class CommonServices {
    public static void Configure(IServiceCollection services, IConfiguration configuration) {
        services.AddDevExpressBlazor(options => {
            options.SizeMode = DevExpress.Blazor.SizeMode.Medium;
        });
        services.AddScoped<DxThemesService>();
    }
}