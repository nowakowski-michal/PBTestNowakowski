CREATE PROCEDURE [dbo].[AddStudent]
	@Imie varchar(50),
	@Nazwisko varchar(50),
	@IdGrupy int = null  -- dlaczego null bo w poleceniu jest opcjonalnosc
AS
BEGIN
 SET NOCOUNT ON;
INSERT INTO Studenci VALUES (@Imie, @Nazwisko, @IdGrupy); 
SELECT TOP 1 s.Id, s.Imie, s.Nazwisko, gr.Nazwa FROM Studenci s JOIN Grupy gr ON gr.Id = s.IdGrupy ORDER BY s.Id DESC;
END;