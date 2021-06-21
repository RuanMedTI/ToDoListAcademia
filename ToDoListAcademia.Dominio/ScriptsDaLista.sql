insert into TBLista 
	(
		[Titulo], 
		[DataCriacao], 
		[DataConclusao],
		[Prioridade],
		[Percentual]
	) 
	values 
	(
		'Arrumar o quarto no fim de semana',
		'06/20/2021',
		'06/21/2021',
		'Alta'
	)

update TBLista 
	set	
		[Titulo] = 'Arrumar o quarto o mais rápido possível', 
		[DataCriacao]='06/20/2021', 
		[DataConclusao] = '06/21/2021',
		[Prioridade] = 'Baixa'
	where 
		[Id] = 1

Delete from TBLista 
	where 
		[Id] = 1


select * from TBLista