using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace WebDriverTask2.Pages
{
    public class PastebinPage
    {
        private readonly WebDriver driver;

        public PastebinPage(WebDriver driver)
        {
            this.driver = driver;
        }

        readonly By textArea = By.XPath("//*[@id='postform-text']");
        readonly By syntaxHighlighting = By.XPath("//span[@id='select2-postform-format-container']");
        readonly By pasteNameArea = By.XPath("//*[@id='postform-name']");

        readonly By filledTextArea = By.XPath("//div[@class='source bash']/ol/li[1]/div");
        readonly By filledTextArea1 = By.XPath("//div[@class='source bash']/ol/li[2]/div");
        readonly By filledTextArea2 = By.XPath("//div[@class='source bash']/ol/li[3]/div");
        
        readonly By filledTitleArea = By.XPath("//div[@class='info-top']/h1");
        readonly By expirationTimeArea = By.XPath("//div[@class='expire']");
        readonly By syntaxValue = By.XPath("//a[@class='btn -small h_800']");

        public void TypeNewPaste(string input)
        {
            driver.FindElement(textArea).SendKeys(input);
        }

		public void SelectSyntaxHighlighting(string syntax, string selectedValue)
		{
			driver.ExecuteJavaScript($"document.querySelector('{syntax}').value = '{selectedValue}'");
		}

		public void SetPasteExpiration(string pasteExpirationSelector, string selectedValue)
        {
            driver.ExecuteJavaScript($"document.querySelector('{pasteExpirationSelector}').value = '{selectedValue}'");
        }

        public void TypePasteName(string pasteName)
        {
            driver.FindElement(pasteNameArea).SendKeys(pasteName);
        }

        public string GetFilledTextAreaValue()
        {
            return driver.FindElement(filledTextArea).Text;
        }

        public string GetFilledTitleAreaValue()
        {
            return driver.FindElement(filledTitleArea).Text;

        }

        public string GetExpirationTimeAreaValue()
        {
            return driver.FindElement(expirationTimeArea).Text;

        }

        public string GetSyntaxValue()
        {
            return driver.FindElement(syntaxValue).Text;
        }

		internal string GetFilledTextAreaValue1()
		{
			return driver.FindElement(filledTextArea).Text;
		}

		internal string GetFilledTextAreaValue2()
		{
			return driver.FindElement(filledTextArea).Text;
		}
	}
}