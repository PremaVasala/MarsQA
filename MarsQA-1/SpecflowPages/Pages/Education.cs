using System;
using MarsQA_1.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using NUnit.Framework;


namespace MarsQA_1.SpecflowPages.Pages
{
    class Education
    {
        public IWebElement EduTab => Driver.driver.FindElement(By.XPath("//a[normalize-space()='Education']"));
        public IWebElement Addnew => Driver.driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//div[contains(@class,'ui teal button')][normalize-space()='Add New']"));

        public IWebElement UniName => Driver.driver.FindElement(By.XPath("//input[@placeholder='College/University Name']"));

        public IWebElement Country => Driver.driver.FindElement(By.XPath("//select[@name='country']"));
   
        public IWebElement title => Driver.driver.FindElement(By.XPath("//select[@name='title']"));
        public IWebElement degree => Driver.driver.FindElement(By.XPath("//input[@placeholder='Degree']"));
        public IWebElement yearofgrad => Driver.driver.FindElement(By.XPath("//select[@name='yearOfGraduation']"));

        public IWebElement addbutton => Driver.driver.FindElement(By.XPath("//div[@class='sixteen wide field']//input[@value='Add']"));
        public IWebElement Editbtn => Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[1]/i"));
        public IWebElement Update => Driver.driver.FindElement(By.XPath("//input[@value='Update']"));
        public IWebElement deleteButton => Driver.driver.FindElement(By.XPath("//tbody/tr/td[6]/span[2]/i[1]"));
  
    

        public IWebElement alertMessage => Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        static string message;

        public void EducationTab()
        {
            EduTab.Click();
        }

        public void AddNewTab()
        {
            Addnew.Click();
        }

        public void Addbutton()
        {
            addbutton.Click();
        }

        public void EditButton()
        {
            Editbtn.Click();

        }


        public void AddEducation()
        {


            // Populate colleage/university test data collection
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.DataExcelPath, "Education");

            //Enter the Education details

            int i = new Random().Next(2, 5);
         
                Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

                Thread.Sleep(5000);
                UniName.SendKeys(ExcelLibHelper.ReadData(i, "University Name"));
                //Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                Thread.Sleep(2000);

                //Select Country of colleage/ University from dropdown
                var CountryofColleage = Driver.driver.FindElement(By.XPath("//select[@name='country']"));
                SelectElement select = new SelectElement(CountryofColleage);

                Driver.TurnOnWait();
                Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

                select.SelectByValue(ExcelLibHelper.ReadData(i, "Country of colleage/University"));
                Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

                // Select Title from dropdow

                var title = Driver.driver.FindElement(By.Name("title"));
                SelectElement select1 = new SelectElement(title);
                select1.SelectByValue(ExcelLibHelper.ReadData(i, "Title"));

                // Enter Degree
                degree.SendKeys(ExcelLibHelper.ReadData(i, "Degree"));
                Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                Thread.Sleep(5000);


                //Select year of Graduation from dropdown
                var yearofgrad = Driver.driver.FindElement(By.Name("yearOfGraduation"));
                SelectElement select2 = new SelectElement(yearofgrad);
                select2.SelectByValue(ExcelLibHelper.ReadData(i, "YearOfgraduation"));
                Thread.Sleep(5000);


                // click on Add button
                addbutton.Click();
                Thread.Sleep(5000);
            
        }

        public void ValidateEducation()
        {

            message = alertMessage.Text;

            //Function to verify if the education record has been added    

            if (message.Contains("has been added"))
            {
                Console.WriteLine(message);
            }
            else if (message.Equals("This information is already exist."))
            {
                Console.WriteLine(message);
                Console.WriteLine("Add a different education record");
            }


        }

        public void UpdateEducation()
        {
            Thread.Sleep(5000);
            Editbtn.Click();


            // Populate colleage/university test data collection
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.DataExcelPath, "Education");
            Thread.Sleep(5000);


            //Enter the Education details

            int i = new Random().Next(2, 5);

            //Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            Thread.Sleep(5000);
            UniName.Clear();

            UniName.SendKeys(ExcelLibHelper.ReadData(i, "Update University Name"));
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            //Select Country of colleage/ University from dropdown

            var CountryofColleage = Driver.driver.FindElement(By.XPath("//select[@name='country']"));
            SelectElement select = new SelectElement(CountryofColleage);

            Driver.TurnOnWait();
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            select.SelectByValue(ExcelLibHelper.ReadData(i, "Update Country of colleage/University"));
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            // Select Title from dropdow

            var title = Driver.driver.FindElement(By.Name("title"));
            SelectElement select1 = new SelectElement(title);
            select1.SelectByValue(ExcelLibHelper.ReadData(i, "Update Title"));
            Thread.Sleep(5000);

            // Enter Degree
            degree.Clear();
            degree.SendKeys(ExcelLibHelper.ReadData(i, "Update Degree"));
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);


            //Select year of Graduation from dropdown
            Thread.Sleep(5000);
            var yearofgrad = Driver.driver.FindElement(By.Name("yearOfGraduation")); //yearOfGraduation
            SelectElement select2 = new SelectElement(yearofgrad);
            Thread.Sleep(5000);
            select2.SelectByValue(ExcelLibHelper.ReadData(i, "UpdateYear"));

            // click on Update button
            Thread.Sleep(2000);
            Update.Click();
            Thread.Sleep(5000);
        }

    

    public void ValidateUpateEducation()
    {
        try
        {
            if (message.Contains("has been updated to your education"))
            {
                Assert.True(message.Contains("has been updated to your education")); Console.WriteLine(message);
            }
            else if (message.Equals("This information is already exist."))
            {
                Console.WriteLine(message);
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Editing education record failed");
        }
    }

        public void DeleteRecord()
        {
            Thread.Sleep(2000);
            deleteButton.Click();
            Thread.Sleep(2000);
        }

        public void ValidateDeleteRecord()

        {

            try
            {
                if (message.Contains("entry has been successfully removed") 

                 || message.Contains("Education entry successfully removed"))
                {
                    Console.WriteLine(message);
                }
                else
                {
                    Console.WriteLine("No record available for deleteing");
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Deleting education record failed");
            }





        }
    }
}









   

        


    
    









    
