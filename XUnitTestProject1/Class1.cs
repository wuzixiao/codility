using ConsoleApp1;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        [Fact]
        public async Task Throw_Exception_When_Evaluators_Null()
        {
            //Arrange
            var mockLogger = new Mock<ILogger>();
            var mockCouponProvider = new Mock<ICouponProvider>();
            var couponId = new Guid();
            var userId = new Guid();

            var manager = new CouponManager(mockLogger.Object, mockCouponProvider.Object);
            IEnumerable<Func<Coupon, Guid, bool>> evaluators = null;

            //Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => manager.CanRedeemCoupon(couponId, userId, evaluators));

            //Assert
            Assert.Equal(nameof(evaluators),exception.ParamName);
        }

        [Fact]
        public async Task Throw_Exception_When_Retrieved_Coupon_Null()
        {
            //Arrange
            var couponId = new Guid();
            var userId = new Guid();
            var mockLogger = new Mock<ILogger>();
            var mockEvaluators = new Mock<IEnumerable<Func<Coupon, Guid, bool>>>();
            var mockCouponProvider = new Mock<ICouponProvider>();
            mockCouponProvider
                .Setup(provider => provider.Retrieve(couponId))
                .ReturnsAsync((string)null);

            var manager = new CouponManager(mockLogger.Object, mockCouponProvider.Object);

            //Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => manager.CanRedeemCoupon(couponId, userId, mockEvaluators.Object));

            //Assert
            Assert.Equal(nameof(evaluators),exception.ParamName);
        }
    }
}
