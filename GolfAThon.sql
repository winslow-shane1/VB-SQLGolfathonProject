-- --------------------------------------------------------------------------------
-- Name: Shane Winslow
-- Class: IT-102
-- Abstract: Stored Procedures
-- --------------------------------------------------------------------------------

-- --------------------------------------------------------------------------------
-- Options
-- --------------------------------------------------------------------------------
USE dbSQL1;     -- Get out of the master database
SET NOCOUNT ON; -- Report only errors

-- --------------------------------------------------------------------------------
-- Drop Tables
-- --------------------------------------------------------------------------------
IF OBJECT_ID( 'TGolferEventYearSponsors' )		IS NOT NULL DROP TABLE	TGolferEventYearSponsors
IF OBJECT_ID( 'TSponsors' )						IS NOT NULL DROP TABLE	TSponsors
IF OBJECT_ID( 'TSponsorTypes' )					IS NOT NULL DROP TABLE	TSponsorTypes
IF OBJECT_ID( 'TPaymentTypes' )					IS NOT NULL DROP TABLE	TPaymentTypes
IF OBJECT_ID( 'TGolferEventYears' )				IS NOT NULL DROP TABLE	TGolferEventYears
IF OBJECT_ID( 'TEventYears' )					IS NOT NULL DROP TABLE	TEventYears
IF OBJECT_ID( 'TGolfers' )						IS NOT NULL DROP TABLE	TGolfers
IF OBJECT_ID( 'TGenders' )						IS NOT NULL DROP TABLE	TGenders
IF OBJECT_ID( 'TShirtSizes' )					IS NOT NULL DROP TABLE	TShirtSizes

-- ---------------------------------------------------------------------------------
-- Drop Procedure Statements
-- ---------------------------------------------------------------------------------
IF OBJECT_ID( 'uspAddGolfer' )					IS NOT NULL DROP PROCEDURE	uspAddGolfer
IF OBJECT_ID( 'uspAddEvent' )					IS NOT NULL DROP PROCEDURE	uspAddEvent
IF OBJECT_ID( 'uspAddSponsor' )					IS NOT NULL DROP PROCEDURE	uspAddSponsor
IF OBJECT_ID( 'uspAddGolferEvent' )				IS NOT NULL DROP PROCEDURE	uspAddGolferEvent
IF OBJECT_ID( 'uspAddGolferEventYearSponsor' )	IS NOT NULL DROP PROCEDURE	uspAddGolferEventYearSponsor

-- ---------------------------------------------------------------------------------
-- Drop Database Views
-- ---------------------------------------------------------------------------------
IF OBJECT_ID( 'vAvailableGolfers' )				IS NOT NULL DROP VIEW	vAvailableGolfers
IF OBJECT_ID( 'vEventGolfers' )					IS NOT NULL DROP VIEW	vEventGolfers
IF OBJECT_ID( 'vSponsors' )						IS NOT NULL DROP VIEW	vSponsors
IF OBJECT_ID( 'vAllSponsors' )					IS NOT NULL DROP VIEW	vAllSponsors
IF OBJECT_ID( 'vSponsorshipsGolfer' )			IS NOT NULL DROP VIEW	vSponsorshipsGolfer
IF OBJECT_ID( 'vSponsorshipTotalCollected' )	IS NOT NULL DROP VIEW	vSponsorshipTotalCollected
IF OBJECT_ID( 'vSponsorshipTotalSponsored' )	IS NOT NULL DROP VIEW	vSponsorshipTotalSponsored
IF OBJECT_ID( 'vEventTotal' )					IS NOT NULL DROP VIEW	vEventTotal
IF OBJECT_ID( 'vParticipatingSponsors' )		IS NOT NULL DROP VIEW	vParticipatingSponsors

-- --------------------------------------------------------------------------------
-- Step #1: Create Tables
-- --------------------------------------------------------------------------------
CREATE TABLE TEventYears
(
	 intEventYearID					INTEGER				NOT NULL
	,intEventYear					INTEGER				NOT NULL
	,CONSTRAINT TEventYears_PK PRIMARY KEY ( intEventYearID	)
)

CREATE TABLE TGenders
(
	 intGenderID					INTEGER					NOT NULL
	,strGenderDesc					VARCHAR(50)				NOT NULL
	,CONSTRAINT TGenders_PK PRIMARY KEY ( intGenderID )
)

