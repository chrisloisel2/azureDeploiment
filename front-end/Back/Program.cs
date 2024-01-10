var builder = WebApplication.CreateBuilder(args);

// Permet de definir le chemin de base pour les fichiers statiques
builder.Services.AddEndpointsApiExplorer();

// Ajout du service pour la gestion de swagger
builder.Services.AddSwaggerGen();

// Ajout du service pour la gestion des controllers
// Il permet de faire le lien entre les routes et les methodes
builder.Services.AddControllers();

// Definition du CORS pour autoriser les requetes depuis le front
// je lui donne un nom "CorsPolicy" pour l'utiliser dans le app.UseCors("CorsPolicy")
// AllowAnyOrigin() : autorise toutes les origines
builder.Services.AddCors(options =>
{
	options.AddPolicy("CorsPolicy", builder =>
	{
		builder.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader();
	});
});

var app = builder.Build();

// Ajout du CORS
app.UseCors("CorsPolicy");

// Ajout de swagger
app.UseSwagger();

// Ajout de l'interface de swagger
app.UseSwaggerUI();

// Ajout de la gestion des routes
app.MapControllers();

// Ajout de la gestion des fichiers statiques
app.UseHttpsRedirection();

app.Run();
