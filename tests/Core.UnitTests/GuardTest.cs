#region Libraries
using Ploeh.AutoFixture.Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Extensions; 
#endregion

namespace Blog.UnitTests
{
    public class GuardTest
    {
        [Fact]
        public void IsNotNullThrowExceptionWithNullValue()
        {
            Assert.Throws<ArgumentNullException>(() => Guard.IsNotNull(null, String.Empty));
        }

        [Theory, AutoData]
        public void IsNotNullNotThrowExceptionWhitNonNullValue(object anonymousValue)
        {
            Assert.DoesNotThrow(() => Guard.IsNotNull(anonymousValue, String.Empty));
        }

        [Theory, AutoData]
        public void IsNotNullOrEmptyNotThrowExceptionWithNonNullValue(string anonymousString)
        {
            Assert.DoesNotThrow(() => Guard.IsNotNullOrEmpty(anonymousString, String.Empty));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void IsNotNullOrEmptyThrowExceptionWithNullOrEmptyValue(string anonymousString)
        {
            Assert.Throws<ArgumentException>(() => Guard.IsNotNullOrEmpty(anonymousString, String.Empty));
        }
    }
}
