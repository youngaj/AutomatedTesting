using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace SampleProject.Tests
{
    public class Calculator_Should
    {

        //[Fact]
        //public void AddNumbers()
        //{
        //    //Arrange
        //    var calculator = new Calculator();

        //    //Act
        //    var sum = calculator
        //                     .Add(1)
        //                     .Add(2)
        //                     .Execute();

        //    //Assert
        //    Assert.Equal(3, sum);

        //}

        //[Fact]
        //public void Return4()
        //{
        //    //Arrange
        //    var calculator = new Calculator();

        //    //Act
        //    var sum = calculator
        //                    .Add(2)
        //                    .Add(2)
        //                    .Execute();

        //    //Assert
        //    Assert.Equal(4, sum);

        //}

        [Fact]
        public void One_Plus_One_Returns3()
        {
            //Arrange
            var logger = new Logger();
            var user = new User() { Id = 1, Name = "Andre" };
            var calculator = new Calculator(user, logger);

            //Act
            var sum = calculator
                            .Add(1)
                            .Add(2)
                            .Execute();

            //Assert
            Assert.Equal(3, sum);

        }

        [Fact]
        public void Two_Plus_Two_Returns4()
        {
            //Arrange
            var logger = new Logger();
            var user = new User() { Id = 1, Name = "Andre" };
            var calculator = new Calculator(user, logger);

            //Act
            var sum = calculator
                            .Add(2)
                            .Add(2)
                            .Execute();

            //Assert
            Assert.Equal(4, sum);

        }

        [Fact]
        public void One_Plus_Two__Minus_Three_Returns0()
        {
            //Arrange
            var logger = new Logger();
            var user = new User() { Id = 1, Name = "Andre" };
            var calculator = new Calculator(user, logger);

            //Act
            var sum = calculator
                            .Add(1)
                            .Add(2)
                            .Subtract(3)
                            .Execute();

            //Assert
            Assert.Equal(0, sum);

        }

        [Fact]
        public void VerifyAddLogging()
        {
            //Arrange
            var logger = new Mock<ILogger>();
            var user = new User() { Id = 1, Name = "Andre" };
            var calculator = new Calculator(user, logger.Object);

            //Act
            var sum = calculator
                            .Add(1)
                            .Execute();

            //Assert
            var expectedMsg = "Andre Added 1";
            logger.Verify(x => x.info(expectedMsg), Times.AtLeastOnce);
            //logger.Verify(x => x.info(It.IsAny<string>()), Times.AtLeastOnce);

        }

        public Calculator CreateSUT()
        {
            var logger = new Logger();
            var user = new User() { Id = 1, Name = "Andre" };
            var calculator = new Calculator(user, logger);
            return calculator;
        }

    }

    public class CalculatorBuilder
    {
        private IUser _user;
        private ILogger _logger;

        public CalculatorBuilder()
        {
            _user = new User() { Id = 1, Name = "Andre" };
            _logger = new Logger();
        }

        public CalculatorBuilder WithUser(IUser user)
        {
            _user = user;
            return this;
        }
        public CalculatorBuilder WithLogger(ILogger logger)
        {
            _logger = logger;
            return this;
        }

        public Calculator Build()
        {
            return new Calculator(_user, _logger);
        }
    }
}
