using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using static MarsQA_1.Helpers.CommonMethods;
using AventStack.ExtentReports;

namespace MarsQA_1.SpecflowPages.Pages
{
    class Skills
    {

        // Click on Skills Tab
        public IWebElement SkillsTab => Driver.driver.FindElement(By.XPath("//a[normalize-space()='Skills']"));

        //Click on Add New button
        public IWebElement AddNew => Driver.driver.FindElement(By.XPath("//div[@class='ui teal button']"));

        //Enter the Skills
        public IWebElement AddSkill => Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));

        //Click on Add
        public IWebElement AddBtn => Driver.driver.FindElement(By.XPath("//input[@value='Add']"));

        // update Skills
        public IWebElement UpdateSkillsIcon => Driver.driver.FindElement(By.XPath("//td[@class='right aligned']//i[@class='outline write icon']"));

        // Update button
        public IWebElement Updatebutton => Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]"));
        // Click on DeleteButton
        public IWebElement Deletebutton => Driver.driver.FindElement(By.XPath("//i[@class='remove icon']"));

        public void SkillTab()
        {
            // Click On LanguageTab
            SkillsTab.Click();
        }

        public void UpdateTab()
        {

            // Click On Update
            UpdateSkillsIcon.Click();

        }

        public void DeleteTab()
        {
            // Click on delete
            Deletebutton.Click();
        }


        // Add Skills 
        
        public void AddSkills()

        {
            #region Add New Language

            // Populate Login page test data collection
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.DataExcelPath, "Skills");
            for (int i = 2; i <= 5; i++)
            {
                Driver.TurnOnWait();
                //Click on Add New button
                AddNew.Click();
                Thread.Sleep(5000);

                //Enter the Skill
                Driver.TurnOnWait();
                Thread.Sleep(2000);
                AddSkill.SendKeys(ExcelLibHelper.ReadData(i, "Skill"));

                //Select the Skill level.
                var Skilllevel = Driver.driver.FindElement(By.Name("level"));
                SelectElement select = new SelectElement(Skilllevel);

                Driver.TurnOnWait();
                select.SelectByValue(ExcelLibHelper.ReadData(i, "SkillLevel"));

                //Click on Add
                AddBtn.Click();
                Thread.Sleep(2000);
            }
            #endregion


        }

       

        // validate the language is added sucessfully 
        public void ValidateSkills()

        {

            #region Validate the language is added sucessfully
            try
            {
                //Start the Reports
                test = extent.CreateTest("Add Skill");
                test.Log(Status.Info, "Adding Skill");
                String expectedValue = ExcelLibHelper.ReadData(2, "Skill");
                //Get the table list
                IList<IWebElement> Tablerows = Driver.driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
                //Get the row count in table
                var rowCount = Tablerows.Count;
                for (var i = 1; i < rowCount; i++)
                {
                    Thread.Sleep(3000);
                    string actualValue = Driver.driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    //Check if expected value is equal to actual value
                    if (expectedValue == actualValue)
                    {
                        test.Log(Status.Pass, "Add Language Successful");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "AddSkill");
                        Assert.IsTrue(true);
                    }
                    else
                        test.Log(Status.Fail, "Test Failed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(3000);
            #endregion
        }


        public void UpdateSkills()
        {

            #region Update the given Language
            Thread.Sleep(3000);
            // Populate Login page test data collection
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.DataExcelPath, "Skills");
            String expectedValue = ExcelLibHelper.ReadData(2, "Skill");

            //Get the table list
            IList<IWebElement> Tablerows = Driver.driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));

            //Get the row count in table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                //Get the xpath of ith row Skills name
                String actualValue = Driver.driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;
                //check if the editLanguage Parameter matches with ith row Language name
                if (actualValue.Equals(expectedValue))
                {
                    //CliCk on Edit icon

                    Driver.driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[3]/span[1]/i")).Click();

                    //Send Skill name to update
                    IWebElement editRowValue = Driver.driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));

                    //Clear Previous text
                    editRowValue.Clear();
                    editRowValue.SendKeys(ExcelLibHelper.ReadData(2, "UpdateSkill"));

                    //Select Skill Level to update
                    var SkillLevelList = Driver.driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td/div/div[2]/select"));
                    var selectElement = new SelectElement(SkillLevelList);
                    selectElement.SelectByValue(ExcelLibHelper.ReadData(2, "UpdateSkillLevel"));

                    // Click on update button
                    Thread.Sleep(3000);
                    // form/div/div/div/div/table/tbody[" + i +"]/tr/ td[1] / div[1] / span[1] / input[1].Click();
                    Driver.driver.FindElement(By.XPath("//form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[" + i + "]/tr[1]/td[1]/div[1]/span[1]/input[1]")).Click();
                }
                #endregion

            } }

      
        public void valiadteSkillUpdate()
        {

            #region validate updated language
            try
            {
                //Start the Reports
                Driver.TurnOnWait();
                test = extent.CreateTest("Edit Skill");
                test.Log(Status.Info, "Editing Skill");
                Driver.TurnOnWait();
                String expectedValue1 = ExcelLibHelper.ReadData(2, "UpdateSkill");
                //Get the table list
                IList<IWebElement> UpdatedTablerows = Driver.driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
                //Get the row count in table
                var UpdatedrowCount1 = UpdatedTablerows.Count;
                for (var j = 1; j < UpdatedrowCount1; j++)
                {
                    string actualValue1 = Driver.driver.FindElement(By.XPath("//div/table/tbody[" + j + "]/tr/td[1]")).Text;
                    //Check if expected value is equal to actual value
                    if (expectedValue1 == actualValue1)
                    {
                        test.Log(Status.Pass, "Language updated Successful");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "UpdateSkill");
                        Assert.IsTrue(true);
                    }
                    else
                        test.Log(Status.Fail, "Test Failed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(3000);
            #endregion
        }



        // Click on delete button

        public void DeleteSkills()
        {

            #region Delete given language
            // Populate Login page test data collection
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.DataExcelPath, "Skills");
            String expectedValue = ExcelLibHelper.ReadData(2, "DeleteSkills");

            //Get the table row list
            IList<IWebElement> Tablerows = Driver.driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
            //Get the row count of table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                //Get the xpath of ith row SkillName
                String actualValue = Driver.driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;

                //check if the DeleteLanguage parameter matches with ith Row SkillName
                if (actualValue == expectedValue)
                {
                    // Click on delete button
                    Driver.driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[3]/span[2]/i")).Click();
                }
            }
            #endregion
        }


        public void ValidateDeleteSkills()
        {
            #region Valdidate deleted laguage
            try
            {
                //Start the Reports
                test = extent.CreateTest("Remove Skill");
                test.Log(Status.Info, "Deleting Skill");
                String expectedValue1 = ExcelLibHelper.ReadData(2, "DeleteSkills");
                //Get the table list
                IList<IWebElement> Tablerows1 = Driver.driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
                //Get the row count in table
                var rowCount1 = Tablerows1.Count;
                for (var j = 1; j < rowCount1; j++)
                {
                    Thread.Sleep(3000);
                    string actualValue1 = Driver.driver.FindElement(By.XPath("//div/table/tbody[" + j + "]/tr/td[1]")).Text;
                    //Check if expected value is equal to actual value
                    if (expectedValue1 != actualValue1)
                    {
                        Assert.IsTrue(true);
                        test.Log(Status.Pass, "Skill deleted Successful");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "DeleteSkill");
                    }
                    else
                        test.Log(Status.Fail, "Test Failed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(3000);
            #endregion
        }



    }

}
