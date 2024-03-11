using TPW;
namespace MainTests
{
    [TestClass]
    public class ConverterTests
    {
        [TestMethod]
        public void StringConv_InputAllNumbers_ShouldReturnParsedInt()
        {
            // Arrange
            Conv converter = new Conv();
            string input = "123";
            converter.StringConv(input);
        }

        [TestMethod]
        public void StringConv_InputNotAllNumbers_ShouldWriteErrorMessage()
        {
            Conv converter = new Conv();
            string input = "abc";
            converter.StringConv(input);

        }

    }
}
