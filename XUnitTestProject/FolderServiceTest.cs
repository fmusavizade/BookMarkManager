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
    public class FolderServiceTest
    {
        Mock<IFolderRepository> _mockFolderRepository;
        [Fact]
        public void TestGetAll()
        {
            //Arrange

            _mockFolderRepository = new Mock<IFolderRepository>();
            List<Folder> _folderList = new List<Folder>()
            {
                new Folder() {
                    Createdat=new DateTime(2022,10,25,10,30,0),
                    Updatedat=new DateTime(2022,10,26,10,30,0),
                    Id=1,
                    Name="shop"
            },
                new Folder{
                    Createdat=new DateTime(2022,10,25,10,30,0),
                    Updatedat=new DateTime(2022,10,26,10,30,0),
                    Id=2,
                    Name="News"
                }
            };

            _mockFolderRepository.Setup(r => r.GetAll(It.IsAny<List<Expression<Func<Folder, bool>>>>(), It.IsAny<List<Expression<Func<Folder, object>>>>())).Returns(_folderList);
            var folderService = new FolderService(_mockFolderRepository.Object);

            //Act
            var response = folderService.GetAll().ToList();

            //assert
            Assert.NotEmpty(response);

        }
        [Fact]
        public void TestInsert_Success()
        {
            //Arrange

            _mockFolderRepository = new Mock<IFolderRepository>();
            _mockFolderRepository.Setup(r => r.Insert(It.IsAny<Folder>())).Returns(true);
            var folderService = new FolderService(_mockFolderRepository.Object);

            //Act
            var response = folderService.Insert(new FolderDTO()
            {
                Description = "",
                Name = "IT Articles"
            });

            //assert
            Assert.Equal(ResponseStatus.Success, response);
        }

        [Fact]
        public void TestInsert_Fail()
        {
            //Arrange

            _mockFolderRepository = new Mock<IFolderRepository>();
            _mockFolderRepository.Setup(r => r.Insert(It.IsAny<Folder>())).Returns(false);
            var folderService = new FolderService(_mockFolderRepository.Object);

            //Act
            var response = folderService.Insert(new FolderDTO()
            {
                Description = "",
                Name = "IT Articles"
            });

            //assert
            Assert.Equal(ResponseStatus.UnSuccess, response);

        }
        [Fact]
        public void TestUpdate_Success()
        {
            //Arrange

            _mockFolderRepository = new Mock<IFolderRepository>();
            _mockFolderRepository.Setup(r => r.GetByID(It.IsAny<int>())).Returns(new Folder
            {
                Createdat = new DateTime(2022, 10, 25, 10, 30, 0),
                Updatedat = new DateTime(2022, 10, 26, 10, 30, 0),
                Id = 1,
                Name = "shop"
            });
            _mockFolderRepository.Setup(r => r.Update(It.IsAny<int>(), It.IsAny<Folder>())).Returns(true);
            var folderService = new FolderService(_mockFolderRepository.Object);

            //Act
            var response = folderService.Update(1, new FolderDTO()
            {
                Description = "",
                Name = "IT Articles"
            });

            //assert
            Assert.Equal(ResponseStatus.Success, response);

        }
        [Fact]
        public void TestUpdate_UnSuccess()
        {
            //Arrange

            _mockFolderRepository = new Mock<IFolderRepository>();
            _mockFolderRepository.Setup(r => r.GetByID(It.IsAny<int>())).Returns(new Folder
            {
                Createdat = new DateTime(2022, 10, 25, 10, 30, 0),
                Updatedat = new DateTime(2022, 10, 26, 10, 30, 0),
                Id = 1,
                Name = "shop"
            });
            _mockFolderRepository.Setup(r => r.Update(It.IsAny<int>(), It.IsAny<Folder>())).Returns(false);
            var folderService = new FolderService(_mockFolderRepository.Object);

            //Act
            var response = folderService.Update(1, new FolderDTO()
            {
                Description = "",
                Name = "IT Articles"
            });

            //assert
            Assert.Equal(ResponseStatus.UnSuccess, response);

        }
        [Fact]
        public void TestUpdate_NotFound()
        {
            //Arrange

            _mockFolderRepository = new Mock<IFolderRepository>();
            _mockFolderRepository.Setup(r => r.GetByID(It.IsAny<int>())).Returns<Folder>(null);
            var folderService = new FolderService(_mockFolderRepository.Object);

            //Act
            var response = folderService.Update(1, new FolderDTO()
            {
                Description = "",
                Name = "IT Articles"
            });

            //assert
            Assert.Equal(ResponseStatus.NotFound, response);

        }

        [Fact]
        public void TestDelete_Success()
        {
            //Arrange

            _mockFolderRepository = new Mock<IFolderRepository>();
            _mockFolderRepository.Setup(r => r.GetByID(It.IsAny<int>())).Returns(new Folder
            {
                Createdat = new DateTime(2022, 10, 25, 10, 30, 0),
                Updatedat = new DateTime(2022, 10, 26, 10, 30, 0),
                Id = 1,
                Name = "shop"
            });
            _mockFolderRepository.Setup(r => r.Delete(It.IsAny<int>())).Returns(true);
            var folderService = new FolderService(_mockFolderRepository.Object);

            //Act
            var response = folderService.Delete(1);

            //assert
            Assert.Equal(ResponseStatus.Success, response);

        }
        [Fact]
        public void TestDelete_UnSuccess()
        {
            //Arrange

            _mockFolderRepository = new Mock<IFolderRepository>();
            _mockFolderRepository.Setup(r => r.GetByID(It.IsAny<int>())).Returns(new Folder
            {
                Createdat = new DateTime(2022, 10, 25, 10, 30, 0),
                Updatedat = new DateTime(2022, 10, 26, 10, 30, 0),
                Id = 1,
                Name = "shop"
            });

            _mockFolderRepository.Setup(r => r.Delete(It.IsAny<int>())).Returns(false);
            var folderService = new FolderService(_mockFolderRepository.Object);

            //Act
            var response = folderService.Delete(1);

            //assert
            Assert.Equal(ResponseStatus.UnSuccess, response);

        }
        [Fact]
        public void TestDelete_NotFound()
        {
            //Arrange

            _mockFolderRepository = new Mock<IFolderRepository>();
            _mockFolderRepository.Setup(r => r.GetByID(It.IsAny<int>())).Returns<Folder>(null);
            var folderService = new FolderService(_mockFolderRepository.Object);

            //Act
            var response = folderService.Delete(1);

            //assert
            Assert.Equal(ResponseStatus.NotFound, response);

        }
    }
}
