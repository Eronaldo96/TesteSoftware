#language: pt
#encoding: iso-8859-1

Funcionalidade: Criar conta de usuário

	Como uma pessoa que navega na aplicação
	Eu quero criar uma conta de usuário
	Para que eu possa ter acesso aos recursos do sistema

Contexto: 
	Dado Eu acesso a página de criação de conta de usuário

Esquema do Cenário: Criar conta de usuário com sucesso
	E Eu preencho o nome do usuário <nome>
	E Eu preencho o email do usuário <email>
	E Eu preencho a senha do usuário <senha>
	E Eu confirmo a senha do usuário <senha>
	Quando Eu solicitar a realização do cadastro
	Então Eu recebo mensagem de sucesso "Usuário cadastrado com sucesso!"

	Exemplos: 
	| nome             | email                     | senha                |
	| "Ana Maria"      | "anamaria@gmail.com"      | "@Anamaria2024"      |
	| "João Pedro"     | "joaopedro@gmail.com"     | "@Joaopedro2024"     |
	| "Carlos Ribeiro" | "carlosribeiro@gmail.com" | "@Carlosribeiro2024" |

