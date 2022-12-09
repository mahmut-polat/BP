using BPApi.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BPApi.Test.Application.Extensions
{
    public class ObjectExtensionsTest
    {
        [Theory()]
        [InlineData("test")]
        [InlineData(1)]
        [InlineData(1.1)]
        public async Task IsNullOrEmpty_ShouldReturnTrue_WhenObjectIsNotEmpty(object obj)
        {
            var result = obj.IsNullOrEmpty();

            Assert.False(result);
        }

        public async Task IsNullOrEmpty_ShouldReturnTrue_WhenListIsNotEmpty()
        {
            var list = new List<string>()
            {
                "test",
                ""
            };
        }

        [Theory()]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData(null)]
        public async Task IsNullOrEmpty_ShouldReturnFalse_WhenObjectIsNullOrEmpty(object obj)
        {

        }
    }
}
