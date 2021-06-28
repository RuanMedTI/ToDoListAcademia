insert into TBCompromissos 
	(
		[Assunto], 
		[Local], 
		[DataCompromisso],
		[HoraInicio],
		[DataTermino]
	) 
	values 
	(
		'Reunião sobre novo parceiro',
		'Café das Dez',
		'07/10/2021',
		'Dez da manha',
		'07/10/2021'
	)

update TBCompromissos 
	set	
		[Assunto] = 'Reunião sobre novo parceiro master', 
		[Local] ='Café das Dez', 
		[DataCompromisso] = '07/10/2021',
		[HoraInicio] = 'Dez e meia da manha',
		[DataTermino] = '07/10/2021'
	where 
		[Id] = 1

Delete from TBCompromissos 
	where 
		[Id] = 1


select * from TBCompromissos