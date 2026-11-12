using Bussines.ApiSecond.Bussines;
using Domain.ApiSecond;
using Domain.ApiSecond.Dto;
using Moq;
using Repository.ApiSecond.Intefaces;

namespace Unittest.ApiSecond.Bussines
{
    public class CarritoBussinesTest
    {
        [Fact]
        public void GetAll_ShouldReturnListOfCarritos()
        {
            // Arrange
            var mockCarritoRepository = new Mock<ICarritoRepository>();
            var mockCarritoItemRepository = new Mock<ICarritoItemRepository>();
            var mockProductoRepository = new Mock<IProductoRepository>();
            var expectedCarritos = new List<Carrito>
            {
                new Carrito { Id = 1, IdCliente = 1, Fecha = DateTime.Now },
                new Carrito { Id = 2, IdCliente = 2, Fecha = DateTime.Now }
            };
            mockCarritoRepository.Setup(repo => repo.GetAll()).Returns(expectedCarritos);
            var carritoBussines = new CarritoBussines(mockCarritoRepository.Object, mockCarritoItemRepository.Object, mockProductoRepository.Object);
            // Act
            var result = carritoBussines.GetAll();
            // Assert
            Assert.True(result.Count > 0);
            Assert.Equal(expectedCarritos.Count, result.Count);
        }

        [Fact]
        public void Insert_ShouldReturnTrue_WhenCarritoIsInserted()
        {
            // Arrange
            var mockCarritoRepository = new Mock<ICarritoRepository>();
            var mockCarritoItemRepository = new Mock<ICarritoItemRepository>();
            var mockProductoRepository = new Mock<IProductoRepository>();

            var carritoInsertDto = new CarritoInsertDto
            {
                IdCliente = 1,
                Fecha = DateTime.Now,
                CarritoItem = new List<CarritoItemInsertDto>
                {
                    new CarritoItemInsertDto { IdProducto = 1 },
                    new CarritoItemInsertDto { IdProducto = 2 }
                }
            };
            mockCarritoRepository.Setup(repo => repo.InsertDapper(It.IsAny<Carrito>())).Returns(1);
            mockCarritoItemRepository.Setup(repo => repo.InsertDapper(It.IsAny<CarritoItem>())).Returns(true);
            mockProductoRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(new Producto { Id = 1, NombreProducto = "Producto 1" });

            var carritoBussines = new CarritoBussines(mockCarritoRepository.Object, mockCarritoItemRepository.Object, mockProductoRepository.Object);
            // Act
            var result = carritoBussines.Insert(carritoInsertDto);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Insert_ShouldThrowException_WhenCarritoNotInserted() 
        {
            // Arrange
            var mockCarritoRepository = new Mock<ICarritoRepository>();
            var mockCarritoItemRepository = new Mock<ICarritoItemRepository>();
            var mockProductoRepository = new Mock<IProductoRepository>();

            var carritoInsertDto = new CarritoInsertDto();

            mockCarritoRepository.Setup(x => x.InsertDapper(It.IsAny<Carrito>())).Returns(0);

            var carritoBussines = new CarritoBussines(mockCarritoRepository.Object, mockCarritoItemRepository.Object, mockProductoRepository.Object);

            // Assert
            Assert.Throws<Exception>(() => carritoBussines.Insert(carritoInsertDto));
        }

        [Fact]
        public void Insert_ShouldThrowException_WhenCarritoItemNotInserted()
        {
            // Arrange
            var mockCarritoRepository = new Mock<ICarritoRepository>();
            var mockCarritoItemRepository = new Mock<ICarritoItemRepository>();
            var mockProductoRepository = new Mock<IProductoRepository>();

            var carritoInsertDto = new CarritoInsertDto
            {
                IdCliente = 1,
                Fecha = DateTime.Now,
                CarritoItem = new List<CarritoItemInsertDto>
                {
                    new CarritoItemInsertDto { IdProducto = 1 }
                }
            };
            mockCarritoRepository.Setup(x => x.InsertDapper(It.IsAny<Carrito>())).Returns(1);
            mockCarritoItemRepository.Setup(x => x.InsertDapper(It.IsAny<CarritoItem>())).Returns(false);
            var carritoBussines = new CarritoBussines(mockCarritoRepository.Object, mockCarritoItemRepository.Object, mockProductoRepository.Object);
            // Assert
            Assert.Throws<Exception>(() => carritoBussines.Insert(carritoInsertDto));
        }

        [Fact]
        public void Insert_ShouldThrowException_WhenProductoNotExists()
        {
            // Arrange
            var mockCarritoRepository = new Mock<ICarritoRepository>();
            var mockCarritoItemRepository = new Mock<ICarritoItemRepository>();
            var mockProductoRepository = new Mock<IProductoRepository>();
            var carritoInsertDto = new CarritoInsertDto
            {
                IdCliente = 1,
                Fecha = DateTime.Now,
                CarritoItem = new List<CarritoItemInsertDto>
                {
                    new CarritoItemInsertDto { IdProducto = 1 }
                }
            };
            mockCarritoRepository.Setup(x => x.InsertDapper(It.IsAny<Carrito>())).Returns(1);
            mockProductoRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns((Producto)null);
            var carritoBussines = new CarritoBussines(mockCarritoRepository.Object, mockCarritoItemRepository.Object, mockProductoRepository.Object);
            // Assert
            Assert.Throws<Exception>(() => carritoBussines.Insert(carritoInsertDto));
        }
    }
}
