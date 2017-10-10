using Xunit;
using SqlQueryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlQueryLibrary.Tests
{
    public class ReportsQueryTests
    {
        [Fact()]
        public void GetReportsTestWithNullConnectionString()
        {
            var r = new ReportsQuery("");

            var exception = Record.Exception(() => r.GetReports(""));

            Assert.NotNull(exception);
            Assert.True(exception.Message.Contains("is null"));
        }

        [Theory]
        [InlineData("", "", "")]
        [InlineData(" ", "", "")]
        [InlineData("RROLEO", "1-Jan-2010")]
        public void GetReportsTest(string supplierCode, string fromDate, string toDate)
        {
            var r = new ReportsQuery("");

            var exception = Record.Exception(() => r.GetReports(""));

            Assert.NotNull(exception);
            Assert.True(exception.Message.Contains("is null"));
        }
    }
}