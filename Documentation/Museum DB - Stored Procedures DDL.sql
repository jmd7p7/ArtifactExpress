CREATE PROCEDURE GET_COLLECTION @CollectionName varchar(70) = 'King Tut'
AS
SELECT C.CollectionName as 'Collection', A.ArtifactName as 'Artifact'
     FROM Artifact as A
     INNER JOIN (IN_COLLECTION as IC INNER JOIN COLLECTION AS C ON IC.CollectionID = C.CollectionID)
     ON IC.ArtifactID = A.ArtifactID
     WHERE C.CollectionName = @CollectionName

exec GET_COLLECTION @CollectionName = 'King Tut'

--------------------------------------------------------------------------------

CREATE PROCEDURE GET_BORROWED_ARTIFACTS @MuseumName varchar(70) = 'Louvre'
AS
SELECT M.MuseumName as 'Museum', A.ArtifactName as 'Artifact'
     FROM Artifact as A
     INNER JOIN (BORROWED_LOG as BL INNER JOIN Museum as M ON BL.MuseumID = M. MuseumID)
     on A.ArtifactID = BL.ArtifactID
     WHERE M.MuseumName = @MuseumName

exec GET_BORROWED_ARTIFACTS @MuseumName = 'Louvre'

----------------------------------------------------------------------------------

CREATE PROCEDURE GET_LOANED_ARTIFACTS @MuseumName varchar(70) = 'Smithsonian'
AS
SELECT M.MuseumName as 'Museum', A.ArtifactName as 'Artifact'
     FROM Artifact as A
     INNER JOIN (LOANED_LOG as LL INNER JOIN Museum as M ON LL.MuseumID = M. MuseumID)
     on A.ArtifactID = LL.ArtifactID
     WHERE M.MuseumName = @MuseumName

exec GET_LOANED_ARTIFACTS @MuseumName = 'Smithsonian'

------------------------------------------------------------------------------------

CREATE PROCEDURE GET_ARTIFACT_LOCATION @ArtifactName varchar(70)
AS
SELECT A.ArtifactName as 'Artifact', L.RoomNumber as 'Room', L.FloorNumber as 'Floor'
   FROM Artifact as A
   INNER JOIN LOCATION as L on A.LocationID = L.LocationID
   WHERE A.ArtifactName = @ArtifactName

exec GET_ARTIFACT_LOCATION @ArtifactName = 'Mona Lisa'

--------------------------------------------------------------------------------------
CREATE PROCEDURE GET_ARTIFACT_DESCRIPTION @ArtifactName varchar(70)
AS 
SELECT A.ArtifactName as 'Artifact', A.DescriptionSummary as 'Description'
    FROM Artifact as A
    WHERE A.ArtifactName = @ArtifactName

exec GET_ARTIFACT_DESCRIPTION @ArtifactName = 'Mona Lisa'

---------------------------------------------------------------------------------------

CREATE PROCEDURE APPRAISED_VALUE_GREATER_THAN @Value dec (11,2)
AS
SELECT A.ArtifactName as 'Artifact', A.AppraisedValue as 'Appraised Value'
   FROM Artifact as A
   WHERE A.AppraisedValue > @Value

exec APPRAISED_VALUE_GREATER_THAN @Value = 10000

------------------------------------------------------------------------------------------

CREATE PROCEDURE FROM_TIME_PERIOD @TimePeriod varchar(50)
AS
SELECT A.ArtifactName as 'Artifact', TP.TimePeriodName as 'Time Period'
   FROM Artifact as A INNER JOIN Time_Period as TP on A.TimePeriodID = TP.TimePeriodID
   WHERE TP.TimePeriodName = @TimePeriod

exec FROM_TIME_PERIOD @TimePeriod = 'Mid-Modern'

--------------------------------------------------------------------------------------------

CREATE PROCEDURE BORROW_AN_ARTIFACT @ArtifactID varchar(70), @MuseumID varchar(70), @DateBorrowed date, @DateReturned date
AS
INSERT INTO BORROWED_LOG values(@ArtifactID, @MuseumID, @DateBorrowed, @DateReturned)


exec BORROW_AN_ARTIFACT @ArtifactID = 13, @MuseumID =2, @DateBorrowed = '2/21/2013', @DateReturned ='3/25/2015'

----------------------------------------------------------------------------------------------------

CREATE PROCEDURE LOAN_AN_ARTIFACT @ArtifactID varchar(70), @MuseumID varchar(70), @DateLoaned date, @DateReturned date
AS
INSERT INTO LOANED_LOG values(@ArtifactID, @MuseumID, @DateLoaned, @DateReturned)


exec LOAN_AN_ARTIFACT @ArtifactID = 13, @MuseumID = 2, @DateLoaned = '2/21/2013', @DateReturned ='3/25/2015'

----------------------------------------------------------------------------------------------------------



CREATE PROCEDURE GET_ALL_TOOLS_USED_IN_TEST @artifactName VARCHAR(50) = "Artifact Name"
as
SELECT Artifact.ArtifactName, Treatment_Tool.ToolName
FROM Treatment_Tool INNER JOIN (Tools_Used_In_Test INNER JOIN (Test INNER JOIN (Test_Used INNER JOIN (Artifact_Preservation INNER JOIN (Has_Preservation Inner JOIN Artifact on Has_Preservation.ArtifactID = Artifact.ArtifactID) 
on Artifact_Preservation.ArtifactPreservationID = Has_Preservation.ArtifactPreservationID) on Test_Used.ArtifactPreservationID=Artifact_Preservation.ArtifactPreservationID) 
on Test.TestId=Test_Used.TestID) on Tools_Used_In_Test.TestID=Test.TestID) on Treatment_Tool.ToolID = Tools_Used_In_Test.ToolID
WHERE ArtifactName = @artifactName
 
exec GET_ALL_TOOLS_USED_IN_TEST @artifactName = 'Mona Lisa'

---------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE GET_AUTHENTICATION @artifactName VARCHAR(50) = "Artifact Name"
as
SELECT Artifact.ArtifactName, Artifact_Preservation.Authenticated
FROM Artifact_Preservation INNER JOIN (Has_Preservation Inner JOIN Artifact on Has_Preservation.ArtifactID = Artifact.ArtifactID) on Artifact_Preservation.ArtifactPreservationID = Has_Preservation.ArtifactPreservationID
WHERE ArtifactName = @artifactName

exec GET_AUTHENTICATION @artifactName = 'Mona Lisa'

