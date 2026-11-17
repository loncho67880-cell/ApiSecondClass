using Bussines.ApiSecond.Bussines;
using Domain.ApiSecond;
using Domain.ApiSecond.Dto;
using Moq;
using Repository.ApiSecond.Intefaces;

namespace Unittest.ApiSecond.Bussines
{
    public class PedidoBussinesTest
    {
        [Fact]
        public void GetAll_ShouldReturnListOfPedidos()
        {
            // Arrange
            var mockPedidoRepository = new Mock<IPedidoRepository>();
            var mockPedidoItemRepository = new Mock<IPedidoItemRepository>();
            var expectedPedidos = new List<Pedido>
            {
                new Pedido { Id = 1, IdCliente = 1, Fecha = DateTime.Now },
                new Pedido { Id = 2, IdCliente = 2, Fecha = DateTime.Now }
            };
            mockPedidoRepository.Setup(repo => repo.GetAll()).Returns(expectedPedidos);
            var pedidoBussines = new PedidoBussines(mockPedidoRepository.Object, mockPedidoItemRepository.Object);
            // Act
            var result = pedidoBussines.GetAll();
            // Assert
            Assert.True(result.Count > 0);
            Assert.Equal(expectedPedidos.Count, result.Count);
        }

        [Fact]
        public void GetById_ShouldReturnPedido_WhenPedidoExists()
        {
            // Arrange
            var mockPedidoRepository = new Mock<IPedidoRepository>();
            var mockPedidoItemRepository = new Mock<IPedidoItemRepository>();

            var expectedPedido = new Pedido { Id = 1, IdCliente = 1, Fecha = DateTime.Now };
            mockPedidoRepository.Setup(repo => repo.GetById(1)).Returns(expectedPedido);

            var pedidoBussines = new PedidoBussines(mockPedidoRepository.Object, mockPedidoItemRepository.Object);

            // Act
            var result = pedidoBussines.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedPedido.Id, result.Id);
        }

        [Fact]
        public void Insert_ShouldReturnTrue_WhenPedidoIsInserted()
        {
            // Arrange
            var mockPedidoRepository = new Mock<IPedidoRepository>();
            var mockPedidoItemRepository = new Mock<IPedidoItemRepository>();

            var pedidoInsertDto = new PedidoInsertDto
            {
                IdCliente = 1,
                Fecha = DateTime.Now,
                PedidoItem = new List<PedidoItemInsertDto>
                {
                    new PedidoItemInsertDto { IdProducto = 1 },
                    new PedidoItemInsertDto { IdProducto = 2 }
                }
            };

            mockPedidoRepository.Setup(repo => repo.InsertDapper(It.IsAny<Pedido>())).Returns(1);
            mockPedidoItemRepository.Setup(repo => repo.InsertDapper(It.IsAny<PedidoItem>())).Returns(true);

            var pedidoBussines = new PedidoBussines(mockPedidoRepository.Object, mockPedidoItemRepository.Object);

            // Act
            var result = pedidoBussines.Insert(pedidoInsertDto);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Update_ShouldReturnTrue_WhenPedidoIsUpdated()
        {
            // Arrange
            var mockPedidoRepository = new Mock<IPedidoRepository>();
            var mockPedidoItemRepository = new Mock<IPedidoItemRepository>();
            var pedidoUpdateDto = new PedidoUpdateDto
            {
                IdCliente = 1,
                Fecha = DateTime.Now
            };
            mockPedidoRepository.Setup(repo => repo.Update(It.IsAny<Pedido>())).Returns(true);
            var pedidoBussines = new PedidoBussines(mockPedidoRepository.Object, mockPedidoItemRepository.Object);
            // Act
            var result = pedidoBussines.Update(1, pedidoUpdateDto);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Delete_ShouldReturnTrue_WhenPedidoIsDeleted()
        {
            // Arrange
            var mockPedidoRepository = new Mock<IPedidoRepository>();
            var mockPedidoItemRepository = new Mock<IPedidoItemRepository>();

            mockPedidoRepository.Setup(repo => repo.Delete(1)).Returns(true);

            var pedidoBussines = new PedidoBussines(mockPedidoRepository.Object, mockPedidoItemRepository.Object);

            // Act
            var result = pedidoBussines.Delete(1);
            // Assert
            Assert.True(result);
        }
    }
}
