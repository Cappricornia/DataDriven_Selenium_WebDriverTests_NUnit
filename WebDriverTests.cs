using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataDrivenWebDriverTestsNUnit
{
    public class WebDriverTests
    {
        private WebDriver driver;
        private const string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";
        private ChromeOptions options;
        IWebElement firstInput;
        IWebElement operation;
        IWebElement secondInput;
        IWebElement calcButton;
        IWebElement result;
        IWebElement resetButton;
       

        [OneTimeSetUp]
        public void OpenBrowser()
        {
            options = new ChromeOptions();
            options.AddArgument("--headless");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Url = BaseUrl;
            firstInput = driver.FindElement(By.Id("number1"));
            operation = driver.FindElement(By.Id("operation"));
            secondInput = driver.FindElement(By.Id("number2"));
            calcButton = driver.FindElement(By.Id("calcButton"));
            result = driver.FindElement(By.Id("result"));
            resetButton = driver.FindElement(By.Id("resetButton"));
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }

       
        [Test]
        public void Test_Sum_Two_Positive_Numbers()
        {
            // Arrange
            resetButton.Click();
            firstInput.SendKeys("10");
            operation.SendKeys("+");
            secondInput.SendKeys("2");

            // Act
            calcButton.Click();
            var expectedResult = "Result: 12";

            // Assert
            Assert.That(result.Text, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_Sum_Two_Negative_Numbers()
        {
            // Arrange
            resetButton.Click();
            firstInput.SendKeys("-10");
            operation.SendKeys("+");
            secondInput.SendKeys("-2");

            // Act
            calcButton.Click();
            var expectedResult = "Result: -12";

            // Assert
            Assert.That(result.Text, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_Multiply_Two_Positive_Numbers()
        {
            // Arrange
            resetButton.Click();
            firstInput.SendKeys("10");
            operation.SendKeys("*");
            secondInput.SendKeys("2");

            // Act
            calcButton.Click();
            var expectedResult = "Result: 20";

            // Assert
            Assert.That(result.Text, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_Sum_Two_Positive_FLoating_Point_Numbers()
        {
            // Arrange
            resetButton.Click();
            firstInput.SendKeys("10.3");
            operation.SendKeys("+");
            secondInput.SendKeys("2.5");

            // Act
            calcButton.Click();
            var expectedResult = "Result: 12.8";

            // Assert
            Assert.That(result.Text, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_Multiply_Two_Negative_Numbers()
        {
            // Arrange
            resetButton.Click();
            firstInput.SendKeys("-10");
            operation.SendKeys("*");
            secondInput.SendKeys("-2");

            // Act
            calcButton.Click();
            var expectedResult = "Result: 20";

            // Assert
            Assert.That(result.Text, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_Subtract_Two_Positive_Numbers()
        {
            // Arrange
            resetButton.Click();
            firstInput.SendKeys("10");
            operation.SendKeys("-");
            secondInput.SendKeys("2");

            // Act
            calcButton.Click();
            var expectedResult = "Result: 8";

            // Assert
            Assert.That(result.Text, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_Subtract_Two_Negative_Numbers()
        {
            // Arrange
            resetButton.Click();
            firstInput.SendKeys("-10");
            operation.SendKeys("-");
            secondInput.SendKeys("-2");

            // Act
            calcButton.Click();
            var expectedResult = "Result: -8";

            // Assert
            Assert.That(result.Text, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_Divide_Two_Positive_Numbers()
        {
            // Arrange
            resetButton.Click();
            firstInput.SendKeys("10");
            operation.SendKeys("/");
            secondInput.SendKeys("2");

            // Act
            calcButton.Click();
            var expectedResult = "Result: 5";

            // Assert
            Assert.That(result.Text, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_Divide_Two_Negative_Numbers()
        {
            // Arrange
            resetButton.Click();
            firstInput.SendKeys("-10");
            operation.SendKeys("/");
            secondInput.SendKeys("-2");

            // Act
            calcButton.Click();
            var expectedResult = "Result: 5";

            // Assert
            Assert.That(result.Text, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_Divide_Positive_Number_By_Zero()
        {
            // Arrange
            resetButton.Click();
            firstInput.SendKeys("10");
            operation.SendKeys("/");
            secondInput.SendKeys("0");

            // Act
            calcButton.Click();
            var expectedResult = "Result: Infinity";

            // Assert
            Assert.That(result.Text, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_Divide_Positive_Number_By_InvalidInput()
        {
            // Arrange
            resetButton.Click();
            firstInput.SendKeys("10");
            operation.SendKeys("/");
            secondInput.SendKeys("hi");

            // Act
            calcButton.Click();
            var expectedResult = "Result: invalid input";

            // Assert
            Assert.That(result.Text, Is.EqualTo(expectedResult));
        }

    }
}
