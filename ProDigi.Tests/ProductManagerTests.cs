using FluentAssertions;
using Moq;
using ProDigi.App.Abstract;
using ProDigi.App.Concrete;
using ProDigi.App.Managers;
using ProDigi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDigi.Tests
{
    public class ProductManagerTests
    {
        [Theory]
        [InlineData(0,1)]
        [InlineData(1331,1332)]
        public void AddNewProduct_ForAddingNewProduct_NewIdIsCorrect(int lastId, int id)
        {
            //arrange
            string name = "Test";
            string version = "1.0";
            string designer = "Pan Jan";
            var mock = new Mock<IService<Product>>();
            mock.Setup(s => s.GetLastId()).Returns(lastId);
            var manager = new ProductManager(mock.Object);
            //act
            var newId = manager.AddNewProduct(name, version, designer);
            //assert
            newId.Should().Be(id);
        }
    }
}
