using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataDrivenWebDriverTestsNUnit
{
    public class DataDrivenTests
    {
        private WebDriver driver;
        private const string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";
        private ChromeOptions options;    
        IWebElement firstInput;
        IWebElement operationField;
        IWebElement secondInput;
        IWebElement calcButton;
        IWebElement result;
        IWebElement resetButton;
       

        [OneTimeSetUp]
        public void OpenBrower()
        {
            options = new ChromeOptions();
            options.AddArgument("--headless");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Url = BaseUrl;
            firstInput = driver.FindElement(By.Id("number1"));
            operationField = driver.FindElement(By.Id("operation"));
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
        
        [TestCase("10", "+", "2", "Result: 12")]
        [TestCase("-10", "+", "-2", "Result: -12")]
        [TestCase("10.3", "+", "2.5", "Result: 12.8")]
        [TestCase("10", "*", "2", "Result: 20")]
        [TestCase("-10", "*", "-2", "Result: 20")]
        [TestCase("10", "-", "2", "Result: 8")]
        [TestCase("-10", "-", "-2", "Result: -8")]
        [TestCase("10", "/", "2", "Result: 5")]
        [TestCase("-10", "/", "-2", "Result: 5")]
        [TestCase("10", "/", "0", "Result: Infinity")]
        [TestCase("10", "/", "hi", "Result: invalid input")]
       

        [Test]
        public void Test_Calculator_WebApp(string firstNum, string operation, string secondNum, string expectedResult)
        {
            // Arrange
            resetButton.Click();
            firstInput.SendKeys(firstNum);
            operationField.SendKeys(operation);
            secondInput.SendKeys(secondNum);

            // Act
            calcButton.Click();

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result.Text));
        } 

    }
}