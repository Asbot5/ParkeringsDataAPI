CREATE OR ALTER TRIGGER SpecielleParkingsPladserToParkingsområde
ON SpecielleParkeringsPladser
AFTER UPDATE
AS BEGIN
	DECLARE @OmrådeId INT;
	DECLARE @PreOptagedePladser INT;
	DECLARE @PostOptagedePladser INT;
	SELECT @OmrådeId = OmrådeId FROM INSERTED;
	SELECT @PreOptagedePladser = OptagedePladser FROM DELETED;
	SELECT @PostOptagedePladser = OptagedePladser FROM INSERTED;

	UPDATE Parkeringsområde
	SET OptagedePladser = OptagedePladser + (@PostOptagedePladser - @PreOptagedePladser)
	WHERE Id = @OmrådeId
END;