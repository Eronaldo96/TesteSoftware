using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static System.Net.Mime.MediaTypeNames;

namespace BDDSpecFlowTests
{
    [Binding]
    public class CriarContaSteps
    {
        IWebDriver? driver;

        [Given(@"Eu acesso a página de criação de conta de usuário")]
        public void Eu_acesso_a_página_de_criação_de_conta_de_usuário()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://testedesoftware.azurewebsites.net/Account/Register");
        }

        [Given(@"Eu preencho o nome do usuário ""(.*)""")]
        public void Eu_preencho_o_nome_do_usuário(string nome)
        {
            var campo = driver.FindElement(By.XPath("//*[@id=\"name-input\"]"));
            campo.Clear();
            campo.SendKeys(nome);
        }

        [Given(@"Eu preencho o email do usuário ""(.*)""")]
        public void Eu_preencho_o_email_do_usuário(string email)
        {
            var index = email.IndexOf("@");
            var novoEmail = email.Substring(0, index) + Guid.NewGuid() + email.Substring(index);

            var campo = driver.FindElement(By.XPath("//*[@id=\"email-input\"]"));
            campo.Clear();
            campo.SendKeys(novoEmail);
        }

        [Given(@"Eu preencho a senha do usuário ""(.*)""")]
        public void Eu_preencho_a_senha_do_usuário(string senha)
        {
            var campo = driver.FindElement(By.XPath("//*[@id=\"password-input\"]"));
            campo.Clear();
            campo.SendKeys(senha);
        }

        [Given(@"Eu confirmo a senha do usuário ""(.*)""")]
        public void Eu_confirmo_a_senha_do_usuário(string senha)
        {
            var campo = driver.FindElement(By.XPath("//*[@id=\"confirm-password-input\"]"));
            campo.Clear();
            campo.SendKeys(senha);
        }

        [When(@"Eu solicitar a realização do cadastro")]
        public void Eu_solicitar_a_realização_do_cadastro()
        {
            var botao = driver.FindElement(By.XPath("//*[@id=\"register-button\"]"));
            botao.Click();
        }

        [Then(@"Eu recebo mensagem de sucesso ""(.*)""")]
        public void Eu_recebo_mensagem_de_sucesso(string mensagem)
        {
            var texto = driver.FindElement(By.XPath("//*[@id=\"success-message\"]"));

            texto.Text.Should().Contain(mensagem);

            driver.Close();
        }
    }
}



