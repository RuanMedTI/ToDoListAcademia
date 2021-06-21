insert into TBContatos 
	(
		[Nome], 
		[E-mail], 
		[Telefone],
		[Empresa],
		[Cargo]
	) 
	values 
	(
		'Carlos Vitor da Costa',
		'carloscontato@empresa.com',
		33210891,
		'Carlos Finanças',
		'Presidente'
	)

update TBContatos 
	set	
		[Nome] = 'Carlos Vitor Costa', 
		[E-mail]='carloscontato@empresa.com', 
		[Telefone] = 33210891,
		[Empresa] = 'Carlos Finanças',
		[Cargo] = 'CEO'
	where 
		[Id] = 1

Delete from TBContatos 
	where 
		[Id] = 1

select * from TBContatos