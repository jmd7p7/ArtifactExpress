

CREATE TABLE STORAGE_REQUIREMENT (
     StorageRequirementID    int primary key identity,
     Type varchar(70)
)

CREATE TABLE ARTIST  (
     ArtistID     int primary key identity,
     ArtistName    varchar(100)
)

CREATE TABLE COUNTRY
(
     CountryID int primary key identity,
     CountryName varchar(100)
)

CREATE TABLE TREATMENT_TECHNIQUE
(
     TreatmentTechniqueID int primary key identity,
     TechniqueName varchar(100),
     TechniqueDescription varchar(500)
)

CREATE TABLE TREATMENT_TOOL
( 
     ToolID int primary key identity,
     ToolName varchar(70)
)

CREATE TABLE TREATMENT_REGIMEN
(
     TreatmentRegimenID int primary key identity,
     TreatmentName varchar(100),
     TreatmentDescription varchar(500),
     TreatmentCost dec(7,2)
     constraint ValidCost check (TreatmentCost > 0)
)

CREATE TABLE TEST
(
     TestID int primary key identity,
     TestName varchar(100)
)

CREATE TABLE PHOTOGRAPH
(
     PhotographID int primary key identity,
     Flickr_URL varchar(300)
)

CREATE TABLE ARTIFACT_TYPE
(
     ArtifactTypeID int primary key identity,
     ArtifactTypeName varchar(70)
)

CREATE TABLE LOCATION
(
     LocationID int primary key identity,
     FloorNumber int not null,
     RoomNumber int not null,
     DisplayOrStorage char(1),
     constraint floorValidation check (FloorNumber between 1 and 4),
     constraint RoomValidation check (RoomNumber between 100 and 499),
     constraint DisplayStorageValidation check (DisplayOrStorage = 'D' OR DisplayOrStorage = 'd' OR DisplayOrStorage = 'S' OR DisplayOrStorage = 's')
)

CREATE TABLE TIME_PERIOD
(
     TimePeriodID int primary key identity,
     TimePeriodName varchar(70) not null,
     BeginningYear int not null,
     EndingYear int not null,
     constraint ValidateYears check (EndingYear > BeginningYear)
)

CREATE TABLE MUSEUM
(
     MuseumID int primary key identity,
     MuseumName varchar (100) not null
)

