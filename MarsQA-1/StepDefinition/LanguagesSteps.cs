using MarsQA_1.SpecflowPages.Pages;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature
{
    [Binding]
    public class LanguagesSteps
    {
        Languages Lang = new Languages();

        [Given(@"the User Clicks on Language Tab")]
        public void GivenTheUserClicksOnLanguageTab()
        {
            Lang.LanguageTab();
        }
        
     
        [When(@"the user Adds the New Language details and Clicks on Add button")]
        public void WhenTheUserAddsTheNewLanguageDetailsAndClicksOnAddButton()
        {
            Lang.AddLanguages();
        }

        [Then(@"the User should see the new Language in his profile")]
        public void ThenTheUserShouldSeeTheNewLanguageInHisProfile()
        {


             Lang.ValidateAddlanguage();
            //Lang.expectedmessage = Lang.LanguagedatafromExcel + " has been updated to your languages";
            //Lang.ValidateUpdatelanguage();



        }


        [Given(@"the User is on Language Tab")]
        public void GivenTheUserIsOnLanguageTab()
        {
            Lang.LanguageTab();
        }


        [When(@"the user  Edits the Language details and click on update button")]
        public void WhenTheUserEditsTheLanguageDetailsAndClickOnUpdateButton()
        {
            Lang.UpdateLanguage();
        }


        [Then(@"the Language Details should be Updated and should be seen by User")]
        public void ThenTheLanguageDetailsShouldBeUpdatedAndShouldBeSeenByUser()
        {
            //Lang.valiadteUpdatelanguage();

            //Lang.expectedmessage = Lang.LanguagedatafromExcel + " has been updated to your languages";
            //Lang.ValidateUpdatelanguage();
        }


        [When(@"the user deletes the Language")]
        public void WhenTheUserDeletesTheLanguage()
        {
            Lang.DeleteTab();
        }

        [Then(@"the User Language details should be deleted")]
        public void ThenTheUserLanguageDetailsShouldBeDeleted()
        {
            Lang.validateDeleteLanguage();
        }




    }
}
