CREATE PROCEDURE Cliente_Obter_PorAssunto
    @IdAssunto int
AS

/*
[Cliente_Obter_PorAssunto] Procedure para obter clientes por IdAssunto

TIME                        QUEM                      QUANDO                 DESCRIÇÃO
=======================================================================================

Desenvolvimento         Willian Braga               18-05-2021                 Criação

=======================================================================================

*/

BEGIN
    SELECT
        clie.Id,
        clie.Nome,
        clie.Email
    FROM Cliente clie
        INNER JOIN Conversa con ON clie.Id = con.IdCliente
        INNER JOIN Mensagem mens ON con.Id = mens.IdConversa
    WHERE mens.IdAssunto = @IdAssunto
END

GO