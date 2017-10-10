using Xunit;
using SqlQueryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace SqlQueryLibrary.Tests
{
    public class SuppliersQueryTests
    { 

    private ITestOutputHelper _output;

    public SuppliersQueryTests(ITestOutputHelper output)
    {
    _output = output;
    }

    
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("1239r4")]
        public void  GetSuppliersTest(string supplierCode)
        {
            var suppliersQuery = new SuppliersQuery("");

            var exception = Record.Exception(() => suppliersQuery.GetSuppliers(supplierCode));

            Assert.NotNull(exception);
            _output.WriteLine(exception.Message);
        }

      

    }
}