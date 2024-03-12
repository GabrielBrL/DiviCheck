using Blazored.LocalStorage;
using CTRLInvesting.Client.Interfaces;
using CTRLInvesting.Client.Services;
using CTRLInvesting.Client.Providers;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using CTRLInvesting.Client.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IAcoesService, AcoesService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IInvestimentosService, InvestimentosService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddScoped<CustomHttpHandler>();

builder.Services.AddScoped<FluentValidationRegisterUsuario>();

builder.Services.AddScoped(opt => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration["ApiURI"])
});

builder.Services.AddAuthenticationCore();

builder.Services.AddBlazorBootstrap();

builder.Services.AddLocalization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRequestLocalization("pt-BR");
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
