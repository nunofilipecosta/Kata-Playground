using Xunit;

namespace KataPlayground.UnitTests.Multiples3And5
{
    public class Multiple3And5Tests
    {
        [Fact]
        public void Sum_From4_Returns3()
        {
            var sum = Multiple3And5.Sum(4);
            var sum2 = Multiple3And5_2.Sum(4);

            Assert.Equal(3, sum);
            Assert.Equal(3, sum2);
        }

        [Fact]
        public void Sum_From6_Returns8()
        {
            var sum = Multiple3And5.Sum(6);
            var sum2 = Multiple3And5_2.Sum(6);

            Assert.Equal(8, sum);
            Assert.Equal(8, sum2);
        }

        [Fact]
        public void Sum_From10_Returns23()
        {
            var sum = Multiple3And5.Sum(10);
            var sum2 = Multiple3And5_2.Sum(10);

            Assert.Equal(23, sum);
            Assert.Equal(23, sum2);
        }
    }
}
