using ConsoleApp1;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class CouponManagerTest
    {
        private readonly ILogger logger;
        private readonly ICouponProvider couponProvider;

        [Fact]
        public void Throw_Exception_When_Logger_Is_Null()
        {
            //Arrange
            var nameOfLogger = nameof(logger);
            var mockCouponProvider = new Mock<ICouponProvider>();

            //Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new CouponManager(null, mockCouponProvider.Object));
            Assert.Equal(nameOfLogger,exception.ParamName);
            exception = Assert.Throws<ArgumentNullException>(() => new CouponManager(null, null));
            Assert.Equal(nameOfLogger,exception.ParamName);
        }

        [Fact]
        public void Throw_Exception_When_CouponProvider_Is_Null()
        {
            //Arrange
            var nameOfCouponProvider = nameof(couponProvider);
            var mockLogger = new Mock<ILogger>();

            //Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new CouponManager(mockLogger.Object, null));
            Assert.Equal(nameOfCouponProvider,exception.ParamName);
        }
    }
}
