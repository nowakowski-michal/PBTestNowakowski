CREATE PROCEDURE [dbo].[GetHistoryPaginated]
	@Offset int ,
	@PageSize int
AS
BEGIN
SELECT h.Id, h.Imie, h.Nazwisko, g.Nazwa, h.DateTime, h.TypAkcji FROM Historia h LEFT JOIN Grupy g ON h.IdGrupy = g.Id ORDER BY h.Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
END;


