using Projects;

var builder = DistributedApplication.CreateBuilder(args);

#pragma warning disable ASPIRECERTIFICATES001
var keycloak = builder.AddKeycloak("keycloak", 6001)
    .WithoutHttpsCertificate()
#pragma warning restore ASPIRECERTIFICATES001
    .WithDataVolume("keyclock-data"); // To persist keycloak data outside docker container

var questionService = builder.AddProject<QuestionService>("question-svc")
    .WithReference(keycloak)
    .WaitFor(keycloak);

builder.Build().Run();