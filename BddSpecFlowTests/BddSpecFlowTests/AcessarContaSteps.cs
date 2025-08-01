using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace BDDSpecFlowTests
{
    [Binding]
    public class AcessarContaSteps
    {
        IWebDriver? driver;

        [Given(@"Eu acesso a página de autenticação de usuário")]
        public void Eu_acesso_a_página_de_autenticação_de_usuário()
        {
            driver = new ChromeDriver(); //abrindo o google chrome
            driver.Manage().Window.Maximize(); //maximizando a janela
            driver.Navigate().GoToUrl("https://testedesoftware.azurewebsites.net/Account/Login"); //acessando a página
        }

        [Given(@"Eu informo o email de acesso ""(.*)""")]
        public void Eu_informo_o_email_de_acesso(string email)
        {
            var campo = driver.FindElement(By.XPath("//*[@id=\"email-input\"]")); //capturando o campo
            campo.Clear(); //limpando o conteudo do campo
            campo.SendKeys(email); //preenchendo o campo
        }

        [Given(@"Eu informo a senha de acesso ""(.*)""")]
        public void Eu_informo_a_senha_de_acesso(string senha)
        {
            var campo = driver.FindElement(By.XPath("//*[@id=\"password-input\"]")); //capturando o campo
            campo.Clear(); //limpando o conteudo do campo
            campo.SendKeys(senha); //preenchendo o campo
        }

        [When(@"Eu solicito o acesso ao sistema")]
        public void Eu_solicito_o_acesso_ao_sistema()
        {
            var botao = driver.FindElement(By.XPath("//*[@id=\"login-button\"]")); //capturando o botão
            botao.Click(); //clicando no botão
        }

        [Then(@"Eu sou redirecionado para o painel de ações")]
        public void Eu_sou_redirecionado_para_o_painel_de_ações()
        {
            var url = driver.Url; //capturando e comparando a URL do sistema
            url.Should().Be("https://testedesoftware.azurewebsites.net/Home/Index");

            driver.Close(); //fechar o navegador
        }

        [Then(@"Eu recebo a mensagem ""(.*)""")]
        public void Eu_recebo_a_mensagem(string mensagem)
        {
            //capturando a mensagem exibida no sistema
            var texto = driver.FindElement(By.XPath("//*[@id=\"error-message\"]"));

            //comparando o texto (resultado obtido) com a mensagem (resultado esperado)
            mensagem.Should().Be(texto.Text);

            driver.Close(); //fechar o navegador
        }

        [Then(@"Eu recebo erro de validação do campo email ""(.*)""")]
        public void Eu_recebo_erro_de_validação_do_campo_email(string mensagem)
        {
            //capturando a mensagem exibida no sistema
            var texto = driver.FindElement(By.XPath("//*[@id=\"email-validation\"]"));

            //comparando o texto (resultado obtido) com a mensagem (resultado esperado)
            mensagem.Should().Be(texto.Text);
        }

        [Then(@"Eu recebo erro de validação do campo senha ""(.*)""")]
        public void Eu_recebo_erro_de_validação_do_campo_senha(string mensagem)
        {
            //capturando a mensagem exibida no sistema
            var texto = driver.FindElement(By.XPath("//*[@id=\"password-validation\"]"));

            //comparando o texto (resultado obtido) com a mensagem (resultado esperado)
            mensagem.Should().Be(texto.Text);

            driver.Close(); //fechar o navegador
        }

    }
}
