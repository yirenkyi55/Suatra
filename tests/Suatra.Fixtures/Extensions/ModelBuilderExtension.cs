using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;

namespace Suatra.Fixtures.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder Seed<T>(this ModelBuilder builder, string file) where T : class
        {
            using (var reader = new StreamReader(file))
            {
                var json = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<T[]>(json);

                builder.Entity<T>().HasData(data);

            }

            return builder;
        }
    }
}