CREATE TABLE EXHIBIT
(
     ExhibitID int primary key identity,
     ExhibitName varchar (100) not null,
     ExhibitDescription varchar(500),
     BeginningDate date,
     EndingDate date, 
     CollectionID int, 
     LocationID int default 1,
     constraint LocationFK foreign key (LocationID) references LOCATION (LocationID) 
          on delete set default,
     constraint CollectionFK foreign key (CollectionID) references COLLECTION (CollectionID)

CREATE TABLE EXHIBIT
(
     ExhibitID int primary key identity,
     ExhibitName varchar (100) not null,
     ExhibitDescription varchar(500),
     BeginningDate date,
     EndingDate date, 
     CollectionID int, 
     LocationID int default 1,
     constraint LocationFK foreign key (LocationID) references LOCATION (LocationID) 
          on delete set default,
     constraint CollectionFK foreign key (CollectionID) references COLLECTION (CollectionID)
          on delete casecade
)

CREATE TABLE COLLECTION
(
     CollectionID int primary key identity,
     CollectionName varchar (100) not null,
     CollectionDescription varchar (500),
     TimePeriodID int default 1, 
     CountryID int default 1,
     constraint TimePeriodFK foreign key (TimePeriodID) references TIME_PERIOD (TimePeriodID)
           on delete set default,
     constraint CountryFK foreign key (CountryID) references COUNTRY (CountryID)
           on delete set default
)

CREATE TABLE ARTIFACT
(
     ArtifactID int primary key identity,
     ArtifactName varchar (100) not null,
     DescriptionSummary varchar (500),
     AppraisedValue dec (11,2),
     InsuredValue dec (11,2),
     TimePeriodID int default 1,
     LocationID int default 1, 
     CountryID int default 1, 
     ArtifactTypeID int default 1,
     constraint ArtifactTimePeriodFK foreign key (TimePeriodID) references TIME_PERIOD (TimePeriodID) 
           on delete set default,
     constraint ArtifactLocationFK foreign key (LocationID) references LOCATION (LocationID) 
           on delete set default,
     constraint ArtifactCountryFK foreign key (CountryID) references COUNTRY (CountryID)
           on delete set default,
     constraint ArtifactArtifactTypeK foreign key (ArtifactTypeID) references ARTIFACT_TYPE (ArtifactTypeID)
           on delete set default,
     constraint ValidateAppraisedValue check (AppraisedValue > 0),
     constraint ValidateInsuredValue check (InsuredValue > 0)
)

CREATE TABLE ARTIFACT_PRESERVATION
(
     ArtifactPreservationID int primary key identity,
     Authenticated char(1) default 'N',
     InitialCondition varchar (500),
     constraint AuthenticatedValidation check (Authenticated = 'Y' OR Authenticated = 'y' OR Authenticated = 'N' OR Authenticated ='n')
)

CREATE TABLE TOOL
(
     ToolID int primary key identity,
     ToolName varchar(70) not null
)


-- THE FOLLOWING ARE ALL RELATIONSHIP TABLES -- 

CREATE TABLE IN_COLLLECTION
(
     ArtifactID int primary key not null,
     CollectionID int not null,
     constraint InCollectionArtifactFK foreign key (ArtifactID) references Artifact (ArtifactID)
          on delete cascade,
     constraint InCollectionCollectionFK foreign key (CollectionID) references Collection (CollectionID)
          on delete cascade
)

CREATE TABLE HAS_STORAGE_REQUIREMENT
(
     ArtifactID int not null,
     StorageRequirementID int not null,
     constraint HasStorageRequirementPK primary key (ArtifactID, StorageRequirementID),
     constraint HasStorageRequirementArtifactFK foreign key (ArtifactID) references artifact (ArtifactID)
          on delete cascade,
     constraint HasStorageRequirementStorageRequirement foreign key (StorageRequirementID) references STORAGE_REQUIREMENT (StorageRequirementID)
          on delete cascade
)

CREATE TABLE VISUAL_RECORD
(
     ArtifactID int not null,
     PhotographID int primary key not null,
     constraint VisualRecordArtifactFK foreign key (ArtifactID) references Artifact (ArtifactID)
           on delete cascade,
     constraint VisualRecordPhotographFK foreign key (PhotographID) references Photograph (PhotographID)
           on delete cascade
)

CREATE TABLE HAS_ARTIST
(
     ArtifactID int primary key not null,
     ArtistID int not null,
     constraint HasArtistArtistFK foreign key (ArtistID) references Artist (ArtistID)
           on delete cascade,
     constraint HasArtistArtifactFK foreign key (ArtifactID) references Artifact (ArtifactID)
           on delete cascade
)

CREATE TABLE IN_LOCATION
(
     ArtifactID int primary key not null,
     LocationID int not null,
     constraint InLocationArtifactFK foreign key (ArtifactID) references Artifact (ArtifactID),
     constraint InLocationLocationFK foreign key (LocationID) references Location (LocationID) 
)

CREATE TABLE LOCATION_OF_EXHIBIT
(
     ExhibitID int primary key not null, 
     LocationID int not null,
     constraint LocationOfExhibitExhibitFK foreign key (ExhibitID) references Exhibit (ExhibitID) 
            on delete cascade,
     constraint LocationOfExhibitLocationFK foreign key (LocationID) references Location (LocationID)    
)

CREATE TABLE HAS_PRESERVATION
(
     ArtifactID int not null,
     ArtifactPreservationID int not null,
     constraint HasPreservationPK primary key (ArtifactID, ArtifactPreservationID),
     constraint HasPreservationArtifactFK foreign key (ArtifactID) references Artifact (ArtifactID)
         on delete cascade,
     constraint HasPreservationArtifactPreservationFK foreign key (ArtifactPreservationID) references ARTIFACT_PRESERVATION (ArtifactPreservationID)
)

CREATE TABLE TEST_USED
(
     ArtifactPreservationID int not null,
     TestID int not null default 1,
     TestDate Date default '1/1/2011',
     constraint TestUsedPK primary key (ArtifactPreservationID, TestID),
     constraint TestUsedArtifactPreservationFK foreign key (ArtifactPreservationID) references Artifact_Preservation (ArtifactPreservationID)
          on delete cascade,
     constraint TestUsedTestFK foreign key (TestID) references Test (TestID)
          on delete set default 
)

CREATE TABLE TREATMENT_REGIMEN_USED
(
     ArtifactPreservationID int not null,
     TreatmentRegimenID int not null default 1,
     TreatmentDate Date default '1/1/2011',
     constraint TreatmentRegimenPK primary key (ArtifactPreservationID, TreatmentRegimenID),
     constraint TreatmentRegimenUsedArtifactPreservationFK foreign key (ArtifactPreservationID) references Artifact_Preservation (ArtifactPreservationID)
          on delete cascade,
     constraint TreatmentRegimenUsedTreatmentRegimenFK foreign key (TreatmentRegimenID)references Treatment_Regimen (TreatmentRegimenID)
          on delete set default 
)

CREATE TABLE TOOLS_USED_IN_TREATMENT
(
     TreatmentRegimenID int not null,
     ToolID int not null default 1,
     constraint ToolsUsedInTreatmentPK primary key (TreatmentRegimenID, ToolID),
     constraint ToolsUsedInTreatmentTreatmentRegimenFK foreign key (TreatmentRegimenID) references Treatment_Regimen(TreatmentRegimenID)
          on delete cascade,
     constraint ToolsUsedInTreatmentToolFK foreign key (ToolID) references TOOL (ToolID)
          on delete set default 
)



CREATE TABLE TOOLS_USED_IN_TEST
(
     TestID int not null,
     ToolID int not null default 1,
     constraint ToolsUsedInTestPK primary key (TestID, ToolID),
     constraint ToolsUsedInTestTestFK foreign key (TestID) references Test (TestID)
          on delete cascade,
     constraint ToolsUsedInTestToolFK foreign key (ToolID) references TOOL (ToolID)
          on delete set default 
)

CREATE TABLE TECHNIQUE_USED_IN_TREATMENT
(
     TreatmentRegimenID int not null,
     TreatmentTechniqueID int not null default 1,
     constraint TechniqueUsedInTreatmentPK primary key (TreatmentRegimenID,  TreatmentTechniqueID),
     constraint TechiniqueUsedTreatmentRegimenFK foreign key (TreatmentRegimenID) references Treatment_Regimen (TreatmentRegimenID)
          on delete cascade,
     constraint TechniqueUsedTechniqueFK foreign key (TreatmentTechniqueID) references Treatment_Technique (TreatmentTechniqueID)
          on delete set default
)


CREATE TABLE TECHNIQUE_USED_IN_TEST
(
     TestID int not null,
     TreatmentTechniqueID int not null default 1,
     constraint TechniqueUsedInTestPK primary key (TestID, TreatmentTechniqueID),
     constraint TechiniqueUsedInTestTreatmentTechniqueFK foreign key (TreatmentTechniqueID) references Treatment_Technique (TreatmentTechniqueID)
          on delete set default,
     constraint TechiniqueUsedInTestTestFK foreign key (TestID) references Test (TestID)
          on delete cascade
)

CREATE TABLE BORROWED_LOG
(
     ArtifactID int not null,
     MuseumID int not null,
     DateBorrowed Date not null,
     DateReturned Date,
     constraint BorrowedLogPK primary key (ArtifactID, MuseumID, DateBorrowed),
     constraint DateValidation check ( DateReturned > DateBorrowed),
     constraint BorrowedLogArtifactFK foreign key (ArtifactID) references Artifact (ArtifactID)
           on delete cascade,
     constraint BorrowedLogMuseumFK foreign key (MuseumID) references Museum (MuseumID)
           on delete cascade
)

CREATE TABLE LOANED_LOG
(
     ArtifactID int not null,
     MuseumID int not null,
     DateLoaned Date not null,
     DateReturned Date,
     constraint LoanedLogPK primary key (ArtifactID, MuseumID, DateLoaned),
     constraint LoanedDateValidation check ( DateReturned > DateLoaned),
     constraint LoanedLogArtifactFK foreign key (ArtifactID) references Artifact (ArtifactID)
           on delete cascade,
     constraint LoanedLogMuseumFK foreign key (MuseumID) references Museum (MuseumID)
           on delete cascade
)