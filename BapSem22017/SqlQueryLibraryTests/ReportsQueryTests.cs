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
    public class ReportsQueryTests
    {
        private ITestOutputHelper _output;

        public ReportsQueryTests(ITestOutputHelper output)
        {
            _output = output;
        }
        [Fact()]
        public void GetReportsTestWithNullConnectionString()
        {
            var r = new ReportsQuery("");

            var exception = Record.Exception(() => r.GetReports(""));

            Assert.NotNull(exception);
            _output.WriteLine(exception.Message);
            Assert.True(exception.Message.Contains("is null"));
        }

        [Theory]
        [InlineData("", "", "")]
        [InlineData(" ", "", "")]
        [InlineData("RROLEO", "1-Jan-2010", "")]
        public void GetReportsTest(string supplierCode, string fromDate, string toDate)
        {
            var r = new ReportsQuery("");

            DateTime? fromDateTime = string.IsNullOrEmpty(fromDate) ? (DateTime?) null : DateTime.Parse(fromDate);
            DateTime? toDateTime = string.IsNullOrEmpty(toDate) ? (DateTime?) null : DateTime.Parse(toDate);

            var exception = Record.Exception(() => r.GetReports(supplierCode, fromDateTime, toDateTime));

            Assert.NotNull(exception);
            _output.WriteLine(exception.Message);
 
        }
          
    }
}