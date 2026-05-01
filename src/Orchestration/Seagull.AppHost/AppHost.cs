var builder = DistributedApplication.CreateBuilder(args);

// 1 - Postgres
var pgUser = builder.AddParameter("pg-user", "postgres", publishValueAsDefault: true);
var pgPass = builder.AddParameter("pg-password", "Dino2025!", publishValueAsDefault: true);

var postgres = builder
    .AddPostgres("postgres-server", userName: pgUser, password: pgPass, port: 5434)
    .WithContainerName("seagull_postgres")
    .WithImage("postgres", "15-alpine")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithVolume("seagull-postgres-data", "/var/lib/postgresql/data")
    .WithPgAdmin()
    .WithPgWeb();

// required databases
var posDb = postgres.AddDatabase("pos");
var keycloakDb = postgres.AddDatabase("keycloakDb");

// 2 - Keycloak
var keycloack = builder
    .AddContainer("seagull-keycloak-server", "quay.io/keycloak/keycloak", "latest")
    .WithContainerName("seagull_keycloak")
    .WithEndpoint(port: 8080, targetPort: 8080, name: "http", isExternal: true)
    .WithUrl("http://localhost:8080")
    .WithVolume("keycloak-data", "/opt/keycloak/data")
    .WithEnvironment("KEYCLOAK_ADMIN", "admin")
    .WithEnvironment("KEYCLOAK_ADMIN_PASSWORD", "Dino2025!")
    .WithEnvironment("KC_HTTP_ENABLED", "true")
    .WithEnvironment("KC_HOSTNAME", "localhost")
    .WithEnvironment("KC_HOSTNAME_STRICT", "false")
    .WithEnvironment("KC_PROXY", "edge")
    .WithEnvironment("KC_DB", "postgres")
    .WithEnvironment("KC_DB_URL_HOST", postgres.Resource.Name)
    .WithEnvironment("KC_DB_URL_DATABASE", keycloakDb.Resource.Name)
    .WithEnvironment("KC_DB_USERNAME", pgUser)
    .WithEnvironment("KC_DB_PASSWORD", pgPass)
    .WithEnvironment("KC_DB_URL_SCHEMA", "keycloak")
    // .WithEnvironment("KC_HEALTH_ENABLED", "true")
    .WithArgs("start-dev")
    .WaitFor(postgres);

// // 3 - Jaeger
// var jaeger = builder
//     .AddContainer("jaeger", "jaegertracing/all-in-one", "latest")
//     .WithExternalHttpEndpoints();

// 4 - Stand Api
var pos = builder.AddProject<Projects.Pos_Api>("pos-api")
    .WithReference(postgres).WaitFor(postgres)
    .WithExternalHttpEndpoints();

builder.Build().Run();
