using AutoFixture;
using Moq;
using TODO_Solution.Model;
using TODO_Solution.Repository;
using TODO_Solution.Services;

namespace TODO.Test
{
    [TestClass]
    public class TodoServiceTests
    {
        // Existing TodoItem for testing
        private readonly TodoItem existingTodo = new TodoItem { Id = "64c1533d5d727c22a0e79477", title = "Existing Todo", isDone = false };


        [TestMethod]
        public async Task CreateNewTodoAsync_ValidTodo_CallsDataStorageCreateAsync()
        {
            // Arrange
            var mockDataStorage = new Mock<ITodoDataStorage>();
            var todoService = new TodoService(mockDataStorage.Object);

            var todo = new TodoItem
            {
                title = "Title",
                isDone = true,
            };

            // Act
            await todoService.CreateNewTodoAsync(todo);

            // Assert
            mockDataStorage.Verify(ds => ds.CreateAsync(It.IsAny<TodoItem>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task CreateNewTodoAsync_NullTodo_ThrowsArgumentNullException()
        {
            // Arrange
            var mockDataStorage = new Mock<ITodoDataStorage>();
            var todoService = new TodoService(mockDataStorage.Object);

            // Act
            await todoService.CreateNewTodoAsync(null);
            // await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await todoService.CreateNewTodoAsync(null));
        }

        [TestMethod]
        public async Task GetTodoByIdAsync_ValidId_ReturnsTodoItem()
        {
            // Arrange
            var mockDataStorage = new Mock<ITodoDataStorage>();
            var todoService = new TodoService(mockDataStorage.Object);

            var expectedTodo = new TodoItem { Id = "64c1533d5d727c22a0e794f3", title = "Todo 1", isDone = false };
            mockDataStorage.Setup(ds => ds.GetByIdAsync("64c1533d5d727c22a0e794f3")).ReturnsAsync(expectedTodo);

            // Act
            var actualTodo = await todoService.GetTodoByIdAsync("64c1533d5d727c22a0e794f3");

            // Assert
            Assert.AreEqual(expectedTodo, actualTodo);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task GetTodoByIdAsync_NullId_ThrowsArgumentException()
        {
            // Arrange
            var mockDataStorage = new Mock<ITodoDataStorage>();
            var todoService = new TodoService(mockDataStorage.Object);

            // Act
            await todoService.GetTodoByIdAsync(null);
            // await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await todoService.GetTodoByIdAsync(null));
        }



        [TestMethod]
        public async Task GetAllTodosAsync_ReturnsListOfTodos_FromDataStorage()
        {
            // Arrange
            var mockDataStorage = new Mock<ITodoDataStorage>();
            var todoService = new TodoService(mockDataStorage.Object);

            var expectedTodos = new List<TodoItem>
            {
                new TodoItem { Id = "74c1533d5d727c22a0e794f9", title = "Todo 1", isDone = false },
                new TodoItem { Id = "14c1533d5d727c22a0e794f9", title = "Todo 2", isDone = true },
            };

            mockDataStorage.Setup(ds => ds.GetAllAsync()).ReturnsAsync(expectedTodos);

            // Act
            var actualTodos = await todoService.GetAllTodosAsync();

            // Assert
            CollectionAssert.AreEqual(expectedTodos, actualTodos);
        }


        [TestMethod]
        public async Task RemoveTodoAsync_ValidId_CallsDataStorageDeleteAsync()
        {
            // Arrange
            var mockDataStorage = new Mock<ITodoDataStorage>();
            var todoService = new TodoService(mockDataStorage.Object);

            // Act
            await todoService.RemoveTodoAsync("64c1533d5d727c22a0e794f9");

            // Assert
            mockDataStorage.Verify(ds => ds.DeleteAsync("64c1533d5d727c22a0e794f9"), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task RemoveTodoAsync_NullId_ThrowsArgumentException()
        {
            // Arrange
            var mockDataStorage = new Mock<ITodoDataStorage>();
            var todoService = new TodoService(mockDataStorage.Object);

            // Act
            await todoService.RemoveTodoAsync(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task RemoveTodoAsync_EmptyId_ThrowsArgumentException()
        {
            // Arrange
            var mockDataStorage = new Mock<ITodoDataStorage>();
            var todoService = new TodoService(mockDataStorage.Object);

            // Act
            await todoService.RemoveTodoAsync(string.Empty);
        }


        [TestMethod]
        public async Task UpdateTodoAsync_ValidIdAndTodo_CallsDataStorageUpdateAsync()
        {
            // Arrange
            var mockDataStorage = new Mock<ITodoDataStorage>();
            var todoService = new TodoService(mockDataStorage.Object);

            var todoToUpdate = new TodoItem { Id = "64c1533d5d727c22a0e794f9", title = "Updated Todo", isDone = true };

            // Act
            await todoService.UpdateTodoAsync("64c1533d5d727c22a0e794f9", todoToUpdate);

            // Assert
            mockDataStorage.Verify(ds => ds.UpdateAsync("64c1533d5d727c22a0e794f9", todoToUpdate), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task UpdateTodoAsync_NullTodo_ThrowsArgumentNullException()
        {
            // Arrange
            var mockDataStorage = new Mock<ITodoDataStorage>();
            var todoService = new TodoService(mockDataStorage.Object);

            // Act
            await todoService.UpdateTodoAsync("64c1533d5d727c22a0e794f9", null);

            // Assert: Expects ArgumentNullException to be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task UpdateTodoAsync_EmptyId_ThrowsArgumentException()
        {
            // Arrange
            var mockDataStorage = new Mock<ITodoDataStorage>();
            var todoService = new TodoService(mockDataStorage.Object);

            var todoToUpdate = new TodoItem { Id = "64c1533d5d727c22a0e794f1", title = "Updated Todo", isDone = true };

            // Act
            await todoService.UpdateTodoAsync(string.Empty, todoToUpdate);


        }

        [TestMethod]
        public async Task UpdateTodoAsync_InvalidId_DoesNotCallDataStorageUpdateAsync()
        {
            // Arrange
            var mockDataStorage = new Mock<ITodoDataStorage>();
            var todoService = new TodoService(mockDataStorage.Object);

            var todoToUpdate = new TodoItem { Id = "64c1533d5d727c22a0e794f1", title = "Updated Todo", isDone = true };

            // Act
            await todoService.UpdateTodoAsync("64c1533d5d727c22a0e794f1", todoToUpdate);

            // Assert
            mockDataStorage.Verify(ds => ds.UpdateAsync("2", todoToUpdate), Times.Never);
        }


    }
}