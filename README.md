MoonStat

Descrição
A aplicação MoonStat é uma ferramenta de análise de conteúdo web. O utilizador insere um URL de uma página web, e a aplicação recolhe e analisa o conteúdo da página, fornecendo estatísticas como o número total de termos e os termos mais utilizados.

Estrutura do Projeto
A estrutura do projeto segue o padrão de design MVC (Model-View-Controller):

Model: Responsável pela lógica de análise de conteúdo e gestão de dados.
View: Responsável pela interface gráfica e interação com o utilizador.
Controller: Responsável pelo fluxo de controle entre Model e View.

Componentes Principais

Controller.cs:
Inicializa a aplicação.
Subscreve eventos entre Model e View.
Processa o input do utilizador e coordena a análise de conteúdo.

Model.cs:
Realiza a análise de conteúdo web.
Emite notificações e resultados da análise para a View.

View.cs:
Recebe input do utilizador.
Apresenta os resultados da análise.
Atualiza o estado da análise.

Logger.cs:
Regista todas as ações importantes em um ficheiro de log.
Dependências
OpenQA.Selenium: Usado para navegar e obter o conteúdo das páginas web.

Como Executar
Certifique-se de que todas as dependências estão instaladas.
Compile o projeto no Visual Studio 2022.
Execute a aplicação.
Insira um URL válido na interface da aplicação e clique no botão "Iniciar Análise".
Acompanhe o progresso e visualize os resultados na interface.

Este projeto foi desenvolvido por: 
•	DIOGO FERREIRA - 2200223 
•	GONÇALO AMARAL - 2101511
•	JOANA BRAGUEZ - 1801702 
•	NUNO RODRIGUES - 2201022
•	SANDRA SEQUEIRA - 2200026 
para a UC de Laboratório de Desenvolvimento de Software - UAB.
