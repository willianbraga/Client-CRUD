# Client-CRUD

Caso queira, pode ser mudado no Startup.cs:

            //services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(_configuration.GetConnectionString("connectionString")));

a mudança entre InMemory ou DB.

Esta sendo utilizado as portas:

localhost:4200 -> Angular
localhost:5000 -> Api