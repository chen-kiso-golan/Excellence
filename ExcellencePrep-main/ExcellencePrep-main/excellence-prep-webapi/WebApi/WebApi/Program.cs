var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the service provider
var provider = builder.Services.BuildServiceProvider();

// Get the configuration service from the provider
var configuration = provider.GetRequiredService<IConfiguration>();

// Add CORS policy
builder.Services.AddCors(options => {

    var Frontend_url = configuration.GetValue<string>("Frontend_url");

    options.AddDefaultPolicy(builder =>
    {
        //builder.WithOrigins(Frontend_url).AllowAnyMethod().AllowAnyHeader();
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });

});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

//app.MapControllers();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();











