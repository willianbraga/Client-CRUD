CREATE PROCEDURE Assunto_Obter_Resumo
AS

/*
[Assunto_Obter_Resumo] Procedure para obter resumo de assunto e quantidade que foram tratados

TIME                        QUEM                      QUANDO                 DESCRIÇÃO
=======================================================================================

Desenvolvimento         Willian Braga               18-05-2021                 Criação

=======================================================================================

*/

BEGIN
    SELECT
        assun.Descricao,
        count(*) as Quantidade
    FROM Assunto assun
        INNER JOIN Mensagem mens ON mens.IdAssunto = assun.Id
    GROUP by assun.Descricao
END

GO