CREATE TABLE TShirtSizes
(
	 intShirtSizeID					INTEGER					NOT NULL
	,strShirtSizeDesc				VARCHAR(50)				NOT NULL
	,CONSTRAINT TShirtSizes_PK PRIMARY KEY ( intShirtSizeID )
)

CREATE TABLE TGolfers
(
	 intGolferID					INTEGER					NOT NULL
	,strFirstName					VARCHAR(50)				NOT NULL
	,strLastName					VARCHAR(50)				NOT NULL
	,strStreetAddress				VARCHAR(50)				NOT NULL
	,strCity						VARCHAR(50)				NOT NULL
	,strState						VARCHAR(50)				NOT NULL
	,strZip							VARCHAR(50)				NOT NULL
	,strPhoneNumber					VARCHAR(50)				NOT NULL
	,strEmail						VARCHAR(50)				NOT NULL
	,intShirtSizeID					INTEGER					NOT NULL
	,intGenderID					INTEGER					NOT NULL
	,CONSTRAINT TGolfers_PK PRIMARY KEY ( intGolferID )
)

CREATE TABLE TSponsors
(
	 intSponsorID					INTEGER					NOT NULL
	,strFirstName					VARCHAR(50)				NOT NULL
	,strLastName					VARCHAR(50)				NOT NULL
	,strStreetAddress				VARCHAR(50)				NOT NULL
	,strCity						VARCHAR(50)				NOT NULL
	,strState						VARCHAR(50)				NOT NULL
	,strZip							VARCHAR(50)				NOT NULL
	,strPhoneNumber					VARCHAR(50)				NOT NULL
	,strEmail						VARCHAR(50)				NOT NULL
	,CONSTRAINT TSponsors_PK PRIMARY KEY ( intSponsorID )
)

CREATE TABLE TPaymentTypes
(
	 intPaymentTypeID				INTEGER					NOT NULL
	,strPaymentTypeDesc				VARCHAR(50)				NOT NULL
	,CONSTRAINT TPaymentTypes_PK PRIMARY KEY ( intPaymentTypeID )
)

CREATE TABLE TGolferEventYears
(
	 intGolferEventYearID			INTEGER					NOT NULL
	,intGolferID					INTEGER					NOT NULL
	,intEventYearID					INTEGER					NOT NULL
	,CONSTRAINT TGolferEventYears_UQ UNIQUE ( intGolferID, intEventYearID )
	,CONSTRAINT TGolferEventYears_PK PRIMARY KEY ( intGolferEventYearID )
)


CREATE TABLE TGolferEventYearSponsors
(
	 intGolferEventYearSponsorID	INTEGER					NOT NULL
	,intGolferID					INTEGER					NOT NULL
	,intEventYearID					INTEGER					NOT NULL
	,intSponsorID					INTEGER					NOT NULL
	,monPledgeAmount				MONEY					NOT NULL
	,intSponsorTypeID				INTEGER					NOT NULL
	,intPaymentTypeID				INTEGER					NOT NULL
	,blnPaid						BIT						NOT NULL
	,CONSTRAINT TGolferEventYearSponsors_UQ UNIQUE ( intGolferID, intEventYearID, intSponsorID )
	,CONSTRAINT TGolferEventYearSponsors_PK PRIMARY KEY ( intGolferEventYearSponsorID )
)

CREATE TABLE TSponsorTypes
(
	 intSponsorTypeID				INTEGER					NOT NULL
	,strSponsorTypeDesc				VARCHAR(50)				NOT NULL
	,CONSTRAINT TSponsorTypes_PK PRIMARY KEY ( intSponsorTypeID )
)


-- --------------------------------------------------------------------------------
-- Step #2: Identify and Create Foreign Keys
-- --------------------------------------------------------------------------------
--
-- #	Child							Parent						Column(s)
-- -	-----							------						---------
-- 1	TGolfers						TGenders					intGenderID
-- 2	TGolfers						TShirtSizes					intShirtSizeID
-- 3    TGolferEventYears				TGolfers					intGolferID
-- 4	TGolferEventYearSponsors		TGolferEventYears			intGolferID, intEventYearID
-- 5	TGolferEventYears				TEventYears					intEventYearID
-- 6    TGolferEventYearSponsors		TSponsors					intSponsorID
-- 7	TGolferEventYearSponsors		TSponsorTypes				intSponsorTypeID
-- 8	TGolferEventYearSponsors		TPaymentTypes				intPaymentTypeID

