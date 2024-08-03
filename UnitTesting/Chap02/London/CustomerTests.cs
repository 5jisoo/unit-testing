using Moq;

namespace UnitTesting.Chap02.London;

public class CustomerTests
{
    [Fact]
    public void Purchase_succeeds_when_enough_inventory()
    {
        // 준비
        var storeMock = new Mock<IStore>();
        storeMock
            .Setup(x => x.HasEnoughInventory(Product.Shampoo, 5))
            .Returns(true);
        var customer = new Customer();

        // 실행
        bool success = customer.Purchase(storeMock.Object, Product.Shampoo, 5);

        // 검증
        Assert.True(success);
        storeMock.Verify(x => x.RemoveInventory(Product.Shampoo, 5), Times.Once);
    }

    [Fact]
    public void Purchase_fails_when_not_enough_inventory()
    {
        // 준비
        var storeMock = new Mock<IStore>();
        storeMock
            .Setup(x => x.HasEnoughInventory(Product.Shampoo, 5))
            .Returns(false);
        var customer = new Customer();

        // 실행
        bool success = customer.Purchase(storeMock.Object, Product.Shampoo, 5);

        // 검증
        Assert.False(success);
        storeMock.Verify(x => x.RemoveInventory(Product.Shampoo, 5), Times.Never);
    }
}