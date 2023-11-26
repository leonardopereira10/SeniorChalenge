select
	Numero as 'Numero do processo',
 	p.Nome as 'Fornecedor',
 	DataVencimento as 'Data de vencimento',
 	DataPagamento as 'Data de pagamento',
	Valor as 'Valor líquido',
	Pago as 'Está pago?' 
from
	(select Numero, CodigoFornecedor, DataVencimento, DataPagamento, Valor, Pago from
		(
			select
				Numero,
				CodigoFornecedor, 
				case when DataProrrogacao = null
					then DataVencimento 
					else DataProrrogacao 
				end as DataVencimento,
				NULL as DataPagamento,
				(ContasAPagar.Valor+Acrescimo-Desconto) as Valor,
				'Não' as Pago 
			from ContasAPagar
			union
			select 
				Numero, 
				CodigoFornecedor, 
				DataVencimento, 
				DataPagamento, 
				(ContasPagas.Valor+Acrescimo-Desconto) as Valor, 
				'Sim' as Pago 
			from ContasPagas
		) ContasAux
	) Contas
	left join Pessoas p 
		on p.Codigo = Contas.CodigoFornecedor;