-- 1
ALTER TABLE TGolfers ADD CONSTRAINT TGolfers_TGenders_FK
FOREIGN KEY ( intGenderID ) REFERENCES TGenders ( intGenderID )

-- 2
ALTER TABLE TGolfers ADD CONSTRAINT TGolfers_TShirtSizes_FK
FOREIGN KEY ( intShirtSizeID ) REFERENCES TShirtSizes ( intShirtSizeID )

-- 3
ALTER TABLE TGolferEventYears ADD CONSTRAINT TGolferEventYears_TGolfers_FK
FOREIGN KEY ( intGolferID ) REFERENCES TGolfers ( intGolferID )

-- 4
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TGolferEventYears_FK
FOREIGN KEY ( intGolferID, intEventYearID ) REFERENCES TGolferEventYears ( intGolferID, intEventYearID )

-- 5
ALTER TABLE TGolferEventYears ADD CONSTRAINT TGolferEventYears_TEventYears_FK
FOREIGN KEY ( intEventYearID ) REFERENCES TEventYears ( intEventYearID )

-- 6
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TSponsors_FK
FOREIGN KEY ( intSponsorID ) REFERENCES TSponsors ( intSponsorID )

-- 7
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TSponsorTypes_FK
FOREIGN KEY ( intSponsorTypeID ) REFERENCES TSponsorTypes ( intSponsorTypeID )

-- 8
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TPaymentTypes_FK
FOREIGN KEY ( intPaymentTypeID ) REFERENCES TPaymentTypes ( intPaymentTypeID )

-- --------------------------------------------------------------------------------
-- Step #3: Add data to Gender
-- --------------------------------------------------------------------------------

INSERT INTO TGenders( intGenderID, strGenderDesc)
VALUES		(1, 'Female')
		,(2, 'Male')

---- --------------------------------------------------------------------------------
---- Step #4: Add men's and women's shirt sizes
---- --------------------------------------------------------------------------------

INSERT INTO TShirtSizes( intShirtSizeID, strShirtSizeDesc)
VALUES		(1, 'Mens Small')
		,(2, 'Mens Medium')
		,(3, 'Mens Large')
		,(4, 'Mens XLarge')
		,(5, 'Womens Small')
		,(6, 'Womens Medium')
		,(7, 'Womens Large')
		,(8, 'Womens XLarge')

---- --------------------------------------------------------------------------------
---- Step #5: Add years
---- --------------------------------------------------------------------------------
INSERT INTO TEventYears ( intEventYearID, intEventYear )
	VALUES	 ( 1, 2018)
		,( 2, 2019)
		,(3, 2020)

---- --------------------------------------------------------------------------------
---- Step #6: Add sponsor types
---- --------------------------------------------------------------------------------
INSERT INTO TSponsorTypes ( intSponsorTypeID, strSponsorTypeDesc)
	VALUES (1, 'Parent')
		,(2, 'Alumni')
		,(3, 'Friend')
		,(4, 'Business')

---- --------------------------------------------------------------------------------
---- Step #7: Add payment types
---- --------------------------------------------------------------------------------
INSERT INTO TPaymentTypes ( intPaymentTypeID, strPaymentTypeDesc)
	VALUES (1, 'Check')
		,(2, 'Cash')
		,(3, 'Credit Card')
---- --------------------------------------------------------------------------------
---- Step #8: Add sponsors
---- --------------------------------------------------------------------------------

INSERT INTO TSponsors ( intSponsorID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail )
VALUES	 ( 1, 'Jim', 'Smith', '1979 Wayne Trace Rd.', 'Willow', 'OH', '42368', '5135551212', 'jsmith@yahoo.com' )
		,( 2, 'Sally', 'Jones', '987 Mills Rd.', 'Cincinnati', 'OH', '45202', '5135551234', 'sjones@yahoo.com' )
		,( 3, 'Bob', 'Barker', '987 Ashton Rd.', 'Cincinnati', 'OH', '45232', '5136661234', 'bbarker@yahoo.com' )
