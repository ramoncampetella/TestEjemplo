Feature: HomeDiario
	Validar que la home del diario se carga.

@checkHome
Scenario: Check home diario
	Given Ingreso la direccion del sitio del diario
	When Sin cargar ningun dato
	Then Visualizo la portada y veo el logo del diario.
