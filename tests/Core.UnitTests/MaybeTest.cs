#region Libraries
using Ploeh.AutoFixture.Xunit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Extensions;
#endregion

//Taken from https://github.com/ploeh/Booking/blob/master/BookingDomainModel.UnitTest/MaybeTests.cs
namespace Blog.UnitTests
{
    public abstract class MaybeTest<T>
    {
        [Theory, AutoData]
        public void SutIsEnumerable(Maybe<T> sut)
        {
            Assert.IsAssignableFrom<IEnumerable<T>>(sut);
        }

        [Theory, AutoData]
        public void CreatedWithModestConstructorIsNonGenericallyEmpty(
            [Modest]Maybe<T> sut)
        {
            Assert.Empty(sut);
        }

        [Theory, AutoData]
        public void CreatedWithModestConstructorIsGenericallyEmpty(
            [Modest]Maybe<T> sut)
        {
            Assert.False(sut.Any());
        }

        [Theory, AutoData]
        public void CreatedWithGreedyConstructorYieldsCorrectItem(
            [Frozen]T expected,
            [Greedy]Maybe<T> sut)
        {
            Assert.Equal(expected, sut.Single());
        }

        [Theory, AutoData]
        public void CreatedWithGreedyConstructorYieldsCorrectItemOnNonGenericInterface(
            [Frozen]T expected,
            [Greedy]Maybe<T> sut)
        {
            IEnumerable actual = sut;
            Assert.Equal(expected, actual.OfType<T>().Single());
        }

        [Theory, AutoData]
        public void ToMaybeReturnsCorrectResult(T expected)
        {
            Maybe<T> acutal = expected.ToMaybe();
            Assert.Equal(expected, acutal.SingleOrDefault());
        }

        [Fact]
        public void EmptyReturnsCorrectResult()
        {
            Maybe<T> actual = Maybe.Empty<T>();
            Assert.Empty(actual);
        }
    }

    public class MaybeTestsOfObject : MaybeTest<object> { }
    public class MaybeTestsOfString : MaybeTest<string> { }
    public class MaybeTestsOfInt32 : MaybeTest<int> { }
    public class MaybeTestsOfGuid : MaybeTest<Guid> { }
}
