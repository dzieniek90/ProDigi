using FluentAssertions;
using Moq;
using ProDigi.App.Abstract;
using ProDigi.App.Managers;
using ProDigi.Domain.Common;
using ProDigi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDigi.Tests
{

    public class OrderManagerTests
    {

        [Theory]
        [InlineData(0, 1)]
        [InlineData(23, 24)]
        [InlineData(1231, 1232)]
        public void AddNewOrder_ForAddingNewOrder_NewIdIsCorrect(int lastId, int id)
        {
            //arrange
            int typeId = 1;
            var product = new Product();
            int quantity = 100;
            string company = "Test";

            var mock = new Mock<IService<Order>>();
            mock.Setup(s => s.GetLastId()).Returns(lastId);
            var manager = new OrderManager(mock.Object);
            //act
            var newId = manager.AddNewOrder(typeId, product, quantity, company);
            //assert
            newId.Should().Be(id);
        }


        public readonly List<Order> testOrders = new List<Order>()
            {
            new Order(){Id = 1, OrderTypeId = 1},
            new Order(){Id = 2, OrderTypeId = 2},
            new Order(){Id = 3, OrderTypeId = 3},
            new Order(){Id = 4, OrderTypeId = 3},
            new Order(){Id = 5, OrderTypeId = 2},
            new Order(){Id = 6, OrderTypeId = 1},
            };

        [Theory]
        [InlineData(1, new int[] {1, 6})]
        [InlineData(2, new int[] {2, 5})]
        [InlineData(3, new int[] {3, 4})]
        public void GetOrdersByTypeId_ForGivenTypeId_ReturnsCorrectOrders(int typeId, int[] ids)
        {
            //arrange
            var mock = new Mock<IService<Order>>();
            mock.Setup(s => s.Items).Returns(testOrders);
            var manager = new OrderManager(mock.Object);
            //act
            var orders = manager.GetOrdersByTypeId(typeId);
            int[] ordersIds = orders.Select(o => o.Id).ToArray();
            //assert
            ordersIds.Should().Equal(ids);
           

        }
    }
}

