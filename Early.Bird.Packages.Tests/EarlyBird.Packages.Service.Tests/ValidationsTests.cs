using EarlyBird.Packages.DAL.Mappers;
using EarlyBird.Packages.DAL.Models;
using EarlyBird.Packages.Service;
using Xunit;

namespace Early.Bird.Packages.Tests.EarlyBird.Packages.Service.Tests
{
    public class ValidationsTests
    {
        [Fact]
        public void ValidateDimensions_returns_correct_amount_of_errors()
        {
            //Arrange
            var bigPackage = new Package
            {
                Kolliid = 123456789012345678,
                Height = 100,
                Weight = 100,
                Length = 100,
                Width = 100
            };

            //Act 
            var res = Validations.ValidateDimensions(PackageMapper.ToModel(bigPackage));

            //Assert
            Assert.Equal(4, res.Count);

        }

        [Fact]
        public void ValidateDimensions_returns_no_errors()
        {
            //Arrange
            var bigPackage = new Package
            {
                Kolliid = 123456789012345678,
                Height = 10,
                Weight = 10,
                Length = 10,
                Width = 10
            };

            //Act 
            var res = Validations.ValidateDimensions(PackageMapper.ToModel(bigPackage));

            //Assert
            Assert.Empty(res);
        }

        [Theory]
        [InlineData("a", false)]
        [InlineData("123", false)]
        [InlineData("999956789012345678", true)]
        [InlineData("aaaaaaaaaaaaaaaaaa", false)]
        public void IsSearchKolliidValid_Validates_correctly(string kolliid, bool expected)
        {
            //Act 
            var res = Validations.IsSearchKolliidValid(kolliid);

            //Assert
            Assert.Equal(expected, res);
        }
    }
}