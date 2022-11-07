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
        [Fact]
        public void TestInsert_Success()
        {
            //Arrange
            _mockBookMarkRepository = new Mock<IBookMarkRepository>();
            _mockBookMarkRepository.Setup(r => r.Insert(It.IsAny<BookMark>())).Returns(true);
            var bookMarkService = new BookMarkService(_mockBookMarkRepository.Object);

            //Act
            var response = bookMarkService.Insert(new BookMarkDTO()
            {
                Name = "Facebook",
                URL = "http://facebook.com"
            });

            //assert
            Assert.Equal(ResponseStatus.Success, response);
        }

        [Fact]
        public void TestInsert_Fail()
        {
            //Arrange
            _mockBookMarkRepository = new Mock<IBookMarkRepository>();
            _mockBookMarkRepository.Setup(r => r.Insert(It.IsAny<BookMark>())).Returns(false);
            var bookMarkService = new BookMarkService(_mockBookMarkRepository.Object);

            //Act
            var response = bookMarkService.Insert(new BookMarkDTO()
            {
                Name = "Facebook",
                URL = "http://facebook.com"
            });

            //assert
            Assert.Equal(ResponseStatus.UnSuccess, response);

        }
        [Fact]
        public void TestUpdate_Success()
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
            _mockBookMarkRepository.Setup(r => r.Update(It.IsAny<int>(), It.IsAny<BookMark>())).Returns(true);
            var bookMarkService = new BookMarkService(_mockBookMarkRepository.Object);

            //Act
            var response = bookMarkService.Update(1, new BookMarkDTO()
            {
                FolderId = null,
                Name = "Facebook",
                URL = "http://facebook.com"
            });

            //assert
            Assert.Equal(ResponseStatus.Success, response);

        }
        [Fact]
        public void TestUpdate_UnSuccess()
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
            _mockBookMarkRepository.Setup(r => r.Update(It.IsAny<int>(), It.IsAny<BookMark>())).Returns(false);
            var bookMarkService = new BookMarkService(_mockBookMarkRepository.Object);

            //Act
            var response = bookMarkService.Update(1, new BookMarkDTO()
            {
                FolderId = null,
                Name = "Facebook",
                URL = "http://facebook.com"
            });

            //assert
            Assert.Equal(ResponseStatus.UnSuccess, response);

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

        [Fact]
        public void TestDelete_Success()
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
            _mockBookMarkRepository.Setup(r => r.Delete(It.IsAny<int>())).Returns(true);
            var bookMarkService = new BookMarkService(_mockBookMarkRepository.Object);

            //Act
            var response = bookMarkService.Delete(1);

            //assert
            Assert.Equal(ResponseStatus.Success, response);

        }
        [Fact]
        public void TestDelete_UnSuccess()
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
            _mockBookMarkRepository.Setup(r => r.Delete(It.IsAny<int>())).Returns(false);
            var bookMarkService = new BookMarkService(_mockBookMarkRepository.Object);

            //Act
            var response = bookMarkService.Delete(1);

            //assert
            Assert.Equal(ResponseStatus.UnSuccess, response);

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
