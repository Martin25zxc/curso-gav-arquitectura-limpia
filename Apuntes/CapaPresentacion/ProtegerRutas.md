En ves de poner el decorator authorize podemos ir a program y poenr 

AuthorizeFilter("");


builder.Services.AddControllers(opciones =>
{
    opciones.Filters.Add(new AuthorizeFilter("esadmin"));
});
