using Marketplace.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Marketplace.Tests
{
    public class MoneyTest
    {
        [Fact]
        public void
        Money_objects_with_the_same_amount_should_be_equal()
        {
            var firstAmount = new Money(5);
            var secondAmount = new Money(5);

            Assert.Equal(firstAmount, secondAmount);
        }

        [Fact]
        public void
        Money_objects_with_the_different_amount_should_not_be_equal()
        {
            var firstAmount = new Money(5);
            var secondAmount = new Money(6);

            Assert.NotEqual(firstAmount, secondAmount);
        }

        [Fact]
        public void Sum_of_money_gives_full_amount()
        {
            var coin1 = new Money(1);
            var coin2 = new Money(2);
            var coin3 = new Money(2);

            var banknote = new Money(5);

            Assert.Equal(banknote, coin1 + coin2 + coin3);
        }

        [Fact]
        public void The_equals()
        {
            var list1_1_1 = new List<Money>();
            list1_1_1.Add(new Money(30));

            var list1_1 = new List<Money>();
            list1_1.Add(new Money(20, list1_1_1));

            var list1 = new List<Money>();
            list1.Add(new Money(10, list1_1));

            var coin1 = new Money(2, list1);

            var list2_1_1 = new List<Money>();
            list1_1_1.Add(new Money(30));

            var list2_1 = new List<Money>();
            list2_1.Add(new Money(20, list1_1_1));

            var list2 = new List<Money>();
            list2.Add(new Money(10, list2_1));

            var coin2 = new Money(2, list2);

            Assert.Equal(coin1, coin2);
        }
    }
}
