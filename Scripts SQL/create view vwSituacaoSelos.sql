create view vwSituacaoSelos as
SELECT     s.nrSelo, t.dsTipoSelo, s.dtLancamento, s.dtAtribuicao, s.dsLogin, s.stSelo, i.nrPedido,
                          (SELECT     dtPedido
                            FROM          dbo.tblPedidos AS p
                            WHERE      (nrPedido = i.nrPedido)) AS dtPedido,
                          (SELECT     stPedido
                            FROM          dbo.tblPedidos AS p
                            WHERE      (nrPedido = i.nrPedido)) AS stPedido,
                          (SELECT     nmCartao
                            FROM          dbo.tblCartaoAssinatura AS c
                            WHERE      (nrCartao = i.nrCartao)) AS nmCartao, i.vlItem,
                          (SELECT     dsAto
                            FROM          dbo.tblAtosOperacoes AS a
                            WHERE      (cdAto = i.cdAto)) AS dsAto, t.cdTipoSelo, t.cdTipoDocumento
FROM         dbo.tblSelos AS s INNER JOIN
                      dbo.tblTipoSelo AS t ON s.cdTipoSelo = t.cdTipoSelo LEFT OUTER JOIN
                      dbo.tblItensPedido AS i ON i.nrSelo = s.nrSelo AND i.cdTipoSelo = s.cdTipoSelo