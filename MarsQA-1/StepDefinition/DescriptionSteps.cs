using MarsQA_1.Helpers;
using MarsQA_1.SpecflowPages.Pages;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature
{
    [Binding]
    public class DescriptionSteps
    {
        description des = new description();
        
        [Given(@"seller able to click on the DescriptionLink")]
        public void GivenSellerAbleToClickOnTheDescriptionLink()
        {
        des.DesClick();
        }


        [Given(@"seller  enters the the descrption into the Input field")]
        public void GivenSellerEntersTheTheDescrptionIntoTheInputField()
        {
            des.DesTextBox();

        }

        [When(@"seller click on save button")]
        public void WhenSellerClickOnSaveButton()
        {
            des.DesSave();
        }

       
    }
}