---- --------------------------------------------------------------------------------
---- Step #9: Add golfers
---- --------------------------------------------------------------------------------

INSERT INTO TGolfers ( intGolferID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID )
VALUES	 ( 1, 'Bill', 'Goldstein', '156 Main St.', 'Mason', 'OH', '45040', '5135559999', 'bGoldstein@yahoo.com', 1, 2 )
		,( 2, 'Tara', 'Everett', '3976 Deer Run', 'West Chester', 'OH', '45069', '5135550101', 'teverett@yahoo.com', 6, 1 )
		,( 3, 'Shane', 'Winslow', '292 Rampart Court', 'Fort Mitchell', 'KY', '41017', '8597394722', 'srwinslow@cincinnatistate.edu', 3, 2 )

---- --------------------------------------------------------------------------------
---- Step # 10: Add Golfers and sponsors to link them
---- --------------------------------------------------------------------------------

INSERT INTO TGolferEventYears ( intGolferEventYearID, intGolferID, intEventYearID)
	VALUES (1, 1, 1)
		,(2, 2, 1)
		,(3, 1, 2)
		,(4, 2, 2)

---- --------------------------------------------------------------------------------
---- Step # 10: Add Golfers and sponsors to link them
---- --------------------------------------------------------------------------------
INSERT INTO TGolferEventYearSponsors ( intGolferEventYearSponsorID, intGolferID, intEventYearID, intSponsorID, monPledgeAmount, intSponsorTypeID, intPaymentTypeID, blnPaid )
VALUES	 ( 1, 1, 1, 1, 25.00, 1, 1, 1 )
		,( 2, 1, 2, 2, 25.00, 1, 1, 1 )
		,( 3, 1, 2, 1, 50.00, 2, 2, 1 )
		,( 4, 2, 2, 1, 45.00, 3, 1, 1 )

-- ---------------------------------------------------------------------------------
-- Step # 11.1: Create a stored procedure to add an event year -uspAddEvent
-- ---------------------------------------------------------------------------------

GO

CREATE PROCEDURE uspAddEvent
		@intEventYearID		AS INTEGER OUTPUT			
		,@intEventYear		AS INTEGER			
AS

SET XACT_ABORT ON -- terminate and rollback if any errors

BEGIN TRANSACTION
	
	SELECT	@intEventYearID = MAX(intEventYearID) + 1
	FROM TEventYears (TABLOCKX) -- lock the table until end of transaction

	-- default to 1 if table is empty
	SELECT @intEventYearID = COALESCE(@intEventYearID, 1)

	INSERT INTO TEventYears (intEventYearID, intEventYear)
	VALUES					(@intEventYearID, @intEventYear)

COMMIT TRANSACTION

GO

-- ----------------------------------------------------------------------------------
-- Step #11.2: Create a stored procedure to add an event year -uspAddEvent
-- ----------------------------------------------------------------------------------

GO

CREATE PROCEDURE uspAddGolfer
	@intGolferID		AS INTEGER OUTPUT
	,@strFirstName		AS VARCHAR(50)
	,@strLastName		AS VARCHAR(50)		
	,@strStreetAddress	AS VARCHAR(50)		
	,@strCity			AS VARCHAR(50)		
	,@strState			AS VARCHAR(50)		
	,@strZip			AS VARCHAR(50)		
	,@strPhoneNumber	AS VARCHAR(50)		
	,@strEmail			AS VARCHAR(50)		
	,@intShirtSizeID	AS INTEGER			
	,@intGenderID		AS INTEGER			
AS

SET XACT_ABORT ON -- terminate and rollback if any errors

BEGIN TRANSACTION
	
	SELECT	@intGolferID = MAX(intGolferID) + 1
	FROM TGolfers (TABLOCKX) -- lock the table until end of transaction

	-- default to 1 if table is empty
	SELECT @intGolferID = COALESCE(@intGolferID, 1)

	INSERT INTO TGolfers (intGolferID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID)
	VALUES					(@intGolferID, @strFirstName, @strLastName, @strStreetAddress, @strCity, @strState, @strZip, @strPhoneNumber, @strEmail, @intShirtSizeID, @intGenderID)

COMMIT TRANSACTION

GO

