using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var cacheConfigSection = config.GetSection("CacheConfiguration");
var cacheChild = config.GetSection("CacheConfiguration").GetChildren().ToDictionary(x => x.Key, v => v.Value);
var cacheChildget = config.GetSection("CacheConfiguration").Get<CacheConfig>();

var cacheConfig = config.GetSection("CacheConfiguration");
var cacheConfigChild = config.GetSection("CacheConfiguration").GetSection("CacheUseCase");
var cacheName = cacheConfigChild.GetSection("0").Value;
var cacheName1 = cacheConfigChild.GetSection("0:Name").Value;

Console.WriteLine("Done!");

public class CacheConfig {
  public List<CacheUseConfig> CacheUseCase { get; set; }
}

public class CacheUseConfig {
    public string Name { get; set; }
}