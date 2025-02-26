using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<KargoTakip_Backend_WebAPI>("kargo-takip-webapi");

builder.Build().Run();
