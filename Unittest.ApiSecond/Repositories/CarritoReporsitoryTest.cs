using Microsoft.EntityFrameworkCore;
using Repository.ApiSecond.EF;
using Domain.ApiSecond;
using Repository.ApiSecond.Data;

namespace Unittest.ApiSecond.Repositories
{
    public class CarritoReporsitoryTest
    {
        private readonly CarritoDbContext _carritoDbContext;

        public CarritoReporsitoryTest()
        {
            var contectInMemory = new DbContextOptionsBuilder<CarritoDbContext>()
                .UseInMemoryDatabase(databaseName: "CarritoTestDb")
                .Options;

            var context = new CarritoDbContext(contectInMemory);

            //Inicializamos la base de datos en memoria con algunos datos de prueba
            context.Carrito.Add(new Carrito { Id = 1, IdCliente = 1 });
            context.Carrito.Add(new Carrito { Id = 2, IdCliente = 2 });

            context.SaveChanges();
        }

        [Fact]
        public void GetAll_ShouldReturnList()
        {
            var repository = new CarritoRepository(_carritoDbContext);

            var result = repository.GetAll();

            //assert
            Assert.NotNull(result);
            Assert.True(result.Any());
        }

        [Fact]
        public void Insert_EF_ShouldInsertCarrito()
        {
            var repository = new CarritoRepository(_carritoDbContext);

            var carrito = new Carrito { IdCliente = 1, Fecha = DateTime.Now };

            int resultId = repository.InsertEF(carrito);
            
            //assert
            Assert.True(resultId > 0);

            var carrito2 = new Carrito { IdCliente = 2, Fecha = DateTime.Now };

            resultId = repository.InsertEF(carrito2);

            //assert
            Assert.True(resultId > 1);
        }
    }
}
