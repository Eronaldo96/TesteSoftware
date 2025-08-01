#language: pt-br
#encoding: iso-8859-1

Funcionalidade: Acessar conta de usuário
		

		Como um usuário cadastrado no sistema
		Eu quero acessar a minha conta
		Para que eu possa utilizar o painel de ações

Contexto: 
		Dado Eu acesso a página de autenticação de usuário

Cenário: Realizar autenticação de usuário com sucesso
		E Eu informo o email de acesso "teste@teste.com.br"
		E Eu informo a senha de acesso "@Teste2024"
		Quando Eu solicito o acesso ao sistema
		Então Eu sou redirecionado para o painel de ações

Cenário: Acesso negado de usuário
		E Eu informo o email de acesso "exemplo@teste.com.br"
		E Eu informo a senha de acesso "@Exemplo123"
		Quando Eu solicito o acesso ao sistema
		Então Eu recebo a mensagem "Email ou senha inválidos."

Cenário: Validação de campos obrigatórios
		Quando Eu solicito o acesso ao sistema
		Então Eu recebo erro de validação do campo email "O email é obrigatório."
		E Eu recebo erro de validação do campo senha "A senha é obrigatória."
