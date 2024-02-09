<h1 align="center">Projeto da UC de Laboratórios de Informática IV - 2023/2024</h1>
<h2 align="center">Counter Offer: Global Auctions - Online Auctions Software</h2>

## Definição
O CO:GA é um local de leilões de skins e Counter Strike onde os utilizadores podem leiloar as suas skins ou competir entre si em leilões para as comprar.

## Elementos deste repositório
Neste repositório podem ser encontrados:
- Toda a lógica e implementação da aplicação
- Relatórios e apresentações da aplicação
- Modelos e diagramas utilizados na idealização da aplicação

## Funcionalidades
Nesta aplicação é possível:
- Efetuar login e registo
- Manipular dados de perfil, alterar palavra-passe e email associado
- Favoritar leilões para fácil acesso e acompanhamento em tempo real
- Eliminar conta
- Criar leilões de um artigo ou de um bundle de artigos
- Participar em leilões efetuando um número ilimitado de lances até ao fim do leilão

## Observações importantes
- Este sistema funciona sobre uma camada de dados isto é, contém uma base de dados relacional onde estão guardados os dados da aplicação.
- Esta base de dados pode ser manipulada usando SSMS (SQL Server Managemenet Studio).
- Aqui deve ser criada a base de dados, as tabelas e deve ser feito o povoamento.

## Execução da aplicação
- Devido ao programa funcionar sobre uma camada de dados, é necessário executar e povoar a base de dados antes de executar o programa. Os scripts necessários para a base de dados encontram-se [aqui](https://github.com/Pedrosilva03/li4-online-auctions/tree/8d358ede026ce57b5f1f7e9896a12498a051531d/app/SQL)
- Deve também ser alterado o nome da máquina no campo MACHINE [aqui](https://github.com/Pedrosilva03/li4-online-auctions/blob/8d358ede026ce57b5f1f7e9896a12498a051531d/app/Data/DAOS/DAOconfig.cs)
- Este nome pode ser encontrado na janela de conexão ao abrir o SSMS (campo ```Server name```) e colado no campo especificado anteriormente.
- Este programa é executado em browser. Para iniciar a sua execução basta, na pasta app, executar o comando ```dotnet watch```.
- O programa irá ser compilado e executado automaticamente.

## Conclusão
Trabalho realizado por Pedro Silva, António Silva, Diogo Barros e Duarte Leitão.
