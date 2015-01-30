using calc.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTest
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var matrix = new Matrix(2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 1;
            matrix[1, 0] = 1;
            matrix[1, 1] = 1;

            var matrix2 = new Matrix(2);
            matrix2[0, 0] = 1;
            matrix2[0, 1] = 1;
            matrix2[1, 0] = 1;
            matrix2[1, 1] = 1;

            var matrix3 = new Matrix(2);
            matrix3[0, 0] = 2;
            matrix3[0, 1] = 2;
            matrix3[1, 0] = 2;
            matrix3[1, 1] = 2;

            var result = matrix + matrix2;
            Assert.AreEqual(result, matrix3);
        }
    }
}
