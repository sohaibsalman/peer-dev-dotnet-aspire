var builder = DistributedApplication.CreateBuilder(args);

var keyclock = builder.AddKeycloak("keyclock", 6001)
    .WithDataVolume("keyclock-data"); // To persist keyclock data outside docker container

builder.Build().Run();