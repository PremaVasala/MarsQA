using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace MarsQA_1.SpecflowPages.Pages
{
     class description
    {

      public IWebElement descriptionTab => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i"));

        public IWebElement descriptionTextBox => Driver.driver.FindElement(By.XPath("//textarea[@placeholder='Please tell us about any hobbies, additional expertise, or anything else you’d like to add.']"));

        public IWebElement saveButton => Driver.driver.FindElement(By.XPath("//button[@type='button']"));
      
        public  void DesClick()
        {
            descriptionTab.Click();
        }

        public void DesTextBox()
        {

            descriptionTextBox.Click();
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Description");
            descriptionTextBox.Clear();
            descriptionTextBox.SendKeys(ExcelLibHelper.ReadData(2, "Description"));
        }

        public void DesSave()
        {
            saveButton.Click();
            Thread.Sleep(5000);
            Driver.driver.SwitchTo().Window(Driver.driver.WindowHandles.Last());

            // verify Description is save successfully
          Assert.AreEqual(Driver.driver.FindElement(By.XPath("/html/body/div[1]/div")).Text, "Description has been saved successfully");
            Driver.driver.SwitchTo().DefaultContent();


        }

    }

}


  



































      
    
