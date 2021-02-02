﻿using Marketplace.Domain;
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
        public void HashCode_of_money_should_be_equal()
        {
            var coin1 = new Money(1);
            var coin2 = new Money(1);

            Assert.Equal(coin1.GetHashCode(), coin2.GetHashCode());
        }

        [Fact]
        public void HashCode_of_money_should_not_be_equal()
        {
            var coin1 = new Money(1);
            var coin2 = new Money(2);

            Assert.NotEqual(coin1.GetHashCode(), coin2.GetHashCode());
        }
    }
}
