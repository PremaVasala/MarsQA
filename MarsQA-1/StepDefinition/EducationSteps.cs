using MarsQA_1.SpecflowPages.Pages;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature
{
    [Binding]
    public class EducationSteps
    {
        Education Edu = new Education();

        [Given(@"the user is on Educationtab")]
        public void GivenTheUserIsOnEducationtab()
        {
            Edu.EducationTab();
        }

        [Given(@"the user click on Addnew button")]
        public void GivenTheUserClickOnAddnewButton()
        {
            Edu.AddNewTab();
        }

        [When(@"the User add education details")]
        public void WhenTheUserAddEducationDetails()
        {
            Edu.AddEducation();
        }

        [Then(@"the user can able to see message ""(.*)""")]
        public void ThenTheUserCanAbleToSeeMessage(string p0)
        {
            Edu.ValidateEducation();
        }

        [Given(@"the user is on Education tab")]
        public void GivenTheUserIsOnEducationTab()
        {
            Edu.EducationTab();
        }

        [Given(@"the user click on editIcon")]
        public void GivenTheUserClickOnEditIcon()
        {
            Edu.EditButton();
        }

        [When(@"the User Update education details")]
        public void WhenTheUserUpdateEducationDetails()
        {
            Edu.UpdateEducation();
        }

        [Then(@"the user is able to see message ""(.*)""")]
        public void ThenTheUserIsAbleToSeeMessage( string p0 )
        {
            Edu.ValidateUpateEducation();
        }

        [Given(@"the user click on EducationTab")]
        public void GivenTheUserClickOnEducationTab()
        {
            Edu.EducationTab();
        }

        [When(@"the user Delete the Education record")]
        public void WhenTheUserDeleteTheEducationRecord()
        {
            Edu.DeleteRecord();
        }

        [Then(@"the user get message as ""(.*)""")]
        public void ThenTheUserGetMessageAs( string p0 )
        {
            Edu.ValidateDeleteRecord();
        }

    }


}
