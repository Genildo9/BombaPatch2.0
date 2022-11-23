# BombaPatch2.0
Api da copa do mundo

Qual é o seu desafio?
Modelar e implementar o backend em forma de API RESTFul do sistema de classificação da Copa 
do Mundo da Fifa.

Requisitos:
O sistema deve conter as seleções que vão jogar a copa, em seus respectivos grupos com a lista de jogos.
Como apenas duas equipes passam de fase, deve ter os criterios de classificação, como quem fez mais pontos, tem mais gols de saldo,
marcou mais gols, sofreu menos gols, levou menos cartões amarelos ou menos cartões vermelhos.

Para que serve?
O sistema tem como objetivo, criar uma Api com o tema relacionado a copa do mundo, onde terão os cadastros de seleções, jogadores, arbitros, estadios,
os grupos e os criterios de classificação, com o objetivo de simular a primeira fase da copa do mundo, a fase de classificatoria. 



Como usar?
Camadas:
-Api onde fica todos os controllers com as rotas, statup e o banco de dados.
-A Application é onde fica os services com as regras de negocio e algumas validações. 
-O Domain é onde fica as classes principais.
-Persistence é onde fica os arquivos que fazem a comunicação direta com o banco de dados.
Controllers:
-Dentro do Controller fica as rotas da API, são elas a selecao onde tem os gets para verificar as selecoes cadastradas, o post para cadastrar, o put para editar 
e o delete para excluir.
-A Partida onde serão exibidas todas as partidas da fase de grupos com as suas datas e possui os mesmos metodos que à em selecao.
Tem o controller do Jogo, que tem um pouco mais de complexidade, onde tem a integração de três classes, a selecaoJogoResultado onde vai gravar
o resultado daquela seleção na partida, o JogoResultado onde vai adicionar o Id das duas seleções cadastradas anteriormente e o resultado da partida
e em seguida tem a verificação de quem foi a vencedora ou se teve empate na partida, e por ultimo a classe jogo onde busca o grupo, estadio, arbitro,
as seleções que jogaram e pega o resultado jogo da classe anterior, e tambem tem todos os metodos utilizados anteriormente.
-O controller do Grupo vai trazer as duas seleções classificadas de cada grupo, onde foi feito um foreach com um filtro para buscar
as seleções e em seguida verificar os criterios de classificação para ver quem foi classificada.
-A ultima Controller é a de Eliminatoria, que pussui uma referncia a um arquivo chamado FaseEnum para verificar que fase é essa partida,
as seleções que estão jogado e quem venceu e quem perdeu, essa verificação ocorre através de um mapeamento e um filtro feito no grupoclassificação,
onde tem dois for da chave A e chave B, foi adicionado um filtro e um contador na chave A, para selecionar os primeiros quatro classificados da variavel
SelecaoClassificada1 e um filtro com contador que vai somar mais um para selecionar a SelecaoClassificada2 para criar os jogos, na chave B 
é da mesma maneira, mas o for se inicia em cinto e vai até o oito. Dessa maneira vai ocorrendo o for até as semi_finais onde tem o filtro que seleciona as seleções perdedoras para o jogo
de disputa de terceiro lugar e as vencedoras para a disputa final.
São essas as cinco Controllers e as suas funções.
Para rodar o projeto é necessario o dotnet 6.
Os testes podem ser feitos no postman ou no swagger, para rodar no swagger e necessario entrar no terminal e na pasta .Api, e digitar um dotnet run e colocar a rota no browser, 
ou um dotnet watch run e ele ja abre o swagger no browser sem precisar adicionar o caminho.




