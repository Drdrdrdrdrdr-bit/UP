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

        // Конструктор вместо [TestInitialize] — вызывается для каждого теста
        public SegmentTests()
        {
            _mock = new MockSegmentForm();
        }

        // ─── Оба конца в одной четверти ──────────────────────

        [Theory]
        [InlineData(2, 3, 4, 1, "1ч.")] // Q1
        [InlineData(-2, 3, -4, 1, "2ч.")] // Q2
        [InlineData(-2, -3, -4, -1, "3ч.")] // Q3
        [InlineData(2, -3, 4, -1, "4ч.")] // Q4
        public void GetQuadrant_BothInSameQuadrant_ReturnsOnlyThatQuadrant(
            float ax, float ay, float bx, float by, string expected)
        {
            var seg = new Segment(_mock, ax, ay, bx, by);
            var result = seg.GetQuadrant();

            Assert.Contains(expected, result);

            // Остальные четверти не должны быть
            foreach (var q in new[] { "1ч.", "2ч.", "3ч.", "4ч." })
                if (q != expected)
                    Assert.DoesNotContain(q, result);
        }

        // ─── Пересечение осей ─────────────────────────────────

        [Theory]
        [InlineData(-2, 2, 2, 2, "1ч.", "2ч.")] // пересекает ось Y сверху
        [InlineData(-2, -2, 2, -2, "3ч.", "4ч.")] // пересекает ось Y снизу
        [InlineData(2, 2, 2, -2, "1ч.", "4ч.")] // пересекает ось X справа
        [InlineData(-2, 2, -2, -2, "2ч.", "3ч.")] // пересекает ось X слева
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
            // A(-3,2) B(4,-1) — пересекает обе оси → Q1, Q2, Q4
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
            // A(-3,3) B(3,-3) — через центр, все четверти
            var seg = new Segment(_mock, -3, 3, 3, -3);
            var result = seg.GetQuadrant();

            Assert.Contains("1ч.", result);
            Assert.Contains("2ч.", result);
            Assert.Contains("3ч.", result);
            Assert.Contains("4ч.", result);
        }

        // ─── Точки на осях ────────────────────────────────────

        [Theory]
        [InlineData(3, 0, 3, 3, "1ч.", "4ч.")] // A на оси X
        [InlineData(0, 3, 3, 3, "1ч.", "2ч.")] // A на оси Y
        [InlineData(-3, 0, -3, 3, "2ч.", "3ч.")] // B на оси X
        public void GetQuadrant_PointOnAxis_NotCountedAsQuadrant(
            float ax, float ay, float bx, float by,
            string shouldContain, string shouldNotContain)
        {
            var seg = new Segment(_mock, ax, ay, bx, by);
            var result = seg.GetQuadrant(); // Сделать вывод

            Assert.Contains(shouldContain, result);
            Assert.DoesNotContain(shouldNotContain, result);
        }

        [Fact]
        public void GetQuadrant_BothOnAxis_NoQuadrant()
        {
            // A(3,0) B(-3,0) — оба на оси X
            var seg = new Segment(_mock, 3, 0, -3, 0);
            var result = seg.GetQuadrant();

            Assert.DoesNotContain("1ч.", result);
            Assert.DoesNotContain("2ч.", result);
            Assert.DoesNotContain("3ч.", result);
            Assert.DoesNotContain("4ч.", result);
        }

        // ─── UpdatePoint ──────────────────────────────────────

        [Fact]
        public void UpdatePoint_ChangesCoordinates()
        {
            var seg = new Segment(_mock, 1, 1, 2, 2);
            seg.UpdatePoint(3, 4, 5, 6);

            Assert.Equal(3f, seg.A.X);
            Assert.Equal(4f, seg.A.Y);
            Assert.Equal(5f, seg.B.X);
            Assert.Equal(6f, seg.B.Y);
        }

        [Fact]
        public void UpdatePoint_ThenGetQuadrant_UsesNewCoordinates()
        {
            var seg = new Segment(_mock, -1, -1, -2, -2);
            var before = seg.GetQuadrant();
            Assert.Contains("3ч.", before);

            seg.UpdatePoint(1, 1, 2, 2);
            var after = seg.GetQuadrant();

            Assert.Contains("1ч.", after);
            Assert.DoesNotContain("3ч.", after);
        }

        // ─── PrintQuadrant вызывается ─────────────────────────

        [Fact]
        public void GetQuadrant_AlwaysCallsPrintQuadrant()
        {
            var seg = new Segment(_mock, 1, 1, 2, 2);
            seg.GetQuadrant();

            Assert.False(string.IsNullOrEmpty(_mock.LastPrinted));
        }
    }
}
