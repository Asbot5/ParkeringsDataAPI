CREATE OR ALTER TRIGGER LogToParkingsområde
ON Log
AFTER INSERT
AS BEGIN
	DECLARE @OmrådeId INT;
	DECLARE @Retning BIT;
	SELECT @OmrådeId = OmrådeId FROM INSERTED;
	SELECT @Retning = Retning FROM INSERTED;

	IF @Retning = 0
		UPDATE Parkeringsområde
		SET OptagedePladser = OptagedePladser + 1
		WHERE Id = @OmrådeId
	ELSE 
		UPDATE Parkeringsområde
		SET OptagedePladser = OptagedePladser - 1
		WHERE Id = @OmrådeId
END;