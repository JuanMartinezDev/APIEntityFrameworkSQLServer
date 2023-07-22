using Microsoft.EntityFrameworkCore;
using projectef.Models;
namespace projectef;

public class TareasContext: DbContext
{
	public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }
    public TareasContext(DbContextOptions<TareasContext> options) :base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriaInit = new List<Categoria>();
        categoriaInit.Add(new Categoria() {CategoriaId = Guid.Parse("0f3f7d9e-7c2a-4460-8149-aeac90e73f74"), Nombre = "Actividades pendientes", Peso = 20 });
        categoriaInit.Add(new Categoria() {CategoriaId = Guid.Parse("0f3f7d9e-7c2a-4460-8149-aeac90e73f02"), Nombre = "Actividades personales", Peso = 50 });
        
        modelBuilder.Entity<Categoria>(categoria=>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p=> p.CategoriaId);

            categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=> p.Description).IsRequired(false);
            categoria.Property(p=> p.Peso);
            categoria.HasData(categoriaInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea() {TareaId = Guid.Parse("0f3f7d9e-7c2a-4460-8149-aeac90e73f10"), CategoriaId = Guid.Parse("0f3f7d9e-7c2a-4460-8149-aeac90e73f74"), PrioridadTarea = Prioridad.Media, Titulo = "Pago de servicios publicos", FechaCreacion = DateTime.Now });
        tareasInit.Add(new Tarea() {TareaId = Guid.Parse("0f3f7d9e-7c2a-4460-8149-aeac90e73f11"), CategoriaId = Guid.Parse("0f3f7d9e-7c2a-4460-8149-aeac90e73f02"), PrioridadTarea = Prioridad.Baja, Titulo = "Terminar de ver peliculas Netflix", FechaCreacion = DateTime.Now });

        modelBuilder.Entity<Tarea>(tarea=>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p=> p.TareaId);

            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaId);
            tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p=> p.Descripcion).IsRequired(false);
            tarea.Property(p=> p.PrioridadTarea);
            tarea.Property(p=> p.FechaCreacion);
            tarea.Ignore(p=> p.Resumen);
            tarea.HasData(tareasInit);

        });
    }
}
