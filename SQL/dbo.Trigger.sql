CREATE TRIGGER Trigger_Historia_Studenci
ON [dbo].[Studenci]
FOR DELETE, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS(SELECT * FROM deleted)
    BEGIN
        -- INSERT INTO Historia  DELETE 
        INSERT INTO Historia (Imie, Nazwisko, IdGrupy, TypAkcji, DateTime)
        SELECT d.Imie, d.Nazwisko, d.IdGrupy, 1 , GETDATE()
        FROM deleted AS d;
    END;

    IF EXISTS(SELECT * FROM inserted)
    BEGIN
        -- INSERT INTO Historia UPDATE 
        INSERT INTO Historia (Imie, Nazwisko, IdGrupy, TypAkcji, DateTime)
        SELECT i.Imie, i.Nazwisko, i.IdGrupy,0, GETDATE()
        FROM inserted AS i
        WHERE NOT EXISTS(SELECT 1 FROM deleted AS d WHERE d.Id = i.Id);
    END;
END;