-- ----------------------------------------------------------------------------------
-- Step #11.3: Create a stored procedure to add an sponsor -uspAddSponsor
-- ----------------------------------------------------------------------------------

GO

CREATE PROCEDURE uspAddSponsor
	@intSponsorID		AS INTEGER OUTPUT
	,@strFirstName		AS VARCHAR(50)
	,@strLastName		AS VARCHAR(50)		
	,@strStreetAddress	AS VARCHAR(50)		
	,@strCity			AS VARCHAR(50)		
	,@strState			AS VARCHAR(50)		
	,@strZip			AS VARCHAR(50)		
	,@strPhoneNumber	AS VARCHAR(50)		
	,@strEmail			AS VARCHAR(50)		
		
AS

SET XACT_ABORT ON -- terminate and rollback if any errors

BEGIN TRANSACTION
	
	SELECT	@intSponsorID = MAX(intSponsorID) + 1
	FROM TSponsors(TABLOCKX) -- lock the table until end of transaction

	-- default to 1 if table is empty
	SELECT @intSponsorID = COALESCE(@intSponsorID, 1)

	INSERT INTO TSponsors(intSponsorID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail)
	VALUES					(@intSponsorID, @strFirstName, @strLastName, @strStreetAddress, @strCity, @strState, @strZip, @strPhoneNumber, @strEmail)

COMMIT TRANSACTION

GO

-- ------------------------------------------------------------------------------------
-- Step #11.4 Create a stored procedure to add a golfer to an event year
-- ------------------------------------------------------------------------------------
GO

CREATE PROCEDURE uspAddGolferEvent
	@intGolferEventYearID	AS INTEGER OUTPUT
	,@intGolferID			AS INTEGER
	,@intEventYearID		AS INTEGER
AS

BEGIN TRANSACTION

	SELECT @intGolferEventYearID = MAX(intGolferEventYearID) + 1
	FROM TGolferEventYears (TABLOCKX)

	-- default to 1 if table is empty
	SELECT @intGolferEventYearID = COALESCE(@intGolferEventYearID, 1)

	INSERT INTO TGolferEventYears (intGolferEventYearID, intGolferID, intEventYearID)
	VALUES (@intGolferEventYearID, @intGolferID, @intEventYearID)

COMMIT TRANSACTION

GO

-- Test it
--DECLARE @intGolferEventYearID AS INTEGER = 0;
--EXECUTE uspAddGolferEvent @intGolferEventYearID OUTPUT, 3, 1
--PRINT 'Golfer ID = ' + CONVERT( VARCHAR, @intGolferEventYearID )

-- ------------------------------------------------------------------------------------
-- Step #11.4 Create a stored procedure to add a sponsorship to a golfer for an event year
-- ------------------------------------------------------------------------------------
GO

CREATE PROCEDURE uspAddGolferEventYearSponsor
	@intGolferEventYearSponsorID	AS INTEGER OUTPUT
	,@intGolferID					AS INTEGER
	,@intEventYearID				AS INTEGER
	,@intSponsorID					AS INTEGER
	,@monPledgeAmount				AS MONEY
	,@intSponsorTypeID				AS INTEGER
	,@intPaymentTypeID				AS INTEGER
	,@intPaymentStatusID			AS INTEGER

AS

BEGIN TRANSACTION

	SELECT @intGolferEventYearSponsorID = MAX(intGolferEventYearSponsorID) + 1
	FROM TGolferEventYearSponsors (TABLOCKX)

	-- default to 1 if table is empty
	SELECT @intGolferEventYearSponsorID = COALESCE(@intGolferEventYearSponsorID, 1)

	INSERT INTO TGolferEventYearSponsors (intGolferEventYearSponsorID, intGolferID, intEventYearID, intSponsorID, monPledgeAmount, intSponsorTypeID, intPaymentTypeID, blnPaid)
	VALUES (@intGolferEventYearSponsorID, @intGolferID, @intEventYearID, @intSponsorID, @monPledgeAmount, @intSponsorTypeID, @intPaymentTypeID, @intPaymentStatusID)

COMMIT TRANSACTION

GO

-- ------------------------------------------------------------------------------------
-- Step #12.1 Create a view for the Available Golfers within the database
-- ------------------------------------------------------------------------------------
GO

