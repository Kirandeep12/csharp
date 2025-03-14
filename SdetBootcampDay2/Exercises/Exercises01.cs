using NUnit.Framework;
using SdetBootcampDay2.TestObjects.Exercises;

namespace SdetBootcampDay2.Exercises
{
    [TestFixture]
    public class Exercises01
    {
        /**
         * TODO: After updating the OrderHandler to fix the Single Responsibility violation,
         * make the tests work again.
         */

        /**
         * TODO: After updating the OrderHandler to fix the Dependency Inversion violations,
         * make the tests work again.
         */

        /**
         * TODO: Add a test that tests that injects a stock count of 0 for Day Of The Tentacle,
         * tries to order a copy and verifies that the expected exception with the expected message
         * is thrown.
         */

        /**
         * TODO: Add a test that that creates a new OrderHandler using PayPal as a payment
         * processor, and test that ordering more than five items results in a payment failure,
         * even when there is enough stock.
         */

        [Test]
        public void Order1CopyOfFIFA24_ShouldLeave9CopiesRemaining()
        {
            Dictionary<OrderItem, int> stock = new Dictionary<OrderItem, int>
            {
                { OrderItem.FIFA_24, 10 }
            };
            var orderHandler = new OrderHandler(stock, new PaymentProcessor(PaymentProcessorType.Stripe));

            orderHandler.Order(OrderItem.FIFA_24, 1);

            Assert.That(orderHandler.PaymentProcess(OrderItem.FIFA_24, 1), Is.True);
            Assert.That(orderHandler.GetStockFor(OrderItem.FIFA_24), Is.EqualTo(9));
        }

        [Test]
        public void Order101CopiesOfFortnite_ShouldYieldArgumentException()
        {
            Dictionary<OrderItem, int> stock = new Dictionary<OrderItem, int>
            {
                { OrderItem.Fortnite, 5 }
            };
            
            var orderHandler = new OrderHandler(stock, new PaymentProcessor(PaymentProcessorType.Stripe));

            var e = Assert.Throws<ArgumentException>(() =>
            {
                orderHandler.Order(OrderItem.Fortnite, 6);
            });

            Assert.That(e.Message, Is.EqualTo("Insufficient stock for item Fortnite"));
        }

        [Test]
        public void AddStockForDayOfTheTentacle_ShouldYieldArgumentException()
        {
            Dictionary<OrderItem, int> stock = new Dictionary<OrderItem, int>
            {
                { OrderItem.FIFA_24, 2 },
                { OrderItem.SuperMarioBros3, 3 },
                { OrderItem.Fortnite, 4 }
            };
            
            var orderHandler = new OrderHandler(stock, new PaymentProcessor(PaymentProcessorType.Stripe));

            var e = Assert.Throws<ArgumentException>(() =>
            {
                orderHandler.AddStock(OrderItem.DayOfTheTentacle, 10);
            });

            Assert.That(e.Message, Is.EqualTo("Unknown item DayOfTheTentacle"));
        }
    }
}
