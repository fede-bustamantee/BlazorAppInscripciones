using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorAppVS;
using BlazorAppVS.Services;
using CurrieTechnologies.Razor.SweetAlert2;
using BlazorAppVS.Interfaces;
using BlazorAppVS.Interfaces.Commons;
using BlazorAppVS.Interfaces.MesasExamenes;
using BlazorAppVS.Services.Commons;
using BlazorAppVS.Services.Horarios;
using BlazorAppVS;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Logging.SetMinimumLevel(LogLevel.Debug);
var urlApi = builder.Configuration.GetValue<string>("urlApi");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(urlApi) });
builder.Services.AddScoped<IAlumnoService, AlumnoService>();
builder.Services.AddScoped<ICarreraService, CarreraService>();
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IAnioCarreraService, AnioCarreraService>();
builder.Services.AddScoped<IMateriaService, MateriaService>();
builder.Services.AddScoped<IDetalleInscripcionService, DetalleInscripcionService>();
builder.Services.AddScoped<IMesaExamenService, MesaExamenService>();
builder.Services.AddScoped<IHorarioService, HorarioService>();
builder.Services.AddScoped<IDetalleHorarioService, DetalleHorarioService>();

builder.Services.AddSweetAlert2();
await builder.Build().RunAsync();