CREATE PROCEDURE Conversa_Obter_PorDocumentoCliente
    @DocumentoCliente VARCHAR(30)
AS

/*
[Conversa_ObterPorDocumentoCliente] Procedure para obter conversas de clientes por documento

TIME                        QUEM                      QUANDO                 DESCRIÇÃO
=======================================================================================

Desenvolvimento         Willian Braga               18-05-2021                 Criação

=======================================================================================

*/

BEGIN
    SELECT
        con.Id,
        con.IdTipoConversa,
        con.IdCliente,
        con.DataInicio,
        con.DataFim
    FROM Conversa con
        INNER JOIN Cliente clie ON con.IdCliente = clie.Id
    WHERE 	clie.Documento = @DocumentoCliente
END

GO