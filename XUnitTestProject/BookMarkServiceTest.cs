using BookMarkManager.Dal.Repositories.BaseRepository;
using BookMarkManager.Model.Context;
using BookMarkManager.Model.DTO;
using BookMarkManager.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace XUnitTestProject
{
    public class BookMarkServiceTest
    {
        Mock<IBookMarkRepository> _mockBookMarkRepository;
        [Fact]
        public void TestGetAll()
        {
            //Arrange
            _mockBookMarkRepository = new Mock<IBookMarkRepository>();
            List<BookMark> _bookMarkList = new List<BookMark>()
            {
                new BookMark() {
                    Createdat=new DateTime(2022,10,25,10,30,0),
                    Updatedat=new DateTime(2022,10,26,10,30,0),
                    Id=1,
                    Name="Amazon",
                    FolderId=1,
                    URL="http://amazon.com"
            },
                new BookMark{
                    Createdat=new DateTime(2022,10,25,10,30,0),
                    Updatedat=new DateTime(2022,10,26,10,30,0),
                    Id=2,
                    Name="BBC News",
                    FolderId=2,
                    URL="http://bbc.com"
                }
            };

            _mockBookMarkRepository.Setup(r => r.GetAll(It.IsAny<List<Expression<Func<BookMark, bool>>>>(), It.IsAny<List<Expression<Func<BookMark, object>>>>())).Returns(_bookMarkList);
            var bookMarkService = new BookMarkService(_mockBookMarkRepository.Object);

            //Act
            var response = bookMarkService.GetAll().ToList();

            //assert
            Assert.NotEmpty(response);

        }
        [Theory]
        [InlineData("Facebook", "http://facebook.com",true, ResponseStatus.Success)]
        [InlineData("Facebook", "http://facebook.com",false, ResponseStatus.UnSuccess)]
        public void TestInsert(string name, string url,bool mockInsertResult, ResponseStatus expected)
        {
            //Arrange
            _mockBookMarkRepository = new Mock<IBookMarkRepository>();
            _mockBookMarkRepository.Setup(r => r.Insert(It.IsAny<BookMark>())).Returns(mockInsertResult);
            var bookMarkService = new BookMarkService(_mockBookMarkRepository.Object);

            //Act
            var response = bookMarkService.Insert(new BookMarkDTO()
            {
                Name = name,
                URL = url
            });

            //assert
            Assert.Equal(expected, response);
        }

        [Theory]
        [InlineData( true, ResponseStatus.Success)]
        [InlineData( false, ResponseStatus.UnSuccess)]
        public void TestUpdate(bool mockResult, ResponseStatus expected)
        {
            //Arrange
            _mockBookMarkRepository = new Mock<IBookMarkRepository>();
            _mockBookMarkRepository.Setup(r => r.GetByID(It.IsAny<int>())).Returns(new BookMark()
            {
                Createdat = new DateTime(2022, 10, 25, 10, 30, 0),
                Updatedat = new DateTime(2022, 10, 26, 10, 30, 0),
                Id = 1,
                Name = "Amazon",
                FolderId = 1,
                URL = "http://amazon.com"
            });
            _mockBookMarkRepository.Setup(r => r.Update(It.IsAny<int>(), It.IsAny<BookMark>())).Returns(mockResult);
            var bookMarkService = new BookMarkService(_mockBookMarkRepository.Object);

            //Act
            var response = bookMarkService.Update(1, new BookMarkDTO()
            {
                FolderId = null,
                Name = "Facebook",
                URL = "http://facebook.com"
            });

            //assert
            Assert.Equal(expected, response);

        }
        [Fact]
        public void TestUpdate_NotFound()
        {
            //Arrange
            _mockBookMarkRepository = new Mock<IBookMarkRepository>();
            _mockBookMarkRepository.Setup(r => r.GetByID(It.IsAny<int>())).Returns<BookMark>(null);
            var bookMarkService = new BookMarkService(_mockBookMarkRepository.Object);

            //Act
            var response = bookMarkService.Update(1, new BookMarkDTO()
            {
                FolderId = null,
                Name = "Facebook",
                URL = "http://facebook.com"
            });

            //assert
            Assert.Equal(ResponseStatus.NotFound, response);

        }


        [Theory]
        [InlineData(true, ResponseStatus.Success)]
        [InlineData(false, ResponseStatus.UnSuccess)]
        public void TestDelete(bool mockResult, ResponseStatus expected)
        {
            //Arrange
            _mockBookMarkRepository = new Mock<IBookMarkRepository>();
            _mockBookMarkRepository.Setup(r => r.GetByID(It.IsAny<int>())).Returns(new BookMark()
            {

                Createdat = new DateTime(2022, 10, 25, 10, 30, 0),
                Updatedat = new DateTime(2022, 10, 26, 10, 30, 0),
                Id = 1,
                Name = "Amazon",
                FolderId = 1,
                URL = "http://amazon.com"
            });
            _mockBookMarkRepository.Setup(r => r.Delete(It.IsAny<int>())).Returns(mockResult);
            var bookMarkService = new BookMarkService(_mockBookMarkRepository.Object);

            //Act
            var response = bookMarkService.Delete(1);

            //assert
            Assert.Equal(expected, response);

        }
        [Fact]
        public void TestDelete_NotFound()
        {
            //Arrange
            _mockBookMarkRepository = new Mock<IBookMarkRepository>();
            _mockBookMarkRepository.Setup(r => r.GetByID(It.IsAny<int>())).Returns<BookMark>(null);
            var bookMarkService = new BookMarkService(_mockBookMarkRepository.Object);

            //Act
            var response = bookMarkService.Delete(1);

            //assert
            Assert.Equal(ResponseStatus.NotFound, response);

        }
    }

}
