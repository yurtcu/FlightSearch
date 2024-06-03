namespace FlightSearchAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowCORS",
                    builder =>
                    {
                        builder.WithOrigins("*")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowCORS");


            app.MapControllers();

            app.Run();
        }
    }
}
