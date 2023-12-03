using liteOppdrag.Services;
using Polly;

var builder = WebApplication.CreateBuilder(args);

// To get the base url from ApiSettings
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Polly retry policy
var retryPolicy = Policy
    .Handle<HttpRequestException>()
    .WaitAndRetryAsync(new[]
    {
        TimeSpan.FromSeconds(1),
        TimeSpan.FromSeconds(5),
        TimeSpan.FromSeconds(10)
    });


// Add Services.
builder.Services.AddControllers();

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register services
builder.Services.AddScoped<IVaApiHttpClientService, VaApiHttpClientService>();
builder.Services.AddScoped<IDimensjonService, DimensjonService>();
builder.Services.AddSingleton<IAsyncPolicy>(retryPolicy);


// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();