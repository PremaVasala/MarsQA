using MarsQA_1.SpecflowPages.Pages;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature
{
    [Binding]
    public class SkillsSteps
    {
        Skills SK = new Skills();
         
        [Given(@"the User Clicks on skills Tab")]
        public void GivenTheUserClicksOnSkillsTab()
        {
            SK.SkillTab();
        }
        
        [When(@"the user Adds the New skills details and clicks on Add button")]
        public void WhenTheUserAddsTheNewSkillsDetailsAndClicksOnAddButton()
        {
            SK.AddSkills();
        }
        
        [Then(@"the User should see the new skills in his profile")]
        public void ThenTheUserShouldSeeTheNewSkillsInHisProfile()
        {
            SK.ValidateSkills();
        }


        [Given(@"the user is on Skills Tab")]
        public void GivenTheUserIsOnSkillsTab()
        {
            SK.SkillTab();
        }

        [When(@"the user Edits the existing skills details and click on update button")]
        public void WhenTheUserEditsTheExistingSkillsDetailsAndClickOnUpdateButton()
        {
            SK.UpdateSkills();
        }

        [Then(@"the user should see updated skills in his profile")]
        public void ThenTheUserShouldSeeUpdatedSkillsInHisProfile()
        {
            SK.valiadteSkillUpdate();
        }

        [Given(@"the User at skills Tab")]
        public void GivenTheUserAtSkillsTab()
        {
            SK.SkillTab();
        }

        [When(@"the user deletes the skills")]
        public void WhenTheUserDeletesTheSkills()
        {
            SK.DeleteSkills();
        }

        [Then(@"the User skills details should be deleted")]
        public void ThenTheUserSkillsDetailsShouldBeDeleted()
        {
            SK.ValidateDeleteSkills();
            
        }



    }
}
