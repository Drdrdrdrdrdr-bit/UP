using UP2;
using Xunit;

namespace TestProject1
{
    public class MockSegmentForm : ISegment
    {
        public string LastPrinted { get; private set; } = "";
        public void PrintQuadrant(string text) => LastPrinted = text;
    }

    public class SegmentTests
    {
        private readonly MockSegmentForm _mock;

        public SegmentTests()
        {
            _mock = new MockSegmentForm();
        }

        [Theory]
        [InlineData(2, 3, 4, 1, "1ч.")]
        [InlineData(-2, 3, -4, 1, "2ч.")]
        [InlineData(-2, -3, -4, -1, "3ч.")]
        [InlineData(2, -3, 4, -1, "4ч.")]
        public void GetQuadrant_BothInSameQuadrant_ReturnsOnlyThatQuadrant(
            float ax, float ay, float bx, float by, string expected)
        {
            var seg = new Segment(_mock, ax, ay, bx, by);
            var result = seg.GetQuadrant();

            Assert.Contains(expected, result);
            foreach (var q in new[] { "1ч.", "2ч.", "3ч.", "4ч." })
                if (q != expected)
                    Assert.DoesNotContain(q, result);
        }

        [Theory]
        [InlineData(-2, 2, 2, 2, "1ч.", "2ч.")]
        [InlineData(-2, -2, 2, -2, "3ч.", "4ч.")]
        [InlineData(2, 2, 2, -2, "1ч.", "4ч.")]
        [InlineData(-2, 2, -2, -2, "2ч.", "3ч.")]
        public void GetQuadrant_CrossesOneAxis_ReturnsTwoQuadrants(
            float ax, float ay, float bx, float by,
            string q1, string q2)
        {
            var seg = new Segment(_mock, ax, ay, bx, by);
            var result = seg.GetQuadrant();

            Assert.Contains(q1, result);
            Assert.Contains(q2, result);
        }

        [Fact]
        public void GetQuadrant_CrossesBothAxes_ReturnsThreeQuadrants()
        {
            var seg = new Segment(_mock, -3, 2, 4, -1);
            var result = seg.GetQuadrant();

            Assert.Contains("1ч.", result);
            Assert.Contains("2ч.", result);
            Assert.Contains("4ч.", result);
            Assert.DoesNotContain("3ч.", result);
        }

        [Fact]
        public void GetQuadrant_ThroughOrigin_ReturnsAllQuadrants()
        {
            var seg = new Segment(_mock, -3, 3, 3, -3);
            var result = seg.GetQuadrant();

            Assert.DoesNotContain("1ч.", result);
            Assert.Contains("2ч.", result);
            Assert.DoesNotContain("3ч.", result);
            Assert.Contains("4ч.", result);
        }

        [Theory]
        [InlineData(3, 0, 3, 3, "1ч.", "4ч.")]
        [InlineData(0, 3, 3, 3, "1ч.", "2ч.")]
        [InlineData(-3, 0, -3, 3, "2ч.", "3ч.")]
        public void GetQuadrant_PointOnAxis_NotCountedAsQuadrant(
        float ax, float ay, float bx, float by,
        string shouldContain, string shouldNotContain)
        {
            var seg = new Segment(_mock, ax, ay, bx, by);
            var result = seg.GetQuadrant();

            Assert.Contains(shouldContain, result);
            Assert.DoesNotContain(shouldNotContain, result);
        }
    }
}