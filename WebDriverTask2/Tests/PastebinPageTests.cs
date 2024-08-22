using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverTask2.Pages;

namespace WebDriverTask2.Tests
{
    [TestFixture]
    public class PastebinPageTests
    {
        ChromeDriver driver;
        PastebinPage page;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Url = "https://pastebin.com/";

            page = new PastebinPage(driver);
        }

        [Test]
        public void TestMethod_PutValues_DisplayesPutValues()
        {
            driver.FindElement(By.XPath("//button[2]")).Click();
            page.TypeNewPaste(
				"git config --global user.name  \"New Sheriff in Town\"\ngit reset $(git commit-tree HEAD^{tree} -m \"Legacy code\")\ngit push origin master --force"
				);

            page.SelectSyntaxHighlighting("#postform-format", "8");
            page.SetPasteExpiration("#postform-expiration", "10M");

            page.TypePasteName("how to gain dominance among developers");

            driver.FindElement(By.XPath("//*[@class='btn -big']")).Click();

            Assert.That(page.GetFilledTextAreaValue(), Is.EqualTo(
				@"git config --global user.name  ""New Sheriff in Town"""));
            Assert.That(page.GetFilledTextAreaValue1(), Is.EqualTo("git reset $(git commit-tree HEAD^{tree} -m \"Legacy code\")"));
            Assert.That(page.GetFilledTextAreaValue2(), Is.EqualTo("git push origin master --force\""));

			Assert.That(page.GetSyntaxValue(), Is.EqualTo("Bash"));
            Assert.That(page.GetExpirationTimeAreaValue(), Is.EqualTo("10 MIN"));
            Assert.That(page.GetFilledTitleAreaValue(), Is.EqualTo("how to gain dominance among developers"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}