CREATE VIEW vAvailableGolfers
AS
SELECT 
	intGolferID
	,strLastName
	,strFirstName
FROM 
	TGolfers 
WHERE
	intGolferID NOT IN (SELECT intGolferID FROM TGolferEventYears WHERE intEventYearID = 
							(SELECT MAX(intEventYearID) FROM TEventYears))

GO

SELECT * FROM vAvailableGolfers

-- ----------------------------------------------------------------------------------------
-- Step #12.2 Create a view for the Golfers already assigned within a particular Event Year
-- ----------------------------------------------------------------------------------------

GO

CREATE VIEW vEventGolfers
AS
SELECT
	TG.intGolferID
	,TG.strLastName
	,TG.strFirstName
	,TE.intEventYearID
FROM
	TEventYears AS TE
		JOIN TGolferEventYears AS TGE
			ON TGE.intEventYearID = TE.intEventYearID
		JOIN TGolfers AS TG
			ON TGE.intGolferID = TG.intGolferID

GO

-- ------------------------------------------------------------------------------------
-- Step #12.3 Create a view for the Sponsors within the database
-- ------------------------------------------------------------------------------------
GO

CREATE VIEW vSponsors
AS
SELECT 
	intSponsorID, strLastName, strFirstName
FROM 
	TSponsors			

GO

-- ------------------------------------------------------------------------------------
-- Step #12.4 Create a view for the Sponsorships within the database
-- ------------------------------------------------------------------------------------
GO

CREATE VIEW vSponsorshipsGolfer
AS
SELECT 
	TGES.intGolferEventYearSponsorID, TGES.intEventYearID, TG.strFirstName + ' ' + TG.strLastName As 'Golfer', TGES.intGolferID, TS.strLastName + ', ' + TS.strFirstName + ', $' + STR(TGES.monPledgeAmount, 6, 2) As 'Sponsor', TGES.intSponsorID

FROM 
	TGolferEventYearSponsors AS TGES Join TGolfers As TG
	On TG.intGolferID = TGES.intGolferID

	Join TSponsors As TS
	On TS.intSponsorID = TGES.intSponsorID
							

GO

Select Sponsor, intSponsorID From vSponsorshipsGolfer Where intEventYearID = 2

-- ------------------------------------------------------------------------------------
-- Step #12.5 Create a view for the Sponsorship Totals Collected by Golfers within the database
-- ------------------------------------------------------------------------------------
GO

CREATE VIEW vSponsorshipTotalCollected
AS
SELECT 
	TGES.intEventYearID, TGES.intGolferID, Sum(TGES.monPledgeAmount) As 'TotalCollected'

FROM 
	TGolferEventYearSponsors as TGES
	
	Group by TGES.intEventYearID, TGES.intGolferID

GO

-- ------------------------------------------------------------------------------------
-- Step #12.6 Create a view for the Sponsorship Totals of the Amount Donated per Sponsor per Event within the database
-- ------------------------------------------------------------------------------------
GO

CREATE VIEW vSponsorshipTotalSponsored
AS
SELECT 
	TGES.intEventYearID, TGES.intSponsorID, Sum(TGES.monPledgeAmount) As 'TotalSponsored'

FROM 
	TGolferEventYearSponsors as TGES
	
	Group by TGES.intEventYearID, TGES.intSponsorID

GO

-- ------------------------------------------------------------------------------------
-- Step #12.7 Create a view for the Sponsorship Totals of the Amount Donated per Sponsor per Event within the database
-- ------------------------------------------------------------------------------------
GO

CREATE VIEW vEventTotal
AS
SELECT 
	TGES.intEventYearID, Sum(TGES.monPledgeAmount) As 'TotalEvent'

FROM 
	TGolferEventYearSponsors as TGES
	
	Group by TGES.intEventYearID

GO

-- ------------------------------------------------------------------------------------
-- Step #12.8 Create a view for the Participating Sponsors per Year within the database
-- ------------------------------------------------------------------------------------
GO

CREATE VIEW vParticipatingSponsors
AS
SELECT 
	TGES.intEventYearID, TS.strLastName + ', ' + TS.strFirstName As 'Sponsor', TGES.intSponsorID

FROM 
	TGolferEventYearSponsors AS TGES Join TSponsors As TS
	On TS.intSponsorID = TGES.intSponsorID
GO
