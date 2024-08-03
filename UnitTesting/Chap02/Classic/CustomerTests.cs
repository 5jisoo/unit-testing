namespace UnitTesting.Chap02.Classic;

public class CustomerTests
{
    [Fact]
    public void Purchase_succeeds_when_enough_inventory()
    {
        // 준비
        var store = new Store();
        store.AddInventory(Product.Shampoo, 10);
        var customer = new Customer();

        // 실행
        bool success = customer.Purchase(store, Product.Shampoo, 5);

        // 검증
        Assert.True(success);
        Assert.Equal(5, store.GetInventory(Product.Shampoo)); // 상품 재고 5개 감소
    }

    [Fact]
    public void Purchase_fails_when_not_enough_inventory()
    {
        // 준비
        var store = new Store();
        store.AddInventory(Product.Shampoo, 10);
        var customer = new Customer();

        // 실행
        bool success = customer.Purchase(store, Product.Shampoo, 15);

        // 검증
        Assert.False(success);
        Assert.Equal(10, store.GetInventory(Product.Shampoo)); // 상품 재고 수량 변화 없음
    }
}