using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature
{
    [Binding]
    class Login
    {
        [Given(@"I login to the website")]
        public void GivenILoginToTheWebsite()
        {
            //MarsQA_1.Pages.SignIn.SigninStep();
        }

        [When(@"The user enter valid credentials, click on login")]
        public void WhenTheUserEnterValidCredentialsClickOnLogin()
        {
           

        }

        [Then(@"The user must login in to the account")]
        public void ThenTheUserMustLoginInToTheAccount()
        {
           
        }




    }
}
